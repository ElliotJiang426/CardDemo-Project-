using System;

public struct Range
{
    public int min; // 攻击范围下限
    public int max; // 攻击范围上线

    public Range(int _min, int _max)
    {
        min = _min;
        max = _max;
    }
};

public struct Clip
{
    public int curClip; // 当前弹夹数
    public int maxClip; // 最大弹夹数

    public Clip(int _curClip, int _maxClip)
    {
        curClip = _curClip;
        maxClip = _maxClip;
    }
};
public delegate void HookFunction(Battleground bg);
public class Weapon
{
    /* Attributes */
    public String name;         // 武器名称
    public Range range;         // 攻击范围
    public float hitRate;       // 命中率
    public int damage;          // 伤害
    public Clip clip;           // 弹夹数量
    public float hitComp;       // 命中补正
    public String description;  // 武器描述
    public HookFunction beforeHookFunction; // 攻击前钩子函数
    public HookFunction afterHookFunction;  // 攻击后钩子函数

    /* Methods */
    // 参数化构造函数
    public Weapon(
        String _name, 
        int _minRange, 
        int _maxRange,
        float _hitRate,
        int _damage,
        int _curClip,
        int _maxClip,
        float _hitComp,
        String _description,
        HookFunction _beforeHookFunction,
        HookFunction _afterHookFunction) 
    {
        Console.WriteLine("新武器创建");
        name = _name;
        range = new Range(_minRange, _maxRange);
        hitRate = _hitRate;
        damage = _damage;
        clip = new Clip(_curClip, _maxClip);
        hitComp = _hitComp;
        description = _description;
        beforeHookFunction = _beforeHookFunction;
        afterHookFunction = _afterHookFunction;
    }

    // 攻击之前调用钩子函数
    public void BeforeAttack(Battleground bg)
    {
        Console.WriteLine("beforeAttack");
        if(beforeHookFunction != null) beforeHookFunction(bg);
        return;
    }

    // 攻击之后调用钩子函数
    public void AfterAttack(Battleground bg)
    {
        Console.WriteLine("afterAttack");
        if(afterHookFunction != null) afterHookFunction(bg);
        return;
    }
}
