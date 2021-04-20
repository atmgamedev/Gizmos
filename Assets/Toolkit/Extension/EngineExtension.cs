using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Gizmos
{
    public static class EngineExtension
    {
        public static T GetOrAddComponent<T>(this GameObject self) where T : Component
        {
            T comp = self.GetComponent<T>();
            return comp ? comp : self.AddComponent<T>();
        }
        public static T GetOrAddComponent<T>(this Component self) where T : Component
        {
            T comp = self.GetComponent<T>();
            return comp ? comp : self.gameObject.AddComponent<T>();
        }

        public static void Activate(this GameObject self)
        {
            self.SetActive(true);
        }
        public static void Deactivate(this GameObject self)
        {
            self.SetActive(false);
        }

        public static void Enable(this Behaviour self)
        {
            self.enabled = true;
        }
        public static void Disable(this Behaviour self)
        {
            self.enabled = false;
        }

        public static void SetAnchoredPositionX(this RectTransform rectTransform, float x)
        {
            rectTransform.anchoredPosition = new Vector2(x, rectTransform.anchoredPosition.y);
        }
        public static void SetAnchoredPositionY(this RectTransform rectTransform, float y)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, y);
        }

        public static void SetScreenUIByWorldPosition(this RectTransform rectTransform, Vector3 worldPosition)
        {
            var viewportPoint = Camera.main.WorldToViewportPoint(worldPosition);
            rectTransform.anchorMin = rectTransform.anchorMax = viewportPoint;
        }
        public static void SetScreenUIByWorldPosition(this RectTransform rectTransform, Vector3 worldPosition, Camera camera)
        {
            var viewportPoint = camera.WorldToViewportPoint(worldPosition);
            rectTransform.anchorMin = rectTransform.anchorMax = viewportPoint;
        }
        public static void SetScreenUIByWorldPosition(this RectTransform rectTransform, Vector3 worldPosition, Camera camera, Vector2 viewportOffset)
        {
            var viewportPoint = camera.WorldToViewportPoint(worldPosition);
            rectTransform.anchorMin = rectTransform.anchorMax = (Vector2)viewportPoint + viewportOffset;
        }

        public static float Duration(this AnimationCurve curve)
        {
            Keyframe lastFrame = curve[curve.length - 1];
            return lastFrame.time;
        }
        public static float FirstValue(this AnimationCurve curve)
        {
            Keyframe firstFrame = curve[0];
            return firstFrame.value;
        }
        public static float LastValue(this AnimationCurve curve)
        {
            Keyframe lastFrame = curve[curve.length - 1];
            return lastFrame.value;
        }
        public static float[] UniformSample(this AnimationCurve curve, int amount)
        {
            float[] values = new float[amount];
            for (int i = 0; i < amount; i++)
            {
                values[i] = curve.Evaluate(i / (float)amount);
            }
            return values;
        }

        public static void Pause(this Animator animator)
        {
            animator.speed = 0;
        }
        public static void Resume(this Animator animator)
        {
            animator.speed = 1;
        }

        public static void AddEntry(this EventTrigger trigger, EventTriggerType entryType, UnityAction<BaseEventData> call)
        {
            EventTrigger.Entry entry = new EventTrigger.Entry { eventID = entryType };
            entry.callback.AddListener(call);
            trigger.triggers.Add(entry);
        }
        public static void AddEntry(this EventTrigger trigger, EventTriggerType entryType, UnityAction call)
        {
            EventTrigger.Entry entry = new EventTrigger.Entry { eventID = entryType };
            entry.callback.AddListener((baseEventData) => { call(); });
            trigger.triggers.Add(entry);
        }

        /// <summary>
        /// Replace built-in Invoke method.
        /// Call `this.Invoke` in MonoBehaviour.
        /// </summary>
        public static IEnumerator Invoke(this MonoBehaviour self, Action action, float waitTime)
        {
            var routine = InvokeRoutine(action, waitTime);
            self.StartCoroutine(routine);
            return routine;
        }
        static IEnumerator InvokeRoutine(Action action, float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            action();
        }
        public static IEnumerator Invoke<T>(this MonoBehaviour self, Action<T> action, T param, float waitTime)
        {
            var routine = InvokeRoutine(action, param, waitTime);
            self.StartCoroutine(routine);
            return routine;
        }
        static IEnumerator InvokeRoutine<T>(Action<T> action, T param, float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            action(param);
        }
        public static IEnumerator Invoke<T1, T2>(this MonoBehaviour self, Action<T1, T2> action, T1 param1, T2 param2, float waitTime)
        {
            var routine = InvokeRoutine(action, param1, param2, waitTime);
            self.StartCoroutine(routine);
            return routine;
        }
        static IEnumerator InvokeRoutine<T1, T2>(Action<T1, T2> action, T1 param1, T2 param2, float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            action(param1, param2);
        }

        public static void ReplaceAndStartCoroutine(this MonoBehaviour self, ref IEnumerator oldRoutine, IEnumerator newRoutine)
        {
            if (oldRoutine != null)
            {
                self.StopCoroutine(oldRoutine);
            }
            self.StartCoroutine(newRoutine);
            oldRoutine = newRoutine;
        }

        public static Vector2 To4Directional(this Vector2 vector)
        {
            if (vector == Vector2.zero)
            {
                return vector;
            }
            Vector2 fourDirVec;
            if (Mathf.Abs(vector.x) >= Mathf.Abs(vector.y))
            {
                if (vector.x > 0)
                {
                    fourDirVec = vector.magnitude * Vector2.right;
                }
                else
                {
                    fourDirVec = vector.magnitude * Vector2.left;
                }
            }
            else
            {
                if (vector.y > 0)
                {
                    fourDirVec = vector.magnitude * Vector2.up;
                }
                else
                {
                    fourDirVec = vector.magnitude * Vector2.down;
                }
            }
            return fourDirVec;
        }
        public static Vector2 To8Directional(this Vector2 vector)
        {
            if (vector == Vector2.zero)
            {
                return vector;
            }
            float angleFromRight = Vector2.SignedAngle(Vector2.right, vector);
            if (angleFromRight < 0)
            {
                angleFromRight += 360;
            }
            float rotateAngle = angleFromRight % 45;
            if (rotateAngle > 22.5f)
            {
                rotateAngle -= 45f;
            }
            return Quaternion.Euler(0, 0, -rotateAngle) * vector;
        }
        public static Vector2 ToXZVector2(this Vector3 vector3)
        {
            return new Vector2(vector3.x, vector3.z);
        }
        public static Vector3 ToXZVector3(this Vector2 vector2)
        {
            return new Vector3(vector2.x, 0f, vector2.y);
        }
        public static Vector3 ClearY(this Vector3 self)
        {
            return new Vector3(self.x, 0, self.z);
        }
        public static Vector3 SetX(this ref Vector3 vector, float x)
        {
            vector.Set(x, vector.y, vector.z);
            return vector;
        }
        public static Vector3 SetY(this ref Vector3 vector, float y)
        {
            vector.Set(vector.x, y, vector.z);
            return vector;
        }
        public static Vector3 SetZ(this ref Vector3 vector, float z)
        {
            vector.Set(vector.x, vector.y, z);
            return vector;
        }

        public static void DebugDrawPath(this UnityEngine.AI.NavMeshPath path)
        {
            Vector3[] corners = path.corners;
            for (int i = 0, length = corners.Length - 1; i < length; i++)
            {
                Debug.DrawLine(corners[i], corners[i + 1], Color.yellow);
            }
        }

        public static LayerMask GetLayerMask(int layer)
        {
            int layerMask = 0;
            for (int i = 0; i < 32; i++)
            {
                if (!Physics.GetIgnoreLayerCollision(layer, i))
                {
                    layerMask |= 1 << i;
                }
            }
            return layerMask;
        }
        public static LayerMask GetLayerMask(this GameObject go)
        {
            return GetLayerMask(go.layer);
        }

        public static void Restart(this ParticleSystem ps)
        {
            ps.Clear();
            ps.Play();
        }

        public static float[] Distribute(float totalValue, float[] weights)
        {
            float weightSum = 0;
            for (int i = 0, length = weights.Length; i < length; i++)
            {
                weightSum += weights[i];
            }
            float unitValue = totalValue / weightSum;
            float[] values = new float[weights.Length];
            for (int i = 0, length = weights.Length; i < length; i++)
            {
                values[i] = unitValue * weights[i];
            }
            return values;
        }
    }
}
