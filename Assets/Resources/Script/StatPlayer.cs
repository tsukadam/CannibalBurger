using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Coffee.UIExtensions;

//プレイヤーのステータスを保持する
//プレイ外データ、ハイスコアなど
//オートセーブではこの中のデータが保持される
public class StatPlayer : MonoBehaviour {
    //StasGame
    public GameObject StatGame;

    public GameObject Script;
    
    //全体での遊んだ数
    public int TotalCountPlay = 0;//遊んだ回数　初回はチュートリアル出す　初回は数周で切る？

    //各画面
    public GameObject Menu;
    public GameObject Game;
    public GameObject HighScore;
    public GameObject Library;
    public GameObject Setting;

    //ハイスコア光らせ用
    public GameObject Score1;
    public GameObject Score2;
    public GameObject Score3;
    public GameObject Score4;
    public GameObject Score5;
    //今何位にランクインしたか
    public int RankInNumber = 0;

    //スコア情報
    public GameObject ScoreButton1;
    public GameObject ScoreButton2;
    public GameObject ScoreButton3;
    public GameObject ScoreButton4;
    public GameObject ScoreButton5;
    public GameObject ScoreInfo;
    public GameObject ScoreEndCard;
    public Text InfoRank;
    public Text InfoG;
    public Text InfoLv;
    public Text InfoDays;
    public Text InfoPlayCount;
    public Text InfoResult;
    public Text InfoGetG;
    public Text InfoCustomerNumber;
    public Text InfoVictory;
    public Text InfoKill;


    //図鑑画面
    public GameObject LibraryField;

    public GameObject InfoWindow;
    public Text LibName;
    public Text LibText;
    public Text LibDropName;
    public Text LibDropPower;
    public Text LibDropSus;
    public Text LibMeatName;
    public Text LibMeatPower;
    public Text LibMeatSus;
    public GameObject LibDropImage;
    public GameObject LibMeatImage;
    public GameObject LibImage;
    public GameObject LibImageBase;

    public Text LibDropG;
    public Text LibHp;
    public Text LibSaveSus;
    public Text LibPopLv;
    public Text LibDisLv;
    public Text LibRare;

    public GameObject HatenaPrefab;
    public Text LibCompleteNumber;


    public Text TextMaxG1;
    public Text TextMaxLv1;
    public Text TextMaxDays1;
    public Text TextMaxG2;
    public Text TextMaxLv2;
    public Text TextMaxDays2;
    public Text TextMaxG3;
    public Text TextMaxLv3;
    public Text TextMaxDays3;
    public Text TextMaxG4;
    public Text TextMaxLv4;
    public Text TextMaxDays4;
    public Text TextMaxG5;
    public Text TextMaxLv5;
    public Text TextMaxDays5;


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
    public int LowText;

    //チュートリアルやストーリーのフラグ
    public int FlagStoryOP = 0;
    public int FlagTutorialFirstFeed = 0;
    public int FlagTutorialSecondFeed = 0;
    public int FlagTutorialThirdFeed = 0;
    public int FlagTutorialFirstSelect = 0;
    public int FlagTutorialFirstRare = 0;
    public int FlagTutorialFirstSaveSus = 0;
    public int FlagTutorialFirstDispose = 0;
    public int FlagTutorialFirstHolyday = 0;
    public int FlagTutorialFirstLvup = 0;

    //保存用の箱
    public string FSOPKey = " FSOPKey";
    public string FT1FeedKey = "FT1FeedKey";
    public string FT2FeedKey = "FT2FeedKey";
    public string FT3FeedKey = "FT3FeedKey";
    public string FT1SelectKey = "FT1SelectKey";
    public string FT1RareKey = "FT1RareKey";
    public string FT1SaveSusKey = "FT1SaveSusKey";
    public string FT1DisposeKey = "FT1DisposeKey";
    public string FT1HolydayKey = "FT1HolydayKey";
    public string FT1LvupKey = "FT1LvupKey";

    //倒した客の記録、図鑑用
    //前回の記録は起動時に読み込んでいる
    //ゲーム開始時と図鑑表示時に、Allの客データの数から箱を生成し、
    //それに前回の記録を写す。ゲーム中はそれに書き込んでいき、リアルタイムでセーブする
    //0=未、1=倒した
    //0個目の要素＝id0の客　実際にはid4からしかデータ入ってないので、表示に使う時0～4までは無視する　総数も5引いて考える
    //0～4がカラなので5多い数になる
    public int[] CustomerList;
    public int[] LoadedCustomerList;
    public string CustomerListKey = "CustomerListKey";


    //セーブ中断しているかのフラグ
    //0=なし　1=あり Start内で代入
    //アリの場合開始時の初期設定に影響を及ぼす
    public int ExistSave=0;
    public string ExistSaveKey = "ExistSave";

    //一時保存用の箱
    public string SaveLvKey = " SaveLvKey";
    public string SaveDaysKey = "SaveDaysKey";
    public string SaveSusKey = "SaveSusKey";
    public string SaveExpKey = "SaveExpKey";
    public string SaveKillKey = "SaveKillKey";
    public string SaveCustomerKey = "SaveCustomerKey";
    public string SaveCustomerVictoryKey = "SaveCustomerVicvoryKey";
    public string SaveGKey = "SaveGKey";
    public string SaveGetGKey = "SaveGetGKey";
    //所持アイテム情報

    public string Item1NameKey = "Item1NameKey";
    public string Item1ImageKey = "Item1imageKey";
    public string Item1ColorKey = "Item1ColorKey";
    public string Item1PowerKey = "Item1PowerKey";
    public string Item1SusKey = "Item1SusKey";

    public string Item2NameKey = "Item2NameKey";
    public string Item2ImageKey = "Item2imageKey";
    public string Item2ColorKey = "Item2ColorKey";
    public string Item2PowerKey = "Item2PowerKey";
    public string Item2SusKey = "Item2SusKey";

    public string Item3NameKey = "Item3NameKey";
    public string Item3ImageKey = "Item3imageKey";
    public string Item3ColorKey = "Item3ColorKey";
    public string Item3PowerKey = "Item3PowerKey";
    public string Item3SusKey = "Item3SusKey";

    public string Item4NameKey = "Item4NameKey";
    public string Item4ImageKey = "Item4imageKey";
    public string Item4ColorKey = "Item4ColorKey";
    public string Item4PowerKey = "Item4PowerKey";
    public string Item4SusKey = "Item4SusKey";


    //一時保存用の生成した客idの箱
    public int[] CID = new int[20];
    public string[] CColor = new string[20];

    public string [] CIDKey = {
        "CID1Key" ,
        "CID2Key" ,
        "CID3Key" ,
        "CID4Key" ,
        "CID5Key" ,
        "CID6Key" ,
        "CID7Key" ,
        "CID8Key" ,
        "CID9Key" ,
        "CID10Key" ,
        "CID11Key" ,
        "CID12Key" ,
        "CID13Key" ,
        "CID14Key" ,
        "CID15Key" ,
        "CID16Key" ,
        "CID17Key" ,
        "CID18Key" ,
        "CID19Key" ,
        "CID20Key" ,
    };
    public string[] CColorKey = {
        "CColor1Key" ,
        "CColor2Key" ,
        "CColor3Key" ,
        "CColor4Key" ,
        "CColor5Key" ,
        "CColor6Key" ,
        "CColor7Key" ,
        "CColor8Key" ,
        "CColor9Key" ,
        "CColor10Key" ,
        "CColor11Key" ,
        "CColor12Key" ,
        "CColor13Key" ,
        "CColor14Key" ,
        "CColor15Key" ,
        "CColor16Key" ,
        "CColor17Key" ,
        "CColor18Key" ,
        "CColor19Key" ,
        "CColor20Key" ,
    };
    //今回のゲームでのスコア
    public int EndCard = 0;//エンドカード
    public int MaxLv=0;//到達レベル
    public int MaxDays=0;//到達日付
    public int MaxKill=0;//殺人数
    public int MaxCustomer=0;//さばいた客の数
    public int MaxCustomerVictory=0;//うち魅了した客の数
    public int MaxG=0;//最終的な持ち金＝スコア
    public int MaxGetG=0;//かせいだ売上の総和　持ち金を引けば利益率が出る

    //過去のスコア
    public int EndCard1 = 0;//エンドカード
    public int MaxLv1;//到達レベル
    public int MaxDays1;//到達日付
    public int MaxKill1;//殺人数
    public int MaxCustomer1;//さばいた客の数
    public int MaxCustomerVictory1;//うち魅了した客の数
    public int MaxG1;//最終的な持ち金＝スコア
    public int MaxGetG1;//かせいだ売上の総和　持ち金を引けば利益率が出る
    public int CountPlay1;//遊んだ回数　初回はチュートリアル出す　初回は数周で切る？

    public int EndCard2 = 0;//エンドカード
    public int MaxLv2;//到達レベル
    public int MaxDays2;//到達日付
    public int MaxKill2;//殺人数
    public int MaxCustomer2;//さばいた客の数
    public int MaxCustomerVictory2;//うち魅了した客の数
    public int MaxG2;//最終的な持ち金＝スコア
    public int MaxGetG2;//かせいだ売上の総和　持ち金を引けば利益率が出る
    public int CountPlay2;//遊んだ回数　初回はチュートリアル出す　初回は数周で切る？

    public int EndCard3 = 0;//エンドカード
    public int MaxLv3;//到達レベル
    public int MaxDays3;//到達日付
    public int MaxKill3;//殺人数
    public int MaxCustomer3;//さばいた客の数
    public int MaxCustomerVictory3;//うち魅了した客の数
    public int MaxG3;//最終的な持ち金＝スコア
    public int MaxGetG3;//かせいだ売上の総和　持ち金を引けば利益率が出る
    public int CountPlay3;//遊んだ回数　初回はチュートリアル出す　初回は数周で切る？

