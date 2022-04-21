using UnityEngine;
using Coroutine = System.Collections.IEnumerator;

namespace Odders
{
    public static class MonoBehaviourExtensions
    {
        public static void StartCoroutines(this MonoBehaviour mono, params Coroutine[] coroutines) => coroutines.Each(i => mono.StartCoroutine(i));
        public static void StopCoroutines(this MonoBehaviour mono, params Coroutine[] coroutines) => coroutines.Each(i => mono.StopCoroutine(i));
    }
}