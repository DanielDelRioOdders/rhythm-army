using UnityEngine;

namespace Odders
{
    public static class TransformExtensions
    {
        public static Vector3 OrbitAround(this Transform t, Vector3 pivot, Quaternion angle)
            => angle * (t.position - pivot) + pivot;
    }
}