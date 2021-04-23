using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollResult : MonoBehaviour
{
    public Text playerrollresult;
    public Text enemyrollresult;

    static public int playerRoll;
    static public int playerRollRange;
    static public int enemyRoll;
    static public int enemyRollRange;

    void Start()
    {
        playerrollresult.text = null;
    }

    public void setPlayerRoll(int result)
    {
        playerRoll = result;
    }

    public void setPlayerRollRange(int result)
    {
        playerRollRange = result;
    }    

    public void setEnemyRoll(int result)
    {
        enemyRoll = result;
    }

    public void setEnemyRollRange(int result)
    {
        enemyRollRange = result;
    }    

    void Update()
    {
        if(PlayerManager.PlayerOutOfRange)
            playerrollresult.text = "射击失败！";
        else
            playerrollresult.text = "roll点结果：" + playerRoll + "/" + playerRollRange + (playerRollRange == 0?"":(playerRoll <= playerRollRange? " 命中!":" MISS!"));

        if(PlayerManager.EnemyOutOfRange)
            enemyrollresult.text = "射击失败！";
        else 
            enemyrollresult.text = "roll点结果：" + enemyRoll + "/" + enemyRollRange + (enemyRollRange == 0?"":(enemyRoll <= enemyRollRange? " 命中!":" MISS!"));

    }
}
