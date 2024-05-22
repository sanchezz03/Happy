using System.Reflection;

namespace Happy.Common.Helpers;

public static class TypesHelper
{
    #region Public methods

    /// <summary>
    /// Returns target types from all assemblies by current
    /// </summary>
    /// <param name="targetType"></param>
    /// <returns>List of types</returns>
    public static List<Type> GetTypesFromAllAssembliesByGenericInterface(Type targetType)
    {
        return GetAllAssembly()
            .SelectMany(s => s.GetTypes())
            .Where(p => p.GetInterfaces().Any(i => i.Name == targetType.Name) && p.FullName.StartsWith("Happy"))
            .ToList();
    }

    #endregion


    #region Private methods

    private static List<Assembly> GetAllAssembly()
    {
        List<Assembly> allAssemblies = new List<Assembly>();
        var location = Assembly.GetExecutingAssembly().Location;
        string path = Path.GetDirectoryName(location);
        foreach (string dll in Directory.GetFiles(path, "*.dll"))
        {
            allAssemblies.Add(Assembly.LoadFile(dll));
        }

        return allAssemblies;
    }

    #endregion
}
