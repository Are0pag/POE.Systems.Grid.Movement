namespace Scripts.Systems.GridMovement
{
    internal class IdleState : StateCell
    {
        internal override void OnMouseEnter(MovableCell cell) {
            base.OnMouseEnter(cell);
            cell.Display.SelectedSkin.SetActive(true);
        }

        internal override void OnMouseExit(MovableCell cell) {
            base.OnMouseExit(cell);
            cell.Display.SelectedSkin.SetActive(false);
        }
    }
}