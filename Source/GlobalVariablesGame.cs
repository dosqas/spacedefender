namespace SpaceDefender
{
    /// <summary>
    /// Stores global variables and settings related to the game, 
    /// including difficulty level, wave count, and game status.
    /// </summary>
    public class GlobalVariablesGame
    {
        /// <summary>
        /// Represents the various difficulty levels available in the game.
        /// </summary>
        public enum GameDifficultyLevel
        {
            /// <summary>
            /// Easy difficulty level, suitable for beginners.
            /// </summary>
            Easy,

            /// <summary>
            /// Medium difficulty level, providing a balanced challenge.
            /// </summary>
            Medium,

            /// <summary>
            /// Hard difficulty level, designed for experienced players.
            /// </summary>
            Hard,

            /// <summary>
            /// Custom difficulty level, allowing players to define their own settings.
            /// </summary>
            Custom
        }

        /// <summary>
        /// The current difficulty level of the game.
        /// </summary>
        /// <remarks>
        /// This variable is set globally and affects various gameplay mechanics,
        /// such as alien spawn rates, boss strength, and other in-game factors.
        /// </remarks>
        public static GameDifficultyLevel GameDifficulty;

        /// <summary>
        /// The total number of waves in the game.
        /// </summary>
        /// <remarks>
        /// This value represents the number of alien waves the player needs to defeat to complete the game.
        /// It may vary based on the selected difficulty level or custom settings.
        /// </remarks>
        public static int WaveCount;

        /// <summary>
        /// Indicates whether the player has lost the game.
        /// </summary>
        /// <remarks>
        /// This boolean flag is set to `true` when the player's ship is destroyed or a critical objective is failed.
        /// It is used to trigger game-over mechanics and display the relevant UI.
        /// </remarks>
        public static bool HasLost;
    }
}