using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeControl : MonoBehaviour {
  [SerializeField]
  private int _lives = 3;
  public GameObject lifeElement;
  public Canvas canvas;
  public float gap = 25;
  private List<GameObject> elements = new List<GameObject>();

  public int lives {
    get => _lives; set {
      _lives = value;
    }
  }

  void Start() {
    UpdateHearts();
  }

  void UpdateHearts() {
    foreach (var element in elements) {
      DestroyImmediate(element);
    }
    elements.Clear();

    for (int i = 0; i < lives; i++) {
      var element = Instantiate(lifeElement, lifeElement.transform.position, lifeElement.transform.rotation);
      element.transform.SetParent(canvas.transform, false);

      var rect = element.GetComponent<RectTransform>();
      rect.anchoredPosition -= new Vector2(i * (gap + rect.sizeDelta.x), 0);
    }
  }
}
