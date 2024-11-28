namespace Scripts.Systems.GridMovement
{
    internal abstract class StateCell
    {
        internal virtual void EnterState(MovableCell cell) {
            cell.Display.SelectedSkin.SetActive(false);
        }

        internal virtual void OnMouseEnter(MovableCell cell) {
            MovableCell.IsMouseOnGrid = true;
        }

        internal virtual void OnMouseOver(MovableCell cell) {
        }

        internal virtual void OnMouseExit(MovableCell cell) {
            MovableCell.IsMouseOnGrid = false;
        }
    }
}