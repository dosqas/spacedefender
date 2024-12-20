using NAudio.Wave;

namespace SpaceDefender
{
    /// <summary>
    /// The AudioManager class is responsible for managing and controlling audio playback in the application.
    /// It provides functionality to play and stop music, as well as play sound effects (SFX).
    /// </summary>
    public static class AudioManager
    {
        /// <summary>
        /// Gets the name of the currently playing song.
        /// </summary>
        public static string SongPlaying { get; private set; } = string.Empty;

        /// <summary>
        /// Makes a stream for the music found in the .resx file. Will then provide the stream for the
        /// MusicPlauer class found in the AudioManagerHelpers class.
        /// </summary>
        private static WaveStream? musicStream;

        /// <summary>
        /// Plays music from the provided <see cref="UnmanagedMemoryStream"/> data.
        /// If a song is already playing, it stops the current song and plays the new one.
        /// </summary>
        /// <param name="musicStreamData">The music data stream to be played.</param>
        /// <param name="musicName">The name of the music track being played.</param>
        /// <param name="loopPlayer">Specifies whether the music should loop. Default is false.</param>
        /// <exception cref="ArgumentException">Thrown when the provided music stream is null.</exception>
        public static void PlayMusic(UnmanagedMemoryStream musicStreamData, string musicName, bool loopPlayer = false)
        {
            // Check if sound is muted
            if (GlobalUtilsGUI.SoundMute) return;

            // Stop any currently playing music
            StopMusic();
            SongPlaying = musicName;

            // Validate input
            if (musicStreamData == null)
                throw new ArgumentException("Music stream is null or empty.");

            var memoryStream = new MemoryStream();
            musicStreamData.CopyTo(memoryStream);
            memoryStream.Position = 0;

            // Initialize music stream and player
            musicStream = new WaveFileReader(memoryStream);
            AudioManagerHelpers.MusicPlayer = new WaveOutEvent();

            if (loopPlayer)
            {
                // Use LoopStream if looping is enabled
                musicStream = new LoopStream(musicStream);
            }

            // Set volume and initialize player
            AudioManagerHelpers.MusicPlayer.Volume = GlobalUtilsGUI.SoundVolume / 100.0f;
            AudioManagerHelpers.MusicPlayer.Init(musicStream);
            AudioManagerHelpers.MusicPlayer.Play();
        }

        /// <summary>
        /// Stops the currently playing music and resets related states.
        /// </summary>
        public static void StopMusic()
        {
            SongPlaying = string.Empty;
            AudioManagerHelpers.MusicPlayer?.Stop();
            AudioManagerHelpers.MusicPlayer?.Dispose();
            musicStream?.Dispose();
            AudioManagerHelpers.MusicPlayer = null;
            musicStream = null;
        }

        /// <summary>
        /// Plays a sound effect (SFX) from the provided stream.
        /// </summary>
        /// <param name="sfxStream">The sound effect stream to be played.</param>
        /// <exception cref="ArgumentException">Thrown when the provided SFX stream is null.</exception>
        public static void PlaySfx(UnmanagedMemoryStream sfxStream)
        {
            // Check if sound is muted
            if (GlobalUtilsGUI.SoundMute) return;

            // Validate input
            if (sfxStream == null)
                throw new ArgumentException("SFX stream is null or empty.");

            Task.Run(() =>
            {
                using var memoryStream = new MemoryStream();
                sfxStream.CopyTo(memoryStream);
                memoryStream.Position = 0;

                // Initialize the wave reader and player
                using var waveReader = new WaveFileReader(memoryStream);
                using var waveOut = new WaveOutEvent();
                waveOut.Volume = GlobalUtilsGUI.SoundVolume / 100.0f;
                waveOut.Init(waveReader);
                waveOut.Play();

                // Wait for the sound effect to finish playing
                while (waveOut.PlaybackState == PlaybackState.Playing)
                {
                    Task.Delay(10).Wait();
                }
            });
        }
    }

    /// <summary>
    /// The LoopStream class is a custom implementation of <see cref="WaveStream"/> that loops the audio
    /// when it reaches the end, allowing continuous playback.
    /// </summary>
    public class LoopStream : WaveStream
    {
        private readonly WaveStream sourceStream;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoopStream"/> class with the specified source stream.
        /// </summary>
        /// <param name="sourceStream">The <see cref="WaveStream"/> to be looped.</param>
        public LoopStream(WaveStream sourceStream)
        {
            this.sourceStream = sourceStream;
        }

        /// <summary>
        /// Gets the wave format of the audio data.
        /// </summary>
        public override WaveFormat WaveFormat => sourceStream.WaveFormat;

        /// <summary>
        /// Gets the length of the stream in bytes.
        /// </summary>
        public override long Length => sourceStream.Length;

        /// <summary>
        /// Gets or sets the current position within the stream.
        /// </summary>
        public override long Position
        {
            get => sourceStream.Position;
            set => sourceStream.Position = value;
        }

        /// <summary>
        /// Reads audio data from the stream into the specified buffer.
        /// If the end of the stream is reached, it loops back to the beginning.
        /// </summary>
        /// <param name="buffer">The buffer to store the read audio data.</param>
        /// <param name="offset">The offset within the buffer to start writing.</param>
        /// <param name="count">The number of bytes to read.</param>
        /// <returns>The number of bytes read.</returns>
        public override int Read(byte[] buffer, int offset, int count)
        {
            int bytesRead = sourceStream.Read(buffer, offset, count);
            if (bytesRead < count)
            {
                sourceStream.Position = 0; // Loop back to the start
                bytesRead += sourceStream.Read(buffer, bytesRead, count - bytesRead);
            }
            return bytesRead;
        }
    }
}
