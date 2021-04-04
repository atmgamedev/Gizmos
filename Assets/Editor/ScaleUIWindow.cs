using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using TMPro;

namespace Toolkit
{
    public class ScaleUIWindow : OdinEditorWindow
    {
        [MenuItem("Window/ScaleUIWindow")]
        static void OpenWindow()
        {
            GetWindow<ScaleUIWindow>().Show();
        }

        public RectTransform root;

        [Button]
        void ScaleChildrenUI(float scale)
        {
            var children = root.GetComponentsInChildren<RectTransform>();
            for (int i = 0, length = children.Length; i < length; i++)
            {
                var child = children[i];
                child.anchoredPosition *= scale;
                child.sizeDelta *= scale;
            }

            var texts = root.GetComponentsInChildren<Text>();
            for (int i = 0, length = texts.Length; i < length; i++)
            {
                var text = texts[i];
                text.fontSize *= 2;
            }

            var tmps = root.GetComponentsInChildren<TextMeshProUGUI>();
            for (int i = 0, length = tmps.Length; i < length; i++)
            {
                var tmp = tmps[i];
                tmp.fontSize *= 2;
            }
        }
    }
}
