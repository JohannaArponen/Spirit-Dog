using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Animate : MonoBehaviour {

  public Sprite[] sprites;
  public float frameTime = 1;
  private int _index = 0;

  private SpriteRenderer sr;
  private float time = 0f;

  public int index {
    get => _index; set {
      _index = value;
      sr.sprite = sprites[_index];
    }
  }

  // Start is called before the first frame update
  void Start() {
    if (frameTime <= 0) {
      Debug.LogWarning("Frame time of animation 0. Setting to infinite");
      frameTime = float.PositiveInfinity;
    }
    sr = GetComponent<SpriteRenderer>();
    sr.sprite = sprites[_index];
  }

  // Update is called once per frame
  void Update() {
    time += Time.deltaTime;
    while (time > frameTime) {
      sr.sprite = sprites[_index];
      time -= frameTime;
      _index++;
      if (_index >= sprites.Length) {
        _index = 0;
      }
    }
  }
}
