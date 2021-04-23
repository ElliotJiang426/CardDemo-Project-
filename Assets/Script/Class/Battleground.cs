using UnityEngine;
using System;

public class Battleground
{
    public enum Turn {PLAYER, ENEMY};
    public Cat[] cats;          // 玩家
    public int[] location;      // 玩家位置
    public int distance;        // 距离
    public Turn curInTurn;      // 当前是谁的回合
    public int curTurnNum;      // 当前回合数
    public bool isHitted;       // 上一次攻击是否命中
    public int shootCount;      // 本回合累计射击次数
    
    public Battleground(Cat player, Cat enemy, int _distance, Turn _curInTurn, int _curTurnNum)
    {
        cats = new Cat[2];
        cats[0] = player;
        cats[1] = enemy;

        location = new int[2];
        location[0] = 4;
        location[1] = 11;

        distance = _distance;
        curInTurn = _curInTurn;
        curTurnNum = _curTurnNum;
        isHitted = false;
        shootCount = 0;
    }

    public void StartTurn(){
        Console.WriteLine((curInTurn == Turn.PLAYER?"Player ":"Enemy ") + "start turn " + this.curTurnNum);
        cats[(int)curInTurn].startTurnHookFunction(this);
        return;
    }

    public void EndTurn(){
        Console.WriteLine((curInTurn == Turn.PLAYER?"Player ":"Enemy ") + "End turn " + this.curTurnNum);
        cats[(int)curInTurn].endTurnHookFunction(this);
        UpdateDistance();
        ChangeTurn();
    }
    
    public void UpdateDistance(){
        distance = Mathf.Abs(location[0] - location[1]);
    }
    public void UpdateLocation(Turn turn, int newLocation){
        location[(int)turn] = newLocation;
    }
    public void ChangeTurn(){
        curInTurn = 1-curInTurn;
        if(curInTurn == Turn.PLAYER)
            curTurnNum++;
        isHitted = false;
        shootCount = 0;
    }
}
