using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class HSDisplay : MonoBehaviour {
    Text text;
    private int HighScore = 0;

    // Use this for initialization
    void Awake() {
        text = this.gameObject.GetComponent<Text>();
        roundManager.GUIupdate += checkHighScore;
        roundManager.Lost += Save;
        HighScore = Load();
        text.text = string.Format("High Score: {0}", HighScore);
    }

    void checkHighScore(double time, int round) {
        if (round > HighScore) {
            HighScore = round;
            text.text = String.Format("High Score: {0}", HighScore);
        }
    }

    void Save(int round) {
        if (round >= HighScore) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.OpenOrCreate);

            PlayerData data = new PlayerData();
            data.HighScore = HighScore;

            bf.Serialize(file, data);
            file.Close();
        }
    }

    int Load() {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat")) {
            BinaryFormatter bf = new BinaryFormatter();

            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.OpenOrCreate);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            return data.HighScore;
        } else {
            return 0;
        }

    }
}

[Serializable]
class PlayerData {
    public int HighScore;
}
