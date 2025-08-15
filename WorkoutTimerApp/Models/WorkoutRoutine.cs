namespace WorkoutTimerApp.Models;

/// <summary>
/// Represents a complete workout routine loaded from Google Sheets
/// </summary>
public class WorkoutRoutine
{
    /// <summary>
    /// Unique identifier for the workout routine
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Name of the workout routine (usually from sheet name)
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Google Sheets file ID for this routine
    /// </summary>
    public string GoogleSheetsId { get; set; } = string.Empty;

    /// <summary>
    /// Sheet name within the Google Sheets file
    /// </summary>
    public string SheetName { get; set; } = string.Empty;

    /// <summary>
    /// When this routine was last loaded from Google Sheets
    /// </summary>
    public DateTime LastUpdated { get; set; }

    /// <summary>
    /// List of exercises in this routine
    /// </summary>
    public List<Exercise> Exercises { get; set; } = new();

    /// <summary>
    /// Total duration of the workout routine
    /// </summary>
    public TimeSpan TotalDuration => TimeSpan.FromSeconds(Exercises.Sum(e => e.Duration.TotalSeconds));

    /// <summary>
    /// Number of exercises in the routine
    /// </summary>
    public int ExerciseCount => Exercises.Count;

    /// <summary>
    /// Number of active exercises (excluding rest periods)
    /// </summary>
    public int ActiveExerciseCount => Exercises.Count(e => !e.IsRest);

    /// <summary>
    /// Number of rest periods
    /// </summary>
    public int RestPeriodCount => Exercises.Count(e => e.IsRest);

    /// <summary>
    /// Formatted display text for total duration
    /// </summary>
    public string FormattedTotalDuration
    {
        get
        {
            var total = TotalDuration;
            if (total.Hours > 0)
                return $"{total.Hours}h {total.Minutes}m {total.Seconds}s";
            else if (total.Minutes > 0)
                return $"{total.Minutes}m {total.Seconds}s";
            else
                return $"{total.Seconds}s";
        }
    }

    /// <summary>
    /// Check if this routine is valid for workout execution
    /// </summary>
    public bool IsValid => !string.IsNullOrEmpty(Name) && Exercises.Count > 0;
}