    public int EndCard4 = 0;//エンドカード
    public int MaxLv4;//到達レベル
    public int MaxDays4;//到達日付
    public int MaxKill4;//殺人数
    public int MaxCustomer4;//さばいた客の数
    public int MaxCustomerVictory4;//うち魅了した客の数
    public int MaxG4;//最終的な持ち金＝スコア
    public int MaxGetG4;//かせいだ売上の総和　持ち金を引けば利益率が出る
    public int CountPlay4;//遊んだ回数　初回はチュートリアル出す　初回は数周で切る？

    public int EndCard5 = 0;//エンドカード
    public int MaxLv5;//到達レベル
    public int MaxDays5;//到達日付
    public int MaxKill5;//殺人数
    public int MaxCustomer5;//さばいた客の数
    public int MaxCustomerVictory5;//うち魅了した客の数
    public int MaxG5;//最終的な持ち金＝スコア
    public int MaxGetG5;//かせいだ売上の総和　持ち金を引けば利益率が出る
    public int CountPlay5;//遊んだ回数　初回はチュートリアル出す　初回は数周で切る？

    public string TotalCountPlayKey = "TotalCountPlay";

    public string EndCard1Key = "EndCard1";
    public string EndCard2Key = "EndCard2";
    public string EndCard3Key = "EndCard3";
    public string EndCard4Key = "EndCard4";
    public string EndCard5Key = "EndCard5";

    public string MaxLv1Key = "MaxLv1";
    public string MaxDays1Key = "MaxDays1";
    public string MaxKill1Key = "MaxKill1";
    public string MaxCustomer1Key = "MaxCustomer1";
    public string MaxCustomerVictory1Key = "MaxCustomerVictory1";
    public string MaxG1Key = "MaxG1";
    public string MaxGetG1Key = "MaxgetG1";
    public string CountPlay1Key = "CountPlay1";

    public string MaxLv2Key = "MaxLv2";
    public string MaxDays2Key = "MaxDays2";
    public string MaxKill2Key = "MaxKill2";
    public string MaxCustomer2Key = "MaxCustomer2";
    public string MaxCustomerVictory2Key = "MaxCustomerVictory2";
    public string MaxG2Key = "MaxG2";
    public string MaxGetG2Key = "MaxgetG2";
    public string CountPlay2Key = "CountPlay2";

    public string MaxLv3Key = "MaxLv3";
    public string MaxDays3Key = "MaxDays3";
    public string MaxKill3Key = "MaxKill3";
    public string MaxCustomer3Key = "MaxCustomer3";
    public string MaxCustomerVictory3Key = "MaxCustomerVictory3";
    public string MaxG3Key = "MaxG3";
    public string MaxGetG3Key = "MaxgetG3";
    public string CountPlay3Key = "CountPlay3";

    public string MaxLv4Key = "MaxLv4";
    public string MaxDays4Key = "MaxDays4";
    public string MaxKill4Key = "MaxKill4";
    public string MaxCustomer4Key = "MaxCustomer4";
    public string MaxCustomerVictory4Key = "MaxCustomerVictory4";
    public string MaxG4Key = "MaxG4";
    public string MaxGetG4Key = "MaxgetG4";
    public string CountPlay4Key = "CountPlay4";

    public string MaxLv5Key = "MaxLv5";
    public string MaxDays5Key = "MaxDays5";
    public string MaxKill5Key = "MaxKill5";
    public string MaxCustomer5Key = "MaxCustomer5";
    public string MaxCustomerVictory5Key = "MaxCustomerVictory5";
    public string MaxG5Key = "MaxG5";
    public string MaxGetG5Key = "MaxgetG5";
    public string CountPlay5Key = "CountPlay5";

    //休日アクション値のセーブ
    public string ModifyGKey = " ModifyGKey";
    public string ModifySusKey = " ModifySusKey";

    public string PoliceCost1Key = " PoliceCost1Key";
    public string PoliceReturn1Key = " PoliceReturn1Key";
    public string PoliceCost2Key = " PoliceCost2Key";
    public string PoliceReturn2Key = " PoliceReturn2Key";

    public string ChurchReturn1Key = " ChurchReturn1Key";
    public string ChurchReturn2Key = " ChurchReturn2Key";

    public string HomeReturn1Key = " HomeReturn1Key";
    public string HomeReturn2Key = " HomeReturn2Key";

    public string MarketItem1NameKey = " MarketItem1NameKey";
    public string MarketItem1PicturePathKey = " MarketItem1PicturePathKey";
    public string MarketItem1PowerKey = " MarketItem1PowerKey";
    public string MarketItem1ColorKey = " MarketItem1ColorKey";
    public string MarketItem1SusKey = " MarketItem1SusKey";
    public string MarketItem1CostKey = " MarketItem1CostKey";

    public string MarketItem2NameKey = " MarketItem2NameKey";
    public string MarketItem2PicturePathKey = " MarketItem2PicturePathKey";
    public string MarketItem2PowerKey = " MarketItem2PowerKey";
    public string MarketItem2ColorKey = " MarketItem2ColorKey";
    public string MarketItem2SusKey = " MarketItem2SusKey";
    public string MarketItem2CostKey = " MarketItem2CostKey";

    class CustomerListClass
    {
        public int[] List;
    }

    public static class PlayerPrefsUtils
    {
        /// <summary>
        /// 指定されたオブジェクトの情報を保存します
        /// </summary>
        public static void SetObject<T>(string key, T obj)
        {
            var json = JsonUtility.ToJson(obj);
            PlayerPrefs.SetString(key, json);
        }

        /// <summary>
        /// 指定されたオブジェクトの情報を読み込みます
        /// </summary>
        public static T GetObject<T>(string key)
        {
            var json = PlayerPrefs.GetString(key);
            var obj = JsonUtility.FromJson<T>(json);
            return obj;
        }
    }

    //図鑑用客リストの生成
    public void MakeCustomerList()
    {
        string[,] CustomerAllData = StatGame.GetComponent<StatGame>().CustomerAllData;
        int AllCustomerLength = CustomerAllData.GetLength(0);
        //0～4がカラなので5足さないといけないが、一行目は項目名なので、差し引き4足さないといけない
        CustomerList = new int[AllCustomerLength+4];
        //全てに0を代入、このあと前回データを上書きする
        for (int i = 0; i < CustomerList.Length; i++)
        {
            CustomerList[i]=0;
        }

    }
    //前回データのコピー
    //リスト生成の後に、前回データのロードが済んだタイミングで実行
    public void LoadCustomerList()
    {
        string[,] CustomerAllData = StatGame.GetComponent<StatGame>().CustomerAllData;
        int AllCustomerLength = CustomerAllData.GetLength(0);
        int LoadedDataLength = LoadedCustomerList.GetLength(0);


      //  Debug.Log(LoadedDataLength);
      //  Debug.Log(AllCustomerLength);

        if (LoadedCustomerList != null)
        {
            //データがロードデータより減ってる時は、
            //そのぶん書き込み回数を減らす。減った分のデータは消える。
            if (LoadedDataLength > AllCustomerLength+4)
            {
                LoadedDataLength = AllCustomerLength-4;
            }

          //  Debug.Log(LoadedDataLength);
            for (int i = 0; i < LoadedDataLength; i++)
            {
         //       Debug.Log(i);
                //Loadedの数までしか書き込まない。書き込まなかったところは0になる
                //1が入っているところだけ書き込む
                if (LoadedCustomerList[i] == 1)
                {
                    CustomerList[i] = LoadedCustomerList[i];
                }
            }
        }
    }



    //チュートリアルとストーリーの履歴フラグ
    //表示したときすぐ保存
    //別途、フラグを1に変える
    public void SaveFlag()
    {
        PlayerPrefs.SetInt(FSOPKey, FlagStoryOP);
        PlayerPrefs.SetInt(FT1FeedKey, FlagTutorialFirstFeed);
        PlayerPrefs.SetInt(FT2FeedKey, FlagTutorialSecondFeed);
        PlayerPrefs.SetInt(FT3FeedKey, FlagTutorialThirdFeed);
        PlayerPrefs.SetInt(FT1SelectKey, FlagTutorialFirstSelect);
        PlayerPrefs.SetInt(FT1RareKey, FlagTutorialFirstRare);
        PlayerPrefs.SetInt(FT1SaveSusKey, FlagTutorialFirstSaveSus);
        PlayerPrefs.SetInt(FT1DisposeKey, FlagTutorialFirstDispose);
        PlayerPrefs.SetInt(FT1HolydayKey, FlagTutorialFirstHolyday);
        PlayerPrefs.SetInt(FT1LvupKey, FlagTutorialFirstLvup);




}
    //チュートリアルのみリセット
    public void ResetTutorial()
    {
        FlagTutorialFirstFeed = 0;
        FlagTutorialSecondFeed = 0;
        FlagTutorialThirdFeed = 0;
        FlagTutorialFirstSelect = 0;
        FlagTutorialFirstRare = 0;
        FlagTutorialFirstSaveSus = 0;
        FlagTutorialFirstDispose = 0;
        FlagTutorialFirstHolyday = 0;
        FlagTutorialFirstLvup = 0;
        SaveFlag();
        SaveDelete();
    }
    //ストーリーのみリセット
    public void ResetOpening()
    {
        FlagStoryOP = 0;
        SaveFlag();
        SaveDelete();
    }

    //デバッグ用　チュートリアルとストーリーフラグ、図鑑フラグ、セーブをすべて０に
    public void ResetFlag()
    {
        FlagStoryOP = 0;
  FlagTutorialFirstFeed = 0;
FlagTutorialSecondFeed = 0;
        FlagTutorialThirdFeed = 0;
        FlagTutorialFirstSelect = 0;
    FlagTutorialFirstRare = 0;
    FlagTutorialFirstSaveSus = 0;
 FlagTutorialFirstDispose = 0;
     FlagTutorialFirstHolyday = 0;
   FlagTutorialFirstLvup = 0;

        MakeCustomerList();
        LoadedCustomerList = CustomerList;
        WriteCustomerList();

        SaveFlag();
        SaveDelete();

    }


