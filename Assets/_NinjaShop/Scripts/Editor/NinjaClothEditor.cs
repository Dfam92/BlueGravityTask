using UnityEngine;
using UnityEditor;
namespace NinjaShop.NinjaClothes
{
    [CustomEditor(typeof(NinjaCloth))]
    public class NinjaClothEditor : Editor
    {
        NinjaCloth ninjaCloth;

        private void OnEnable()
        {
            ninjaCloth = (NinjaCloth)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (ninjaCloth == null) return;
            Texture2D texture = AssetPreview.GetAssetPreview(ninjaCloth.clothSprite);
            GUILayout.Label("", GUILayout.Height(100), GUILayout.Width(100));
            GUI.DrawTexture(GUILayoutUtility.GetLastRect(),texture);
        }
    }
}

