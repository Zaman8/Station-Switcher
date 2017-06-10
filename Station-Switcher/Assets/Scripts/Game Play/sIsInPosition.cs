using UnityEngine;
using System.Collections;

public class sIsInPosition : MonoBehaviour {
    sNextStation nextStation;
    GameObject station;
    bool rightStation = false;

    sEndRound endRound;

    private void Awake() {
        nextStation = GameObject.FindGameObjectWithTag("Master").GetComponent<sNextStation>();
        do {
            station = nextStation.station;
        } while (nextStation.station == null); //make sure we are setting to something that exists (we could run this before we get to nextstation)
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject == station) { //if we enter the correct dial run this
            rightStation = true; //set righstation true
            StartCoroutine(wait()); //wait for x secs 
            if (rightStation) { //check if we're still in right station
                if (endRound.complete == false) { //if the time isn't up
                    endRound.complete = true; //set round as complete
                    endRound.endRound(true); //and end it
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        rightStation = false; //if we exit anything (especialy including the right station) set the right station to false
    }

    IEnumerator wait() {
        yield return new WaitForSeconds(0.8f); //time to wait
        yield break; 
    }

}
