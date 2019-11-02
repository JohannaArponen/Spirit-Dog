using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPumpkin : MonoBehaviour {
  void OnTriggerEnter2D(Collider2D col) {
    col.GetComponent<LifeControl>().lives--;
    gameObject.GetComponent<Animate>().enabled = true;
  }
}
