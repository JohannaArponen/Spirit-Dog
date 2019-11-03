using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  public float speed = 5f;
  public Vector2 velocity;
  public float gravity = 1f;
  public float drag = 0.05f;
  public Animate runAnim;
  public float runAnimSpeedMult = 1f;
  public Animate jumpAnim;
  public Animate hurtAnim;
  public float hurtDuration = 0.5f;
  private float hurtUntil = 0f;
  public Vector2 onHurtPush = new Vector2(-0.1f, -0.2f);
  private BoxCollider2D col;

  public KeyCode jump = KeyCode.Space;
  public float jumpCooldown = 0.1f;
  private float lastJump = 0f;
  public float jumpStrength = 5f;
  public float jumpRayTest = 0.05f;

  private LifeControl lc;

  void Start() {
    col = GetComponent<BoxCollider2D>();
    lc = GetComponent<LifeControl>();
    jumpAnim.frameTime = float.PositiveInfinity;
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
    if (hurtUntil < Time.time) {
      if (floorHit) {
        runAnim.enabled = true;
        jumpAnim.enabled = false;
        hurtAnim.enabled = false;
        runAnim.index = runAnim.index;
        runAnim.frameTime = 1 / (velocity.x * runAnimSpeedMult);
      } else {
        runAnim.enabled = false;
        jumpAnim.enabled = true;
        hurtAnim.enabled = false;
        jumpAnim.index = jumpAnim.index;
        if (velocity.y > 0) {
          jumpAnim.index = 0; // Jumpping up
        } else {
          jumpAnim.index = 1; // Jumping down
        }
      }
    }

    if (floorHit && velocity.y < 0) {
      velocity.y = 0;
      transform.position = new Vector3(transform.position.x, floorHit.point.y + col.size.y / 2, transform.position.z);
    }


    transform.position += new Vector3(velocity.x, velocity.y, 0);
  }

  public void Hurt(int num, bool doPush = true) {
    lc.lives -= num;
    if (num > 0) {
      hurtUntil = Time.time + hurtDuration;
      runAnim.enabled = false;
      jumpAnim.enabled = false;
      hurtAnim.enabled = true;
      hurtAnim.index = hurtAnim.index;
    }
    if (doPush) {
      velocity += onHurtPush;
    }
  }
}
