using UnityEngine;
using UnityEngine.AI;
using Odders;

namespace RhythmArmy
{
	[AddComponentMenu("Rhythm Army/Unit"), RequireComponent(typeof(NavMeshAgent))]
	public class Unit : MonoBehaviour
	{
		#region Public Variables
		public float moveDuration = 0.25f;
		#endregion Public Variables


		#region Protected Variables
		protected NavMeshAgent agent;
		protected Vector3 destination;
		#endregion Protected Variables


		#region Unity Methods
		protected virtual void OnEnable() => RhythmController.OnBeat += OnBeat;
		protected virtual void OnDisable() => RhythmController.OnBeat -= OnBeat;

		protected virtual void Awake() => agent = GetComponent<NavMeshAgent>();
		#endregion Unity Methods


		#region Main Methods
		protected virtual void OnBeat()
		{
			EnableAgent();
			Invoke(nameof(DisableAgent), moveDuration);
		}
		#endregion Main Methods


		#region Utility Methods
		public void SetDestination(Transform destination) => this.destination = destination.position;

		protected void EnableAgent()
		{
			agent.SetDestination(destination);
			agent.isStopped = false;
		}
		protected void DisableAgent() => agent.isStopped = true;
		#endregion Utility Methods
	}
}