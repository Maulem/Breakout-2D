using UnityEngine;
using UnityEngine.UI;


public class PauseUI : MonoBehaviour {

    GameManager gm;

    private void OnEnable() {
        gm = GameManager.GetInstance();
    }
    
    public void Retornar() {
        gm.ChangeState(GameManager.GameState.GAME);
    }

    public void Inicio() {
        gm.ChangeState(GameManager.GameState.MENU);
        gm.resetar = 3;
    }
}