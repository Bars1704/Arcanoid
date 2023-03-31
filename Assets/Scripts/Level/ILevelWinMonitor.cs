using System;

namespace Level
{
    public interface ILevelWinMonitor
    {
        public event Action OnLevelWin;
    }
}