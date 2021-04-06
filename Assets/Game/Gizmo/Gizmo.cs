using System;
using System.Text;
using UnityEngine;
using UnityEngine.Assertions;

namespace Gizmos
{
    public abstract class Gizmo
    {
        public Energy costEnergy;
        public int costAmount;
        public int level;
        public int score;
        public abstract void AddEffectToCurrentPlayer();
        public abstract string GetEffectDescription();
        public virtual GameObject GetUI() { return null; }
    }

    [Serializable]
    public class FileRandomGizmo : Gizmo
    {
        [SerializeField] FileRandomEffect effect;
        public override void AddEffectToCurrentPlayer()
        {
            Player.CurrentPlayer.Dashboard.AddEffect(effect);
        }
        public override string GetEffectDescription()
        {
            return "存档后随机摸球";
        }
    }

    [Serializable]
    public class PickRandomGizmo : Gizmo
    {
        [SerializeField] PickRandomEffect effect;
        public override void AddEffectToCurrentPlayer()
        {
            Player.CurrentPlayer.Dashboard.AddEffect(effect);
        }
        public override string GetEffectDescription()
        {
            Assert.IsTrue(effect.energies.Length > 0);
            string[] colorTexts = new string[effect.energies.Length];
            for (int i = 0, length = colorTexts.Length; i < length; i++)
            {
                colorTexts[i] = EnergyUtility.GetEnergyColorText(effect.energies[i]);
            }
            var sb = new StringBuilder();
            sb.AppendFormat("摸{0}球", colorTexts[0]);
            for (int i = 1, length = colorTexts.Length; i < length; i++)
            {
                sb.AppendFormat("或{0}球", colorTexts[0]);
            }
            sb.Append("后随机摸球");
            return sb.ToString();
        }

        public override GameObject GetUI()
        {
            return effect.GetUI();
        }
    }

    [Serializable]
    public class BuildPickGizmo : Gizmo
    {
        [SerializeField] BuildPickEffect effect;
        public override void AddEffectToCurrentPlayer()
        {
            Player.CurrentPlayer.Dashboard.AddEffect(effect);
        }
        public override string GetEffectDescription()
        {
            Assert.IsTrue(effect.energies.Length > 0);
            string[] colorTexts = new string[effect.energies.Length];
            for (int i = 0, length = colorTexts.Length; i < length; i++)
            {
                colorTexts[i] = EnergyUtility.GetEnergyColorText(effect.energies[i]);
            }
            var sb = new StringBuilder();
            sb.AppendFormat("摸{0}卡", colorTexts[0]);
            for (int i = 1, length = colorTexts.Length; i < length; i++)
            {
                sb.AppendFormat("或{0}卡", colorTexts[0]);
            }
            sb.Append("后摸球");
            return sb.ToString();
        }

        public override GameObject GetUI()
        {
            return effect.GetUI();
        }
    }

    [Serializable]
    public class BuildStarGizmo : Gizmo
    {
        [SerializeField] BuildStarEffect effect;
        public override void AddEffectToCurrentPlayer()
        {
            Player.CurrentPlayer.Dashboard.AddEffect(effect);
        }
        public override string GetEffectDescription()
        {
            Assert.IsTrue(effect.energies.Length > 0);
            string[] colorTexts = new string[effect.energies.Length];
            for (int i = 0, length = colorTexts.Length; i < length; i++)
            {
                colorTexts[i] = EnergyUtility.GetEnergyColorText(effect.energies[i]);
            }
            var sb = new StringBuilder();
            sb.AppendFormat("摸{0}卡", colorTexts[0]);
            for (int i = 1, length = colorTexts.Length; i < length; i++)
            {
                sb.AppendFormat("或{0}卡", colorTexts[0]);
            }
            sb.Append("后得1星");
            return sb.ToString();
        }
    }

    [Serializable]
    public class ConverterGizmo : Gizmo
    {
        [SerializeField] ConverterEffect effect;
        public override void AddEffectToCurrentPlayer()
        {
            Player.CurrentPlayer.Dashboard.AddEffect(effect);
        }
        public override string GetEffectDescription()
        {
            Assert.IsTrue(effect.energies.Length > 0);
            string[] colorTexts = new string[effect.energies.Length];
            for (int i = 0, length = colorTexts.Length; i < length; i++)
            {
                colorTexts[i] = EnergyUtility.GetEnergyColorText(effect.energies[i]);
            }
            var sb = new StringBuilder();
            sb.AppendFormat("将{0}球", colorTexts[0]);
            for (int i = 1, length = colorTexts.Length; i < length; i++)
            {
                sb.AppendFormat("或{0}球", colorTexts[0]);
            }
            sb.Append("转换成任意颜色");
            return sb.ToString();
        }
    }

    [Serializable]
    public class DuplicatorGizmo : Gizmo
    {
        [SerializeField] DuplicatorEffect effect;
        public override void AddEffectToCurrentPlayer()
        {
            Player.CurrentPlayer.Dashboard.AddEffect(effect);
        }
        public override string GetEffectDescription()
        {
            Assert.IsTrue(effect.energies.Length > 0);
            string[] colorTexts = new string[effect.energies.Length];
            for (int i = 0, length = colorTexts.Length; i < length; i++)
            {
                colorTexts[i] = EnergyUtility.GetEnergyColorText(effect.energies[i]);
            }
            var sb = new StringBuilder();
            sb.AppendFormat("将{0}球", colorTexts[0]);
            for (int i = 1, length = colorTexts.Length; i < length; i++)
            {
                sb.AppendFormat("或{0}球", colorTexts[0]);
            }
            sb.Append("分裂成2个");
            return sb.ToString();
        }
    }

    [Serializable]
    public class UpgradeGizmo : Gizmo
    {
        [SerializeField] UpgradeEffect effect;
        public override void AddEffectToCurrentPlayer()
        {
            switch (effect.type)
            {
                case UpgradeEffect.Type.StorageAdd1ResearchAdd1:
                    Player.CurrentPlayer.Dashboard.AddEnergyLimit(1);
                    Player.CurrentPlayer.Dashboard.AddResearchAmount(1);
                    break;
                case UpgradeEffect.Type.StorageAdd1FileAdd1:
                    Player.CurrentPlayer.Dashboard.AddEnergyLimit(1);
                    Player.CurrentPlayer.Dashboard.AddFileLimit(1);
                    break;
            }
        }
        public override string GetEffectDescription()
        {
            string desc = "";
            switch (effect.type)
            {
                case UpgradeEffect.Type.StorageAdd1ResearchAdd1:
                    desc = "球上限和研究+1";
                    break;
                case UpgradeEffect.Type.StorageAdd1FileAdd1:
                    desc = "球上限和存档+1";
                    break;
            }
            return desc;
        }
    }
}
