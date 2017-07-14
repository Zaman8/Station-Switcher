using UnityEngine;
using System.Collections;

public class roundManager : MonoBehaviour {
    private int roundNum = 0; //keep track of rounds
    private double time = 8; //time left in round
    private bool lost = false; //control to end previous timer so we can start new

    public delegate void startNewRound(dialDetect winner);
    public static event startNewRound newRound; //event for ticks to reset and controller to calcuate direction

    public delegate void updateGUI(double timer, int round);
    public static event updateGUI GUIupdate; //event for the scoring gui to update the timer and round display

    public delegate void playstate(int round);
    public static event playstate Lost;

    // Use this for initialization
    void Start() {
        dialDetect.scored += newRoundman; //call newRoundman when the ticks return a win/score
        bool pass = false;
        while (!pass) {
            if (GameObject.FindGameObjectsWithTag("tick").Length > 0)
                pass = true;
        }
        newRoundman();
    }

    private void newRoundman() {
        roundNum++; //add 1 to round number

        int tickNum = GameObject.FindGameObjectsWithTag("tick").Length; //chose a new tick to be correct
        //Debug.Log("tickNum = " + tickNum);
        dialDetect[] potientalwinners = new dialDetect[tickNum];
        for (int i = 0; i < tickNum; i++) {
            potientalwinners[i] = GameObject.FindGameObjectsWithTag("tick")[i].GetComponent<dialDetect>(); //assign each dialDetect script from the tick gameobjects
        }
        int theChosenOne = Random.Range(0, potientalwinners.Length);
        Debug.Log("chosen one " + theChosenOne);

        newRound(potientalwinners[theChosenOne]); //call the newround event (sets ticks to false) 
        potientalwinners[theChosenOne].iswinner = true; //set the chosen tick bool to true and set dir
        potientalwinners[theChosenOne].gameObject.GetComponent<SpriteRenderer>().color =  new Color(1f, 0f, 1f, 0.5f); //debuging purposes to tell which tick is the winner

        time = 8 - (roundNum/4);

    }

    private void Lose() {
        lost = true;
        Lost(roundNum);
        Debug.Log("You lost");
    }

    private void Update() {
        if (!lost) {
            time -= Time.deltaTime;
            GUIupdate(time, roundNum);

            if (time <= 0)
                Lose();
        }
    }
}
