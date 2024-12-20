using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace SpaceDefender
{
    /// <summary>
    /// The GlobalUtilsGUI class contains utility constants and settings related to the graphical user interface (GUI),
    /// including color definitions and audio settings. It also defines a custom slider control class used for volume or other settings,
    /// alongside the double buffered panels needed for smoother animations.
    /// </summary>
    public class GlobalUtilsGUI
    {
        /// <summary>
        /// A lighter shade of royal blue used for UI elements.
        /// </summary>
        public static readonly Color LighterRoyalBlue = Color.FromArgb(0xFF, 0x7A, 0x96, 0xEA);

        /// <summary>
        /// A lighter shade of firebrick red used for UI elements.
        /// </summary>
        public static readonly Color LighterFireBrick = Color.FromArgb(0xFF, 0xC1, 0x4E, 0x4E);

        /// <summary>
        /// A lighter shade of dark green used for UI elements.
        /// </summary>
        public static readonly Color LighterDarkGreen = Color.FromArgb(0xFF, 0x02, 0x4B, 0x30);

        /// <summary>
        /// The current sound volume level (0 to 100). Default value is 50.
        /// </summary>
        public static int SoundVolume = 50;

        /// <summary>
        /// A boolean value indicating whether sound is muted. Default value is false (not muted).
        /// </summary>
        public static bool SoundMute = false;

        /// <summary>
        /// The CustomSlider class extends TrackBar and provides a custom implementation of a slider control,
        /// typically used for adjusting settings like sound volume. The slider allows the user to drag the thumb to adjust values
        /// and is visually customized with different colors and styles.
        /// </summary>
        public class CustomSlider : TrackBar
        {
            /// <summary>
            /// A custom type identifier for the slider (e.g., for different purposes like volume, brightness, etc.).
            /// </summary>
            public int Type;

            /// <summary>
            /// Custom event triggered when the value of the slider changes.
            /// </summary>
            public new event EventHandler? ValueChanged;

            /// <summary>
            /// Initializes a new instance of the CustomSlider class with a specified type.
            /// The slider is customized with properties like size, colors, and minimum/maximum values.
            /// </summary>
            /// <param name="type">The type of slider (e.g., for volume, brightness, etc.).</param>
            public CustomSlider(int type)
            {
                // Set default properties
                SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
                this.Minimum = 0;
                this.Maximum = 100;
                this.Value = 50;
                this.TickStyle = TickStyle.Both;
                this.Height = 20;
                this.BackColor = Color.RoyalBlue;
                this.Size = new Size(400, 50);
                this.Type = type;

                this.Anchor = AnchorStyles.None;
                this.BackColor = Color.RoyalBlue;
            }

            /// <summary>
            /// Handles the custom drawing of the slider control. It draws the track and thumb based on the current value.
            /// </summary>
            /// <param name="e">The PaintEventArgs used for custom drawing.</param>
            protected override void OnPaint(PaintEventArgs e)
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Draw track
                Rectangle trackRect = new(0, this.Height / 2 - 2, this.Width, 4);
                using (Brush trackBrush = new SolidBrush(Color.LightGray))
                {
                    g.FillRectangle(trackBrush, trackRect);
                }

                // Calculate the thumb position based on the value
                float thumbPosition = (float)(this.Width - 10) * (this.Value - this.Minimum) / (this.Maximum - this.Minimum);

                // Draw thumb
                Rectangle thumbRect = new((int)thumbPosition, this.Height / 2 - 8, 10, 16);
                using (Brush thumbBrush = new SolidBrush(Color.White))
                {
                    g.FillRectangle(thumbBrush, thumbRect);
                }

                // Draw thumb border
                using Pen borderPen = new(Color.Gray);
                g.DrawRectangle(borderPen, thumbRect);
            }

            /// <summary>
            /// Handles mouse down events on the slider. It calculates and updates the slider's value based on the mouse position.
            /// </summary>
            /// <param name="e">The MouseEventArgs that contains information about the mouse event.</param>
            protected override void OnMouseDown(MouseEventArgs e)
            {
                base.OnMouseDown(e);
                UpdateValueFromMouse(e.X);
            }

            /// <summary>
            /// Handles mouse move events on the slider. It updates the slider's value if the mouse button is pressed.
            /// </summary>
            /// <param name="e">The MouseEventArgs that contains information about the mouse event.</param>
            protected override void OnMouseMove(MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    UpdateValueFromMouse(e.X);
                }
            }

            /// <summary>
            /// Updates the value of the slider based on the mouse's X-coordinate. The value is clamped between the minimum and maximum range.
            /// </summary>
            /// <param name="mouseX">The X-coordinate of the mouse, used to calculate the new slider value.</param>
            private void UpdateValueFromMouse(int mouseX)
            {
                float newValue = (float)mouseX / this.Width * (this.Maximum - this.Minimum) + this.Minimum;
                int clampedValue = Math.Min(this.Maximum, Math.Max(this.Minimum, (int)newValue));

                if (clampedValue != this.Value)
                {
                    this.Value = clampedValue;
                    Invalidate(); // Redraw the slider

                    // Raise custom event to notify listeners of the value change
                    OnValueChanged(EventArgs.Empty);
                }
            }

            /// <summary>
            /// Invoked when the value of the slider changes. This triggers the custom ValueChanged event.
            /// </summary>
            /// <param name="e">The EventArgs for the value change event.</param>
            protected override void OnValueChanged(EventArgs e)
            {
                ValueChanged?.Invoke(this, e); // Notify listeners
            }
        }

        /// <summary>
        /// The DoubleBufferedTableLayoutPanel class is a custom TableLayoutPanel that enables double buffering,
        /// helping to prevent flickering during rendering and improving performance.
        /// </summary>
        public class DoubleBufferedTableLayoutPanel : TableLayoutPanel
        {
            /// <summary>
            /// Initializes a new instance of the DoubleBufferedTableLayoutPanel class with double buffering enabled.
            /// </summary>
            public DoubleBufferedTableLayoutPanel()
            {
                this.DoubleBuffered = true;
                this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                this.UpdateStyles();
            }
        }

        /// <summary>
        /// The DoubleBufferedPanel class is a custom Panel that enables double buffering to improve rendering performance,
        /// reducing flickering and improving visual smoothness during rendering. This panel is used to display game elements.
        /// </summary>
        public class DoubleBufferedPanel : Panel
        {
            private GameController _gameController = new();

            /// <summary>
            /// Initializes a new instance of the DoubleBufferedPanel class with double buffering enabled.
            /// </summary>
            public DoubleBufferedPanel()
            {
                this.DoubleBuffered = true;
                this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                this.SetStyle(ControlStyles.UserPaint, true);
                this.UpdateStyles();
            }

            /// <summary>
            /// Sets the GameController for the panel. This controller manages the game elements like the ship, aliens, and projectiles.
            /// </summary>
            /// <param name="gameController">The GameController instance to be used by the panel.</param>
            public void SetGameController(GameController gameController)
            {
                this._gameController = gameController;
            }

            /// <summary>
            /// Handles the custom painting of the panel. It draws the game elements such as the ship, aliens, and projectiles.
            /// </summary>
            /// <param name="e">The PaintEventArgs used for custom drawing on the panel.</param>
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);

                // Draw aliens and projectiles
                DrawAliensAndProjectiles(e.Graphics);

                // Draw the ship
                DrawShip(e.Graphics);
            }

            /// <summary>
            /// Draws the aliens and projectiles on the panel.
            /// </summary>
            /// <param name="g">The Graphics object used for drawing the game elements.</param>
            private void DrawAliensAndProjectiles(Graphics g)
            {
                List<Alien> aliens = _gameController.AlienUpdater.GetAliens();
                List<Projectile> projectiles = _gameController.ProjectileUpdater.GetProjectiles();

                foreach (var alien in aliens)
                {
                    alien?.Draw(g);
                }

                // Draw all projectiles
                foreach (var projectile in projectiles)
                {
                    if (projectile != null && projectile.IsActive)
                    {
                        projectile.Draw(g);
                    }
                }
            }

            /// <summary>
            /// Draws the ship on the panel.
            /// </summary>
            /// <param name="g">The Graphics object used for drawing the ship.</param>
            private void DrawShip(Graphics g)
            {
                _gameController.Ship!.Draw(g);
            }
        }

        /// <summary>
        /// Resizes an image to a new specified size while maintaining high quality during resizing.
        /// </summary>
        /// <param name="image">The original image to be resized.</param>
        /// <param name="newSize">The new size for the resized image.</param>
        /// <returns>A Bitmap containing the resized image.</returns>
        public static Bitmap ResizeImage(Image image, Size newSize)
        {
            Bitmap resizedImage = new(newSize.Width, newSize.Height);
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                g.DrawImage(image, 0, 0, newSize.Width, newSize.Height);
            }
            return resizedImage;
        }

        /// <summary>
        /// Blends two images together with a specified opacity for the second image.
        /// </summary>
        /// <param name="image1">The first image (background) to be drawn.</param>
        /// <param name="image2">The second image (foreground) to be blended with the first image.</param>
        /// <param name="opacity">The opacity of the second image, where 1 is fully opaque and 0 is fully transparent.</param>
        /// <param name="panel">The Panel where the blended image will be drawn.</param>
        /// <returns>A Bitmap containing the blended images.</returns>
        public static Bitmap BlendImages(Image image1, Image image2, float opacity, Panel panel)
        {
            // Create a bitmap with the size of the panel
            Bitmap blendedImage = new(panel.Width, panel.Height);

            using (Graphics g = Graphics.FromImage(blendedImage))
            {
                // Set the interpolation mode for better image quality
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                // Draw the first image (image1, which is backgroundInnerMenu fading to black)
                g.DrawImage(image1, new Rectangle(0, 0, panel.Width, panel.Height));

                // Create a ColorMatrix to control the opacity of the second image
                ColorMatrix colorMatrix = new()
                {
                    Matrix33 = opacity  // Control the opacity of the second image
                };

                ImageAttributes attributes = new();
                attributes.SetColorMatrix(colorMatrix);

                // Draw the second image (image2, which is backgroundGame) with opacity
                g.DrawImage(image2, new Rectangle(0, 0, panel.Width, panel.Height), 0, 0, panel.Width, panel.Height, GraphicsUnit.Pixel, attributes);
            }

            return blendedImage;
        }

        /// <summary>
        /// Creates a solid color image with the specified dimensions and color.
        /// </summary>
        /// <param name="width">The width of the image.</param>
        /// <param name="height">The height of the image.</param>
        /// <param name="color">The color to fill the image with.</param>
        /// <returns>An Image filled with the specified color.</returns>
        public static Image CreateSolidColorImage(int width, int height, Color color)
        {
            Bitmap solidColorImage = new(width, height);

            using (Graphics g = Graphics.FromImage(solidColorImage))
            {
                g.Clear(color);
            }

            return solidColorImage;
        }
    }
}
