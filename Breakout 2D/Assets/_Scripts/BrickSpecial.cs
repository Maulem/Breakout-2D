using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpecial: MonoBehaviour {

    public int life = 1;

    public Color blockColor = Color.white;
    SpriteRenderer Rend;

    float r, g, b;
    int rf = 0, gf = 0, bf = 0;
    Color rgb;
    float velocidade = 8;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (life > 0) {
            life--;
        }
        else {
            Destroy(gameObject);
        }
    }

    void Start() {
        Rend = GetComponent<SpriteRenderer>();
        r = Random.Range(0f, 1f);
        g = Random.Range(0f, 1f);
        b = Random.Range(0f, 1f);
        rgb = new Color(r, g, b);
    }

    void Update() {
        if (r >= 1) {
            rf = 1;
        }
        if (r <= 0.3) {
            rf = 0;
        }
        if (rf == 0) {
            r += 0.01f * Time.deltaTime * velocidade * 2;
        }
        else {
            r -= 0.01f * Time.deltaTime * velocidade * 2;
        }

        if (g >= 1) {
            gf = 1;
        }
        if (g <= 0.3) {
            gf = 0;
        }
        if (gf == 0) {
            g += 0.01f * Time.deltaTime * velocidade * 2;
        }
        else {
            g -= 0.01f * Time.deltaTime * velocidade * 2;
        }

        if (b >= 1) {
            bf = 1;
        }
        if (b <= 0.3) {
            bf = 0;
        }
        if (bf == 0) {
            b += 0.01f * Time.deltaTime * velocidade * 2;
        }
        else {
            b -= 0.01f * Time.deltaTime * velocidade * 2;
        }

        
        rgb = new Color(r, g, b);
        Rend.color = rgb;
    }

}