    //セーブ中断のセーブ処理部分
    public void Save()
    {
            //Ｇ，カルマ取得修正率
    int ModifyG = StatGame.GetComponent<StatGame>().ModifyG;
    int ModifySus = StatGame.GetComponent<StatGame>().ModifySus;

    //休日行動のステ
    int PoliceCost1 = StatGame.GetComponent<StatGame>().PoliceCost1;
    int PoliceReturn1 = StatGame.GetComponent<StatGame>().PoliceReturn1;
    int PoliceCost2 = StatGame.GetComponent<StatGame>().PoliceCost2;
    int PoliceReturn2 = StatGame.GetComponent<StatGame>().PoliceReturn2;

    int ChurchReturn1 = StatGame.GetComponent<StatGame>().ChurchReturn1;
    int ChurchReturn2 = StatGame.GetComponent<StatGame>().ChurchReturn2;

    int HomeReturn1 = StatGame.GetComponent<StatGame>().HomeReturn1;
    int HomeReturn2 = StatGame.GetComponent<StatGame>().HomeReturn2;

        string MarketItem1Name = StatGame.GetComponent<StatGame>().MarketItem1[0];
        string MarketItem1PicturePath = StatGame.GetComponent<StatGame>().MarketItem1[1];
        string MarketItem1Power = StatGame.GetComponent<StatGame>().MarketItem1[2];
        string MarketItem1Color = StatGame.GetComponent<StatGame>().MarketItem1[3];
        string MarketItem1Sus = StatGame.GetComponent<StatGame>().MarketItem1[4];


        string MarketItem2Name = StatGame.GetComponent<StatGame>().MarketItem2[0];
        string MarketItem2PicturePath = StatGame.GetComponent<StatGame>().MarketItem2[1];
        string MarketItem2Power = StatGame.GetComponent<StatGame>().MarketItem2[2];
        string MarketItem2Color = StatGame.GetComponent<StatGame>().MarketItem2[3];
        string MarketItem2Sus = StatGame.GetComponent<StatGame>().MarketItem2[4];

        int MarketCost1 = StatGame.GetComponent<StatGame>().MarketCost1;
    int MarketCost2 = StatGame.GetComponent<StatGame>().MarketCost2;



    int NowLv = StatGame.GetComponent<StatGame>().StatLv;
        int NowDays = StatGame.GetComponent<StatGame>().StatDays;
        float NowSus = StatGame.GetComponent<StatGame>().StatSus;
        int NowExp = StatGame.GetComponent<StatGame>().StatExp;
        int NowG = StatGame.GetComponent<StatGame>().StatG;

        string Item1Name =StatGame.GetComponent<StatGame>().Item1[0];
        string Item1Image = StatGame.GetComponent<StatGame>().Item1[1];
        string Item1Power = StatGame.GetComponent<StatGame>().Item1[2];
        string Item1Color = StatGame.GetComponent<StatGame>().Item1[3];
        string Item1Sus = StatGame.GetComponent<StatGame>().Item1[4];

        string Item2Name = StatGame.GetComponent<StatGame>().Item2[0];
        string Item2Image = StatGame.GetComponent<StatGame>().Item2[1];
        string Item2Power = StatGame.GetComponent<StatGame>().Item2[2];
        string Item2Color = StatGame.GetComponent<StatGame>().Item2[3];
        string Item2Sus = StatGame.GetComponent<StatGame>().Item2[4];

        string Item3Name = StatGame.GetComponent<StatGame>().Item3[0];
        string Item3Image = StatGame.GetComponent<StatGame>().Item3[1];
        string Item3Power = StatGame.GetComponent<StatGame>().Item3[2];
        string Item3Color = StatGame.GetComponent<StatGame>().Item3[3];
        string Item3Sus = StatGame.GetComponent<StatGame>().Item3[4];

        string Item4Name = StatGame.GetComponent<StatGame>().Item4[0];
        string Item4Image = StatGame.GetComponent<StatGame>().Item4[1];
        string Item4Power = StatGame.GetComponent<StatGame>().Item4[2];
        string Item4Color = StatGame.GetComponent<StatGame>().Item4[3];
        string Item4Sus = StatGame.GetComponent<StatGame>().Item4[4];


        int Count = 0;
        int CustomerLength = 0;
        if (GameObject.FindGameObjectsWithTag("Customer") != null)
        {
            GameObject[] NormalCustomer = GameObject.FindGameObjectsWithTag("Customer");
            CustomerLength = NormalCustomer.Length;
            if (CustomerLength > 20) { Debug.Log("20人いてセーブできません"); }
            while(Count< 20)
            {
                if (Count < CustomerLength)
                {
                    CID[Count] = NormalCustomer[Count].GetComponent<StatCustomer>().Id;
                    CColor[Count] = NormalCustomer[Count].GetComponent<StatCustomer>().Color;
                }
                else
                {
                    CID[Count] = 0;
                    CColor[Count] = "";
                }
                PlayerPrefs.SetInt(CIDKey[Count], CID[Count]);
                PlayerPrefs.SetString(CColorKey[Count], CColor[Count]);

                Count++;

            }

        }



        //書き込み
        WriteHighScore();
        //遊んだ回数の記録などのためにスコア情報も書き込む
        ExistSave = 1;
        PlayerPrefs.SetInt(ExistSaveKey, ExistSave);//セーブ存在フラグ

        PlayerPrefs.SetInt(SaveLvKey, NowLv);
        PlayerPrefs.SetInt(SaveDaysKey, NowDays);
        PlayerPrefs.SetFloat(SaveSusKey, NowSus);
        PlayerPrefs.SetInt(SaveExpKey, NowExp);
        PlayerPrefs.SetInt(SaveKillKey, MaxKill);
        PlayerPrefs.SetInt(SaveCustomerKey, MaxCustomer);
        PlayerPrefs.SetInt(SaveCustomerVictoryKey, MaxCustomerVictory);
        PlayerPrefs.SetInt(SaveGKey, NowG);
        PlayerPrefs.SetInt(SaveGetGKey, MaxGetG);

        PlayerPrefs.SetString(Item1NameKey, Item1Name);
        PlayerPrefs.SetString(Item1ImageKey, Item1Image);
        PlayerPrefs.SetString(Item1PowerKey, Item1Power);
        PlayerPrefs.SetString(Item1ColorKey, Item1Color);
        PlayerPrefs.SetString(Item1SusKey, Item1Sus);

        PlayerPrefs.SetString(Item2NameKey, Item2Name);
        PlayerPrefs.SetString(Item2ImageKey, Item2Image);
        PlayerPrefs.SetString(Item2PowerKey, Item2Power);
        PlayerPrefs.SetString(Item2ColorKey, Item2Color);
        PlayerPrefs.SetString(Item2SusKey, Item2Sus);

        PlayerPrefs.SetString(Item3NameKey, Item3Name);
        PlayerPrefs.SetString(Item3ImageKey, Item3Image);
        PlayerPrefs.SetString(Item3PowerKey, Item3Power);
        PlayerPrefs.SetString(Item3ColorKey, Item3Color);
        PlayerPrefs.SetString(Item3SusKey, Item3Sus);

        PlayerPrefs.SetString(Item4NameKey, Item4Name);
        PlayerPrefs.SetString(Item4ImageKey, Item4Image);
        PlayerPrefs.SetString(Item4PowerKey, Item4Power);
        PlayerPrefs.SetString(Item4ColorKey, Item4Color);
        PlayerPrefs.SetString(Item4SusKey, Item4Sus);

        PlayerPrefs.SetInt(ModifyGKey, ModifyG);
        PlayerPrefs.SetInt(ModifySusKey, ModifySus);

        PlayerPrefs.SetInt(PoliceCost1Key, PoliceCost1);
        PlayerPrefs.SetInt(PoliceReturn1Key, PoliceReturn1);
        PlayerPrefs.SetInt(PoliceCost2Key, PoliceCost2);
        PlayerPrefs.SetInt(PoliceReturn2Key, PoliceReturn2);

        PlayerPrefs.SetInt(ChurchReturn1Key, ChurchReturn1);
        PlayerPrefs.SetInt(ChurchReturn2Key, ChurchReturn2);

        PlayerPrefs.SetInt(HomeReturn1Key, HomeReturn1);
        PlayerPrefs.SetInt(HomeReturn2Key, HomeReturn2);

        PlayerPrefs.SetInt(MarketItem1CostKey, MarketCost1);
        PlayerPrefs.SetInt(MarketItem2CostKey, MarketCost2);

        PlayerPrefs.SetString(MarketItem1NameKey, MarketItem1Name);
        PlayerPrefs.SetString(MarketItem1PicturePathKey, MarketItem1PicturePath);
        PlayerPrefs.SetString(MarketItem1PowerKey, MarketItem1Power);
        PlayerPrefs.SetString(MarketItem1ColorKey, MarketItem1Color);
        PlayerPrefs.SetString(MarketItem1SusKey, MarketItem1Sus);

        PlayerPrefs.SetString(MarketItem2NameKey, MarketItem2Name);
        PlayerPrefs.SetString(MarketItem2PicturePathKey, MarketItem2PicturePath);
        PlayerPrefs.SetString(MarketItem2PowerKey, MarketItem2Power);
        PlayerPrefs.SetString(MarketItem2ColorKey, MarketItem2Color);
        PlayerPrefs.SetString(MarketItem2SusKey, MarketItem2Sus);



}
//セーブ情報のロード
//ゲーム開始時に一回だけ呼ばれる
public void Load()
    {
        if (ExistSave == 1)
        {
            StatGame.GetComponent<StatGame>().StatLv = PlayerPrefs.GetInt(SaveLvKey, 0);
            StatGame.GetComponent<StatGame>().StatDays = PlayerPrefs.GetInt(SaveDaysKey, 0);
            StatGame.GetComponent<StatGame>().StatSus = PlayerPrefs.GetFloat(SaveSusKey, 0);
            StatGame.GetComponent<StatGame>().StatExp = PlayerPrefs.GetInt(SaveExpKey, 0);
            StatGame.GetComponent<StatGame>().StatG = PlayerPrefs.GetInt(SaveGKey, 0);

    string[] SaveItem1 = { "None", "None", "None", "None", "None" };//
    string[] SaveItem2 = { "None", "None", "None", "None", "None" };//
    string[] SaveItem3 = { "None", "None", "None", "None", "None" };//
    string[] SaveItem4 = { "None", "None", "None", "None", "None" };//

            int Count = 0;
            while (Count < 20)
            {
                CID[Count] = PlayerPrefs.GetInt(CIDKey[Count]);
                CColor[Count] = PlayerPrefs.GetString(CColorKey[Count]);

                Count++;
            }


            SaveItem1[0]=PlayerPrefs.GetString(Item1NameKey);
            SaveItem1[1] = PlayerPrefs.GetString(Item1ImageKey);
            SaveItem1[2] = PlayerPrefs.GetString(Item1PowerKey);
            SaveItem1[3] = PlayerPrefs.GetString(Item1ColorKey);
            SaveItem1[4] = PlayerPrefs.GetString(Item1SusKey);
            SaveItem2[0] = PlayerPrefs.GetString(Item2NameKey);
            SaveItem2[1] = PlayerPrefs.GetString(Item2ImageKey);
            SaveItem2[2] = PlayerPrefs.GetString(Item2PowerKey);
            SaveItem2[3] = PlayerPrefs.GetString(Item2ColorKey);
            SaveItem2[4] = PlayerPrefs.GetString(Item2SusKey);
            SaveItem3[0] = PlayerPrefs.GetString(Item3NameKey);
            SaveItem3[1] = PlayerPrefs.GetString(Item3ImageKey);
            SaveItem3[2] = PlayerPrefs.GetString(Item3PowerKey);
            SaveItem3[3] = PlayerPrefs.GetString(Item3ColorKey);
            SaveItem3[4] = PlayerPrefs.GetString(Item3SusKey);
            SaveItem4[0] = PlayerPrefs.GetString(Item4NameKey);
            SaveItem4[1] = PlayerPrefs.GetString(Item4ImageKey);
            SaveItem4[2] = PlayerPrefs.GetString(Item4PowerKey);
            SaveItem4[3] = PlayerPrefs.GetString(Item4ColorKey);
            SaveItem4[4] = PlayerPrefs.GetString(Item4SusKey);

            StatGame.GetComponent<StatGame>().Item1 = SaveItem1;
            StatGame.GetComponent<StatGame>().Item2 = SaveItem2;
            StatGame.GetComponent<StatGame>().Item3 = SaveItem3;
            StatGame.GetComponent<StatGame>().Item4 = SaveItem4;

            MaxKill = PlayerPrefs.GetInt(SaveKillKey, 0);
            MaxCustomer = PlayerPrefs.GetInt(SaveCustomerKey, 0);
            MaxCustomerVictory = PlayerPrefs.GetInt(SaveCustomerVictoryKey, 0);
            MaxKill = PlayerPrefs.GetInt(SaveKillKey, 0);

            StatGame.GetComponent<StatGame>().ModifyG= PlayerPrefs.GetInt(ModifyGKey, 0);
            StatGame.GetComponent<StatGame>().ModifySus = PlayerPrefs.GetInt(ModifySusKey, 0);

            StatGame.GetComponent<StatGame>().PoliceCost1 = PlayerPrefs.GetInt(PoliceCost1Key, 0);
            StatGame.GetComponent<StatGame>().PoliceReturn1 = PlayerPrefs.GetInt(PoliceReturn1Key, 0);
            StatGame.GetComponent<StatGame>().PoliceCost2 = PlayerPrefs.GetInt(PoliceCost2Key, 0);
            StatGame.GetComponent<StatGame>().PoliceReturn2 = PlayerPrefs.GetInt(PoliceReturn2Key, 0);

            StatGame.GetComponent<StatGame>().ChurchReturn1 = PlayerPrefs.GetInt(ChurchReturn1Key, 0);
            StatGame.GetComponent<StatGame>().ChurchReturn2 = PlayerPrefs.GetInt(ChurchReturn2Key, 0);

            StatGame.GetComponent<StatGame>().HomeReturn1 = PlayerPrefs.GetInt(HomeReturn1Key, 0);
            StatGame.GetComponent<StatGame>().HomeReturn2 = PlayerPrefs.GetInt(HomeReturn2Key, 0);

            StatGame.GetComponent<StatGame>().MarketCost1 = PlayerPrefs.GetInt(MarketItem1CostKey, 0);
            StatGame.GetComponent<StatGame>().MarketCost2 = PlayerPrefs.GetInt(MarketItem2CostKey, 0);

            string[] MarketItem1 = { "None", "None", "None", "None", "None" };//
            string[] MarketItem2 = { "None", "None", "None", "None", "None" };//

            MarketItem1[0] = PlayerPrefs.GetString(MarketItem1NameKey);
            MarketItem1[1] = PlayerPrefs.GetString(MarketItem1PicturePathKey);
            MarketItem1[2] = PlayerPrefs.GetString(MarketItem1PowerKey);
            MarketItem1[3] = PlayerPrefs.GetString(MarketItem1ColorKey);
            MarketItem1[4] = PlayerPrefs.GetString(MarketItem1SusKey);

            MarketItem2[0] = PlayerPrefs.GetString(MarketItem2NameKey);
            MarketItem2[1] = PlayerPrefs.GetString(MarketItem2PicturePathKey);
            MarketItem2[2] = PlayerPrefs.GetString(MarketItem2PowerKey);
            MarketItem2[3] = PlayerPrefs.GetString(MarketItem2ColorKey);
            MarketItem2[4] = PlayerPrefs.GetString(MarketItem2SusKey);

            StatGame.GetComponent<StatGame>().MarketItem1 = MarketItem1;
            StatGame.GetComponent<StatGame>().MarketItem2 = MarketItem2;

            //ロードしたら情報は破棄する？
            //いまのところ残しておく、セーブ存在フラグは降ろした状態で書き込んでおくので不正出来ないはず
            SaveDelete();
        }
        else { Debug.Log("ExistSaveが1でないのに叩かれています。Loadはしません"); }
    }
    //セーブ存在フラグを下ろして記録する
    public void SaveDelete()
    {
        ExistSave = 0;
        PlayerPrefs.SetInt(ExistSaveKey, ExistSave);//セーブ存在フラグ

    }
    //図鑑全開放（デバッグ用）
    public void LibraryAllOpen()
    {
        string[,] CustomerAllData = StatGame.GetComponent<StatGame>().CustomerAllData;
        int AllCustomerLength = CustomerAllData.GetLength(0);
        int Count = 1;
        int LowId = Script.GetComponent<LvDesignController>().LowId;
        int NowId = 0;
        int LoadedDataLength = LoadedCustomerList.GetLength(0);
        string NowIdString = "";

        while (Count < AllCustomerLength)
        {
            NowIdString = CustomerAllData[Count, LowId];
            NowId = int.Parse(NowIdString);
            CustomerList[NowId] = 1;

            Count++;
        }
        WriteCustomerList();

    }

