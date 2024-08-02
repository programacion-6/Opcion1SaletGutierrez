using Newtonsoft.Json;
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
        try
        {
            var jsonData = File.ReadAllText(jsonFilePath);
            var dataList = JsonConvert.DeserializeObject<List<T>>(jsonData);
            return dataList ?? new List<T>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading data: {ex.Message}");
            return new List<T>();
        }
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
