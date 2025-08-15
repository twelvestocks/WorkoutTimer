# TASKS.md - Workout Timer App

## Project Status Overview
**Project:** Workout Timer App
**Current Phase:** Project Setup & Foundation
**Last Updated:** 15 August 2025
**Overall Progress:** 6/89 tasks completed (7%)

## Active Sprint/Focus
**Current Focus:** Development Environment Setup and Project Foundation
**Sprint Goal:** Establish working development environment with basic MAUI project structure
**Estimated Completion:** 1-2 weeks for foundation phase

---

## Phase 1: Project Setup & Foundation
*Target: Get development environment ready and basic MAUI project structure in place*

### Environment Setup
- [✅] **ENV-001: Visual Studio 2022 Setup**
  - Install Visual Studio 2022 with .NET MAUI workload
  - Install Android SDK and emulator tools
  - Verify .NET 8.0 installation and MAUI workload
  - **Acceptance:** Visual Studio can create and build MAUI Android projects

- [ ] **ENV-002: Android Development Environment**
  - Configure Android SDK with API levels 21-34
  - Set up Android Emulator with test device
  - Test USB debugging with physical Android device
  - **Acceptance:** Can deploy and debug MAUI app on emulator and physical device

- [ ] **ENV-003: Google API Setup**
  - Create Google Cloud Console project
  - Enable Google Drive and Sheets APIs
  - Generate OAuth 2.0 credentials for Android app
  - **Acceptance:** API credentials configured and ready for integration

- [✅] **ENV-004: Git Repository Initialisation**
  - Initialise local Git repository
  - Create .gitignore for .NET MAUI projects
  - Set up initial commit structure
  - **Acceptance:** Version control working with proper ignore patterns

### Project Structure Creation
- [✅] **STRUCT-001: MAUI Project Creation**
  - Create new .NET MAUI project with appropriate naming
  - Configure target frameworks for Android
  - Set minimum and target Android API levels
  - **Acceptance:** Project builds successfully and deploys to Android

- [✅] **STRUCT-002: Solution Architecture Setup**
  - Create folder structure following MVVM pattern
  - Add necessary project folders (Models, ViewModels, Views, Services)
  - Configure dependency injection container
  - **Acceptance:** Clean project structure ready for feature development

- [✅] **STRUCT-003: NuGet Package Dependencies**
  - Install Google.Apis.Drive.v3
  - Install Google.Apis.Sheets.v4
  - Install Google.Apis.Auth
  - Install Microsoft.EntityFrameworkCore.Sqlite
  - **Acceptance:** All packages installed and compatible

### Documentation Framework
- [ ] **DOC-001: Complete PRD**
  - Finalise all business requirements and user stories
  - Validate acceptance criteria for all features
  - **Acceptance:** PRD approved and comprehensive

- [ ] **DOC-002: Update PLANNING.md**
  - Complete technical architecture documentation
  - Finalise technology stack decisions
  - **Acceptance:** PLANNING.md contains all necessary technical guidance

- [✅] **DOC-003: Create CLAUDE.md**
  - Document coding standards for .NET MAUI development
  - Include essential commands and workflow
  - Add project-specific conventions
  - **Acceptance:** CLAUDE.md provides clear development context

---

## Phase 2: Core Infrastructure Development
*Target: Build foundational services and data access layer*

### Authentication & Google Integration
- [ ] **AUTH-001: Google Authentication Service**
  - Implement GoogleAuthService for OAuth 2.0 flow
  - Add secure token storage using Android Keystore
  - Handle authentication state management
  - **Acceptance:** Users can authenticate with Google accounts

- [ ] **AUTH-002: Google Drive API Integration**
  - Create GoogleDriveService for file listing
  - Implement spreadsheet file filtering
  - Add error handling for API failures
  - **Acceptance:** Can list and filter Google Sheets from user's Drive

- [ ] **AUTH-003: Google Sheets API Integration**
  - Create GoogleSheetsService for reading sheet data
  - Implement cell range reading for Action/Time columns
  - Add sheet validation logic
  - **Acceptance:** Can read and parse workout data from Google Sheets

### Data Models & Services
- [ ] **DATA-001: Core Data Models**
  - Create Exercise entity with action and duration properties
  - Create WorkoutRoutine entity for complete routines
  - Create WorkoutSession entity for tracking active workouts
  - **Acceptance:** All data models properly defined with validation

