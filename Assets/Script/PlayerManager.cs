using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //暴力数值传递！用来构建初始卡牌的数据
    static public int playerSnum;
    static public int playerMnum;
    static public int playerLnum;
    static public int enemySnum;
    static public int enemyMnum;
    static public int enemyLnum;

    //一些用于UI的变量
    public GameObject playerrolltext;
    public GameObject enemyrolltext;
    static public bool DBSuccess = false;
    static public bool hasDB = false;
    static public bool PlayerOutOfRange = false;
    static public bool EnemyOutOfRange = false;
    //==================2.0更新↓=======================
    static public int PlayerId = 5;
    static public bool PlayerIsMove = false;
    static public int EnemyId = 12;
    static public bool EnemyIsMove = false;

    //以下我根据表手动填写数据 我不会做成数据库调用 我是sb

    //血量
    static public int PlayerHP = 20;
    static public int EnemyHP = 20;

    //弹夹
    static public int PlayerClip =3;
    static public int PlayerClipMax = 5;
    static public int EnemyClip = 3;
    static public int EnemyClipMax = 6;

    //开枪概率
    int PlayerLuck = 70;
    int EnemyLuck = 80;

    //开枪伤害
    int PlayerDamage = 5;
    int EnemyDamage = 4;
    //伤害加成
    int PlayerDamageBonus = 3;
    int EnemyDamageBonus = 0;
    int PlayerDBLuck = 50;
    int EnemyDBLuck = 0;
    int DBRangeMin = 5;
    int DBRangeMax = 6;

    //命中补正
    float PlayerRangeAmend = 1f;
    float EnemyRangeAmend = 0.6f;
    //需要补正射程
    int PlayerRAmin = 0;
    int PlayerRAmax = 16;
    int EnemyRAmin = 5;
    int EnemyRAmax = 6;

    //连续命中补正
    float PlayerContinous = 0.8f;
    float EnemyContinous = 1f;
    //连续射击计数
    public static int PlayerContinousTime = 0;
    public static int EnemyContinousTime = 0;
    //是否有补正
    //bool PlayerContinousFlag = true;
    //bool EnemyContinousFlag = false;

    //射程
    int PlayerRangeMin = 2;
    int PlayerRangeMax = 6;
    int EnemyRangeMin = 1;
    int EnemyRangeMax = 6;

    //位置
    static public int distance = 7;

    void Start()
    {
        //从上个场景调用输入值
        playerSnum = buttonToNext.playerSnum;
        playerMnum = buttonToNext.playerMnum;
        playerLnum = buttonToNext.playerLnum;
        enemySnum = buttonToNext.enemySnum;
        enemyMnum = buttonToNext.enemyMnum;
        enemyLnum = buttonToNext.enemyLnum;
    }
    void CastDamage(string str)
    {
        if (str == "PlayerShoot")
        {
            PlayerOutOfRange = false;

            int roll = Random.Range(1, 100);
            playerrolltext.SendMessage("getPR", roll);

            float luck;

            if (distance >= PlayerRAmin && distance <= PlayerRAmax)
                luck = PlayerLuck * Mathf.Pow(PlayerContinous, PlayerContinousTime) * PlayerRangeAmend;
            else
                luck = PlayerLuck * Mathf.Pow(PlayerContinous, PlayerContinousTime);
            playerrolltext.SendMessage("getPL", luck);

            if (PlayerClip > 0 && distance <= PlayerRangeMax && distance >= PlayerRangeMin)
            {
                if (roll <= luck)
                {
                    //普通射击伤害
                    EnemyHP -= PlayerDamage;

                    //伤害加成
                    if (distance >= DBRangeMin && distance <= DBRangeMax)
                    {
                        Debug.Log("yes");
                        hasDB = true;

                        int roll2 = Random.Range(1, 100);
                        if (roll2 <= PlayerDBLuck)
                        {
                            EnemyHP -= PlayerDamageBonus;

                            DBSuccess = true;
                        }
                        else
                            DBSuccess = false;
                    }
                    else hasDB = false;
                }

                PlayerContinousTime++;
            }
            else PlayerOutOfRange = true;

            if(PlayerClip>0)
                PlayerClip--;
        }

        if (str == "EnemyShoot")
        {
            EnemyOutOfRange = false;

            int roll = Random.Range(1, 100);
            enemyrolltext.SendMessage("getER", roll);

            float luck;
            if(distance >= EnemyRAmin && distance <= EnemyRAmax)
                luck = EnemyLuck * Mathf.Pow(EnemyContinous, EnemyContinousTime) * EnemyRangeAmend;
            else
                luck = EnemyLuck * Mathf.Pow(EnemyContinous, EnemyContinousTime);
            enemyrolltext.SendMessage("getEL", luck);

            if (EnemyClip > 0 && distance <= EnemyRangeMax && distance >= EnemyRangeMin)
            {
                if (roll <= luck)
                {   
                    //普通射击伤害
                    PlayerHP -= EnemyDamage;
                }

                EnemyContinousTime++;
            }
            else EnemyOutOfRange = true;

            if (EnemyClip > 0)
                EnemyClip--;
        }

        //==================2.0更新↓=======================
        if (str == "PlayerMove")
        {
            PlayerIsMove = true;
        }

        if (str == "EnemyMove")
        {
            EnemyIsMove = true;
        }
        //==================2.0更新↑=======================

        if (str == "PlayerLoad")
        {
            if (PlayerClip < PlayerClipMax)
                PlayerClip++;
        }

        if (str == "EnemyLoad")
        {
            if (EnemyClip < EnemyClipMax)
                EnemyClip++;
        }
        
        
    }

    //==================2.0更新↓=======================
    void getPlayerId(int result)
    {
        PlayerId = result;
    }

    void getPlayerIsMove(bool result)
    {
        PlayerIsMove = result;
    }
    void getEnemyId(int result)
    {
        EnemyId = result;
    }

    void getEnemyIsMove(bool result)
    {
        EnemyIsMove = result;
    }

    void Update()
    {
        distance = Mathf.Abs(EnemyId - PlayerId);
    }

}
