namespace Odders
{
    public static class AnimatorExtensions
    {
        public static bool HasParameter(this UnityEngine.Animator a, string param) => a.parameters.Contains(i => i.name == param);
    }
}