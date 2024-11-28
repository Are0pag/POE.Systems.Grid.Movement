using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Scripts.Systems.GridMovement
{
    internal class MoveTrace
    {
        protected Vector3 _startPoint;
        public bool Executing = false;
        public bool IsComplete = false;

        internal MoveTrace(IGridMovable currentlyMoving) {
            CurrentlyMoving = currentlyMoving;
            _startPoint = currentlyMoving.MovingObject.transform.position;
        }

        internal List<InputCommand> Commands { get; } = new();

        internal IGridMovable CurrentlyMoving { get; }

        internal InputCommand LastCommand { get; private set; }

        internal virtual async UniTask PassWay() {
            try {
                foreach (var command in Commands) {
                    await command.MoveCommand.Execute();
                    command.DisplayCommand.OnCellPassed();
                }
            }
            catch (Exception ex) {
                Debug.Log($"catch {ex} from {nameof(MoveTrace)}");
            }
        }

        internal virtual void AddStep(IMovableGridCell cell) {
            if (cell.Position == _startPoint)
                return;

            var command = new MoveCommand(CurrentlyMoving, cell.Position, GetStartPositionForCommand());
            var displayCommand = new DisplayCommand(cell, CurrentlyMoving.GridMovementStats.StepCount - Commands.Count);

            LastCommand = new InputCommand(command, displayCommand);
            Commands.Add(LastCommand);
        }

        internal virtual void UndoStep() {
            LastCommand.DisplayCommand.Undo();
            Commands.Remove(LastCommand);

            if (Commands.Count > 0)
                LastCommand = Commands.Last();
        }

        internal virtual void UndoOperation() {
            foreach (var command in Commands) command.DisplayCommand.Undo();
        }


        protected virtual Vector3 GetStartPositionForCommand() {
            return Commands.Count == 0 ? CurrentlyMoving.MovingObject.transform.position : LastCommand.MoveCommand.TargetPosition;
        }
    }
}