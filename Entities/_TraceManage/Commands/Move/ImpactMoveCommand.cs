using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Scripts.Systems.GridMovement
{
    internal class ImpactMoveCommand : MoveCommand
    {
        internal protected int NecessarySteps { get; }
        protected readonly float _speed;
        
        internal ImpactMoveCommand(IGridMovable movingObject, Vector3 targetPosition, Vector3 startPosition, float speed, int necessarySteps) 
            : base(movingObject, targetPosition, startPosition) 
        {
            NecessarySteps = necessarySteps;
            _speed = speed;
        }
        
        internal override async UniTask Execute() {
            await _movingObject.MoveAsync(TargetPosition, _speed);
        }

        internal override async UniTask Undo() {
            await _movingObject.MoveAsync(StartPosition, _speed);
        }
    }
}