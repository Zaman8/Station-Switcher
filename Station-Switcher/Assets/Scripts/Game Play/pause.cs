using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class pause : MonoBehaviour {
    public static bool paused = false;
    public GameObject pauseMenu;

    public void clicked() {
        if (!paused) {
            Time.timeScale = 0;
            paused = true;
            pauseMenu.SetActive(true);
        } else {
            Time.timeScale = 1;
            paused = false;
            pauseMenu.SetActive(false);
        }
    }
}
