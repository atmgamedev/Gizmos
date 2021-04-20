using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

namespace Gizmos
{
    public static class MathUtility
    {
        /// <summary>
        /// 抽奖。
        /// </summary>
        /// <param name="winRate">中奖概率</param>
        /// <returns>是否抽中</returns>
        public static bool Raffle(float winRate)
        {
            return Random.Range(0f, 1f) < winRate;
        }
        public static bool Raffle(int denominator, int numerator = 1)
        {
            Assert.IsTrue(denominator > 0 && numerator >= 0);
            return Random.Range(0, denominator) < numerator;
        }

        /// <summary>
        /// 从 0 到 n-1 中选取 pickCount 个数。
        /// </summary>
        public static int[] FisherYatesShuffle(int n, int pickCount)
        {
            Assert.IsTrue(n > 0 && pickCount > 0 && pickCount <= n);
            int[] indexes = new int[n];
            for (int i = 0; i < n; i++)
            {
                indexes[i] = i;
            }
            for (int i = n - 1; i >= 1; i--)
            {
                int r = Random.Range(0, i + 1);
                int temp = indexes[r];
                indexes[r] = indexes[i];
                indexes[i] = temp;
            }
            int[] result = new int[pickCount];
            Array.Copy(indexes, result, pickCount);
            return result;
        }

        /// <summary>
        /// 打乱顺序
        /// </summary>
        public static void RandomSequence<T>(T[] array)
        {
            int length = array.Length;
            int[] indexes = FisherYatesShuffle(length, length);
            T[] newArray = new T[length];
            for (int i = 0; i < length; i++)
            {
                newArray[i] = array[indexes[i]];
            }
            for (int i = 0; i < length; i++)
            {
                array[i] = newArray[i];
            }
        }
        public static void RandomSequence<T>(List<T> list)
        {
            int length = list.Count;
            int[] indexes = FisherYatesShuffle(length, length);
            T[] newArray = new T[length];
            for (int i = 0; i < length; i++)
            {
                newArray[i] = list[indexes[i]];
            }
            for (int i = 0; i < length; i++)
            {
                list[i] = newArray[i];
            }
        }

        /// <summary>
        /// 两圆的交点。
        /// </summary>
        public static Vector2[] CircleIntersections(Vector2 center1, float radius1, Vector2 center2, float radius2)
        {
            Assert.IsTrue(radius1 > 0 && radius2 > 0);

            float dis = Vector2.Distance(center1, center2);
            float r1r2 = radius1 + radius2;
            float r1dis = radius1 + dis;
            float r2dis = radius2 + dis;
            if (dis > r1r2 || radius1 > r2dis || radius2 > r1dis)
            {
                return new Vector2[0];
            }
            if (Mathf.Approximately(dis, r1r2))
            {
                return new Vector2[] { center1 + (center2 - center1).normalized * radius1 };
            }
            if (Mathf.Approximately(radius1, r2dis))
            {
                return new Vector2[] { center1 + (center2 - center1).normalized * radius1 };
            }
            if (Mathf.Approximately(radius2, r1dis))
            {
                return new Vector2[] { center2 + (center1 - center2).normalized * radius2 };
            }
            float c1cos = (radius1 * radius1 + dis * dis - radius2 * radius2) / (2 * radius1 * dis);
            float c1angle = Mathf.Acos(c1cos) * Mathf.Rad2Deg;
            Vector2 c1c2 = center2 - center1;
            Vector2 dir1 = (Quaternion.AngleAxis(c1angle, Vector3.forward) * c1c2).normalized;
            Vector2 dir2 = (Quaternion.AngleAxis(-c1angle, Vector3.forward) * c1c2).normalized;
            return new Vector2[] { center1 + radius1 * dir1, center1 + radius1 * dir2 };
        }

        /// <summary>
        /// 圆上随机点。
        /// </summary>
        public static Vector2 RandomOnUnitCircle()
        {
            float angle = Random.Range(0f, 360f);
            return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        }

        /// <summary>
        /// 平方。
        /// </summary>
        public static float Square(float number)
        {
            return number * number;
        }

        public static MoveDirection GetDirectionFromInput(Vector2 input, float deadzone)
        {
            if (input.sqrMagnitude < deadzone * deadzone)
            {
                return MoveDirection.None;
            }
            float x = input.x;
            float y = input.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x > 0)
                {
                    return MoveDirection.Right;
                }
                else
                {
                    return MoveDirection.Left;
                }
            }
            else
            {
                if (y > 0)
                {
                    return MoveDirection.Up;
                }
                else
                {
                    return MoveDirection.Down;
                }
            }
        }

        /// <summary>
        /// 从数组中随机一个
        /// </summary>
        public static T RandomOne<T>(T[] array)
        {
            return array[Random.Range(0, array.Length)];
        }

        /// <summary>
        /// 直线速度转换为转速。
        /// </summary>
        public static float VelocityToRotateSpeed(float velocity, float radius)
        {
            return velocity / radius * Mathf.Rad2Deg;
        }

        public static Vector2 WorldToGUIPoint(Vector3 worldPosition)
        {
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(worldPosition);
            return new Vector2(screenPoint.x, Screen.height - screenPoint.y);
        }
    }
}
