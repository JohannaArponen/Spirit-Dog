using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CollectStatue : MonoBehaviour {
  public AudioSource rollSound;
  public Vector2 pushForce = new Vector2(1, 0.5f);
  public float rotateForce = 1f;
  public float collisionTimer = 2f;
  public float deathTimer = 2f;
  private float hitTime = 0f;
  private bool colliding = true;

  void OnTriggerEnter2D(Collider2D col) {
    if (col.tag == "Player") {
      if (hitTime == 0) {
        Player player = col.GetComponent<Player>();
        gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
        var rb = gameObject.GetComponent<Rigidbody2D>();
        gameObject.layer = LayerMask.NameToLayer("CollideWithTiles");
        rb.isKinematic = false;
        rb.velocity += pushForce * player.velocity;
        rb.rotation += rotateForce;
        hitTime = Time.time;
        player.Hurt(1);
        if (rollSound != null)
          rollSound.Play();
      }
    }
  }

  void Update() {
    if (hitTime != 0) {
      if (colliding && Time.time - collisionTimer > hitTime) {
        GetComponent<CircleCollider2D>().enabled = false;
      }
      if (Time.time - collisionTimer - deathTimer > hitTime) {
        Destroy(gameObject);
      }
    }
  }
}
