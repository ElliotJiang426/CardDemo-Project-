using System;
using System.Collections.Generic;
using UnityEngine;

public class CardList
{
    /* Attributes */
    public int cardNumber;      // 卡组剩余卡牌数量
    public List<Card> deck;     // 卡组
    public List<Card> tomb;     // 墓地
    public List<Card> hand;     // 手牌

    /* Methods */
    // 参数化构造函数
    public CardList() 
    {
        cardNumber = 0;
        deck = new List<Card>();
        tomb = new List<Card>();
        hand = new List<Card>();
    }

    // 初始化牌库
    public void Initialize(int cardShoot, int cardMove, int cardLoad, List<Card> cardSpell) 
    {
        int id = 0;
        // 添加射击牌
        for(int i = 0; i < cardShoot; i++){
            BasicCard card = new BasicCard("Shoot", Card.Type.SHOOT, 1, "this is a shoot card");
            card.card = (GameObject)Resources.Load("Prefabs/CardShoot");
            card.id = id++;
            tomb.Add(card);
        }
        // 添加移动牌
        for(int i = 0; i < cardMove; i++){
            BasicCard card = new BasicCard("Move", Card.Type.MOVE, 1, "this is a move card");
            card.card = (GameObject)Resources.Load("Prefabs/CardMove");
            card.id = id++;
            tomb.Add(card);
        }
        // 添加装填牌
        for(int i = 0; i < cardLoad; i++){
            BasicCard card = new BasicCard("Load", Card.Type.LOAD, 1, "this is a load card");
            card.card = (GameObject)Resources.Load("Prefabs/CardLoad");
            card.id = id++;
            tomb.Add(card);
        }
        // 添加法术牌
        if(cardSpell != null)
            for(int i = 0; i < cardSpell.Count; i++){
                cardSpell[i].id = id++;
                tomb.Add(cardSpell[i]);
            }

        Shuffle();
    }

    // 抽取卡牌
    public void DrawCardFromDeck(int n)
    {
        if(deck.Count < n)
            Shuffle();
        for(int i = 0; i < n; i++){
            if(hand.Count < 10)
                hand.Add(deck[0]);
            else
                MoveCardToTomb(deck[0]);
            deck.RemoveAt(0);
        }
    }

    // 使用卡牌
    public void UseCard(Card card)
    {
        MoveCardToTomb(card);
        hand.Remove(card);
    }

    // 洗牌
    public void Shuffle()
    {
        int rand;
        Card tempCard;
        while (tomb.Count > 0)
        {
            rand = UnityEngine.Random.Range(0, tomb.Count);
            tempCard = tomb[rand];
            deck.Add(tempCard);
            tomb.RemoveAt(rand);
        }
    }

    // 添加卡牌
    public int AddCardToDeck(Card card)
    {
        deck.Add(card);
        return ++cardNumber;
    }

    // 移入墓地
    public void MoveCardToTomb(Card card) 
    {
        tomb.Add(card);
        return;
    }
}