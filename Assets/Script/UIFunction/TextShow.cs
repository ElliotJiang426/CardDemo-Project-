using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextShow : MonoBehaviour
{
    public Text whoseRound;
    public Text PlayerDeck;
    public Text EnemyDeck;
    public Text PlayerHP;
    public Text EnemyHP;
    public Text PlayerClip;
    public Text EnemyClip;
    public static Battleground battleground;

    // Start is called before the first frame update
    void Start()
    {
        battleground = PlayerManager.battleground;
    }

    // Update is called once per frame
    void Update()
    {
        if (battleground.curInTurn == Battleground.Turn.PLAYER)
            whoseRound.text = "你的回合";
        else
            whoseRound.text = "对手回合";

        PlayerDeck.text = "牌库剩余：" + battleground.cats[0].cardList.deck.Count + "张"; 
        EnemyDeck.text = "牌库剩余：" + battleground.cats[1].cardList.deck.Count + "张";

        PlayerHP.text = "HP:" + battleground.cats[0].hp;
        EnemyHP.text = "HP:" + battleground.cats[1].hp;

        PlayerClip.text = "Clip:" + battleground.cats[0].weapon.clip.curClip + "/" + battleground.cats[0].weapon.clip.maxClip;
        EnemyClip.text = "Clip:" + battleground.cats[1].weapon.clip.curClip + "/" + battleground.cats[1].weapon.clip.maxClip;


    }
}
