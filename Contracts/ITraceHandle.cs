using Scripts.Services.EventBus;

namespace Scripts.Systems.GridMovement
{
    /// <summary>
    ///     It is a type of event that is used by a cell in various states to notify about the type  of user input
    /// </summary>
    internal interface ITraceHandle : IGlobalSubscriber
    {
        void OnPlayerSelectCell(IMovableGridCell cell);
        void OnPlayerContinueMovableItemPass(IMovableGridCell cell);
    }
}