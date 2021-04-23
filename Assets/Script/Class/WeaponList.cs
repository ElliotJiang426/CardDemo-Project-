using System;
using UnityEngine;

class WeaponList
{
    public static HookFunction[] beforeHookFunctions;
    public static HookFunction[] afterHookFunctions;
    public static void Initialize()
    {
        // 定义委托函数数组
        beforeHookFunctions = new HookFunction[3];
        afterHookFunctions = new HookFunction[3];
         
        // 攻击前 hook 函数
        beforeHookFunctions[0] = new HookFunction(Weapon_Musket_BeforeAttack);
        beforeHookFunctions[1] = new HookFunction(Weapon_Revolver_BeforeAttack);
        beforeHookFunctions[2] = new HookFunction(Weapon_Shotgun_BeforeAttack);

        // 攻击后 hook 函数
        afterHookFunctions[0] = new HookFunction(Weapon_Musket_AfterAttack);
        afterHookFunctions[1] = new HookFunction(Weapon_Revolver_AfterAttack);
        afterHookFunctions[2] = new HookFunction(Weapon_Shotgun_AfterAttack);
 
        Console.ReadKey();
    }

    // 左轮手枪
    public static void Weapon_Revolver_BeforeAttack(Battleground bg)
    {
        Console.WriteLine("trigger Revolver BeforeHook");
    }
    // 双管猎枪
    public static void Weapon_Shotgun_BeforeAttack(Battleground bg)
    {
        Console.WriteLine("trigger Shotgun BeforeHook");
    }
    // 毛瑟步枪: 50% 的概率造成额外的伤害
    public static void Weapon_Musket_BeforeAttack(Battleground bg)
    {
        Console.WriteLine("trigger Musket BeforeAttack");
        
        if (bg.distance >= 5 && bg.distance <= 6){
            int roll = UnityEngine.Random.Range(1, 100);
            if (roll <= 50)
            {
                bg.cats[(int)bg.curInTurn].weapon.damage += 3;
            }
        }
    }
 
    // 左轮手枪
    public static void Weapon_Revolver_AfterAttack(Battleground bg)
    {
        Console.WriteLine("trigger Revolver AfterHook");
    }
    // 双管猎枪
    public static void Weapon_Shotgun_AfterAttack(Battleground bg)
    {
        Console.WriteLine("trigger Shotgun AfterHook");
    }
    // 毛瑟步枪
    public static void Weapon_Musket_AfterAttack(Battleground bg)
    {
        Console.WriteLine("trigger Musket AfterAttack");
        bg.cats[(int)bg.curInTurn].weapon.damage = 5;
    }
}