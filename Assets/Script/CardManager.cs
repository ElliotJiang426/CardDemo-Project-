using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject CardShoot;
    public GameObject CardMove;
    public GameObject CardLoad;

    public GameObject PlayerArea;
    public GameObject EnemyArea;

    static public List<GameObject> PlayerTotalDeck = new List<GameObject>();
    static public List<GameObject> EnemyTotalDeck = new List<GameObject>();

    public List<GameObject> PlayerHand = new List<GameObject>();//手牌
    public List<GameObject> PlayerDeck = new List<GameObject>();//发牌库
    public List<GameObject> PlayerDiscard = new List<GameObject>();//弃牌堆

    public List<GameObject> EnemyHand = new List<GameObject>();
    public List<GameObject> EnemyDeck = new List<GameObject>();
    public List<GameObject> EnemyDiscard = new List<GameObject>();

    public GameObject BattleManager;

    //记录回合
    static public int turn = 0;

    //记录牌库剩余牌数
    static public int PlayerDeckNum;
    static public int EnemyDeckNum;

    //开始运行
    void Start()
    {
        //和BattleManager消息传递准备
        BattleManager = GameObject.Find("BattleManager");

        //建立十张总牌库
        if (PlayerManager.playerSnum != 0)
        {
            for (int i = 0; i < PlayerManager.playerSnum; i++)
                PlayerTotalDeck.Add(CardShoot);
        }
        if (PlayerManager.playerMnum != 0)
        {
            for (int i = 0; i < PlayerManager.playerMnum; i++)
                PlayerTotalDeck.Add(CardMove);
        }
        if (PlayerManager.playerLnum != 0)
        {
            for (int i = 0; i < PlayerManager.playerLnum; i++)
                PlayerTotalDeck.Add(CardLoad);
        }

        if (PlayerManager.enemySnum != 0)
        {
            for (int i = 0; i < PlayerManager.enemySnum; i++)
                EnemyTotalDeck.Add(CardShoot);
        }
        if (PlayerManager.enemyMnum != 0)
        {
            for (int i = 0; i < PlayerManager.enemyMnum; i++)
                EnemyTotalDeck.Add(CardMove);
        }
        if (PlayerManager.enemyLnum != 0)
        {
            for (int i = 0; i < PlayerManager.enemyLnum; i++)
                EnemyTotalDeck.Add(CardLoad);
        }

        //洗牌
        Shuffle(PlayerTotalDeck);
        Shuffle(EnemyTotalDeck);

        //建立发牌库
        PlayerDeck = PlayerTotalDeck;
        EnemyDeck = EnemyTotalDeck;

        //第零轮玩家发牌六张
        PlayerDraw(6);
    }

    //更新信息
    void Update()
    {
        //牌库剩余牌数
        PlayerDeckNum = PlayerDeck.Count;
        EnemyDeckNum = EnemyDeck.Count;
    }

    //点击结束回合时发牌
    public void ClickToDraw()
    {
        if (turn % 2 == 0)
            PlayerManager.PlayerContinousTime = 0;
        else
            PlayerManager.EnemyContinousTime = 0;
        
        turn++;

        //若牌库为0，洗弃牌堆加入牌库
        if (PlayerDeck.Count == 0)
        {
            if(turn % 2 == 0)
            {
                Shuffle(PlayerDiscard);
                for (int i = 0; i < PlayerDiscard.Count; i++)
                    PlayerDeck.Add(PlayerDiscard[i]);
                PlayerDiscard.Clear();
            }
        }
        if (EnemyDeck.Count == 0)
        {
            if(turn % 2 == 1)
            {
                Shuffle(EnemyDiscard);
                for (int i = 0; i < EnemyDiscard.Count; i++)
                    EnemyDeck.Add(EnemyDiscard[i]);
                EnemyDiscard.Clear();
            }
        }

        //按回合发牌
        if (turn == 1)
        {
            EnemyDraw(6);
        }
        if(turn % 2 == 0 && turn != 0)
        {
            PlayerDraw(2);
        }
        if(turn % 2 == 1 && turn != 1)
        {
            EnemyDraw(2);
        }
    }

    //出牌
    public void ClickOnCard(string cardname)
    {
        //使用了脚本间的消息传递器 从DealCards脚本传回了被点击的牌的类型
        
        //本来是想在实例化的时候，给每个被实例化的对象赋一个属性，来标记它在手牌库的第几个，在被点击时再将序号传回来的
        //但是我失败了
        //于是变成那边被点击的实体直接destroy，这里的手牌库遍历，随便移除一张同名牌

        //玩家出牌
        if(turn %2 == 0)
        {
            if (cardname == "shoot")
            {
                int id = 0;
                while (true)
                {
                    if (PlayerHand[id] == CardShoot)
                    {
                        PlayerHand.RemoveAt(id);
                        PlayerDiscard.Add(CardShoot);
                        break;
                    }
                    id++;
                }
                string strPS = "PlayerShoot";
                BattleManager.SendMessage("CastDamage", strPS);
            }

            if (cardname == "move")
            {
                int id = 0;
                while (true)
                {
                    if (PlayerHand[id] == CardMove)
                    {
                        PlayerHand.RemoveAt(id);
                        PlayerDiscard.Add(CardMove);
                        break;
                    }
                    id++;
                }
                string strPM = "PlayerMove";
                BattleManager.SendMessage("CastDamage", strPM);
            }

            if (cardname == "load")
            {
                int id = 0;
                while (true)
                {
                    if (PlayerHand[id] == CardLoad)
                    {
                        PlayerHand.RemoveAt(id);
                        PlayerDiscard.Add(CardLoad);
                        break;
                    }
                    id++;
                }
                string strPL = "PlayerLoad";
                BattleManager.SendMessage("CastDamage", strPL);
            }
            
        }

        //敌人出牌
        else
        {
            if (cardname == "shoot")
            {
                int id = 0;
                while (true)
                {
                    if (EnemyHand[id] == CardShoot)
                    {
                        EnemyHand.RemoveAt(id);
                        EnemyDiscard.Add(CardShoot);
                        break;
                    }
                    id++;
                }
                string strES = "EnemyShoot";
                BattleManager.SendMessage("CastDamage", strES);
            }

            if (cardname == "move")
            {
                int id = 0;
                while (true)
                {
                    if (EnemyHand[id] == CardMove)
                    {
                        EnemyHand.RemoveAt(id);
                        EnemyDiscard.Add(CardMove);
                        break;
                    }
                    id++;
                }
                string strEM = "EnemyMove";
                BattleManager.SendMessage("CastDamage", strEM);
            }

            if (cardname == "load")
            {
                int id = 0;
                while (true)
                {
                    if (EnemyHand[id] == CardLoad)
                    {
                        EnemyHand.RemoveAt(id);
                        EnemyDiscard.Add(CardLoad);
                        break;
                    }
                    id++;
                }
                string strEL = "EnemyLoad";
                BattleManager.SendMessage("CastDamage", strEL);
            }
        }

    }
    
    //被调函数：玩家从牌库抽n张进入手牌
    public void PlayerDraw(int num)
    {
        for(int i = 0; i < num; i++)
        {
            if(PlayerDeck.Count==0)
            {
                break;
            }
            else
            {
                PlayerHand.Add(PlayerDeck[0]);
                
                //将定义的这些卡牌prefab实例化
                GameObject playerCard = Instantiate(PlayerDeck[0], new Vector3(0, 0, 0), Quaternion.identity);
                //将卡牌设为playerArea的子类
                playerCard.transform.SetParent(PlayerArea.transform, false);
                
                PlayerDeck.RemoveAt(0);

                //修改这张牌是手牌第几张的属性
                
            }
        }
    }

    //被调函数：敌人从牌库抽n张进入手牌
    public void EnemyDraw(int num)
    {
        for (int i = 0; i < num; i++)
        {
            if (EnemyDeck.Count == 0)
            {
                break;
            }
            else
            {
                EnemyHand.Add(EnemyDeck[0]);
                GameObject enemyCard = Instantiate(EnemyDeck[0], new Vector3(0, 0, 0), Quaternion.identity);
                enemyCard.transform.SetParent(EnemyArea.transform, false);
                EnemyDeck.RemoveAt(0);
            }
        }
    }

    //洗牌算法
    public void Shuffle<GameObject>(List<GameObject> _list)
    {
        List<GameObject> tempList = new List<GameObject>();
        int rand;
        GameObject tempValue;
        while (_list.Count > 0)
        {
            rand = Random.Range(0, _list.Count);
            tempValue = _list[rand];
            tempList.Add(tempValue);
            _list.RemoveAt(rand);
        }
        for (int i = 0; i < tempList.Count; i++)
        {
            _list.Add(tempList[i]);
        }
    }

}
