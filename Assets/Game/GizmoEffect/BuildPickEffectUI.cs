using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

namespace Gizmos
{
    public class BuildPickEffectUI : MonoBehaviour, IGizmoEffectUI
    {
        [SerializeField] Image[] cardImages;

        public void SetUI(GizmoEffect effect)
        {
            BuildPickEffect buildPickEffect = effect as BuildPickEffect;
            Assert.IsTrue(buildPickEffect != null);

            for (int i = 0, length = buildPickEffect.energies.Length; i < length; i++)
            {
                cardImages[i].color = EnergyUtility.GetEnergyColor(buildPickEffect.energies[i]);
            }
            cardImages[1].gameObject.SetActive(buildPickEffect.energies.Length > 1);
        }
    }
}
