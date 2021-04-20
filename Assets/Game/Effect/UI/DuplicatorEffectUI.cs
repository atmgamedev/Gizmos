using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

namespace Gizmos
{
    public class DuplicatorEffectUI : EffectUI
    {
        [SerializeField] Image[] sphereImages;

        public override void SetUI(Effect effect)
        {
            var duplicatorEffect = effect as DuplicatorEffect;
            Assert.IsTrue(duplicatorEffect != null);

            for (int i = 0, length = duplicatorEffect.energies.Length; i < length; i++)
            {
                sphereImages[i].color = EnergyUtility.GetEnergyColor(duplicatorEffect.energies[i]);
            }
            sphereImages[1].gameObject.SetActive(duplicatorEffect.energies.Length > 1);
        }
    }
}
