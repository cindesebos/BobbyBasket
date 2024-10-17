#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace Sources.Game.Editor
{
    [InitializeOnLoad]
    public static class BootSceneAutoLoader
    {
        private static string BootSceneName = Scenes.Boot.ToString();

        static BootSceneAutoLoader() => EditorApplication.playModeStateChanged += OnPlayModeChanged;

        private static void OnPlayModeChanged(PlayModeStateChange state)
        {
            if (state != PlayModeStateChange.EnteredPlayMode) return;

            if (SceneManager.GetActiveScene().name != BootSceneName) SceneManager.LoadScene(BootSceneName);

            EditorApplication.playModeStateChanged -= OnPlayModeChanged;
        }
    }
}
#endif