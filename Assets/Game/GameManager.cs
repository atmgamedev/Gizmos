using UnityEngine;

namespace Gizmos
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] GizmoManager gizmoManager;
        [SerializeField] GizmoCard[] level1Cards;

        #region Config

        public const int usableLevel3GizmoCount = 16;
        public const int startingGizmoGizmoCount = 4;

        public const int eachTypeEnergySphereCount = 13;
        public const int displayEnergySphereCount = 6;

        public const int victoryPointTokenWorth1Count = 14;
        public const int victoryPointTokenWorth5Count = 6;
        #endregion

        void Start()
        {
            for (int i = 0, length = level1Cards.Length; i < length; i++)
            {
                Gizmo gizmo = gizmoManager.DrawLevel1Gizmo();
                level1Cards[i].SetGizmo(gizmo);
            }
        }
    }
}
