namespace SpaceDefender
{
    /// <summary>
    /// Manages the overall game logic, including player actions, game state, and interactions between game entities.
    /// </summary>
    public class GameController
    {
        /// <summary>
        /// Timer for the main game loop.
        /// </summary>
        public System.Windows.Forms.Timer GameTimer;

        /// <summary>
        /// Manages the background scrolling effect.
        /// </summary>
        public BackgroundUpdater BackgroundUpdater = new();

        /// <summary>
        /// Manages the projectiles fired by the player.
        /// </summary>
        public ProjectileUpdater ProjectileUpdater = new();

        /// <summary>
        /// Manages the aliens in the game.
        /// </summary>
        public AlienUpdater AlienUpdater = new();

        /// <summary>
        /// Manages collision detection between projectiles and aliens.
        /// </summary>
        public CollisionManager CollisionManager;

        /// <summary>
        /// Represents the player's ship.
        /// </summary>
        public Ship Ship = new(new Point(667, 763));

        private bool isMovingLeft = false; // Flag to mark the ship is moving left
        private bool isMovingRight = false; // Flag to mark the ship is moving right
        private bool isShooting = false; // Flag to mark the ship is shooting

        private DateTime lastShotTime = DateTime.MinValue; // Variable to keep track of when the last projectile was shot
        private readonly int fireRateCooldown = 750; // Variable used to have a cooldown between shooting

        private DateTime lastAlienSpawnTime = DateTime.Now; // Variable to keep track of when the last alien was spawned
        private int alienSpawnRateCooldown = 2000; // Variable used to have a cooldown between alien spawns

        /// <summary>
        /// Manages the waves of aliens in the game.
        /// </summary>
        public WaveManager WaveManager = new();

        private DateTime? waveEndTime = null; // Keeps trach of when the last wave was ended to introduce a delay between waves

        /// <summary>
        /// Initializes a new instance of the <see cref="GameController"/> class.
        /// </summary>
        public GameController()
        {
            GameTimer = new System.Windows.Forms.Timer();
            CollisionManager = new CollisionManager(this);
        }

        /// <summary>
        /// Sets the wave count based on the input string.
        /// </summary>
        /// <param name="input">The input string representing the wave count.</param>
        /// <param name="errorMessage">The error message if the input is invalid.</param>
        /// <returns>True if the wave count is valid, otherwise false.</returns>
        public static bool SetWaveCount(string input, out string errorMessage)
        {
            if (int.TryParse(input, out int waveCount) && waveCount >= 1 && waveCount <= 15)
            {
                GlobalVariablesGame.WaveCount = waveCount;
                errorMessage = string.Empty;
                return true;
            }

            errorMessage = "Wave must be a number between 1-15!";
            return false;
        }

        /// <summary>
        /// Sets the game difficulty level.
        /// </summary>
        /// <param name="difficulty">The difficulty level to set.</param>
        public static void SetDifficulty(GlobalVariablesGame.GameDifficultyLevel difficulty)
        {
            GlobalVariablesGame.GameDifficulty = difficulty;
        }

        /// <summary>
        /// Sets the game difficulty level and adjusts the wave count accordingly.
        /// </summary>
        /// <param name="difficulty">The difficulty level to set.</param>
        public static void SetGameDifficulty(GlobalVariablesGame.GameDifficultyLevel difficulty)
        {
            GlobalVariablesGame.GameDifficulty = difficulty;

            switch (difficulty)
            {
                case GlobalVariablesGame.GameDifficultyLevel.Easy:
                    GlobalVariablesGame.WaveCount = 5;
                    break;
                case GlobalVariablesGame.GameDifficultyLevel.Medium:
                    GlobalVariablesGame.WaveCount = 8;
                    break;
                case GlobalVariablesGame.GameDifficultyLevel.Hard:
                    GlobalVariablesGame.WaveCount = 12;
                    break;
            }
        }

