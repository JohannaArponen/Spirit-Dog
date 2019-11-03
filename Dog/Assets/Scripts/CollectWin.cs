﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectWin : MonoBehaviour {
  public AudioSource audioData;

  void OnTriggerEnter2D(Collider2D col) {
    col.GetComponent<Player>().Win();
    if (audioData != null)
      audioData.Play();
  }
}
