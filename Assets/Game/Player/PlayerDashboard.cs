using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using TMPro;
using Sirenix.OdinInspector;

namespace Gizmos
{
    public class PlayerDashboard : MonoBehaviour
    {
        public string PlayerName { get; private set; }
        [SerializeField] TextMeshProUGUI nameText;

        public int Score { get; private set; }
        [SerializeField] TextMeshProUGUI scoreText;

        public int Star { get; private set; }
        [SerializeField] TextMeshProUGUI starText;

        #region Energy
        public class EnergyStorage
        {
            Dictionary<Energy, int> dict = new Dictionary<Energy, int>
            {
                { Energy.Green, 0 },
                { Energy.Blue, 0 },
                { Energy.Yellow, 0 },
                { Energy.Red, 0 },
            };

            public int this[Energy energy]
            {
                get => dict[energy];
                set => dict[energy] = value;
            }

            public int limit;

            public int Amount => dict[Energy.Green] + dict[Energy.Blue] + dict[Energy.Yellow] + dict[Energy.Red];
            public bool Overflow => Amount > limit;

            public string StorageText => string.Format("{0}/{1}", Amount, limit);
        }
        public EnergyStorage energyStorage = new EnergyStorage();

        [Serializable]
        class EnergyUI
        {
            [SerializeField] Energy energy;
            public Energy Energy => energy;
            [SerializeField] TextMeshProUGUI amountText;
            public TextMeshProUGUI AmountText => amountText;
        }
        [SerializeField, TableList] EnergyUI[] energyUIs;
        Dictionary<Energy, TextMeshProUGUI> energyUIDict = new Dictionary<Energy, TextMeshProUGUI>();
        [SerializeField] TextMeshProUGUI energyStorageText;
        #endregion

        #region File
        public class FileStorage
        {
            public List<GizmoCard> filedCards = new List<GizmoCard>();

            public int limit;

            public int Amount => filedCards.Count;
            public bool CanFile => Amount < limit;

            public string FileText => string.Format("{0}/{1}", Amount, limit);
        }
        public FileStorage fileStorage = new FileStorage();

        [SerializeField] TextMeshProUGUI fileText;
        #endregion

        #region Effect
        public class EffectInfo
        {
            public List<GizmoEffect> effects = new List<GizmoEffect>();
            public int limit = 16; // TODO: should load from config

            public int Amount => effects.Count;
            public string EffectText => string.Format("{0}/{1}", Amount, limit);
        }
        public EffectInfo effectInfo = new EffectInfo();
        #endregion

        public int ResearchAmount { get; private set; }

        public GameObject activeFrame;

        [SerializeField] TextMeshProUGUI researchText;
        [SerializeField] TextMeshProUGUI gizmoText;

        void Awake()
        {
            for (int i = 0, length = energyUIs.Length; i < length; i++)
            {
                var e = energyUIs[i];
                energyUIDict.Add(e.Energy, e.AmountText);
            }

            SetScore(0);
            SetStar(0);
            SetEnergy(Energy.Green, 0);
            SetEnergy(Energy.Blue, 0);
            SetEnergy(Energy.Yellow, 0);
            SetEnergy(Energy.Red, 0);
            SetEnergyLimit(5);
            SetFileLimit(1);
            SetResearchAmount(3);
            ResetEffect();
        }

        public void SetPlayerName(string playerName)
        {
            this.PlayerName = playerName;
            nameText.text = playerName;
        }
        public void AddScore(int number)
        {
            SetScore(Score + number);
        }
        void SetScore(int number)
        {
            Score = number;
            scoreText.text = Score.ToString();
        }
        public void AddStar(int number)
        {
            SetStar(Star + number);
        }
        void SetStar(int number)
        {
            Star = number;
            scoreText.text = Star.ToString();
        }

        public void AddEnergy(Energy energy)
        {
            SetEnergy(energy, energyStorage[energy] + 1);
        }
        public void CostEnergy(Energy energy, int number)
        {
            SetEnergy(energy, energyStorage[energy] - number);
        }
        void SetEnergy(Energy energy, int number)
        {
            Assert.IsTrue(number >= 0);
            energyUIDict[energy].text = number.ToString();
            energyStorage[energy] = number;
            UpdateStorageText();
        }
        public void AddEnergyLimit(int number)
        {
            SetEnergyLimit(energyStorage.limit + number);
        }
        void SetEnergyLimit(int number)
        {
            energyStorage.limit = number;
            UpdateStorageText();
        }
        void UpdateStorageText() {
            energyStorageText.text = energyStorage.StorageText;
            energyStorageText.color = energyStorage.Overflow ? Color.red : Color.black;
        }
        public void AddFile(GizmoCard card)
        {
            Assert.IsTrue(fileStorage.CanFile);
            fileStorage.filedCards.Add(card);
        }
        public void BuildFromFile(GizmoCard card)
        {
            Assert.IsNotNull(fileStorage.filedCards);
            Assert.IsNotNull(fileStorage.filedCards.Find(filedCard => filedCard == card));
            fileStorage.filedCards.Remove(card);
            fileText.text = fileStorage.FileText;
        }
        public void AddFileLimit(int number)
        {
            SetFileLimit(fileStorage.limit + number);
        }
        void SetFileLimit(int number)
        {
            fileStorage.limit = number;
            fileText.text = fileStorage.FileText;
        }
        public void AddResearchAmount(int number)
        {
            SetResearchAmount(ResearchAmount + number);
        }
        void SetResearchAmount(int number)
        {
            ResearchAmount = number;
            researchText.text = ResearchAmount.ToString();
        }
        public void AddEffect(GizmoEffect effect)
        {
            effectInfo.effects.Add(effect);
            gizmoText.text = effectInfo.EffectText;
        }
        void ResetEffect()
        {
            effectInfo.effects = new List<GizmoEffect>();
            gizmoText.text = effectInfo.EffectText;
        }
    }
}
