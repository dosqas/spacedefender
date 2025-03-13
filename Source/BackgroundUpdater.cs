namespace SpaceDefender
{
    /// <summary>
    /// The BackgroundUpdater class manages the background image and updates its scrolling effect
    /// to simulate continuous movement, creating a looping background for the game.
    /// </summary>
    public class BackgroundUpdater
    {
        private CancellationTokenSource? _cts; // The token used to signal cancellation of the function
        private Task? _backgroundUpdateTask; // The task of updating the background itself
        private ManualResetEventSlim _pauseEvent = new(true); // A helper variable to help us when the game is paused

        private int _backgroundOffset; // The current offset in the background image
        private const int BackgroundSpeed = 10; // Speed of background movement
        private const int BackgroundHeight = 2089; // Height of the background image
        private Image? _backgroundImage; // The background image to be used
        private Bitmap? _loopingBackgroundBitmap; // Bitmap for the looping background effect

        /// <summary>
        /// Starts the background update task, which continuously scrolls the background image.
        /// </summary>
        /// <param name="gamePanelMain">The main game panel where the background image is drawn.</param>
        public void StartBackgroundUpdateTask(Panel gamePanelMain)
        {
            StopBackgroundUpdateTask();
            _backgroundImage = Properties.Resources.backgroundGame; // Load background image from resources
            _backgroundOffset = 0;

            _cts = new CancellationTokenSource();

            _backgroundUpdateTask = Task.Run(async () =>
            {
                while (!_cts.Token.IsCancellationRequested)
                {
                    _pauseEvent.Wait();

                    await Task.Delay(8, _cts.Token); // Delay to control the speed of the background scroll

                    if (!_cts.Token.IsCancellationRequested)
                    {
                        gamePanelMain.BeginInvoke((Action)(() =>
                        {
                            UpdateBackground(gamePanelMain); // Update the background on the UI thread
                        }));
                    }
                }
            }, _cts.Token);
        }

        /// <summary>
        /// Stops the background update task and clears the background.
        /// </summary>
        public void StopBackgroundUpdateTask()
        {
            _cts?.Cancel();
            _pauseEvent.Set();

            Task.Run(() =>
            {
                _backgroundUpdateTask?.Wait();
            }).ContinueWith(task =>
            {
                if (_backgroundUpdateTask?.IsCompleted ?? false)
                {
                    _backgroundUpdateTask?.Dispose();
                }
            }, TaskScheduler.Default);
        }

        /// <summary>
        /// Pauses the background update task, halting the scrolling of the background.
        /// </summary>
        public void PauseBackgroundUpdateTask()
        {
            _pauseEvent.Reset();
        }

        /// <summary>
        /// Resumes the background update task, allowing the background to scroll again.
        /// </summary>
        public void ResumeBackgroundUpdateTask()
        {
            _pauseEvent.Set();
        }

        /// <summary>
        /// Updates the background image position to create the scrolling effect.
        /// The background will loop by resetting the offset once it reaches the end.
        /// </summary>
        /// <param name="gamePanelMain">The main game panel where the background is drawn.</param>
        private void UpdateBackground(Panel gamePanelMain)
        {
            // Update the background offset to simulate scrolling
            _backgroundOffset = (_backgroundOffset + BackgroundSpeed) % BackgroundHeight;

            if (_loopingBackgroundBitmap == null)
            {
                // Initialize the looping background bitmap if it's null
                _loopingBackgroundBitmap = new Bitmap(gamePanelMain.Width, gamePanelMain.Height);
            }

            using (Graphics g = Graphics.FromImage(_loopingBackgroundBitmap))
            {
                g.Clear(Color.Transparent); // Clear any previous drawing
                // Draw the background at the current offset and above it for looping effect
                g.DrawImage(_backgroundImage!, 0, _backgroundOffset);
                g.DrawImage(_backgroundImage!, 0, _backgroundOffset - BackgroundHeight);
            }

            // Set the new bitmap as the background image for the game panel
            gamePanelMain.BackgroundImage = _loopingBackgroundBitmap;
        }
    }
}
