using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public enum GameState { MENU, GAME, PAUSE, ENDGAME, RESET };

    public GameState gameState { get; private set; }
    public int vidas;
    public int pontos;
    public int resetar = 0;
    public int powerup = 0;

    private static GameManager _instance;

    public static GameManager GetInstance() {
        if(_instance == null)
        {
            _instance = new GameManager();
        }

        return _instance;
    }
    private GameManager() {
        vidas = 3;
        pontos = 0;
        gameState = GameState.MENU;
    }

    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;

    
    public void ChangeState(GameState nextState) {
        if (nextState == GameState.GAME) Reset();
        gameState = nextState;
        changeStateDelegate();
        if (resetar > 0) {
            resetar--;
        }
    }

    private void Reset() {
        vidas = 3;
        pontos = 0;
    }
}
