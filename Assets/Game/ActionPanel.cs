using UnityEngine;
using UnityEngine.UI;

namespace Gizmos
{
    public class ActionPanel : MonoBehaviour
    {
        [SerializeField] Button endTurnButton;

        [SerializeField] GameManager gameManager;
        [SerializeField] TurnManager turnManager;

        void Awake()
        {
            endTurnButton.onClick.AddListener(EndTurn);
        }
        void OnDestroy()
        {
            endTurnButton.onClick.RemoveListener(EndTurn);
        }

        void EndTurn()
        {
            Player.CurrentPlayerEndTurn();
            GameManager.CheckGameEnd();
            TurnManager.NextPlayerStartTurn();
        }
    }
}
