namespace PlatformerMVC
{
    public interface ILateUpdate : IUpdatable
    {
        public void LateUpdate(float deltaTime);
    }
}
