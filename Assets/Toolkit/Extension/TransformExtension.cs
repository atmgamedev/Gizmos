using System;
using UnityEngine;

namespace Gizmos
{
    public static class TransformExtension
    {
        public static Transform FindRecursive(this Transform self, string name)
        {
            int childCount = self.childCount;
            if (childCount == 0)
            {
                if (self.name == name)
                {
                    return self;
                }
                else
                {
                    return null;
                }
            }

            for (int i = 0; i < childCount; i++)
            {
                var child = self.GetChild(i);
                var childResult = child.FindRecursive(name);
                if (childResult)
                {
                    return childResult;
                }
            }
            return null;
        }

        public static void SetPositionX(this Transform transform, float x)
        {
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }
        public static void SetPositionY(this Transform transform, float y)
        {
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }
        public static void SetPositionZ(this Transform transform, float z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, z);
        }
        public static void SetLocalPositionX(this Transform transform, float x)
        {
            transform.localPosition = new Vector3(x, transform.localPosition.y, transform.localPosition.z);
        }
        public static void SetLocalPositionY(this Transform transform, float y)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);
        }
        public static void SetLocalPositionZ(this Transform transform, float z)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, z);
        }

        public static void SetLocalEulerAngleX(this Transform transform, float x)
        {
            Vector3 angle = transform.localEulerAngles;
            transform.localEulerAngles = new Vector3(x, angle.y, angle.z);
        }
        public static void SetLocalEulerAngleY(this Transform transform, float y)
        {
            Vector3 angle = transform.localEulerAngles;
            transform.localEulerAngles = new Vector3(angle.x, y, angle.z);
        }
        public static void SetLocalEulerAngleZ(this Transform transform, float z)
        {
            Vector3 angle = transform.localEulerAngles;
            transform.localEulerAngles = new Vector3(angle.x, angle.y, z);
        }

        public static void CopyLocal(this Transform origin, Transform target)
        {
            origin.localPosition = target.localPosition;
            origin.localRotation = target.localRotation;
            origin.localScale = target.localScale;
        }
        public static void CopyLocalPose(this Transform origin, Transform target)
        {
            origin.localPosition = target.localPosition;
            origin.localRotation = target.localRotation;
        }
        public static void SetLocalPose(this Transform transform, Pose pose)
        {
            transform.localPosition = pose.position;
            transform.localRotation = pose.rotation;
        }

        public static Vector3 DirectionTo(this Vector3 origin, Vector3 target)
        {
            return (target - origin).normalized;
        }
        public static Vector3 DirectionTo(this Transform origin, Vector3 target)
        {
            return (origin.position.DirectionTo(target));
        }
        public static Vector3 DirectionTo(this Transform origin, Transform target)
        {
            return (origin.position.DirectionTo(target.position));
        }
        public static Vector3 DirectionTo(this Transform origin, Component target)
        {
            return (origin.position.DirectionTo(target.transform.position));
        }
        public static Vector3 YPlaneDirectionTo(this Vector3 origin, Vector3 target)
        {
            return (target - origin).ClearY().normalized;
        }
        public static Vector3 YPlaneDirectionTo(this Transform origin, Vector3 target)
        {
            return origin.position.YPlaneDirectionTo(target);
        }

        public static float DistanceTo(this Vector3 origin, Vector3 target)
        {
            return Vector3.Distance(origin, target);
        }
        public static float DistanceTo(this Vector3 origin, Component component)
        {
            return origin.DistanceTo(component.transform.position);
        }
        public static float DistanceTo(this Transform origin, Vector3 target)
        {
            return origin.position.DistanceTo(target);
        }
        public static float DistanceTo(this Transform origin, Transform target)
        {
            return origin.position.DistanceTo(target.position);
        }
        public static float YPlaneDistanceTo(this Vector3 origin, Vector3 target)
        {
            return origin.ClearY().DistanceTo(target.ClearY());
        }
        public static float YPlaneDistanceTo(this Transform origin, Vector3 target)
        {
            return origin.position.ClearY().DistanceTo(target.ClearY());
        }
        public static float YPlaneDistanceTo(this Transform origin, Transform target)
        {
            return origin.position.ClearY().DistanceTo(target.position.ClearY());
        }

        public static bool InDistance(this Vector3 origin, Vector3 target, float distance)
        {
            return (target - origin).sqrMagnitude < distance * distance;
        }
        public static bool YPlaneInDistance(this Vector3 origin, Vector3 target, float distance)
        {
            return (target - origin).ClearY().sqrMagnitude < distance * distance;
        }

        public static float AngleToTarget(this Transform origin, Vector3 target)
        {
            return Vector3.Angle(origin.forward, origin.DirectionTo(target));
        }
        public static float AngleToTarget(this Transform origin, Transform target)
        {
            return Vector3.Angle(origin.forward, origin.DirectionTo(target));
        }
        public static float XPlaneAngleToTarget(this Transform origin, Vector3 target)
        {
            Vector3 xPlaneForward = Vector3.ProjectOnPlane(origin.forward, Vector3.right);
            Vector3 xPlaneTargetDir = Vector3.ProjectOnPlane(origin.DirectionTo(target), Vector3.right);
            return Vector3.Angle(xPlaneForward, xPlaneTargetDir);
        }
        public static float XPlaneAngleToTarget(this Transform origin, Transform target)
        {
            return XPlaneAngleToTarget(origin, target.position);
        }
        public static float YPlaneAngleToTarget(this Transform origin, Vector3 target)
        {
            Vector3 yPlaneForward = Vector3.ProjectOnPlane(origin.forward, Vector3.up);
            Vector3 yPlaneTargetDir = Vector3.ProjectOnPlane(origin.DirectionTo(target), Vector3.up);
            return Vector3.Angle(yPlaneForward, yPlaneTargetDir);
        }
        public static float YPlaneAngleToTarget(this Transform origin, Transform target)
        {
            return YPlaneAngleToTarget(origin, target.position);
        }

        public static Transform[] Children(this Transform transform)
        {
            int count = transform.childCount;
            var children = new Transform[count];
            for (int i = 0; i < count; i++)
            {
                children[i] = transform.GetChild(i);
            }
            return children;
        }
        public static void DestroyChildren(this Transform transform)
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                UnityEngine.Object.Destroy(transform.GetChild(i).gameObject);
            }
        }
        public static void DestroyChildrenImmediate(this Transform transform)
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                UnityEngine.Object.DestroyImmediate(transform.GetChild(i).gameObject);
            }
        }

        public static void RotateTowards(this Transform transform, Vector3 forward, float maxDegreesDelta)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(forward), maxDegreesDelta);
        }

        public static void YPlaneLookAt(this Transform transform, Vector3 target)
        {
            Vector3 yPlaneTarget = new Vector3(target.x, transform.position.y, target.z);
            transform.LookAt(yPlaneTarget);
        }
        public static void YPlaneLookAt(this Transform transform, Transform target)
        {
            transform.YPlaneLookAt(target.position);
        }
        public static void YPlaneLookAt(this Transform transform, Component target)
        {
            transform.YPlaneLookAt(target.transform.position);
        }

        /// <summary>
        /// 朝某个位置移动
        /// </summary>
        /// <returns>是否到达</returns>
        public static bool MoveTowards(this Transform transform, Vector3 target, float moveDistance)
        {
            float dis = transform.DistanceTo(target);
            if (dis <= moveDistance)
            {
                transform.position = target;
                return true;
            }
            transform.position += transform.DirectionTo(target) * moveDistance;
            return false;
        }
    }
}
