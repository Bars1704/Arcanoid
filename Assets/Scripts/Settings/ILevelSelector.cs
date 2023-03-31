namespace Settings
{
    public interface ILevelSelector
    {
        LevelSettings GetNextLevel();

        LevelSettings Current { get; }
    }
}