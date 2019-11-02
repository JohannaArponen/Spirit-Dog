using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointControl : MonoBehaviour {
  public UnityEngine.UI.Text text;
  private int points;

  public int Points {
    get => points; set {
      points = value;
      UpdatePoints();
    }
  }

  // Start is called before the first frame update
  void Start() {
    UpdatePoints();
  }

  // Update is called once per frame
  void UpdatePoints() {
    text.text = points.ToString();
  }
}
