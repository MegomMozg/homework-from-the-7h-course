using UnityEngine;

namespace PlatformerMVC
{
    [CreateAssetMenu(fileName = "Settings", menuName = "Other/Settings", order = 1)]
    public class GameSettings : ScriptableObject
    {
        [Header("��� ����� ��������� ������ ��������� ��������")]
        [Space]
        [Tooltip("���������� ������������")] public bool Player;
        [Tooltip("���������� �������� ������ � ���� �� ��������")] public bool Background;//+
        [Tooltip("���������� ������")] public bool DeathZone;//+
        [Tooltip("���������� ������")] public bool Finish;//+
        [Tooltip("���������� �����(���� ��� ������ �� ��������)")] public bool Coin;//-

        
    }
}