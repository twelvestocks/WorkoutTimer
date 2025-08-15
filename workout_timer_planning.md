# PLANNING.md - Workout Timer App

## Project Vision
**Project Name:** Workout Timer App
**Version:** 1.0
**Last Updated:** 15 August 2025
**Owner:** Automint Ltd - Director

**Technical Vision:**
A .NET MAUI Android application leveraging Google APIs for seamless workout routine management with precise timing and audio feedback. The architecture prioritises reliability, offline capability, and familiar Windows development patterns.

**Success Criteria:**
- Timer accuracy within 1 second over 60+ minute sessions
- Successful Google Sheets integration with offline caching
- Reliable audio feedback across Android device variations
- Smooth installation and operation via sideloading

## System Architecture

**Architecture Pattern:**
MVVM (Model-View-ViewModel) with dependency injection for clean separation of concerns

**High-Level Components:**
- **Presentation Layer:** XAML views with ViewModels for data binding and UI logic
- **Business Logic Layer:** Services for workout management, timing, and audio control
- **Data Access Layer:** Google API clients and local SQLite database
- **Platform Services:** Android-specific implementations for audio and authentication

**Data Flow:**
User authentication → Google Drive file selection → Sheet data retrieval → Local caching → Workout execution with real-time timer updates

## Technology Stack

**Frontend Technologies:**
- **Framework:** .NET MAUI 8.0
- **Language:** C# 12.0
- **UI Framework:** XAML with data binding
- **Styling:** MAUI styles and templates
- **Build Tool:** MSBuild with Visual Studio 2022

**Backend Technologies:**
- **Runtime:** .NET 8.0
- **API Integration:** Google.Apis NuGet packages
- **Authentication:** Google.Apis.Auth for OAuth 2.0
- **Data Access:** Entity Framework Core with SQLite
- **Audio:** Android MediaPlayer and TextToSpeech APIs

**Database & Storage:**
- **Primary Database:** SQLite 3.46
- **Caching:** Entity Framework Core In-Memory for session data
- **File Storage:** Local application data folder
- **Cloud Integration:** Google Drive and Sheets APIs

**Infrastructure & DevOps:**
- **Development:** Visual Studio 2022 Community/Professional
- **Version Control:** Git with local repository
- **Deployment:** Android APK sideloading
- **Testing:** MSTest with manual device testing

## Development Tools & Environment

**Required Tools:**
- **IDE:** Visual Studio 2022 (17.8 or later)
- **Android SDK:** API Level 21+ (Android 5.0+)
- **Emulator:** Android Emulator or physical device for testing
- **Package Manager:** NuGet Package Manager

**Development Environment:**
- **.NET Version:** 8.0 LTS
- **Target Framework:** net8.0-android
- **Minimum Android Version:** API 21 (Android 5.0)
- **Target Android Version:** API 34 (Android 14)

**Local Setup Requirements:**
```bash
# Verify .NET installation
dotnet --version

# Install MAUI workload
dotnet workload install maui

# Create project structure
dotnet new maui -n WorkoutTimerApp
```

**Required Visual Studio Workloads:**
- .NET Multi-platform App UI development
- Android development tools
- Android SDK and emulator

## Integration Requirements

**External APIs:**
- **Google Drive API v3:** File listing and access for spreadsheet selection
- **Google Sheets API v4:** Reading worksheet data and cell values
- **Google Sign-In:** OAuth 2.0 authentication flow

**Google API Configuration:**
- OAuth 2.0 client credentials for Android application
- Scopes: drive.readonly, spreadsheets.readonly
- API key restrictions for Android package name

**Platform Services:**
- **Android Text-to-Speech:** Built-in TTS engine for exercise announcements
- **Android MediaPlayer:** Audio playback for notification sounds
- **Android Vibration:** Haptic feedback for interval transitions

## Security & Compliance

**Security Requirements:**
- **Authentication:** Google OAuth 2.0 with secure credential storage
- **Authorisation:** Read-only access to user's Google Drive and Sheets
- **Data Protection:** Local SQLite database encryption for cached workout data
- **API Security:** Secure API key management and request signing

**Security Implementation:**
- Android Keystore for OAuth token storage
- Certificate pinning for Google API communications
- Input validation for all sheet data processing
- Secure local storage for user preferences

## Performance & Scalability

**Performance Requirements:**
- **UI Responsiveness:** 60fps during workout sessions
- **Timer Precision:** ±500ms accuracy for all intervals
- **API Response:** Sheet loading within 3 seconds
- **Memory Usage:** <100MB for typical workout sessions

**Performance Optimisation:**
- Async/await patterns for all API calls
- Efficient XAML binding with data virtualisation
- Background thread processing for sheet parsing
- Memory management for long workout sessions

## Testing Strategy

**Testing Approach:**
- **Unit Testing:** MSTest for business logic and calculations
- **Integration Testing:** Manual testing with real Google Sheets
- **UI Testing:** Manual testing on physical Android devices
- **Performance Testing:** Timer accuracy verification over extended periods

**Test Coverage Goals:**
- **Business Logic:** 90% code coverage for timing and calculation logic
- **Integration:** All Google API interaction scenarios tested
- **UI/UX:** Manual testing across different screen sizes and orientations

**Quality Gates:**
- All unit tests pass before deployment
- Manual verification of timer accuracy
- Successful installation via sideloading

## Deployment & Release

