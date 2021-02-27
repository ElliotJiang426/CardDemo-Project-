using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollResult : MonoBehaviour
{
    public Text playerrollresult;
    public Text enemyrollresult;

    static public int playerroll;
    static public int playerluck;
    static public int enemyroll;
    static public int enemyluck;

    static public bool DBsuccess = false;
    static public bool hasDB = false;

    void Start()
    {
        playerrollresult.text = null;
    }

    public void getPR(int result)
    {
        playerroll = result;
    }

    public void getPL(int result)
    {
        playerluck = result;
    }    

    public void getER(int result)
    {
        enemyroll = result;
    }

    public void getEL(int result)
    {
        enemyluck = result;
    }    

    void Update()
    {
        if(PlayerManager.PlayerOutOfRange)
        {
            playerrollresult.text = "射击失败！";
        }
        else
        {
            if (PlayerManager.hasDB)
            {
                if (PlayerManager.DBSuccess)
                    playerrollresult.text = "roll点结果：" + playerroll + "/" + playerluck + "    伤害加成:成功";
                else
                    playerrollresult.text = "roll点结果：" + playerroll + "/" + playerluck + "    伤害加成:失败";
            }
            else
                playerrollresult.text = "roll点结果：" + playerroll + "/" + playerluck;
        }

        if(PlayerManager.EnemyOutOfRange)
        {
            enemyrollresult.text = "射击失败！";
        }
        else enemyrollresult.text = "roll点结果：" + enemyroll + "/" + enemyluck;

    }
}
