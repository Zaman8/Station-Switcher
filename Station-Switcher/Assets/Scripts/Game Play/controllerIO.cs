using UnityEngine;
using System.Collections;

public class controllerIO : MonoBehaviour {
    Rigidbody2D dial;
    private int dir = 1;
    [SerializeField]
    private float dialSpeed = 1;
    [SerializeField]
    private float rotSpeed = 1;

    // Use this for initialization
    void Start () {
        dial = GameObject.FindGameObjectWithTag("Dial").GetComponent<Rigidbody2D>();
        roundManager.newRound += direction;

	}
	
	// Update is called once per frame
	void FixedUpdate () {  
        int rotation = (int)Input.GetAxisRaw("Horizontal");
        if(rotation == dir && dial.transform.position.x > -2.83 && dial.transform.position.x < 4.795 && !pause.paused) { 
            gameObject.GetComponent<Rigidbody2D>().MoveRotation(gameObject.GetComponent<Rigidbody2D>().rotation + (-1*(dir * rotSpeed)));
            dial.MovePosition(new Vector2(dial.position.x + (dir * dialSpeed), dial.position.y));
        }
	}

    void direction(dialDetect tick) {
        if (tick.gameObject.transform.position.x > dial.gameObject.transform.position.x) {
            dir = 1;
        }
        else {
            dir = -1;
        }
    }
}
