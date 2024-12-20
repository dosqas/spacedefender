namespace SpaceDefender
{
    /// <summary>
    /// Manages and updates the movement and state of projectiles in the game.
    /// </summary>
    public class ProjectileUpdater
    {
        /// <summary>
        /// The cancellation token source used to signal when the projectile update task should stop.
        /// </summary>
        private CancellationTokenSource? _cts;

        /// <summary>
        /// The task responsible for updating projectiles periodically.
        /// </summary>
        private Task? _projectileUpdateTask;

        /// <summary>
        /// Event used to pause and resume the projectile update task.
        /// </summary>
        /// <remarks>
        /// The task is initially running, as indicated by the `true` parameter.
        /// </remarks>
        private ManualResetEventSlim _pauseEvent = new(true);

        /// <summary>
        /// A list that holds all the active projectiles in the game.
        /// </summary>
        private readonly List<Projectile> projectiles = new();

        /// <summary>
        /// Starts the projectile update task, which periodically updates projectile states.
        /// </summary>
        /// <param name="gamePanelMain">The main game panel used to invoke UI updates.</param>
        /// <remarks>
        /// This method ensures any existing update task is stopped before starting a new one.
        /// Updates are executed approximately every 16ms (60 FPS).
        /// </remarks>
        public void StartProjectileUpdateTask(Panel gamePanelMain)
        {
            // Ensure clean start
            StopProjectileUpdateTask();

            _cts = new CancellationTokenSource();

            _projectileUpdateTask = Task.Run(async () =>
            {
                while (!_cts.Token.IsCancellationRequested)
                {
                    _pauseEvent.Wait(); // Wait if paused

                    await Task.Delay(16, _cts.Token); // Delay for 16ms (simulate 60 FPS)

                    if (!_cts.Token.IsCancellationRequested)
                    {
                        gamePanelMain.BeginInvoke((Action)(() =>
                        {
                            UpdateProjectiles(); // Update projectiles on the UI thread
                        }));
                    }
                }
            }, _cts.Token);
        }

        /// <summary>
        /// Stops the projectile update task and clears all active projectiles.
        /// </summary>
        /// <remarks>
        /// This method cancels the update task, waits for it to complete, and cleans up resources.
        /// </remarks>
        public void StopProjectileUpdateTask()
        {
            projectiles.Clear(); // Clear all projectiles

            _cts?.Cancel(); // Cancel the task
            _pauseEvent.Set(); // Ensure task is not paused

            // Wait for task completion and dispose resources
            Task.Run(() =>
            {
                _projectileUpdateTask?.Wait();
            }).ContinueWith(task =>
            {
                if (_projectileUpdateTask?.IsCompleted ?? false)
                {
                    _projectileUpdateTask?.Dispose();
                }
            }, TaskScheduler.Default);
        }

        /// <summary>
        /// Pauses the projectile update task.
        /// </summary>
        public void PauseProjectileUpdateTask()
        {
            _pauseEvent.Reset(); // Pauses the task
        }

        /// <summary>
        /// Resumes the projectile update task.
        /// </summary>
        public void ResumeProjectileUpdateTask()
        {
            _pauseEvent.Set(); // Resumes the task
        }

        /// <summary>
        /// Updates the state and position of all active projectiles.
        /// </summary>
        /// <remarks>
        /// - Active projectiles are moved by calling their `Move` method.
        /// - Inactive projectiles are removed from the list.
        /// </remarks>
        private void UpdateProjectiles()
        {
            foreach (var projectile in projectiles.ToList())
            {
                if (projectile.IsActive)
                {
                    projectile.Move();
                }
                else
                {
                    projectiles.Remove(projectile);
                }
            }
        }

        /// <summary>
        /// Adds a new projectile to the list of active projectiles.
        /// </summary>
        /// <param name="newProjectile">The projectile to be added.</param>
        public void AddProjectile(Projectile newProjectile)
        {
            projectiles.Add(newProjectile);
        }

        /// <summary>
        /// Gets the list of all active projectiles.
        /// </summary>
        /// <returns>A list of <see cref="Projectile"/> objects currently active.</returns>
        public List<Projectile> GetProjectiles()
        {
            return projectiles;
        }
    }
}
