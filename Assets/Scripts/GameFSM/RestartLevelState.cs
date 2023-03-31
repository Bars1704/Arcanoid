namespace GameFSM
{
    public class RestartLevelState : IState
    {
        private readonly StateMachine _stateMachine;

        public RestartLevelState(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            _stateMachine.Enter<StartGameState>();
        }
        public void Exit()
        {
        }
    }
}