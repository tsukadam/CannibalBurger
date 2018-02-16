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

    //CustomerControllerから開始時に渡される、客データの行情報
    public int LowName;
    public int LowImage;
    public int LowPopLv;
    public int LowDisLv;
    public int LowRare;
    public int LowHp;
    public int LowCoreColor;
    public int LowSaveSus;
    public int LowDropG;
    public int LowDropName;
    public int LowDropImage;
    public int LowDropPower;
    public int LowDropSus;
    public int LowMeatName;
    public int LowMeatImage;
    public int LowMeatPower;
    public int LowMeatSus;

    //レアリティを数字に変換、高いほど強い
    public int GetRarerityInt(string Rarerity)
    {
        int Result=0;
        if (Rarerity == "C") { Result = 0; }
        else if (Rarerity == "UC") { Result = 1; }
        else if (Rarerity == "R") { Result = 2; }
        else if (Rarerity == "SR") { Result = 3; }
        else if (Rarerity == "SSR") { Result = 4; }

        return Result;
    }

    //初回アイテムの生成
    public void MakeItemFirst()
    {
        StatGame.GetComponent<StatGame>().Item1 = new string[] { "ネズミにく", "niku1", "10", "#ff0000", "0" };
        StatGame.GetComponent<StatGame>().Item2 = new string[] { "どてカボチャ", "niku1", "15", "#00ff00", "0" };
        StatGame.GetComponent<StatGame>().Item3 = new string[] { "かびチーズ", "niku1", "20", "#0000ff", "0" };
        StatGame.GetComponent<StatGame>().Item4 = new string[] { "きみょうなにく", "niku1", "40", "#666666", "100" };
    }

    //初回客の生成
    public void MakeCustomerFirst()
    {

        MakeCustomerNormal();
    }

    //レアリティ別出現確率調整
    public string GetRarerity()
    {
        string ResultRarerity="";
        int ProbableC = 50;
        int ProbableUC = 30;
        int ProbableR = 10;
        int ProbableSR = 8;
        int ProbableSSR = 2;
        int RandomCount = Random.Range(0, ProbableC+ ProbableUC+ ProbableR+ ProbableSR+ ProbableSSR);

        if (RandomCount >= 0 & RandomCount <= ProbableC) { ResultRarerity = "C"; }
        else if (RandomCount >= ProbableC & RandomCount <= ProbableC+ ProbableUC) { ResultRarerity = "UC"; }
        else if (RandomCount >= ProbableC+ ProbableUC & RandomCount <= ProbableC + ProbableUC+ ProbableR) { ResultRarerity = "R"; }
        else if (RandomCount >= ProbableC + ProbableUC+ ProbableR & RandomCount <= ProbableC + ProbableUC + ProbableR+ ProbableSR) { ResultRarerity = "SR"; }
        else { ResultRarerity = "SSR"; }

        return ResultRarerity;
    }

    //通常客の生成
    public void MakeCustomerNormal()
    {
        int GameLv = StatGame.GetComponent<StatGame>().StatLv;

        string SelectedName;
        string SelectedImage;
        string SelectedHp;
        int SelectedHpInt;
        string SelectedCoreColor;
        string SelectedColor;
        string SelectedDropG;
        int SelectedDropGInt;
        string SelectedDropName;
        string SelectedDropImage;
        string SelectedDropPower;
        int SelectedDropPowerInt;
        string SelectedDropColor;
        string SelectedDropSus;
        int SelectedDropSusInt;
        string SelectedMeatName;
        string SelectedMeatImage;
        string SelectedMeatPower;
        int SelectedMeatPowerInt;
        string SelectedMeatColor;
        string SelectedMeatSus;
        int SelectedMeatSusInt;
        string SelectedSaveSus;
        int SelectedSaveSusInt;
        string SelectedRare;
        string SelectedPopLv;
        int SelectedPopLvInt;
        string SelectedDisLv;
        int SelectedDisLvInt;


        int count = 0;
        while (count < GameLv+4)
        {
            string[,] UseCustomer;
            string ThisRarerity = GetRarerity();
 
            if (ThisRarerity == "C") {
                if (StatGame.GetComponent<StatGame>().CustmerC[0, 0] == "None")
                {
                    UseCustomer = StatGame.GetComponent<StatGame>().CustmerUC;
                }
                else {
                    UseCustomer = StatGame.GetComponent<StatGame>().CustmerC;
                }
            }
            else if (ThisRarerity == "UC")
            {
                if (StatGame.GetComponent<StatGame>().CustmerUC[0, 0] == "None")
                {
                    UseCustomer = StatGame.GetComponent<StatGame>().CustmerC;
                }
                else { UseCustomer = StatGame.GetComponent<StatGame>().CustmerUC; }
            }
            else if (ThisRarerity == "R") {
                if (StatGame.GetComponent<StatGame>().CustmerR[0, 0] == "None")
                {
                    UseCustomer = StatGame.GetComponent<StatGame>().CustmerC;
                }
                else { UseCustomer = StatGame.GetComponent<StatGame>().CustmerR; }
            }
            else if (ThisRarerity == "SR") {
                if (StatGame.GetComponent<StatGame>().CustmerSR[0, 0] == "None")
                {
                    UseCustomer = StatGame.GetComponent<StatGame>().CustmerC;
                }
                else { UseCustomer = StatGame.GetComponent<StatGame>().CustmerSR; }
            }
            else {
                if (StatGame.GetComponent<StatGame>().CustmerSSR[0, 0] == "None")
                {
                    UseCustomer = StatGame.GetComponent<StatGame>().CustmerC;
                }
                else { UseCustomer = StatGame.GetComponent<StatGame>().CustmerSSR; } }

            int CustomerLength=UseCustomer.GetLength(0);
            int RandomCount = Random.Range(0,CustomerLength-1);




            SelectedName = UseCustomer[RandomCount,LowName];
            SelectedImage = UseCustomer[RandomCount, LowImage];
            SelectedHp = UseCustomer[RandomCount, LowHp];
            SelectedHpInt = int.Parse(SelectedHp);
            SelectedCoreColor = UseCustomer[RandomCount, LowCoreColor];
            SelectedColor = "";
            SelectedDropG = UseCustomer[RandomCount, LowDropG];
            SelectedDropGInt = int.Parse(SelectedDropG);
            SelectedDropName = UseCustomer[RandomCount, LowDropName];
            SelectedDropImage = UseCustomer[RandomCount, LowDropImage];
            SelectedDropPower = UseCustomer[RandomCount, LowDropPower];
            SelectedDropColor = "";
            SelectedDropSus = UseCustomer[RandomCount, LowDropSus];
            SelectedMeatName = UseCustomer[RandomCount, LowMeatName];
            SelectedMeatImage = UseCustomer[RandomCount, LowMeatImage];
            SelectedMeatPower = UseCustomer[RandomCount, LowMeatPower];
            SelectedMeatColor = "";
            SelectedMeatSus = UseCustomer[RandomCount, LowMeatSus];
            SelectedSaveSus = UseCustomer[RandomCount, LowSaveSus];
            SelectedSaveSusInt = int.Parse(SelectedSaveSus);
            SelectedRare = UseCustomer[RandomCount, LowRare];
            SelectedPopLv = UseCustomer[RandomCount, LowPopLv];
            SelectedPopLvInt = int.Parse(SelectedPopLv);
            SelectedDisLv = UseCustomer[RandomCount, LowDisLv];
            SelectedDisLvInt = int.Parse(SelectedDisLv);

            GetComponent<CustomerController>().MakeCustomer(
                SelectedName,
                SelectedImage, 
                SelectedHpInt,
                SelectedCoreColor,
                SelectedColor,
                SelectedDropGInt,
                new string[] { SelectedDropName, SelectedDropImage, SelectedDropPower, SelectedDropColor, SelectedDropSus },
                new string[] { SelectedMeatName, SelectedMeatImage, SelectedMeatPower, SelectedMeatColor, SelectedMeatSus },
                 SelectedSaveSusInt,
                 SelectedRare,
                 SelectedPopLvInt,
                 SelectedDisLvInt);
            count++;
        }

    }

    //レベルアップ判定
    public bool LvUpCondition()
    {
        int Exp = StatGame.GetComponent<StatGame>().StatExp;
        bool LvUpBool;
        if (Exp >= 100) { LvUpBool = true; }
        else { LvUpBool = false; }
        return LvUpBool;

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

        return GetGResult;
    }

    //EXP基数から取得EXPを計算して加算
    public int VictoryDropExp(int GetExp, int VictoryPoint)
    {
        int GameLv = StatGame.GetComponent<StatGame>().StatLv;
        float GameLvFloat = (float)GameLv;
        float ExpLimit = 1/(GameLvFloat/2);
        float ResultGetExp=(GetExp + GetExp * (VictoryPoint / 100))*ExpLimit;
        int ResultGetExpInt = (int)ResultGetExp;
        return ResultGetExpInt;
    }

    //表示上のEXP
    public string StringGetExp(int GetExp)
    {
        string ResultString;
        int GameLv = StatGame.GetComponent<StatGame>().StatLv;

        int Result = GetExp * GameLv;
        ResultString = Result.ToString();

            return ResultString;
    }
    //Sus基数から上昇Susを計算して加算
    public float FeedGetSus(float GetSus)
    {
        float ResultGetSus=GetSus;
        return ResultGetSus;

    }
    public string[] GetPickUpItem()
    {

        string[] PickUpItem= { "ネズミにく","niku1","10","#666666","0"};
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
