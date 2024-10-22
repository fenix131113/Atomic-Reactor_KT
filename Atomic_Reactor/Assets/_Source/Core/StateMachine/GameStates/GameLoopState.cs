using ResourceSystem.Services;

namespace Core.StateMachine.GameStates
{
    public class GameLoopState : State
    {
        private readonly GameInfo _gameInfo;

        public GameLoopState(GameInfo gameInfo) => _gameInfo = gameInfo;
        
        public override void Enter()
        {
            _gameInfo.SetPlayingState(true);
        }

        public override void Exit()
        {
            ResourceTimerService.Instance.StopAllTimers();
        }
    }
}