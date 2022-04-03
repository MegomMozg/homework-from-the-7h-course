using System.Collections.Generic;


namespace PlatformerMVC
{
    public sealed class UpdateController : IUpdateController
    {
        private List<IUpdate> _updateList;
        private List<IFixedUpdate> _fixedUpdateList;
        private List<ILateUpdate> _lateUpdateList;
        private List<IUnscaledUpdate> _unscaledUpdateList;

        public UpdateController()
        {
            _updateList = new List<IUpdate>();
            _fixedUpdateList = new List<IFixedUpdate>();
            _lateUpdateList = new List<ILateUpdate>();
            _unscaledUpdateList = new List<IUnscaledUpdate>();
        }

        public void Update(float deltaTime)
        {
            foreach (IUpdate controller in _updateList)
            {
                controller.Update(deltaTime);
            }
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            foreach (IFixedUpdate controller in _fixedUpdateList)
            {
                controller.FixedUpdate(fixedDeltaTime);
            }
        }

        public void LateUpdate(float deltaTime)
        {
            foreach (ILateUpdate controller in _lateUpdateList)
            {
                controller.LateUpdate(deltaTime);
            }
        }

        public void UnscaledUpdate(float unscaledDeltaTime)
        {
            foreach (IUnscaledUpdate controller in _unscaledUpdateList)
            {
                controller.UnscaledUpdate(unscaledDeltaTime);
            }
        }

        public void AddController(IUpdatable updatable)
        {
            if (updatable is IUpdate updateController) _updateList.Add(updateController);
            if (updatable is IFixedUpdate fixedUpdateController) _fixedUpdateList.Add(fixedUpdateController);
            if (updatable is ILateUpdate lateUpdateController) _lateUpdateList.Add(lateUpdateController);
            if (updatable is IUnscaledUpdate unscaledUpdateController) _unscaledUpdateList.Add(unscaledUpdateController);
        }

        public void RemoveController(IUpdatable updatable)
        {
            if (updatable is IUpdate updateController) _updateList.Remove(updateController);
            if (updatable is IFixedUpdate fixedUpdateController) _fixedUpdateList.Remove(fixedUpdateController);
            if (updatable is ILateUpdate lateUpdateController) _lateUpdateList.Remove(lateUpdateController);
            if (updatable is IUnscaledUpdate unscaledUpdateController) _unscaledUpdateList.Remove(unscaledUpdateController);
        }

    }
}
