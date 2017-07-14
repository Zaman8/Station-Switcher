using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class timeDisplay : MonoBehaviour {
    Text text;

	// Use this for initialization
	void Awake() {
        text = this.GetComponent<Text>();
        roundManager.GUIupdate += timeRefresh;
	}
	
	void timeRefresh(double time, int round) {
        string strTime = string.Format("{0:N3}", time);
        char[] charTime = strTime.ToCharArray();
        text.text = string.Format("{0} {1}{2}", charTime[0], charTime[2], charTime[3]);
    }
}
