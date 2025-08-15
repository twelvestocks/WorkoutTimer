# Workout Timer App

A .NET MAUI Android application that integrates with Google Sheets to provide structured workout timing with audio cues.

## Overview

The Workout Timer App allows users to create flexible workout routines in Google Sheets and execute them with precise timing, clear visual feedback, and optional audio announcements. Perfect for fitness enthusiasts who want customisable workout routines with professional timing capabilities.

## Features (Planned)

- 🔗 **Google Sheets Integration** - Load workout routines directly from Google Sheets
- ⏱️ **Precise Timing** - Accurate interval timing with drift compensation
- 🔊 **Audio Feedback** - Text-to-speech announcements and audio cues
- 📱 **Android Native** - Built with .NET MAUI for smooth Android experience
- 💾 **Offline Support** - Works offline after initial workout data load
- ⏸️ **Workout Controls** - Pause, resume, skip, and stop functionality

## Technology Stack

- **.NET MAUI 8.0** - Cross-platform UI framework
- **C# 12.0** - Modern language features with nullable reference types
- **XAML + MVVM** - Clean separation with data binding
- **Entity Framework Core** - Local SQLite database for caching
- **Google APIs** - Drive v3 and Sheets v4 integration
- **Android Platform** - Targeting API 21+ (Android 5.0+)

## Project Structure

```
WorkoutTimerApp/
├── Models/              # Data entities (Exercise, WorkoutRoutine)
├── ViewModels/          # MVVM view models with INotifyPropertyChanged
├── Views/              # XAML pages and user controls
├── Services/           # Business logic and API integration
├── Data/               # Entity Framework context and repositories
├── Platforms/Android/  # Android-specific implementations
├── Resources/          # Images, sounds, styles, localisation
└── Helpers/            # Utility classes and extensions
```

## Development Status

**Current Phase:** Project Setup & Foundation (Phase 1 of 6)

This project follows a structured development approach:
1. ✅ **Project Setup & Foundation** - Basic MAUI structure and architecture
2. ⏳ **Core Infrastructure** - Google API integration, database, services
3. ⏳ **User Interface Development** - MVVM screens and navigation
4. ⏳ **Feature Implementation** - Complete workflow integration
5. ⏳ **Testing & Quality Assurance** - Comprehensive testing
6. ⏳ **Deployment & Documentation** - APK creation and user guides

## Getting Started

### Prerequisites

- Visual Studio 2022 17.8+ with .NET MAUI workload
- Android SDK API levels 21-34
- Physical Android device or emulator for testing
- Google Cloud Console project with Drive and Sheets APIs enabled

### Setup Instructions

1. **Clone the repository**
   ```bash
   git clone https://github.com/twelvestocks/WorkoutTimer.git
   cd WorkoutTimer
   ```

2. **Install .NET MAUI workload** (if not already installed)
   ```bash
   dotnet workload install maui
   ```

3. **Restore packages**
   ```bash
   dotnet restore WorkoutTimerApp
   ```

4. **Build the project**
   ```bash
   dotnet build WorkoutTimerApp
   ```

5. **Configure Google APIs**
   - Create a Google Cloud Console project
   - Enable Google Drive and Sheets APIs
   - Generate OAuth 2.0 credentials for Android
   - Add credentials to the project (details in setup documentation)

## Google Sheets Format

Create workout sheets with this simple format:

| Action | Time |
|--------|------|
| Push-ups | 00:45 |
| Rest | 00:15 |
| Squats | 01:00 |
| Rest | 00:15 |

- **Action**: Exercise name or rest period
- **Time**: Duration in MM:SS format

## Contributing

This is a personal project with a specific development workflow:

1. **Always work in feature branches** - Never commit directly to `main`
2. **Follow the phase-based development** - Respect the structured approach
3. **Update documentation** - Keep CLAUDE.md, planning docs, and tasks updated
4. **Use pull requests** - All changes go through PR workflow

## Documentation

- **[CLAUDE.md](CLAUDE.md)** - Development guidance for Claude Code
- **[Planning](workout_timer_planning.md)** - Complete technical architecture
- **[Tasks](workout_timer_tasks.md)** - Phase-based development breakdown
- **[PRD](workout_timer_prd.md)** - Product requirements and specifications

## License

This project is developed for personal use. See the repository for any licensing details.

## Contact

This is a personal project by Automint Ltd. For questions or suggestions, please open an issue in the GitHub repository.

---

**Development Note:** This project is built using .NET MAUI and requires Windows development environment. The project structure and documentation are optimised for development with Claude Code assistance.