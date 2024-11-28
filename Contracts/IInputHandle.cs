using Scripts.Services.EventBus;

namespace Scripts.Systems.GridMovement
{
    internal interface IInputHandle : IGlobalSubscriber
    {
        void OnMouseButtonDown();
        void OnMouseButtonUp();
    }
}