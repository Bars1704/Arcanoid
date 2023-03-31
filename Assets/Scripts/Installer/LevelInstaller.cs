using Input;
using Level;
using Reflex;
using ScreenBounds;
using Settings;
using UnityEngine;

namespace Installer
{
    public class LevelInstaller : Reflex.Scripts.Installer
    {
        [SerializeField] private DesktopPlayerInput _playerInput;
        [SerializeField] private OneLevelSelector _levelSelector;
        [SerializeField] private LevelLoader _levelLoader;
        [SerializeField] private LevelGameLoopMediator _levelGameLoopMediator;

        public override void InstallBindings(Container container)
        {
            container.BindInstanceAs<IPlayerInput>(_playerInput);
            container.BindInstanceAs<ILevelSelector>(_levelSelector);
            container.BindInstanceAs<ILevelLoader>(_levelLoader);
            container.BindInstanceAs<ILevelWinMonitor>(_levelGameLoopMediator);
            container.BindInstanceAs<ILevelLoseMonitor>(_levelGameLoopMediator);
            container.BindSingleton<IScreenBoundsService, ScreenBoundsService>();

            container.Construct<Level.Game>();
        }
    }
}