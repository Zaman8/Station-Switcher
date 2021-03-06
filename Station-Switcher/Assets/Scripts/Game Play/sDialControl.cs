﻿using UnityEngine;
using System.Collections;
using System;

public class sDialControl : MonoBehaviour {
    private int direction = 0; //+ is counterclockwise; - is clockwise (-1, 0, 1)
    private int desiredDirection = 0;
    public double theta;
    Transform rotator;

    private void Awake() {
        rotator = gameObject.GetComponent<Transform>(); //just used to rotate spirit
    }

    void LateUpdate() { //used to evaluate player direction and rotate spirit
        getDirection();
        if (direction == desiredDirection) {
            rotator.Rotate(rotator.position, (float)(theta * (180/Math.PI)), Space.Self); //rotate game object by theta in degrees
            //call function or event to station
          }
    }

    void getDirection() { //used to get direction and distance of turn by player
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
            Touch touch = Input.GetTouch(0);
            double radians = Math.Atan(touch.deltaPosition.x / (touch.deltaPosition.y)); //find theta (polar coordinates) using inverse Tangent and change in position since last update
            theta = radians;
            direction = (int)(radians / Math.Abs(radians));
        }
        else {
            theta = 0;
            direction = 0;
        }
    }
   void setDesiredDirection(int direction) {
        desiredDirection = direction;
    }
}

