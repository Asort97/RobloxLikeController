# Roblox-Like Controller System

A professional third-person character controller implementation for Unity, designed to replicate the control mechanics found in Roblox. This system provides cross-platform support for both PC and mobile devices, featuring advanced camera controls, character movement, and animation integration.

## Overview

This project implements a comprehensive character control system that combines smooth character movement, dynamic camera behavior, and responsive touch controls. Built with Unity 2022.3.3f1, it leverages Cinemachine for advanced camera management and includes mobile-optimized touch controls with joystick support.

## Core Features

### Character Control System
- **Movement System**: Smooth character locomotion with directional input handling
- **Jump Mechanics**: Physics-based jumping with ground detection
- **Dynamic Speed Adjustment**: Adaptive movement speed based on input intensity
- **Character Rotation**: Smooth character orientation aligned with movement direction
- **Animation Integration**: Animator blend tree system for fluid character animations

### Advanced Camera System
- **Dual Camera Modes**: Seamless transition between third-person and first-person perspectives
- **Dynamic Zoom Control**: Pinch-to-zoom functionality for camera distance adjustment
- **First-Person Toggle**: Automatic first-person mode activation at minimum zoom distance
- **Cinemachine Integration**: Professional camera behavior using Unity Cinemachine
- **Touch-Based Camera Rotation**: Intuitive camera control via touch/drag input
- **Configurable Sensitivity**: Adjustable camera sensitivity for optimal user experience

### Mobile Optimization
- **Virtual Joystick**: On-screen joystick for mobile character movement
- **Touch Controls**: Multi-touch support for simultaneous movement and camera control
- **Touch Field System**: Dedicated screen area for camera manipulation
- **Performance Optimization**: FPS management with configurable frame rate limits
- **Responsive Layout**: Adaptive UI positioning based on screen dimensions

### Additional Features
- **Character Switching**: Runtime character model swapping with animation preservation
- **FPS Counter**: Real-time frame rate monitoring and display
- **Performance Unlocking**: Configurable VSync and target frame rate settings
- **Ground Detection**: Collision-based ground state management for accurate jump mechanics

## Technical Architecture

### Core Components

#### PlayerMovement.cs
The primary controller responsible for character locomotion and physics interactions.

**Key Responsibilities:**
- Processes input from virtual joystick
- Calculates movement direction based on camera orientation
- Manages character rotation and velocity
- Handles jump physics using Rigidbody forces
- Controls animator parameters for animation states
- Manages character visibility during first-person mode

**Configuration Parameters:**
- `speedMove`: Base movement velocity
- `forceJump`: Vertical impulse force for jumping
- `rotateSpeed`: Character rotation interpolation speed
- `smoothChangeSpeed`: Speed transition smoothing factor

#### CameraZoom.cs
Manages camera zoom mechanics and view mode transitions.

**Key Responsibilities:**
- Processes pinch gestures for zoom control
- Dynamically adjusts Cinemachine camera orbit radius
- Switches between third-person and first-person cameras
- Prevents zoom during movement input
- Maintains camera lens synchronization

**Configuration Parameters:**
- `Sensitivity`: Zoom gesture sensitivity multiplier
- Zoom range: 0.4 to 8 units
- First-person threshold: 0.5 units

#### InputCMCamera.cs
Bridges touch input to Cinemachine's axis system for camera rotation.

**Key Responsibilities:**
- Captures touch drag input via TouchField
- Translates touch deltas to Cinemachine input axes
- Applies sensitivity scaling for camera rotation
- Integrates with Cinemachine's input system

**Configuration Parameters:**
- `_touchSpeedSensitivityX`: Horizontal rotation sensitivity
- `_touchSpeedSensitivityY`: Vertical rotation sensitivity

#### TouchField.cs
Detects and processes touch input for camera control.

**Key Responsibilities:**
- Tracks pointer events on designated UI area
- Calculates touch delta movement
- Prevents camera rotation during zoom gestures
- Supports both touch and mouse input

#### CharacterSwitcher.cs
Enables runtime character model switching.

**Key Responsibilities:**
- Toggles between character model variants
- Updates animator references dynamically
- Maintains animation state during transitions
- Implements event-based animator updates

#### FPSUnlocker.cs
Manages application performance settings.

**Key Responsibilities:**
- Disables VSync for uncapped frame rates
- Sets target frame rate (default: 90 FPS)
- Displays real-time FPS counter
- Optimizes rendering performance

## Dependencies

### Unity Packages
- **Cinemachine**: Advanced camera control and behavior system
- **TextMesh Pro**: High-quality text rendering for UI elements

### Third-Party Assets
- **Joystick Pack**: Virtual joystick implementation for mobile controls
- **Graphy**: Ultimate stats monitor for performance tracking (optional)

