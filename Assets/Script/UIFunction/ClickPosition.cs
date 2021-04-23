using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickPosition : MonoBehaviour
{
    //给每个位置一个编号
    public int id = 1;
    
    int PlayerId;
    int EnemyId;
    public GameObject BattleManager;
    public static Battleground battleground;


    public void SetId(int thisId)
    {
        id = thisId;
    }

    public void isClick()
    {
        Debug.Log(id);
        bool result = false;
        if(battleground.curInTurn == Battleground.Turn.PLAYER)
        {
            battleground.UpdateLocation(Battleground.Turn.PLAYER, id);
            BattleManager.SendMessage("setPlayerIsMove", result);
        }
        
        else if(battleground.curInTurn == Battleground.Turn.ENEMY)
        {
            battleground.UpdateLocation(Battleground.Turn.ENEMY, id);
            BattleManager.SendMessage("setEnemyIsMove", result);
        }
    }    
    void Start()
    {
        //和BattleManager消息传递准备
        BattleManager = GameObject.Find("BattleManager");
        battleground = PlayerManager.battleground;
    }

    // Update is called once per frame
    void Update()
    {
        //若不在可移动范围内 则禁用按钮
        if (!PlayerManager.PlayerIsMove && !PlayerManager.EnemyIsMove)
            this.GetComponent<Button>().enabled = false;
        else
        {
            if(PlayerManager.PlayerIsMove)
            {
                // 当前 player 和 enemy 位置不可点击
                if(id == battleground.location[0] || id == battleground.location[1])
                    this.GetComponent<Button>().enabled = false;
                // 前后两格可以移动
                else if (id <= battleground.location[0] + 2 && id >= battleground.location[0] - 2)
                    this.GetComponent<Button>().enabled = true;
                // 其他位置不可以移动
                else
                    this.GetComponent<Button>().enabled = false;
            }
           
            if(PlayerManager.EnemyIsMove)
            {
                if (id == battleground.location[0] || id == battleground.location[1])
                    this.GetComponent<Button>().enabled = false;
                else if (id <= battleground.location[1] + 2 && id >= battleground.location[1] - 2)
                    this.GetComponent<Button>().enabled = true;
                else
                    this.GetComponent<Button>().enabled = false;
            }

        }

        RenderBlock();
    }

    public void RenderBlock(){
        if(id == battleground.location[0])
            this.GetComponent<Image>().color = new Color((0 / 255f), (124 / 255f), (255 / 255f), (255 / 255f)); 
        else if(id == battleground.location[1])
            this.GetComponent<Image>().color = new Color((255 / 255f), (0 / 255f), (164 / 255f), (255 / 255f));
        else
            this.GetComponent<Image>().color = new Color((87 / 255f), (87 / 255f), (87 / 255f), (255 / 255f));
    }
}
