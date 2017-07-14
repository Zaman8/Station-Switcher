using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonLoadScene : MonoBehaviour {

	public void loadNextScene(int index) {
        SceneManager.LoadScene(index);
    }
}
