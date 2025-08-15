# Product Requirements Document: Workout Timer App

## 1. Project Overview
**Project Name:** Workout Timer App
**Date:** 15 August 2025
**Version:** 1.0
**Owner:** Automint Ltd - Director

**Executive Summary:**
A mobile Android application that integrates with Google Sheets to provide structured workout timing with audio cues. The app allows users to select workout routines from their Google Drive, then guides them through timed exercise intervals with clear visual feedback and optional audio announcements.

**Problem Statement:**
Currently, there's no simple way to create flexible workout routines in Google Sheets and have them automatically guide a workout session with proper timing, audio cues, and progress tracking. Existing workout apps don't offer the flexibility of spreadsheet-based routine creation that can be easily modified and shared.

**Success Metrics:**
- Users can successfully connect to Google Sheets and load workout routines
- Timer accuracy within 1 second for all intervals
- Audio cues function reliably across different Android devices
- App remains stable during entire workout sessions (no crashes)
- Successful sideloading and installation on target devices

## 2. User Requirements

**Target Users:**
- **Primary**: Fitness enthusiasts who prefer customisable workout routines
- **Secondary**: Personal trainers who create routines for clients via Google Sheets

**User Stories:**
- As a fitness enthusiast, I want to create workout routines in Google Sheets so that I can easily modify and organise my exercises
- As a user, I want to select a workout sheet from my Google Drive so that I can start my routine quickly
- As a user, I want clear visual and audio feedback during workouts so that I stay focused on exercising rather than watching the clock
- As a user, I want to pause and resume workouts so that I can handle interruptions without losing my place
- As a user, I want the app to work offline after loading so that poor connectivity doesn't interrupt my workout
- As a trainer, I want to share workout sheets with clients so that they can follow structured routines

**User Journey:**
1. User opens app and authenticates with Google account (if needed)
2. User browses and selects a workout sheet from Google Drive
3. User reviews the workout structure and taps "Start"
4. App guides user through each exercise/rest interval with timers and audio cues
5. User can pause, resume, or end workout as needed
6. App provides completion summary when workout finishes

## 3. Functional Requirements

**Core Features:**
1. **Google Account Integration**
   - Description: Authenticate with existing Google accounts on device
   - Acceptance Criteria: User can select from available Google accounts and authenticate seamlessly
   - Priority: High

2. **Google Sheets Selection**
   - Description: Browse and select workout sheets from Google Drive
   - Acceptance Criteria: User can see list of spreadsheets, filter/search if needed, and select target sheet
   - Priority: High

3. **Workout Sheet Validation**
   - Description: Verify selected sheet has proper Action/Time column structure
   - Acceptance Criteria: App validates sheet format and shows clear error messages for invalid sheets
   - Priority: High

4. **Workout Preview**
   - Description: Display workout overview before starting
   - Acceptance Criteria: User can see all exercises, durations, and total workout time before beginning
   - Priority: Medium

5. **Main Timer Display**
   - Description: Clear visual display of current exercise, interval timer, and total workout progress
   - Acceptance Criteria: Large, readable text showing current action, time remaining, and overall progress
   - Priority: High

6. **Workout Controls**
   - Description: Start, pause, resume, and end workout functionality
   - Acceptance Criteria: All controls work reliably without timing issues or state confusion
   - Priority: High

7. **Audio Feedback System**
   - Description: Configurable audio cues including text-to-speech and warning pips
   - Acceptance Criteria: User can choose voice announcements, warning beeps, or both; audio works consistently
   - Priority: High

8. **Skip Functionality (Nice-to-have)**
   - Description: Ability to skip current interval and move to next
   - Acceptance Criteria: Skip button advances to next exercise without affecting overall timing accuracy
   - Priority: Low

**API Requirements:**
- Google Drive API v3: List and access spreadsheet files
- Google Sheets API v4: Read worksheet data and structure
- Android Authentication: Google Sign-In integration
- Data formats: JSON for API responses, local SQLite for offline caching

**Data Requirements:**
- Input data: Google Sheets with Action (text) and Time (MM:SS format) columns
- Output data: Workout progress, timing logs, user preferences
- Storage requirements: Local SQLite database for offline workout data and user settings

## 4. Technical Requirements

