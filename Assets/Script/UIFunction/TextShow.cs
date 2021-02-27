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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CardManager.turn % 2 == 0)
            whoseRound.text = "你的回合";
        else
            whoseRound.text = "对手回合";

        PlayerDeck.text = "牌库剩余：" + CardManager.PlayerDeckNum + "张"; 
        EnemyDeck.text = "牌库剩余：" + CardManager.EnemyDeckNum + "张";

        PlayerHP.text = "HP:" + PlayerManager.PlayerHP;
        EnemyHP.text = "HP:" + PlayerManager.EnemyHP;

        PlayerClip.text = "Clip:" + PlayerManager.PlayerClip + "/" + PlayerManager.PlayerClipMax;
        EnemyClip.text = "Clip:" + PlayerManager.EnemyClip + "/" + PlayerManager.EnemyClipMax;


    }
}
