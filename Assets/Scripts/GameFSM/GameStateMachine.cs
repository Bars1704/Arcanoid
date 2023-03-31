using System;
using System.Collections.Generic;
using Input;
using Level;
using Settings;

namespace GameFSM
{
    public class GameStateMachine : StateMachine
    {
        public GameStateMachine(
            IPlayerInput playerInput,
            ILevelSelector levelSelector,
            ILevelLoader levelLoader,
            ILevelWinMonitor winMonitor,
            ILevelLoseMonitor loseMonitor)
        {
            _states = new Dictionary<Type, IState>
            {
                [typeof(StartGameState)] = new StartGameState(this, levelLoader, levelSelector, playerInput),
                [typeof(GameLoopState)] = new GameLoopState(this, levelLoader, winMonitor, loseMonitor),
                [typeof(RestartLevelState)] = new RestartLevelState(this),
            };
        }
    }
}