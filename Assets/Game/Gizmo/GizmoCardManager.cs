
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
            level1Gizmos = gizmoConfig.GetLevelGizmoList();
        }

        void Start()
        {
            InitLevel1Cards();
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
            int r = Random.Range(0, level1Gizmos.Count);
            Gizmo gizmo = level1Gizmos[r];
            level1Gizmos.RemoveAt(r);
            return gizmo;
        }
    }
}
