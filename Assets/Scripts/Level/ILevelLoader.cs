using Settings;

namespace Level
{
    public interface ILevelLoader
    {
        public void Init(LevelSettings newLevel);
        public void StartGame();
    }
}