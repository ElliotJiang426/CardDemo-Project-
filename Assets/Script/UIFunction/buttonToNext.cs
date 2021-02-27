using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonToNext : MonoBehaviour
{
    static public int playerSnum;
    static public int playerMnum;
    static public int playerLnum;
    static public int enemySnum;
    static public int enemyMnum;
    static public int enemyLnum;
    public void onClick()
    {
        playerSnum = GetInput.playerSnum;
        playerMnum = GetInput.playerMnum;
        playerLnum = GetInput.playerLnum;
        enemySnum = GetInput.enemySnum;
        enemyMnum = GetInput.enemyMnum;
        enemyLnum = GetInput.enemyLnum;

        SceneManager.LoadScene("Game");
    }
}
