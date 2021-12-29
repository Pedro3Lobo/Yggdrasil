using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public PlayerData data;
    public string file = "player.txt";

    public void Save()
    {
        string json = JsonUtility.ToJson(data);
        WriteToFile(file, json);
    }

    public void Load()
    {
        data = new PlayerData();
        string json = ReadFromFile(file);
        JsonUtility.FromJsonOverwrite(json, data);
    }

    private void WriteToFile(string filename, string json)
    {
        string path = GetFilePath(filename);
        FileStream filestream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(filestream))
        {
            writer.Write(json);
        }
    }

    private string ReadFromFile(string filename)
    {
        string path = GetFilePath(filename);
        FileStream filestream = new FileStream(path, FileMode.Create);

        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(filestream))
            {
                string json = reader.ReadToEnd();
                return json;
            }
        }
        else
            Debug.LogWarning("File not found!");
        return "";
    }



    private string GetFilePath(string filename)
    {


        return Application.persistentDataPath+"/"+filename;
    }

}
