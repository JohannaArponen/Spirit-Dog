using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateVolume : MonoBehaviour {
  public void ChangeVolume(float value) {
    AudioListener.volume = value;
  }
}
