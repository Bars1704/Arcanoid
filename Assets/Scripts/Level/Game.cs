using GameFSM;
using Input;
using Settings;

namespace Level
{
    public class Game
    {
        private readonly StateMachine _gameStateMachine;

        public Game(
            IPlayerInput playerInput,
            ILevelSelector levelSelector,
            ILevelLoader levelLoader,
            ILevelWinMonitor winMonitor,
            ILevelLoseMonitor loseMonitor)
        {
            _gameStateMachine = new GameStateMachine(playerInput, levelSelector, levelLoader, winMonitor, loseMonitor);
            _gameStateMachine.Enter<StartGameState>();
        }
    }
}