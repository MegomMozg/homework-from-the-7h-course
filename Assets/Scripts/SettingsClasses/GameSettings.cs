using UnityEngine;

namespace PlatformerMVC
{
    [CreateAssetMenu(fileName = "Settings", menuName = "Other/Settings", order = 1)]
    public class GameSettings : ScriptableObject
    {
        [Header("Тут можно настроить работу некоторых скриптов")]
        [Space]
        [Tooltip("отключение передвижения")] public bool Player;
        [Tooltip("отключение слежения камеры и фона за игркоком")] public bool Background;//+
        [Tooltip("отключение смерти")] public bool DeathZone;//+
        [Tooltip("отключение победы")] public bool Finish;//+
        [Tooltip("отключение монет(пока они вообще на работают)")] public bool Coin;//-

        
    }
}