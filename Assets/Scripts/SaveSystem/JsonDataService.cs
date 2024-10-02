using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class JsonDataService : IDataService
{
    public void SaveData<T>(string RelativePath, T Data, bool Encryped)
    {
        string path = Application.persistentDataPath + RelativePath;
        
        try
        {
            if (File.Exists(path))
            {
                Debug.Log("File Exists.");
                File.Delete(path);
            }
            else
            {
                Debug.Log("Writing file for the first time");
            }
            using FileStream stream = File.Create(path);
            stream.Close();
            File.WriteAllText(path,JsonConvert.SerializeObject(Data));
        }
        catch (Exception e)
        {
            Debug.LogError("Unable to save data");
        }
    }

    public T LoadData<T>(string RelativePath, bool Encryped)
    {
        string path = Application.persistentDataPath + RelativePath;

        if (!File.Exists(path))
        {
            Debug.LogError("File does not exist");
            throw new FileNotFoundException(path + "does not exist");
        }

        try
        {
            T data = JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
            return data;
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to load data");
            throw e;
        }
    }
}