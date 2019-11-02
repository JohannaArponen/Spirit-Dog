using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
  public GameObject target;

  // Update is called once per frame
  void Update() {
    var pos = transform.position;
    var tarPos = target.transform.position;

    transform.position = new Vector3(tarPos.x, pos.y, pos.z);
  }
}
