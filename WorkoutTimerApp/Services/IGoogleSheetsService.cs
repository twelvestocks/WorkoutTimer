using WorkoutTimerApp.Models;

namespace WorkoutTimerApp.Services;

/// <summary>
/// Interface for Google Sheets integration to load workout routines
/// </summary>
public interface IGoogleSheetsService
{
    /// <summary>
    /// Authenticate with Google account using OAuth 2.0
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if authentication successful</returns>
    Task<bool> AuthenticateAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Get list of available spreadsheet files from Google Drive
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>List of spreadsheet files</returns>
    Task<List<GoogleSpreadsheetFile>> GetAvailableSpreadsheetsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Get worksheet names from a specific spreadsheet
    /// </summary>
    /// <param name="spreadsheetId">Google Sheets file ID</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>List of worksheet names</returns>
    Task<List<string>> GetWorksheetNamesAsync(string spreadsheetId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Load workout routine from a specific Google Sheet
    /// </summary>
    /// <param name="spreadsheetId">Google Sheets file ID</param>
    /// <param name="sheetName">Name of the worksheet</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Parsed workout routine</returns>
    Task<WorkoutRoutine?> LoadWorkoutRoutineAsync(string spreadsheetId, string sheetName, CancellationToken cancellationToken = default);

    /// <summary>
    /// Validate that a sheet has the required column structure (Action, Time)
    /// </summary>
    /// <param name="spreadsheetId">Google Sheets file ID</param>
    /// <param name="sheetName">Name of the worksheet</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Validation result with any error messages</returns>
    Task<SheetValidationResult> ValidateSheetStructureAsync(string spreadsheetId, string sheetName, CancellationToken cancellationToken = default);

    /// <summary>
    /// Preview workout data from sheet without full parsing
    /// </summary>
    /// <param name="spreadsheetId">Google Sheets file ID</param>
    /// <param name="sheetName">Name of the worksheet</param>
    /// <param name="maxRows">Maximum number of rows to preview</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Preview of workout data</returns>
    Task<WorkoutPreview?> PreviewWorkoutDataAsync(string spreadsheetId, string sheetName, int maxRows = 10, CancellationToken cancellationToken = default);

    /// <summary>
    /// Check if user is currently authenticated
    /// </summary>
    /// <returns>True if authenticated and tokens are valid</returns>
    bool IsAuthenticated { get; }

    /// <summary>
    /// Sign out and clear stored credentials
    /// </summary>
    Task SignOutAsync();
}

/// <summary>
/// Represents a Google Sheets file available in user's Drive
/// </summary>
public class GoogleSpreadsheetFile
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public DateTime ModifiedTime { get; set; }
    public string WebViewLink { get; set; } = string.Empty;
}

/// <summary>
/// Result of validating a sheet's structure
/// </summary>
public class SheetValidationResult
{
    public bool IsValid { get; set; }
    public List<string> Errors { get; set; } = new();
    public List<string> Warnings { get; set; } = new();
    public bool HasActionColumn { get; set; }
    public bool HasTimeColumn { get; set; }
    public int DataRowCount { get; set; }
}

/// <summary>
/// Preview of workout data from a sheet
/// </summary>
public class WorkoutPreview
{
    public string SheetName { get; set; } = string.Empty;
    public List<ExercisePreview> Exercises { get; set; } = new();
    public TimeSpan EstimatedTotalDuration { get; set; }
    public int TotalExerciseCount { get; set; }
    public bool HasValidStructure { get; set; }
}

/// <summary>
/// Preview of a single exercise from sheet data
/// </summary>
public class ExercisePreview
{
    public string Action { get; set; } = string.Empty;
    public string TimeText { get; set; } = string.Empty;
    public TimeSpan? ParsedDuration { get; set; }
    public bool IsValidTime { get; set; }
    public int RowNumber { get; set; }
}