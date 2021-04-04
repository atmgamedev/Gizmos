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
                    ColorUtility.TryParseHtmlString("#52A845", out c);
                    break;
                case Energy.Blue:
                    ColorUtility.TryParseHtmlString("#0173BC", out c);
                    break;
                case Energy.Yellow:
                    ColorUtility.TryParseHtmlString("#FFDE17", out c);
                    break;
                case Energy.Red:
                    ColorUtility.TryParseHtmlString("#EB1C24", out c);
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
