using Scripts.Services.EventBus;

namespace Scripts.Systems.GridMovement
{
    public class GridContentTargetNotifying : GridContent
    {
        protected IGridMovable _gridMovable;
        public override IGridMovable SelectedHero {
            get => _gridMovable;
            set {
                EventBus<IExternalGridMovementSubscriber>
                   .RaiseEvent<ITargetChangeNotification>(n => n.OnTargetChange(value));
                _gridMovable = value;
            }
        }
    }
}