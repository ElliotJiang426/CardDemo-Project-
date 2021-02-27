using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveInput : MonoBehaviour
{
    public InputField distance;

    static public int NowDistance;

    // Start is called before the first frame update
    void Start()
    {
        distance.text = PlayerManager.distance.ToString();
    }

    // Update is called once per frame
    public void EndInput()
    {
        int.TryParse(distance.text, out NowDistance);
    }
}
