namespace SpaceDefender
{
    /// <summary>
    /// Manages the update loop and state of all aliens in the game.
    /// It handles adding, updating, pausing, resuming, and removing aliens.
    /// </summary>
    public class AlienUpdater
    {
        private CancellationTokenSource? _cts;
        private Task? _alienUpdateTask;
        private ManualResetEventSlim _pauseEvent = new(true);
        private readonly List<Alien> aliens = new();

        /// <summary>
        /// Starts the task that continuously updates the aliens' states.
        /// It runs on a separate thread to avoid blocking the main game loop.
        /// </summary>
        /// <param name="gamePanelMain">The main panel of the game for invoking UI updates.</param>
        public void StartAlienUpdateTask(Panel gamePanelMain)
        {
            // Ensure clean start
            StopAlienUpdateTask(gamePanelMain);

            _cts = new CancellationTokenSource();

            _alienUpdateTask = Task.Run(async () =>
            {
                while (!_cts.Token.IsCancellationRequested)
                {
                    _pauseEvent.Wait(); // Pauses the task when necessary

                    await Task.Delay(16, _cts.Token); // Wait for 16 ms (~60 FPS)

                    if (!_cts.Token.IsCancellationRequested)
                    {
                        // Update aliens on the main UI thread
                        gamePanelMain.BeginInvoke((Action)(() =>
                        {
                            UpdateAliens(gamePanelMain);
                        }));
                    }
                }
            }, _cts.Token);
        }

        /// <summary>
        /// Stops the alien update task and clears the alien list.
        /// </summary>
        /// <param name="gamePanelMain">The main panel of the game.</param>
        public void StopAlienUpdateTask(Panel gamePanelMain)
        {
            aliens.Clear(); // Clear the list of aliens

            _cts?.Cancel(); // Cancel the task
            _pauseEvent.Set(); // Ensure the task is not paused

            Task.Run(() =>
            {
                _alienUpdateTask?.Wait(); // Wait for task to complete
            }).ContinueWith(task =>
            {
                // Dispose the task when it completes
                if (_alienUpdateTask?.IsCompleted ?? false)
                {
                    _alienUpdateTask?.Dispose();
                }
            }, TaskScheduler.Default);
        }

        /// <summary>
        /// Pauses the alien update task.
        /// The task will not update aliens until resumed.
        /// </summary>
        public void PauseAlienUpdateTask()
        {
            _pauseEvent.Reset(); // Pause the task
        }

        /// <summary>
        /// Resumes the alien update task.
        /// The task will resume updating aliens.
        /// </summary>
        public void ResumeAlienUpdateTask()
        {
            _pauseEvent.Set(); // Resume the task
        }

        /// <summary>
        /// Updates the state of each alien in the game.
        /// This includes moving active aliens and handling death animations.
        /// </summary>
        /// <param name="gamePanelMain">The main panel of the game for drawing updated aliens.</param>
        private void UpdateAliens(Panel gamePanelMain)
        {
            foreach (var alien in aliens.ToList()) // Create a copy to prevent modification during iteration
            {
                if (alien.IsActive)
                {
                    alien.Move(); // Move the alien
                }
                else
                {
                    // Handle death animation and remove alien if it's fully exploded
                    if (!alien.DrawDeathAnimation()) aliens.Remove(alien);
                }
            }
        }

        /// <summary>
        /// Adds a new alien to the list of active aliens.
        /// </summary>
        /// <param name="newAlien">The alien to be added to the game.</param>
        /// <param name="gamePanelMain">The main panel of the game.</param>
        public void AddAlien(Alien newAlien, Panel gamePanelMain)
        {
            aliens.Add(newAlien);
        }

        /// <summary>
        /// Gets the current list of active aliens.
        /// </summary>
        /// <returns>A list of active aliens.</returns>
        public List<Alien> GetAliens()
        {
            return aliens;
        }
    }
}