**Deployment Strategy:**
- **Development:** Local emulator and USB debugging
- **Testing:** Sideloading APK to physical devices
- **Release:** Signed APK for manual installation

**Build Configuration:**
- Debug builds for development with verbose logging
- Release builds with optimisation and minimal logging
- Code signing for production APK files

**APK Generation Process:**
```xml
<!-- In .csproj file -->
<PropertyGroup Condition="'$(Configuration)' == 'Release'">
    <AndroidSigningKeyStore>workout-timer.keystore</AndroidSigningKeyStore>
    <AndroidSigningKeyAlias>workout-timer-key</AndroidSigningKeyAlias>
</PropertyGroup>
```

## Data Architecture

**Core Entities:**
- **WorkoutSession:** Current workout state and progress
- **Exercise:** Individual exercise or rest period
- **WorkoutRoutine:** Complete routine loaded from Google Sheets
- **UserSettings:** Audio preferences and application configuration

**Data Flow:**
1. Google Sheets API retrieves raw worksheet data
2. Data parser converts to local Exercise entities
3. SQLite caches routine for offline access
4. ViewModel manages workout state during session

**Offline Strategy:**
- Cache complete workout routines locally after loading
- Store user preferences in local database
- Enable full workout functionality without internet after initial load

## MVVM Architecture Implementation

**View Models:**
- **MainViewModel:** Google account selection and sheet browsing
- **WorkoutSelectionViewModel:** Sheet preview and validation
- **WorkoutSessionViewModel:** Active workout timer and controls
- **SettingsViewModel:** Audio preferences and app configuration

**Services:**
- **GoogleSheetsService:** API integration and data retrieval
- **WorkoutTimerService:** Precise timing and interval management
- **AudioService:** Text-to-speech and sound effect management
- **DatabaseService:** Local data persistence and caching

**Models:**
- **WorkoutRoutine:** Business entity for complete workout
- **Exercise:** Individual timed interval with action and duration
- **UserPreferences:** Settings and configuration options

## Audio System Design

**Text-to-Speech Implementation:**
- Android TextToSpeech engine integration
- Configurable speech rate and pitch
- Exercise name announcement at interval start
- Time remaining announcements (optional)

**Audio Feedback Options:**
- Interval transition beeps (3-2-1 countdown)
- Exercise start confirmation tone
- Workout completion sound
- Warning pips before interval end

**Audio Service Interface:**
```csharp
public interface IAudioService
{
    Task AnnounceExercise(string exerciseName);
    Task PlayIntervalWarning(int secondsRemaining);
    Task PlayIntervalComplete();
    Task ConfigureTtsSettings(TtsSettings settings);
}
```

## Error Handling & Resilience

**Network Resilience:**
- Graceful degradation when API calls fail
- Retry logic with exponential backoff
- Clear user messaging for connectivity issues
- Offline mode activation when network unavailable

**Timer Reliability:**
- System timer with drift compensation
- Background service for uninterrupted timing
- State preservation during app lifecycle events
- Recovery from interruptions (calls, notifications)

**Error Recovery:**
- Comprehensive exception handling with user-friendly messages
- Automatic retry for transient failures
- Fallback options for critical functionality
- Logging for debugging timing issues

## Development Workflow

**Project Structure:**
```
WorkoutTimerApp/
├── Models/              # Data entities
├── ViewModels/          # MVVM view models
├── Views/              # XAML pages and controls
├── Services/           # Business logic services
├── Data/               # Database context and repositories
├── Platforms/Android/  # Android-specific implementations
└── Resources/          # Images, sounds, styles
```

**Coding Standards:**
- C# naming conventions and async/await patterns
- XAML binding best practices
- Dependency injection for all services
- Comprehensive XML documentation for public APIs

## Assumptions & Constraints

**Technical Assumptions:**
- Users have Android 5.0 or later devices
- Reliable internet connection available for initial sheet loading
- Google account authentication will remain stable
- Text-to-speech engine available on target devices

**Development Constraints:**
- Single developer with primary Windows/C# experience
- No access to Google Play Store for distribution
- Limited to sideloading deployment method
- Must work across variety of Android screen sizes

**Google API Constraints:**
- Rate limits: 100 requests per 100 seconds per user
- Quota limits: 50,000 requests per day
- OAuth scope limitations to read-only access
- API deprecation cycles requiring future updates

## Risks & Mitigation

**Technical Risks:**
- **Timer drift during long sessions:** Implement system timer with periodic calibration
- **Google API rate limiting:** Cache data locally and implement request throttling
- **Audio system compatibility:** Test across multiple Android versions and manufacturers
- **Memory management:** Profile memory usage and implement proper disposal patterns

**Development Risks:**
- **Learning curve for MAUI:** Start with simple prototypes before full implementation
- **Android deployment complexity:** Test sideloading process early and document steps
- **Google API integration:** Begin with simple API calls before complex sheet parsing

## Future Considerations

**Architecture Evolution:**
- Service-oriented design allows for future cloud backend integration
- MVVM pattern supports addition of new views and features
- Modular audio system enables advanced audio feature expansion

**Platform Expansion:**
- .NET MAUI codebase ready for iOS deployment
- Shared business logic minimises duplicate code
- Platform-specific services abstracted for multi-platform support

**Feature Roadmap:**
- Workout creation and editing within app
- Synchronisation across multiple devices
- Advanced audio features (music integration, custom sounds)
- Fitness tracker integration via platform APIs