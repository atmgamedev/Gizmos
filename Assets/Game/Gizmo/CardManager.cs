using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Gizmos
{
    public class CardManager : MonoBehaviour
    {
        [SerializeField] GizmoConfig gizmoConfig;
        [SerializeField] Card[] level1Cards;

        List<Gizmo> level1Gizmos;

        void Awake()
        {
            InitLevel1Gizmos();
            InitLevel1Cards();

            Card.OnGizmoCardFile += CurrentPlayerFile;
        }

        void OnDestroy() {
            Card.OnGizmoCardFile -= CurrentPlayerFile;
        }

        void InitLevel1Gizmos()
        {
            level1Gizmos = gizmoConfig.GetLevelGizmoList();
            MathUtility.RandomSequence(level1Gizmos);
        }
        void InitLevel1Cards()
        {
            for (int i = 0, length = level1Cards.Length; i < length; i++)
            {
                Gizmo gizmo = DrawGizmoOfLevel(1);
                level1Cards[i].SetGizmo(gizmo);
            }
        }

        /// <summary>
        /// 从发明堆补充一张发明到桌面
        /// </summary>
        Gizmo DrawGizmoOfLevel(int level)
        {
            // TODO: only support level1 now
            Assert.AreEqual(1, level);
            if (level1Gizmos.Count == 0)
            {
                return null;
            }
            Gizmo gizmo = level1Gizmos[0];
            level1Gizmos.RemoveAt(0);
            return gizmo;
        }

        void BuildGizmoCard(Card gizmoCard)
        {
            Gizmo gizmo = gizmoCard.Gizmo;
            Player.CurrentPlayer.Dashboard.CostEnergy(gizmo.costEnergy, gizmo.costAmount);
            Player.CurrentPlayer.Dashboard.AddScore(gizmo.score);
            Player.CurrentPlayer.Dashboard.UseBuildEffect(gizmo.costEnergy, gizmo.level);
            gizmoCard.Gizmo.AddEffectToCurrentPlayer();
        }

        void FillGizmoCardAt(int index, int level)
        {
            // TODO: only support level1 now
            Assert.AreEqual(1, level);
            Gizmo gizmo = DrawGizmoOfLevel(1);
            if (gizmo == null)
            {
                level1Cards[index].SetGizmo(null);
                return;
            }
            level1Cards[index].SetGizmo(gizmo);
        }

        public void CurrentPlayerBuild(int index, int level)
        {
            // TODO: only support level1 now
            Assert.AreEqual(1, level);
            BuildGizmoCard(level1Cards[index]);
            FillGizmoCardAt(index, level);
            Player.CurrentPlayer.OnAct();
        }

        void CurrentPlayerFile(int index, int level)
        {
            // TODO
            Player.CurrentPlayer.OnAct();
        }
    }
}
