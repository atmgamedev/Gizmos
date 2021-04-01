using UnityEngine;

namespace Gizmos
{
    /// <summary>
    /// 爆珠
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
                    t = "绿";
                    break;
                case Energy.Blue:
                    t = "蓝";
                    break;
                case Energy.Yellow:
                    t = "黄";
                    break;
                case Energy.Red:
                    t = "红";
                    break;
                default:
                    throw new System.Exception();
            }
            return t;
        }
    }
}
