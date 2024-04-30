using UnityEngine;
using UnityEngine.UI;

using BBUnity.UI.Utilities;

namespace BBUnity.UI.Components {

    /// <summary>
    /// 
    /// </summary>
    public class BackgroundGradient : BaseMeshEffect {
        public Color m_color1 = Color.white;
        public Color m_color2 = Color.white;

        public override void ModifyMesh(VertexHelper vh) {
            if(!enabled) return;

            Rect rect = graphic.rectTransform.rect;
            Vector2 dir = ColorGradient.RotationDir(0.0f);

            ColorGradient.Matrix2x3 localPositionMatrix = ColorGradient.LocalPositionMatrix(rect, dir);

            UIVertex vertex = default(UIVertex);
            for (int i = 0; i < vh.currentVertCount; i++) {
                vh.PopulateUIVertex(ref vertex, i);
                Vector2 localPosition = localPositionMatrix * vertex.position;
                vertex.color *= Color.Lerp(m_color2, m_color1, localPosition.y);
                vh.SetUIVertex(vertex, i);
            }
        }
    }
}
