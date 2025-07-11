# Immersive Scaler Screenshot Requirements

This document outlines the specific screenshots needed for comprehensive Immersive Scaler documentation.

## Screenshot Directory Structure
```
screenshots/
├── immersive-scaler-hero-image.png              # Main README banner
├── interface/
│   ├── immersive-scaler-window-complete.png     # Full tool window
│   ├── immersive-scaler-component-inspector.png # Component in inspector
│   └── immersive-scaler-build-integration.png   # NDMF build process
├── features/
│   ├── immersive-scaler-measurement-gizmos.png  # Scene measurement visualization
│   ├── immersive-scaler-proportion-demo.png     # Proportion control results
│   ├── immersive-scaler-measurement-methods.png # Different measurement approaches
│   └── immersive-scaler-viewposition-sync.png   # Eye height adjustment
├── before-after/
│   ├── immersive-scaler-height-comparison.png   # Before/after scaling
│   └── immersive-scaler-proportion-comparison.png # Proportion adjustments
└── workflow/
    ├── immersive-scaler-setup-step1.png         # Adding component
    ├── immersive-scaler-setup-step2.png         # Configuration
    └── immersive-scaler-setup-step3.png         # Build result
```

## Required Screenshots

### 1. Hero Image (800x400px)
**File**: `immersive-scaler-hero-image.png`
**Purpose**: Main README banner showcasing the tool's primary value
**Content**:
- Unity Scene view with avatar and measurement gizmos visible
- Shows before/after avatar heights side by side
- Immersive Scaler window open showing key controls
- Professional measurement visualization
- Clear demonstration of non-destructive scaling

### 2. Complete Tool Window (700x600px)
**File**: `interface/immersive-scaler-window-complete.png`
**Purpose**: Comprehensive interface documentation
**Content**:
- Full Immersive Scaler window with all sections expanded
- Target height settings clearly visible
- Upper body percentage controls
- Arm/leg thickness sliders
- Measurement method dropdown
- Auto-populate measurements button
- Preview mode controls
- All collapsible sections open to show full functionality

### 3. Component Inspector (600x500px)
**File**: `interface/immersive-scaler-component-inspector.png`
**Purpose**: Show Unity Inspector integration
**Content**:
- GameObject selected with VRChatImmersiveScaler component
- All component parameters visible in Inspector
- Shows the component as it appears in avatar hierarchy
- Demonstrates easy parameter access
- Shows component's integration with Unity workflow

### 4. Measurement Gizmos in Scene (800x600px)
**File**: `features/immersive-scaler-measurement-gizmos.png`
**Purpose**: Visualize measurement system
**Content**:
- Scene view showing avatar with measurement gizmos
- Visual indicators for different measurement points
- Height measurement lines clearly visible
- Arm measurement visualization (head-to-elbow, head-to-hand)
- Ground plane reference
- Shows how measurements are calculated visually

### 5. Before/After Height Comparison (800x500px)
**File**: `before-after/immersive-scaler-height-comparison.png`
**Purpose**: Demonstrate primary scaling functionality
**Content**:
- Side-by-side comparison of same avatar
- Left: Original height (e.g., 1.2m short avatar)
- Right: Scaled height (e.g., 1.7m realistic height)
- Maintain proportions while showing clear height difference
- Include height measurements as text overlays
- Show ViewPosition adjustment

### 6. Proportion Control Demo (800x500px)
**File**: `features/immersive-scaler-proportion-demo.png`
**Purpose**: Show advanced proportioning capabilities
**Content**:
- Three versions of same avatar showing different upper body percentages
- 30% (long legs), 50% (balanced), 70% (short legs)
- Clear visual differences in torso vs leg proportions
- Shows how the tool creates realistic body ratios
- Demonstrates artistic control over proportions

### 7. Measurement Methods Comparison (800x500px)
**File**: `features/immersive-scaler-measurement-methods.png`
**Purpose**: Explain measurement method selection
**Content**:
- Same avatar showing different measurement approaches
- Head-to-elbow (VRC standard) vs Head-to-hand vs Arm length
- Visual indicators showing what each method measures
- Shows why method selection affects results
- Demonstrates measurement accuracy importance

