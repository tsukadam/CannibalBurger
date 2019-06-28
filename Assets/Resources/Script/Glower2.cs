using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using Coffee.UIExtensions;

public class Glower2 : MonoBehaviour
{
    //ステータス表示オブジェクトの取得
    public GameObject Script;
    public GameObject Myself;//自分自身
    int GlowFlag = 0;
    public float ColorChangeSpan = 0.01f;
    Color MotoColor;
    public Color CusCol;

    //グローの光りをオンにする
    public void GlowRareType()
    {
        Myself.GetComponent<UIEffect>().enabled = true;

        CusCol = Myself.GetComponent<Text>().color;
        MotoColor = Myself.GetComponent<Text>().color;
        float CusR = CusCol.r;
        float CusG = CusCol.g;
        float CusB = CusCol.b;
        CusR += ColorChangeSpan;
        CusG += ColorChangeSpan;
        CusB += ColorChangeSpan;
        Myself.GetComponent<Text>().color = new Color(CusR, CusG, CusB, 1.0f);

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
    //グローの光りをオフにする
    public void GlowRareTypeStop()
    {
        Myself.GetComponent<UIEffect>().enabled = false;
        Myself.GetComponent<Text>().color = Script.GetComponent<GameController>().GYellow;
        iTween.Stop(Myself);
    }


    public void OnUpdateGlow(float NextPoint)
    {
        float NextA;
        NextA = (NextPoint + ColorChangeSpan) * 5 / (20 * ColorChangeSpan);

        Color NextGlow = Myself.GetComponent<UIEffect>().shadowColor;
        NextGlow.a = NextA;

        Myself.GetComponent<UIEffect>().shadowColor = NextGlow;

        Color NextCol = Myself.GetComponent<Text>().color;
        float NextR = NextCol.r;
        float NextG = NextCol.g;
        float NextB = NextCol.b;

        if (NextPoint <= 1 / 4 + ColorChangeSpan)
        {
            NextR += NextPoint * 1 / 15;
            NextG += NextPoint * 1 / 15;
            NextB += NextPoint * 1 / 15;
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

        Myself.GetComponent<Text>().color = NextCol;



    }
    private void OnDisable()
    {
        GlowRareTypeStop();
    }

    // Use this for initialization
    void Start()
    {
        Myself.GetComponent<Text>().color = Script.GetComponent<GameController>().GYellow;
        MotoColor = Myself.GetComponent<Text>().color;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