### Unity Version
- **Minimum Version**: Unity 2022.3.3f1
- **Target Platforms**: PC (Windows, macOS, Linux), Mobile (Android, iOS)

## Setup Instructions

### Prerequisites
1. Unity 2022.3.3f1 or later
2. Basic understanding of Unity Editor
3. Git for version control

### Installation

1. **Clone the Repository**
   ```bash
   git clone https://github.com/Asort97/RobloxLikeController.git
   cd RobloxLikeController
   ```

2. **Open in Unity**
   - Launch Unity Hub
   - Click "Add" and select the cloned project directory
   - Open the project with Unity 2022.3.3f1 or later

3. **Import Required Packages**
   - Cinemachine should be automatically imported
   - TextMesh Pro essentials will prompt on first use

4. **Scene Setup**
   - Open the main scene located in `Assets/Scenes/`
   - Ensure all prefabs are properly referenced

### Configuration

#### Character Setup
1. Assign character models to `CharacterSwitcher` component
2. Configure animator controllers with required parameters:
   - `isMoving` (bool)
   - `VelocityX` (float)
   - `VelocityY` (float)
   - `isJump` (trigger)
   - `isGrounded` (bool)

#### Camera Configuration
1. Configure Cinemachine FreeLook camera for third-person view
2. Set up Cinemachine Virtual Camera for first-person view
3. Adjust camera orbit radii and sensitivity values
4. Position cameras appropriately relative to character

#### Input Configuration
1. Position virtual joystick UI element (left side of screen)
2. Configure TouchField component (right side of screen)
3. Adjust sensitivity values for camera and movement
4. Test touch zones on target device resolution

## Usage

### Basic Controls

**PC Controls:**
- **Movement**: Use virtual joystick (or WASD if implemented)
- **Camera Rotation**: Hold and drag right mouse button
- **Jump**: Click jump button (UI element)

**Mobile Controls:**
- **Movement**: Use on-screen joystick (left side)
- **Camera Rotation**: Drag on right side of screen
- **Zoom**: Pinch gesture with two fingers on right side
- **Jump**: Tap jump button

### Camera Behavior
- **Third-Person Mode**: Default view with adjustable distance
- **First-Person Mode**: Automatically activates when zoomed to minimum
- Character mesh is hidden in first-person mode for immersion

### Character Switching
- Use the character switch button to toggle between available character models
- Animations and controls remain consistent across characters

## Project Structure

```
Assets/
├── Animations/          # Character animation files
├── Models/             # 3D character models
│   └── Characters/     # Boy and girl character variants
├── Scenes/             # Unity scene files
├── Scripts/            # Core controller scripts
│   ├── PlayerMovement.cs
│   ├── CameraZoom.cs
│   ├── InputCMCamera.cs
│   ├── TouchField.cs
│   ├── CharacterSwitcher.cs
│   └── FPSUnlocker.cs
├── Joystick Pack/      # Virtual joystick implementation
├── Graphy/             # Performance monitoring (optional)
└── TextMesh Pro/       # Text rendering resources
```

## Performance Considerations

### Optimization Strategies
- VSync disabled for mobile performance
- Target frame rate set to 90 FPS for smooth gameplay
- Character mesh culled during first-person mode
- Touch input processed with zone-based filtering
- Cinemachine lens synchronization minimizes recalculation

### Mobile Performance
- Tested on Android and iOS devices
- Optimized touch processing for low-latency input
- Efficient animator parameter updates
- Minimal draw calls through smart visibility management

## Known Limitations

- Camera zoom is disabled during character movement
- Pinch gesture requires both touches on right side of screen
- Character must be on ground (tagged "Ground") for jump to work
- First-person mode requires camera zoom below 0.5 units

## Future Enhancements

Potential improvements for future development:
- Sprinting and crouching mechanics
- Swimming and climbing systems
- Enhanced animation state machines
- Customizable control schemes
- Network multiplayer support
- Advanced character customization

## License

This project is available for educational and commercial use. Please refer to the repository license file for detailed terms.

## Contributing

Contributions are welcome. Please follow these guidelines:
1. Fork the repository
2. Create a feature branch
3. Commit changes with clear descriptions
4. Submit pull request with detailed explanation

## Acknowledgments

- **Cinemachine**: Unity Technologies
- **Joystick Pack**: Virtual joystick asset
- **Graphy**: Performance monitoring tool

## Support

For issues, questions, or suggestions:
- Create an issue in the GitHub repository
- Provide detailed reproduction steps for bugs
- Include Unity version and platform information

---

**Project Status**: Active Development  
**Unity Version**: 2022.3.3f1  
**Last Updated**: October 2025
