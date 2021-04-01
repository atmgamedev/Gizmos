using System.Collections;
using UnityEngine;
using TMPro;

namespace Gizmos
{
    public class TurnManager : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI turnText;
        int turn;

        static TurnManager instance;

        void Awake()
        {
            instance = this;
        }
        void Start()
        {
            SetTurn(0);
            PlayerStartTurn(Player.CurrentPlayerIndex);
        }

        public static void NextPlayerStartTurn()
        {
            int nextPlayerIndex = Player.NextPlayerIndex;
            if (nextPlayerIndex == 0)
            {
                instance.IncreaseTurn();
            }
            PlayerStartTurn(nextPlayerIndex);
        }

        static void PlayerStartTurn(int playerIndex)
        {
            Player.StartTurn(playerIndex);
        }

        void SetTurn(int number)
        {
            turn = number;
            turnText.text = string.Format("第{0}回合", turn + 1);
        }
        void IncreaseTurn()
        {
            SetTurn(turn + 1);
        }
    }
}
