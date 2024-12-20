namespace SpaceDefender
{
    /// <summary>
    /// Manages the waves of enemies in the game, including the configuration and progression of waves.
    /// </summary>
    public class WaveManager
    {
        /// <summary>
        /// Array containing all the waves in the game.
        /// </summary>
        public Wave[] Waves;

        /// <summary>
        /// The current wave index, starting from 1.
        /// </summary>
        public int CurrentWave = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="WaveManager"/> class.
        /// </summary>
        public WaveManager()
        {
            Waves = new Wave[16];
            InitWaveManager();
        }

        /// <summary>
        /// Initializes the <see cref="Waves"/> array with predefined wave configurations.
        /// </summary>
        /// <remarks>
        /// - Regular waves contain varying numbers of green, yellow, and red aliens.
        /// - Certain waves are designated as boss waves, which contain only a boss and no other aliens.
        /// </remarks>
        public void InitWaveManager()
        {
            Waves[1] = new Wave(5, 0, 0);
            Waves[2] = new Wave(7, 0, 0);
            Waves[3] = new Wave(8, 4, 0);
            Waves[4] = new Wave(9, 6, 2);
            Waves[5] = new Wave(0, 0, 0, true); // Boss wave
            Waves[6] = new Wave(11, 8, 4);
            Waves[7] = new Wave(12, 9, 6);
            Waves[8] = new Wave(0, 0, 0, true); // Boss wave
            Waves[9] = new Wave(13, 10, 8);
            Waves[10] = new Wave(14, 11, 9);
            Waves[11] = new Wave(15, 13, 10);
            Waves[12] = new Wave(0, 0, 0, true); // Boss wave
            Waves[13] = new Wave(0, 0, 0, true); // Boss wave
            Waves[14] = new Wave(0, 0, 0, true); // Boss wave
            Waves[15] = new Wave(0, 0, 0, true); // Boss wave
        }

        /// <summary>
        /// Checks whether the current wave has been completed.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the wave has no remaining aliens and no boss is present; otherwise, <c>false</c>.
        /// </returns>
        public bool CurrentWaveIsOver()
        {
            var wave = Waves[CurrentWave];
            return !wave.BossSpawned &&
                   wave.GreenAlienCount == 0 &&
                   wave.YellowAlienCount == 0 &&
                   wave.RedAlienCount == 0;
        }

        /// <summary>
        /// Marks the boss of the current wave as defeated.
        /// </summary>
        public void BossDefeated()
        {
            Waves[CurrentWave].BossSpawned = false;
        }

        /// <summary>
        /// Retrieves the count of a specific type of alien in the current wave.
        /// </summary>
        /// <param name="alienType">
        /// The type of alien to query:
        /// <list type="bullet">
        /// <item><description>1 for green aliens.</description></item>
        /// <item><description>2 for yellow aliens.</description></item>
        /// <item><description>3 for red aliens.</description></item>
        /// </list>
        /// </param>
        /// <returns>
        /// The count of the specified alien type in the current wave.
        /// </returns>
        public int GetCurrentWaveAlienTypeCount(int alienType)
        {
            switch (alienType)
            {
                case 1:
                    return Waves[CurrentWave].GreenAlienCount;
                case 2:
                    return Waves[CurrentWave].YellowAlienCount;
                case 3:
                    return Waves[CurrentWave].RedAlienCount;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// Decrements the count of a specific type of alien in the current wave by one.
        /// </summary>
        /// <param name="alienType">
        /// The type of alien to decrement:
        /// <list type="bullet">
        /// <item><description>1 for green aliens.</description></item>
        /// <item><description>2 for yellow aliens.</description></item>
        /// <item><description>3 for red aliens.</description></item>
        /// </list>
        /// </param>
        public void DecAlienTypeCount(int alienType)
        {
            switch (alienType)
            {
                case 1:
                    Waves[CurrentWave].GreenAlienCount--;
                    break;
                case 2:
                    Waves[CurrentWave].YellowAlienCount--;
                    break;
                case 3:
                    Waves[CurrentWave].RedAlienCount--;
                    break;
            }
        }
    }

    /// <summary>
    /// Represents a wave of enemies in the game.
    /// </summary>
    public class Wave
    {
        /// <summary>
        /// Gets or sets the number of green aliens in this wave.
        /// </summary>
        public int GreenAlienCount { get; set; }

        /// <summary>
        /// Gets or sets the number of yellow aliens in this wave.
        /// </summary>
        public int YellowAlienCount { get; set; }

        /// <summary>
        /// Gets or sets the number of red aliens in this wave.
        /// </summary>
        public int RedAlienCount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a boss is present in this wave.
        /// </summary>
        public bool BossSpawned { get; set; } = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="Wave"/> class.
        /// </summary>
        /// <param name="greenAlienCount">The initial count of green aliens.</param>
        /// <param name="yellowAlienCount">The initial count of yellow aliens.</param>
        /// <param name="redAlienCount">The initial count of red aliens.</param>
        /// <param name="bossSpawned">
        /// Whether a boss is present in this wave. Defaults to <c>false</c>.
        /// </param>
        public Wave(int greenAlienCount, int yellowAlienCount, int redAlienCount, bool bossSpawned = false)
        {
            GreenAlienCount = greenAlienCount;
            YellowAlienCount = yellowAlienCount;
            RedAlienCount = redAlienCount;
            BossSpawned = bossSpawned;
        }
    }
}
