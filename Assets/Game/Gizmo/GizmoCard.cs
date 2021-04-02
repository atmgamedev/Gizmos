using System;
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

        public static event Action<int, int> OnGizmoCardBuild = delegate { };
        public static event Action<int, int> OnGizmoCardFile = delegate { };

        void OnValidate()
        {
            image = GetComponent<Image>();
            button = GetComponent<Button>();

            button.onClick.AddListener(OnClick);
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

        void OnClick()
        {
            int index = transform.GetSiblingIndex();
            // TODO: check if it is a build action or a file action
            OnGizmoCardBuild(index, Gizmo.level);
        }
    }
}