        /// <summary>
        /// Starts the game screen and initializes the game state.
        /// 
        /// Also acts to create the fading transition between starting and actually starting to play
        /// </summary>
        /// <param name="gamePanelMain">The main game panel.</param>
        /// <param name="gameLabelStart">The label displaying the start message.</param>
        /// <param name="gameButtonMenu">The button to open the game menu.</param>
        /// <param name="gameLabelWave">The label displaying the current wave.</param>
        /// <param name="onGameEnd">The action to perform when the game ends.</param>
        public void StartGameScreen(Panel gamePanelMain, Label gameLabelStart, Button gameButtonMenu, Label gameLabelWave, Action onGameEnd)
        {
            GlobalVariablesGame.HasLost = false;
            WaveManager = new WaveManager();

            // Set the initial background to backgroundInnerMenu
            gamePanelMain.BackgroundImage = Properties.Resources.backgroundInnerMenu;
            gamePanelMain.Visible = true;
            gameLabelStart.ForeColor = Color.RoyalBlue;
            gameLabelStart.Text = "Protect your planet, captain!";
            gameButtonMenu.Visible = false;
            gameLabelWave.Visible = false;

            float fadeOpacity = 0.0f;
            bool fadingToBlack = true;

            Image initialBackground = Properties.Resources.backgroundInnerMenu;
            Image targetBackground = Properties.Resources.backgroundGame;

            System.Windows.Forms.Timer fadeTimer = new()
            {
                Interval = 50
            };

            fadeTimer.Tick += (s, args) =>
            {
                if (fadingToBlack)
                {
                    fadeOpacity += 0.05f;

                    if (fadeOpacity >= 1.0f)
                    {
                        fadingToBlack = false;
                        fadeOpacity = 0.0f;
                        initialBackground = GlobalUtilsGUI.CreateSolidColorImage(gamePanelMain.Width, gamePanelMain.Height, Color.Black);
                    }
                    else
                    {
                        gamePanelMain.BackgroundImage = GlobalUtilsGUI.BlendImages(initialBackground, GlobalUtilsGUI.CreateSolidColorImage(gamePanelMain.Width, gamePanelMain.Height, Color.Black), fadeOpacity, gamePanelMain);
                    }
                }
                else
                {
                    fadeOpacity += 0.05f;

                    if (fadeOpacity >= 1.0f)
                    {
                        fadeTimer.Stop();
                        gamePanelMain.BackgroundImage = targetBackground;

                        System.Windows.Forms.Timer startTimer = new()
                        {
                            Interval = 500
                        };

                        startTimer.Tick += (startSender, startArgs) =>
                        {
                            AudioManager.PlayMusic(Properties.Resources.game, "game");
                            startTimer.Stop();

                            gameLabelStart.Text = "";
                            gameButtonMenu.Visible = true;
                            gameLabelWave.Text = "Wave:1 /" + GlobalVariablesGame.WaveCount + (GlobalVariablesGame.WaveCount < 10 ? " " : "");
                            gameLabelWave.Visible = true;

                            InitializeGameTimers(gamePanelMain, gameLabelWave, gameLabelStart, onGameEnd);
                        };

                        startTimer.Start();
                    }
                    else
                    {
                        gamePanelMain.BackgroundImage = GlobalUtilsGUI.BlendImages(GlobalUtilsGUI.CreateSolidColorImage(gamePanelMain.Width, gamePanelMain.Height, Color.Black), targetBackground, fadeOpacity, gamePanelMain);
                    }
                }

                gamePanelMain.Invalidate();
            };

            fadeTimer.Start();

            InitializeShip(gamePanelMain);
        }

        /// <summary>
        /// Initializes the ship's position and movement.
        /// </summary>
        /// <param name="gamePanelMain">The main game panel.</param>
        public void InitializeShip(Panel gamePanelMain)
        {
            int targetY = 650;
            int shipSpeed = 5;

            this.Ship!.Position = new Point(667, 763);

            System.Windows.Forms.Timer shipTimer = new()
            {
                Interval = 5
            };

            shipTimer.Tick += (s, e) =>
            {
                if (Ship.Position.Y > targetY)
                {
                    Ship.Position = new Point(Ship.Position.X, Ship.Position.Y - shipSpeed);
                }
                else
                {
                    shipTimer.Stop();
                }
                gamePanelMain.Invalidate();
            };

            shipTimer.Start();
        }

