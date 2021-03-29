using UnityEngine;
using TMPro;
using Sirenix.OdinInspector;

namespace Gizmos
{
    public class TurnManager : MonoBehaviour
    {
        public int turn;
        [SerializeField] TextMeshProUGUI turnText;
        public int currentPlayerIndex;

        void Start()
        {
            SetTurn(0);
            ActivePlayer(currentPlayerIndex);
        }

        public void FinishTurn()
        {
            NextPlayer();
        }

        void NextPlayer()
        {
            currentPlayerIndex = (currentPlayerIndex + 1) % PlayerDashboard.list.Count;
            if (currentPlayerIndex == 0)
            {
                SetTurn(turn + 1);
            }
            ActivePlayer(currentPlayerIndex);
        }

        void ActivePlayer(int playerIndex)
        {

            for (int i = 0, length = PlayerDashboard.list.Count; i < length; i++)
            {
                var player = PlayerDashboard.list[i];
                player.activeFrame.SetActive(currentPlayerIndex == i);
            }
        }

        void SetTurn(int number)
        {
            turn = number;
            turnText.text = string.Format("µÚ{0}»ØºÏ", turn + 1);
        }
    }
}
