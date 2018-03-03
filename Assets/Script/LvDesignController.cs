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
    public int LowId;
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

    //レベルデザインデータの行情報
    public int LowNeedExp;
    public int LowCustomerNum;
    public int LowRateC;
    public int LowRateUC;
    public int LowRateR;
    public int LowRateSus;
    public int LowLvUpSus;

    //今のレベルでのレベルデザインデータ
    public int NeedExp;
    public int CustomerNum;
    public float RateC;
    public float RateUC;
    public float RateR;
    public float RateSus;
    public int LvUpSus;

    public int LvDesignDataGetCount=0;

    public int LvDesignLowNumber;

    //そのレベルの情報を保持する、レベルアップ時に走る
    //初回は列番号のデータを取得
    public void GetLvDesignData()
    {
        string[,] LvDesignData = StatGame.GetComponent<StatGame>().LvDesignData;

        int LvLength = LvDesignData.GetLength(0);
        int LowCount = 0;

        //初回のみ、どの行に何のデータがあるか取得する
        if (LvDesignDataGetCount == 0)
        {

            int LvDesignLowLength = LvDesignData.GetLength(1);
            LowCount = 0;
            while (LowCount < LvDesignLowLength)
            {
                if (LvDesignData[0, LowCount] == "NeedExp") { LowNeedExp = LowCount; }
                else if (LvDesignData[0, LowCount] == "CustomerNum") { LowCustomerNum = LowCount; }
                else if (LvDesignData[0, LowCount] == "RateC") { LowRateC = LowCount; }
                else if (LvDesignData[0, LowCount] == "RateUC") { LowRateUC = LowCount; }
                else if (LvDesignData[0, LowCount] == "RateR") { LowRateR = LowCount; }
                else if (LvDesignData[0, LowCount] == "RateSus") { LowRateSus = LowCount; }
                else if (LvDesignData[0, LowCount] == "LvUpSus") { LowLvUpSus = LowCount; }
                else { Debug.Log("Customerデータの行の取得に失敗しました Low=" + LowCount); }
                LowCount++;
            }
            LvDesignDataGetCount = 1;
            LvDesignLowNumber = LowCount;//列の数を記録
        }

        LowCount = LvDesignLowNumber;//二回目以降は記録された数から読む
        int NowLv = StatGame.GetComponent<StatGame>().StatLv;
        NeedExp = int.Parse(LvDesignData[NowLv, LowNeedExp]);
    CustomerNum = int.Parse(LvDesignData[NowLv, LowCustomerNum]);
        RateC = float.Parse(LvDesignData[NowLv, LowRateC]);
        RateUC = float.Parse(LvDesignData[NowLv, LowRateUC]);
        RateR= float.Parse(LvDesignData[NowLv, LowRateR]);
    RateSus= float.Parse(LvDesignData[NowLv, LowRateSus]);
    LvUpSus= int.Parse(LvDesignData[NowLv, LowLvUpSus]);

}

    //レアリティを数字に変換
    public int GetRarerityInt(string Rarerity)
    {
        int Result=0;
        if (Rarerity == "C") { Result = 0; }
        else if (Rarerity == "UC") { Result = 1; }
        else if (Rarerity == "R") { Result = 2; }
        else if (Rarerity == "Sus") { Result = 3; }
        else{ Result = 0; Debug.Log("レアリティを数字に変換できません。Cにしました"); }

        return Result;
    }

    //初回アイテムの生成
    public void MakeItemFirst()
    {
        StatGame.GetComponent<StatGame>().Item1 = new string[] { "にく", "NikuSyou", "1", "#dd6645", "0" };
        StatGame.GetComponent<StatGame>().Item2 = new string[] { "レタス", "Retasu", "1", "#88cc66", "0" };
        StatGame.GetComponent<StatGame>().Item3 = new string[] { "チーズ", "CheezeSyou", "1", "#dddd77", "0" };
        StatGame.GetComponent<StatGame>().Item4 = new string[] { "チーズ", "CheeseTyuu", "2", "#ebebdd", "0" };
    }

    //初回客の生成
    public void MakeCustomerFirst()
    {
        //特に初回らしいことはしていない
        //なんかしたければここで
        MakeCustomerNormal();
    }

    //レアリティ別出現確率調整
    public string GetRarerity()
    {
        string ResultRarerity="";
        int ProbableC = (int)RateC;
        int ProbableUC = (int)RateUC;
        int ProbableR = (int)RateR;
        int ProbableSus = (int)RateSus;


        int RandomCount = Random.Range(0, ProbableC+ ProbableUC+ ProbableR+ ProbableSus);

        if (RandomCount >= 0 & RandomCount <= ProbableC) { ResultRarerity = "C"; }
        else if (RandomCount >= ProbableC & RandomCount <= ProbableC+ ProbableUC) { ResultRarerity = "UC"; }
        else if (RandomCount >= ProbableC+ ProbableUC & RandomCount <= ProbableC + ProbableUC+ ProbableR) { ResultRarerity = "R"; }
        else if (RandomCount >= ProbableC + ProbableUC+ ProbableR & RandomCount <= ProbableC + ProbableUC + ProbableR+ ProbableSus) { ResultRarerity = "SUS"; }
        else { ResultRarerity = "C";Debug.Log("レアリティの出現確率調整に失敗しました。Cにしました"); }

        return ResultRarerity;
    }
    //セーブされたidから客を生成
    public void MakeSavedCustomer()
    {
        int CIDLength = StatPlayer.GetComponent<StatPlayer>().CID.Length;
        int Count = 0;
        while (Count < CIDLength)
        {
            if (StatPlayer.GetComponent<StatPlayer>().CID[Count] != 0)
            {
                MakeCustomerId(StatPlayer.GetComponent<StatPlayer>().CID[Count]);
            }
            Count++;
        }

    }

    //入れたidの客を生成する
    public void MakeCustomerId(int Id)
    {
        string SelectedId;
        int SelectedIdInt;
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
        string SelectedDropColor;
        string SelectedDropSus;
        string SelectedMeatName;
        string SelectedMeatImage;
        string SelectedMeatPower;
        string SelectedMeatColor;
        string SelectedMeatSus;
        string SelectedSaveSus;
        int SelectedSaveSusInt;
        string SelectedRare;
        string SelectedPopLv;
        int SelectedPopLvInt;
        string SelectedDisLv;
        int SelectedDisLvInt;

        string IdString = Id.ToString();
        string[,] CustomerAllData = StatGame.GetComponent<StatGame>().CustomerAllData;
        int CustomerLength = CustomerAllData.GetLength(0);
        int CustomerLowLength = CustomerAllData.GetLength(1);
        int Count = 1;
        int Count2 = 0;
        string[] UseCustomer = new string[CustomerLowLength];
        Debug.Log("id:"+Id);

        while (Count < CustomerLength)
        {
            Debug.Log(Count);
            if (CustomerAllData[Count,LowId] == IdString)
            {
                Count2 = 0;
                while (Count2 < CustomerLowLength)
                {
                    UseCustomer[Count2] = CustomerAllData[Count, Count2];
                    Count2++;
                }
                break;
            }
            else if (Count == CustomerLength-1)
            {
                Debug.Log("指定されたidの客は存在しません。一列目の客の情報を入れます");
                Count2 = 0;
                while (Count2 < CustomerLowLength)
                {
                    UseCustomer[Count2] = CustomerAllData[1, Count2];
                    Count2++;
                }

            }
            Count++;
        }


        SelectedId = UseCustomer[LowId];
        SelectedIdInt = int.Parse(SelectedId);
        SelectedName = UseCustomer[LowName];
        SelectedImage = UseCustomer[LowImage];
        SelectedHp = UseCustomer[LowHp];
        SelectedHpInt = int.Parse(SelectedHp);
        SelectedCoreColor = UseCustomer[LowCoreColor];
        SelectedColor = "";
        SelectedDropG = UseCustomer[LowDropG];
        SelectedDropGInt = int.Parse(SelectedDropG);
        SelectedDropName = UseCustomer[LowDropName];
        SelectedDropImage = UseCustomer[LowDropImage];
        SelectedDropPower = UseCustomer[LowDropPower];
        SelectedDropColor = "";
        SelectedDropSus = UseCustomer[LowDropSus];
        SelectedMeatName = UseCustomer[LowMeatName];
        SelectedMeatImage = UseCustomer[LowMeatImage];
        SelectedMeatPower = UseCustomer[LowMeatPower];
        SelectedMeatColor = "";
        SelectedMeatSus = UseCustomer[LowMeatSus];
        SelectedSaveSus = UseCustomer[LowSaveSus];
        SelectedSaveSusInt = int.Parse(SelectedSaveSus);
        SelectedRare = UseCustomer[LowRare];
        SelectedPopLv = UseCustomer[LowPopLv];
        SelectedPopLvInt = int.Parse(SelectedPopLv);
        SelectedDisLv = UseCustomer[LowDisLv];
        SelectedDisLvInt = int.Parse(SelectedDisLv);

        GetComponent<CustomerController>().MakeCustomer(
    SelectedIdInt,
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
    
}
    //通常客の生成
    public void MakeCustomerNormal()
    {
        int GameLv = StatGame.GetComponent<StatGame>().StatLv;

        string SelectedId;
        int SelectedIdInt;
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
        string SelectedDropColor;
        string SelectedDropSus;
        string SelectedMeatName;
        string SelectedMeatImage;
        string SelectedMeatPower;
        string SelectedMeatColor;
        string SelectedMeatSus;
        string SelectedSaveSus;
        int SelectedSaveSusInt;
        string SelectedRare;
        string SelectedPopLv;
        int SelectedPopLvInt;
        string SelectedDisLv;
        int SelectedDisLvInt;


        int count = 0;
        //そのレアリティの客がそのレベル帯にいない場合、別のレアリティのを入れる。
        //※代替レアリティの客が存在する保証はプログラム内にはない
        
        while (count < CustomerNum)
        {
            string[,] UseCustomer;
            string ThisRarerity = GetRarerity();
 
            if (ThisRarerity == "C") {
                if (StatGame.GetComponent<StatGame>().CustmerC[0, 0] == "None")
                {
                    UseCustomer = StatGame.GetComponent<StatGame>().CustmerUC;
        Debug.Log("CがいないのでUCにしました");
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
                    Debug.Log("UCがいないのでCにしました");

                }
                else { UseCustomer = StatGame.GetComponent<StatGame>().CustmerUC; }
            }
            else if (ThisRarerity == "R") {
                if (StatGame.GetComponent<StatGame>().CustmerR[0, 0] == "None")
                {
                    UseCustomer = StatGame.GetComponent<StatGame>().CustmerC;
                    Debug.Log("RがいないのでCにしました");
                }
                else { UseCustomer = StatGame.GetComponent<StatGame>().CustmerR; }
            }
            else if (ThisRarerity == "SUS") {
                if (StatGame.GetComponent<StatGame>().CustmerSus[0, 0] == "None")
                {
                    UseCustomer = StatGame.GetComponent<StatGame>().CustmerC;
                    Debug.Log("SUSがいないのでCにしました");
                }
                else { UseCustomer = StatGame.GetComponent<StatGame>().CustmerSus; }
            }
            else {
                    UseCustomer = StatGame.GetComponent<StatGame>().CustmerC;
                Debug.Log("レアリティが変です。Cにしました");
            }

            int CustomerLength=UseCustomer.GetLength(0);
            int RandomCount = Random.Range(0,CustomerLength-1);



            SelectedId = UseCustomer[RandomCount, LowId];
            SelectedIdInt = int.Parse(SelectedId);
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
                SelectedIdInt,
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

    //色距離の計算
    public int ColorCondition(string UseItemColor, string CustomerColor)
    {
        Color UseColor = GetComponent<ColorGetter>().ToColor(UseItemColor);
        Color CustomColor = GetComponent<ColorGetter>().ToColor(CustomerColor);
        float UseR = UseColor.r;
        float UseG = UseColor.g;
        float UseB = UseColor.b;
        float CusR = CustomColor.r;
        float CusG = CustomColor.g;
        float CusB = CustomColor.b;

        //RGB差の計算
        float DistanceR = Mathf.Abs(UseR - CusR)*255;
        float DistanceG = Mathf.Abs(UseG - CusG) * 255;
        float DistanceB = Mathf.Abs(UseB - CusB) * 255;
        float DistanceRGB = DistanceR + DistanceG + DistanceB;

        //HDTV差の計算
        float Ganma = 2.2f;
        float UseHDTV = Mathf.Pow(Mathf.Pow(UseR, Ganma) * 0.222015f + Mathf.Pow(UseG, Ganma) * 0.706655f + Mathf.Pow(UseB, Ganma) * 0.071330f, 1 / Ganma);
        float CusHDTV = Mathf.Pow(Mathf.Pow(CusR, Ganma) * 0.222015f + Mathf.Pow(CusG, Ganma) * 0.706655f + Mathf.Pow(CusB, Ganma) * 0.071330f, 1 / Ganma);

        float DistanceHDTV = Mathf.Abs(UseHDTV - CusHDTV);
        float DC = (DistanceHDTV * 2 + DistanceRGB) / 100;

        float Per;
        //0<DistancePer<1275
        //倍率の算出
        if (DC > 3.5) { Per = 0.5f; }
        else {
            Per = (1f*(1 / Mathf.Pow(13 / 4f, DC)) * 4 + DC / 30)+1f/4;
        }
        //f(x)=((1/(13/4)^x)*4-x/30)+1/4
        //色距離0で4倍、0.5で3倍、1.2で2倍、2.45で等倍、3.5以上は1/2
        Per *= 100;
        int PerInt = (int)Per;
     //   Debug.Log(DC+"→"+PerInt);
        return PerInt;
    }
    //客に対する勝利条件
    //使ったアイテムのパワーと客ＨＰと色倍率で定義
    //勝利点を返す
    public float VictoryCondition(int UseItemPower,int CustomerHp, int RateColor)
    {
        float FloatItem = (float)UseItemPower;
        float FloatHp = (float)CustomerHp;
        float FloatColor = (float)RateColor;
        float Vic = (FloatItem * FloatColor / 100 - FloatHp) / FloatHp;
        Debug.Log(UseItemPower+":"+CustomerHp+":"+RateColor+"="+Vic);
        return Vic;
    }

        //取得Ｇを計算して返す
public int VictoryDropG(int GetG,float VictoryPoint)
    {
        //勝利幅の1/10が加算される（微増、５に対して６で勝利したら幅１で5.1点となる。１０で勝利しても5.5点）
        float GetGResult = GetG + GetG * (VictoryPoint / 10);

        int IntGetGResult = (int)GetGResult;

        return IntGetGResult;
    }

    //取得EXPを計算して返す
    public int VictoryDropExp(int GetExp, float VictoryPoint)
    {
        int GameLv = StatGame.GetComponent<StatGame>().StatLv;
        //勝利幅の1/10が加算される（微増、５に対して６で勝利したら幅１で5.1点となる。１０で勝利しても5.5点）
        float FloatGetExp = GetExp + GetExp * (VictoryPoint / 10);

        //そのレベルの必要Expを100として、取得したExp画素がいくつかを計算
        float FloatNeedExp = (float)NeedExp;
        float ResultGetExp= FloatGetExp*100/FloatNeedExp;
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

        string[] PickUpItem= { "ネズミにく", "NezunikuSyou", "1", "#d9cac7", "0"};
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