    //図鑑画面の描画
    public void GoLibrary()
    {
        LoadCustomerList();
        Script.GetComponent<CustomerController>().GetCustomerData(1);


        string[,] CustomerAllData = StatGame.GetComponent<StatGame>().CustomerAllData;
        int AllCustomerLength = CustomerAllData.GetLength(0);
        int Count = 1;
        int LowId = Script.GetComponent<LvDesignController>().LowId;
        int NowId = 0;
        string NowIdString = "";
      
       
       // Debug.Log(AllCustomerLength);
        while (Count < AllCustomerLength)
        {
            NowIdString = CustomerAllData[Count, LowId];
           NowId = int.Parse(NowIdString);

            //Debug.Log(Count + ":" + NowId);

            if (CustomerList[NowId] == 1)
            {
                Script.GetComponent<LvDesignController>().MakeCustomerId(NowId, "", 1);
            }
            else
            {

                GameObject Question = (GameObject)Instantiate(
                    HatenaPrefab,
                    transform.position,
                    Quaternion.identity);
                Question.transform.SetParent(LibraryField.transform);
                //位置決定
                int PositionY = 0;
                int PositionX = 0;
                Question.transform.position = new Vector3(PositionX, PositionY, 0);
                Question.tag = "Customer";
            }

            Count++;
        }

        //コンプリート率の表示
        int NowNumberInt = 0;
        Count = 5;
        while (Count < CustomerList.Length)
        {
            if (CustomerList[Count] == 1)
            {
                NowNumberInt++;
            }
            Count++;
        }


        string AllNumber = (AllCustomerLength-1).ToString();
        string NowNumber = (NowNumberInt).ToString();

        LibCompleteNumber.text = NowNumber + "/"+AllNumber ;


        Menu.SetActive(false);
        HighScore.SetActive(false);
        Library.SetActive(true);
        Game.SetActive(false);
        InfoWindow.SetActive(false);


    }

    public void CloseScroreInfo()
    {
        ScoreInfo.SetActive(false);

    }


