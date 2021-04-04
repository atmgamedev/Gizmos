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
        [SerializeField] Image costImage;
        [SerializeField] TextMeshProUGUI costText;

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
            Color c = EnergyUtility.GetEnergyColor(gizmo.costEnergy);
            // image.color = c;
            effectText.text = gizmo.GetEffectDescription();
            costImage.color = c;
            costText.text = gizmo.costAmount.ToString();
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
