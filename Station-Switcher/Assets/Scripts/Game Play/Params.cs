using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Params : MonoBehaviour {
    public static bool Mute = false;


	// Use this for initialization
	void Awake() {
        PlayerData data = load();
        Mute = data.Mute;
        Debug.Log("Mute is " + Mute);
	}

    PlayerData load() {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat")) {
            BinaryFormatter bf = new BinaryFormatter();

            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.OpenOrCreate);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            return data;
        } else { 
            return new PlayerData();
        }
    } 
}
