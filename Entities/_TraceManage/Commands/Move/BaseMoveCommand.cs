using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Scripts.Systems.GridMovement
{
    internal abstract class BaseMoveCommand
    {
        protected readonly IGridMovable _movingObject;

        protected BaseMoveCommand(IGridMovable movingObject, Vector3 targetPosition, Vector3 startPosition) {
            _movingObject = movingObject;
            TargetPosition = targetPosition;
            StartPosition = startPosition;
        }

        internal abstract UniTask Execute();
        internal abstract UniTask Undo();
        
        internal protected Vector3 TargetPosition { get; protected set; }
        internal protected Vector3 StartPosition { get; protected set; }
    }
}