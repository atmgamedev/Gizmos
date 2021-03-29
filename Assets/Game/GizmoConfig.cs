using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Gizmos
{
    [CreateAssetMenu(fileName = "GizmoConfig", menuName = "Game/GizmoConfig")]
    public class GizmoConfig : ScriptableObject
    {
        [SerializeField, TableList] Gizmo[] level1Gizmos;

        [Button] void GenerateLevel1Gizmos()
        {
            List<Gizmo> gizmos = new List<Gizmo>();

            for (int i = 0; i < 4; i++)
            {
                var gizmo = new Gizmo
                {
                    costEnergy = (Energy)i,
                    costAmount = 1,
                    effect = new FileRandom()
                };
                gizmos.Add(gizmo);
            }
            for (int i = 0; i < 8; i++)
            {
                var gizmo = new Gizmo
                {
                    costEnergy = (Energy)(i / 2),
                    costAmount = 1,
                    effect = new PickRandom()
                };
                gizmos.Add(gizmo);
            }
            for (int i = 0; i < 4; i++)
            {
                var gizmo = new Gizmo
                {
                    costEnergy = (Energy)i,
                    costAmount = 1,
                    effect = new BuildPick()
                };
                gizmos.Add(gizmo);
            }
            for (int i = 0; i < 4; i++)
            {
                var gizmo = new Gizmo
                {
                    costEnergy = (Energy)i,
                    costAmount = 1,
                    effect = new BuildStar()
                };
                gizmos.Add(gizmo);
            }
            for (int i = 0; i < 8; i++)
            {
                var gizmo = new Gizmo
                {
                    costEnergy = (Energy)(i / 2),
                    costAmount = 1,
                    effect = new Converter()
                };
                gizmos.Add(gizmo);
            }
            for (int i = 0; i < 4; i++)
            {
                var gizmo = new Gizmo
                {
                    costEnergy = (Energy)i,
                    costAmount = 1,
                    effect = new Upgrade
                    {
                        type = Upgrade.Type.StorageAdd1FileAdd1
                    }
                };
                gizmos.Add(gizmo);
            }
            for (int i = 0; i < 4; i++)
            {
                var gizmo = new Gizmo
                {
                    costEnergy = (Energy)i,
                    costAmount = 1,
                    effect = new Upgrade
                    {
                        type = Upgrade.Type.StorageAdd1FileAdd1
                    }
                };
                gizmos.Add(gizmo);
            }
            level1Gizmos = gizmos.ToArray();
        }
    }
}
