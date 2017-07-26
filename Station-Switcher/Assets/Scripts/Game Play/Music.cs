using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {
    Transform tick;
    Transform dial;
    SpriteRenderer slide;

    AudioSource Audio;
    bool stop = false;

    // Use this for initialization
    void Start() {
        roundManager.newRound += getTick;
        roundManager.Lost += isStopped;

        Audio = this.gameObject.GetComponent<AudioSource>();
        dial = GameObject.FindGameObjectWithTag("Dial").GetComponent<Transform>();
        slide = GameObject.FindGameObjectWithTag("Slider").GetComponent<SpriteRenderer>();
        Audio.volume = 0;

    }

    void FixedUpdate() {
        if (!Params.Mute) {
            if (!stop && !pause.paused) {
                float volume = (Mathf.Abs(tick.position.x - dial.position.x) < 5) ? 1 - (Mathf.Abs(tick.position.x - dial.position.x) * 2.5f) : 0.01f;
                Audio.volume = volume;
            } else
                Audio.volume = 0;
        } else {
            if (!stop && !pause.paused) {
                slide.color = new Vector4(1, (Color.white.g - 1 /( Mathf.Abs(tick.position.x - dial.position.x) *5)), (Color.white.b - 1 / (Mathf.Abs(tick.position.x - dial.position.x) *5)), 1);
            }
        }
    }

    void getTick(dialDetect tick) {
        this.tick = tick.gameObject.transform;
    }

    void isStopped(int useless) {
        stop = true;
    }
}
