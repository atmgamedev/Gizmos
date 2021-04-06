using UnityEngine;
using UnityEngine.UI;

namespace Gizmos
{
    public class BuildPickEffectUI : MonoBehaviour
    {
        [SerializeField] Image[] cardImages;
        public Image[] CardImages => cardImages;
    }
}
