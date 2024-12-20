namespace SpaceDefender
{
    /// <summary>
    /// Represents a projectile in the game that can move and interact with other objects.
    /// </summary>
    public class Projectile
    {
        /// <summary>
        /// The speed at which the projectile moves upwards on the screen.
        /// </summary>
        public int Speed { get; set; } = 10;

        /// <summary>
        /// The current position of the projectile on the screen.
        /// </summary>
        public Point Position { get; set; }

        /// <summary>
        /// Indicates whether the projectile is currently active (visible and functional).
        /// </summary>
        /// <remarks>
        /// A projectile becomes inactive if it moves off the screen or interacts with a target.
        /// </remarks>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// The bounding rectangle of the projectile, used for collision detection.
        /// </summary>
        public Rectangle Bounds => new(Position, new Size(33, 44));

        /// <summary>
        /// The visual representation of the projectile.
        /// </summary>
        /// <remarks>
        /// The default image is loaded from resources as a 33x44 pixel bitmap.
        /// </remarks>
        public Bitmap Image { get; private set; } = Properties.Resources.projectile;

        /// <summary>
        /// Initializes a new instance of the <see cref="Projectile"/> class with a starting position.
        /// </summary>
        /// <param name="startPosition">The initial position of the projectile.</param>
        public Projectile(Point startPosition)
        {
            Position = startPosition;
        }

        /// <summary>
        /// Moves the projectile upwards by decreasing its Y-coordinate.
        /// </summary>
        /// <remarks>
        /// If the projectile moves off the top of the screen (Y-coordinate < 0), it becomes inactive.
        /// </remarks>
        public void Move()
        {
            Position = new Point(Position.X, Position.Y - Speed);

            if (Position.Y + 20 < 0) // Projectile is off the screen
            {
                IsActive = false;
            }
        }

        /// <summary>
        /// Draws the projectile on the screen at its current position.
        /// </summary>
        /// <param name="g">The graphics object used to render the projectile.</param>
        /// <remarks>
        /// The projectile is only drawn if it is active.
        /// </remarks>
        public void Draw(Graphics g)
        {
            if (IsActive)
            {
                g.DrawImage(Image, Position.X, Position.Y);
            }
        }
    }
}
