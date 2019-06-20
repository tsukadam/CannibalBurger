using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Coffee.UIExtensions;

public class Glower : MonoBehaviour {
    //ステータス表示オブジェクトの取得
    public GameObject Myself;//自分自身
    int GlowFlag = 0;

    public void Glow()
    {
        GlowFlag = 1;
       Myself.GetComponent<UIEffect>().enabled = true;

        Hashtable hashGlow = new Hashtable(){
            {"from", 0},
            {"to", 0.2f},
            {"time", 1.0f},
            {"delay", 0f},
            {"easeType",iTween.EaseType.linear},
            {"loopType",iTween.LoopType.pingPong},
            {"onupdate", "OnUpdateGlow"},
            {"onupdatetarget", gameObject},
        };
        iTween.ValueTo(gameObject, hashGlow);

    }

    public void GlowStop()
    {
        GlowFlag = 0;

        //       Myself.GetComponent<UIEffect>().enabled = false;
        iTween.Stop(Myself, "value");
    }


    public void OnUpdateGlow(float NextA)
    {
        Color NextGlow = Myself.GetComponent<UIEffect>().shadowColor;
        NextGlow.a = NextA;

        Myself.GetComponent<UIEffect>().shadowColor = NextGlow;

    }


    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (Myself != null)
        {
            if (GlowFlag == 0 & Myself.GetComponent<Button>().interactable == true)
            {

                Glow();

            }
            if (Myself.GetComponent<Button>().interactable == false)
            {
                GlowStop();

            }
        }
	}
}
