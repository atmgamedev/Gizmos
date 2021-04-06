using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Gizmos
{
    public class GizmoCard : MonoBehaviour
    {
        [SerializeField] GizmoCardManager manager;

        [SerializeField] TextMeshProUGUI effectText;
        [SerializeField] Image image;
        [SerializeField] TextMeshProUGUI costText;

        Button button;

        public Gizmo Gizmo { get; private set; }

        public static event Action<int, int> OnGizmoCardBuild = delegate { };
        public static event Action<int, int> OnGizmoCardFile = delegate { };

        void Awake()
        {
            button = GetComponent<Button>();

            button.onClick.AddListener(OnClick);
        }

        public void SetGizmo(Gizmo gizmo)
        {
            Gizmo = gizmo;
            Color c = EnergyUtility.GetEnergyColor(gizmo.costEnergy);
            effectText.text = gizmo.GetEffectDescription();
            image.color = c;
            costText.text = gizmo.costAmount.ToString();
            var ui = gizmo.GetUI();
            if (ui != null)
            {
                ui.transform.SetParent(effectText.transform);
                ui.transform.localPosition = Vector3.zero;
                effectText.enabled = false;
            }
        }

        public void SetAffordablity(bool affordability)
        {
            button.interactable = affordability;
        }

        void OnClick()
        {
            int index = transform.GetSiblingIndex();
            // TODO: check if it is a build action or a file action
            manager.CurrentPlayerBuild(index, Gizmo.level);
        }
    }
}
