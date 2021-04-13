using System;
using UnityEngine;

namespace Gizmos
{
    public abstract class GizmoEffect
    {
        public virtual GameObject GetUI(){ return null; }
        public virtual int GetStar() { return 0; }
        public virtual bool TakeEffect(Energy energy) { return false; }
    };

    [Serializable]
    public class FileRandomEffect : GizmoEffect { }

    [Serializable]
    public class PickRandomEffect : GizmoEffect
    {
        public Energy[] energies;
        public PickRandomEffectUI uiPrefab;

        public override GameObject GetUI()
        {
            var ui = UnityEngine.Object.Instantiate(uiPrefab);
            ui.SetUI(this);
            return ui.gameObject;
        }
    };

    [Serializable]
    public class BuildPickEffect : GizmoEffect
    {
        public Energy[] energies;
        public BuildPickEffectUI uiPrefab;

        public override GameObject GetUI()
        {
            var ui = UnityEngine.Object.Instantiate(uiPrefab);
            ui.SetUI(this);
            return ui.gameObject;
        }
    }

    [Serializable]
    public class BuildStarEffect : GizmoEffect
    {
        public Energy[] energies;

        public int star;
        public override int GetStar() { return star; }
        public override bool TakeEffect(Energy energy) { return Array.IndexOf(energies, energy) > -1; }

        public BuildStarEffectUI uiPrefab;

        public override GameObject GetUI()
        {
            var ui = UnityEngine.Object.Instantiate(uiPrefab);
            ui.SetUI(this);
            return ui.gameObject;
        }
    }

    [Serializable]
    public class ConverterEffect : GizmoEffect
    {
        public Energy[] energies;
        public ConverterEffectUI uiPrefab;

        public override GameObject GetUI()
        {
            var ui = UnityEngine.Object.Instantiate(uiPrefab);
            ui.SetUI(this);
            return ui.gameObject;
        }
    }

    [Serializable]
    public class DuplicatorEffect : GizmoEffect
    {
        public Energy[] energies;
    }

    [Serializable]
    public class UpgradeEffect : GizmoEffect
    {
        public enum Type
        {
            StorageAdd1ResearchAdd1,
            StorageAdd1FileAdd1,
        }

        public Type type;
        public ConverterEffectUI uiPrefab;

        public override GameObject GetUI()
        {
            var ui = UnityEngine.Object.Instantiate(uiPrefab);
            ui.SetUI(this);
            return ui.gameObject;
        }
    }
}
