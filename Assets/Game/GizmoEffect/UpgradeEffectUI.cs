using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using TMPro;

namespace Gizmos
{
    public class UpgradeEffectUI : MonoBehaviour, IGizmoEffectUI
    {
        [SerializeField] Image[] images;
        [SerializeField] TextMeshProUGUI[] texts;

        public void SetUI(GizmoEffect effect)
        {
            UpgradeEffect upgradeEffect = effect as UpgradeEffect;
            Assert.IsTrue(upgradeEffect != null);
            switch (upgradeEffect.type)
            {
                case UpgradeEffect.Type.StorageAdd1ResearchAdd1:
                    break;
                case UpgradeEffect.Type.StorageAdd1FileAdd1:
                    break;
            }
        }
    }
}
