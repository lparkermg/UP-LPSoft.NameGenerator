namespace LPSoft.NameGenerator 
{
    /// <summary>
    /// Interface for implementing random number generators for use with the Name Generator.
    /// </summary>
    public interface ICanRandom 
    {
        int Range(int min, int max);
    }
}