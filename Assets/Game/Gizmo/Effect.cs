using System;
using UnityEngine;

namespace Gizmos
{
    public abstract class Effect
    {
        public EffectUI uiPrefab;
        public virtual int GetStar() { return 0; }
        public virtual bool TakeEffect(Energy energy) { return false; }

        public GameObject InstantiateUI()
        {
            var ui = UnityEngine.Object.Instantiate(uiPrefab);
            ui.SetUI(this);
            return ui.gameObject;
        }
    };

    [Serializable]
    public class FileRandomEffect : Effect { }

    [Serializable]
    public class PickRandomEffect : Effect
    {
        public Energy[] energies;
    };

    [Serializable]
    public class BuildPickEffect : Effect
    {
        public Energy[] energies;
    }

    [Serializable]
    public class BuildStarEffect : Effect
    {
        public Energy[] energies;

        public int star;
        public override int GetStar() { return star; }
        public override bool TakeEffect(Energy energy) { return Array.IndexOf(energies, energy) > -1; }
    }

    [Serializable]
    public class ConverterEffect : Effect
    {
        public Energy[] energies;
    }

    [Serializable]
    public class DuplicatorEffect : Effect
    {
        public Energy[] energies;
    }

    [Serializable]
    public class UpgradeEffect : Effect
    {
        public enum Type
        {
            StorageAdd1ResearchAdd1,
            StorageAdd1FileAdd1,
        }

        public Type type;
    }
}
