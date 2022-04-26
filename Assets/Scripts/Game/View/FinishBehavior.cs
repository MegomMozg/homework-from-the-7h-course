using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace PlatformerMVC.game
{
    [AddComponentMenu(menuName: "Behavior/Game/Finish")]
    public class FinishBehavior : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;

        public event Action OnRestartButtonClick;

        public void Awake()
        {
            _restartButton.onClick.AddListener(RestartButton);
        }

        private void RestartButton()
        {
            OnRestartButtonClick?.Invoke();
        }
    }
}

