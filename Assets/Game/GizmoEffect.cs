using System;
using Sirenix.OdinInspector;

namespace Gizmos
{
    [Serializable]
    public class GizmoEffect
    {

    };

    [Serializable]
    public class FileRandom : GizmoEffect { }

    [Serializable]
    public class PickRandom : GizmoEffect
    {
        public Energy[] energies;
    };

    [Serializable]
    public class BuildPick : GizmoEffect
    {
        public Energy[] energies;
    }

    [Serializable]
    public class BuildStar : GizmoEffect
    {
        public Energy[] energies;
    }

    [Serializable]
    public class Converter : GizmoEffect
    {
        public Energy[] energies;
    }

    [Serializable]
    public class Duplicator : GizmoEffect
    {
        public Energy[] energies;
    }

    [Serializable]
    public class Upgrade : GizmoEffect
    {
        public enum Type
        {
            StorageAdd1ResearchAdd1,
            StorageAdd1FileAdd1,
        }

        public Type type;
    }
}
