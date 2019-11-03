using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatWalk : MonoBehaviour {
  public float jumpRayTest = 0.05f;
  public float speed = 1f;
  private BoxCollider2D col;
  private SpriteRenderer sr;
  // Start is called before the first frame update
  void Start() {
    col = GetComponent<BoxCollider2D>();
    sr = GetComponent<SpriteRenderer>();
    sr.flipX = true;
  }

  // Update is called once per frame
  void Update() {
    var floorTestLeft = Physics2D.Raycast(transform.position - new Vector3(col.size.x / 2, col.size.y / 2), Vector2.down, jumpRayTest, 1 << 9);
    var floorTestRight = Physics2D.Raycast(transform.position - new Vector3(-col.size.x / 2, col.size.y / 2), Vector2.down, jumpRayTest, 1 << 9);

    if (!floorTestRight && !floorTestLeft) {
      transform.Translate(0, -jumpRayTest, 0); // Move down untill colliding with something
    } else if (!floorTestLeft) {
      speed = Mathf.Abs(speed);
      sr.flipX = true;
    } else if (!floorTestRight) {
      speed = -Mathf.Abs(speed);
      sr.flipX = false;
    }

    transform.Translate(speed * Time.deltaTime, 0, 0);
  }
}
