using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ReloadScene : MonoBehaviour {
  public KeyCode reload = KeyCode.R;
  // Update is called once per frame
  void Update() {
    if (Input.GetKeyDown(reload)) {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
  }
}
