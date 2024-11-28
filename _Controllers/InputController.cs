using Scripts.Services.EventBus;
using UnityEngine;

namespace Scripts.Systems.GridMovement
{
    internal class InputController : MonoBehaviour
    {
        protected virtual void Update() {
            if (Input.GetMouseButtonDown(0)) 
                EventBus<IGidMovementSubscriber>.RaiseEvent<IInputHandle>(h => h.OnMouseButtonDown());

            if (Input.GetMouseButtonUp(0)) 
                EventBus<IGidMovementSubscriber>.RaiseEvent<IInputHandle>(h => h.OnMouseButtonUp());
        }
    }
}