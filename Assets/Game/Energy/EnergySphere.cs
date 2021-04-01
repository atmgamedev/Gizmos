using System;
using UnityEngine;
using UnityEngine.UI;

namespace Gizmos
{
    public class EnergySphere : MonoBehaviour
    {
        Image image;
        Button button;

        public Energy Energy { get; private set; }

        public static event Action<int> OnEnergySphereClick = delegate { };

        void Awake()
        {
            image = GetComponent<Image>();
            button = GetComponent<Button>();

            button.onClick.AddListener(OnClick);
        }

        public void SetEnergy(Energy energy)
        {
            Energy = energy;
            image.color = EnergyUtility.GetEnergyColor(energy);
        }

        void OnClick()
        {
            int index = transform.GetSiblingIndex();
            OnEnergySphereClick(index);
        }
    }
}
