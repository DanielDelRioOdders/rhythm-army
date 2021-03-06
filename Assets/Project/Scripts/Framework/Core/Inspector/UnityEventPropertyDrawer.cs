#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;
using UnityEngine.Events;

namespace Odders.Editor
{
    [CustomPropertyDrawer(typeof(UnityEventBase), true)]
    public class UnityEventPropertyDrawer : UnityEventDrawer
    {
        protected override void SetupReorderableList(ReorderableList list)
        {
            base.SetupReorderableList(list);
            list.draggable = true;
        }
    }
}
#endif