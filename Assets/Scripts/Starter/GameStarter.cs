using UnityEngine;


namespace PlatformerMVC
{
    public sealed class GameStarter : MonoBehaviour
    {
        public bool ControllerLevel;
        private IUpdateController _mainUpdateController;

        private void Start()
        {
            Game game = new Game();
            game.Start(this);
        }

        public void SetUpdateController(IUpdateController updateController)
        {
            _mainUpdateController = updateController;
        }

        private void Update()
        {
            _mainUpdateController.Update(Time.deltaTime);
            _mainUpdateController.UnscaledUpdate(Time.unscaledDeltaTime);
        }

        private void FixedUpdate()
        {
            _mainUpdateController.FixedUpdate(Time.fixedDeltaTime);
        }

        private void LateUpdate()
        {
            _mainUpdateController.LateUpdate(Time.deltaTime);
        }

    }

}

