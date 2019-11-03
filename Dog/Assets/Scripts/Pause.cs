using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
  public KeyCode pause = KeyCode.Escape;
  public KeyCode pause2 = KeyCode.P;
  public bool paused = false;
  public GameObject pauseGUI;
  public GameObject player;
  private Player playerScript;

  public float pauseMusicPitch = 0.5f;
  public float pitchSlowSpeed = 0.5f;
  public AudioSource music;

  private bool pitchChangeFinish = true;

  void Start() {
    playerScript = player.GetComponent<Player>();
    if (paused) {
      PauseGame();
    } else {
      UnPause();
    }
  }
  void Update() {
    FixedUpdate();
  }

  void FixedUpdate() {

    if (!pitchChangeFinish) {
      if (paused) {
        music.pitch = Mathf.Max(pauseMusicPitch, music.pitch - pitchSlowSpeed * 0.05f);
        if (music.pitch == pauseMusicPitch) {
          pitchChangeFinish = true;
        }
      } else {
        music.pitch = Mathf.Min(1, music.pitch + pitchSlowSpeed * 0.05f);
        if (music.pitch == 1) {
          pitchChangeFinish = true;
        }
      }
    }
    if (Input.GetMouseButton(0) || Input.GetMouseButton(1)) {
      if (paused) {
        UnPause();
      }
    } else if (Input.GetKeyDown(pause) || Input.GetKeyDown(pause2)) {
      if (paused) {
        UnPause();
      } else {
        PauseGame();
      }
    } else {
      if (paused) {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
          UnPause();
        };
      }
    }
  }

  void PauseGame() {
    playerScript.enabled = false;
    Time.timeScale = 0f;
    pauseGUI.SetActive(true);
    paused = true;
    pitchChangeFinish = false;
  }

  void UnPause() {
    playerScript.enabled = true;
    Time.timeScale = 1f;
    pauseGUI.SetActive(false);
    paused = false;
    pitchChangeFinish = false;
  }
}