    public void CloseInfomation()
    {
        InfoWindow.SetActive(false);

    }
    public void Infomation(int Id)
    {
        string[,] CustomerAllData = StatGame.GetComponent<StatGame>().CustomerAllData;

        int AllCustomerLength = CustomerAllData.GetLength(0);
        int Count = 1;
        int LowId = Script.GetComponent<LvDesignController>().LowId;
        int NowColumn=1;
        while (Count < AllCustomerLength)
        {
            if (int.Parse(CustomerAllData[Count,LowId]) == Id)
            {
                NowColumn = Count;
            }
            Count++;
        }

        string Name = CustomerAllData[NowColumn, LowName];
        string Image = CustomerAllData[NowColumn, LowImage];
        string Hp = CustomerAllData[NowColumn, LowHp];
        string Color = CustomerAllData[NowColumn, LowCoreColor];
        string DropG = CustomerAllData[NowColumn, LowDropG];
        string DropItemName = CustomerAllData[NowColumn, LowDropName];
        string DropItemImage = CustomerAllData[NowColumn, LowDropImage];
        string DropItemPower = CustomerAllData[NowColumn, LowDropPower];
        string DropItemSus = CustomerAllData[NowColumn, LowDropSus];
        string MeatItemName = CustomerAllData[NowColumn, LowMeatName];
        string MeatItemImage = CustomerAllData[NowColumn, LowMeatImage];
        string MeatItemPower = CustomerAllData[NowColumn, LowMeatPower];
        string MeatItemSus = CustomerAllData[NowColumn, LowMeatSus];

        string SaveSus = CustomerAllData[NowColumn, LowSaveSus];
        string Rarerity = CustomerAllData[NowColumn, LowRare];
        string LvAppear = CustomerAllData[NowColumn, LowPopLv];
        string LvDisAppear = CustomerAllData[NowColumn, LowDisLv];
        string Text = CustomerAllData[NowColumn, LowText];

        //LibImage.GetComponent<Infomation>().GlowOff();

        //改行文字を改行に変換
        string[] SplitSerif = Text.Split("／"[0]);
        //Debug.Log(SplitSerif.Length);
        if (SplitSerif.Length == 1) { }
        else
        {
            int CountN = 0;
            Text = "";
            while (CountN < SplitSerif.Length)
            {
                if (CountN == 0)
                {
                    Text = SplitSerif[CountN];
                }
                else
                {
                    Text = Text + "\n" + SplitSerif[CountN];
                }
                CountN++;
            }

        }

        LibName.text=Name;
        LibText.text=Text;

        LibDropName.text=DropItemName;
        LibDropPower.text =DropItemPower;
        LibDropSus.text =DropItemSus;
        LibDropSus.color = Script.GetComponent<GameController>().SusGreen;


        LibMeatName.text =MeatItemName;
        LibMeatPower.text =MeatItemPower;
        LibMeatSus.text=MeatItemSus;
        LibMeatSus.color = Script.GetComponent<GameController>().SusGreen;

        string ImagePath = "CustomerColor/" + Image;
        string ImagePathBase = "CustomerBase/" + Image;

        Sprite SpriteImage = Resources.Load<Sprite>(ImagePath);
        Sprite SpriteImageBase = Resources.Load<Sprite>(ImagePathBase);

        LibImage.GetComponent<Image>().sprite = SpriteImage;
        LibImageBase.GetComponent<Image>().sprite = SpriteImageBase;

        Color CoreCol = Script.GetComponent<ColorGetter>().ToColor(Color);

        LibImage.GetComponent<Image>().color = CoreCol;
        LibImage.GetComponent<UIEffect>().shadowColor = CoreCol;

        string ItemImagePath = "Item/" + DropItemImage;
        Sprite SpriteItemImage = Resources.Load<Sprite>(ItemImagePath);
        string MeatImagePath = "Item/" + MeatItemImage;
        Sprite SpriteMeatImage = Resources.Load<Sprite>(MeatImagePath);

        LibDropImage.GetComponent<Image>().sprite = SpriteItemImage;
        LibMeatImage.GetComponent<Image>().sprite = SpriteMeatImage;

        LibDropImage.GetComponent<Image>().color = CoreCol;
        LibMeatImage.GetComponent<Image>().color = CoreCol;

        LibDropG.text =DropG;
        LibDropG.color = Script.GetComponent<GameController>().GYellow;

        LibHp.text =Hp;

        LibSaveSus.text =SaveSus;
        LibSaveSus.color = Script.GetComponent<GameController>().ExpBlue;

        LibPopLv.text =LvAppear;

        int DisAppearPlusOne = int.Parse(LvDisAppear);
        int DisAppearResult = DisAppearPlusOne - 1;
        LibDisLv.text=(string)DisAppearResult.ToString();


        if (Rarerity == "R")
        {
            LibRare.color = Script.GetComponent<GameController>().GYellow;
       //     LibImage.GetComponent<Infomation>().Glow();
        }

        else if (Rarerity == "UC")
        {
            LibRare.color = Script.GetComponent<GameController>().GSilver;
        }
        else if (Rarerity == "C")
        {
            LibRare.color = Script.GetComponent<GameController>().GCopper;
        }
        else if (Rarerity == "SUS")
        {
            Rarerity = "UC";
            LibRare.color = Script.GetComponent<GameController>().GSilver;
        }

        LibRare.text = Rarerity;

        InfoWindow.SetActive(true);
   

    }

        //ハイスコア画面の描画
        public void GoHighScore()
    {

        
        TextMaxG1.text=MaxG1.ToString();
        TextMaxLv1.text = MaxLv1.ToString();
        TextMaxDays1.text = MaxDays1.ToString();

        TextMaxG2.text = MaxG2.ToString();
        TextMaxLv2.text = MaxLv2.ToString();
        TextMaxDays2.text = MaxDays2.ToString();

        TextMaxG3.text = MaxG3.ToString();
        TextMaxLv3.text = MaxLv3.ToString();
        TextMaxDays3.text = MaxDays3.ToString();

        TextMaxG4.text = MaxG4.ToString();
        TextMaxLv4.text = MaxLv4.ToString();
        TextMaxDays4.text = MaxDays4.ToString();

        TextMaxG5.text = MaxG5.ToString();
        TextMaxLv5.text = MaxLv5.ToString();
        TextMaxDays5.text = MaxDays5.ToString();

        Menu.SetActive(false);
        HighScore.SetActive(true);
        ScoreInfo.SetActive(false);
        Game.SetActive(false);
        Setting.SetActive(false);

        Score1.GetComponent<Glower2>().GlowRareTypeStop();
        Score2.GetComponent<Glower2>().GlowRareTypeStop();
        Score3.GetComponent<Glower2>().GlowRareTypeStop();
        Score4.GetComponent<Glower2>().GlowRareTypeStop();
        Score5.GetComponent<Glower2>().GlowRareTypeStop();

        //空のスコアは押せないようにする
        ScoreButton1.GetComponent<Button>().interactable = false;
        ScoreButton2.GetComponent<Button>().interactable = false;
        ScoreButton3.GetComponent<Button>().interactable = false;
        ScoreButton4.GetComponent<Button>().interactable = false;
        ScoreButton5.GetComponent<Button>().interactable = false;
        if (MaxDays1 != 0)
        {
            ScoreButton1.GetComponent<Button>().interactable = true;
        }
        if (MaxDays2 != 0)
        {
            ScoreButton2.GetComponent<Button>().interactable = true;
        }
        if (MaxDays3 != 0)
        {
            ScoreButton3.GetComponent<Button>().interactable = true;
        }
        if (MaxDays4 != 0)
        {
            ScoreButton4.GetComponent<Button>().interactable = true;
        }
        if (MaxDays5 != 0)
        {
            ScoreButton5.GetComponent<Button>().interactable = true;
        }


    }

