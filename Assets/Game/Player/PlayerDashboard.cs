using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Gizmos
{
    public class PlayerDashboard : MonoBehaviour
    {
        public class EnergyInfo
        {
            public int green;
            public int blue;
            public int yellow;
            public int red;

            public int limit;

            public int Amount => green + blue + yellow + red;
        }

        public class FileInfo
        {
            public List<GizmoCard> filedCards = new List<GizmoCard>();

            public int limit;

            public int Amount => filedCards.Count;
        }

        public class EffectInfo
        {
            public List<GizmoEffect> effects = new List<GizmoEffect>();

            public int Amount => effects.Count;
        }

        public string playerName;

        public int score;
        public int star;

        public EnergyInfo energyInfo;
        public FileInfo fileInfo;

        public int researchAmount;

        [SerializeField] GameObject activeFrame;
        [SerializeField] TextMeshProUGUI nameText;
        [SerializeField] TextMeshProUGUI scoreText;
        [SerializeField] TextMeshProUGUI starText;
        [SerializeField] TextMeshProUGUI storageText;
        [SerializeField] TextMeshProUGUI fileText;
        [SerializeField] TextMeshProUGUI researchText;
        [SerializeField] TextMeshProUGUI gizmoText;

        [SerializeField] TextMeshProUGUI greenEnergyText;
        [SerializeField] TextMeshProUGUI blueEnergyText;
        [SerializeField] TextMeshProUGUI yellowEnergyText;
        [SerializeField] TextMeshProUGUI redEnergyText;
        [SerializeField] TextMeshProUGUI totalEnergyText;

        public static List<PlayerDashboard> list = new List<PlayerDashboard>();

        void Awake()
        {
            playerName = string.Format("Player {0}", list.Count.ToString());
            nameText.text = playerName;

            SetScore(0);
            SetStar(0);
            SetEngergyLimit(5);
            SetFileLimit(1);
            SetResearchAmount(3);

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
        void SetEngergyLimit(int number)
        {
            energyInfo.limit = number;
            storageText.text = string.Format("{0}/{1}", energyInfo.Amount, energyInfo.limit);
        }
        void SetFileLimit(int number)
        {
            fileInfo.limit = number;
            fileText.text = string.Format("{0}/{1}", fileInfo.Amount, fileInfo.limit);
        }
        void SetResearchAmount(int number)
        {
            researchAmount = number;
            researchText.text = researchAmount.ToString();
        }
    }
}
