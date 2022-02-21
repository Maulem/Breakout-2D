using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RacketMov : MonoBehaviour {
    [Range(1, 15)]
    public float velocidade = 5.0f;
    GameManager gm;
    SpriteRenderer Rend;

    float r, g, b;
    int rf = 0, gf = 0, bf = 0;

    float sizex = 0.05f;
    float sizex2 = 0.95f;
    
    Color rgb;

    Vector2 originalPos;

    private void OnTriggerEnter2D(Collider2D col) {
        GetComponent<AudioSource>().Play();
    }

    // Start is called before the first frame update
    void Start() {
        gm = GameManager.GetInstance();
        Rend = GetComponent<SpriteRenderer>();
        r = Random.Range(0f, 1f);
        g = Random.Range(0f, 1f);
        b = Random.Range(0f, 1f);
        rgb = new Color(r, g, b);

        originalPos = Camera.main.WorldToViewportPoint(transform.position);


    }

    // Update is called once per frame
    void Update() {
        
        // primeira execução nas rotinas de Update() da Bola e Raquete.
        if (gm.gameState != GameManager.GameState.GAME) return;


        Vector2 posicaoViewport = Camera.main.WorldToViewportPoint(transform.position);

        float inputX = Input.GetAxis("Horizontal");

        if( posicaoViewport.x > sizex && inputX < 0 ) {
            transform.position += new Vector3(inputX, 0, 0) * Time.deltaTime * velocidade;
        }
        if( posicaoViewport.x < sizex2 && inputX > 0) {
            transform.position += new Vector3(inputX, 0, 0) * Time.deltaTime * velocidade;
        }

        if (gm.powerup == 1) {
            Rend.transform.localScale = new Vector2(6, 0.25f);
            sizex = 0.15f;
            sizex2 = 0.85f;
            gm.powerup = 0;
        }
        
        // Debug.Log($"OUT2: {posicaoViewport.x}");

        if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME) {
            gm.ChangeState(GameManager.GameState.PAUSE);
        }

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

        if (gm.resetar == 2) {
            Rend.transform.localScale = new Vector2(2, 0.25f);
            sizex = 0.05f;
            sizex2 = 0.95f;
            gm.resetar = 1;
        }

    }
}