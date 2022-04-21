using UnityEngine;

namespace Odders
{
	[CreateAssetMenu(fileName = "New Shake Data", menuName = "Odders/Shake Data")]
	public class ShakeData : ScriptableObject
	{
		#region Public Variables
		public SpatialProperty target = SpatialProperty.POSITION;

		[Range(0f, 5f)] public float amplitude = 1f;
		[Range(0f, 20f)] public float frequency = 10f;
		[Range(0f, 5f)] public float duration = 0.5f;

		public AnimationCurve curve = new AnimationCurve
		(
			new Keyframe(0f, 0f, Mathf.Deg2Rad * 0f, Mathf.Deg2Rad * 720f),
			new Keyframe(0.2f, 1f),
			new Keyframe(1f, 0f)
		);

		public bool showConstraints, constraintX, constraintY, constraintZ;
		#endregion Public Variables


		#region Main Methods
		public void Shake(Transform transform)
		{
			Shaker s = transform.gameObject.GetComponent<Shaker>();

			if (s == null)
			{
				s = transform.gameObject.AddComponent<Shaker>();
				s.destroy = true;
			}

			s.Shake(this);
		}
		#endregion Main Methods
	}
}