**Technology Stack:**
- Frontend: .NET MAUI (C# with XAML)
- Backend: Google APIs for data access
- Database: SQLite for local storage
- Infrastructure: Android deployment via sideloading

**Performance Requirements:**
- Response time: Sheet loading within 3 seconds on good connection
- Throughput: Support workout routines up to 100 exercises
- Availability: Offline functionality after initial sheet load
- Scalability: Single-user application, no concurrent user concerns

**Security Requirements:**
- Authentication: Google OAuth 2.0 with secure token storage
- Authorisation: Read-only access to user's Google Drive and Sheets
- Data protection: No sensitive data storage beyond cached workout routines
- Security standards: Follow Google API security best practices

**Integration Requirements:**
- External APIs: Google Drive API v3, Google Sheets API v4, Google Sign-In
- Third-party tools: None beyond Google services
- Legacy systems: None

## 5. Non-Functional Requirements

**Usability:**
- Intuitive interface suitable for use during physical exercise
- Large, easy-to-read text and buttons for workout display
- Single-handed operation where possible
- Clear visual hierarchy and minimal cognitive load during workouts

**Reliability:**
- Graceful handling of network connectivity issues
- Robust timer functionality that doesn't drift or skip
- Proper state management for pause/resume functionality
- Error recovery for API failures

**Maintainability:**
- Clean MVVM architecture for separation of concerns
- Comprehensive logging for debugging workout timing issues
- Unit tests for timer logic and data processing
- Clear documentation for future maintenance

## 6. Constraints & Assumptions

**Technical Constraints:**
- Android-only deployment initially
- Requires Google account for sheet access
- Dependent on Google APIs for core functionality
- Must work on variety of Android screen sizes

**Business Constraints:**
- Budget: Development time rather than monetary cost
- Timeline: Personal project with flexible completion date
- Resource availability: Single developer with Windows/C# background

**Assumptions:**
- Users have existing Google accounts and basic familiarity with Google Sheets
- Workout routines will follow consistent Action/Time column format
- Users have reliable internet connection for initial sheet loading
- Android devices have functional audio output capabilities

## 7. Implementation Guidance for AI Agents

**Development Approach:**
- Preferred methodology: Incremental development with working prototypes
- Testing strategy: Unit tests for business logic, manual testing for UI/UX
- Code organisation: MVVM pattern with proper separation of concerns

**Quality Standards:**
- Code review: Self-review with focus on timer accuracy and error handling
- Performance benchmarks: Smooth 60fps UI, accurate timing within 1 second
- Error handling: Graceful degradation and clear user messaging

**Communication Preferences:**
- Progress reporting: Regular updates on completed features
- Question escalation: Immediate clarification for ambiguous requirements
- Documentation: Update technical docs as architecture evolves

## 8. Acceptance Criteria & Testing

**Definition of Done:**
- [ ] All functional requirements implemented and tested
- [ ] Audio feedback works reliably across different devices
- [ ] Google Sheets integration functions correctly
- [ ] Timer accuracy verified across long workout sessions
- [ ] App installs and runs via sideloading
- [ ] User interface is clear and usable during physical exercise

**Test Scenarios:**
1. Happy path: User selects valid sheet, completes full workout with audio cues
2. Network interruption: App continues functioning when connectivity drops during workout
3. Invalid sheet format: App provides clear error message and recovery options
4. Long workout sessions: Timer remains accurate for 60+ minute routines
5. Audio preference changes: Settings persist and apply correctly

**Validation Methods:**
- Unit testing: Timer logic, data parsing, calculation functions
- Integration testing: Google API interactions, audio system integration
- User acceptance testing: Real workout scenarios with different routine types

## 9. Dependencies & Risks

**External Dependencies:**
- Google APIs: Critical dependency with impact on core functionality
- Android platform: Updates could affect compatibility

**Risk Assessment:**
- Google API changes: Low probability, high impact - mitigation through API versioning
- Audio system compatibility: Medium probability, medium impact - mitigation through testing across devices
- Timer drift on long sessions: Low probability, high impact - mitigation through careful timer implementation

## 10. Future Considerations

**Potential Enhancements:**
- iOS version using same .NET MAUI codebase
- Workout history and statistics tracking
- Custom workout creation within the app
- Integration with fitness wearables
- Multiple sheet format support

**Scalability Planning:**
- Architecture supports addition of local workout storage
- Code structure allows for multi-platform expansion
- API integration designed for future feature additions