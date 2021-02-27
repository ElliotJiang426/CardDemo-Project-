using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetInput : MonoBehaviour
{
    public InputField playerS;
    public InputField playerM;
    public InputField playerL;
    public InputField enemyS;
    public InputField enemyM;
    public InputField enemyL;

    static public int playerSnum = 0;
    static public int playerMnum = 0;
    static public int playerLnum= 0;
    static public int enemySnum = 0;
    static public int enemyMnum = 0;
    static public int enemyLnum = 0;

    public void endInput()
    {
        int.TryParse(playerS.text,out playerSnum);
        int.TryParse(playerM.text, out playerMnum);
        int.TryParse(playerL.text, out playerLnum);
        int.TryParse(enemyS.text, out enemySnum);
        int.TryParse(enemyM.text, out enemyMnum);
        int.TryParse(enemyL.text, out enemyLnum);
    }


}

