using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gizmos
{
    public class EnergySphereManager : MonoBehaviour
    {
        [SerializeField] Image[] sphereImages;

        const int eachTypeSphereCount = 13;
        const int displaySphereCount = 6;

        List<Energy> hiddenSpheres;
        public List<Energy> DisplaySpheres { get; private set; }

        void Awake()
        {
            InitHiddenSpheres();
            InitDisplaySpheres();
        }

        void Start()
        {
            UpdateUI();
        }

        void InitHiddenSpheres()
        {
            int typeAmount = 4;
            int sphereAmount = typeAmount * eachTypeSphereCount;
            Energy[] spheres = new Energy[sphereAmount];
            for (int i = 0; i < typeAmount; i++)
            {
                for (int j = 0; j < eachTypeSphereCount; j++)
                {
                    spheres[i * eachTypeSphereCount + j] = (Energy)i;
                }
            }
            hiddenSpheres = new List<Energy>(sphereAmount);
            int[] indexes = MathUtility.FisherYatesShuffle(sphereAmount, sphereAmount);
            for (int i = 0; i < sphereAmount; i++)
            {
                hiddenSpheres.Add(spheres[indexes[i]]);
            }
        }

        void InitDisplaySpheres()
        {
            DisplaySpheres = new List<Energy>();
            for (int i = 0; i < displaySphereCount; i++)
            {
                SlideOutOne();
            }
        }

        void SlideOutOne()
        {
            int i = Random.Range(0, hiddenSpheres.Count);
            Energy energy = hiddenSpheres[i];
            DisplaySpheres.Add(energy);
            hiddenSpheres.RemoveAt(i);
        }

        void UpdateUI()
        {
            for (int i = 0, length = DisplaySpheres.Count; i < length; i++)
            {
                sphereImages[i].color = EnergyUtility.GetEnergyColor(DisplaySpheres[i]);
            }
        }
    }
}
