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

    public void SetId(int thisId)
    {
        id = thisId;
    }

    public void isClick()
    {
        if(PlayerManager.PlayerIsMove)
        {
            PlayerId = id;
            BattleManager.SendMessage("getPlayerId", PlayerId);
            bool result1 = false;
            BattleManager.SendMessage("getPlayerIsMove", result1);
        }
        
        if(PlayerManager.EnemyIsMove)
        {
            EnemyId = id;
            BattleManager.SendMessage("getEnemyId", EnemyId);
            bool result2 = false;
            BattleManager.SendMessage("getEnemyIsMove", result2);
        }
    }    
    void Start()
    {
        //和BattleManager消息传递准备
        BattleManager = GameObject.Find("BattleManager");
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
                if(id == PlayerManager.EnemyId)
                    this.GetComponent<Button>().enabled = false;
                else if (id == PlayerManager.PlayerId + 1 || id == PlayerManager.PlayerId + 2 || id == PlayerManager.PlayerId - 1 || id == PlayerManager.PlayerId - 2)
                    this.GetComponent<Button>().enabled = true;
                else
                    this.GetComponent<Button>().enabled = false;
            }
           
            if(PlayerManager.EnemyIsMove)
            {
                if (id == PlayerManager.PlayerId)
                    this.GetComponent<Button>().enabled = false;
                else if (id == PlayerManager.EnemyId + 1 || id == PlayerManager.EnemyId + 2 || id == PlayerManager.EnemyId - 1 || id == PlayerManager.EnemyId - 2)
                    this.GetComponent<Button>().enabled = true;
                else
                    this.GetComponent<Button>().enabled = false;
            }

        }

        if(id == PlayerManager.PlayerId)
            this.GetComponent<Image>().color = new Color((0 / 255f), (124 / 255f), (255 / 255f), (255 / 255f)); 
        else if(id == PlayerManager.EnemyId)
            this.GetComponent<Image>().color = new Color((255 / 255f), (0 / 255f), (164 / 255f), (255 / 255f));
        else
            this.GetComponent<Image>().color = new Color((87 / 255f), (87 / 255f), (87 / 255f), (255 / 255f));


    }
}
