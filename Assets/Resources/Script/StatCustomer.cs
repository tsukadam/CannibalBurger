using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Coffee.UIExtensions;

//客のステータスを保持する
//cloneして使う
public class StatCustomer : MonoBehaviour
{

    //ステータスの定義
    public int Id = 0;//名前
    public string Name = "name";//名前
    public string Image = "image";//イメージのファイル名（.png抜き）
    public int Hp = 0;//舌の肥え具合
    public string CoreColor = "corecolor";//中心色　あれば色の算出に使う
    public string Color = "color";//色
    public int DropG = 0;//報酬G
    public string[] DropItem = { "Name", "PictuePath", "Power", "Color", "Sus" };//報酬アイテム（固定）
    public string[] DropMeat = { "Name", "PictuePath", "Power", "Color", "Sus" };//肉にした場合の能力
    public int SaveSus = 0;//殺した場合のSus減少値
    public string Rarerity = "";//レアリティ
    public int LvAppear = 0;//出現レベル
    public int LvDisAppear = 999;//いなくなるレベル

    //計算用の記録領域
    public int PointPower = 0;//点数での勝利度合
    public float PointColor = 0;//色での勝利度合

    //ステータス表示オブジェクトの取得
    public GameObject Customer;//自分自身
    
    public Color CusCol;
    public float ColorChangeSpan = 0.2f;

    //グローの光りをオンにする
    public void Glow()
    {
        Customer.GetComponent<UIEffect>().enabled = true;

        CusCol = Customer.GetComponent<Image>().color;
        float CusR = CusCol.r;
        float CusG = CusCol.g;
        float CusB = CusCol.b;
        CusR -= ColorChangeSpan;
        CusG -= ColorChangeSpan;
        CusB -= ColorChangeSpan;
        Customer.GetComponent<Image>().color = new Color(CusR,CusG,CusB,1.0f);

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

        Color NextGlow = Customer.GetComponent<UIEffect>().shadowColor;
        NextGlow.a = NextA;

        Customer.GetComponent<UIEffect>().shadowColor = NextGlow;

        Color NextCol = Customer.GetComponent<Image>().color;
        float NextR = NextCol.r;
        float NextG = NextCol.g;
        float NextB = NextCol.b;

        if (NextPoint <= 1/4+ColorChangeSpan)
        {
            NextR += NextPoint*8/5;
            NextG += NextPoint * 8 / 5;
            NextB += NextPoint * 8 / 5;
        }
        else if (NextPoint == 0)
        {
            NextR += CusCol.r;
            NextG += CusCol.g;
            NextB += CusCol.b;

        }
        else {
        }

        NextCol = new UnityEngine.Color(NextR, NextG, NextB, 1.0f);

        Customer.GetComponent<Image>().color = NextCol;



    }

    // Use this for initialization
    void Start()
    {




    }

    // Update is called once per frame
    void Update()
    {
    }
}
