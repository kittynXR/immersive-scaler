using UnityEditor;
using UnityEngine;

namespace Kittyn.Tools
{
    public static class KittynLanguageSelector
    {
        private const int MENU_PRIORITY = 500;
        
        [MenuItem("Tools/⚙️🎨 kittyn.cat 🐟/🌐 Language / 言語/English", false, MENU_PRIORITY)]
        private static void SetLanguageEnglish()
        {
            SetLanguage("en", "English");
        }
        
        [MenuItem("Tools/⚙️🎨 kittyn.cat 🐟/🌐 Language / 言語/日本語 (Japanese)", false, MENU_PRIORITY + 1)]
        private static void SetLanguageJapanese()
        {
            SetLanguage("ja", "日本語");
        }
        
        [MenuItem("Tools/⚙️🎨 kittyn.cat 🐟/🌐 Language / 言語/Español (Spanish)", false, MENU_PRIORITY + 2)]
        private static void SetLanguageSpanish()
        {
            SetLanguage("es", "Español");
        }
        
        [MenuItem("Tools/⚙️🎨 kittyn.cat 🐟/🌐 Language / 言語/한국어 (Korean)", false, MENU_PRIORITY + 3)]
        private static void SetLanguageKorean()
        {
            SetLanguage("ko", "한국어");
        }
        
        [MenuItem("Tools/⚙️🎨 kittyn.cat 🐟/🌐 Language / 언어/Français (French)", false, MENU_PRIORITY + 4)]
        private static void SetLanguageFrench()
        {
            SetLanguage("fr", "Français");
        }
        
        [MenuItem("Tools/⚙️🎨 kittyn.cat 🐟/🌐 Language / 언어/Deutsch (German)", false, MENU_PRIORITY + 5)]
        private static void SetLanguageGerman()
        {
            SetLanguage("de", "Deutsch");
        }
        
        [MenuItem("Tools/⚙️🎨 kittyn.cat 🐟/🌐 Language / 언어/Català (Catalan)", false, MENU_PRIORITY + 6)]
        private static void SetLanguageCatalan()
        {
            SetLanguage("ca", "Català");
        }
        
        [MenuItem("Tools/⚙️🎨 kittyn.cat 🐟/🌐 Language / 언어/English", true)]
        private static bool ValidateLanguageEnglish()
        {
            return KittynLocalization.CurrentLanguage != "en";
        }
        
        [MenuItem("Tools/⚙️🎨 kittyn.cat 🐟/🌐 Language / 언어/日本語 (Japanese)", true)]
        private static bool ValidateLanguageJapanese()
        {
            return KittynLocalization.CurrentLanguage != "ja";
        }
        
        [MenuItem("Tools/⚙️🎨 kittyn.cat 🐟/🌐 Language / 언어/Español (Spanish)", true)]
        private static bool ValidateLanguageSpanish()
        {
            return KittynLocalization.CurrentLanguage != "es";
        }
        
        [MenuItem("Tools/⚙️🎨 kittyn.cat 🐟/🌐 Language / 언어/한국어 (Korean)", true)]
        private static bool ValidateLanguageKorean()
        {
            return KittynLocalization.CurrentLanguage != "ko";
        }
        
        [MenuItem("Tools/⚙️🎨 kittyn.cat 🐟/🌐 Language / 언어/Français (French)", true)]
        private static bool ValidateLanguageFrench()
        {
            return KittynLocalization.CurrentLanguage != "fr";
        }
        
        [MenuItem("Tools/⚙️🎨 kittyn.cat 🐟/🌐 Language / 언어/Deutsch (German)", true)]
        private static bool ValidateLanguageGerman()
        {
            return KittynLocalization.CurrentLanguage != "de";
        }
        
        [MenuItem("Tools/⚙️🎨 kittyn.cat 🐟/🌐 Language / 언어/Català (Catalan)", true)]
        private static bool ValidateLanguageCatalan()
        {
            return KittynLocalization.CurrentLanguage != "ca";
        }
        
        private static void SetLanguage(string languageCode, string languageName)
        {
            Debug.Log($"[KittynLanguageSelector] Attempting to set language to: {languageCode} ({languageName})");
            
            var oldLanguage = KittynLocalization.CurrentLanguage;
            KittynLocalization.CurrentLanguage = languageCode;
            var newLanguage = KittynLocalization.CurrentLanguage;
            
            Debug.Log($"[KittynLanguageSelector] Language changed from '{oldLanguage}' to '{newLanguage}'");
            
            var message = KittynLocalization.Get("messages.language_changed");
            Debug.Log($"[KittynLanguageSelector] Test message: {message}");
            
            // Repaint all editor windows to update UI immediately
            EditorApplication.RepaintHierarchyWindow();
            
            // Force repaint of all windows
            var windows = Resources.FindObjectsOfTypeAll<EditorWindow>();
            foreach (var window in windows)
            {
                window.Repaint();
            }
            
            // Show a temporary notification
            if (EditorWindow.focusedWindow != null)
            {
                EditorWindow.focusedWindow.ShowNotification(new GUIContent($"Language: {languageName}"), 3f);
            }
        }
        
        /// <summary>
        /// Create a language selection dropdown for use in settings windows
        /// </summary>
        public static void DrawLanguageSelector(string label = null)
        {
            var displayLabel = label ?? KittynLocalization.Get("common.language");
            var currentLanguage = KittynLocalization.CurrentLanguage;
            var languages = KittynLocalization.AvailableLanguages;
            var languageNames = new string[languages.Length];
            var currentIndex = 0;
            
            for (int i = 0; i < languages.Length; i++)
            {
                languageNames[i] = KittynLocalization.GetLanguageDisplayName(languages[i]);
                if (languages[i] == currentLanguage)
                    currentIndex = i;
            }
            
            EditorGUI.BeginChangeCheck();
            var newIndex = EditorGUILayout.Popup(displayLabel, currentIndex, languageNames);
            if (EditorGUI.EndChangeCheck() && newIndex != currentIndex)
            {
                SetLanguage(languages[newIndex], languageNames[newIndex]);
            }
        }
        
        /// <summary>
        /// Get current language display name for status display
        /// </summary>
        public static string GetCurrentLanguageDisplayName()
        {
            return KittynLocalization.GetLanguageDisplayName(KittynLocalization.CurrentLanguage);
        }
    }
}