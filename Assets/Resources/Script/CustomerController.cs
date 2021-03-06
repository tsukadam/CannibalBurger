﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Coffee.UIExtensions;

//客の生成を制御する
public class CustomerController : MonoBehaviour
{

    //客プレファブ
    public GameObject CustomerPrefab;
    public GameObject CustomerLibraryPrefab;

    //gamestat
    public GameObject StatGame;
    public GameObject StatPlayer;

    public GameObject CustomerField;//表示スペース
    public GameObject LibraryField;//ライブラリ表示スペース

    //イベントシステムの取得（処理中に切る場合がある）
    public GameObject EventSystem;

    public Text DebugLog;

    public int LowDataGetCount=0;

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
    public int LowText;

    public int LowNumber;

    //そのレベルの客をレアリティごとの配列にして保持する
    public void GetCustomerData(int NowLv)
    {

        string[,] CustomerAllData = StatGame.GetComponent<StatGame>().CustomerAllData;

        int CustomerLength = CustomerAllData.GetLength(0);
        int Count = 1;
        int ThisPopLv;
        int ThisDisLv;
        int LowCount = 0;



        //初回のみ、どの行に何のデータがあるか取得する
        if (LowDataGetCount == 0)
        {

            int CustomerLowLength = CustomerAllData.GetLength(1);
            LowCount = 0;
            while (LowCount < CustomerLowLength)
            {
                if (CustomerAllData[0, LowCount] == "Name") { LowName = LowCount; }
                else if (CustomerAllData[0, LowCount] == "Image") { LowImage = LowCount; }
                else if (CustomerAllData[0, LowCount] == "PopLv") { LowPopLv = LowCount; }
                else if (CustomerAllData[0, LowCount] == "DisLv") { LowDisLv = LowCount; }
                else if (CustomerAllData[0, LowCount] == "Rare") { LowRare = LowCount; }
                else if (CustomerAllData[0, LowCount] == "Hp") { LowHp = LowCount; }
                else if (CustomerAllData[0, LowCount] == "CoreColor") { LowCoreColor = LowCount; }
                else if (CustomerAllData[0, LowCount] == "SaveSus") { LowSaveSus = LowCount; }
                else if (CustomerAllData[0, LowCount] == "DropG") { LowDropG = LowCount; }
                else if (CustomerAllData[0, LowCount] == "DropName") { LowDropName = LowCount; }
                else if (CustomerAllData[0, LowCount] == "DImage") { LowDropImage = LowCount; }
                else if (CustomerAllData[0, LowCount] == "DPower") { LowDropPower = LowCount; }
                else if (CustomerAllData[0, LowCount] == "DSus") { LowDropSus = LowCount; }
                else if (CustomerAllData[0, LowCount] == "MeatName") { LowMeatName = LowCount; }
                else if (CustomerAllData[0, LowCount] == "MImage") { LowMeatImage = LowCount; }
                else if (CustomerAllData[0, LowCount] == "MPower") { LowMeatPower = LowCount; }
                else if (CustomerAllData[0, LowCount] == "MSus") { LowMeatSus = LowCount; }
                else if (CustomerAllData[0, LowCount] == "Id") { LowId = LowCount; }
                else if (CustomerAllData[0, LowCount] == "Text") { LowText = LowCount; }
                else { Debug.Log("Customerデータの行の取得に失敗しました Low="+ LowCount); }
                LowCount++;
            }


            GetComponent<LvDesignController>().LowId = LowId;
            GetComponent<LvDesignController>().LowName = LowName;
            GetComponent<LvDesignController>().LowImage = LowImage;
            GetComponent<LvDesignController>().LowPopLv = LowPopLv;
            GetComponent<LvDesignController>().LowDisLv = LowDisLv;
            GetComponent<LvDesignController>().LowRare = LowRare;
            GetComponent<LvDesignController>().LowHp = LowHp;
            GetComponent<LvDesignController>().LowCoreColor = LowCoreColor;
            GetComponent<LvDesignController>().LowSaveSus = LowSaveSus;
            GetComponent<LvDesignController>().LowDropG = LowDropG;
            GetComponent<LvDesignController>().LowDropName = LowDropName;
            GetComponent<LvDesignController>().LowDropImage = LowDropImage;
            GetComponent<LvDesignController>().LowDropPower = LowDropPower;
            GetComponent<LvDesignController>().LowDropSus = LowDropSus;
            GetComponent<LvDesignController>().LowMeatName = LowMeatName;
            GetComponent<LvDesignController>().LowMeatImage = LowMeatImage;
            GetComponent<LvDesignController>().LowMeatPower = LowMeatPower;
            GetComponent<LvDesignController>().LowMeatSus = LowMeatSus;
            GetComponent<LvDesignController>().LowText = LowText;

            StatPlayer.GetComponent<StatPlayer>().LowId = LowId;
            StatPlayer.GetComponent<StatPlayer>().LowName = LowName;
            StatPlayer.GetComponent<StatPlayer>().LowImage = LowImage;
            StatPlayer.GetComponent<StatPlayer>().LowPopLv = LowPopLv;
            StatPlayer.GetComponent<StatPlayer>().LowDisLv = LowDisLv;
            StatPlayer.GetComponent<StatPlayer>().LowRare = LowRare;
            StatPlayer.GetComponent<StatPlayer>().LowHp = LowHp;
            StatPlayer.GetComponent<StatPlayer>().LowCoreColor = LowCoreColor;
            StatPlayer.GetComponent<StatPlayer>().LowSaveSus = LowSaveSus;
            StatPlayer.GetComponent<StatPlayer>().LowDropG = LowDropG;
            StatPlayer.GetComponent<StatPlayer>().LowDropName = LowDropName;
            StatPlayer.GetComponent<StatPlayer>().LowDropImage = LowDropImage;
            StatPlayer.GetComponent<StatPlayer>().LowDropPower = LowDropPower;
            StatPlayer.GetComponent<StatPlayer>().LowDropSus = LowDropSus;
            StatPlayer.GetComponent<StatPlayer>().LowMeatName = LowMeatName;
            StatPlayer.GetComponent<StatPlayer>().LowMeatImage = LowMeatImage;
            StatPlayer.GetComponent<StatPlayer>().LowMeatPower = LowMeatPower;
            StatPlayer.GetComponent<StatPlayer>().LowMeatSus = LowMeatSus;
            StatPlayer.GetComponent<StatPlayer>().LowText = LowText;


            LowDataGetCount = 1;
            LowNumber = LowCount;//列の数を記録
        }

        LowCount = LowNumber;//二回目以降は記録された数から読む


        Count = 1;
        int CountC = 0;
        int CountUC = 0;
        int CountR = 0;
        int CountSus = 0;

        while (Count< CustomerLength){
            ThisPopLv = int.Parse(CustomerAllData[Count, LowPopLv]);
            ThisDisLv = int.Parse(CustomerAllData[Count, LowDisLv]);
//登場レベルの間にあるキャラなら処理する
//まずレアリティごとの数を数える
            if (NowLv>=ThisPopLv &NowLv<ThisDisLv) {
                if (CustomerAllData[Count, LowRare] == "C") { CountC++; }
                else if (CustomerAllData[Count, LowRare] == "UC") { CountUC++; }
                else if (CustomerAllData[Count, LowRare] == "R") { CountR++; }
                else if (CustomerAllData[Count, LowRare] == "SUS") { CountSus++; }
                else { Debug.Log("レアリティの仕分けに失敗しています。Cとして数えます。Column="+Count);
                    CountUC++;
                }
            }
            Count++;
        }
   //     Debug.Log("C="+CountC);
        string[,] CustmerC;
        string[,] CustmerUC;
        string[,] CustmerR;
        string[,] CustmerSus;

        if (CountC == 0) { CustmerC = new string[1, 1];CustmerC[0,0]="None"; }
        else {
            CustmerC = new string[CountC, LowCount];
        }
        if (CountUC == 0) { CustmerUC = new string[1, 1]; CustmerUC[0, 0] = "None"; }
        else {
            CustmerUC = new string[CountUC, LowCount];
        }
        if (CountR == 0) { CustmerR = new string[1, 1]; CustmerR[0, 0] = "None"; }
        else {
            CustmerR = new string[CountR, LowCount];
        }
        if (CountSus == 0) { CustmerSus = new string[1, 1]; CustmerSus[0, 0] = "None"; }
        else {
            CustmerSus = new string[CountSus, LowCount];
        }


        //もっかい回して配列を取得
        Count = 1;
        int CountSmall = 0;
        CountC = 0;
        CountUC = 0;
        CountR = 0;
        CountSus = 0;

        while (Count < CustomerLength)
        {
            ThisPopLv = int.Parse(CustomerAllData[Count, LowPopLv]);
            ThisDisLv = int.Parse(CustomerAllData[Count, LowDisLv]);
            //登場レベルの間にあるキャラなら処理する
            //まずレアリティごとの数を数える
            if( NowLv >= ThisPopLv & NowLv < ThisDisLv)
            {
                if (CustomerAllData[Count, LowRare] == "C") {
                    CountSmall = 0;
                    while (CountSmall<LowCount)
                    {
                        CustmerC[CountC, CountSmall] = CustomerAllData[Count, CountSmall];
                            CountSmall++;
                    }
                    CountC++; }
                else if (CustomerAllData[Count, LowRare] == "UC") {
                    CountSmall = 0;
                    while (CountSmall < LowCount)
                    {
                        CustmerUC[CountUC, CountSmall] = CustomerAllData[Count, CountSmall];
                        CountSmall++;
                    }
                    CountUC++;}
                else if (CustomerAllData[Count, LowRare] == "R") {
                    CountSmall = 0;
                    while (CountSmall < LowCount)
                    {
                        CustmerR[CountR, CountSmall] = CustomerAllData[Count, CountSmall];
                        CountSmall++;
                    }
                    CountR++; }
                else if (CustomerAllData[Count, LowRare] == "SUS") {
                    CountSmall = 0;
                    while (CountSmall < LowCount)
                    {
                        CustmerSus[CountSus, CountSmall] = CustomerAllData[Count, CountSmall];
                        CountSmall++;
                    }
                    CountSus++; }
                else {
                    CountSmall = 0;
                    while (CountSmall < LowCount)
                    {
                        CustmerC[CountC, CountSmall] = CustomerAllData[Count, CountSmall];
                    CountSmall++;
                }
                CountC++;
                Debug.Log("レアリティの仕分けに失敗しています。Cとして数えます。Column=" + Count);
                    CountUC++;
                }
            }
            Count++;
        }

        StatGame.GetComponent<StatGame>().CustmerC = CustmerC;
        StatGame.GetComponent<StatGame>().CustmerUC = CustmerUC;
        StatGame.GetComponent<StatGame>().CustmerR = CustmerR;
        StatGame.GetComponent<StatGame>().CustmerSus = CustmerSus;


    }



