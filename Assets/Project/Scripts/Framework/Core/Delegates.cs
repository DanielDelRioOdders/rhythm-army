using UnityEngine;

namespace Odders
{
	public delegate void VoidDelegate();
	public delegate void BoolDelegate(bool b);
	public delegate void BoolArrayDelegate(bool[] b);
	public delegate void IntDelegate(int i);
	public delegate void IntArrayDelegate(int[] i);
	public delegate void FloatDelegate(float f);
	public delegate void FloatArrayDelegate(float[] f);
	public delegate void StringDelegate(string s);
	public delegate void StringArrayDelegate(string[] s);
	public delegate void Vector2Delegate(Vector2 v);
	public delegate void Vector2ArrayDelegate(Vector2[] v);
	public delegate void Vector2IntDelegate(Vector2Int v);
	public delegate void Vector2IntArrayDelegate(Vector2Int[] v);
	public delegate void Vector3Delegate(Vector3 v);
	public delegate void Vector3ArrayDelegate(Vector3[] v);
	public delegate void Vector3IntDelegate(Vector3Int v);
	public delegate void Vector3IntArrayDelegate(Vector3Int[] v);
	public delegate void TransformDelegate(Transform t);
	public delegate void TransformArrayDelegate(Transform[] t);
	public delegate void GameObjectDelegate(GameObject o);
	public delegate void GameObjectArrayDelegate(GameObject[] o);
	public delegate void ObjectDelegate(object o);
	public delegate void ObjectArrayDelegate(object[] o);
	public delegate void GenericDelegate<T>(T t);
	public delegate void GenericArrayDelegate<T>(T[] t);

	public delegate T ValidInputDelegate<T>(string input);

	public delegate T FieldDelegate<T>(string label, T val, GUILayoutOption[] options);
}