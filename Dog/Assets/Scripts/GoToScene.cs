using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour {
  public KeyCode menuKey = KeyCode.M;
  public string sceneName;
  // Update is called once per frame
  void Update() {
    if (Input.GetKeyDown(menuKey)) {
      SceneManager.LoadScene(sceneName);
    }
  }
}
