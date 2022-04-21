using System;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;

namespace Odders
{
	public static class ObjectExtensions
	{
		private static void Log(Action<string, Object> function, Object obj, string prefix, params object[] msg)
		{
			string prefixFormat = prefix == "" ? prefix : $"[{prefix}] ";
			string objectFormat = $"[{obj.name.Color("lightblue")}]";
			string messagesFormat = $"{string.Join(" | ", msg)}";

			function($"{prefixFormat}{objectFormat} {messagesFormat}\n", obj);
		}

		public static void Log(this Object o, params object[] msg)					=> Log(Debug.Log, o, "", msg);
		public static void LogNotification(this Object o, params object[] msg)		=> Log(Debug.Log, o, "Notification".Color("cyan"), msg);
		public static void LogSuccess(this Object o, params object[] msg)			=> Log(Debug.Log, o, "Success".Color("lime"), msg);
		public static void LogWarning(this Object o, params object[] msg)			=> Log(Debug.LogWarning, o, "Warning".Color("yellow"), msg);
		public static void LogError(this Object o, params object[] msg)				=> Log(Debug.LogError, o, "Error".Color("red"), msg);
	}
}