using UnityEngine;

namespace Gizmos
{
    /// <summary>
    /// ±¬Öé
    /// </summary>
    public enum Energy
    {
        Green,
        Blue,
        Yellow,
        Red
    }

    public static class EnergyUtility
    {
        public static Color GetEnergyColor(Energy energy)
        {
            Color c;
            switch (energy)
            {
                case Energy.Green:
                    c = Color.green;
                    break;
                case Energy.Blue:
                    c = Color.blue;
                    break;
                case Energy.Yellow:
                    c = Color.yellow;
                    break;
                case Energy.Red:
                    c = Color.red;
                    break;
                default:
                    throw new System.Exception();
            }
            return c;
        }

        public static string GetEnergyColorText(Energy energy)
        {
            string t;
            switch (energy)
            {   
                case Energy.Green:
                    t = "ÂÌ";
                    break;
                case Energy.Blue:
                    t = "À¶";
                    break;
                case Energy.Yellow:
                    t = "»Æ";
                    break;
                case Energy.Red:
                    t = "ºì";
                    break;
                default:
                    throw new System.Exception();
            }
            return t;
        }
    }
}
