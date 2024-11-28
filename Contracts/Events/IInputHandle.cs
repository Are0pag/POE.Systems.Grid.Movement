using Scripts.Services.EventBus;

namespace Scripts.Systems.GridMovement
{
    internal interface IInputHandle : IGidMovementSubscriber
    {
        void OnMouseButtonDown();
        void OnMouseButtonUp();
    }
}