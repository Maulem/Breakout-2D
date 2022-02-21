using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick: MonoBehaviour {

    public Color g1 = new Color(0.17f, 1, 40);
    public Color g2 = new Color(0.13f, 0.80f, 30);
    public Color g3 = new Color(0.10f, 0.55f, 20);
    public Color g4 = new Color(0.06f, 0.35f, 10);

    public int life = 1;

    public Color blockColor = Color.white;
    SpriteRenderer Rend;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (life > 0) {
            life--;
        }
        else {
            Destroy(gameObject);
        }
        switch (life) {
            case 0:
                blockColor = g1;
                break;
            case 1:
                blockColor = g2;
                break;
            case 2:
                blockColor = g3;
                break;
            default:
                blockColor = g4;
                break;
        }
    }

    void Start() {
        Rend = GetComponent<SpriteRenderer>();
        Rend.color = blockColor;
    }

    void Update() {
        Rend.color = blockColor;
    }
}
