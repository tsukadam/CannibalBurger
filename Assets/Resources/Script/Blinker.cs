using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Coffee.UIExtensions;

public class Blinker : MonoBehaviour
{
    //ステータス表示オブジェクトの取得
    public GameObject Myself;//自分自身
    public int BlinkFlag = 0;

    public void Blink()
    {
        BlinkFlag = 1;
        Hashtable hashGlow = new Hashtable(){
            {"from", 1.0f},
            {"to", 0.5f},
            {"time", 0.75f},
            {"delay", 0f},
            {"easeType",iTween.EaseType.linear},
            {"loopType",iTween.LoopType.pingPong},
            {"onupdate", "OnUpdateBlink"},
            {"onupdatetarget", gameObject},
        };
        iTween.ValueTo(gameObject, hashGlow);

    }


    public void OnUpdateBlink(float NextA)
    {
        Color NextGlow = Myself.GetComponent<Image>().color;
        NextGlow.a = NextA;

        Myself.GetComponent<Image>().color = NextGlow;

    }


    // Use this for initialization
    void Start()
    {
        Blink();
    }

    // Update is called once per frame
    void Update()
    {
        if (BlinkFlag == 0)
        {
            Blink();
        }
    }
}
