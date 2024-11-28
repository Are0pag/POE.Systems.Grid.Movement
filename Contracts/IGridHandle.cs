using Scripts.Services.EventBus;

namespace Scripts.Systems.GridMovement
{
    internal interface IGridHandle : IGlobalSubscriber
    {
        void OnInput();
        void OnMovableItemDefine();
        void OnStopTracing();
    }
}