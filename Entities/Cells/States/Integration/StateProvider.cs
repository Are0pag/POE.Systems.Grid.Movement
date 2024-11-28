namespace Scripts.Systems.GridMovement
{
    internal class StateProvider
    {
        internal StateCell CurrentState { get; private set; }
        internal IdleState IdleState { get; private set; } = new();
        internal StartWayState StartWayState { get; private set; } = new();
        internal TraceWayState TraceWayState { get; private set; } = new();

        internal void SwitchState(StateCell state, MovableCell cell) {
            CurrentState = CurrentState == state ? CurrentState : state;
            CurrentState.EnterState(cell);
        }
    }
}