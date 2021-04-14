using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

namespace Gizmos
{
    public class BuildStarEffectUI : GizmoEffectUI
    {
        [SerializeField] Image[] cardImages;

        public override void SetUI(GizmoEffect effect)
        {
            BuildStarEffect buildStarEffect = effect as BuildStarEffect;
            Assert.IsTrue(buildStarEffect != null);

            for (int i = 0, length = buildStarEffect.energies.Length; i < length; i++)
            {
                cardImages[i].color = EnergyUtility.GetEnergyColor(buildStarEffect.energies[i]);
            }
            cardImages[1].gameObject.SetActive(buildStarEffect.energies.Length > 1);
        }
    }
}
