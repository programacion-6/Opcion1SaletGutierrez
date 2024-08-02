namespace Opcion1SaletGutierrez.src.Manager;

public class DataManager<T>
{
    private readonly string _jsonFilePath;

    public DataManager(string jsonFilePath)
    {
        _jsonFilePath = jsonFilePath;
    }
}
