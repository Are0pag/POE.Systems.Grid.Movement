namespace Scripts.Systems.GridMovement
{
    internal struct InputCommand
    {
        internal BaseMoveCommand MoveCommand { get; private set; }
        internal DisplayCommand DisplayCommand { get; private set; }

        internal InputCommand(BaseMoveCommand command, DisplayCommand displayCommand) {
            MoveCommand = command;
            DisplayCommand = displayCommand;
        }
    }
}