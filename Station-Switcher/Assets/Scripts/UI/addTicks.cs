using UnityEngine;
using System.Collections;

public class addTicks : MonoBehaviour {
    private float space = 0;
    public GameObject fullTick;
    public GameObject halfTick;
    public int numTicks;
	// Use this for initialization

	void Awake () {
        space = (this.GetComponent<Renderer>().bounds.size.x) / numTicks; //distance between each tick is equal and takes up full length of slider

        for (int i = 0; i < numTicks; i++) { //loop adds each tick, evens being full oods being half,
            GameObject thing;
            if (i % 2 == 0)
                thing = fullTick;
            else
                thing = halfTick;
           Vector3 pos = new Vector3((float)(-3.795 + space * i), (float)0.15, 0); //position of each tick is the space between each starting at the left end of the slider
            
           GameObject tick = Instantiate(thing); //create tick
            tick.transform.parent = this.transform; //make slider parent of slider
            tick.transform.localPosition = pos; //move the tick to the correct position
        }
	}
	
}
