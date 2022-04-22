using UnityEngine;
using UnityEngine.AI;
using Odders;

namespace RythmMonsters
{
	[AddComponentMenu("Rythm Monsters/Unit"), RequireComponent(typeof(NavMeshAgent))]
	public class Unit : MonoBehaviour
	{
		#region Public Variables
		public int attack = 1;
		public int defense = 1;
		public string line;
		public string id;
		public Animator animator;
		public AudioSource audioSource;
		public AudioClip deadClip, spawnClip;
		#endregion Public Variables


		#region Protected Variables
		protected NavMeshAgent agent;
		protected Vector3 destination;
		protected bool dead;
		#endregion Protected Variables


		#region Unity Methods
		protected virtual void OnEnable() => Rhythm.OnAccent += OnAccent;
		protected virtual void OnDisable() => Rhythm.OnAccent -= OnAccent;

		protected virtual void Awake() => agent = GetComponent<NavMeshAgent>();

		protected virtual void Start()
		{
			if (spawnClip != null)
				audioSource.PlayOneShot(spawnClip);
		}

		protected virtual void OnCollisionEnter(Collision collision)
		{
			if (collision.gameObject.name == line) Destroy(gameObject);

			Unit enemy = collision.gameObject.GetComponent<Unit>();

			if (enemy != null && enemy.id == id)
				enemy.TakeDamage(attack);
		}
		#endregion Unity Methods


		#region Main Methods
		protected virtual void OnAccent()
		{
			EnableAgent();
			Invoke(nameof(DisableAgent), Rhythm.Instance.rate / 4f);
		}

		public void TakeDamage(int damage)
		{
			defense -= damage;

			if (defense <= 0)
			{
				DisableAgent();
				dead = true;
				animator.Play("Die");
				Destroy(gameObject, 1f);

				if (deadClip != null)
					audioSource.PlayOneShot(deadClip);
			}
		}
		#endregion Main Methods


		#region Utility Methods
		public void SetDestination(Transform destination) => this.destination = destination.position;

		protected void EnableAgent()
		{
			if (dead) return;

			agent.SetDestination(destination);
			agent.isStopped = false;
		}
		protected void DisableAgent() => agent.isStopped = true;
		#endregion Utility Methods
	}
}