namespace PlatformerMVC
{
    public interface IUnscaledUpdate : IUpdatable
    {
        public void UnscaledUpdate(float unscaledDeltaTime);
    }
}

