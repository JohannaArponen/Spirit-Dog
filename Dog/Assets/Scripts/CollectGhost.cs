using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGhost : MonoBehaviour {
  public int points = 500;
  void OnTriggerEnter2D(Collider2D col) {
    if (col.GetComponent<Bite>().biting) {
      col.GetComponent<PointControl>().Points += points;
      Destroy(gameObject);
    }
  }
}
