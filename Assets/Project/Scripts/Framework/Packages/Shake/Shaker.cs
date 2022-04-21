using UnityEngine;
using UnityEngine.Events;

namespace Odders
{
	[AddComponentMenu("Odders/Shaker")]
	public class Shaker : BaseObject
	{
		#region Public Variables
		[HideInInspector] public bool destroy;
		#endregion Public Variables


		#region Events
		public UnityEvent<ShakeData> OnStart, OnFinish;
		#endregion Events


		#region Properties
		public ShakeController[] Shakes { get; private set; } = new ShakeController[0];
		#endregion Properties


		#region Unity Methods
		protected virtual void LateUpdate()
		{
			Vector3 positionOffset = Vector3.zero;
			Vector3 rotationOffset = Vector3.zero;
			Vector3 scaleOffset = Vector3.one;

			for (int i = Shakes.Length - 1; i != -1; i--)
			{
				ShakeController s = Shakes[i];
				s.Update();

				float x = s.Data.constraintX ? 0f : s.Noise.x;
				float y = s.Data.constraintY ? 0f : s.Noise.y;
				float z = s.Data.constraintZ ? 0f : s.Noise.z;
				Vector3 noise = new Vector3(x, y, z);

				switch (s.Data.target)
				{
					case SpatialProperty.POSITION: positionOffset += noise; break;
					case SpatialProperty.ROTATION: rotationOffset += noise; break;
					case SpatialProperty.SCALE: scaleOffset += noise; break;
				}

				if (!s.IsRunning)
				{
					OnFinish?.Invoke(s.Data);
					Shakes = Shakes.Remove(s);
				}
			}

			LocalPosition = positionOffset;
			LocalEulerAngles = rotationOffset;
			LocalScale = scaleOffset;

			if (Shakes.IsNullOrEmpty() && destroy) Destroy(this); 
		}
		#endregion Unity Methods


		#region Main Methods
		public void Shake(ShakeData data)
		{
			ShakeController s = new ShakeController(data);
			Shakes = Shakes.Add(s);
			OnStart?.Invoke(data);
		}
		#endregion Main Methods
	}
}