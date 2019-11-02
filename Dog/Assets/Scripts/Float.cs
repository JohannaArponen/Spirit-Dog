using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour {
  public Vector3 relativeStart;
  public Vector3 relativeEnd;

  private Vector3 start;
  private Vector3 end;
  // Start is called before the first frame update
  void Start() {
    start = transform.position + relativeStart;
    end = transform.position + relativeEnd;
  }

  // Update is called once per frame
  void Update() {
    transform.position = Vector3.Lerp(start, end, (Mathf.Sin(Time.time * 2) + 1) / 2);
  }
}
