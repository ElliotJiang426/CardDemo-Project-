using System;
using UnityEngine;

public class Card : MonoBehaviour
{
    /* Attributes */
    public enum Type {MOVE, SHOOT, LOAD, SPELL};
    public int cost;                                // 饥饿值消耗
    public Type type;                               // 卡牌种类
    public new String name;                         // 卡牌名称
    public String description;                      // 卡牌描述
    public GameObject card;               // 对应的 GameObject
    public int id;                               // 卡牌编号
}



