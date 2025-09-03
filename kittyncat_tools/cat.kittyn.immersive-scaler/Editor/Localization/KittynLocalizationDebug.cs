using UnityEditor;
using UnityEngine;
using System.Linq;

namespace Kittyn.Tools.ImmersiveScaler
{
    public static class KittynLocalizationDebug
    {
        [MenuItem("Tools/⚙️🎨 kittyn.cat 🐟/🧪 QA/Immersive Scaler - Log Localization Status", false, 821)]
        public static void LogStatus()
        {
            Debug.Log($"[Immersive Scaler Localization Debug] Testing Immersive Scaler localization system...");
            
            // Force init
            var langs = KittynLocalization.AvailableLanguages;
            Debug.Log($"[Immersive Scaler Localization] Current: {KittynLocalization.CurrentLanguage} | Available: {string.Join(", ", langs)}");

            // Sample keys that Immersive Scaler should have
            string[] sample = new[]
            {
                "common.language",
                "messages.language_changed",
                "immersive_scaler.window_title",
                "immersive_scaler.comp_header",
                "immersive_scaler.target_height",
            };

            foreach (var code in langs.OrderBy(s => s))
            {
                var ok = sample.Select(k => (k, KittynLocalization.Get(k, code))).ToArray();
                Debug.Log($"[Immersive Scaler Localization] {code}: " + string.Join(" | ", ok.Select(p => $"{p.k}='{p.Item2}'")));
            }
            
            // Test keys that Immersive Scaler should NOT have (from other plugins)
            string[] shouldNotHave = new[]
            {
                "comfi_hierarchy.window_title",
                "enhanced_dynamics.status",
            };
            
            Debug.Log($"[Immersive Scaler Localization] Testing excluded keys (should return [key]):");
            foreach (var key in shouldNotHave)
            {
                var result = KittynLocalization.Get(key);
                Debug.Log($"[Immersive Scaler Localization] {key} = '{result}'" + (result.StartsWith("[") ? " ✅ Correctly excluded" : " ❌ Should be excluded"));
            }
        }
    }
}