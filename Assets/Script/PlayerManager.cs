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
    static public bool PlayerOutOfRange = false;
    static public bool EnemyOutOfRange = false;
    //==================3.0更新↓=======================
    static public bool PlayerIsMove = false;
    static public bool EnemyIsMove = false;

    //血量
    static public int PlayerHP = 20;
    static public int EnemyHP = 20;

    // 武器
    static Weapon playerWeapon;
    static Weapon enemyWeapon;

    // 猫猫
    static Cat player;
    static Cat enemy;

    // 卡组
    static CardList playerCardList;
    static CardList enemyCardList;
    public static Battleground battleground;
    /*====================== 3.0 end ===================== */

    void Start()
    {
        //从上个场景调用输入值
        playerSnum = buttonToNext.playerSnum;
        playerMnum = buttonToNext.playerMnum;
        playerLnum = buttonToNext.playerLnum;
        enemySnum = buttonToNext.enemySnum;
        enemyMnum = buttonToNext.enemyMnum;
        enemyLnum = buttonToNext.enemyLnum;

        /*====================== 3.0 start ===================== */
        WeaponList.Initialize();
        // 武器
        playerWeapon = new Weapon("毛瑟步枪", 2, 6, 0.7f, 5, 3, 5, 0.8f, "test", WeaponList.beforeHookFunctions[0], WeaponList.afterHookFunctions[0]);
        enemyWeapon = new Weapon("左轮手枪", 1, 6, 0.8f, 4, 3, 6, 1f, "test", WeaponList.beforeHookFunctions[1], WeaponList.afterHookFunctions[1]);

        // 猫猫
        player = new Cat("Player", 20, 0, 0, 1, playerWeapon, CatList.startTurnHookFunctions[0], CatList.endTurnHookFunctions[0]);
        enemy = new Cat("Enemy", 20, 0, 0, 1, enemyWeapon, CatList.startTurnHookFunctions[1], CatList.endTurnHookFunctions[1]);

        // 卡组
        playerCardList = new CardList();
        enemyCardList = new CardList();
        playerCardList.Initialize(playerSnum, playerMnum, playerLnum, null);
        enemyCardList.Initialize(enemySnum, enemyMnum, enemyLnum, null);
        player.cardList = playerCardList;
        enemy.cardList = enemyCardList;

        // 战场
        battleground = new Battleground(player, enemy, 7, 0, 1);
        /*====================== 3.0 end ===================== */
    }
    void Shoot()
    {
        if (battleground.curInTurn == Battleground.Turn.PLAYER)
        {
            // 调用武器钩子函数
            battleground.cats[0].weapon.BeforeAttack(battleground);

            // 调用 DealDamage 函数
            DealDamage(0, 1);

            // 调用武器钩子函数
            battleground.cats[0].weapon.AfterAttack(battleground);
        }

        else if (battleground.curInTurn == Battleground.Turn.ENEMY)
        {
            // 调用武器钩子函数
            battleground.cats[1].weapon.BeforeAttack(battleground);

            // 调用 DealDamage 函数
            DealDamage(1, 0);

            // 调用武器钩子函数
            battleground.cats[1].weapon.AfterAttack(battleground);
        }
    }

    /* ================ 3.0 start =============== */
    void Move(){
        if (battleground.curInTurn == Battleground.Turn.PLAYER)
            PlayerIsMove = true;
        if (battleground.curInTurn == Battleground.Turn.ENEMY)
            EnemyIsMove = true;
    }

    void Load(){
        if (battleground.curInTurn == Battleground.Turn.PLAYER)
            if (battleground.cats[0].weapon.clip.curClip < battleground.cats[0].weapon.clip.maxClip)
                battleground.cats[0].weapon.clip.curClip++;
        if (battleground.curInTurn == Battleground.Turn.ENEMY)
            if (battleground.cats[1].weapon.clip.curClip < battleground.cats[1].weapon.clip.maxClip)
                battleground.cats[1].weapon.clip.curClip++;
    }
    /* ================= 3.0 end =============== */

    //==================3.0更新↓=======================

    void DealDamage(int shooter, int target)
    {
        // roll 点
        int roll = Random.Range(1, 100);
        playerrolltext.SendMessage(shooter == 0?"setPlayerRoll":"setEnemyRoll", roll);

        // 计算命中率的上限
        float rollRange;
        rollRange = (battleground.cats[shooter].weapon.hitRate * 100) * Mathf.Pow(battleground.cats[shooter].weapon.hitComp, battleground.shootCount);
        playerrolltext.SendMessage(shooter == 0?"setPlayerRollRange":"setEnemyRollRange", rollRange);


        if (battleground.cats[shooter].weapon.clip.curClip > 0 && battleground.distance <= battleground.cats[shooter].weapon.range.max && battleground.distance >= battleground.cats[shooter].weapon.range.min)
        {
            PlayerOutOfRange = false;
            // 命中
            if (roll <= rollRange){
                // 射击伤害
                battleground.cats[target].hp -= battleground.cats[shooter].weapon.damage;
            }

            // 射击次数加一
            battleground.shootCount++;
        }
        else 
            PlayerOutOfRange = true;

        if(battleground.cats[shooter].weapon.clip.curClip > 0)
            battleground.cats[shooter].weapon.clip.curClip--;
    }
    void setPlayerIsMove(bool result)
    {
        PlayerIsMove = result;
    }
    void setEnemyIsMove(bool result)
    {
        EnemyIsMove = result;
    }
    void Update()
    {
        battleground.UpdateDistance();
    }

}
