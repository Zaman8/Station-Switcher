using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class endScore : MonoBehaviour {
    Text text;

    // Use this for initialization
    void Awake() {
        text = this.gameObject.GetComponent<Text>();
        roundManager.Lost += showScore;
    }

    void showScore(int round) {
        Debug.Log("here mf");
        text.text = string.Format("{0}", round);
    }
}
