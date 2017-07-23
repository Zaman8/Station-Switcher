using UnityEngine;
using System.Collections;
using System;

public class audio : MonoBehaviour {
    dialDetect detect;
    private GameObject dial;
    public AudioClip[] songs;
    [SerializeField]
    private AudioClip stat;

    private void Awake() {
        detect = this.gameObject.GetComponent<dialDetect>();
        dial = GameObject.FindGameObjectWithTag("Dial");
    }
	
	IEnumerator Start() {
        while (true) {
            if (detect.iswinner) {
                AudioSource audio = GetComponent<AudioSource>(); //audio source, actually plays sounds

                int n = UnityEngine.Random.Range(0, songs.Length); //choose a random song
                songs[n].LoadAudioData(); //load that song
                    audio.clip = songs[n]; //set the source to that song
                    float length = audio.clip.length; //save its length for latter
                    float volume = 1 - (Math.Abs(this.gameObject.transform.position.x - dial.transform.position.x) / 6.75f); //scaled volume for the some, the close the dial gets to th dial the load it is
                    audio.PlayOneShot(songs[n], volume); //plays the song
                    float startTime = 0; //set the start time for that song
                    audio.clip = stat; //set the audio clip to static
                    while (startTime < length) { //while the song is playing do this
                        audio.PlayOneShot(stat, 1 - volume); //play the static (which is like 5 secs)
                        yield return new WaitForSeconds(audio.clip.length); //wait for the static to finish
                        startTime += audio.clip.length; //set the time to itself plus the static time; should stop around the same time as song and next dial takes control
                  }
               }
            }
        }
	}
