using Opcion1SaletGutierrez.src.Interfaces;

namespace Opcion1SaletGutierrez.src.Manager;

public class DataManager<T> : IDataManager<T>
{
    private readonly string _jsonFilePath;

    public DataManager(string jsonFilePath)
    {
        _jsonFilePath = jsonFilePath;
    }

    public bool AddItem(T item)
    {
        throw new NotImplementedException();
    }

    public List<T> LoadData(string jsonFilePath)
    {
        throw new NotImplementedException();
    }

    public bool RemoveItem(string attributeName, object id)
    {
        throw new NotImplementedException();
    }

    public List<T> SearchByAttribute(string attributeName, string value)
    {
        throw new NotImplementedException();
    }

    public T SearchById(string attributeName, T id)
    {
        throw new NotImplementedException();
    }

    public bool UpdateItem(string attributeName, object id, T updatedItem)
    {
        throw new NotImplementedException();
    }
}
