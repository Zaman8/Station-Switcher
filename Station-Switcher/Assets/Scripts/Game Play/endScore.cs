using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class endScore : MonoBehaviour {
    Text text;
    [SerializeField]
    GameObject PauseMenu;
    [SerializeField]
    GameObject Scoring;

    // Use this for initialization
    void Awake() {
        text = this.gameObject.GetComponent<Text>();
        roundManager.Lost += showScore;
        PauseMenu.SetActive(false);
        Scoring.SetActive(false);
    }

    void showScore(int round) {
        text.text = string.Format("{0}", round);
    }
}
