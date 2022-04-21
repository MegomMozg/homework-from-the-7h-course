using UnityEngine;

namespace PlatformerMVC
{
    [CreateAssetMenu(fileName = "Settings", menuName = "Other/Settings", order = 1)]
    public class GameSettings : ScriptableObject
    {
        public bool Player;//+
        public bool Background;//+
        public bool DeathZone;//+
        public bool Finish;//+
        public bool Coin;//-
    }
}