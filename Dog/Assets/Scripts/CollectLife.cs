using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectLife : MonoBehaviour {
  void OnTriggerEnter2D(Collider2D col) {
    if (col.tag == "Player") {
      col.GetComponent<LifeControl>().lives++;
      Destroy(gameObject);
    }
  }
}
