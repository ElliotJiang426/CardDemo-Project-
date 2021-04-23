using System;

public class Cat 
{
    /* Attributes */
    public String name;     // 名字
    public int hp;          // 生命值
    public int exp;         // 经验值
    public int fullness;    // 饱腹感
    public int level;       // 等级
    // public List<Object> packet;  // 背包
    public CardList cardList;       // 卡组
    // public Status status;        // 状态
    // public Talent talent;        // 天赋
    public Weapon weapon;   // 武器
    public HookFunction startTurnHookFunction;  // 回合开始钩子函数
    public HookFunction endTurnHookFunction;    // 回合结束钩子函数

    /* Methods */
    // 参数化构造函数
    public Cat(
        String _name, 
        int _hp, 
        int _exp, 
        int _fullness, 
        int _level, 
        Weapon _weapon,
        HookFunction _startTurnHookFunction,
        HookFunction _endTurnHookFunction)
    {
        name = _name;
        hp = _hp;
        exp = _exp;
        fullness = _fullness;
        level = _level;
        weapon = _weapon;
        startTurnHookFunction = _startTurnHookFunction;
        endTurnHookFunction = _endTurnHookFunction;
    }

    // 升级
    public int Upgrade()
    {
        return ++level;
    }
}