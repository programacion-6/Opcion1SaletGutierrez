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
        try
        {
            var dataList = LoadData();
            dataList.Add(item);
            File.WriteAllText(_jsonFilePath, JsonConvert.SerializeObject(dataList, Formatting.Indented));
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding item: {ex.Message}");
            return false;
        }
    }

    public List<T> LoadData()
    {
        try
        {
            var jsonData = File.ReadAllText(_jsonFilePath);
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
        try
        {
            var dataList = LoadData();
            var propertyInfo = typeof(T).GetProperty(attributeName);
            if (propertyInfo == null)
            {
                throw new ArgumentException($"Property '{attributeName}' not found in type '{typeof(T).Name}'");
            }

            var itemToRemove = dataList.FirstOrDefault(x => propertyInfo.GetValue(x)?.ToString() == id.ToString());
            if (itemToRemove != null)
            {
                dataList.Remove(itemToRemove);
                File.WriteAllText(_jsonFilePath, JsonConvert.SerializeObject(dataList, Formatting.Indented));
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error removing item: {ex.Message}");
            return false;
        }
    }

    public List<T> SearchByAttribute(string attributeName, string value)
    {
        try
        {
            var dataList = LoadData();
            var propertyInfo = typeof(T).GetProperty(attributeName);
            if (propertyInfo == null)
            {
                throw new ArgumentException($"Property '{attributeName}' not found in type '{typeof(T).Name}'");
            }

            var results = dataList.Where(
                            x => propertyInfo.GetValue(x) != null &&
                                 propertyInfo.GetValue(x).ToString()
                                 .IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0)
                            .ToList();
            return results;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error searching by attribute: {ex.Message}");
            return new List<T>();
        }
    }

    public T SearchById(string attributeName, T id)
    {
        try
        {
            var dataList = LoadData();
            var propertyInfo = typeof(T).GetProperty(attributeName);
            if (propertyInfo == null)
            {
                throw new ArgumentException($"Property '{attributeName}' not found in type '{typeof(T).Name}'");
            }

            var item = dataList.FirstOrDefault(x => propertyInfo.GetValue(x).Equals(id));
            return item;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error searching by ID: {ex.Message}");
            return default;
        }
    }

    public bool UpdateItem(string attributeName, object id, T updatedItem)
    {
        try
        {
            var dataList = LoadData();
            var itemIndex = dataList.FindIndex(x => GetPropertyValue(x, attributeName).Equals(id));

            if (itemIndex >= 0)
            {
                dataList[itemIndex] = updatedItem;
                File.WriteAllText(_jsonFilePath, JsonConvert.SerializeObject(dataList, Formatting.Indented));
                return true;
            }

            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating item: {ex.Message}");
            return false;
        }
    }
    
    private object GetPropertyValue(object obj, string propertyName)
    {
        return obj.GetType().GetProperty(propertyName)?.GetValue(obj, null);
    }
}
