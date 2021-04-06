using System;
using UnityEngine;

namespace Gizmos
{
    public abstract class GizmoEffect
    {
        public virtual GameObject GetUI(){ return null; }
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
            var ui = GameObject.Instantiate(uiPrefab);
            for (int i = 0, length = energies.Length; i < length; i++)
            {
                ui.SphereImages[i].color = EnergyUtility.GetEnergyColor(energies[i]);
            }
            ui.SphereImages[1].gameObject.SetActive(energies.Length > 1);
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
            var ui = GameObject.Instantiate(uiPrefab);
            for (int i = 0, length = energies.Length; i < length; i++)
            {
                ui.CardImages[i].color = EnergyUtility.GetEnergyColor(energies[i]);
            }
            ui.CardImages[1].gameObject.SetActive(energies.Length > 1);
            return ui.gameObject;
        }
    }

    [Serializable]
    public class BuildStarEffect : GizmoEffect
    {
        public Energy[] energies;
    }

    [Serializable]
    public class ConverterEffect : GizmoEffect
    {
        public Energy[] energies;
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
    }
}
