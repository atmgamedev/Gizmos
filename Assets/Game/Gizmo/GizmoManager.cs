
using System.Collections.Generic;
using UnityEngine;

namespace Gizmos
{
    public class GizmoManager : MonoBehaviour
    {
        [SerializeField] GizmoConfig gizmoConfig;

        List<Gizmo> level1Gizmos;

        void Awake()
        {
            level1Gizmos = gizmoConfig.GetLevelGizmoList();
        }

        public Gizmo DrawLevel1Gizmo()
        {
            int r = Random.Range(0, level1Gizmos.Count);
            Gizmo gizmo = level1Gizmos[r];
            level1Gizmos.RemoveAt(r);
            return gizmo;
        }
    }
}
