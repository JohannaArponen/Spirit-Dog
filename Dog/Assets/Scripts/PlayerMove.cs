using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
  public float speed = 5f;
  public Vector2 velocity;
  public float gravity = 1f;
  public float drag = 0.05f;
  public BoxCollider2D col;

  public KeyCode jump = KeyCode.Space;
  public float jumpStrength = 5f;
  public float jumpRayTest = 0.01f;

  void Start() {
    col = GetComponent<BoxCollider2D>();
  }

  // Update is called once per frame
  void Update() {

    if (Input.GetKey(jump)
      && velocity.y <= 0
      && Physics2D.Raycast(transform.position - new Vector3(0, col.size.y / 2), Vector2.down, jumpRayTest, 1 << LayerMask.NameToLayer("Tiles"))) {
      velocity.y += jumpStrength;
    }

    velocity.x += speed * Time.deltaTime;
    velocity.y -= gravity * Time.deltaTime;
    float multiplier = Mathf.Max(0f, 1f - drag * Time.fixedDeltaTime);
    velocity = multiplier * velocity;

    RaycastHit2D floorHit = Physics2D.Raycast(transform.position - new Vector3(0, col.size.y / 2), Vector2.down, -velocity.y, 1 << LayerMask.NameToLayer("Tiles"));

    if (floorHit && velocity.y < 0) {
      velocity.y = 0;
      transform.Translate(0, floorHit.distance, 0);
    }


    transform.position += new Vector3(velocity.x, velocity.y, 0);
  }
}
