using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class roundDisplay : MonoBehaviour {
    Text text;

	// Use this for initialization
	void Awake() {
        text = this.GetComponent<Text>();
        roundManager.GUIupdate += roundRefresh;
	}
	
	void roundRefresh(double time, int round) {
        string rounddisplay = string.Format("Round: {0}", round);
        text.text = rounddisplay;
    }
}
