using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Gizmos
{
    [CreateAssetMenu(fileName = "GizmoConfig", menuName = "Game/GizmoConfig")]
    public class GizmoConfig : ScriptableObject
    {
        [SerializeField, TableList] FileRandomGizmo[] level1FileRandomGizmos;

        [Button] void GenerateLevel1Gizmos()
        {
            List<Gizmo> gizmos = new List<Gizmo>();

            for (int i = 0; i < 4; i++)
            {
                var gizmo = new FileRandomGizmo
                {
                    costEnergy = (Energy)i,
                    costAmount = 1,
                    effect = new FileRandomEffect()
                };
                gizmos.Add(gizmo);
            }
            for (int i = 0; i < 8; i++)
            {
                var gizmo = new PickRandomGizmo
                {
                    costEnergy = (Energy)(i / 2),
                    costAmount = 1,
                    effect = new PickRandomEffect()
                };
                gizmos.Add(gizmo);
            }
            for (int i = 0; i < 4; i++)
            {
                var gizmo = new BuildPickGizmo
                {
                    costEnergy = (Energy)i,
                    costAmount = 1,
                    effect = new BuildPickEffect()
                };
                gizmos.Add(gizmo);
            }
            for (int i = 0; i < 4; i++)
            {
                var gizmo = new BuildStarGizmo
                {
                    costEnergy = (Energy)i,
                    costAmount = 1,
                    effect = new BuildStarEffect()
                };
                gizmos.Add(gizmo);
            }
            for (int i = 0; i < 8; i++)
            {
                var gizmo = new ConverterGizmo
                {
                    costEnergy = (Energy)(i / 2),
                    costAmount = 1,
                    effect = new ConverterEffect()
                };
                gizmos.Add(gizmo);
            }
            for (int i = 0; i < 4; i++)
            {
                var gizmo = new UpgradeGizmo
                {
                    costEnergy = (Energy)i,
                    costAmount = 1,
                    effect = new UpgradeEffect
                    {
                        type = UpgradeEffect.Type.StorageAdd1FileAdd1
                    }
                };
                gizmos.Add(gizmo);
            }
            for (int i = 0; i < 4; i++)
            {
                var gizmo = new UpgradeGizmo
                {
                    costEnergy = (Energy)i,
                    costAmount = 1,
                    effect = new UpgradeEffect
                    {
                        type = UpgradeEffect.Type.StorageAdd1FileAdd1
                    }
                };
                gizmos.Add(gizmo);
            }
        }
    }
}
