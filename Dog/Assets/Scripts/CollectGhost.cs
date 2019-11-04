using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGhost : MonoBehaviour {
  public int points = 500;
  public float floatUpwardsSpeed = 4f;
  public float waveIncreaseDivisor = 4;
  private float hitTime = 0f;
  private float upVelocity = 0f;
  private float floatTime = 0f;
  public float deathTimer = 4f;
  public AudioSource saveSound;

  void Update() {
    if (hitTime > 0) {
      if (Time.time - deathTimer > hitTime) {
        Destroy(gameObject);
      }
      floatTime += Time.deltaTime;
      upVelocity += floatUpwardsSpeed * Time.deltaTime;
      transform.Translate(Mathf.Sin(Time.time * floatTime / waveIncreaseDivisor), upVelocity, 0);
    }
  }

  void OnTriggerEnter2D(Collider2D col) {
    if (col.tag == "Player") {
      if (col.GetComponent<Bite>().biting) {
        col.GetComponent<PointControl>().Points += points;
        GetComponent<CircleCollider2D>().enabled = false;
        hitTime = Time.time;
        if (saveSound != null)
          saveSound.Play();
      }
    }
  }
}
