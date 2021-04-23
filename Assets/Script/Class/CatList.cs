using System;
using UnityEngine;

class CatList
{
    public static HookFunction[] startTurnHookFunctions;
    public static HookFunction[] endTurnHookFunctions;

    public static void Initialize()
    {
        // 定义委托函数数组
        startTurnHookFunctions = new HookFunction[8];
        endTurnHookFunctions = new HookFunction[8];
         
        // 回合开始 hook 函数
        startTurnHookFunctions[0] = new HookFunction(Cat_Player_StartTurn);
        startTurnHookFunctions[1] = new HookFunction(Cat_Tabby_StartTurn);
        startTurnHookFunctions[2] = new HookFunction(Cat_CoolHair_StartTurn);
        startTurnHookFunctions[3] = new HookFunction(Cat_AbaAba_StartTurn);
        startTurnHookFunctions[4] = new HookFunction(Cat_Persian_StartTurn);
        startTurnHookFunctions[5] = new HookFunction(Cat_Lover_StartTurn);
        startTurnHookFunctions[6] = new HookFunction(Cat_SingleEye_StartTurn);
        startTurnHookFunctions[7] = new HookFunction(Cat_Abyss_StartTurn);

        // 回合结束 hook 函数
        endTurnHookFunctions[0] = new HookFunction(Cat_Player_EndTurn);
        endTurnHookFunctions[1] = new HookFunction(Cat_Tabby_EndTurn);
        endTurnHookFunctions[2] = new HookFunction(Cat_CoolHair_EndTurn);
        endTurnHookFunctions[3] = new HookFunction(Cat_AbaAba_EndTurn);
        endTurnHookFunctions[4] = new HookFunction(Cat_Persian_EndTurn);
        endTurnHookFunctions[5] = new HookFunction(Cat_Lover_EndTurn);
        endTurnHookFunctions[6] = new HookFunction(Cat_SingleEye_EndTurn);
        endTurnHookFunctions[7] = new HookFunction(Cat_Abyss_EndTurn);
 
        Console.ReadKey();
    }

    // 玩家
    public static void Cat_Player_StartTurn(Battleground bg)
    {
        Console.WriteLine("Player Start Turn");
    }
    public static void Cat_Player_EndTurn(Battleground bg)
    {
        Console.WriteLine("Player End Turn");
    }

    // 胆小的虎斑猫
    public static void Cat_Tabby_StartTurn(Battleground bg)
    {
        Console.WriteLine("Tabby Start Turn");
    }
    public static void Cat_Tabby_EndTurn(Battleground bg)
    {
        Console.WriteLine("Tabby End Turn");
    }

    // 酷酷的长毛猫
    public static void Cat_CoolHair_StartTurn(Battleground bg)
    {
        Console.WriteLine("CoolHair Start Turn");
    }
    public static void Cat_CoolHair_EndTurn(Battleground bg)
    {
        Console.WriteLine("CoolHair End Turn");
    }

    // 阿巴阿巴橘
    public static void Cat_AbaAba_StartTurn(Battleground bg)
    {
        Console.WriteLine("AbaAba Start Turn");
    }
    public static void Cat_AbaAba_EndTurn(Battleground bg)
    {
        Console.WriteLine("AbaAba End Turn");
    }

    // 波斯猫姐姐
    public static void Cat_Persian_StartTurn(Battleground bg)
    {
        Console.WriteLine("Persian Start Turn");
    }
    public static void Cat_Persian_EndTurn(Battleground bg)
    {
        Console.WriteLine("Persian End Turn");
    }

    // 恋爱中的猫
    public static void Cat_Lover_StartTurn(Battleground bg)
    {
        Console.WriteLine("Lover Start Turn");
    }
    public static void Cat_Lover_EndTurn(Battleground bg)
    {
        Console.WriteLine("Lover End Turn");
    }

    // 独眼大叔
    public static void Cat_SingleEye_StartTurn(Battleground bg)
    {
        Console.WriteLine("SingleEye Start Turn");
    }
    public static void Cat_SingleEye_EndTurn(Battleground bg)
    {
        Console.WriteLine("SingleEye End Turn");
    }

    // 深渊猫
    public static void Cat_Abyss_StartTurn(Battleground bg)
    {
        Console.WriteLine("Abyss Start Turn");
    }
    public static void Cat_Abyss_EndTurn(Battleground bg)
    {
        Console.WriteLine("Abyss End Turn");
    }
}