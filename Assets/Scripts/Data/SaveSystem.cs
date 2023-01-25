using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem
{
    const string saveFileName = "/player.fog";

    public void SavePlayer(PlayerDataStructure player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + saveFileName;

        using (FileStream stream = new FileStream(path, FileMode.Create))
        {
            formatter.Serialize(stream, player);
        }
    }

    public PlayerDataStructure LoadPlayer()
    {
        string path = Application.persistentDataPath + saveFileName;

        if (File.Exists(path))
        {
            PlayerDataStructure data;
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                if (stream.Length == 0)
                    return null;

                data = formatter.Deserialize(stream) as PlayerDataStructure;
            }

            return data;
        }
        return null;
    }

    public void ResetPlayerData()
    {
        string path = Application.persistentDataPath + saveFileName;

        if (File.Exists(path))
            File.Delete(path);
    }

    public void OpenPlayerDataFolder() => Process.Start(Application.persistentDataPath);
}
