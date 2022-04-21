using UnityEngine;

namespace Odders
{
	[CreateAssetMenu(fileName = "New Game Event", menuName = "Odders/Game Event")]
	public class GameEvent : ScriptableObject
	{
		#region Private Variables
		private Observer[] events = new Observer[0];
		#endregion Private Variables


		#region Main Methods
		public void Invoke() => events.Each(i => i.Invoke());
		public void Add(Observer observer) => events = events.Add(observer, true);
		public void Remove(Observer observer) => events = events.Remove(observer);
		#endregion Main Methods
	}
}