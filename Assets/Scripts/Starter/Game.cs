using UnityEngine;

namespace PlatformerMVC
{
    #region Using
    using PlatformerMVC.game;
    using PlatformerMVC.game.Background;
    using PlatformerMVC.game.GenerateLevel;
    #endregion
    public sealed class Game
    {
        #region Close
        private GameStarter _gameStarter;
        public void Start(GameStarter gameStarter)
        {
            _gameStarter = gameStarter;
            if (gameStarter.ControllerLevel == true) BeginGame();
            else if (gameStarter.ControllerLevel == false) NewBegingame();

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
            #region Update
            UpdateController updateController = new UpdateController();
            updateController.AddController(bulletController);
            updateController.AddController(background);
            updateController.AddController(turelController);
            updateController.AddController(playerController);
            updateController.AddController(end);
            _gameStarter.SetUpdateController(updateController);
            #endregion
        }
        private void NewBegingame()
        {
            PlayerController playerController = new PlayerController();
            GenerateLevelController generateLevelController = new GenerateLevelController();
            #region Update
            UpdateController updateController = new UpdateController();
            updateController.AddController(playerController);
            _gameStarter.SetUpdateController(updateController);
            #endregion
        }
    }
}
