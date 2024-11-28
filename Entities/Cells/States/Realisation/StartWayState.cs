using Scripts.Services.EventBus;

namespace Scripts.Systems.GridMovement
{
    internal class StartWayState : StateCell
    {
        internal override void OnMouseOver(MovableCell cell) {
            cell.StateProvider.SwitchState(cell.StateProvider.IdleState, cell);
            EventBus.RaiseEvent<ITraceHandle>(h => h.OnPlayerSelectCell(cell));
        }
    }
}