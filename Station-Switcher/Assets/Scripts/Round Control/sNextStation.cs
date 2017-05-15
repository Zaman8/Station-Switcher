using UnityEngine;
using System.Collections;
using System;

public class sNextStation : MonoBehaviour {
    sDialControl dial;
    Transform stationDial;
    float station;
    float stationPosition;

     void Awake() {
        dial = GameObject.FindGameObjectWithTag("Dial").GetComponent<sDialControl>();
        stationDial = GameObject.FindGameObjectWithTag("Station Dial").GetComponent<Transform>();
    }

    public void nextStation() {
        do {
            System.Random choser = new System.Random();
            float nextStation = (float)((choser.NextDouble() * 20) + 89.7); //chose a random station from 89.7 to 109.7
            station = nextStation; //make that the station
            stationPosition = station; //convert from station to xy plane in unity (work on when we know spacing)
        } while (stationPosition == stationDial.position.x);
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
}
