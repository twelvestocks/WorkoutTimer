# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview
**Workout Timer App** - A .NET MAUI Android application that integrates with Google Sheets to provide structured workout timing with audio cues. Users select workout routines from Google Drive, then receive guided workout sessions with precise timing and audio feedback.

## Essential Commands

**Development Commands:**
```bash
# From Windows (since .NET MAUI requires Windows environment)
dotnet build                                    # Build solution
dotnet run --framework net8.0-android          # Run on Android emulator/device
dotnet test                                     # Run unit tests
dotnet workload install maui                   # Install MAUI workload (setup)

# Android deployment
dotnet build -f net8.0-android -c Release     # Release build
dotnet publish -f net8.0-android -c Release  # Create APK for sideloading

# Package management
dotnet add package [PackageName]               # Add NuGet package
dotnet restore                                 # Restore packages
```

**Linux/WSL Commands:**
Since this is a .NET project accessed from Linux/WSL, use the MCP .NET tools:
```bash
# Use mcp__code-tools__dotnet_check_compilation to verify builds
# Use mcp__code-tools__dotnet_analyze_project to examine project structure
# Pass Windows paths like: D:\source\repos\WorkoutTimer\WorkoutTimerApp\WorkoutTimerApp.csproj
```

## Project Status & Workflow
**Current Phase:** Project Setup & Foundation (0% complete)

**Mandatory Workflow:**
1. **ALWAYS** read `workout_timer_planning.md` at conversation start for technical context
2. **ALWAYS** check `workout_timer_tasks.md` before beginning work to see current phase
3. **ALWAYS** update task status immediately when completing work
4. Follow the phase-based development approach defined in TASKS.md

## Technology Stack
- **Framework:** .NET MAUI 8.0 targeting Android API 21-34
- **Language:** C# 12.0 with nullable reference types
- **UI:** XAML with MVVM data binding pattern
- **Database:** Entity Framework Core 8.0 with SQLite
- **APIs:** Google Drive v3, Google Sheets v4, Google Auth
- **Audio:** Android TextToSpeech and MediaPlayer
- **IDE:** Visual Studio 2022 (Windows required for MAUI development)

## Architecture Patterns

**MVVM Implementation:**
- All ViewModels inherit from `BaseViewModel` with `INotifyPropertyChanged`
- Use `RelayCommand` or `Command` for UI command bindings
- Services injected via dependency injection in `MauiProgram.cs`
- Strict separation: ViewModels handle UI logic, Services handle business logic

**Project Structure:**
```
WorkoutTimerApp/
├── Models/              # Data entities (Exercise, WorkoutRoutine, WorkoutSession)
├── ViewModels/          # MVVM view models with proper change notification
├── Views/              # XAML pages (MainPage, WorkoutPage, SettingsPage)
├── Services/           # Business logic (GoogleSheetsService, AudioService, TimerService)
├── Data/               # EF Core context and repositories
├── Platforms/Android/  # Android-specific implementations
├── Resources/          # Images, sounds, styles, localisation
└── Helpers/            # Utility classes and extensions
```

**Core Services Architecture:**
- `GoogleSheetsService`: Handles Google API integration with OAuth 2.0
- `WorkoutTimerService`: Manages precise timing with System.Timers.Timer
- `AudioService`: Implements TextToSpeech and sound effects via `IAudioService` interface
- `DatabaseService`: EF Core repository pattern for local data persistence

## Critical Implementation Requirements

**Timer Accuracy:**
- Use `System.Timers.Timer` for precision timing (NOT `Device.StartTimer`)
- Implement timer drift compensation for long sessions
- Maintain accuracy within ±500ms for 60+ minute workouts
- Always marshal UI updates to main thread from timer callbacks

**Google API Integration:**
- Use async/await for ALL Google API calls
- Implement exponential backoff retry for rate limiting
- Cache API responses locally using Entity Framework
- Read-only scopes only: `drive.readonly` and `spreadsheets.readonly`
- Store OAuth tokens securely using Android Keystore

**Audio System:**
- Android `TextToSpeech` for exercise name announcements  
- `MediaPlayer` for interval transition sounds
- Check audio availability before playing
- Thread-safe audio service with proper disposal patterns

**Data Validation:**
- Validate Google Sheets have Action and Time columns
- Parse time format as MM:SS with range validation (1 second to 99:59)
- Sanitise exercise names for TTS pronunciation
- Implement comprehensive input validation

## Code Style Standards
- C# 12.0 features: file-scoped namespaces, nullable reference types
- Microsoft C# conventions: PascalCase for public members
- Async/await for ALL I/O operations (APIs, database, files)
- XML documentation comments for public classes/methods
- Use `ConfigureAwait(false)` in library code
- British English in user-facing text, standard syntax in code

## Testing Requirements
- Unit tests for timer logic, data parsing, and calculations
- Mock Google API services for unit tests
- Manual testing on physical Android devices for audio/timing
- Verify offline functionality after initial data caching
- Test across different Android versions (API 21-34)

## Security & Performance
- Android Keystore for OAuth token storage
- HTTPS for all API communication with certificate pinning
- No logging of sensitive data (tokens, personal information)
- Lazy loading for ViewModels and services
- Proper disposal patterns for database contexts and audio resources
- Memory profiling during long workout sessions

## Development Environment Notes
**Windows Required:** .NET MAUI development requires Visual Studio 2022 on Windows
**From WSL/Linux:** Use MCP .NET tools to interact with the Windows codebase
**Google Setup:** Requires Google Cloud Console project with Drive/Sheets APIs enabled
**Android Testing:** Physical device or emulator required for audio testing

## Phase-Based Development
Development follows strict phases defined in `workout_timer_tasks.md`:
1. **Phase 1:** Environment Setup & Project Foundation 
2. **Phase 2:** Core Infrastructure (Auth, Data, Timer, Audio)
3. **Phase 3:** UI Development (MVVM, Navigation, Screens)
4. **Phase 4:** Feature Integration (Complete workflows)
5. **Phase 5:** Testing & QA
6. **Phase 6:** Deployment & Documentation

**Never skip phases** - each builds essential foundation for the next.

## Common Pitfalls to Avoid
- Using `Thread.Sleep` or blocking calls in async methods
- Storing sensitive data in `SharedPreferences` 
- Making synchronous Google API calls
- Ignoring Android lifecycle events (`OnResume`, `OnPause`)
- Hard-coding user-facing strings (use `.resx` files)
- Using `Device.StartTimer` for precision timing
- Direct UI updates from background threads

## File Integration
- **workout_timer_prd.md:** Business requirements and user stories
- **workout_timer_planning.md:** Complete technical architecture and design decisions  
- **workout_timer_tasks.md:** Phase-based task breakdown with dependencies
- This file provides implementation guidance for executing those tasks

Always maintain consistency across these four documentation files when making changes.