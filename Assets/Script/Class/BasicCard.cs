using System;
using UnityEngine;
using UnityEngine.EventSystems;
public class BasicCard : Card, IPointerClickHandler
{
    public BasicCard(
        String _name, 
        Type _type, 
        int _cost, 
        String _description)
    {
        name = _name;
        type = _type;
        cost = _cost;
        description = _description;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        BasicCard card = eventData.pointerCurrentRaycast.gameObject.GetComponent<BasicCard>();
        CastBasic(card);
    }
    public void CastBasic(BasicCard card)
    {
        GameObject CardManager = GameObject.Find("CardManager");
        Debug.Log(card.id);
        CardManager.SendMessage("ClickOnCard", card);
        Destroy(this.card);
    }
}