using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPumpkin : MonoBehaviour {
  public AudioSource audioData;
  private bool wasHit = false;

  void OnTriggerEnter2D(Collider2D col) {
    if (col.tag == "Player") {
      if (!wasHit) {
        col.GetComponent<Player>().Hurt(1);
        gameObject.GetComponent<Animate>().enabled = true;
        if (audioData != null)
          audioData.Play();
        wasHit = true;
      }
    }
  }
}
