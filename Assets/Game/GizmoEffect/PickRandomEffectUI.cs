using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

namespace Gizmos
{
    public class PickRandomEffectUI : MonoBehaviour, IGizmoEffectUI
    {
        [SerializeField] Image[] sphereImages;

        public void SetUI(GizmoEffect effect)
        {
            PickRandomEffect pickRandomEffect = effect as PickRandomEffect;
            Assert.IsTrue(pickRandomEffect != null);

            for (int i = 0, length = pickRandomEffect.energies.Length; i < length; i++)
            {
                sphereImages[i].color = EnergyUtility.GetEnergyColor(pickRandomEffect.energies[i]);
            }
            sphereImages[1].gameObject.SetActive(pickRandomEffect.energies.Length > 1);
        }
    }
}
