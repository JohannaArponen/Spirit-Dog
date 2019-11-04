using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCat : MonoBehaviour {
  public AudioSource audioData;
  public Animate hitAnim;
  public Animate defaultAnim;
  private bool wasHit = false;

  void OnTriggerEnter2D(Collider2D col) {
    if (col.tag == "Player") {
      if (!wasHit) {
        col.GetComponent<Player>().Hurt(1);
        defaultAnim.enabled = false;
        hitAnim.enabled = true;
        hitAnim.index = hitAnim.index;
        GetComponent<CatWalk>().enabled = false;
        GetComponent<SpriteRenderer>().flipX = false;
        if (audioData != null)
          audioData.Play();
        wasHit = true;
      }
    }
  }
}
