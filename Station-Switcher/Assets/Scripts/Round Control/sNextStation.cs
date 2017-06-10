using UnityEngine;
using System.Collections;
using System;

public class sNextStation : MonoBehaviour {
    sDialControl dial;
    Transform stationDial;
    public GameObject station;
    float stationPosition;

     void Awake() {
        dial = GameObject.FindGameObjectWithTag("Dial").GetComponent<sDialControl>();
        stationDial = GameObject.FindGameObjectWithTag("Station Dial").GetComponent<Transform>();
    }

    public void nextStation() {
        do {
            System.Random choser = new System.Random();
            float nextStation = (float)((choser.Next() * 20) + 89) + (float)(choser.Next()*0.5); //chose a random station from 89 to 109
            station = GameObject.FindGameObjectWithTag(nextStation.ToString());
            stationPosition = station.transform.position.x; //convert from station to xy plane in unity
        } while (stationPosition == stationDial.position.x); //make sure isn't same station
        findDirection();
    }

    private void findDirection() { //compare the position of the station dial and the new station and set the direction that the dial can turn
        int desiredDirection = 0; ;
        if (stationDial.position.x > stationPosition) 
            desiredDirection = -1;
        else if (stationDial.position.x < stationPosition)
            desiredDirection = 1;

        dial.setDesiredDirection(desiredDirection);
    }
    public float getStationPosition() {
        return stationPosition;
    }
}