    public void HighScoreRankIn1()
    {
        RankInNumber = 1;
        MaxLv5 = MaxLv4;
        MaxDays5 = MaxDays4;
        MaxKill5 = MaxKill4;
        MaxCustomer5 = MaxCustomer4;
        MaxCustomerVictory5 = MaxCustomerVictory4;
        MaxG5 = MaxG4;
        MaxGetG5 = MaxGetG4;
        CountPlay5 = CountPlay4;
        EndCard5 = EndCard4;

        MaxLv4 = MaxLv3;
        MaxDays4 = MaxDays3;
        MaxKill4 = MaxKill3;
        MaxCustomer4 = MaxCustomer3;
        MaxCustomerVictory4 = MaxCustomerVictory3;
        MaxG4 = MaxG3;
        MaxGetG4 = MaxGetG3;
        CountPlay4 = CountPlay3;
        EndCard4 = EndCard3;

        MaxLv3 = MaxLv2;
        MaxDays3 = MaxDays2;
        MaxKill3 = MaxKill2;
        MaxCustomer3 = MaxCustomer2;
        MaxCustomerVictory3 = MaxCustomerVictory2;
        MaxG3 = MaxG2;
        MaxGetG3 = MaxGetG2;
        CountPlay3 = CountPlay2;
        EndCard3 = EndCard2;

        MaxLv2 = MaxLv1;
        MaxDays2 = MaxDays1;
        MaxKill2 = MaxKill1;
        MaxCustomer2 = MaxCustomer1;
        MaxCustomerVictory2 = MaxCustomerVictory1;
        MaxG2 = MaxG1;
        MaxGetG2 = MaxGetG1;
        CountPlay2 = CountPlay1;
        EndCard2 = EndCard1;

        MaxLv1 = MaxLv;
        MaxDays1 = MaxDays;
        MaxKill1 = MaxKill;
        MaxCustomer1 = MaxCustomer;
        MaxCustomerVictory1 = MaxCustomerVictory;
        MaxG1 = MaxG;
        MaxGetG1 = MaxGetG;
        CountPlay1 = TotalCountPlay;
        EndCard1 = EndCard;

    }
    public void HighScoreRankIn2()
    {
        RankInNumber = 2;
        MaxLv5 = MaxLv4;
        MaxDays5 = MaxDays4;
        MaxKill5 = MaxKill4;
        MaxCustomer5 = MaxCustomer4;
        MaxCustomerVictory5 = MaxCustomerVictory4;
        MaxG5 = MaxG4;
        MaxGetG5 = MaxGetG4;
        CountPlay5 = CountPlay4;
        EndCard5 = EndCard4;

        MaxLv4 = MaxLv3;
        MaxDays4 = MaxDays3;
        MaxKill4 = MaxKill3;
        MaxCustomer4 = MaxCustomer3;
        MaxCustomerVictory4 = MaxCustomerVictory3;
        MaxG4 = MaxG3;
        MaxGetG4 = MaxGetG3;
        CountPlay4 = CountPlay3;
        EndCard4 = EndCard3;

        MaxLv3 = MaxLv2;
        MaxDays3 = MaxDays2;
        MaxKill3 = MaxKill2;
        MaxCustomer3 = MaxCustomer2;
        MaxCustomerVictory3 = MaxCustomerVictory2;
        MaxG3 = MaxG2;
        MaxGetG3 = MaxGetG2;
        CountPlay3 = CountPlay2;
        EndCard3 = EndCard2;

        MaxLv2 = MaxLv;
        MaxDays2 = MaxDays;
        MaxKill2 = MaxKill;
        MaxCustomer2 = MaxCustomer;
        MaxCustomerVictory2 = MaxCustomerVictory;
        MaxG2 = MaxG;
        MaxGetG2 = MaxGetG;
        CountPlay2 = TotalCountPlay;
        EndCard2 = EndCard;
    }
    public void HighScoreRankIn3()
    {
        RankInNumber = 3;
        MaxLv5 = MaxLv4;
        MaxDays5 = MaxDays4;
        MaxKill5 = MaxKill4;
        MaxCustomer5 = MaxCustomer4;
        MaxCustomerVictory5 = MaxCustomerVictory4;
        MaxG5 = MaxG4;
        MaxGetG5 = MaxGetG4;
        CountPlay5 = CountPlay4;
        EndCard5 = EndCard4;

        MaxLv4 = MaxLv3;
        MaxDays4 = MaxDays3;
        MaxKill4 = MaxKill3;
        MaxCustomer4 = MaxCustomer3;
        MaxCustomerVictory4 = MaxCustomerVictory3;
        MaxG4 = MaxG3;
        MaxGetG4 = MaxGetG3;
        CountPlay4 = CountPlay3;
        EndCard4 = EndCard3;

        MaxLv3 = MaxLv;
        MaxDays3 = MaxDays;
        MaxKill3 = MaxKill;
        MaxCustomer3 = MaxCustomer;
        MaxCustomerVictory3 = MaxCustomerVictory;
        MaxG3 = MaxG;
        MaxGetG3 = MaxGetG;
        CountPlay3 = TotalCountPlay;
        EndCard3 = EndCard;
    }
    public void HighScoreRankIn4()
    {
        RankInNumber = 4;
        MaxLv5 = MaxLv4;
        MaxDays5 = MaxDays4;
        MaxKill5 = MaxKill4;
        MaxCustomer5 = MaxCustomer4;
        MaxCustomerVictory5 = MaxCustomerVictory4;
        MaxG5 = MaxG4;
        MaxGetG5 = MaxGetG4;
        CountPlay5 = CountPlay4;
        EndCard5 = EndCard4;

        MaxLv4 = MaxLv;
        MaxDays4 = MaxDays;
        MaxKill4 = MaxKill;
        MaxCustomer4 = MaxCustomer;
        MaxCustomerVictory4 = MaxCustomerVictory;
        MaxG4 = MaxG;
        MaxGetG4 = MaxGetG;
        CountPlay4 = TotalCountPlay;
        EndCard4 = EndCard;
    }
    public void HighScoreRankIn5()
    {
        RankInNumber = 5;
        MaxLv5 = MaxLv;
        MaxDays5 = MaxDays;
        MaxKill5 = MaxKill;
        MaxCustomer5 = MaxCustomer;
        MaxCustomerVictory5 = MaxCustomerVictory;
        MaxG5 = MaxG;
        MaxGetG5 = MaxGetG;
        CountPlay5 = TotalCountPlay;
        EndCard5 = EndCard;
    }
    //前回プレイのスコアを光らせる
    public void ScoreGlow()
    {
        if (RankInNumber == 1) { Score1.GetComponent<Glower2>().GlowRareType(); }
        else if (RankInNumber == 2) { Score2.GetComponent<Glower2>().GlowRareType(); }
        else if (RankInNumber == 3) { Score3.GetComponent<Glower2>().GlowRareType(); }
        else if (RankInNumber == 4) { Score4.GetComponent<Glower2>().GlowRareType(); }
        else if (RankInNumber == 5) { Score5.GetComponent<Glower2>().GlowRareType(); }
        else { }
    }
    //ハイスコアの順位確認
    public int CheckHighScore()
    {
        RankInNumber = 0;
        int result = 1;
        //過去のスコアにまさっているかどうか確認し、まさっていれば挿入してスコアを更新
        if (MaxG == 0)
        {
            if (MaxDays > MaxDays1)
            {
                HighScoreRankIn1();
            }
            else if (MaxDays > MaxDays2)
            {
                HighScoreRankIn2();
            }
            else if (MaxDays > MaxDays3)
            {
                HighScoreRankIn3();
            }
            else if (MaxDays > MaxDays4)
            {
                HighScoreRankIn4();

            }
            else if (MaxDays > MaxDays5)
            {
                HighScoreRankIn5();
            }
            else if(MaxDays == MaxDays1)
            {
                if (MaxGetG > MaxGetG1)
                {
                    HighScoreRankIn1();
                }
                else if (MaxGetG > MaxGetG2)
                {
                    HighScoreRankIn2();
                }
                else if (MaxGetG > MaxGetG3)
                {
                    HighScoreRankIn3();
                }
                else if (MaxGetG > MaxGetG4)
                {
                    HighScoreRankIn4();

                }
                else if (MaxGetG > MaxGetG5)
                {
                    HighScoreRankIn5();
                }
                else
                {
                    result = 0;
                }
            }
            else
            {
                result = 0;
            }

        }
        else
        {
            if (MaxG > MaxG1)
            {
                HighScoreRankIn1();
            }
            else if (MaxG > MaxG2)
            {
                HighScoreRankIn2();
            }
            else if (MaxG > MaxG3)
            {
                HighScoreRankIn3();
            }
            else if (MaxG > MaxG4)
            {
                HighScoreRankIn4();

            }
            else if (MaxG > MaxG5)
            {
                HighScoreRankIn5();
            }
            else
            {

                result = 0;
            }
        }
        return result;
    }
    //客リストの記録
    public void WriteCustomerList()
    {
        CustomerListClass SaveList = new CustomerListClass();
        SaveList.List = CustomerList;
        PlayerPrefsUtils.SetObject(CustomerListKey, SaveList);
    }
        //ハイスコアの記録
        public void WriteHighScore()
    {
        //書き込み
        PlayerPrefs.SetInt(TotalCountPlayKey, TotalCountPlay);

        PlayerPrefs.SetInt(MaxLv1Key, MaxLv1);
        PlayerPrefs.SetInt(MaxDays1Key, MaxDays1);
        PlayerPrefs.SetInt(MaxKill1Key, MaxKill1);
        PlayerPrefs.SetInt(MaxCustomer1Key, MaxCustomer1);
        PlayerPrefs.SetInt(MaxCustomerVictory1Key, MaxCustomerVictory1);
        PlayerPrefs.SetInt(MaxG1Key, MaxG1);
        PlayerPrefs.SetInt(MaxGetG1Key, MaxGetG1);
        PlayerPrefs.SetInt(CountPlay1Key, CountPlay1);
        PlayerPrefs.SetInt(EndCard1Key, EndCard1);

        PlayerPrefs.SetInt(MaxLv2Key, MaxLv2);
        PlayerPrefs.SetInt(MaxDays2Key, MaxDays2);
        PlayerPrefs.SetInt(MaxKill2Key, MaxKill2);
        PlayerPrefs.SetInt(MaxCustomer2Key, MaxCustomer2);
        PlayerPrefs.SetInt(MaxCustomerVictory2Key, MaxCustomerVictory2);
        PlayerPrefs.SetInt(MaxG2Key, MaxG2);
        PlayerPrefs.SetInt(MaxGetG2Key, MaxGetG2);
        PlayerPrefs.SetInt(CountPlay2Key, CountPlay2);
        PlayerPrefs.SetInt(EndCard2Key, EndCard2);

        PlayerPrefs.SetInt(MaxLv3Key, MaxLv3);
        PlayerPrefs.SetInt(MaxDays3Key, MaxDays3);
        PlayerPrefs.SetInt(MaxKill3Key, MaxKill3);
        PlayerPrefs.SetInt(MaxCustomer3Key, MaxCustomer3);
        PlayerPrefs.SetInt(MaxCustomerVictory3Key, MaxCustomerVictory3);
        PlayerPrefs.SetInt(MaxG3Key, MaxG3);
        PlayerPrefs.SetInt(MaxGetG3Key, MaxGetG3);
        PlayerPrefs.SetInt(CountPlay3Key, CountPlay3);
        PlayerPrefs.SetInt(EndCard3Key, EndCard3);

        PlayerPrefs.SetInt(MaxLv4Key, MaxLv4);
        PlayerPrefs.SetInt(MaxDays4Key, MaxDays4);
        PlayerPrefs.SetInt(MaxKill4Key, MaxKill4);
        PlayerPrefs.SetInt(MaxCustomer4Key, MaxCustomer4);
        PlayerPrefs.SetInt(MaxCustomerVictory4Key, MaxCustomerVictory4);
        PlayerPrefs.SetInt(MaxG4Key, MaxG4);
        PlayerPrefs.SetInt(MaxGetG4Key, MaxGetG4);
        PlayerPrefs.SetInt(CountPlay4Key, CountPlay4);
        PlayerPrefs.SetInt(EndCard4Key, EndCard4);

        PlayerPrefs.SetInt(MaxLv5Key, MaxLv5);
        PlayerPrefs.SetInt(MaxDays5Key, MaxDays5);
        PlayerPrefs.SetInt(MaxKill5Key, MaxKill5);
        PlayerPrefs.SetInt(MaxCustomer5Key, MaxCustomer5);
        PlayerPrefs.SetInt(MaxCustomerVictory5Key, MaxCustomerVictory5);
        PlayerPrefs.SetInt(MaxG5Key, MaxG5);
        PlayerPrefs.SetInt(MaxGetG5Key, MaxGetG5);
        PlayerPrefs.SetInt(CountPlay5Key, CountPlay5);
        PlayerPrefs.SetInt(EndCard5Key, EndCard5);

    }
    //スコアリセット　デバッグ用
    public void ScoreReset()
    {
        PlayerPrefs.SetInt(TotalCountPlayKey, 0);

        PlayerPrefs.SetInt(MaxLv1Key, 0);
        PlayerPrefs.SetInt(MaxDays1Key, 0);
        PlayerPrefs.SetInt(MaxKill1Key, 0);
        PlayerPrefs.SetInt(MaxCustomer1Key, 0);
        PlayerPrefs.SetInt(MaxCustomerVictory1Key, 0);
        PlayerPrefs.SetInt(MaxG1Key, 0);
        PlayerPrefs.SetInt(MaxGetG1Key, 0);
        PlayerPrefs.SetInt(CountPlay1Key, 0);
        PlayerPrefs.SetInt(EndCard1Key, 0);

        PlayerPrefs.SetInt(MaxLv2Key, 0);
        PlayerPrefs.SetInt(MaxDays2Key, 0);
        PlayerPrefs.SetInt(MaxKill2Key, 0);
        PlayerPrefs.SetInt(MaxCustomer2Key, 0);
        PlayerPrefs.SetInt(MaxCustomerVictory2Key, 0);
        PlayerPrefs.SetInt(MaxG2Key, 0);
        PlayerPrefs.SetInt(MaxGetG2Key, 0);
        PlayerPrefs.SetInt(CountPlay2Key, 0);
        PlayerPrefs.SetInt(EndCard2Key, 0);

        PlayerPrefs.SetInt(MaxLv3Key, 0);
        PlayerPrefs.SetInt(MaxDays3Key, 0);
        PlayerPrefs.SetInt(MaxKill3Key, 0);
        PlayerPrefs.SetInt(MaxCustomer3Key, 0);
        PlayerPrefs.SetInt(MaxCustomerVictory3Key, 0);
        PlayerPrefs.SetInt(MaxG3Key, 0);
        PlayerPrefs.SetInt(MaxGetG3Key, 0);
        PlayerPrefs.SetInt(CountPlay3Key, 0);
        PlayerPrefs.SetInt(EndCard3Key, 0);

        PlayerPrefs.SetInt(MaxLv4Key, 0);
        PlayerPrefs.SetInt(MaxDays4Key, 0);
        PlayerPrefs.SetInt(MaxKill4Key, 0);
        PlayerPrefs.SetInt(MaxCustomer4Key, 0);
        PlayerPrefs.SetInt(MaxCustomerVictory4Key, 0);
        PlayerPrefs.SetInt(MaxG4Key, 0);
        PlayerPrefs.SetInt(MaxGetG4Key, 0);
        PlayerPrefs.SetInt(CountPlay4Key, 0);
        PlayerPrefs.SetInt(EndCard4Key, 0);

        PlayerPrefs.SetInt(MaxLv5Key, 0);
        PlayerPrefs.SetInt(MaxDays5Key,0);
        PlayerPrefs.SetInt(MaxKill5Key, 0);
        PlayerPrefs.SetInt(MaxCustomer5Key, 0);
        PlayerPrefs.SetInt(MaxCustomerVictory5Key, 0);
        PlayerPrefs.SetInt(MaxG5Key, 0);
        PlayerPrefs.SetInt(MaxGetG5Key, 0);
        PlayerPrefs.SetInt(CountPlay5Key, 0);
        PlayerPrefs.SetInt(EndCard5Key, 0);

        MaxLv1 = 0;//到達レベル
        MaxDays1 = 0;//到達日付
        MaxKill1 = 0;//殺人数
        MaxCustomer1 = 0;//さばいた客の数
        MaxCustomerVictory1 = 0;//うち魅了した客の数
        MaxG1 = 0;//最終的な持ち金＝スコア
        MaxGetG1 = 0;//かせいだ売上の総和　持ち金を引けば利益率が出る
        CountPlay1 = 0;//遊んだ回数　初回はチュートリアル出す　初回は数周で切る？
        EndCard1 = 0;

        MaxLv2 = 0;//到達レベル
        MaxDays2 = 0;//到達日付
        MaxKill2 = 0;//殺人数
        MaxCustomer2 = 0;//さばいた客の数
        MaxCustomerVictory2 = 0;//うち魅了した客の数
        MaxG2 = 0;//最終的な持ち金＝スコア
        MaxGetG2 = 0;//かせいだ売上の総和　持ち金を引けば利益率が出る
        CountPlay2 = 0;//遊んだ回数　初回はチュートリアル出す　初回は数周で切る？
        EndCard2 = 0;

        MaxLv3 = 0;//到達レベル
        MaxDays3 = 0;//到達日付
        MaxKill3 = 0;//殺人数
        MaxCustomer3 = 0;//さばいた客の数
        MaxCustomerVictory3 = 0;//うち魅了した客の数
        MaxG3 = 0;//最終的な持ち金＝スコア
        MaxGetG3 = 0;//かせいだ売上の総和　持ち金を引けば利益率が出る
        CountPlay3 = 0;//遊んだ回数　初回はチュートリアル出す　初回は数周で切る？
        EndCard3 = 0;

        MaxLv4 = 0;//到達レベル
        MaxDays4 = 0;//到達日付
        MaxKill4 = 0;//殺人数
        MaxCustomer4 = 0;//さばいた客の数
        MaxCustomerVictory4 = 0;//うち魅了した客の数
        MaxG4 = 0;//最終的な持ち金＝スコア
        MaxGetG4 = 0;//かせいだ売上の総和　持ち金を引けば利益率が出る
        CountPlay4 = 0;//遊んだ回数　初回はチュートリアル出す　初回は数周で切る？
        EndCard4 = 0;

        MaxLv5 = 0;//到達レベル
        MaxDays5 = 0;//到達日付
        MaxKill5 = 0;//殺人数
        MaxCustomer5 = 0;//さばいた客の数
        MaxCustomerVictory5 = 0;//うち魅了した客の数
        MaxG5 = 0;//最終的な持ち金＝スコア
        MaxGetG5 = 0;//かせいだ売上の総和　持ち金を引けば利益率が出る
        CountPlay5 = 0;//遊んだ回数　初回はチュートリアル出す　初回は数周で切る？
        EndCard5 = 0;

        MaxLv = 0;//到達レベル
        MaxDays = 0;//到達日付
        MaxKill = 0;//殺人数
        MaxCustomer = 0;//さばいた客の数
        MaxCustomerVictory = 0;//うち魅了した客の数
        MaxG = 0;//最終的な持ち金＝スコア
        MaxGetG = 0;//かせいだ売上の総和　持ち金を引けば利益率が出る
        EndCard = 0;

        TotalCountPlay = 0;//遊んだ回数　初回はチュートリアル出す　初回は数周で切る？

    }

