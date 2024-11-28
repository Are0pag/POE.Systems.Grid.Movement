using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Scripts.Systems.GridMovement
{
    internal class MoveCommand : BaseMoveCommand
    {
        internal MoveCommand(IGridMovable movingObject, Vector3 targetPosition, Vector3 startPosition) : base(movingObject, targetPosition, startPosition) {
        }

        internal override async UniTask Execute() {
            await _movingObject.MoveAsync(TargetPosition, _movingObject.GridMovementStats.Speed);
        }

        internal override async UniTask Undo() {
            await _movingObject.MoveAsync(StartPosition, _movingObject.GridMovementStats.Speed);
        }
    }
}