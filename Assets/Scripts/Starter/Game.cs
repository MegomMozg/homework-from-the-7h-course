using UnityEngine;

namespace PlatformerMVC
{
    public sealed class Game
    {
        private GameStarter _gameStarter;
        public void Start(GameStarter gameStarter)
        {
            _gameStarter = gameStarter;

            BeginGame();

        }

        private void BeginGame()
        {
            Background background = new Background();
            BulletController bulletController = new BulletController();
            turelController turelController = new turelController(bulletController);
            PlayerController playerController = new PlayerController();
            

            UpdateController updateController = new UpdateController();
            updateController.AddController(bulletController);
            updateController.AddController(background);
            updateController.AddController(turelController);
            updateController.AddController(playerController);
            _gameStarter.SetUpdateController(updateController);
        }
    }
}