- [ ] **DATA-002: Database Context Setup**
  - Configure Entity Framework Core with SQLite
  - Create database context for local storage
  - Implement repository pattern for data access
  - **Acceptance:** Local database can store and retrieve workout data

- [ ] **DATA-003: Data Parsing Service**
  - Implement SheetDataParser for converting API responses
  - Add time format parsing (MM:SS to TimeSpan)
  - Include data validation and error handling
  - **Acceptance:** Can parse Google Sheets data into local entities

### Timer & Audio Foundation
- [ ] **TIMER-001: Workout Timer Service**
  - Create WorkoutTimerService with precise timing
  - Implement start, pause, resume, stop functionality
  - Add timer event notifications for UI updates
  - **Acceptance:** Timer maintains accuracy over long periods

- [ ] **AUDIO-001: Audio Service Foundation**
  - Create IAudioService interface
  - Implement basic Android TextToSpeech integration
  - Add simple sound effect playback capability
  - **Acceptance:** Can play TTS announcements and basic sounds

- [ ] **AUDIO-002: Audio Configuration**
  - Add user preference storage for audio settings
  - Implement TTS configuration (rate, pitch, volume)
  - Create audio feedback timing system
  - **Acceptance:** Audio preferences persist and apply correctly

---

## Phase 3: User Interface Development
*Target: Build main application screens and navigation*

### Core UI Framework
- [ ] **UI-001: MVVM Infrastructure**
  - Create BaseViewModel with INotifyPropertyChanged
  - Implement RelayCommand for button bindings
  - Set up dependency injection for ViewModels
  - **Acceptance:** MVVM pattern working with data binding

- [ ] **UI-002: Navigation Service**
  - Implement navigation service for page transitions
  - Create navigation methods between main screens
  - Add back button handling and navigation stack management
  - **Acceptance:** Smooth navigation between all app screens

- [ ] **UI-003: Common UI Components**
  - Create reusable button styles and templates
  - Design consistent colour scheme and typography
  - Implement loading indicators and progress bars
  - **Acceptance:** Consistent visual design across all screens

### Authentication & Setup Screens
- [ ] **SCREEN-001: Splash Screen**
  - Create app startup screen with branding
  - Add initialisation logic for services
  - Implement automatic navigation to main screen
  - **Acceptance:** Professional startup experience

- [ ] **SCREEN-002: Google Account Selection**
  - Create account selection interface
  - Implement Google Sign-In button and flow
  - Add account switching capability
  - **Acceptance:** Users can authenticate with their Google accounts

- [ ] **SCREEN-003: Google Sheets Browser**
  - Create sheet listing interface with search
  - Implement sheet selection with preview
  - Add refresh capability and error handling
  - **Acceptance:** Users can browse and select workout sheets

### Workout Screens
- [ ] **SCREEN-004: Workout Preview Screen**
  - Display selected workout routine overview
  - Show exercise list with durations
  - Calculate and display total workout time
  - Add start workout button
  - **Acceptance:** Users can review routine before starting

- [ ] **SCREEN-005: Main Workout Screen**
  - Create timer display with large, readable text
  - Show current exercise name and remaining time
  - Display overall workout progress
  - Add workout control buttons (pause, resume, stop)
  - **Acceptance:** Clear, functional workout interface

- [ ] **SCREEN-006: Settings Screen**
  - Create audio preference controls
  - Add TTS configuration options
  - Include app information and version details
  - **Acceptance:** Users can configure audio and app preferences

### UI Polish & Responsiveness
- [ ] **UI-004: Responsive Design**
  - Ensure layout works on phones and tablets
  - Test different screen orientations
  - Optimise for various Android screen densities
  - **Acceptance:** App looks good on different device sizes

- [ ] **UI-005: Accessibility Features**
  - Add content descriptions for screen readers
  - Ensure sufficient colour contrast
  - Implement keyboard navigation support
  - **Acceptance:** Basic accessibility requirements met

---

## Phase 4: Feature Implementation & Integration
*Target: Connect UI to services and implement complete workflows*

### Google Sheets Integration
- [ ] **FEAT-001: Sheet Selection Workflow**
  - Connect Google Drive browsing to UI
  - Implement sheet filtering and search
  - Add sheet validation feedback
  - **Acceptance:** Complete sheet selection experience

