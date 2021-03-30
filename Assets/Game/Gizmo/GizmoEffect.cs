using System;

namespace Gizmos
{
    public abstract class GizmoEffect { };

    [Serializable]
    public class FileRandomEffect : GizmoEffect { }

    [Serializable]
    public class PickRandomEffect : GizmoEffect
    {
        public Energy[] energies;
    };

    [Serializable]
    public class BuildPickEffect : GizmoEffect
    {
        public Energy[] energies;
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
