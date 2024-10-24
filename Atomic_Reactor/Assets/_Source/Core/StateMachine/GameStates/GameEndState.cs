namespace Core.StateMachine.GameStates
{
    public class GameEndState : State
    {
        private readonly GameInfo _gameInfo;

        public GameEndState(GameInfo gameInfo) => _gameInfo = gameInfo;

        public override void Enter() => _gameInfo.SetPlayingState(false);
    }
}