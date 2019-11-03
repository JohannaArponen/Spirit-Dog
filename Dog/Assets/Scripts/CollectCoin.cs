using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour {

  public int points = 100;
  void OnTriggerEnter2D(Collider2D col) {
    col.GetComponent<PointControl>().Points += points;
    Destroy(gameObject);
  }
}