    //客生成
    //int Field 0=ゲーム中 1=図鑑
    public void MakeCustomer(int Id,string Name,string Image, int Hp, string CoreColor,string Color, int DropG,string[] DropItem,string[]DropMeat,int SaveSus,string Rarerity,int LvAppear,int LvDisAppear,int Field)
    {

        GameObject NowField=CustomerField;
        GameObject NowPrefab=CustomerPrefab;
        if (Field == 0) {
            NowField = CustomerField;
            NowPrefab = CustomerPrefab;
        }
        else {
            NowField = LibraryField;
            NowPrefab = CustomerLibraryPrefab;
        }



        GameObject Customer = (GameObject)Instantiate(
            NowPrefab,
            transform.position,
            Quaternion.identity);
        Customer.transform.SetParent(NowField.transform);

        //CustomerBaseを取得
GameObject CustomerBase= Customer.transform.Find("CustomerBase").gameObject;

        //位置・大きさ決定
        Customer.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        int PositionY = 400;
        int PositionX = Random.Range(-200, 200);
        Customer.transform.position = new Vector3(PositionX, PositionY, 0);
        float ForceY = -2;
        float ForceX = Random.Range(-2.5f, 2.5f);
        int ForcePower = Random.Range(0, 50000);

        if (Field == 0)
        {
            Customer.GetComponent<Rigidbody2D>().AddForce(new Vector2(ForceX, ForceY) * ForcePower);
        }

        //画像決定

        string ImagePath = "CustomerColor/" + Image;
        string ImagePathBase = "CustomerBase/" + Image;

        Sprite SpriteImage = Resources.Load<Sprite>(ImagePath);
        Sprite SpriteImageBase = Resources.Load<Sprite>(ImagePathBase);

        Customer.GetComponent<Image>().sprite = SpriteImage;
        CustomerBase.GetComponent<Image>().sprite = SpriteImageBase;


        //色決定
        Color CoreCol = GetComponent<ColorGetter>().ToColor(CoreColor);
        float CoreR = CoreCol.r;
        float CoreG = CoreCol.g;
        float CoreB = CoreCol.b;
        Color Col = GetComponent<ColorGetter>().ToColor(Color);

        //色のゆれ
        float PlusR = Random.Range(50f/255,-50f / 255);
        float PlusG = Random.Range(50f / 255, -50f / 255);
        float PlusB = Random.Range(50f / 255, -50f / 255);
                Color UseCol = new Color(CoreR+PlusR, CoreG + PlusG, CoreB + PlusB, 1f);


        string ColorString;        
        //カラーが入っていないならコアカラーの揺れた奴が色
        if (Color == "" | Color == null || Color == "None")
        {
            //ゲーム中は揺れた色、図鑑では揺れない色
            if (Field == 0) { 
            Customer.GetComponent<Image>().color = UseCol;
            Customer.GetComponent<UIEffect>().shadowColor = UseCol;
            ColorString = "#" + GetComponent<ColorGetter>().ToColorString(UseCol);
            }
            else
            {
                Customer.GetComponent<Image>().color = CoreCol;
                Customer.GetComponent<UIEffect>().shadowColor = CoreCol;
                ColorString = "#" + GetComponent<ColorGetter>().ToColorString(CoreCol);

            }
        }
        //そうでないならカラーに一意的に決定
        else
        {
            Customer.GetComponent<Image>().color = Col;
            Customer.GetComponent<UIEffect>().shadowColor = Col;
            ColorString = "#" + GetComponent<ColorGetter>().ToColorString(Col);
        }


        //レアなら光らせる
        if (Rarerity == "R")
        {
            Customer.GetComponent<StatCustomer>().Glow();
            StatGame.GetComponent<StatGame>().FlagGlowCustomer = 1;
         //   Debug.Log("GLOW!");
        }
        else {
        }
        //タグをつける
        Customer.tag = "Customer";
        //アイテム選択時用のボタンを不活性にする
        if (Field == 0)
        {
            Customer.GetComponent<Button>().interactable = false;
        }
        else
        {
            Customer.GetComponent<Button>().interactable = true;
        }

        //客の情報をカスタマーＳＴＡＴに書き込み
        Customer.GetComponent<StatCustomer>().Id = Id;
        Customer.GetComponent<StatCustomer>().Name = Name;
        Customer.GetComponent<StatCustomer>().Image = Image;
        Customer.GetComponent<StatCustomer>().Hp = Hp;
        Customer.GetComponent<StatCustomer>().CoreColor = CoreColor;
        Customer.GetComponent<StatCustomer>().Color = ColorString;
        Customer.GetComponent<StatCustomer>().DropG = DropG;
        Customer.GetComponent<StatCustomer>().DropItem = DropItem;
        Customer.GetComponent<StatCustomer>().DropMeat = DropMeat;
        Customer.GetComponent<StatCustomer>().SaveSus = SaveSus;
        Customer.GetComponent<StatCustomer>().Rarerity = Rarerity;
        Customer.GetComponent<StatCustomer>().LvAppear = LvAppear;
        Customer.GetComponent<StatCustomer>().LvDisAppear = LvDisAppear;

    }


}
