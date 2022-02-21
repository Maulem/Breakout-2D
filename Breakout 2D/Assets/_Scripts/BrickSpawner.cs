using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour {
    
    public GameObject Block;
    public GameObject BlockSpecial;
    GameManager gm;

    void Start() {
        gm = GameManager.GetInstance();
        GameManager.changeStateDelegate += Construir;
        Construir();
    }

    void Construir() {
        if (gm.gameState == GameManager.GameState.GAME) {
            foreach (Transform child in transform) {
                GameObject.Destroy(child.gameObject);
            }
            for(int i = 0; i < 12; i++) {
                for(int j = 0; j < 4; j++) {
                    int special = Random.Range(0, 10);

                    Vector3 posicao = new Vector3(-8.5f + 1.55f * i, 4 - 0.55f * j);

                    if (special == 0 || special == 1) {
                        GameObject brickobj = (GameObject)Instantiate(BlockSpecial, posicao, Quaternion.identity, transform);

                        brickobj.GetComponent<BrickSpecial>().life = 0;

                    } else {
                        GameObject brickobj = (GameObject)Instantiate(Block, posicao, Quaternion.identity, transform);
                        int life = (j - 3) * -1;

                        brickobj.GetComponent<Brick>().life = life;
                        switch (life) {
                            case 0:
                                brickobj.GetComponent<Brick>().blockColor = brickobj.GetComponent<Brick>().g1;
                                break;
                            case 1:
                                brickobj.GetComponent<Brick>().blockColor = brickobj.GetComponent<Brick>().g2;
                                break;
                            case 2:
                                brickobj.GetComponent<Brick>().blockColor = brickobj.GetComponent<Brick>().g3;
                                break;
                            default:
                                brickobj.GetComponent<Brick>().blockColor = brickobj.GetComponent<Brick>().g4;
                                break;
                        }
                    }
                }
            }
        }
    }

    void Update() {
        if (transform.childCount <= 0 && gm.gameState == GameManager.GameState.GAME) {
            gm.ChangeState(GameManager.GameState.ENDGAME);
        }
    }
}
