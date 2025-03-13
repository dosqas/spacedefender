namespace SpaceDefender
{
    /// <summary>
    /// Represents the ship that the player controls during the game.
    /// </summary>
    public class Ship
    {
        /// <summary>
        /// Gets or sets the current position of the ship in the game.
        /// </summary>
        /// <remarks>
        /// The position is represented as a <see cref="Point"/>, with the X and Y coordinates 
        /// specifying the ship's location on the game canvas.
        /// </remarks>
        public Point Position { get; set; }

        /// <summary>
        /// The size of the ship, represented as a <see cref="Size"/> object.
        /// </summary>
        /// <remarks>
        /// The ship's dimensions are fixed at 88x88 pixels.
        /// </remarks>
        public Size Size = new(88, 88);

        /// <summary>
        /// The current image of the ship, which changes based on movement direction.
        /// </summary>
        public Bitmap Image { get; private set; }

        /// <summary>
        /// The speed at which the ship moves horizontally.
        /// </summary>
        /// <remarks>
        /// The ship moves at a constant speed of 15 units per move.
        /// </remarks>
        public int Speed = 15;

        /// <summary>
        /// The stationary image of the ship when no movement is occurring.
        /// </summary>
        private readonly Bitmap stationaryShip;

        /// <summary>
        /// The image of the ship moving to the left.
        /// </summary>
        private readonly Bitmap shipLeft;

        /// <summary>
        /// The image of the ship moving to the right.
        /// </summary>
        private readonly Bitmap shipRight;

        /// <summary>
        /// Initializes a new instance of the <see cref="Ship"/> class with a specified starting position.
        /// </summary>
        /// <param name="startPosition">The initial position of the ship.</param>
        public Ship(Point startPosition)
        {
            Position = startPosition;

            // Load and resize ship images
            stationaryShip = GlobalUtilsGUI.ResizeImage(Properties.Resources.ship, Size);
            shipLeft = GlobalUtilsGUI.ResizeImage(Properties.Resources.ship_left, Size);
            shipRight = GlobalUtilsGUI.ResizeImage(Properties.Resources.ship_right, Size);

            // Set the initial ship image to the stationary state
            Image = stationaryShip;
        }

        /// <summary>
        /// Moves the ship to the left, if it is not already at the left boundary of the game area.
        /// </summary>
        /// <remarks>
        /// - The ship's X-coordinate is decreased by the value of <see cref="Speed"/>.
        /// - The ship's image is updated to represent leftward movement.
        /// </remarks>
        public void MoveLeft()
        {
            if (Position.X > 10)
            {
                Position = new Point(Position.X - Speed, Position.Y);
                Image = shipLeft;
            }
        }

        /// <summary>
        /// Moves the ship to the right, if it is not already at the right boundary of the game area.
        /// </summary>
        /// <remarks>
        /// - The ship's X-coordinate is increased by the value of <see cref="Speed"/>.
        /// - The ship's image is updated to represent rightward movement.
        /// </remarks>
        public void MoveRight()
        {
            if (Position.X + Size.Width < 1412)
            {
                Position = new Point(Position.X + Speed, Position.Y);
                Image = shipRight;
            }
        }

        /// <summary>
        /// Resets the ship's image to its stationary state.
        /// </summary>
        /// <remarks>
        /// This method is typically called when the ship stops moving.
        /// </remarks>
        public void ResetShip()
        {
            Image = stationaryShip;
        }

        /// <summary>
        /// Draws the ship at its current position on the game canvas.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> object used for rendering the ship.</param>
        public void Draw(Graphics g)
        {
            g.DrawImage(Image, Position.X, Position.Y);
        }
    }
}
