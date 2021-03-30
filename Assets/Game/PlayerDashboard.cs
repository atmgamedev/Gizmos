using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Gizmos
{
    public class PlayerDashboard : MonoBehaviour
    {
        public string playerName;

        public int score;
        public int star;

        public int storageAmount;
        public int storageLimit;
        public int fileAmount;
        public int fileLimit;
        public int researchAmount;
        public int gizmoAmount;

        public GameObject activeFrame;
        public TextMeshProUGUI nameText;
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI starText;
        public TextMeshProUGUI storageText;
        public TextMeshProUGUI fileText;
        public TextMeshProUGUI researchText;
        public TextMeshProUGUI gizmoText;

        public static List<PlayerDashboard> list = new List<PlayerDashboard>();

        void Awake()
        {
            playerName = string.Format("Player {0}", list.Count.ToString());
            nameText.text = playerName;

            SetScore(0);
            SetStar(0);
            SetStorageLimit(5);
            SetFileLimit(1);
            SetResearchAmount(3);
            SetGizmoAmount(1);

            list.Add(this);
        }

        void SetScore(int number)
        {
            score = number;
            scoreText.text = score.ToString();
        }
        void SetStar(int number)
        {
            star = number;
            scoreText.text = star.ToString();
        }
        void SetStorageLimit(int number)
        {
            storageLimit = number;
            storageText.text = string.Format("{0}/{1}", storageAmount, storageLimit);
        }
        void SetFileLimit(int number)
        {
            fileLimit = number;
            fileText.text = string.Format("{0}/{1}", fileAmount, fileLimit);
        }
        void SetResearchAmount(int number)
        {
            researchAmount = number;
            researchText.text = researchAmount.ToString();
        }
        void SetGizmoAmount(int number)
        {
            gizmoAmount = number;
            gizmoText.text = string.Format("{0}/16", gizmoAmount, fileLimit);
        }
    }
}
