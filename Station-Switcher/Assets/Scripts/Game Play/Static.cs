using UnityEngine;
using System.Collections;

public class Static : MonoBehaviour {
    Transform tick;
    Transform dial;
    AudioSource Audio;
    bool stop = false;

    // Use this for initialization
    void Start() {
        roundManager.newRound += getTick;
        roundManager.Lost += isStopped;

        Audio = this.gameObject.GetComponent<AudioSource>();
        dial = gameObject.GetComponent<Transform>();

    }

    void FixedUpdate() {
        if (!stop && !pause.paused && !Params.Mute) {
            float volume = (Mathf.Abs(tick.position.x - dial.position.x) < 5) ? 1 - (1 - (Mathf.Abs(tick.position.x - dial.position.x) * 2.5f)) : 0.99f;
            Audio.volume = volume;
        } else
            Audio.volume = 0;
    }

    void getTick(dialDetect tick) {
        this.tick = tick.gameObject.transform;
    }

    void isStopped(int useless) {
        stop = true;
    }
}
