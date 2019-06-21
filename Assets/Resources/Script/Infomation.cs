using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Coffee.UIExtensions;

public class Infomation : MonoBehaviour
{
    public GameObject Self;//自分自身
                           //ステータスの定義
    public string CoreColor = "corecolor";//中心色　あれば色の算出に使う
    public string Color = "color";//色


    public Color CusCol;
    public float ColorChangeSpan = 0.4f;
    public GameObject ParticleG;

    public void GlowOff()
    {
        Self.GetComponent<UIEffect>().enabled = false;

    }
    //グローの光りをオンにする
    public void Glow()
    {
        Self.GetComponent<UIEffect>().enabled = true;

        CusCol = Self.GetComponent<Image>().color;
        float CusR = CusCol.r;
        float CusG = CusCol.g;
        float CusB = CusCol.b;
        CusR -= ColorChangeSpan;
        CusG -= ColorChangeSpan;
        CusB -= ColorChangeSpan;
        Self.GetComponent<Image>().color = new Color(CusR, CusG, CusB, 1.0f);

        Hashtable hashGlow = new Hashtable(){
            {"from", ColorChangeSpan*-1},
            {"to", ColorChangeSpan},
            {"time", 0.75f},
            {"delay", 0f},
            {"easeType",iTween.EaseType.linear},
            {"loopType",iTween.LoopType.pingPong},
            {"onupdate", "OnUpdateGlow"},
            {"onupdatetarget", gameObject},
        };
        iTween.ValueTo(gameObject, hashGlow);
    }


    public void OnUpdateGlow(float NextPoint)
    {
        float NextA;
        NextA = (NextPoint + ColorChangeSpan) * 5 / (20 * ColorChangeSpan);

        Color NextGlow = Self.GetComponent<UIEffect>().shadowColor;
        NextGlow.a = NextA;

        Self.GetComponent<UIEffect>().shadowColor = NextGlow;

        Color NextCol = Self.GetComponent<Image>().color;
        float NextR = NextCol.r;
        float NextG = NextCol.g;
        float NextB = NextCol.b;

        if (NextPoint <= 1 / 4 + ColorChangeSpan)
        {
            NextR += NextPoint * 8 / 5;
            NextG += NextPoint * 8 / 5;
            NextB += NextPoint * 8 / 5;
        }
        else if (NextPoint == 0)
        {
            NextR += CusCol.r;
            NextG += CusCol.g;
            NextB += CusCol.b;

        }
        else
        {
        }

        NextCol = new UnityEngine.Color(NextR, NextG, NextB, 1.0f);

        Self.GetComponent<Image>().color = NextCol;

    }

        public void OpenInfo()    // Use this for initialization
    {
        GameObject StatPlayer = GameObject.FindGameObjectWithTag("StatPlayer");
        int Id = Self.GetComponent<StatCustomer>().Id;


        StatPlayer.GetComponent<StatPlayer>().Infomation(Id);
    }


    public void SountOpenInfo()    // Use this for initialization
    {
        GameObject Script = GameObject.FindGameObjectWithTag("Script");


        Script.GetComponent<SoundController>().ButtonOpenInfo() ;
    }



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }
}