        /// <summary>
        /// Initializes the game timers and starts the main game loop.
        /// 
        /// Every tick we check if the player has:
        /// -lost
        /// -if the ship is moving
        /// -if the ship is shooting
        /// -if the wave is over and which alien to spawn
        /// -if the player won
        /// -update the wave label
        /// -check collisions
        /// 
        /// We also start the loop to update aliens, projectiles, and the background
        /// </summary>
        /// <param name="gamePanelMain">The main game panel.</param>
        /// <param name="gameLabelWave">The label displaying the current wave.</param>
        /// <param name="gameLabelStart">The label displaying the start message.</param>
        /// <param name="onGameEnd">The action to perform when the game ends.</param>
        public void InitializeGameTimers(Panel gamePanelMain, Label gameLabelWave, Label gameLabelStart, Action onGameEnd)
        {
            GameTimer = new System.Windows.Forms.Timer
            {
                Interval = 8
            };

            GameTimer.Tick += (sender, e) =>
            {
                if (GlobalVariablesGame.HasLost)
                {
                    onGameEnd?.Invoke();
                    GameTimer.Stop();
                    return;
                }

                if (isMovingLeft) Ship.MoveLeft();
                else if (isMovingRight) Ship.MoveRight();
                else Ship.ResetShip();

                if ((DateTime.Now - lastShotTime).TotalMilliseconds >= fireRateCooldown && isShooting)
                {
                    ShootProjectile();
                }

                if ((DateTime.Now - lastAlienSpawnTime).TotalMilliseconds >= alienSpawnRateCooldown && !WaveManager.CurrentWaveIsOver())
                {
                    var currentWave = WaveManager.CurrentWave;
                    if (WaveManager.Waves[currentWave].BossSpawned)
                    {
                        if (AudioManager.SongPlaying != "boss")
                            AudioManager.PlayMusic(Properties.Resources.boss, "boss");
                        SpawnAlien(gamePanelMain, WaveManager.CurrentWave);
                    }
                    else
                    {
                        lastAlienSpawnTime = DateTime.Now;

                        Random random = new();
                        int randAlienType = random.Next(1, 4);

                        while (WaveManager.GetCurrentWaveAlienTypeCount(randAlienType) == 0)
                        {
                            randAlienType = random.Next(1, 4);
                        }

                        WaveManager.DecAlienTypeCount(randAlienType);
                        SpawnAlien(gamePanelMain, randAlienType);
                    }
                }

                if (WaveManager.CurrentWaveIsOver() && AlienUpdater.GetAliens().Count == 0)
                {
                    if (waveEndTime == null)
                    {
                        waveEndTime = DateTime.Now;
                        if (WaveManager.CurrentWave == GlobalVariablesGame.WaveCount)
                        {
                            AudioManager.StopMusic();
                            AudioManager.PlaySfx(Properties.Resources.won_sfx);
                            gameLabelStart.Text = "The aliens have been defeated!";
                            gameLabelStart.ForeColor = Color.DarkGreen;
                        }
                        else
                        {
                            AudioManager.PlaySfx(Properties.Resources.wave_over);
                            gameLabelStart.Text = "Wave complete! Brace yourself!";
                        }
                    }

                    if ((DateTime.Now - waveEndTime.Value).TotalMilliseconds >= 2000)
                    {
                        if (WaveManager.CurrentWave == GlobalVariablesGame.WaveCount)
                        {
                            onGameEnd();
                        }
                        else
                        {
                            if (WaveManager.CurrentWave == 6 || WaveManager.CurrentWave == 9) alienSpawnRateCooldown -= 350;
                            gameLabelStart.Text = "";
                            WaveManager.CurrentWave++;
                            gameLabelWave.Text = "Wave:" + WaveManager.CurrentWave + (WaveManager.CurrentWave < 10 ? " " : "") + "/" + GlobalVariablesGame.WaveCount + (GlobalVariablesGame.WaveCount < 10 ? " " : "");
                            waveEndTime = null;
                        }
                    }
                }
                else
                {
                    waveEndTime = null;
                }

                int aliensNeededToSpawn = CollisionManager.CheckCollisions(gamePanelMain, ProjectileUpdater.GetProjectiles(), AlienUpdater.GetAliens());
                for (int i = 0; i < aliensNeededToSpawn; i++)
                {
                    SpawnAlien(gamePanelMain, 1);
                }

                gamePanelMain.Invalidate();
            };

            GameTimer.Start();

            BackgroundUpdater.StartBackgroundUpdateTask(gamePanelMain);
            ProjectileUpdater.StartProjectileUpdateTask(gamePanelMain);
            AlienUpdater.StartAlienUpdateTask(gamePanelMain);
        }

        /// <summary>
        /// Pauses the game timers and updates.
        /// </summary>
        public void PauseGameTimers()
        {
            isMovingLeft = false;
            isMovingRight = false;
            isShooting = false;
            GameTimer.Stop();
            BackgroundUpdater.PauseBackgroundUpdateTask();
            ProjectileUpdater.PauseProjectileUpdateTask();
            AlienUpdater.PauseAlienUpdateTask();
        }

