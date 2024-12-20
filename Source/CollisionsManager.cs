namespace SpaceDefender
{
    /// <summary>
    /// The CollisionManager class is responsible for managing and checking collisions between projectiles and aliens
    /// within the game, as well as updating the grid that tracks their positions for collision detection.
    /// </summary>
    public class CollisionManager
    {
        private readonly Dictionary<Point, List<Projectile>> projectileGrid = new();
        private readonly Dictionary<Point, List<Alien>> alienGrid = new();

        private readonly GameController _gameController;

        /// <summary>
        /// Initializes a new instance of the CollisionManager class with a reference to the GameController.
        /// </summary>
        /// <param name="gameController">The GameController instance used to manage game state.</param>
        public CollisionManager(GameController gameController)
        {
            _gameController = gameController;
        }

        /// <summary>
        /// Updates the grid with the current positions of projectiles and aliens.
        /// This is used to optimize collision detection by grouping entities into grid cells.
        /// </summary>
        /// <param name="projectiles">The list of projectiles in the game.</param>
        /// <param name="aliens">The list of aliens in the game.</param>
        public void UpdateGrid(List<Projectile> projectiles, List<Alien> aliens)
        {
            // Clear previous grid data
            projectileGrid.Clear();
            alienGrid.Clear();

            // Add projectiles to the grid
            foreach (var projectile in projectiles)
            {
                var gridKey = new Point(projectile.Position.X / 50, projectile.Position.Y / 50);
                if (!projectileGrid.ContainsKey(gridKey))
                    projectileGrid[gridKey] = new List<Projectile>();
                projectileGrid[gridKey].Add(projectile);
            }

            // Add aliens to the grid
            foreach (var alien in aliens)
            {
                var gridKey = new Point(alien.Position.X / 50, alien.Position.Y / 50);
                if (!alienGrid.ContainsKey(gridKey))
                    alienGrid[gridKey] = new List<Alien>();
                alienGrid[gridKey].Add(alien);
            }
        }

        /// <summary>
        /// Checks for collisions between active projectiles and aliens. If a collision is detected, the projectile is
        /// deactivated and the alien takes damage. If the alien's health reaches zero, it is deactivated, and specific
        /// actions are performed for different types of aliens (e.g., playing sound, handling special behavior for bosses).
        /// </summary>
        /// <param name="gamePanelMain">The main game panel used for the game interface.</param>
        /// <param name="projectiles">The list of projectiles in the game.</param>
        /// <param name="aliens">The list of aliens in the game.</param>
        /// <returns>
        /// - 0: No aliens to be spawned
        /// - 1: Spawn an alien (for the AlienBoss3 on wave 12)
        /// - 2: Spawn two aliens (for the AlienBoss3 on wave 15)
        /// </returns>
        public int CheckCollisions(Panel gamePanelMain, List<Projectile> projectiles, List<Alien> aliens)
        {
            foreach (var projectile in projectiles)
            {
                if (!projectile.IsActive) continue; // Skip inactive projectiles

                foreach (var alien in aliens)
                {
                    if (!alien.IsActive) continue; // Skip inactive aliens

                    // Check for collision between projectile and alien
                    if (projectile.Bounds.IntersectsWith(alien.Bounds))
                    {
                        projectile.IsActive = false; // Deactivate projectile

                        alien.HealthPoints--; // Decrease alien health

                        if (alien.HealthPoints == 0)
                        {
                            alien.IsActive = false; // Deactivate alien if health reaches zero
                            AudioManager.PlaySfx(Properties.Resources.alien_dead); // Play death sound

                            // Special handling for alien bosses
                            if (alien is AlienBoss1 or AlienBoss2 or AlienBoss3)
                            {
                                AudioManager.PlayMusic(Properties.Resources.game, "game"); // Play normal game music
                            }
                        }
                        else if (alien is AlienBoss2)
                        {
                            // Special behavior for AlienBoss2 (random position change)
                            Random random = new();
                            int randX = random.Next(0, (gamePanelMain.Width - 200));
                            randX += 100;

                            alien.Position = new Point(randX, alien.Position.Y);
                        }

                        if (alien is AlienBoss3)
                        {
                            // Special behavior for AlienBoss3 (trigger specific game condition)
                            if (_gameController.WaveManager.CurrentWave == 15)
                                return 2; // Spawn 2 aliens
                            return 1; // Spawn 1 alien
                        }
                    }
                }
            }
            return 0; // No special conditions met
        }
    }
}
