using Input;
using Level;
using Settings;

namespace GameFSM
{
    public class StartGameState : IState
    {
        private readonly ILevelLoader _levelLoader;
        private readonly ILevelSelector _levelSelector;
        private readonly IPlayerInput _playerInput;
        private readonly StateMachine _stateMachine;

        public StartGameState(
            StateMachine stateMachine,
            ILevelLoader levelLoader,
            ILevelSelector levelSelector,
            IPlayerInput playerInput)
        {
            _stateMachine = stateMachine;
            _levelLoader = levelLoader;
            _levelSelector = levelSelector;
            _playerInput = playerInput;
        }

        public void Exit()
        {
            _playerInput.OnPlayerMoveX -= Begin;
        }

        public void Enter()
        {
            _levelLoader.Init(_levelSelector.GetNextLevel());
            _playerInput.OnPlayerMoveX += Begin;
        }

        private void Begin(float _)
        {
            _stateMachine.Enter<GameLoopState>();
        }
    }
}