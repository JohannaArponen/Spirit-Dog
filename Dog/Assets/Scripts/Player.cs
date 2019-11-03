using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  public float speed = 5f;
  public Vector2 velocity;
  public float gravity = 1f;
  public float drag = 0.05f;
  public AnimateForPlayer runAnim;
  public float runAnimSpeedMult = 1f;
  public Animate jumpAnim;
  public AudioSource jumpSound;
  public Animate biteAnim;
  public Animate deathAnim;
  public float deathMusicPitch = 0.2f;
  public float pitchSlowSpeed = 0.5f;
  public AudioSource music;
  public Animate hurtAnim;
  public AudioSource hurtSound;
  public float hurtDuration = 0.5f;
  private float hurtUntil = 0f;
  public Vector2 onHurtPush = new Vector2(-0.1f, -0.2f);
  private BoxCollider2D col;
  private Pause pause;

  public KeyCode jump = KeyCode.Space;
  public float jumpCooldown = 0.1f;
  private float lastJump = 0f;
  public float jumpStrength = 5f;
  public float jumpRayTest = 0.05f;

  private LifeControl lc;
  private Bite bite;
  private bool dead = false;

  public GameObject winScreen;
  public GameObject loseScreen;

  void Start() {
    col = GetComponent<BoxCollider2D>();
    lc = GetComponent<LifeControl>();
    bite = GetComponent<Bite>();
    jumpAnim.frameTime = float.PositiveInfinity;
  }

  void FixedUpdate() {
    float multiplier = Mathf.Max(0f, 1f - drag * Time.deltaTime);
    velocity = multiplier * velocity;
  }

  // Update is called once per frame
  void Update() {
    if (Input.GetKey(jump)
      && !dead
      && Time.time - jumpCooldown > lastJump
      && velocity.y == 0
      && (
        Physics2D.Raycast(transform.position - new Vector3(0, col.size.y / 2), Vector2.down, jumpRayTest, 1 << 9)
        || Physics2D.Raycast(transform.position - new Vector3(col.size.x / 2, col.size.y / 2), Vector2.down, jumpRayTest, 1 << 9)
        || Physics2D.Raycast(transform.position - new Vector3(-col.size.x / 2, col.size.y / 2), Vector2.down, jumpRayTest, 1 << 9)
      )) {
      jumpSound.Play();
      velocity.y += jumpStrength;
      lastJump = Time.time;
    }

    velocity.x += speed * Time.deltaTime;
    velocity.y -= gravity * Time.deltaTime;

    RaycastHit2D floorHit = Physics2D.Raycast(transform.position - new Vector3(0, col.size.y / 2), Vector2.down, -velocity.y, 1 << 9);
    if (!floorHit) {
      floorHit = Physics2D.Raycast(transform.position - new Vector3(col.size.x / 2, col.size.y / 2), Vector2.down, -velocity.y, 1 << 9);
      if (!floorHit) {
        floorHit = Physics2D.Raycast(transform.position - new Vector3(-col.size.x / 2, col.size.y / 2), Vector2.down, -velocity.y, 1 << 9);
      }
    }
    // Good animation system in work
    if (dead) {
      music.pitch = Mathf.Max(deathMusicPitch, music.pitch - pitchSlowSpeed * Time.deltaTime);
      deathAnim.enabled = true;
      runAnim.enabled = false;
      biteAnim.enabled = false;
      jumpAnim.enabled = false;
      hurtAnim.enabled = false;
      deathAnim.index = deathAnim.index;
    } else if (bite.biting) {
      deathAnim.enabled = false;
      runAnim.enabled = false;
      biteAnim.enabled = true;
      jumpAnim.enabled = false;
      hurtAnim.enabled = false;
      biteAnim.index = biteAnim.index;
      biteAnim.frameTime = 1 / (velocity.x * runAnimSpeedMult);
    } else if (hurtUntil < Time.time) {
      if (floorHit) {
        deathAnim.enabled = false;
        runAnim.enabled = true;
        biteAnim.enabled = false;
        jumpAnim.enabled = false;
        hurtAnim.enabled = false;
        runAnim.index = runAnim.index;
        runAnim.frameTime = 1 / (velocity.x * runAnimSpeedMult);
      } else {
        deathAnim.enabled = false;
        runAnim.enabled = false;
        jumpAnim.enabled = true;
        hurtAnim.enabled = false;
        biteAnim.enabled = false;
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
      hurtSound.Play();
      hurtUntil = Time.time + hurtDuration;
      runAnim.enabled = false;
      jumpAnim.enabled = false;
      hurtAnim.enabled = true;
      hurtAnim.index = hurtAnim.index;
    }
    if (doPush) {
      velocity += onHurtPush;
      velocity = new Vector2(Mathf.Max(velocity.x, onHurtPush.x), Mathf.Min(velocity.y, onHurtPush.y));
    }
    if (lc.lives <= 0) {
      Death();
    }
  }

  public void Win() {
    if (!dead) {
      Camera.main.gameObject.GetComponent<CameraFollow>().enabled = false;
      speed = 0.2f;
      drag = 0.95f;
      winScreen.SetActive(true);
    }
  }

  public void Death() {
    Camera.main.gameObject.GetComponent<CameraFollow>().enabled = false;
    speed = 0f;
    drag = 0.99f;
    dead = true;
    loseScreen.SetActive(true);
  }
}
