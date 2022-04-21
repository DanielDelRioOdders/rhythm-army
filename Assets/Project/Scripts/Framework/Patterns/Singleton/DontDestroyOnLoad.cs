using AddComponentMenu = UnityEngine.AddComponentMenu;

namespace Odders
{
    /// <summary>
    /// 
    /// </summary>
    [AddComponentMenu("Odders/Patterns/Dont Destroy On Load")]
    public class DontDestroyOnLoad : BaseObject { private void Awake() => DontDestroyOnLoad(gameObject); }
}