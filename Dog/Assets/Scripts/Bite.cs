using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bite : MonoBehaviour {
  public KeyCode bite = KeyCode.X;
  public float biteDuration = 1f;
  public float biteCooldown = 1;
  private float lastBite = 0f;
  public AudioSource audioData;
  public bool biting = false;
  // Update is called once per frame
  void Update() {

    biting = Time.time - biteDuration <= lastBite;

    if (Input.GetKey(bite)
      && Time.time - biteCooldown > lastBite) {
      audioData.Play();
      lastBite = Time.time;
    }
  }
}
