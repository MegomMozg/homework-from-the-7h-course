namespace PlatformerMVC
{
    public interface IUpdateController : IUpdate, IFixedUpdate, ILateUpdate, IUnscaledUpdate
    {
        public void AddController(IUpdatable updatable);
        public void RemoveController(IUpdatable updatable);
    }
}
