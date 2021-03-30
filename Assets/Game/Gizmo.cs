using System;

namespace Gizmos
{
    public abstract class Gizmo
    {
        public Energy costEnergy;
        public int costAmount;

    }

    [Serializable]
    public class FileRandomGizmo : Gizmo
    {
        public FileRandomEffect effect;
    }

    [Serializable]
    public class PickRandomGizmo : Gizmo
    {
        public PickRandomEffect effect;
    }

    [Serializable]
    public class BuildPickGizmo : Gizmo
    {
        public BuildPickEffect effect;
    }

    [Serializable]
    public class BuildStarGizmo : Gizmo
    {
        public BuildStarEffect effect;
    }

    [Serializable]
    public class ConverterGizmo : Gizmo
    {
        public ConverterEffect effect;
    }

    [Serializable]
    public class DuplicatorGizmo : Gizmo
    {
        public DuplicatorEffect effect;
    }

    [Serializable]
    public class UpgradeGizmo : Gizmo
    {
        public UpgradeEffect effect;
    }
}
