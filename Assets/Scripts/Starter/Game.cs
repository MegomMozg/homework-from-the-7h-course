using UnityEngine;

namespace PlatformerMVC
{
    public sealed class Game
    {
        private GameStarter _gameStarter;
        public void Start(GameStarter gameStarter)
        {
            _gameStarter = gameStarter;

            InitInputController();

            BeginGame();

        }

        private void InitInputController()
        {
            //IKeySetControl keySetControl = Resources.Load<KeySetControl>(ResourcesPathes.KEY_SET_CONTROL);
            //_inputData = new InputData();
            //_inputController = new InputController(_inputData, keySetControl);
        }

        private void BeginGame()
        {
            SpriteAnimatorConfig SpriteAnimatorConfig = Resources.Load<SpriteAnimatorConfig>(ResourcesPathes.SPRITE_ANIMM_CONFIG);
            SpriteAnimatorController spriteAnimatorController = new SpriteAnimatorController(SpriteAnimatorConfig);
            PlayerController playerController = new PlayerController(spriteAnimatorController);

            UpdateController updateController = new UpdateController();
            updateController.AddController(spriteAnimatorController);
            updateController.AddController(playerController);
            _gameStarter.SetUpdateController(updateController);
        }
    }
}
