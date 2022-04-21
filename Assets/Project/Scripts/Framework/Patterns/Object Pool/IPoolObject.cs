namespace Odders
{
	public interface IPoolObject
	{
		#region Properties
		public ObjectPool Pool { get; set; }
		#endregion Properties


		#region Main Methods
		void OnDequeue();
		void OnEnqueue();
		#endregion Main Methods
	}
}