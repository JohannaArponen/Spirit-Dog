using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCat : MonoBehaviour {
  public AudioSource audioData;
  public Animate hitAnim;
  public Animate defaultAnim;
  private bool wasHit = false;

  void OnTriggerEnter2D(Collider2D col) {
    if (!wasHit) {
      col.GetComponent<Player>().Hurt(1);
      hitAnim.enabled = true;
      defaultAnim.enabled = false;
      GetComponent<CatWalk>().enabled = false;
      GetComponent<SpriteRenderer>().flipX = false;
      if (audioData != null)
        audioData.Play();
      wasHit = true;
    }
  }

}
