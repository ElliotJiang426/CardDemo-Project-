using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPlay : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject text;
    private GameObject showtext;

    public bool isHovering = false;


    public void Awake() //定义Canvas面板
    {
        Canvas = GameObject.Find("Canvas"); 
    }

    public void onClick() //点击时打出此牌
    {
        Destroy(showtext);
        Destroy(this.gameObject);
       
    }

    public void EnterHover() //鼠标悬停开始 实例化文本
    {
        showtext = Instantiate(text, new Vector2(this.gameObject.transform.position.x - Screen.width/2, this.gameObject.transform.position.y - Screen.height/2), Quaternion.identity);
        showtext.transform.SetParent(Canvas.transform, false);
        showtext.transform.SetAsLastSibling();
    }
     public void ExitHover() //鼠标悬停结束
    {
        Destroy(showtext);
    }
}
