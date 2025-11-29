namespace Scripts.Systems.GridMovement
{
    public interface ITargetChangeNotification : IExternalGridMovementSubscriber
    {
        void OnTargetChange(IGridMovable movable);
    }
}