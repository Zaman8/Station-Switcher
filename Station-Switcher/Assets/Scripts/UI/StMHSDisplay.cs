using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class StMHSDisplay : MonoBehaviour {
    Text text;
    private int HighScore;

    void OnEnable() {
        text = this.GetComponent<Text>();
        HighScore = Load();
        text.text = String.Format("{0}", HighScore);
    }

    int Load() {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat")) {
            BinaryFormatter bf = new BinaryFormatter();

            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            return data.HighScore;
        } else {
            return 0;
        }
    }
}
