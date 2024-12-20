namespace SpaceDefender
{
    /// <summary>
    /// Abstract class representing an alien in the game. The alien has properties such as speed, health points,
    /// position, and the ability to move and display a death animation.
    /// </summary>
    public abstract class Alien(Point startPosition, int speed, int healthPoints)
    {
        // Image representing the current alien state (either active or exploded)
        public Bitmap Image { get; protected set; } = Properties.Resources.alien1_1;

        // Speed of the alien's movement
        public int Speed { get; protected set; } = speed;

        // Health points of the alien
        public int HealthPoints { get; set; } = healthPoints;

        // The position of the alien on the screen
        public Point Position { get; set; } = startPosition;

        // Whether the alien is still active in the game
        public bool IsActive { get; set; } = true;

        // A rectangle representing the bounds of the alien for collision detection
        public Rectangle Bounds => new(Position, Image.Size);

        // A counter for how many times the alien has moved
        public int MoveCount = 0;

        // Alien images for animation and death sequence
        protected Bitmap image1 = Properties.Resources.alien1_1;
        protected Bitmap image2 = Properties.Resources.alien1_2;
        protected Bitmap deathImage1 = Properties.Resources.alien1_exploded1;
        protected Bitmap deathImage2 = Properties.Resources.alien1_exploded2;
        protected Bitmap deathImage3 = Properties.Resources.alien1_exploded3;

        // Flag to alternate between alien images for animation
        private bool image1Flag = true;

        // Counter for tracking how many steps the death animation has progressed
        public int AlienDeathAnimationCount { get; private set; } = 0;

        /// <summary>
        /// Moves the alien downward by its speed. If it goes off the screen, the alien is marked as inactive,
        /// and a loss condition is triggered in the game.
        /// </summary>
        public virtual void Move()
        {
            Position = new Point(Position.X, Position.Y + Speed);
            if (Position.Y + Image.Height > 660)
            {
                IsActive = false;
                GlobalVariablesGame.HasLost = true;
            }
        }

        /// <summary>
        /// Draws the death animation for the alien. The alien cycles through a series of images as it "explodes."
        /// </summary>
        /// <returns>True if the death animation is still playing, false otherwise.</returns>
        public virtual bool DrawDeathAnimation()
        {
            if (AlienDeathAnimationCount < 2)
            {
                Image = deathImage1;
                AlienDeathAnimationCount++;
                return true;
            }
            else if (AlienDeathAnimationCount < 6)
            {
                Image = deathImage2;
                AlienDeathAnimationCount++;
                return true;
            }
            else if (AlienDeathAnimationCount < 10)
            {
                Image = deathImage3;
                AlienDeathAnimationCount++;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Draws the alien at its current position on the provided graphics object.
        /// </summary>
        /// <param name="g">The graphics object used to draw the alien.</param>
        public virtual void Draw(Graphics g)
        {
            g.DrawImage(Image, Position.X, Position.Y);
        }

        /// <summary>
        /// Toggles between two images to create an animation effect.
        /// </summary>
        protected void ToggleAnimationImage()
        {
            image1Flag = !image1Flag;
            Image = image1Flag ? image1 : image2;
        }
    }

    // Subclass AlienType1
    /// <summary>
    /// Represents a specific type of alien in the game (AlienType1). In addition to the basic alien behavior, it includes 
    /// an animation where the alien switches between two images and moves at a specific speed.
    /// </summary>
    public class AlienType1 : Alien
    {
        /// <summary>
        /// Initializes a new instance of the AlienType1 class with a specified starting position.
        /// </summary>
        /// <param name="startPosition">The starting position of the alien on the screen.</param>
        public AlienType1(Point startPosition) : base(startPosition, speed: 5, healthPoints: 1)
        {
            image1 = GlobalUtilsGUI.ResizeImage(Properties.Resources.alien1_1, new Size(91, 77));
            image2 = GlobalUtilsGUI.ResizeImage(Properties.Resources.alien1_2, new Size(91, 77));
            deathImage1 = GlobalUtilsGUI.ResizeImage(Properties.Resources.alien1_exploded1, new Size(91, 77));
            deathImage2 = GlobalUtilsGUI.ResizeImage(Properties.Resources.alien1_exploded2, new Size(91, 77));
            deathImage3 = GlobalUtilsGUI.ResizeImage(Properties.Resources.alien1_exploded3, new Size(91, 77));
            Image = image1;
        }

        /// <summary>
        /// Moves the alien and toggles between the two images for animation every 20 moves.
        /// </summary>
        public override void Move()
        {
            base.Move();
            if (MoveCount % 20 == 0) ToggleAnimationImage();
            MoveCount++;
        }
    }


    // Subclass AlienType2
    /// <summary>
    /// Represents the second type of alien, which moves vertically and alternates its animation image every 20 moves.
    /// </summary>
    public class AlienType2 : Alien
    {
        /// <summary>
        /// Initializes a new instance of the AlienType2 class with the specified start position.
        /// </summary>
        /// <param name="startPosition">The initial position of the alien.</param>
        public AlienType2(Point startPosition) : base(startPosition, speed: 7, healthPoints: 1)
        {
            // Resize images for normal and death states
            image1 = GlobalUtilsGUI.ResizeImage(Properties.Resources.alien2_1, new Size(70, 49));
            image2 = GlobalUtilsGUI.ResizeImage(Properties.Resources.alien2_2, new Size(70, 49));
            deathImage1 = GlobalUtilsGUI.ResizeImage(Properties.Resources.alien2_exploded1, new Size(70, 49));
            deathImage2 = GlobalUtilsGUI.ResizeImage(Properties.Resources.alien2_exploded2, new Size(70, 49));
            deathImage3 = GlobalUtilsGUI.ResizeImage(Properties.Resources.alien2_exploded3, new Size(70, 49));
            Image = image1;  // Set the initial image
        }

        /// <summary>
        /// Moves the alien and toggles the animation image every 20 moves.
        /// </summary>
        public override void Move()
        {
            base.Move();
            if (MoveCount % 20 == 0) ToggleAnimationImage();  // Toggle image every 20 moves
            MoveCount++;  // Increment move count
        }
    }

    // Subclass AlienType3
    /// <summary>
    /// Represents the third type of alien, which performs a strafing movement (left and right) while descending.
    /// </summary>
    public class AlienType3 : Alien
    {
        private bool strafeLeft = false;
        private int strafeCount = 0;
        private const int strafeLength = 5;

        /// <summary>
        /// Initializes a new instance of the AlienType3 class with the specified start position.
        /// </summary>
        /// <param name="startPosition">The initial position of the alien.</param>
        public AlienType3(Point startPosition) : base(startPosition, speed: 5, healthPoints: 1)
        {
            // Resize images for strafing and death states
            image1 = GlobalUtilsGUI.ResizeImage(Properties.Resources.alien3_left, new Size(91, 77));
            image2 = GlobalUtilsGUI.ResizeImage(Properties.Resources.alien3_right, new Size(91, 77));
            deathImage1 = GlobalUtilsGUI.ResizeImage(Properties.Resources.alien3_exploded1, new Size(91, 77));
            deathImage2 = GlobalUtilsGUI.ResizeImage(Properties.Resources.alien3_exploded2, new Size(91, 77));
            deathImage3 = GlobalUtilsGUI.ResizeImage(Properties.Resources.alien3_exploded3, new Size(91, 77));
            Image = image1;  // Set the initial image
        }

        /// <summary>
        /// Moves the alien with strafing behavior (left and right) while descending.
        /// </summary>
        public override void Move()
        {
            strafeCount++;  // Increment strafe count to track movement
            if (strafeCount % 15 == 0)
            {
                strafeLeft = !strafeLeft;  // Toggle strafing direction every 15 moves
                Image = strafeLeft ? image1 : image2;  // Change image based on strafing direction
            }

            // Move the alien with clamped X position and increment Y position
            Position = new Point(
                Math.Clamp(Position.X + (strafeLeft ? -Speed * strafeLength : Speed * strafeLength), 100, 1372),
                Position.Y + Speed
            );

            // Check if the alien has gone out of bounds and set it as inactive
            if (Position.Y + Image.Height > 660)
            {
                IsActive = false;
                GlobalVariablesGame.HasLost = true;  // Update game state to lost
            }
        }
    }

    // Subclass AlienBoss1
    /// <summary>
    /// Represents the first boss alien type with the ability to be reborn, having different health points and images.
    /// </summary>
    public class AlienBoss1 : Alien
    {
        /// <summary>
        /// Initializes a new instance of the AlienBoss1 class with the specified start position and rebirth status.
        /// </summary>
        /// <param name="startPosition">The initial position of the alien.</param>
        /// <param name="isReborn">Indicates if the alien is reborn and has different health points and images.</param>
        public AlienBoss1(Point startPosition, bool isReborn) : base(startPosition, speed: 2, healthPoints: isReborn ? 7 : 6)
        {
            // Resize images for boss alien based on reborn status
            if (isReborn)
            {
                image1 = GlobalUtilsGUI.ResizeImage(Properties.Resources.alienboss1reborn_1, new Size(105, 105));
                image2 = GlobalUtilsGUI.ResizeImage(Properties.Resources.alienboss1reborn_2, new Size(105, 105));
            }
            else
            {
                image1 = GlobalUtilsGUI.ResizeImage(Properties.Resources.alienboss1_1, new Size(105, 105));
                image2 = GlobalUtilsGUI.ResizeImage(Properties.Resources.alienboss1_2, new Size(105, 105));
            }

            // Resize death images
            deathImage1 = GlobalUtilsGUI.ResizeImage(Properties.Resources.alienboss1_exploded1, new Size(105, 105));
            deathImage2 = GlobalUtilsGUI.ResizeImage(Properties.Resources.alienboss1_exploded2, new Size(105, 105));
            deathImage3 = GlobalUtilsGUI.ResizeImage(Properties.Resources.alienboss1_exploded3, new Size(105, 105));
            Image = image1;  // Set the initial image
        }

        /// <summary>
        /// Moves the alien and toggles the animation image every 20 moves.
        /// </summary>
        public override void Move()
        {
            base.Move();
            if (MoveCount % 20 == 0) ToggleAnimationImage();  // Toggle image every 20 moves
            MoveCount++;  // Increment move count
        }
    }


    // Subclass AlienBoss2
    /// <summary>
    /// Represents the second boss alien type, which can be reborn with different health points and images.
    /// </summary>
    public class AlienBoss2 : Alien
    {
        /// <summary>
        /// Initializes a new instance of the AlienBoss2 class with the specified start position and rebirth status.
        /// </summary>
        /// <param name="startPosition">The initial position of the alien.</param>
        /// <param name="isReborn">Indicates if the alien is reborn, having different health points and images.</param>
        public AlienBoss2(Point startPosition, bool isReborn) : base(startPosition, speed: 2, healthPoints: isReborn ? 5 : 4)
        {
            // Resize images for boss alien based on reborn status
            if (isReborn)
            {
                image1 = GlobalUtilsGUI.ResizeImage(Properties.Resources.alienboss2reborn_1, new Size(105, 105));
                image2 = GlobalUtilsGUI.ResizeImage(Properties.Resources.alienboss2reborn_2, new Size(105, 105));
            }
            else
            {
                image1 = GlobalUtilsGUI.ResizeImage(Properties.Resources.alienboss2_1, new Size(105, 105));
                image2 = GlobalUtilsGUI.ResizeImage(Properties.Resources.alienboss2_2, new Size(105, 105));
            }

            // Resize death images
            deathImage1 = GlobalUtilsGUI.ResizeImage(Properties.Resources.alienboss2_exploded1, new Size(105, 105));
            deathImage2 = GlobalUtilsGUI.ResizeImage(Properties.Resources.alienboss2_exploded2, new Size(105, 105));
            deathImage3 = GlobalUtilsGUI.ResizeImage(Properties.Resources.alienboss2_exploded3, new Size(105, 105));
            Image = image1;  // Set the initial image
        }

        /// <summary>
        /// Moves the alien and toggles the animation image every 20 moves.
        /// </summary>
        public override void Move()
        {
            base.Move();
            if (MoveCount % 20 == 0) ToggleAnimationImage();  // Toggle image every 20 moves
            MoveCount++;  // Increment move count
        }
    }

    // Subclass AlienBoss3
    /// <summary>
    /// Represents the third boss alien type, which can be reborn with different health points and images.
    /// </summary>
    public class AlienBoss3 : Alien
    {
        /// <summary>
        /// Initializes a new instance of the AlienBoss3 class with the specified start position and rebirth status.
        /// </summary>
        /// <param name="startPosition">The initial position of the alien.</param>
        /// <param name="isReborn">Indicates if the alien is reborn, having different health points and images.</param>
        public AlienBoss3(Point startPosition, bool isReborn) : base(startPosition, speed: 2, healthPoints: isReborn ? 2 : 3)
        {
            // Resize images for boss alien based on reborn status
            if (isReborn)
            {
                image1 = GlobalUtilsGUI.ResizeImage(Properties.Resources.alienboss3reborn_1, new Size(105, 105));
                image2 = GlobalUtilsGUI.ResizeImage(Properties.Resources.alienboss3reborn_2, new Size(105, 105));
            }
            else
            {
                image1 = GlobalUtilsGUI.ResizeImage(Properties.Resources.alienboss3_1, new Size(105, 105));
                image2 = GlobalUtilsGUI.ResizeImage(Properties.Resources.alienboss3_2, new Size(105, 105));
            }

            // Resize death images
            deathImage1 = GlobalUtilsGUI.ResizeImage(Properties.Resources.alienboss3_exploded1, new Size(105, 105));
            deathImage2 = GlobalUtilsGUI.ResizeImage(Properties.Resources.alienboss3_exploded2, new Size(105, 105));
            deathImage3 = GlobalUtilsGUI.ResizeImage(Properties.Resources.alienboss3_exploded3, new Size(105, 105));
            Image = image1;  // Set the initial image
        }

        /// <summary>
        /// Moves the alien and toggles the animation image every 20 moves.
        /// </summary>
        public override void Move()
        {
            base.Move();
            if (MoveCount % 20 == 0) ToggleAnimationImage();  // Toggle image every 20 moves
            MoveCount++;  // Increment move count
        }
    }
}