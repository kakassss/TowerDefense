public interface IDataService
{
    void SaveData<T>(string RelativePath, T Data, bool Encryped);
    T LoadData<T>(string RelativePath, bool Encryped);
}