    //エンドカード番号を返すとエンドカード画像名を返す
    public string EndCardPass(int EndNumber)
    {
        string Result = "";
        if (EndNumber == 1) { Result = "arrest"; }//逮捕
        else if (EndNumber == 2) { Result = "dorei"; }//どれい
        else if (EndNumber == 3) { Result = "tabi"; }//300万以上500万以下
        else if (EndNumber == 4) { Result = "tabi"; }//カルマ時わいろ
        else if (EndNumber == 5) { Result = "shop"; }//500万以上
        else if (EndNumber == 6) { Result = "win"; }//500万以上
        else { Result = "mu"; }//0のとき。初期値
        return Result;
    }
    //エンドカード番号を返すとエンドカード名称を返す
    public string EndCardName(int EndNumber)
    {
        string Result = "";
        if (EndNumber == 1) { Result = "ゲームオーバー"; }//逮捕
        else if (EndNumber == 2) { Result = "ゲームオーバー"; }//どれい
        else if (EndNumber == 3) { Result = "たびだち（タイムアップ）"; }//300万以上500万以下
        else if (EndNumber == 4) { Result = "たびだち（カルマオーバー）"; }//カルマ時わいろ
        else if (EndNumber == 5) { Result = "ゲームクリア"; }//500万以上
        else if (EndNumber == 6) { Result = "パーフェクトクリア"; }//500万以上
        else { Result = "データなし"; }//0のとき。初期値
        return Result;
    }
    //スコア詳細表示
    public void OpenScoreInfo(int ScoreNumber)
    {

        string EndKey = "";

        if (ScoreNumber == 1)
        {
            EndKey = EndCardPass(EndCard1);
            InfoResult.text = EndCardName(EndCard1);
            InfoRank.text="1";
            InfoG.text=MaxG1.ToString();
            InfoLv.text=MaxLv1.ToString();
            InfoDays.text =MaxDays1.ToString();
            InfoPlayCount.text =CountPlay1.ToString();
            InfoGetG.text =MaxGetG1.ToString();
            InfoCustomerNumber.text =MaxCustomer1.ToString();
            InfoVictory.text =MaxCustomerVictory1.ToString();
            InfoKill.text =MaxKill1.ToString();
        }
else if (ScoreNumber == 2)
            {
            EndKey = EndCardPass(EndCard2);
            InfoResult.text = EndCardName(EndCard2);
            InfoRank.text = "2";
                InfoG.text = MaxG2.ToString();
                InfoLv.text = MaxLv2.ToString();
                InfoDays.text = MaxDays2.ToString();
                InfoPlayCount.text = CountPlay2.ToString();
                InfoGetG.text = MaxGetG2.ToString();
                InfoCustomerNumber.text = MaxCustomer2.ToString();
                InfoVictory.text = MaxCustomerVictory2.ToString();
                InfoKill.text = MaxKill2.ToString();
            }
else if (ScoreNumber == 3)
        {
            EndKey = EndCardPass(EndCard3);
            InfoResult.text = EndCardName(EndCard3);
            InfoRank.text = "3";
            InfoG.text = MaxG3.ToString();
            InfoLv.text = MaxLv3.ToString();
            InfoDays.text = MaxDays3.ToString();
            InfoPlayCount.text = CountPlay3.ToString();
            InfoGetG.text = MaxGetG3.ToString();
            InfoCustomerNumber.text = MaxCustomer3.ToString();
            InfoVictory.text = MaxCustomerVictory3.ToString();
            InfoKill.text = MaxKill3.ToString();
        }
        else if (ScoreNumber == 4)
        {
            EndKey = EndCardPass(EndCard4);
            InfoResult.text = EndCardName(EndCard4);
            InfoRank.text = "4";
            InfoG.text = MaxG4.ToString();
            InfoLv.text = MaxLv4.ToString();
            InfoDays.text = MaxDays4.ToString();
            InfoPlayCount.text = CountPlay4.ToString();
            InfoGetG.text = MaxGetG4.ToString();
            InfoCustomerNumber.text = MaxCustomer4.ToString();
            InfoVictory.text = MaxCustomerVictory4.ToString();
            InfoKill.text = MaxKill4.ToString();
        }
        else if (ScoreNumber == 5)
        {
            EndKey = EndCardPass(EndCard5);
            InfoResult.text = EndCardName(EndCard5);
            InfoRank.text = "5";
            InfoG.text = MaxG5.ToString();
            InfoLv.text = MaxLv5.ToString();
            InfoDays.text = MaxDays5.ToString();
            InfoPlayCount.text = CountPlay5.ToString();
            InfoGetG.text = MaxGetG5.ToString();
            InfoCustomerNumber.text = MaxCustomer5.ToString();
            InfoVictory.text = MaxCustomerVictory5.ToString();
            InfoKill.text = MaxKill5.ToString();
        }


        string ImagePath = "Endcard/" + EndKey;
        Sprite SpriteImage = Resources.Load<Sprite>(ImagePath);
        ScoreEndCard.GetComponent<Image>().sprite = SpriteImage;

        ScoreInfo.SetActive(true);

    }


