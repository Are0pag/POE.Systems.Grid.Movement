namespace Scripts.Systems.GridMovement
{
    internal class DisplayCommand
    {
        internal DisplayCommand(IMovableGridCell cell, int remainingStepsCount) {
            cell.Display.WayTraceSkin.SetActive(true);
            cell.Display.SetRemainingStepsText(remainingStepsCount);
            Cell = cell;
        }

        internal IMovableGridCell Cell { get; }

        internal virtual void OnCellPassed() {
            Disable();
        }

        internal virtual void Undo() {
            Disable();
        }

        protected virtual void Disable() {
            Cell.Display.WayTraceSkin.SetActive(false);
        }
    }
}