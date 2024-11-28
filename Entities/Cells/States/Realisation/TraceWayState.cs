using Scripts.Services.EventBus;

namespace Scripts.Systems.GridMovement
{
    internal class TraceWayState : StateCell
    {
        internal override void OnMouseEnter(MovableCell cell) {
            base.OnMouseEnter(cell);
            EventBus.RaiseEvent<ITraceHandle>(h => h.OnPlayerContinueMovableItemPass(cell));
        }
    }
}