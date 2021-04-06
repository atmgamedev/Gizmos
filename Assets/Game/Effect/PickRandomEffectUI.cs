using UnityEngine;
using UnityEngine.UI;

namespace Gizmos
{
    public class PickRandomEffectUI : MonoBehaviour
    {
        [SerializeField] Image[] sphereImages;
        public Image[] SphereImages => sphereImages;
    }
}
