using NAudio.Wave;

/// <summary>
/// A helper for the AudioManager class. Used to have a bit cleaner code
/// </summary>
internal static class AudioManagerHelpers
{
    /// <summary>
    /// An instance of the <see cref="IWavePlayer"/> interface used for playing music.
    /// It allows the management of audio playback, such as playing, pausing, and stopping audio.
    /// </summary>
    public static IWavePlayer? MusicPlayer;
}
