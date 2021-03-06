using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

namespace Gizmos
{
    public class BuildPickEffectUI : EffectUI
    {
        [SerializeField] Image[] cardImages;

        public override void SetUI(Effect effect)
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
