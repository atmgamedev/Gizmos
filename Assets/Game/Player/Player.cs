using System.Collections.Generic;
using UnityEngine;

namespace Gizmos
{
    public class Player : MonoBehaviour
    {
        [SerializeField] PlayerDashboard dashboard;
        public PlayerDashboard Dashboard => dashboard;

        public static List<Player> list = new List<Player>();
        public static int CurrentPlayerIndex { get; private set; }
        public static Player CurrentPlayer => list[CurrentPlayerIndex];
        public static int NextPlayerIndex => (CurrentPlayerIndex + 1) & list.Count;

        void Awake()
        {
            list.Add(this);
            dashboard.SetPlayerName(list.Count.ToString());
        }

        void SetInTurn(bool isInTurn)
        {
            dashboard.activeFrame.SetActive(isInTurn);
        }

        public static void StartTurn(int playerIndex)
        {
            for (int i = 0, length = list.Count; i < length; i++)
            {
                var player = list[i];
                player.SetInTurn(playerIndex == i);
            }
            CurrentPlayerIndex = playerIndex;
            list[playerIndex].StartTurn();
        }
        void StartTurn()
        {
            GetAvailableActions();
        }
        void GetAvailableActions()
        {
            var actions = new List<PlayerAction>();
            if (dashboard.fileInfo.CanFile)
            {
                actions.Add(PlayerAction.File);
            }
            actions.Add(PlayerAction.Pick);
            actions.Add(PlayerAction.Build);
            actions.Add(PlayerAction.Research);

            if (actions.Count == 0)
            {
                EndTurn();
            }
        }
        void OnPlayerAct()
        {
            // TODO

        }

        public static void CurrentPlayerEndTurn()
        {
            // TODO
        }
        void EndTurn()
        {
            // TODO
        }
    }
}
