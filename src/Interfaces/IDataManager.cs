namespace Opcion1SaletGutierrez.src.Interfaces;

public interface IDataManager<T>
{
    List<T> LoadData(string jsonFilePath);

    T SearchById(string attributeName, T id);

    List<T> SearchByAttribute(string attributeName, string value);

    bool AddItem(T item);

    bool RemoveItem(string attributeName, object id);

    bool UpdateItem(string attributeName, object id, T updatedItem);
}
