using UnityEngine;
using System.Collections;

public class sEndRound : MonoBehaviour {
    //use this class to determine if the player passed the round or not, and appriorately react
    Transform stationDial;
    float station;
    sNextStation nextStation;
    public int Round;
    public bool complete; //true when the player fails or passes (ie. completes the round)

    private void Awake() {
        stationDial = GameObject.FindGameObjectWithTag("Station Dial").transform;
        nextStation = GameObject.FindGameObjectWithTag("Master").GetComponent<sNextStation>();
        station = nextStation.getStationPosition();
        startRound();
    }

    private void startRound() { //called on awake and for the start of each round
        Round++; //add one round to the counter, so we know where we are
        complete = false;
        float roundTime = Round < 5 ? 4: (4-(Round/20)); //if round is less than 5 than the player has 4 secs, over 5 and they have formula
        nextStation.nextStation();//determine next station (which will be passed onto dial in method)
        StartCoroutine(CountDown(roundTime)); //start countdown

    }

    public IEnumerator CountDown(float time) { //timer for round, time is given based on round
        float currTime = time;
        while (currTime > 0 && complete == false) {
            UpdateGUI(); //update GUI for display
            yield return new WaitForSeconds(0.01f); //Wait for 1 thousandeth of a sec
            currTime--;
            if (complete == true)
                break;
        }
        if (complete == false) {
            complete = true;
            endRound(false); //when time is < 0 end the round with a fail
        }
    }

    private void UpdateGUI() {

    }

    public void endRound(bool pass) {

    }

}
