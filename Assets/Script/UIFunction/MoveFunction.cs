using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveFunction : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject position;
    public GameObject MoveArea;
    public Text MoveText;

    void Start()
    {

        for (int i = 0;i < 16;i++)
        {
            GameObject playerposition = Instantiate(position, new Vector3(0, 0, 0), Quaternion.identity);
            playerposition.transform.SetParent(MoveArea.transform, false);

            //标id
            if (i == 15)
                position.GetComponent<ClickPosition>().SetId(1);
            else
                position.GetComponent<ClickPosition>().SetId(i + 2);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.PlayerIsMove || PlayerManager.EnemyIsMove)
        {
            MoveText.text = "请点击移动1或2格";
        }
        else
            MoveText.text = null;
    }

}
