using Scripts.Services.EventBus;
using Scripts.Systems.GridMovement.Display;
using UnityEngine;

namespace Scripts.Systems.GridMovement
{
    internal class MovableCell : Cell, IMovableGridCell, IGridHandle
    {
        static internal bool IsMouseOnGrid;
        [field: SerializeField] public CellDisplay Display { get; protected set; }
        internal protected StateProvider StateProvider { get; protected set; }
        Vector3 IMovableGridCell.Position => gameObject.transform.position;


        protected virtual void OnEnable() {
            EventBus.Subscribe(this);
            StateProvider = new StateProvider();
            StateProvider.SwitchState(StateProvider.IdleState, this);
        }

        protected virtual void OnDisable() {
            EventBus.Unsubscribe(this);
        }

        protected virtual void OnMouseEnter() => StateProvider?.CurrentState?.OnMouseEnter(this);

        protected virtual void OnMouseExit() => StateProvider?.CurrentState?.OnMouseExit(this);

        protected virtual void OnMouseOver() => StateProvider?.CurrentState?.OnMouseOver(this);

        void IGridHandle.OnInput() {
            if (IsMouseOnGrid) 
                StateProvider.SwitchState(StateProvider.StartWayState, this);
        }

        void IGridHandle.OnMovableItemDefine() {
            StateProvider.SwitchState(StateProvider.TraceWayState, this);
        }

        void IGridHandle.OnStopTracing() {
            StateProvider.SwitchState(StateProvider.IdleState, this);
        }


    }
}