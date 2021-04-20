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
        public static int NextPlayerIndex => (CurrentPlayerIndex + 1) % list.Count;

        List<PlayerAction> availableActions = new List<PlayerAction>();

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
            InitAvailableActions();
            ActionPanel.UpdateCardsAffordability(dashboard.energyStorage);
            EffectPanel.Instance.SetPanel(Dashboard.effectInfo);
        }
        void InitAvailableActions()
        {
            availableActions.Clear();
            if (dashboard.fileStorage.CanFile)
            {
                availableActions.Add(PlayerAction.File);
            }
            availableActions.Add(PlayerAction.Pick);
            availableActions.Add(PlayerAction.Build);
            availableActions.Add(PlayerAction.Research);
        }
        public void OnAct()
        {
            GetAvailableActions();
        }
        void GetAvailableActions()
        {
            availableActions.Clear();

            // TODO

            if (availableActions.Count == 0)
            {
                EndTurn();
                TurnManager.CurrentPlayerEndTurn();
            }
        }

        public void EndTurn()
        {
            // TODO
        }
    }
}