- [ ] **FEAT-002: Workout Data Loading**
  - Integrate Google Sheets API with workout preview
  - Implement data caching for offline use
  - Add loading states and error handling
  - **Acceptance:** Workout data loads reliably with offline support

- [ ] **FEAT-003: Data Validation & Error Handling**
  - Validate Action/Time column format
  - Provide clear error messages for invalid sheets
  - Implement recovery options for data issues
  - **Acceptance:** Users receive helpful feedback for sheet problems

### Workout Execution
- [ ] **FEAT-004: Workout Session Management**
  - Connect timer service to workout UI
  - Implement exercise progression logic
  - Add workout state persistence
  - **Acceptance:** Workouts execute smoothly with proper state management

- [ ] **FEAT-005: Workout Controls Implementation**
  - Connect pause/resume buttons to timer service
  - Implement stop workout with confirmation
  - Add workout completion detection
  - **Acceptance:** All workout controls function correctly

- [ ] **FEAT-006: Progress Tracking**
  - Display current exercise position in routine
  - Show elapsed time and remaining time
  - Calculate and display overall progress percentage
  - **Acceptance:** Users always know their workout progress

### Audio Integration
- [ ] **FEAT-007: Exercise Announcements**
  - Integrate TTS with workout progression
  - Announce exercise names at interval start
  - Add configurable announcement timing
  - **Acceptance:** Clear audio announcements for each exercise

- [ ] **FEAT-008: Timer Audio Cues**
  - Implement warning beeps before interval end
  - Add interval completion sounds
  - Create configurable countdown audio (3-2-1)
  - **Acceptance:** Audio cues help users stay focused on exercise

- [ ] **FEAT-009: Audio Preference Integration**
  - Connect settings screen to audio service
  - Implement real-time audio preference testing
  - Add audio preview functionality in settings
  - **Acceptance:** Audio preferences work immediately when changed

### Optional Features
- [ ] **OPT-001: Skip Exercise Functionality**
  - Add skip button to workout screen
  - Implement skip confirmation dialog
  - Ensure skipping doesn't affect timer accuracy
  - **Acceptance:** Users can skip exercises without breaking workout flow

---

## Phase 5: Testing & Quality Assurance
*Target: Ensure app reliability and quality across different scenarios*

### Unit Testing
- [ ] **TEST-001: Timer Logic Testing**
  - Write unit tests for WorkoutTimerService
  - Test timer accuracy over various durations
  - Verify pause/resume timing precision
  - **Acceptance:** Timer logic passes all accuracy tests

- [ ] **TEST-002: Data Parsing Testing**
  - Test Google Sheets data parsing with various formats
  - Verify time format conversion accuracy
  - Test error handling for invalid data
  - **Acceptance:** Data parsing handles all expected scenarios

- [ ] **TEST-003: Audio Service Testing**
  - Test TTS functionality across different text inputs
  - Verify audio timing coordination with timer
  - Test audio preference application
  - **Acceptance:** Audio system works reliably in all configurations

### Integration Testing
- [ ] **TEST-004: Google API Integration Testing**
  - Test authentication flow with real Google accounts
  - Verify sheet listing and reading functionality
  - Test error handling for API failures
  - **Acceptance:** Google integration works reliably

- [ ] **TEST-005: End-to-End Workflow Testing**
  - Test complete workflow from sheet selection to workout completion
  - Verify data persistence across app lifecycle
  - Test offline functionality after initial load
  - **Acceptance:** Complete user workflows function properly

- [ ] **TEST-006: Device Compatibility Testing**
  - Test on different Android versions and devices
  - Verify performance on older/slower devices
  - Test various screen sizes and orientations
  - **Acceptance:** App works well across target device range

### Performance & Reliability Testing
- [ ] **TEST-007: Long Session Testing**
  - Test timer accuracy during 60+ minute workouts
  - Verify memory usage remains stable
  - Test app behavior during interruptions (calls, notifications)
  - **Acceptance:** App remains stable during extended use

- [ ] **TEST-008: Network Reliability Testing**
  - Test app behavior with poor/intermittent connectivity
  - Verify offline mode activation and functionality
  - Test recovery from network failures
  - **Acceptance:** App gracefully handles network issues

