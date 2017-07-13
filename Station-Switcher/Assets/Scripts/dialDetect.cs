using UnityEngine;
using System.Collections;

public class dialDetect : MonoBehaviour {
    public bool iswinner;
    private GameObject dial;
    private float timer;
    [SerializeField]
    private float waitTime;

    public delegate void newRound();
    public static event newRound scored;

    // Use this for initialization
    void Start () {
        dial = GameObject.FindGameObjectWithTag("Dial");
        iswinner = false;
        roundManager.newRound += Reset;
	}
	

    private void OnTriggerStay2D(Collider2D collision) {
        if(iswinner) {
            if(collision.gameObject == dial) {
                timer += Time.deltaTime;
                if(timer > waitTime)
                    scored();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject == dial)
            timer = 0;
    }

    private void Reset(dialDetect useless) {
        iswinner = false;
        timer = 0;
    }
}
