using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class JsonReadWriteSystem : MonoBehaviour
{
    public string Name_data;
    public int Days_data;
    public int Cups_data;
    public int D_played_data;
    

    public void SaveToJson()
    {
        PlayerData data = new PlayerData();
        data.Name = Name_data;
        //data.Day = Days_data;
        data.Cups = Cups_data;
        data.D_play = D_played_data;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.dataPath + "/Player.json", json);
    }

    public void LoadFromJson()
    {
        string json = File.ReadAllText(Application.dataPath + "/PlayerFile.json");
        PlayerData data = JsonUtility.FromJson<PlayerData>(json);

        Name_data = data.Name;
      //  Days_data = data.Day;
        Cups_data = data.Cups;
        D_played_data = data.D_play;
    }
}
