using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gizmos
{
    public class EnergyManager : MonoBehaviour
    {
        [SerializeField] Image[] sphereImages;

        public const int eachTypeEnergyCount = 13;
        public const int displayEnergyCount = 6;

        List<Energy> hiddenEnergies;
        public List<Energy> DisplayEnergies { get; private set; }

        void Awake()
        {
            hiddenEnergies = new List<Energy>();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < eachTypeEnergyCount; j++)
                {
                    hiddenEnergies.Add((Energy)i);
                }
            }
        }

        void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            DisplayEnergies = new List<Energy>();
            for (int i = 0; i < displayEnergyCount; i++)
            {
                SlideOutOne();
            }
            UpdateUI();
        }

        void SlideOutOne()
        {
            int i = Random.Range(0, hiddenEnergies.Count);
            Energy energy = hiddenEnergies[i];
            DisplayEnergies.Add(energy);
            hiddenEnergies.RemoveAt(i);
        }

        void UpdateUI()
        {
            for (int i = 0, length = DisplayEnergies.Count; i < length; i++)
            {
                sphereImages[i].color = EnergyUtility.GetEnergyColor(DisplayEnergies[i]);
            }
        }
    }
}
