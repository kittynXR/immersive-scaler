# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Repository Overview

This is the **VRChat Immersive Scaler** - a non-destructive avatar scaling tool for VRChat that uses the NDMF (Non-Destructive Modular Framework) to apply scaling changes during avatar build time without permanently modifying scene files.

## Development Environment

- **Unity Version**: 2022.3.22f1+
- **VRChat SDK**: 3.7.0+ required
- **NDMF**: Required for build-time processing (auto-installed with VCC)
- **C# Version**: Varies by Unity version (C# 9.0 for 2022.3)
- **Development happens within Unity Editor** - no traditional build process

## Project Structure

```
immersive-scaler/
├── build.sh                                    # Main build script for creating releases
├── kittyncat_tools/cat.kittyn.immersive-scaler/
│   ├── package.json                            # Unity package manifest
│   ├── Editor/                                 # Editor-only code
│   │   ├── ImmersiveScalerCore.cs             # Core scaling calculations
│   │   ├── ImmersiveScalerWindow.cs           # Unity Editor window UI
│   │   ├── ImmersiveScalerPlugin.cs           # NDMF plugin integration
│   │   ├── ImmersiveScalerComponentEditor.cs  # Custom inspector
│   │   ├── ImmersiveScalerUIShared.cs         # Shared UI components
│   │   └── cat.kittyn.immersive-scaler.Editor.asmdef
│   └── Runtime/                                # Runtime components
│       ├── ImmersiveScalerComponent.cs         # Main component with scaling parameters
│       └── cat.kittyn.immersive-scaler.Runtime.asmdef
└── screenshots/                                # Documentation images
```

## Build and Release Commands

### Creating a New Release
```bash
./build.sh <version>  # where version is major, minor, patch, or x.y.z
# Examples:
./build.sh patch      # Bumps patch version (1.0.3 -> 1.0.4)
./build.sh minor      # Bumps minor version (1.0.3 -> 1.1.0)
./build.sh major      # Bumps major version (1.0.3 -> 2.0.0)
./build.sh 1.2.3      # Sets specific version
```

The build script:
- Updates package.json version
- Creates VCC-compatible .zip package
- Creates .unitypackage (if Unity is available)
- Commits version bump
- Creates git tag
- Pushes to GitHub
- Creates GitHub release with artifacts

### Setting Unity Version for Builds
```bash
./build.sh --set-unity-version 2022.3.22f1
```

## Key Architecture Patterns

### NDMF Integration
- **Build Phase**: Transforming phase - applies scaling during avatar build
- **Plugin Class**: `ImmersiveScalerPlugin` registers with NDMF
- **Non-Destructive**: All changes applied to build copy, not scene
- **Auto-Cleanup**: Component removes itself after processing

### Core Classes
- `ImmersiveScalerComponent`: Runtime component holding scaling parameters
- `ImmersiveScalerCore`: Core scaling logic and measurements
- `ImmersiveScalerPlugin`: NDMF build processor
- `ImmersiveScalerWindow`: Editor window interface
- `ImmersiveScalerComponentEditor`: Custom inspector UI

### Scaling System
1. **Measurement Methods**: Total height, eye height, or custom
2. **Proportional Scaling**: Separate controls for arms, legs, torso
3. **ViewPosition Sync**: Automatically adjusts VRChat eye position
4. **Preview System**: Real-time gizmos show measurement points

## Testing in Unity

### Manual Testing
1. Add component via menu: `Tools > ⚙️🎨 kittyn.cat 🐟 > 🐟 Immersive Avatar Scaler`
2. Click "Add VRChat Immersive Scaler" to avatar root
3. Configure scaling parameters in component
4. Use "Apply Preview" to see changes in editor
5. Build avatar with VRChat SDK - scaling applies automatically

### Common Test Scenarios
- Different avatar types (humanoid/generic)
- Various measurement methods
- Extreme scaling values
- Missing bones/components
- Complex avatar hierarchies

## Important Development Notes

### Unity-Specific Considerations
- Always use `UnityEngine.Object` null checks (not C# null)
- Respect Unity's main thread requirements
- Handle both play mode and edit mode
- Use `EditorUtility.SetDirty()` when modifying assets

### VRChat-Specific Requirements
- Maintain ViewPosition accuracy after scaling
- Handle both humanoid and generic rigs
- Consider performance ranking impact
- Test with various avatar configurations

### NDMF Build Hook Pattern
- Implement scaling in `BuildPhase.Transforming`
- Access avatar via `ctx.AvatarRootTransform`
- Use `ctx.AvatarDescriptor` for VRChat properties
- Component auto-removal happens after processing

## Code Style

### Naming Conventions
- Classes: PascalCase (e.g., `ImmersiveScalerCore`)
- Methods: PascalCase (e.g., `ApplyScaling`)
- Fields: camelCase with underscore (e.g., `_targetHeight`)
- Properties: PascalCase (e.g., `TargetHeight`)

### File Organization
- Editor code in `Editor/` with `.Editor.asmdef`
- Runtime code in `Runtime/` with `.Runtime.asmdef`
- Keep UI logic separate from core logic
- Use partial classes for large UI implementations
