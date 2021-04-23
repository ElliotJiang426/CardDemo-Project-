using System;
using UnityEngine;
public class SpellCard : Card 
{
    public delegate void SpellFunction ();

    /* Attributes */
    public SpellFunction spellFunction;

    /* Methods */
    // 参数化构造函数
    public SpellCard(
        String _name, 
        Type _type, 
        int _cost, 
        String _description, 
        SpellFunction _spellFunction)
    {
        name = _name;
        type = _type;
        cost = _cost;
        description = _description;
        spellFunction = _spellFunction;
    }

    // 触发法术效果
    public void TriggerSpell()
    {
        Console.WriteLine("triggerSpell");
        if(spellFunction != null) {
            spellFunction();
        } 
        return;
    }
}