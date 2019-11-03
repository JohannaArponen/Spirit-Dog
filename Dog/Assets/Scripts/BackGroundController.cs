using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour {

  public float cameraStart;
  public float cameraEnd;

  public float bgStart;
  public float bgEnd;

  private float width;
  private float height;
  private new Camera camera;


  void Start() {
    camera = Camera.main;

    width = GetComponentInChildren<SpriteRenderer>().bounds.size.x;
    height = GetComponentInChildren<SpriteRenderer>().bounds.size.y;


  }

  // Update is called once per frame
  void Update() {

    transform.position = new Vector3(Mathf.Lerp(bgStart, bgEnd, (camera.transform.position.x - cameraStart) / (cameraEnd - cameraStart)), camera.transform.position.y + height / 2, transform.position.z);
  }
}
