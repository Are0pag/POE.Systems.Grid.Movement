namespace Scripts.Systems.GridMovement
{
    internal interface IInputHandle : IGidMovementSubscriber
    {
        void OnMouseButtonDown();
        void OnMouseButtonUp();
    }
}