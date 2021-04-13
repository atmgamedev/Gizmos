using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

namespace Gizmos
{
    public class ConverterEffectUI : MonoBehaviour, IGizmoEffectUI
    {
        [SerializeField] Image[] sphereImages;

        public void SetUI(GizmoEffect effect)
        {
            ConverterEffect conterverEffect = effect as ConverterEffect;
            Assert.IsTrue(conterverEffect != null);

            for (int i = 0, length = conterverEffect.energies.Length; i < length; i++)
            {
                sphereImages[i].color = EnergyUtility.GetEnergyColor(conterverEffect.energies[i]);
            }
            sphereImages[1].gameObject.SetActive(conterverEffect.energies.Length > 1);
        }
    }
}
