using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStorage : MonoBehaviour {
  void Awake() {
    if (GameObject.FindGameObjectsWithTag("DataStorage").Length > 1) {
      Destroy(gameObject);
    } else {
      DontDestroyOnLoad(this.gameObject);
    }
  }
}
