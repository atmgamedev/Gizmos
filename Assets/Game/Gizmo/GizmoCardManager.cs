using System.Collections.Generic;
using UnityEngine;

namespace Gizmos
{
    public class GizmoCardManager : MonoBehaviour
    {
        [SerializeField] GizmoConfig gizmoConfig;
        [SerializeField] GizmoCard[] level1Cards;

        List<Gizmo> level1Gizmos;

        void Awake()
        {
            InitLevel1Gizmos();
            InitLevel1Cards();
        }

        void InitLevel1Gizmos()
        {
            level1Gizmos = gizmoConfig.GetLevelGizmoList();
            MathUtility.RandomSequence(level1Gizmos);
        }
        void InitLevel1Cards()
        {
            for (int i = 0, length = level1Cards.Length; i < length; i++)
            {
                Gizmo gizmo = DrawLevel1Gizmo();
                level1Cards[i].SetGizmo(gizmo);
            }
        }

        Gizmo DrawLevel1Gizmo()
        {
            if (level1Gizmos.Count == 0)
            {
                return null ;
            }
            Gizmo gizmo = level1Gizmos[0];
            level1Gizmos.RemoveAt(0);
            return gizmo;
        }
    }
}