### 8. Build Process Integration (600x400px)
**File**: `interface/immersive-scaler-build-integration.png`
**Purpose**: Show NDMF integration
**Content**:
- Avatar hierarchy showing ImmersiveScaler component
- Build process window/logs showing NDMF processing
- Shows component auto-removal after build
- Demonstrates non-destructive workflow
- Shows integration with VRChat SDK build process

### 9. ViewPosition Sync Demo (600x400px)
**File**: `features/immersive-scaler-viewposition-sync.png`
**Purpose**: Show automatic eye height adjustment
**Content**:
- Avatar with VRCAvatarDescriptor selected
- ViewPosition gizmo showing eye height
- Before/after ViewPosition adjustment
- Shows how tool maintains proper eye level
- Demonstrates VRChat integration

### 10. Proportion Comparison (800x400px)
**File**: `before-after/immersive-scaler-proportion-comparison.png`
**Purpose**: Show body proportion improvements
**Content**:
- Before: Unrealistic proportions (too short legs, long torso)
- After: Realistic human proportions
- Shows arm/leg thickness retention
- Demonstrates natural-looking results
- Includes measurement annotations

## Technical Specifications

### Unity Editor Setup
- **Unity Version**: 2019.4.31f1 (VRChat standard)
- **Theme**: Dark theme for professional appearance
- **UI Scale**: 100% for consistency
- **Scene Setup**: Good lighting for avatar visibility
- **Test Content**: Use variety of avatar types (realistic, stylized, etc.)

### Avatar Requirements
- Use avatars with different proportions:
  - Short/chibi style avatar (1.2m height)
  - Realistic human proportions (1.7m height)
  - Stylized anime proportions
  - Show scaling working across different art styles

### Measurement Visualization
- **Gizmos**: Clearly visible measurement lines and points
- **Colors**: Use consistent color scheme for measurement indicators
- **Ground Reference**: Show floor/ground plane for height context
- **Annotations**: Add text overlays for measurements when helpful

### Screenshot Standards
- **Resolution**: High DPI capture, scaled down for sharpness
- **Format**: PNG for lossless quality
- **Compression**: Optimized for web without quality loss
- **Consistency**: Same Unity theme and setup across all shots
- **Context**: Include relevant Unity panels (Inspector, Scene view)

### Measurement Examples
- **Short Avatar**: 1.2m → 1.7m (common scaling scenario)
- **Tall Avatar**: 2.0m → 1.7m (downscaling example)
- **Proportion Fixes**: Show fixing unrealistic proportions
- **VRChat Standards**: Demonstrate VRChat-appropriate sizing

## Usage Priority

### High Priority (Essential)
1. Hero Image - Primary marketing/documentation shot
2. Height Comparison - Shows core functionality
3. Complete Tool Window - Shows all features
4. Component Inspector - Shows Unity integration

### Medium Priority (Important)
5. Measurement Gizmos - Shows measurement system
6. Proportion Demo - Shows advanced controls
7. Build Integration - Shows NDMF workflow
8. ViewPosition Sync - Shows VRChat integration

### Low Priority (Enhancement)
9. Measurement Methods - Technical comparison
10. Proportion Comparison - Advanced use case

## Special Considerations

### Non-Destructive Workflow
- Emphasize that changes happen at build time
- Show original avatar remains unchanged
- Demonstrate preview capabilities
- Show component removal after build

### VRChat Integration
- Show ViewPosition synchronization
- Demonstrate VRChat SDK compatibility
- Show proper eye height adjustment
- Include VRChat-specific measurements

### Performance Considerations
- Show that tool adds no runtime overhead
- Demonstrate build-time only processing
- Show clean final avatar state
- Emphasize no impact on avatar performance

## Update Schedule
- Update screenshots when UI changes significantly
- Refresh for major Unity version updates
- Update when new measurement methods are added
- Maintain consistency with other tool documentation
- Update when VRChat SDK changes affect integration