using UnityEngine;
using UnityEditor;
using System.Reflection;
using System.Linq;

namespace VRChatImmersiveScaler
{
    public static class TestIconDetection
    {
        [MenuItem("Tools/⚙️🎨 kittyn.cat 🐟/🧪 Test Immersive Scaler Icon")]
        public static void TestIcon()
        {
            Debug.Log("[ImmersiveScaler] ========== Testing component icon ==========");
            
            var type = typeof(ImmersiveScalerComponent);
            
            // Test 1: Check IconAttribute (fallback for Unity 2021.2+)
            #if UNITY_2021_2_OR_NEWER
            var iconAttr = type.GetCustomAttribute<IconAttribute>();
            if (iconAttr != null)
            {
                Debug.Log($"[ImmersiveScaler] ✓ IconAttribute found: {iconAttr.path}");
            }
            #endif
            
            // Test 2: Check if icon texture exists
            var iconPaths = new[]
            {
                "Packages/cat.kittyn.immersive-scaler/Editor/Icons/ImmersiveScaler.png",
                "Assets/kittyncat_tools/cat.kittyn.immersive-scaler/Editor/Icons/ImmersiveScaler.png"
            };
            
            string foundPath = null;
            foreach (var path in iconPaths)
            {
                if (AssetDatabase.LoadAssetAtPath<Texture2D>(path) != null)
                {
                    foundPath = path;
                    break;
                }
            }
            
            if (foundPath != null)
            {
                Debug.Log($"[ImmersiveScaler] ✓ Icon texture found at: {foundPath}");
            }
            else
            {
                Debug.Log("[ImmersiveScaler] ✗ Icon texture not found");
            }
            
            // Test 3: Check component icon via ObjectContent
            var content = EditorGUIUtility.ObjectContent(null, type);
            if (content != null && content.image != null)
            {
                Debug.Log($"[ImmersiveScaler] ✓ Component icon detected: {content.image.name}");
                Debug.Log($"[ImmersiveScaler]   Icon type: {content.image.GetType().Name}");
                Debug.Log($"[ImmersiveScaler]   Icon size: {content.image.width}x{content.image.height}");
            }
            else
            {
                Debug.Log("[ImmersiveScaler] ✗ No component icon detected via ObjectContent");
                
                // Test with a temporary GameObject
                var tempGO = new GameObject("TempTest");
                var comp = tempGO.AddComponent<ImmersiveScalerComponent>();
                var goContent = EditorGUIUtility.ObjectContent(comp, type);
                if (goContent != null && goContent.image != null)
                {
                    Debug.Log($"[ImmersiveScaler] ✓ Icon detected with instance: {goContent.image.name}");
                }
                else
                {
                    Debug.Log("[ImmersiveScaler] ✗ No icon even with component instance");
                }
                UnityEngine.Object.DestroyImmediate(tempGO);
            }
            
            // Test 4: ComfiHierarchy integration
            var iconManagerType = System.Type.GetType("Comfi.Hierarchy.IconManager, cat.kittyn.comfi-hierarchy.Editor");
            if (iconManagerType != null)
            {
                var getIconMethod = iconManagerType.GetMethod("GetIcon", new[] { typeof(System.Type) });
                if (getIconMethod != null)
                {
                    var comfiIcon = getIconMethod.Invoke(null, new object[] { type }) as Texture2D;
                    if (comfiIcon != null)
                    {
                        Debug.Log($"[ImmersiveScaler] ✓ ComfiHierarchy detected icon: {comfiIcon.name}");
                    }
                    else
                    {
                        Debug.Log("[ImmersiveScaler] ✗ ComfiHierarchy did not detect icon");
                        
                        // Check ComfiHierarchy settings
                        var settingsType = System.Type.GetType("Comfi.Hierarchy.ComfiSettings, cat.kittyn.comfi-hierarchy.Editor");
                        if (settingsType != null)
                        {
                            var instanceProp = settingsType.GetProperty("Instance");
                            var settings = instanceProp?.GetValue(null);
                            if (settings != null)
                            {
                                var thirdPartyEnabled = settings.GetType().GetField("enableThirdPartyIconDetection")?.GetValue(settings);
                                var monoScriptEnabled = settings.GetType().GetField("enableMonoScriptIconDetection")?.GetValue(settings);
                                var assetDbEnabled = settings.GetType().GetField("enableAssetDatabaseIconSearch")?.GetValue(settings);
                                
                                Debug.Log($"[ImmersiveScaler] ComfiHierarchy Settings:");
                                Debug.Log($"[ImmersiveScaler]   Third-party detection: {thirdPartyEnabled}");
                                Debug.Log($"[ImmersiveScaler]   MonoScript detection: {monoScriptEnabled}");
                                Debug.Log($"[ImmersiveScaler]   AssetDatabase search: {assetDbEnabled}");
                            }
                        }
                    }
                }
            }
            else
            {
                Debug.Log("[ImmersiveScaler] - ComfiHierarchy not installed");
            }
            
            // Test 5: Check meta file icon setting
            var metaPath = AssetDatabase.GetTextMetaFilePathFromAssetPath(
                AssetDatabase.FindAssets($"t:MonoScript {type.Name}")
                    .Select(AssetDatabase.GUIDToAssetPath)
                    .FirstOrDefault(p => p.EndsWith($"{type.Name}.cs"))
            );
            
            if (!string.IsNullOrEmpty(metaPath) && System.IO.File.Exists(metaPath))
            {
                var metaContent = System.IO.File.ReadAllText(metaPath);
                if (metaContent.Contains("icon: {fileID: 2800000"))
                {
                    Debug.Log("[ImmersiveScaler] ✓ Icon is properly set in .meta file");
                }
                else if (metaContent.Contains("icon: {instanceID: 0}"))
                {
                    Debug.Log("[ImmersiveScaler] ✗ Icon NOT set in .meta file (instanceID: 0)");
                }
            }
            
            Debug.Log("[ImmersiveScaler] ========== Test complete ==========");
            Debug.Log("[ImmersiveScaler] Icon should now appear in: Hierarchy, Add Component menu, and Inspector");
        }
    }
}