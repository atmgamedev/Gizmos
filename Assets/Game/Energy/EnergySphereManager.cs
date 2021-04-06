using System.Collections.Generic;
using UnityEngine;

namespace Gizmos
{
    public class EnergySphereManager : MonoBehaviour
    {
        [SerializeField] EnergySphere[] spheres;

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
            UpdateDisplaySpheresUI();
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
            MathUtility.RandomSequence(spheres);
            for (int i = 0; i < sphereAmount; i++)
            {
                hiddenSpheres.Add(spheres[i]);
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
            if (hiddenSpheres.Count <= 0)
            {
                return;
            }
            Energy energy = hiddenSpheres[0];
            DisplaySpheres.Add(energy);
            hiddenSpheres.RemoveAt(0);
        }

        public void CurrentPlayerPick(int index)
        {
            Energy e = DisplaySpheres[index];
            DisplaySpheres.RemoveAt(index);
            SlideOutOne();
            UpdateDisplaySpheresUI();
            DisableInteraction();
            Player.CurrentPlayer.Dashboard.AddEnergy(e);
            Player.CurrentPlayer.OnAct();
        }

        void UpdateDisplaySpheresUI()
        {
            for (int i = 0, length = DisplaySpheres.Count; i < length; i++)
            {
                spheres[i].SetEnergy(DisplaySpheres[i]);
            }
        }

        void DisableInteraction()
        {
            // TODO
        }
    }
}
