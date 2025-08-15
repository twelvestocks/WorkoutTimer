# CLAUDE.md - Workout Timer App

## Project Overview
**Project Name:** Workout Timer App
**Type:** .NET MAUI Android Application
**Primary Language:** C# 12.0

## Project Management Protocol
**ALWAYS follow this workflow:**
- Always read PLANNING.md at the start of every new conversation
- Check TASKS.md before starting your work
- Mark completed tasks immediately
- Add newly discovered tasks

## Technology Stack
- **Framework:** .NET MAUI 8.0
- **Language:** C# 12.0 with nullable reference types enabled
- **UI Framework:** XAML with MVVM data binding
- **Database:** Entity Framework Core 8.0 with SQLite
- **APIs:** Google.Apis.Drive.v3, Google.Apis.Sheets.v4, Google.Apis.Auth
- **Testing:** MSTest with manual device testing
- **IDE:** Visual Studio 2022

## Project Structure
```
WorkoutTimerApp/
├── Models/              # Data entities and DTOs
├── ViewModels/          # MVVM view models with INotifyPropertyChanged
├── Views/              # XAML pages and user controls
├── Services/           # Business logic and API integration services
├── Data/               # Entity Framework context and repositories
├── Platforms/Android/  # Android-specific implementations
├── Resources/          # Images, sounds, styles, and localisation
└── Helpers/            # Utility classes and extensions
```

## Essential Commands
```bash
# Development
dotnet build                     # Build solution
dotnet run --framework net8.0-android   # Run on Android
dotnet test                      # Run unit tests
dotnet workload install maui     # Install MAUI workload

# Android deployment
dotnet build -f net8.0-android -c Release  # Release build
dotnet publish -f net8.0-android -c Release # Create APK

# Package management
dotnet add package [PackageName]         # Add NuGet package
dotnet list package                      # List installed packages
dotnet restore                          # Restore packages
```

## Code Style & Standards
- Use C# 12.0 features including file-scoped namespaces and nullable reference types
- Follow Microsoft C# coding conventions with PascalCase for public members
- Use async/await for all I/O operations (Google APIs, database, file access)
- Implement MVVM pattern with proper data binding and INotifyPropertyChanged
- Use dependency injection for all services through MauiProgram.cs
- Always add XML documentation comments for public classes and methods

## MVVM Implementation Standards
- ViewModels must inherit from BaseViewModel with INotifyPropertyChanged
- Use RelayCommand or Command for button and gesture bindings
- Implement proper property change notifications for all bound properties
- Use ObservableCollection for dynamic lists that update the UI
- Separate UI logic in ViewModels from business logic in Services

## Google API Integration Patterns
- Always use async/await for Google API calls
- Implement proper OAuth 2.0 token refresh logic
- Cache API responses locally using Entity Framework
- Handle rate limiting with exponential backoff retry
- Use read-only scopes: `https://www.googleapis.com/auth/drive.readonly` and `https://www.googleapis.com/auth/spreadsheets.readonly`

## Timer Implementation Requirements
- Use System.Timers.Timer for precise interval timing
- Implement timer drift compensation for long sessions
- Always run timer callbacks on background thread and marshal UI updates to main thread
- Persist timer state to handle app lifecycle interruptions
- Maintain accuracy within ±500ms for intervals up to 60 minutes

## Audio System Standards
- Use Android.Speech.Tts.TextToSpeech for voice announcements
- Implement IAudioService interface for dependency injection
- Configure TTS with appropriate speech rate and pitch
- Use Android.Media.MediaPlayer for sound effects
- Always check audio output availability before playing sounds

## Error Handling Patterns
- Use try-catch blocks around all Google API calls with specific exception handling
- Implement user-friendly error messages for common scenarios
- Log errors with sufficient detail for debugging but avoid sensitive data
- Provide offline fallback options when network operations fail
- Use Result<T> pattern for operations that can fail

