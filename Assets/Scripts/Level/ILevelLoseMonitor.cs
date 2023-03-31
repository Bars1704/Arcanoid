using System;

namespace Level
{
    public interface ILevelLoseMonitor
    {
        public event Action OnLevelLose;
    }
}