    //テキストのぼやけを切る
    public void Point(Text TargetText)
    {
        TargetText.font.material.mainTexture.filterMode = FilterMode.Point;

    }
    // Use this for initialization
    void Start () {
        Point(LibName);
        Point(LibText);
        Point(LibDropName);
        Point(LibDropPower);
        Point(LibDropSus);
        Point(LibMeatName);
        Point(LibMeatPower);
        Point(LibMeatSus);
        Point(LibDropG);
        Point(LibHp);
        Point(LibSaveSus);
        Point(LibPopLv);
        Point(LibDisLv);
        Point(LibRare);
        Point(LibCompleteNumber);
        Point(TextMaxG1);
        Point(TextMaxLv1);
        Point(TextMaxDays1);
        Point(TextMaxG2);
        Point(TextMaxLv2);
        Point(TextMaxDays2);
        Point(TextMaxG3);
        Point(TextMaxLv3);
        Point(TextMaxDays3);
        Point(TextMaxG4);
        Point(TextMaxLv4);
        Point(TextMaxDays4);
        Point(TextMaxG5);
        Point(TextMaxLv5);
        Point(TextMaxDays5);

        Point(InfoRank);
        Point(InfoG);
        Point(InfoLv);
        Point(InfoDays);
        Point(InfoPlayCount);
        Point(InfoResult);
        Point(InfoGetG);
        Point(InfoCustomerNumber);
        Point(InfoVictory);
        Point(InfoKill);


    ExistSave = PlayerPrefs.GetInt(ExistSaveKey, 0);

        TotalCountPlay = PlayerPrefs.GetInt(TotalCountPlayKey, 0);

        MaxLv1 = PlayerPrefs.GetInt(MaxLv1Key, 0);
        MaxDays1 = PlayerPrefs.GetInt(MaxDays1Key, 0);
        MaxKill1 = PlayerPrefs.GetInt(MaxKill1Key, 0);
        MaxCustomer1 = PlayerPrefs.GetInt(MaxCustomer1Key, 0);
        MaxCustomerVictory1 = PlayerPrefs.GetInt(MaxCustomerVictory1Key, 0);
        MaxG1 = PlayerPrefs.GetInt(MaxG1Key, 0);
        MaxGetG1 = PlayerPrefs.GetInt(MaxGetG1Key, 0);
        CountPlay1 = PlayerPrefs.GetInt(CountPlay1Key, 0);
        EndCard1= PlayerPrefs.GetInt(EndCard1Key, 0);

        MaxLv2 = PlayerPrefs.GetInt(MaxLv2Key, 0);
        MaxDays2 = PlayerPrefs.GetInt(MaxDays2Key, 0);
        MaxKill2 = PlayerPrefs.GetInt(MaxKill2Key, 0);
        MaxCustomer2 = PlayerPrefs.GetInt(MaxCustomer2Key, 0);
        MaxCustomerVictory2 = PlayerPrefs.GetInt(MaxCustomerVictory2Key, 0);
        MaxG2 = PlayerPrefs.GetInt(MaxG2Key, 0);
        MaxGetG2 = PlayerPrefs.GetInt(MaxGetG2Key, 0);
        CountPlay2 = PlayerPrefs.GetInt(CountPlay2Key, 0);
        EndCard2 = PlayerPrefs.GetInt(EndCard2Key, 0);

        MaxLv3 = PlayerPrefs.GetInt(MaxLv3Key, 0);
        MaxDays3 = PlayerPrefs.GetInt(MaxDays3Key, 0);
        MaxKill3 = PlayerPrefs.GetInt(MaxKill3Key, 0);
        MaxCustomer3 = PlayerPrefs.GetInt(MaxCustomer3Key, 0);
        MaxCustomerVictory3 = PlayerPrefs.GetInt(MaxCustomerVictory3Key, 0);
        MaxG3 = PlayerPrefs.GetInt(MaxG3Key, 0);
        MaxGetG3 = PlayerPrefs.GetInt(MaxGetG3Key, 0);
        CountPlay3 = PlayerPrefs.GetInt(CountPlay3Key, 0);
        EndCard3 = PlayerPrefs.GetInt(EndCard3Key, 0);

        MaxLv4 = PlayerPrefs.GetInt(MaxLv4Key, 0);
        MaxDays4 = PlayerPrefs.GetInt(MaxDays4Key, 0);
        MaxKill4 = PlayerPrefs.GetInt(MaxKill4Key, 0);
        MaxCustomer4 = PlayerPrefs.GetInt(MaxCustomer4Key, 0);
        MaxCustomerVictory4 = PlayerPrefs.GetInt(MaxCustomerVictory4Key, 0);
        MaxG4 = PlayerPrefs.GetInt(MaxG4Key, 0);
        MaxGetG4 = PlayerPrefs.GetInt(MaxGetG4Key, 0);
        CountPlay4 = PlayerPrefs.GetInt(CountPlay4Key, 0);
        EndCard4 = PlayerPrefs.GetInt(EndCard4Key, 0);

        MaxLv5 = PlayerPrefs.GetInt(MaxLv5Key, 0);
        MaxDays5 = PlayerPrefs.GetInt(MaxDays5Key, 0);
        MaxKill5 = PlayerPrefs.GetInt(MaxKill5Key, 0);
        MaxCustomer5 = PlayerPrefs.GetInt(MaxCustomer5Key, 0);
        MaxCustomerVictory5 = PlayerPrefs.GetInt(MaxCustomerVictory5Key, 0);
        MaxG5 = PlayerPrefs.GetInt(MaxG5Key, 0);
        MaxGetG5 = PlayerPrefs.GetInt(MaxGetG5Key, 0);
        CountPlay5 = PlayerPrefs.GetInt(CountPlay5Key, 0);
        EndCard5 = PlayerPrefs.GetInt(EndCard5Key, 0);

        FlagStoryOP = PlayerPrefs.GetInt(FSOPKey, 0);
        FlagTutorialFirstFeed = PlayerPrefs.GetInt(FT1FeedKey, 0);
        FlagTutorialSecondFeed = PlayerPrefs.GetInt(FT2FeedKey, 0);
        FlagTutorialThirdFeed = PlayerPrefs.GetInt(FT3FeedKey, 0);
        FlagTutorialFirstLvup = PlayerPrefs.GetInt(FT1LvupKey, 0);
        FlagTutorialFirstSaveSus = PlayerPrefs.GetInt(FT1SaveSusKey, 0);
        FlagTutorialFirstSelect = PlayerPrefs.GetInt(FT1SelectKey, 0);
        FlagTutorialFirstDispose = PlayerPrefs.GetInt(FT1DisposeKey, 0);
        FlagTutorialFirstRare = PlayerPrefs.GetInt(FT1RareKey, 0);
        FlagTutorialFirstHolyday = PlayerPrefs.GetInt(FT1HolydayKey, 0);

        CustomerListClass LoadList = new CustomerListClass();
        LoadList= PlayerPrefsUtils.GetObject<CustomerListClass>(CustomerListKey);
        LoadedCustomerList = LoadList.List;

    }

    // Update is called once per frame
    void Update () {
	
	}
}
