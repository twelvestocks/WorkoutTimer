namespace WorkoutTimerApp.Services;

/// <summary>
/// Interface for audio feedback during workouts including text-to-speech and sound effects
/// </summary>
public interface IAudioService
{
    /// <summary>
    /// Announce the name of an exercise using text-to-speech
    /// </summary>
    /// <param name="exerciseName">Name of the exercise to announce</param>
    /// <param name="cancellationToken">Cancellation token</param>
    Task AnnounceExerciseAsync(string exerciseName, CancellationToken cancellationToken = default);

    /// <summary>
    /// Announce time remaining in current interval
    /// </summary>
    /// <param name="secondsRemaining">Seconds remaining in interval</param>
    /// <param name="cancellationToken">Cancellation token</param>
    Task AnnounceTimeRemainingAsync(int secondsRemaining, CancellationToken cancellationToken = default);

    /// <summary>
    /// Play warning sound before interval completion
    /// </summary>
    /// <param name="secondsBeforeEnd">How many seconds before interval ends</param>
    /// <param name="cancellationToken">Cancellation token</param>
    Task PlayIntervalWarningAsync(int secondsBeforeEnd, CancellationToken cancellationToken = default);

    /// <summary>
    /// Play sound when interval completes
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    Task PlayIntervalCompleteAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Play countdown audio (3, 2, 1)
    /// </summary>
    /// <param name="countdownSeconds">Number to announce (1-3)</param>
    /// <param name="cancellationToken">Cancellation token</param>
    Task PlayCountdownAsync(int countdownSeconds, CancellationToken cancellationToken = default);

    /// <summary>
    /// Play workout completion sound
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    Task PlayWorkoutCompleteAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Configure text-to-speech settings
    /// </summary>
    /// <param name="settings">TTS configuration settings</param>
    /// <param name="cancellationToken">Cancellation token</param>
    Task ConfigureTtsSettingsAsync(TtsSettings settings, CancellationToken cancellationToken = default);

    /// <summary>
    /// Test audio output with sample announcement
    /// </summary>
    /// <param name="testMessage">Message to speak for testing</param>
    /// <param name="cancellationToken">Cancellation token</param>
    Task TestAudioAsync(string testMessage = "Audio test successful", CancellationToken cancellationToken = default);

    /// <summary>
    /// Check if audio output is available
    /// </summary>
    /// <returns>True if audio can be played</returns>
    Task<bool> IsAudioAvailableAsync();
}

/// <summary>
/// Text-to-speech configuration settings
/// </summary>
public class TtsSettings
{
    /// <summary>
    /// Speech rate (0.0 to 1.0, where 0.5 is normal)
    /// </summary>
    public float SpeechRate { get; set; } = 0.5f;

    /// <summary>
    /// Speech pitch (0.0 to 2.0, where 1.0 is normal)
    /// </summary>
    public float Pitch { get; set; } = 1.0f;

    /// <summary>
    /// Audio volume (0.0 to 1.0)
    /// </summary>
    public float Volume { get; set; } = 0.8f;

    /// <summary>
    /// Preferred TTS language/locale
    /// </summary>
    public string Locale { get; set; } = "en-GB";

    /// <summary>
    /// Whether to announce exercise names
    /// </summary>
    public bool AnnounceExercises { get; set; } = true;

    /// <summary>
    /// Whether to announce time remaining
    /// </summary>
    public bool AnnounceTimeRemaining { get; set; } = true;

    /// <summary>
    /// Whether to play warning sounds
    /// </summary>
    public bool PlayWarningSounds { get; set; } = true;

    /// <summary>
    /// Whether to play countdown (3-2-1)
    /// </summary>
    public bool PlayCountdown { get; set; } = true;
}