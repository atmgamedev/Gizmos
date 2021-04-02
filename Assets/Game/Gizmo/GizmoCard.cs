using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Sirenix.OdinInspector;

namespace Gizmos
{
    public class GizmoCard : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI effectText;
        [SerializeField] TextMeshProUGUI requirementText;

        [SerializeField, ReadOnly] Image image;
        [SerializeField, ReadOnly] Button button;

        public Gizmo Gizmo { get; private set; }

        void OnValidate()
        {
            image = GetComponent<Image>();
            button = GetComponent<Button>();
        }

        public void SetGizmo(Gizmo gizmo)
        {
            Gizmo = gizmo;
            image.color = EnergyUtility.GetEnergyColor(gizmo.costEnergy);
            effectText.text = gizmo.GetEffectDescription();
            string colorText = EnergyUtility.GetEnergyColorText(gizmo.costEnergy);
            requirementText.text = string.Format("{0}球×{1}", colorText, gizmo.costAmount);
        }

        public void SetAffordablity(bool affordability)
        {
            button.interactable = affordability;
        }
    }
}
