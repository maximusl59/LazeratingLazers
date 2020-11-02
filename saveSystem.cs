using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class saveSystem
{

    public static void saveGame(scoreCounter sC) {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        highScore hiScore = new highScore(sC);

        binaryFormatter.Serialize(stream, hiScore);
        stream.Close();
    }

    public static highScore loadGame() {
        string path = Application.persistentDataPath + "/save.txt";
        if (File.Exists(path)) {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            highScore hiScore = binaryFormatter.Deserialize(stream) as highScore;

            stream.Close();

            return hiScore;

        } else {
            Debug.LogError("File not found in " + path);
            return null;
        }
    }
}
