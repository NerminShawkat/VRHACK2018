using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	public void SwitchScene()
    {
        SceneManager.LoadScene("scene_12");
    }
}
