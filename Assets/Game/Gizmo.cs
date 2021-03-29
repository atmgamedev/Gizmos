using System;
using UnityEngine;

namespace Gizmos
{
    [Serializable]
    public class Gizmo
    {
        public Energy costEnergy;
        public int costAmount;
        public GizmoEffect effect;

        #region Config
        public const int displayLevel1GizmoCount = 4;
        public const int displayLevel2GizmoCount = 3;
        public const int displayLevel3GizmoCount = 2;

        public const int usableLevel3GizmoCount = 16;
        public const int startingGizmoGizmoCount = 4;

        public const int eachTypeEnergySphereCount = 13;
        public const int displayEnergySphereCount = 6;

        public const int victoryPointTokenWorth1Count = 14;
        public const int victoryPointTokenWorth5Count = 6;
        #endregion
    }
}
