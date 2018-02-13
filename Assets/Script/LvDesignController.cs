using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//プレイ中のステータスを保持する
public class LvDesignController : MonoBehaviour
{
    //プレイヤーstat
    public GameObject StatPlayer;
    //ゲームstat
    public GameObject StatGame;


    //初回アイテムの生成
    public void MakeItemFirst()
    {
        StatGame.GetComponent<StatGame>().Item1 = new string[] { "初期肉１", "niku1", "10", "#ff0000", "0" };
        StatGame.GetComponent<StatGame>().Item2 = new string[] { "初期肉２", "niku1", "15", "#00ff00", "0" };
        StatGame.GetComponent<StatGame>().Item3 = new string[] { "初期肉３", "niku1", "20", "#0000ff", "0" };
        StatGame.GetComponent<StatGame>().Item4 = new string[] { "初期人肉４", "niku1", "40", "#666666", "6" };
    }

    //初回客の生成
    public void MakeCustomerFirst()
    {

        int count = 0;
        while (count < 20)
        {
            int RandomHp = Random.Range(10, 40);
            //            int RandomImage = Random.Range(1, 4);
            GetComponent<CustomerController>().MakeCustomer("ドクター・ヤブ", "doc", RandomHp, "#ff0000", "", 2, new string[] { "患者の肉", "niku1", "10", "Color", "0.05" }, new string[] { "医者の肉", "niku1", "100", "Color", "0.1" }, 0);
            count++;
        }

    }

    //通常客の生成
    public void MakeCustomerNormal()
    {

        int count = 0;
        while (count < 20)
        {
            int RandomHp = Random.Range(10, 40);
            //            int RandomImage = Random.Range(1, 4);
            GetComponent<CustomerController>().MakeCustomer("ドクター・ヤブ", "doc", RandomHp, "#0000ff", "", 2, new string[] { "患者の肉", "niku1", "10", "Color", "0.05" }, new string[] { "医者の肉", "niku1", "100", "Color", "0.1" }, 0);
            count++;
        }

    }


    //Feedでの勝利条件
    //使ったアイテムのパワーと客ＨＰとの関係で定義
    //あと色
    public int VictoryCondition(int UseItemPower,int CustomerHp, string UseItemColor, string CustomerColor)
    {
        Color UseColor = GetComponent<ColorGetter>().ToColor(UseItemColor);
        Color CustomColor = GetComponent<ColorGetter>().ToColor(CustomerColor);
        float UseR = UseColor.r;
        float UseG = UseColor.g;
        float UseB = UseColor.b;
        float CusR = CustomColor.r;
        float CusG = CustomColor.g;
        float CusB = CustomColor.b;

        float DistanceR = Mathf.Abs(UseR-CusR);
        float DistanceG = Mathf.Abs(UseG - CusG);
        float DistanceB = Mathf.Abs(UseB - CusB);

        float DistancePer = Mathf.Ceil(100 - ((DistanceR + DistanceG + DistanceB) * 100 / 3));
        int DistancePerInt = (int)DistancePer;

        return (UseItemPower + (UseItemPower * (2 * DistancePerInt) / 100)) - CustomerHp;//色完全一致で３００％の力になる
    }

        //賞金基数から取得Ｇを計算して返す
public int VictoryDropG(int GetG,int VictoryPoint)
    {
        int GetGResult = GetG+ GetG * (VictoryPoint/10);

        GetComponent<StatGameController>().GUp(GetGResult);
        return GetGResult;
    }

    //EXP基数から取得EXPを計算して加算
    public int VictoryDropExp(int GetExp, int VictoryPoint)
    {
        int ResultGetExp=GetExp + GetExp * (VictoryPoint / 100);
        GetComponent<StatGameController>().ExpUp(ResultGetExp);
        return ResultGetExp;
    }

    //Sus基数から上昇Susを計算して加算
    public float FeedGetSus(float GetSus)
    {
        float ResultGetSus=GetSus;
        GetComponent<StatGameController>().SusUp(ResultGetSus);
        return ResultGetSus;

    }
    public string[] GetPickUpItem()
    {

        string[] PickUpItem= { "適当な肉","niku1","10","#666666","0"};
        return PickUpItem;

    }
    //レベルアップ時のSus減少計算して加算
    public void LvUpSaveSus()
    {
        int NowLv = StatGame.GetComponent<StatGame>().StatLv;
        GetComponent<StatGameController>().SusUp(-10);//常に１０下げる
    }
    //イベントシステムの取得（処理中に切る場合がある）
    public GameObject EventSystem;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
