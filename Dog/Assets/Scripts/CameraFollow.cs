using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
  public GameObject target;
  public float minY = 0f;
  public float maxY = 0f;
  public Vector2 displacement = new Vector2(Screen.width, Screen.height);

  // Update is called once per frame
  void Update() {
    var pos = transform.position;
    var tarPos = target.transform.position;

    transform.position = new Vector3(tarPos.x + displacement.x, Mathf.Max(minY, Mathf.Min(tarPos.y, maxY)) + displacement.y, pos.z);
  }
}