        /// <summary>
        /// Resumes the game timers and updates.
        /// </summary>
        public void ResumeGameTimers()
        {
            GameTimer.Start();
            BackgroundUpdater.ResumeBackgroundUpdateTask();
            ProjectileUpdater.ResumeProjectileUpdateTask();
            AlienUpdater.ResumeAlienUpdateTask();
        }

        /// <summary>
        /// Stops the game timers and updates.
        /// </summary>
        /// <param name="gamePanelMain">The main game panel.</param>
        public void StopGameTimers(Panel gamePanelMain)
        {
            isMovingLeft = false;
            isMovingRight = false;
            isShooting = false;
            GameTimer.Stop();
            BackgroundUpdater.StopBackgroundUpdateTask();
            ProjectileUpdater.StopProjectileUpdateTask();
            AlienUpdater.StopAlienUpdateTask(gamePanelMain);
        }

        /// <summary>
        /// Handles the key down event for the game panel.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The key event arguments.</param>
        public void GamePanel_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                isMovingLeft = true;
            else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
                isMovingRight = true;
            else if (e.KeyCode == Keys.Space)
                isShooting = true;
        }

        /// <summary>
        /// Handles the key up event for the game panel.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The key event arguments.</param>
        public void GamePanel_KeyUp(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                isMovingLeft = false;
            else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
                isMovingRight = false;
            else if (e.KeyCode == Keys.Space)
                isShooting = false;
        }

        /// <summary>
        /// Handles the mouse down event for the game panel.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The mouse event arguments.</param>
        public void GamePanel_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                isShooting = true;
        }

        /// <summary>
        /// Handles the mouse up event for the game panel.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The mouse event arguments.</param>
        public void GamePanel_MouseUp(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                isShooting = false;
        }

        /// <summary>
        /// Shoots a projectile from the ship.
        /// </summary>
        public void ShootProjectile()
        {
            if ((DateTime.Now - lastShotTime).TotalMilliseconds >= fireRateCooldown)
            {
                AudioManager.PlaySfx(Properties.Resources.shot);
                lastShotTime = DateTime.Now;

                var projectile = new Projectile(new Point(Ship.Position.X + (88 / 2) - 17, Ship.Position.Y - 35));
                ProjectileUpdater.AddProjectile(projectile);
            }
        }

        /// <summary>
        /// Spawns an alien of the specified type at a random position.
        /// </summary>
        /// <param name="gamePanelMain">The main game panel.</param>
        /// <param name="alienType">The type of alien to spawn.</param>
        public void SpawnAlien(Panel gamePanelMain, int alienType)
        {
            Random random = new();
            int randX = random.Next(0, gamePanelMain.Width - 200);
            randX += 100;
            Alien newAlien;
            Point spawnPoint = new(randX, -100);
            bool isReborn = false;

            // Determine if the alien is a boss based on the alien type
            if (alienType == 13 || alienType == 14 || alienType == 15) isReborn = true;

            switch (alienType)
            {
                case 1:
                    {
                        newAlien = new AlienType1(spawnPoint);
                        break;
                    }
                case 2:
                    {
                        newAlien = new AlienType2(spawnPoint);
                        break;
                    }
                case 3:
                    {
                        newAlien = new AlienType3(spawnPoint);
                        break;
                    }
                case 5 or 13: // Boss Alien for Wave 5/13
                    {
                        newAlien = new AlienBoss1(spawnPoint, isReborn);
                        WaveManager.Waves[WaveManager.CurrentWave].BossSpawned = false; // Mark boss as spawned
                        break;
                    }
                case 8 or 14: // Boss Alien for Wave 8/14
                    {
                        newAlien = new AlienBoss2(spawnPoint, isReborn);
                        WaveManager.Waves[WaveManager.CurrentWave].BossSpawned = false; // Mark boss as spawned
                        break;
                    }
                case 12 or 15: // Boss Alien for Wave 12/15
                    {
                        newAlien = new AlienBoss3(spawnPoint, isReborn);
                        WaveManager.Waves[WaveManager.CurrentWave].BossSpawned = false; // Mark boss as spawned
                        break;
                    }
                default:
                    {
                        newAlien = new AlienType1(spawnPoint);
                        break;
                    }
            }

            AlienUpdater.AddAlien(newAlien, gamePanelMain);
        }
    }
}
