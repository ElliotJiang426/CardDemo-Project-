using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealCard : MonoBehaviour
{
    public GameObject CardManager;

    public GameObject CardShoot;
    public GameObject CardMove;
    public GameObject CardLoad;

    private void Start()
    {
        CardManager = GameObject.Find("CardManager");
    }
    public void ClickToDeal()
    {
        string str;
        if(this.gameObject == CardShoot)
        {
            str = "shoot";
            CardManager.SendMessage("ClickOnCard", str);
        }
        if (this.gameObject == CardMove)
        {
            str = "move";
            CardManager.SendMessage("ClickOnCard", str);
        }
            
        if (this.gameObject == CardLoad)
        {
            str = "load";
            CardManager.SendMessage("ClickOnCard", str);
        }
        Destroy(this.gameObject);
    }
}