- [ ] **TEST-009: Audio System Reliability**
  - Test TTS across different Android TTS engines
  - Verify audio output with various headphone/speaker configurations
  - Test audio interruption handling (calls, notifications)
  - **Acceptance:** Audio system works consistently across configurations

---

## Phase 6: Deployment & Documentation
*Target: Prepare app for distribution and create supporting documentation*

### APK Preparation
- [ ] **DEPLOY-001: Release Build Configuration**
  - Configure release build settings for optimal performance
  - Set up code signing with keystore
  - Optimize APK size and remove debugging symbols
  - **Acceptance:** Release APK builds successfully with proper signing

- [ ] **DEPLOY-002: Sideloading Documentation**
  - Create step-by-step installation guide
  - Document Android security settings required
  - Include troubleshooting guide for common issues
  - **Acceptance:** Clear instructions for app installation

- [ ] **DEPLOY-003: APK Testing & Validation**
  - Test final APK on clean Android devices
  - Verify all functionality works in release mode
  - Test installation process on different Android versions
  - **Acceptance:** Release APK installs and functions correctly

### User Documentation
- [ ] **DOC-004: User Guide Creation**
  - Create comprehensive user manual with screenshots
  - Document Google Sheets format requirements
  - Include troubleshooting section for common issues
  - **Acceptance:** Users can successfully use app with documentation

- [ ] **DOC-005: Google Sheets Template**
  - Create sample workout sheet with proper formatting
  - Include various exercise types and durations
  - Document best practices for sheet creation
  - **Acceptance:** Users have working template to start with

- [ ] **DOC-006: Technical Documentation**
  - Complete developer documentation for future maintenance
  - Document API integration and key services
  - Include architecture diagrams and code explanations
  - **Acceptance:** Future developers can understand and modify the app

### Final Quality Assurance
- [ ] **QA-001: Final User Acceptance Testing**
  - Conduct complete workflow testing with real users
  - Gather feedback on usability and functionality
  - Verify all acceptance criteria are met
  - **Acceptance:** App meets all original requirements

- [ ] **QA-002: Performance Verification**
  - Measure and verify timer accuracy meets specifications
  - Test memory usage and battery consumption
  - Verify app startup and response times
  - **Acceptance:** App meets all performance requirements

- [ ] **QA-003: Security & Privacy Review**
  - Verify secure storage of authentication tokens
  - Test API communication security
  - Review app permissions and data handling
  - **Acceptance:** App follows security best practices

---

## Task Status Legend
- [ ] **Not Started** - Task has not been begun
- [🔄] **In Progress** - Task is currently being worked on
- [⏸️] **Blocked** - Task cannot proceed due to dependencies
- [✅] **Completed** - Task has been finished and verified
- [❌] **Cancelled** - Task is no longer needed
- [🔍] **Under Review** - Task is completed but awaiting review

## Task Metadata Guidelines

### Task Naming Convention
**[CATEGORY-NUMBER]: Brief Description**
- **ENV**: Environment setup and tools
- **STRUCT**: Project structure and architecture
- **DOC**: Documentation tasks
- **AUTH**: Authentication and Google integration
- **DATA**: Data models and database work
- **TIMER**: Timer functionality
- **AUDIO**: Audio system implementation
- **UI**: User interface framework
- **SCREEN**: Individual screen development
- **FEAT**: Feature implementation and integration
- **OPT**: Optional/nice-to-have features
- **TEST**: Testing and quality assurance
- **DEPLOY**: Deployment and distribution
- **QA**: Final quality assurance

### Progress Updates
When updating tasks:
- Mark completion date when finished
- Add notes about any issues encountered
- Update related tasks if dependencies change
- Add newly discovered subtasks
- Note any changes to original scope

---

## Integration with Documentation Framework

**TASKS.md works with:**
- **PRD:** Tasks implement the business requirements and user stories defined in the PRD
- **PLANNING.md:** Tasks follow the technical architecture and technology choices outlined in PLANNING.md
- **CLAUDE.md:** Tasks are executed following the coding standards and conventions specified in CLAUDE.md

**Workflow Integration:**
1. **PRD** defines what needs to be built (workout timer with Google Sheets integration)
2. **PLANNING.md** defines how it will be built technically (.NET MAUI with Google APIs)
3. **TASKS.md** breaks down the work into actionable development items
4. **CLAUDE.md** provides the context for how to execute each task consistently