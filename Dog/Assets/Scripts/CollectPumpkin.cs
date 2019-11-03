using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPumpkin : MonoBehaviour {
  public AudioSource audioData;

  void OnTriggerEnter2D(Collider2D col) {
    if (!audioData.isPlaying) {
      col.GetComponent<Player>().Hurt(1);
      gameObject.GetComponent<Animate>().enabled = true;
      if (audioData != null)
        audioData.Play();
    }
  }
}
