using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindGround : MonoBehaviour {
  public float offset = 0f;
  public float maxDistance = 10f;
  // Start is called before the first frame update
  void Start() {
    var hit = Physics2D.Raycast(transform.position, Vector2.down, maxDistance, 1 << LayerMask.NameToLayer("Tiles"));
    if (hit) {
      gameObject.transform.position = new Vector3(transform.position.x, hit.point.y + offset, transform.position.z);
    }
  }
}
