using UnityEngine;

namespace Gizmos
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] SphereManager energySphereManager;

        #region Config
        public const int usableLevel3GizmoCount = 16;
        public const int startingGizmoGizmoCount = 4;

        public const int victoryPointTokenWorth1Count = 14;
        public const int victoryPointTokenWorth5Count = 6;
        #endregion

        public static void CheckGameEnd()
        {
            // TODO
        }
    }
}
