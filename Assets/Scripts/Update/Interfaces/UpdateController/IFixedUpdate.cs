namespace PlatformerMVC
{
    public interface IFixedUpdate : IUpdatable
    {
        public void FixedUpdate(float fixedDeltaTime);
    }
}

