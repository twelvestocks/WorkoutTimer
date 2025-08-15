namespace WorkoutTimerApp.Models;

/// <summary>
/// Represents a single exercise or rest period in a workout routine
/// </summary>
public class Exercise
{
    /// <summary>
    /// Unique identifier for the exercise
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Name or description of the exercise action
    /// </summary>
    public string Action { get; set; } = string.Empty;

    /// <summary>
    /// Duration of the exercise
    /// </summary>
    public TimeSpan Duration { get; set; }

    /// <summary>
    /// Order position within the workout routine
    /// </summary>
    public int Order { get; set; }

    /// <summary>
    /// Whether this is a rest period or active exercise
    /// </summary>
    public bool IsRest { get; set; }

    /// <summary>
    /// Associated workout routine ID
    /// </summary>
    public int WorkoutRoutineId { get; set; }

    /// <summary>
    /// Formatted display text for exercise duration
    /// </summary>
    public string FormattedDuration => $"{Duration.Minutes:D2}:{Duration.Seconds:D2}";

    /// <summary>
    /// Sanitised action name suitable for text-to-speech
    /// </summary>
    public string SanitisedAction => SanitiseForTts(Action);

    /// <summary>
    /// Remove or replace characters that cause TTS pronunciation issues
    /// </summary>
    private static string SanitiseForTts(string input)
    {
        return input
            .Replace("&", " and ")
            .Replace("@", " at ")
            .Replace("#", " number ")
            .Replace("%", " percent ")
            .Replace("(", " ")
            .Replace(")", " ")
            .Replace("[", " ")
            .Replace("]", " ")
            .Replace("{", " ")
            .Replace("}", " ")
            .Trim();
    }
}