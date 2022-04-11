using UnityEngine;

namespace PlatformerMVC
{
    public sealed class Game
    {
        #region Close
        private GameStarter _gameStarter;
        public void Start(GameStarter gameStarter)
        {
            _gameStarter = gameStarter;
            BeginGame();
        }
        #endregion
        private void BeginGame()
        {
            #region Classes
            BulletController bulletController = new BulletController();
            turelController turelController = new turelController(bulletController);
            PlayerController playerController = new PlayerController();
            Background background = new Background();
            #endregion
            #region EndGame
            End end = new End(playerController);
            end.Winner += background.ground;
            #endregion
            #region Controllers
            UpdateController updateController = new UpdateController();
            updateController.AddController(bulletController);
            updateController.AddController(background);
            updateController.AddController(turelController);
            updateController.AddController(playerController);
            updateController.AddController(end);
            _gameStarter.SetUpdateController(updateController);
            #endregion
        }
    }
}
