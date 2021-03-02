using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public GameState gameState;

    public void Save()
    {
        Debug.Log(Application.persistentDataPath + "/Player.dat");
        FileStream file =
            new FileStream(Application.persistentDataPath + "/Player.dat",
                FileMode.OpenOrCreate);
        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(file, gameState.state);
        }
        catch (SerializationException err)
        {
            Debug
                .LogError("There was an issue saving the player data: " +
                err.Message);
        }
        finally
        {
            file.Close();
        }
    }

    public void Load()
    {
        FileStream file =
            new FileStream(Application.persistentDataPath + "/Player.dat",
                FileMode.Open);
        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            gameState.state = (State) formatter.Deserialize(file);
            gameState.load();
        }
        catch (SerializationException err)
        {
            Debug.Log("Error Loading the Game: " + err.Message);
        }
        finally
        {
            file.Close();
        }
    }
}
