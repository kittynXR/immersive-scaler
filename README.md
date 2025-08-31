# cátte — Immersive Scaler

Rizz up your immersion! No blender required and non-destructive!

![Immersive Avatar Scaler](./screenshots/immersive-scaler-hero-image.png)

## Installation

### VRChat Creator Companion (Recommended)

1. Add the repository to VCC: `https://immersive-scaler.kittyn.cat/index.json`
2. Find "cátte — Immersive Scaler" in the package list
3. Click "Add" to install to your project

### Manual Installation

1. Download the latest release from [Releases](https://github.com/kittynXR/immersive-scaler/releases)
2. Extract the zip file to your Unity project's `Packages` folder

## Requirements

- Unity 2019.4.31f1 or later
- VRChat SDK 3.7.0 or later
- NDMF (Non-Destructive Modular Framework) - Automatically installed with VCC

## Features

### 🎯 Precise Avatar Scaling
- **Target Height Control** - Set exact avatar height in meters
- **Proportional Body Scaling** - Separate controls for arms, legs, and torso
- **Multiple Measurement Methods** - Total height, eye height, or custom measurements
- **Real-time Measurement Display** - See current avatar stats instantly

### 🔧 Advanced Proportioning
- **Upper Body Percentage** - Fine-tune torso vs leg proportions (30-75% range)
- **Bone Thickness Control** - Adjust arm/leg thickness independently from length
- **Thigh/Calf Ratio** - Control leg shape and proportions
- **Hand & Foot Scaling** - Toggle scaling for extremities

### 🛡️ Non-Destructive Workflow
- **NDMF Integration** - Scaling applied during build, not in editor
- **Original State Preservation** - Can revert all changes anytime
- **Preview Mode** - See results before committing to build
- **ViewPosition Sync** - Automatically adjusts VRChat eye position

### 📐 Professional Measurement System
- **Multiple Arm Measurement Methods** - Head-to-elbow (VRC standard), head-to-hand, arm length
- **Bone vs Mesh-based Calculations** - Choose measurement method that fits your avatar
- **Visual Measurement Indicators** - Scene gizmos show measurement points
- **Auto-population** - Automatically detect current avatar measurements

### ⚡ Workflow Optimization
- **Build-time Processing** - No permanent changes to your scene
- **Component Auto-removal** - Keeps your scene clean after processing
- **Comprehensive Logging** - Detailed feedback for troubleshooting
- **Error Handling** - Graceful handling of edge cases and complex avatars

## Usage

### Getting Started

1. **Open Immersive Scaler**: Go to `Tools > ⚙️🎨 kittyn.cat 🐟 > 🐟 Immersive Avatar Scaler`
2. **Add Component**: Click "Add VRChat Immersive Scaler" to your avatar root
3. **Set Target Height**: Enter your desired avatar height in meters
4. **Configure Proportions**: Adjust upper body percentage and bone thickness
5. **Build Avatar**: Use VRChat SDK build panel - scaling happens automatically

### Common Workflows

#### Basic Height Adjustment
```
1. Add Immersive Scaler component to avatar root
2. Set target height (e.g., 1.75m for average human)
3. Leave other settings at defaults
4. Build avatar - scaling applied automatically
```

#### Fine-tuning Proportions
```
1. Set target height first
2. Adjust "Upper Body Percentage" (40-50% typical)
3. Modify arm/leg thickness as needed (80-100%)
4. Preview changes with scene gizmos
5. Build when satisfied with proportions
```

#### Professional Avatar Scaling
```
1. Use "Auto-populate measurements" to get current stats
2. Choose appropriate measurement method for your avatar
3. Fine-tune thigh/calf ratios for realistic leg shape
4. Adjust hand/foot scaling based on art style
5. Use preview mode to verify before final build
```

### Advanced Features

#### Measurement Methods
- **Total Height** - Measures from lowest to highest point
- **Eye Height** - Measures from avatar's eye level to floor
- **Custom** - Use your own measurement points

#### Arm Scaling Options
- **Head to Elbow (VRC Standard)** - Matches VRChat's arm length calculation
- **Head to Hand** - Full arm reach measurement
- **Arm Length** - Upper arm + forearm length combined

#### Proportioning Controls
- **Upper Body Percentage** - How much of total height is torso (30-75%)
- **Arm Thickness** - Retain original arm thickness (0-100%)
- **Leg Thickness** - Retain original leg thickness (0-100%)
- **Thigh/Calf Ratio** - Control leg shape proportions

#### Special Features
- **Keep Head Size** - Scales torso instead of head for cartoon avatars
- **Extra Leg Length** - Add extra height for ground clearance
- **Model Centering** - Automatically centers avatar at world origin
- **Finger Spreading** - Adjust finger positions for better IK

## Screenshots

![Complete Tool Interface](./screenshots/interface/immersive-scaler-window-complete.png)
*Complete Immersive Scaler interface with measurement and scaling controls*

![Measurement Gizmos](./screenshots/features/immersive-scaler-measurement-gizmos.png)
*Scene view showing measurement gizmos and scaling preview*

![Height Scaling Comparison](./screenshots/before-after/immersive-scaler-height-comparison.png)
*Avatar before and after scaling with proportional adjustments*

## Why Immersive Scaler?

### Traditional Scaling Problems:
- Destructive changes to your avatar
- Requires external tools like Blender
- Complex bone scaling calculations
- ViewPosition desync issues
- Permanent scene modifications

### Immersive Scaler Solutions:
- **Non-destructive** - Changes only applied during build
- **Unity-native** - No external tools required
- **Intelligent proportioning** - Realistic body ratios
- **Automatic ViewPosition** - Perfect eye height sync
- **Clean workflow** - No permanent scene changes

## Tips & Best Practices

### Getting Natural Proportions
- Use 40-50% upper body percentage for realistic humans
- Keep arm/leg thickness at 80-100% for natural look
- Adjust thigh/calf ratio based on avatar style
- Enable hand/foot scaling for cartoon avatars

### Troubleshooting
- Use "Auto-populate measurements" for accurate baselines
- Switch measurement methods if results look off
- Check avatar hierarchy - root should be at avatar base
- Use preview mode to verify before building

#### Floor Measurement Issues
If your avatar's floor is being detected far below the actual feet:
- This happens when mesh bounds extend beyond visible geometry
- Common causes: blend shapes, hidden meshes, or incorrect bounds from modeling software
- **Solution**: Enable "Use Bone-Based Floor" in Advanced Options
- This uses foot/toe bone positions instead of mesh bounds for accurate floor detection

### Performance Considerations
- Immersive Scaler adds no runtime overhead
- Component automatically removes itself after build
- No impact on avatar performance ranking
- Compatible with all VRChat features

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Support

- [Issues](https://github.com/kittynXR/immersive-scaler/issues)
- [Discussions](https://github.com/kittynXR/immersive-scaler/discussions)