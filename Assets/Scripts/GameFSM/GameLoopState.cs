using Level;

namespace GameFSM
{
    public class GameLoopState : IState
    {
        private readonly ILevelLoader _levelLoader;
        private readonly StateMachine _stateMachine;
        private readonly ILevelWinMonitor _levelWinMonitor;
        private readonly ILevelLoseMonitor _levelLoseMonitor;

        public GameLoopState(StateMachine stateMachine, ILevelLoader levelLoader, ILevelWinMonitor winMonitor,
            ILevelLoseMonitor loseMonitor)
        {
            _stateMachine = stateMachine;
            _levelLoader = levelLoader;
            _levelWinMonitor = winMonitor;
            _levelLoseMonitor = loseMonitor;

            _levelWinMonitor.OnLevelWin += Restart;
            _levelLoseMonitor.OnLevelLose += Restart;
        }

        public void Exit()
        {
            _levelWinMonitor.OnLevelWin -= Restart;
            _levelLoseMonitor.OnLevelLose -= Restart;
        }

        private void Restart()
        {
            _stateMachine.Enter<RestartLevelState>();
        }

        public void Enter()
        {
            _levelLoader.StartGame();
        }
    }
}