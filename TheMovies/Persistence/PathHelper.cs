using System.IO;

namespace TheMovies.Persistence;

internal class PathHelper
{
    public static string GetSolutionDirectory()
    {
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string SolutionDirectory = Directory.GetParent(baseDirectory).Parent.Parent.Parent.Parent.FullName;

        return SolutionDirectory;
    }
}
