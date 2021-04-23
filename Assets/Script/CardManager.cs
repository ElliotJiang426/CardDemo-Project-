using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject PlayerArea;   // 玩家手牌区
    public GameObject EnemyArea;    // 敌人手牌区

    public Dictionary<int, GameObject> PlayerHand = new Dictionary<int, GameObject>();  // 玩家手牌

    public Dictionary<int, GameObject> EnemyHand = new Dictionary<int, GameObject>();   // 敌人手牌

    public GameObject BattleManager;

    /* ============= 3.0 start ============ */
    // battleground
    public static Battleground battleground;

    //开始运行
    void Start()
    {
        //和BattleManager消息传递准备
        BattleManager = GameObject.Find("BattleManager");
        battleground = PlayerManager.battleground;
        Debug.Log(battleground.cats[0].cardList.deck.Count);

        battleground.StartTurn();

        PlayerDraw(7);
        EnemyDraw(6);
    }
    /* ============= 3.0 end ============== */

    //更新信息
    void Update()
    {

    }

    //点击结束回合时发牌
    public void ClickToDraw()
    {
        // 结束当前回合
        battleground.EndTurn();

        // 下一个角色开始回合
        battleground.StartTurn();

        // 按回合发牌
        if(battleground.curInTurn == Battleground.Turn.PLAYER)
            PlayerDraw(2);
        else
            EnemyDraw(2);
    }

    /* ======================= 3.0 START ====================== */
    //出牌
    public void ClickOnCard(Card card)
    {
        //玩家出牌
        string methodName;
        Debug.Log(card.id);
        if(battleground.curInTurn == Battleground.Turn.PLAYER)
        {
            PlayerHand.Remove(card.id);
            battleground.cats[0].cardList.UseCard(card);
        }
        //敌人出牌
        else
        {
            EnemyHand.Remove(card.id);
            battleground.cats[1].cardList.UseCard(card);
        }

        switch(card.type){
            case Card.Type.SHOOT:
                methodName = "Shoot";
                break;
            case Card.Type.MOVE:
                methodName = "Move";
                break;
            case Card.Type.LOAD:
                methodName = "Load";
                break;
            default:
                Debug.Log("card type wrong");
                methodName = "";
                break;
        }
        // 调用 battleManager 对应函数
        BattleManager.SendMessage(methodName);
    }
    /* ======================= 3.0 END ====================== */

    //被调函数：玩家从牌库抽n张进入手牌
    public void PlayerDraw(int num)
    {
        for(int i = 0; i < num; i++)
        {
            /* ============== 3.0 start ============== */
                Card card = battleground.cats[0].cardList.deck[0];
                PlayerHand.Add(card.id, card.card);
                
                //将定义的这些卡牌prefab实例化
                GameObject playerCard = Instantiate(card.card, new Vector3(0, 0, 0), Quaternion.identity);
                playerCard.GetComponent<BasicCard>().id = card.id;
                
                //将卡牌设为playerArea的子类
                playerCard.transform.SetParent(PlayerArea.transform, false);
               
                battleground.cats[0].cardList.DrawCardFromDeck(1);
            /* ============== 3.0 end ============== */
        }
    }

    //被调函数：敌人从牌库抽n张进入手牌
    public void EnemyDraw(int num)
    {
        for (int i = 0; i < num; i++)
        {
            /* ============== 3.0 start ============== */
                Card card = battleground.cats[1].cardList.deck[0];
                EnemyHand.Add(card.id, card.card);

                GameObject enemyCard = Instantiate(card.card, new Vector3(0, 0, 0), Quaternion.identity);
                enemyCard.GetComponent<BasicCard>().id = card.id;

                enemyCard.transform.SetParent(EnemyArea.transform, false);
                battleground.cats[1].cardList.DrawCardFromDeck(1);
            /* ============== 3.0 end ============== */
        }
    }
}
