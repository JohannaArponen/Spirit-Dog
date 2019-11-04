using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour {

  public Block[] blocks;

  private int nextX;
  private GameObject target;

  [System.Serializable]
  public struct Block {
    [Range(0f, 1f)]
    public float chance;
    public GameObject tile;
    public int width;
    public Vector3 offset;
  }

  void Start() {
    target = Camera.main.gameObject;
    nextX = Mathf.FloorToInt(target.transform.position.x);
  }

  // Update is called once per frame
  void Update() {
    if (nextX < Mathf.FloorToInt(target.transform.position.x)) {
      foreach (var block in blocks) {
        if (Random.value < block.chance) {
          var inst = Instantiate(block.tile, transform.position, Quaternion.identity);
          inst.transform.position = new Vector3(inst.transform.position.x, inst.transform.position.y, 0) + block.offset;
          nextX = Mathf.FloorToInt(target.transform.position.x) + block.width - 1;
          break;
        }
      }
      nextX = Mathf.Max(nextX, Mathf.FloorToInt(target.transform.position.x));
    }
  }
}
