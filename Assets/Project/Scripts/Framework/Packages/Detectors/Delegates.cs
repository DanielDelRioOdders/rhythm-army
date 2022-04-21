using UnityEngine;

namespace Odders
{
	public delegate void ColliderDelegate(Collider c);
	public delegate void ColliderArrayDelegate(Collider[] c);
	public delegate void Collider2DDelegate(Collider2D c);
	public delegate void Collider2DArrayDelegate(Collider2D[] c);
	public delegate void CollisionDelegate(Collision c);
	public delegate void Collision2DDelegate(Collision2D c);
}