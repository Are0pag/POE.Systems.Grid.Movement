namespace Scripts.Systems.GridMovement
{
    internal interface IGridHandle : IGidMovementSubscriber
    {
        void OnInput();
        void OnMovableItemDefine();
        void OnStopTracing();
    }
}