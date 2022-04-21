using UnityEngine;

namespace Odders
{
    public static class Rigidbody2DExtensions
    {
        public static void AddExplosionForce(this Rigidbody2D rb, float explosionForce, Vector3 explosionPosition, float explosionRadius, float upwardsModifier = 0f, ForceMode2D mode = ForceMode2D.Force)
        {
            var dir = (rb.transform.position - explosionPosition);
            float wearoff = 1 - (dir.magnitude / explosionRadius);
            Vector3 baseForce = dir.normalized * explosionForce * wearoff;
            rb.AddForce(baseForce);

            float upliftWearoff = 1 - upwardsModifier / explosionRadius;
            Vector3 upliftForce = Vector2.up * explosionForce * upliftWearoff;
            rb.AddForce(upliftForce, mode);
        }
    }
}