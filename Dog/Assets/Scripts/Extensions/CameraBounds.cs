using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CameraBounds {
  public static float LowerBound(this Camera parent) => parent.transform.position.y - parent.orthographicSize;
  public static float UpperBound(this Camera parent) => parent.transform.position.y + parent.orthographicSize;

  public static float RightBound(this Camera parent) => parent.transform.position.x + parent.orthographicSize * parent.aspect;
  public static float LeftBound(this Camera parent) => parent.transform.position.x - parent.orthographicSize * parent.aspect;
}
