using UnityEngine;
using UnityEngine.UI;

namespace Gizmos
{
    public class ActionPanel : MonoBehaviour
    {
        [SerializeField] Button endTurnButton;
        [SerializeField] GizmoCard[] cards;

        static ActionPanel instance;

        void Awake()
        {
            instance = this;

            endTurnButton.onClick.AddListener(TurnManager.CurrentPlayerEndTurn);
        }
        void OnDestroy()
        {
            endTurnButton.onClick.RemoveListener(TurnManager.CurrentPlayerEndTurn);
        }

        public static void UpdateCardsAffordability(PlayerDashboard.EnergyStorage energyStorage)
        {
            for (int i = 0, length = instance.cards.Length; i < length; i++)
            {
                var card = instance.cards[i];
                var gizmo = card.Gizmo;
                card.SetAffordablity(energyStorage[gizmo.costEnergy] >= gizmo.costAmount);
            }
        }
    }
}