## Data Validation Rules
- Validate Google Sheets structure before parsing (must have Action and Time columns)
- Parse time format as MM:SS with validation for reasonable durations (1 second to 99:59)
- Sanitise exercise names for TTS pronunciation
- Validate workout routines have at least one exercise
- Implement proper input validation for all user settings

## Database Patterns
- Use Entity Framework Code First with migrations
- Implement repository pattern for data access abstraction
- Use async methods for all database operations
- Configure SQLite with proper indexing for performance
- Implement proper disposal patterns for database contexts

## Android-Specific Requirements
- Target Android API 21 (5.0) minimum, API 34 (14) target
- Request necessary permissions in AndroidManifest.xml
- Handle Android lifecycle events properly (OnResume, OnPause)
- Use Android.Content.Context appropriately for platform services
- Implement proper back button handling for navigation

## Testing Requirements
- Write unit tests for all timer logic and calculations
- Test Google API integration with mock services for unit tests
- Manually test audio functionality on physical devices
- Verify timer accuracy over extended periods
- Test offline functionality after caching workout data

## Security Standards
- Store OAuth tokens securely using Android Keystore
- Use HTTPS for all Google API communications
- Validate all input data before processing
- Never log sensitive information (tokens, personal data)
- Implement certificate pinning for API communications

## Performance Guidelines
- Use lazy loading for ViewModels and services
- Implement proper image and resource disposal
- Use data virtualisation for large workout lists
- Optimise XAML binding performance with x:Bind where possible
- Profile memory usage during long workout sessions

## UI/UX Standards
- Design for single-handed operation during workouts
- Use large, easily readable text (minimum 16sp) for timer displays
- Implement high contrast colours for workout timer
- Ensure touch targets are minimum 44dp for finger navigation
- Support both portrait and landscape orientations

## Localisation Approach
- Use .resx files for all user-facing strings
- Implement proper pluralisation for time announcements
- Support British English spellings in user interface
- Ensure TTS pronunciations work well for exercise names
- Test time format display in different locales

## Review Process
Before submitting any code:
1. Ensure all async operations use ConfigureAwait(false) in library code
2. Verify timer accuracy meets ±500ms requirement
3. Test Google API integration with real account
4. Validate audio functionality on physical device
5. Check memory usage and dispose patterns
6. Ensure offline mode works after initial data load

## Do NOT
- Use Thread.Sleep or blocking calls in async methods
- Store sensitive data in plain text or SharedPreferences
- Make synchronous calls to Google APIs
- Ignore Android lifecycle events
- Hard-code strings that should be localised
- Use Device.StartTimer for precision timing requirements

## Environment Setup Requirements
- Visual Studio 2022 17.8+ with .NET MAUI workload
- Android SDK API levels 21-34 installed
- Physical Android device or emulator for testing
- Google Cloud Console project with Drive and Sheets APIs enabled
- Valid OAuth 2.0 client credentials for Android

## Deployment Configuration
```xml
<!-- Target Android configuration -->
<TargetFrameworks>net8.0-android</TargetFrameworks>
<SupportedOSPlatformVersion Condition="$([MSBuild]::GetTargetPlatformIdentifier('$(TargetFramework)')) == 'android'">21.0</SupportedOSPlatformVersion>

<!-- Release build optimisations -->
<PropertyGroup Condition="'$(Configuration)' == 'Release'">
    <AndroidSigningKeyStore>workout-timer.keystore</AndroidSigningKeyStore>
    <AndroidSigningKeyAlias>workout-timer-key</AndroidSigningKeyAlias>
    <RunAOTCompilation>true</RunAOTCompilation>
</PropertyGroup>
```

## Debugging Guidelines
- Use conditional compilation for debug logging
- Implement comprehensive logging for timer events
- Log Google API request/response for troubleshooting
- Use Android Debug Bridge (adb) for device debugging
- Profile memory usage during long workout sessions