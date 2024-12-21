using System.Drawing.Text;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace SpaceDefender
{
    /// <summary>
    /// The main form of the SpaceDefender game, handling UI interactions and game state transitions.
    /// </summary>
    public partial class FormMain : Form
    {
        private readonly GameController _gameController = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="FormMain"/> class.
        /// </summary>
        public FormMain()
        {
            LoadFontFromFile();
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            InitializeComponent();
            InitCustomSliders();
        }

        /// <summary>
        /// Handles the form load event, setting the game controller for the main game panel.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            this.gamePanelMain.SetGameController(_gameController);
        }

        /// <summary>
        /// Initializes custom sliders for audio control.
        /// </summary>
        private void InitCustomSliders()
        {
            GlobalUtilsGUI.CustomSlider audioCustomSlider = new(0)
            {
                TabIndex = 6,
                Location = new Point(510, 160)
            };

            audioTableLayoutPanelContents.Controls.Add(audioCustomSlider, 2, 1);
            audioCustomSlider.ValueChanged += (s, e) =>
            {
                GlobalUtilsGUI.SoundVolume = audioCustomSlider.Value;
                AudioManagerHelpers.MusicPlayer!.Volume = audioCustomSlider.Value / 100.0f;

                this.audioLabelSfxVolume.Text = (GlobalUtilsGUI.SoundVolume < 10 ? " " : "") +
                                                (GlobalUtilsGUI.SoundVolume < 100 ? " " : "") +
                                                GlobalUtilsGUI.SoundVolume + "%";
            };
        }

        /// <summary>
        /// Handles the visibility change event for the main table layout panel.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void MainTableLayoutPanelMain_VisibleChanged(object sender, EventArgs e)
        {
            if (!mainTableLayoutPanelMain.Visible) return;

            bool shouldPlayMenuMusic = AudioManager.SongPlaying != "menu";

            if (shouldPlayMenuMusic)
            {
                AudioManager.PlayMusic(Properties.Resources.menu, "menu");
            }
        }

        // PLAY branch
        // Main
        /// <summary>
        /// Handles the click event for the Play button on the main menu.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void MainButtonPlay_Click(object sender, EventArgs e)
        {
            AudioManager.PlaySfx(Properties.Resources.button_click);

            this.playTextBoxWaveInput.Text = "";
            this.mainTableLayoutPanelMain.Hide();
            this.playTableLayoutPanelMain.Show();
        }

        /// <summary>
        /// Handles the mouse enter event for the Play button on the main menu.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void MainButtonPlay_MouseEnter(object sender, EventArgs e)
        {
            this.mainButtonPlay.BackColor = GlobalUtilsGUI.LighterRoyalBlue;
        }

        /// <summary>
        /// Handles the mouse leave event for the Play button on the main menu.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void MainButtonPlay_MouseLeave(object sender, EventArgs e)
        {
            this.mainButtonPlay.BackColor = Color.RoyalBlue;
        }

        // Easy
        /// <summary>
        /// Handles the click event for the Easy button on the play menu.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void PlayButtonEasy_Click(object sender, EventArgs e)
        {
            AudioManager.PlaySfx(Properties.Resources.button_click);

            GameController.SetGameDifficulty(GlobalVariablesGame.GameDifficultyLevel.Easy);

            ShowStartingGameScreen();
        }

        /// <summary>
        /// Handles the mouse enter event for the Easy button on the play menu.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void PlayButtonEasy_MouseEnter(object sender, EventArgs e)
        {
            this.playButtonEasy.BackColor = GlobalUtilsGUI.LighterRoyalBlue;
        }

        /// <summary>
        /// Handles the mouse leave event for the Easy button on the play menu.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void PlayButtonEasy_MouseLeave(object sender, EventArgs e)
        {
            this.playButtonEasy.BackColor = Color.RoyalBlue;
        }

        // Medium
        /// <summary>
        /// Handles the click event for the Medium button on the play menu.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void PlayButtonMedium_Click(object sender, EventArgs e)
        {
            AudioManager.PlaySfx(Properties.Resources.button_click);

            GameController.SetGameDifficulty(GlobalVariablesGame.GameDifficultyLevel.Medium);

            ShowStartingGameScreen();
        }

        /// <summary>
        /// Handles the mouse enter event for the Medium button on the play menu.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void PlayButtonMedium_MouseEnter(object sender, EventArgs e)
        {
            this.playButtonMedium.BackColor = GlobalUtilsGUI.LighterRoyalBlue;
        }

        /// <summary>
        /// Handles the mouse leave event for the Medium button on the play menu.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void PlayButtonMedium_MouseLeave(object sender, EventArgs e)
        {
            this.playButtonMedium.BackColor = Color.RoyalBlue;
        }

        // Hard
        /// <summary>
        /// Handles the click event for the Hard button on the play menu.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void PlayButtonHard_Click(object sender, EventArgs e)
        {
            AudioManager.PlaySfx(Properties.Resources.button_click);

            GameController.SetGameDifficulty(GlobalVariablesGame.GameDifficultyLevel.Hard);

            ShowStartingGameScreen();
        }

        /// <summary>
        /// Handles the mouse enter event for the Hard button on the play menu.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void PlayButtonHard_MouseEnter(object sender, EventArgs e)
        {
            this.playButtonHard.BackColor = GlobalUtilsGUI.LighterRoyalBlue;
        }

        /// <summary>
        /// Handles the mouse leave event for the Hard button on the play menu.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void PlayButtonHard_MouseLeave(object sender, EventArgs e)
        {
            this.playButtonHard.BackColor = Color.RoyalBlue;
        }

        // Start custom
        /// <summary>
        /// Handles the click event for the Start button on the custom play menu.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void PlayButtonStart_Click(object sender, EventArgs e)
        {
            AudioManager.PlaySfx(Properties.Resources.button_click);

            if (!GameController.SetWaveCount(playTextBoxWaveInput.Text, out string errorMessage))
            {
                this.playLabelWaveError.Text = errorMessage;

                System.Windows.Forms.Timer timer = new()
                {
                    Interval = 1000
                };
                timer.Tick += (s, args) =>
                {
                    timer.Stop();
                    this.playLabelWaveError.Text = "";
                };
                timer.Start();

                return;
            }

            GameController.SetDifficulty(GlobalVariablesGame.GameDifficultyLevel.Custom);

            ShowStartingGameScreen();
        }

        /// <summary>
        /// Handles the mouse enter event for the Start button on the custom play menu.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void PlayButtonStart_MouseEnter(object sender, EventArgs e)
        {
            this.playButtonStart.BackColor = GlobalUtilsGUI.LighterRoyalBlue;
        }

        /// <summary>
        /// Handles the mouse leave event for the Start button on the custom play menu.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void PlayButtonStart_MouseLeave(object sender, EventArgs e)
        {
            this.playButtonStart.BackColor = Color.RoyalBlue;
        }

        // Back
        /// <summary>
        /// Handles the click event for the Back button on the play menu.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void PlayButtonBack_Click(object sender, EventArgs e)
        {
            AudioManager.PlaySfx(Properties.Resources.button_click);

            this.playTableLayoutPanelMain.Hide();
            this.mainTableLayoutPanelMain.Show();
        }

        /// <summary>
        /// Handles the mouse enter event for the Back button on the play menu.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void PlayButtonBack_MouseEnter(object sender, EventArgs e)
        {
            this.playButtonBack.BackColor = GlobalUtilsGUI.LighterRoyalBlue;
        }

        /// <summary>
        /// Handles the mouse leave event for the Back button on the play menu.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void PlayButtonBack_MouseLeave(object sender, EventArgs e)
        {
            this.playButtonBack.BackColor = Color.RoyalBlue;
        }

        // STARTING screen
        /// <summary>
        /// Shows the starting game screen and initializes the game.
        /// </summary>
        private void ShowStartingGameScreen()
        {
            AudioManager.StopMusic();
            AudioManager.PlaySfx(Properties.Resources.game_starting);

            this.playTableLayoutPanelMain.Hide();
            this.startingTableLayoutPanelMain.Show();

            this.startingLabelStarting.Text = $"Starting {GlobalVariablesGame.GameDifficulty} game...";
            System.Windows.Forms.Timer timer = new()
            {
                Interval = 1500
            };
            timer.Tick += (s, args) =>
            {
                timer.Stop();
                this.startingTableLayoutPanelMain.Visible = false;

                _gameController.StartGameScreen(this.gamePanelMain, this.gameLabelStart, this.gameButtonMenu, this.gameLabelWave, this.OnGameEnd);
            };
            timer.Start();

            System.Windows.Forms.Timer initTimer = new()
            {
                Interval = 4050
            };
            initTimer.Tick += (s, args) =>
            {
                initTimer.Stop();
            };
            initTimer.Start();
        }

        // GAME screen
        private bool eventsSubscribed = false;

        /// <summary>
        /// Handles the visibility change event for the main game panel.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void GamePanelMain_VisibleChanged(object sender, EventArgs e)
        {
            if (this.gamePanelMain.Visible)
            {
                this.gamePanelMain.Focus();
                if (!eventsSubscribed)
                {
                    this.gamePanelMain.KeyDown += _gameController.GamePanel_KeyDown;
                    this.gamePanelMain.KeyUp += _gameController.GamePanel_KeyUp;
                    this.gamePanelMain.MouseDown += _gameController.GamePanel_MouseDown;
                    this.gamePanelMain.MouseUp += _gameController.GamePanel_MouseUp;
                    eventsSubscribed = true;
                }
            }
            else
            {
                if (eventsSubscribed)
                {
                    this.gamePanelMain.KeyDown -= _gameController.GamePanel_KeyDown;
                    this.gamePanelMain.KeyUp -= _gameController.GamePanel_KeyUp;
                    this.gamePanelMain.MouseDown -= _gameController.GamePanel_MouseDown;
                    this.gamePanelMain.MouseUp -= _gameController.GamePanel_MouseUp;
                    eventsSubscribed = false;
                }
            }
        }

        /// <summary>
        /// Handles the end of the game, displaying the appropriate screen based on the game outcome.
        /// </summary>
        private void OnGameEnd()
        {
            _gameController.StopGameTimers(this.gamePanelMain);
            if (GlobalVariablesGame.HasLost)
            {
                AudioManager.StopMusic();
                AudioManager.PlaySfx(Properties.Resources.lost_sfx);

                this.gameLabelStart.Text = " An alien managed to slip by!";
                this.gameLabelStart.ForeColor = Color.Firebrick;

                var delayTimer = new System.Timers.Timer(2500);
                delayTimer.Elapsed += (sender, e) =>
                {
                    delayTimer.Stop();
                    delayTimer.Dispose();

                    this.Invoke((Action)(() =>
                    {
                        this.gamePanelMain.Visible = false;
                        this.lostTableLayoutPanelMain.Visible = true;
                    }));
                };

                delayTimer.AutoReset = false;
                delayTimer.Start();
            }
            else
            {
                this.gamePanelMain.Visible = false;
                this.wonTableLayoutPanelMain.Visible = true;
            }
        }

        // Menu
        /// <summary>
        /// Handles the click event for the Menu button on the game screen.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void GameButtonMenu_Click(object sender, EventArgs e)
        {
            AudioManager.PlaySfx(Properties.Resources.button_click);
            AudioManager.StopMusic();
            AudioManager.PlayMusic(Properties.Resources.paused, "paused");

            _gameController.PauseGameTimers();
            this.gamePanelMain.Hide();
            this.pausedTableLayoutPanelMain.Show();
        }

        /// <summary>
        /// Handles the mouse enter event for the Menu button on the game screen.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void GameButtonMenu_MouseEnter(object sender, EventArgs e)
        {
            this.gameButtonMenu.BackColor = GlobalUtilsGUI.LighterRoyalBlue;
        }

        /// <summary>
        /// Handles the mouse leave event for the Menu button on the game screen.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void GameButtonMenu_MouseLeave(object sender, EventArgs e)
        {
            this.gameButtonMenu.BackColor = Color.RoyalBlue;
        }

        // PAUSED screen
        // Return
        /// <summary>
        /// Handles the click event for the Return button on the paused screen.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void PausedButtonReturn_Click(object sender, EventArgs e)
        {
            AudioManager.StopMusic();
            AudioManager.PlayMusic(Properties.Resources.game, "game");
            AudioManager.PlaySfx(Properties.Resources.button_click);

            _gameController.ResumeGameTimers();

            this.pausedTableLayoutPanelMain.Hide();
            this.gamePanelMain.Show();
        }

        /// <summary>
        /// Handles the mouse enter event for the Return button on the paused screen.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void PausedButtonReturn_MouseEnter(object sender, EventArgs e)
        {
            this.pausedButtonReturn.BackColor = GlobalUtilsGUI.LighterRoyalBlue;
        }

        /// <summary>
        /// Handles the mouse leave event for the Return button on the paused screen.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void PausedButtonReturn_MouseLeave(object sender, EventArgs e)
        {
            this.pausedButtonReturn.BackColor = Color.RoyalBlue;
        }

        // Exit
        /// <summary>
        /// Handles the click event for the Exit button on the paused screen.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void PausedButtonExit_Click(object sender, EventArgs e)
        {
            AudioManager.PlaySfx(Properties.Resources.button_click);

            _gameController.StopGameTimers(this.gamePanelMain);
            this.pausedTableLayoutPanelMain.Hide();
            this.mainTableLayoutPanelMain.Show();
        }

        /// <summary>
        /// Handles the mouse enter event for the Exit button on the paused screen.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void PausedButtonExit_MouseEnter(object sender, EventArgs e)
        {
            this.pausedButtonExit.BackColor = GlobalUtilsGUI.LighterRoyalBlue;
        }

        /// <summary>
        /// Handles the mouse leave event for the Exit button on the paused screen.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void PausedButtonExit_MouseLeave(object sender, EventArgs e)
        {
            this.pausedButtonExit.BackColor = Color.RoyalBlue;
        }

        // LOST screen
        /// <summary>
        /// Handles the visibility change event for the lost screen.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void LostTableLayoutPanelMain_VisibleChanged(object sender, EventArgs e)
        {
            if (lostTableLayoutPanelMain.Visible) AudioManager.PlayMusic(Properties.Resources.lost, "lost");
        }

        // Restart
        /// <summary>
        /// Handles the click event for the Restart button on the lost screen.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void LostButtonRestart_Click(object sender, EventArgs e)
        {
            AudioManager.PlaySfx(Properties.Resources.button_click);

            this.lostTableLayoutPanelMain.Hide();
            ShowStartingGameScreen();
        }

        /// <summary>
        /// Handles the mouse enter event for the Restart button on the lost screen.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void LostButtonRestart_MouseEnter(object sender, EventArgs e)
        {
            this.lostButtonRestart.BackColor = GlobalUtilsGUI.LighterFireBrick;
        }

        /// <summary>
        /// Handles the mouse leave event for the Restart button on the lost screen.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void LostButtonRestart_MouseLeave(object sender, EventArgs e)
        {
            this.lostButtonRestart.BackColor = Color.Firebrick;
        }

        // (back to) Main menu
        /// <summary>
        /// Handles the click event for the Main Menu button on the lost screen.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void LostButtonMainMenu_Click(object sender, EventArgs e)
        {
            AudioManager.PlaySfx(Properties.Resources.button_click);

            this.lostTableLayoutPanelMain.Hide();
            this.mainTableLayoutPanelMain.Show();
        }

        /// <summary>
        /// Handles the mouse enter event for the Main Menu button on the lost screen.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void LostButtonMainMenu_MouseEnter(object sender, EventArgs e)
        {
            this.lostButtonMainMenu.BackColor = GlobalUtilsGUI.LighterFireBrick;
        }

        /// <summary>
        /// Handles the mouse leave event for the Main Menu button on the lost screen.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void LostButtonMainMenu_MouseLeave(object sender, EventArgs e)
        {
            this.lostButtonMainMenu.BackColor = Color.Firebrick;
        }

        // WON screen
        /// <summary>
        /// Handles the visibility change event for the won screen.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void WonTableLayoutPanelMain_VisibleChanged(object sender, EventArgs e)
        {
            if (wonTableLayoutPanelMain.Visible) AudioManager.PlayMusic(Properties.Resources.won, "won");
        }

        // Main menu
        /// <summary>
        /// Handles the click event for the Main Menu button on the won screen.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void WonButtonMainMenu_Click(object sender, EventArgs e)
        {
            AudioManager.PlaySfx(Properties.Resources.button_click);

            this.wonTableLayoutPanelMain.Hide();
            this.mainTableLayoutPanelMain.Show();
        }

        /// <summary>
        /// Handles the mouse enter event for the Main Menu button on the won screen.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void WonButtonMainMenu_MouseEnter(object sender, EventArgs e)
        {
            this.wonButtonMainMenu.BackColor = GlobalUtilsGUI.LighterDarkGreen;
        }

        /// <summary>
        /// Handles the mouse leave event for the Main Menu button on the won screen.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void WonButtonMainMenu_MouseLeave(object sender, EventArgs e)
        {
            this.wonButtonMainMenu.BackColor = Color.DarkGreen;
        }

        // TUTORIAL branch
        // Main
        /// <summary>
        /// Handles the click event for the Tutorial button on the main menu.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void MainButtonTutorial_Click(object sender, EventArgs e)
        {
            AudioManager.PlaySfx(Properties.Resources.button_click);

            this.mainTableLayoutPanelMain.Hide();
            this.tutorialTableLayoutPanelMain.Show();
        }

        /// <summary>
        /// Handles the mouse enter event for the Tutorial button on the main menu.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void MainButtonTutorial_MouseEnter(object sender, EventArgs e)
        {
            this.mainButtonTutorial.BackColor = GlobalUtilsGUI.LighterRoyalBlue;
        }

        /// <summary>
        /// Handles the mouse leave event for the Tutorial button on the main menu.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void MainButtonTutorial_MouseLeave(object sender, EventArgs e)
        {
            this.mainButtonTutorial.BackColor = Color.RoyalBlue;
        }

        // Back
        /// <summary>
        /// Handles the click event for the Back button on the tutorial screen.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void TutorialButtonBack_Click(object sender, EventArgs e)
        {
            AudioManager.PlaySfx(Properties.Resources.button_click);

            this.tutorialTableLayoutPanelMain.Hide();
            this.mainTableLayoutPanelMain.Show();
        }

        /// <summary>
        /// Handles the mouse enter event for the Back button on the tutorial screen.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void TutorialButtonBack_MouseEnter(object sender, EventArgs e)
        {
            this.tutorialButtonBack.BackColor = GlobalUtilsGUI.LighterRoyalBlue;
        }

        /// <summary>
        /// Handles the mouse leave event for the Back button on the tutorial screen.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void TutorialButtonBack_MouseLeave(object sender, EventArgs e)
        {
            this.tutorialButtonBack.BackColor = Color.RoyalBlue;
        }

        // AUDIO branch
        // Main
        /// <summary>
        /// Handles the click event for the Audio button on the main menu.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void MainButtonAudio_Click(object sender, EventArgs e)
        {
            AudioManager.PlaySfx(Properties.Resources.button_click);

            this.mainTableLayoutPanelMain.Hide();
            this.audioTableLayoutPanelMain.Show();
        }

        /// <summary>
        /// Handles the mouse enter event for the Audio button on the main menu.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void MainButtonAudio_MouseEnter(object sender, EventArgs e)
        {
            this.mainButtonAudio.BackColor = GlobalUtilsGUI.LighterRoyalBlue;
        }

        /// <summary>
        /// Handles the mouse leave event for the Audio button on the main menu.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void MainButtonAudio_MouseLeave(object sender, EventArgs e)
        {
            this.mainButtonAudio.BackColor = Color.RoyalBlue;
        }

        // Mute 
        /// <summary>
        /// Handles the click event for the Mute button on the audio screen.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void AudioButtonMute_Click(object sender, EventArgs e)
        {
            if (GlobalUtilsGUI.SoundMute)
            {
                this.audioButtonMuteSfx.Text = "Mute";
            }
            else
            {
                this.audioButtonMuteSfx.Text = "Unmute";
                AudioManager.StopMusic();
            }

            GlobalUtilsGUI.SoundMute = !GlobalUtilsGUI.SoundMute;

            if (!GlobalUtilsGUI.SoundMute)
            {
                AudioManager.PlaySfx(Properties.Resources.button_click);
                AudioManager.PlayMusic(Properties.Resources.menu, "menu");
            }
        }

        /// <summary>
        /// Handles the mouse enter event for the Mute button on the audio screen.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void AudioButtonMute_MouseEnter(object sender, EventArgs e)
        {
            this.audioButtonMuteSfx.BackColor = GlobalUtilsGUI.LighterRoyalBlue;
        }

        /// <summary>
        /// Handles the mouse leave event for the Mute button on the audio screen.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void AudioButtonMute_MouseLeave(object sender, EventArgs e)
        {
            this.audioButtonMuteSfx.BackColor = Color.RoyalBlue;
        }

        // Back
        /// <summary>
        /// Handles the click event for the Back button on the audio screen.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void AudioButtonBack_Click(object sender, EventArgs e)
        {
            AudioManager.PlaySfx(Properties.Resources.button_click);

            this.audioTableLayoutPanelMain.Hide();
            this.mainTableLayoutPanelMain.Show();
        }

        /// <summary>
        /// Handles the mouse enter event for the Back button on the audio screen.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void AudioButtonBack_MouseEnter(object sender, EventArgs e)
        {
            this.audioButtonBack.BackColor = GlobalUtilsGUI.LighterRoyalBlue;
        }

        /// <summary>
        /// Handles the mouse leave event for the Back button on the audio screen.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void AudioButtonBack_MouseLeave(object sender, EventArgs e)
        {
            this.audioButtonBack.BackColor = Color.RoyalBlue;
        }

        // EXIT branch
        // Main
        /// <summary>
        /// Handles the click event for the Exit button on the main menu.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void MainButtonExit_Click(object sender, EventArgs e)
        {
            AudioManager.PlaySfx(Properties.Resources.button_click);

            this.mainTableLayoutPanelMain.Hide();
            this.exitTableLayoutPanelMain.Show();
        }

        /// <summary>
        /// Handles the mouse enter event for the Exit button on the main menu.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void MainButtonExit_MouseEnter(object sender, EventArgs e)
        {
            this.mainButtonExit.BackColor = GlobalUtilsGUI.LighterRoyalBlue;
        }

        /// <summary>
        /// Handles the mouse leave event for the Exit button on the main menu.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void MainButtonExit_MouseLeave(object sender, EventArgs e)
        {
            this.mainButtonExit.BackColor = Color.RoyalBlue;
        }

        // EXIT screen
        /// <summary>
        /// Handles the visibility change event for the exit screen.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void ExitTableLayoutPanelMain_VisibleChanged(object sender, EventArgs e)
        {
            if (this.exitTableLayoutPanelMain.Visible)
            {
                AudioManager.StopMusic();
            }
        }

        // Yes
        /// <summary>
        /// Handles the click event for the Yes button on the exit screen.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void ExitButtonYes_Click(object sender, EventArgs e)
        {
            AudioManager.PlaySfx(Properties.Resources.button_click);

            this.exitTableLayoutPanelMain.Hide();
            this.exitTableLayoutPanelExiting.Show();

            System.Windows.Forms.Timer timer = new()
            {
                Interval = 1500
            };
            timer.Tick += (s, args) =>
            {
                timer.Stop();
                Environment.Exit(0);
            };
            timer.Start();
        }

        /// <summary>
        /// Handles the mouse enter event for the Yes button on the exit screen.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void ExitButtonYes_MouseEnter(object sender, EventArgs e)
        {
            this.exitButtonYes.BackColor = GlobalUtilsGUI.LighterRoyalBlue;
        }

        /// <summary>
        /// Handles the mouse leave event for the Yes button on the exit screen.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void ExitButtonYes_MouseLeave(object sender, EventArgs e)
        {
            this.exitButtonYes.BackColor = Color.RoyalBlue;
        }

        // No
        /// <summary>
        /// Handles the click event for the No button on the exit screen.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void ExitButtonNo_Click(object sender, EventArgs e)
        {
            AudioManager.PlaySfx(Properties.Resources.button_click);

            this.exitTableLayoutPanelMain.Hide();
            this.mainTableLayoutPanelMain.Show();
        }

        /// <summary>
        /// Handles the mouse enter event for the No button on the exit screen.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void ExitButtonNo_MouseEnter(object sender, EventArgs e)
        {
            this.exitButtonNo.BackColor = GlobalUtilsGUI.LighterRoyalBlue;
        }

        /// <summary>
        /// Handles the mouse leave event for the No button on the exit screen.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void ExitButtonNo_MouseLeave(object sender, EventArgs e)
        {
            this.exitButtonNo.BackColor = Color.RoyalBlue;
        }

        // EXITING screen
        /// <summary>
        /// Handles the visibility change event for the exiting screen.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void ExitTableLayoutPanelExiting_VisibleChanged(object sender, EventArgs e)
        {
            if (this.exitTableLayoutPanelExiting.Visible)
            {
                AudioManager.PlaySfx(Properties.Resources.goodbye);
            }
        }
    }
}


