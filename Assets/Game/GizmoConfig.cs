using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gizmos
{
    [CreateAssetMenu(fileName = "GizmoConfig", menuName = "Game/GizmoConfig")]
    public class GizmoConfig : ScriptableObject
    {
        [SerializeField] Level1GizmoConfig level1GizmoConfig;

        public List<Gizmo> GetLevelGizmoList()
        {
            return level1GizmoConfig.GetGizmoList();
        }

        [Serializable]
        public class Level1GizmoConfig
        {
            [SerializeField, TableList] FileRandomGizmo[] fileRandomGizmos;
            [SerializeField, TableList] PickRandomGizmo[] pickRandomGizmos;
            [SerializeField, TableList] BuildPickGizmo[] buildPickGizmos;
            [SerializeField, TableList] BuildStarGizmo[] buildStarGizmos;
            [SerializeField, TableList] ConverterGizmo[] converterGizmos;
            [SerializeField, TableList] UpgradeGizmo[] upgradeGizmos;

            [Button]
            void InitializeGizmos()
            {
                fileRandomGizmos = new FileRandomGizmo[4];
                pickRandomGizmos = new PickRandomGizmo[8];
                buildPickGizmos = new BuildPickGizmo[4];
                buildStarGizmos = new BuildStarGizmo[4];
                converterGizmos = new ConverterGizmo[8];
                upgradeGizmos = new UpgradeGizmo[8];
            }

            public List<Gizmo> GetGizmoList()
            {
                var gizmos = new List<Gizmo>();
                for (int i = 0, length = fileRandomGizmos.Length; i < length; i++)
                {
                    gizmos.Add(fileRandomGizmos[i]);
                }
                for (int i = 0, length = pickRandomGizmos.Length; i < length; i++)
                {
                    gizmos.Add(pickRandomGizmos[i]);
                }
                for (int i = 0, length = buildPickGizmos.Length; i < length; i++)
                {
                    gizmos.Add(buildPickGizmos[i]);
                }
                for (int i = 0, length = buildStarGizmos.Length; i < length; i++)
                {
                    gizmos.Add(buildStarGizmos[i]);
                }
                for (int i = 0, length = converterGizmos.Length; i < length; i++)
                {
                    gizmos.Add(converterGizmos[i]);
                }
                for (int i = 0, length = upgradeGizmos.Length; i < length; i++)
                {
                    gizmos.Add(upgradeGizmos[i]);
                }
                return gizmos;
            }
        }
    }
}
