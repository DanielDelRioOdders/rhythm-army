namespace Odders
{
	/// <summary>
	/// Design pattern that allows you to restrict the creation of objects belonging to a class.
	/// </summary>
	public abstract class Singleton<T> : BaseObject where T : BaseObject
	{
		#region Properties
		public static T Instance { get; private set; }
		#endregion Properties


		#region Unity Methods
		protected virtual void Awake()
		{
			if (Instance == null) Instance = this as T;
			else Destroy(gameObject);
		}
		#endregion Unity Methods
	}
}