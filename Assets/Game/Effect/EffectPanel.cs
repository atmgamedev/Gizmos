using UnityEngine;

namespace Gizmos
{
    public class EffectPanel : MonoBehaviour
    {
        public static EffectPanel Instance { get; private set; }

        void Awake()
        {
            Instance = this;
        }

        public void SetPanel(PlayerDashboard.EffectInfo effectInfo)
        {
            transform.DetachChildren();
            for (int i = 0, length = effectInfo.effects.Count; i < length; i++)
            {
                var effect = effectInfo.effects[i];
                var ui = effect.InstantiateUI();
                ui.transform.SetParent(transform);
                ui.transform.localScale = Vector3.one;
            }
        }
    }
}
