using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
  public KeyCode pause = KeyCode.Escape;
  public KeyCode pause2 = KeyCode.P;
  public bool paused = false;
  public GameObject pauseGUI;
  public GameObject pauseGUISecondary;
  public GameObject player;
  private Player playerScript;

  public float pauseMusicPitch = 0.5f;
  public float pitchSlowSpeed = 0.5f;
  public AudioSource music;

  private bool pitchChangeFinish = true;
  private float lastPress = 0f;

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
    if (lastPress < Time.realtimeSinceStartup - 0.1f && (Input.GetKeyDown(pause) || Input.GetKeyDown(pause2))) {
      lastPress = Time.realtimeSinceStartup;
      if (paused) {
        UnPause();
      } else {
        PauseGame();
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
    pauseGUISecondary.SetActive(false);
    paused = false;
    pitchChangeFinish = false;
  }
}
