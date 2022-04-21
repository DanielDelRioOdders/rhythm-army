using UnityEngine;
using UnityEngine.Events;
using Coroutine = System.Collections.IEnumerator;

#if UNITY_EDITOR
using Unity.EditorCoroutines.Editor;
#endif

namespace Odders
{
	public abstract partial class BaseObject : MonoBehaviour
	{
		#region Public Variables
#if UNITY_EDITOR
		[HideInInspector] public Inspector inspector = new Inspector();
#endif
		#endregion Public Variables


		#region Private Variables
#if UNITY_EDITOR
		private EditorCoroutine[] editorCoroutines = new EditorCoroutine[0];
#endif
		#endregion Private Variables


		#region Events
		[HideInInspector] public UnityEvent OnEnableObject, OnDisableObject, OnDestroyObject;
		#endregion Events


		#region Properties
		public Vector3 Position { get => transform.position; set => transform.position = value; }
		public Vector3 LocalPosition { get => transform.localPosition; set => transform.localPosition = value; }
		public Quaternion Rotation { get => transform.rotation; set => transform.rotation = value; }
		public Quaternion LocalRotation { get => transform.localRotation; set => transform.localRotation = value; }
		public Vector3 EulerAngles { get => transform.eulerAngles; set => transform.eulerAngles = value; }
		public Vector3 LocalEulerAngles { get => transform.localEulerAngles; set => transform.localEulerAngles = value; }
		public Vector3 LocalScale { get => transform.localScale; set => transform.localScale = value; }

		public Vector3 Up => transform.up;
		public Vector3 Down => -transform.up;
		public Vector3 Right => transform.right;
		public Vector3 Left => -transform.right;
		public Vector3 Forward => transform.forward;
		public Vector3 Backward => -transform.forward;
		public Matrix4x4 LocalToWorldMatrix => transform.localToWorldMatrix;
		public Matrix4x4 WorldToLocalMatrix => transform.worldToLocalMatrix;

		public Transform Parent { get => transform.parent; set => transform.SetParent(value); }

		public float DeltaTime => Time.deltaTime;
		public float FixedDeltaTime => Time.fixedDeltaTime;
		public float TimeScale { get => Time.timeScale; set => Time.timeScale = value; }
		#endregion Properties


		#region Unity Methods
		protected virtual void OnEnable() => OnEnableObject?.Invoke();
		protected virtual void OnDisable() => OnDisableObject?.Invoke();
		protected virtual void OnDestroy() => OnDestroyObject?.Invoke();
		#endregion Unity Methods


		#region Main Methods
		public void StartCoroutines(params Coroutine[] coroutines) => MonoBehaviourExtensions.StartCoroutines(this, coroutines);
		public void StopCoroutines(params Coroutine[] coroutines) => MonoBehaviourExtensions.StopCoroutines(this, coroutines);

		public void Destroy(float delay) => Destroy(gameObject, delay.Abs());
		public void DestroyComponent(float delay) => Destroy(this, delay.Abs());
		#endregion Main Methods


		#region Utility Methods
		public void Print(string msg) => this.Log(msg);

		protected void StartEditorCoroutine(Coroutine c)
		{
#if UNITY_EDITOR
			if (!Application.isPlaying)
			{
				EditorCoroutine editorCoroutine = EditorCoroutineUtility.StartCoroutine(c, this);
				editorCoroutines = editorCoroutines.Add(editorCoroutine);
			}
			else StartCoroutine(c);
#else
			StartCoroutine(c);
#endif
		}
		protected void StopAllEditorCoroutines()
		{
#if UNITY_EDITOR
			editorCoroutines.Each(i => EditorCoroutineUtility.StopCoroutine(i));
			editorCoroutines = new EditorCoroutine[0];
#endif
		}
		protected void RunEditor(VoidDelegate a, VoidDelegate b)
		{
#if UNITY_EDITOR
			if (!Application.isPlaying) b();
			else a();
#else
			a();
#endif
		}
		#endregion Utility Methods
	}
}