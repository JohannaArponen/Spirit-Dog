using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
  public float speed = 5f;
  public Vector2 velocity;
  public float gravity = 1f;
  public float drag = 0.05f;
  private BoxCollider2D col;

  public KeyCode jump = KeyCode.Space;
  public float jumpCooldown = 0.1f;
  private float lastJump = 0f;
  public float jumpStrength = 5f;
  public float jumpRayTest = 0.05f;

  void Start() {
    col = GetComponent<BoxCollider2D>();
  }

  // Update is called once per frame
  void Update() {

    if (Input.GetKey(jump)
      && Time.time - jumpCooldown > lastJump
      && velocity.y == 0
      && Physics2D.Raycast(transform.position - new Vector3(0, col.size.y / 2), Vector2.down, jumpRayTest, 1 << 9)) {
      velocity.y += jumpStrength;
      lastJump = Time.time;
    }

    velocity.x += speed * Time.deltaTime;
    velocity.y -= gravity * Time.deltaTime;
    float multiplier = Mathf.Max(0f, 1f - drag * Time.deltaTime);
    velocity = multiplier * velocity;

    RaycastHit2D floorHit = Physics2D.Raycast(transform.position - new Vector3(0, col.size.y / 2), Vector2.down, -velocity.y, 1 << 9);

    if (floorHit && velocity.y < 0) {
      velocity.y = 0;
      transform.position = new Vector3(transform.position.x, floorHit.point.y + col.size.y / 2, transform.position.z);
    }


    transform.position += new Vector3(velocity.x, velocity.y, 0);
  }
}
