using UnityEngine;

namespace Odders
{
	public class ShakeController
	{
		#region Const Variables
		private const float RAND = 32f;
		#endregion Const Variables


		#region Private Variables
		private Vector3 offset;
		private float t;
		#endregion Private Variables


		#region Properties
		public ShakeData Data { get; private set; }
		public Vector3 Noise { get; private set; }
		public bool IsRunning => t > 0f;
		#endregion Properties


		#region Constructor
		public ShakeController(ShakeData data)
		{
			Data = data;
			t = data.duration;

			offset = offset.Random(0f, RAND);
		}
		#endregion Constructor


		#region Main Methods
		public void Update()
		{
			float deltaTime = Time.deltaTime;
			t -= deltaTime;

			float noiseOffsetDelta = deltaTime * Data.frequency;
			offset.x += noiseOffsetDelta;
			offset.y += noiseOffsetDelta;
			offset.z += noiseOffsetDelta;

			float x = Mathf.PerlinNoise(offset.x, 0f);
			float y = Mathf.PerlinNoise(offset.y, 1f);
			float z = Mathf.PerlinNoise(offset.z, 2f);
			Noise = new Vector3(x, y, z);

			Noise -= Vector3.one * 0.5f;
			Noise *= Data.amplitude;

			float value = 1f - (t / Data.duration);
			Noise *= Data.curve.Evaluate(value);
		}
		#endregion Main Methods
	}
}