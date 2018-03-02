using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//プレイヤーのステータスを保持する
//プレイ外データ、ハイスコアなど
//オートセーブではこの中のデータが保持される
public class StatPlayer : MonoBehaviour {
    //StasGame
    public GameObject StatGame;
    
    //全体での遊んだ数
    public int TotalCountPlay = 0;//遊んだ回数　初回はチュートリアル出す　初回は数周で切る？

    //各画面
    public GameObject Menu;
    public GameObject Game;
    public GameObject HighScore;
    public GameObject AdsDelete;

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

    //今回のゲームでのスコア
    public int MaxLv=0;//到達レベル
    public int MaxDays=0;//到達日付
    public int MaxKill=0;//殺人数
    public int MaxCustomer=0;//さばいた客の数
    public int MaxCustomerVictory=0;//うち魅了した客の数
    public int MaxG=0;//最終的な持ち金＝スコア
    public int MaxGetG=0;//かせいだ売上の総和　持ち金を引けば利益率が出る

    //過去のスコア
    public int MaxLv1;//到達レベル
    public int MaxDays1;//到達日付
    public int MaxKill1;//殺人数
    public int MaxCustomer1;//さばいた客の数
    public int MaxCustomerVictory1;//うち魅了した客の数
    public int MaxG1;//最終的な持ち金＝スコア
    public int MaxGetG1;//かせいだ売上の総和　持ち金を引けば利益率が出る
    public int CountPlay1;//遊んだ回数　初回はチュートリアル出す　初回は数周で切る？

    public int MaxLv2;//到達レベル
    public int MaxDays2;//到達日付
    public int MaxKill2;//殺人数
    public int MaxCustomer2;//さばいた客の数
    public int MaxCustomerVictory2;//うち魅了した客の数
    public int MaxG2;//最終的な持ち金＝スコア
    public int MaxGetG2;//かせいだ売上の総和　持ち金を引けば利益率が出る
    public int CountPlay2;//遊んだ回数　初回はチュートリアル出す　初回は数周で切る？

    public int MaxLv3;//到達レベル
    public int MaxDays3;//到達日付
    public int MaxKill3;//殺人数
    public int MaxCustomer3;//さばいた客の数
    public int MaxCustomerVictory3;//うち魅了した客の数
    public int MaxG3;//最終的な持ち金＝スコア
    public int MaxGetG3;//かせいだ売上の総和　持ち金を引けば利益率が出る
    public int CountPlay3;//遊んだ回数　初回はチュートリアル出す　初回は数周で切る？

    public int MaxLv4;//到達レベル
    public int MaxDays4;//到達日付
    public int MaxKill4;//殺人数
    public int MaxCustomer4;//さばいた客の数
    public int MaxCustomerVictory4;//うち魅了した客の数
    public int MaxG4;//最終的な持ち金＝スコア
    public int MaxGetG4;//かせいだ売上の総和　持ち金を引けば利益率が出る
    public int CountPlay4;//遊んだ回数　初回はチュートリアル出す　初回は数周で切る？

    public int MaxLv5;//到達レベル
    public int MaxDays5;//到達日付
    public int MaxKill5;//殺人数
    public int MaxCustomer5;//さばいた客の数
    public int MaxCustomerVictory5;//うち魅了した客の数
    public int MaxG5;//最終的な持ち金＝スコア
    public int MaxGetG5;//かせいだ売上の総和　持ち金を引けば利益率が出る
    public int CountPlay5;//遊んだ回数　初回はチュートリアル出す　初回は数周で切る？

    public string TotalCountPlayKey = "TotalCountPlay";

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

    //セーブ中断のセーブ処理部分
    public void Save()
    {

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
            while(Count< 20)
            {
                if (Count < CustomerLength)
                {
                    CID[Count] = NormalCustomer[Count].GetComponent<StatCustomer>().Id;
                }
                else
                {
                    CID[Count] = 0;
                }
                PlayerPrefs.SetInt(CIDKey[Count], CID[Count]);

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
    //ハイスコア画面の描画
    public void GoHighScore()
    {
        Menu.SetActive(false);
        HighScore.SetActive(true);
        AdsDelete.SetActive(false);
        Game.SetActive(false);

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

    }

    //ハイスコアの順位確認
    public void CheckHighScore()
    {
        //過去のスコアにまさっているかどうか確認
        if (MaxG > MaxG1)
        {
            MaxLv5 = MaxLv4;
            MaxDays5 = MaxDays4;
            MaxKill5 = MaxKill4;
            MaxCustomer5 = MaxCustomer4;
            MaxCustomerVictory5 = MaxCustomerVictory4;
            MaxG5 = MaxG4;
            MaxGetG5 = MaxGetG4;
            CountPlay5 = CountPlay4;

            MaxLv4 = MaxLv3;
            MaxDays4 = MaxDays3;
            MaxKill4 = MaxKill3;
            MaxCustomer4 = MaxCustomer3;
            MaxCustomerVictory4 = MaxCustomerVictory3;
            MaxG4 = MaxG3;
            MaxGetG4 = MaxGetG3;
            CountPlay4 = CountPlay3;

            MaxLv3 = MaxLv2;
            MaxDays3 = MaxDays2;
            MaxKill3 = MaxKill2;
            MaxCustomer3 = MaxCustomer2;
            MaxCustomerVictory3 = MaxCustomerVictory2;
            MaxG3 = MaxG2;
            MaxGetG3 = MaxGetG2;
            CountPlay3 = CountPlay2;

            MaxLv2 = MaxLv1;
            MaxDays2 = MaxDays1;
            MaxKill2 = MaxKill1;
            MaxCustomer2 = MaxCustomer1;
            MaxCustomerVictory2 = MaxCustomerVictory1;
            MaxG2 = MaxG1;
            MaxGetG2 = MaxGetG1;
            CountPlay2 = CountPlay1;

            MaxLv1 = MaxLv;
            MaxDays1 = MaxDays;
            MaxKill1 = MaxKill;
            MaxCustomer1 = MaxCustomer;
            MaxCustomerVictory1 = MaxCustomerVictory;
            MaxG1 = MaxG;
            MaxGetG1 = MaxGetG;
            CountPlay1 = TotalCountPlay;
        }
        else if (MaxG > MaxG2)
        {
            MaxLv5 = MaxLv4;
            MaxDays5 = MaxDays4;
            MaxKill5 = MaxKill4;
            MaxCustomer5 = MaxCustomer4;
            MaxCustomerVictory5 = MaxCustomerVictory4;
            MaxG5 = MaxG4;
            MaxGetG5 = MaxGetG4;
            CountPlay5 = CountPlay4;

            MaxLv4 = MaxLv3;
            MaxDays4 = MaxDays3;
            MaxKill4 = MaxKill3;
            MaxCustomer4 = MaxCustomer3;
            MaxCustomerVictory4 = MaxCustomerVictory3;
            MaxG4 = MaxG3;
            MaxGetG4 = MaxGetG3;
            CountPlay4 = CountPlay3;

            MaxLv3 = MaxLv2;
            MaxDays3 = MaxDays2;
            MaxKill3 = MaxKill2;
            MaxCustomer3 = MaxCustomer2;
            MaxCustomerVictory3 = MaxCustomerVictory2;
            MaxG3 = MaxG2;
            MaxGetG3 = MaxGetG2;
            CountPlay3 = CountPlay2;

            MaxLv2 = MaxLv;
            MaxDays2 = MaxDays;
            MaxKill2 = MaxKill;
            MaxCustomer2 = MaxCustomer;
            MaxCustomerVictory2 = MaxCustomerVictory;
            MaxG2 = MaxG;
            MaxGetG2 = MaxGetG;
            CountPlay2 = TotalCountPlay;

        }
        else if (MaxG > MaxG3)
        {
            MaxLv5 = MaxLv4;
            MaxDays5 = MaxDays4;
            MaxKill5 = MaxKill4;
            MaxCustomer5 = MaxCustomer4;
            MaxCustomerVictory5 = MaxCustomerVictory4;
            MaxG5 = MaxG4;
            MaxGetG5 = MaxGetG4;
            CountPlay5 = CountPlay4;

            MaxLv4 = MaxLv3;
            MaxDays4 = MaxDays3;
            MaxKill4 = MaxKill3;
            MaxCustomer4 = MaxCustomer3;
            MaxCustomerVictory4 = MaxCustomerVictory3;
            MaxG4 = MaxG3;
            MaxGetG4 = MaxGetG3;
            CountPlay4 = CountPlay3;

            MaxLv3 = MaxLv;
            MaxDays3 = MaxDays;
            MaxKill3 = MaxKill;
            MaxCustomer3 = MaxCustomer;
            MaxCustomerVictory3 = MaxCustomerVictory;
            MaxG3 = MaxG;
            MaxGetG3 = MaxGetG;
            CountPlay3 = TotalCountPlay;

        }
        else if (MaxG > MaxG4)
        {
            MaxLv5 = MaxLv4;
            MaxDays5 = MaxDays4;
            MaxKill5 = MaxKill4;
            MaxCustomer5 = MaxCustomer4;
            MaxCustomerVictory5 = MaxCustomerVictory4;
            MaxG5 = MaxG4;
            MaxGetG5 = MaxGetG4;
            CountPlay5 = CountPlay4;

            MaxLv4 = MaxLv;
            MaxDays4 = MaxDays;
            MaxKill4 = MaxKill;
            MaxCustomer4 = MaxCustomer;
            MaxCustomerVictory4 = MaxCustomerVictory;
            MaxG4 = MaxG;
            MaxGetG4 = MaxGetG;
            CountPlay4 = TotalCountPlay;
        }

        else if (MaxG > MaxG5)
        {
            MaxLv5 = MaxLv;
            MaxDays5 = MaxDays;
            MaxKill5 = MaxKill;
            MaxCustomer5 = MaxCustomer;
            MaxCustomerVictory5 = MaxCustomerVictory;
            MaxG5 = MaxG;
            MaxGetG5 = MaxGetG;
            CountPlay5 = TotalCountPlay;
        }
        else { }


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

        PlayerPrefs.SetInt(MaxLv2Key, MaxLv2);
        PlayerPrefs.SetInt(MaxDays2Key, MaxDays2);
        PlayerPrefs.SetInt(MaxKill2Key, MaxKill2);
        PlayerPrefs.SetInt(MaxCustomer2Key, MaxCustomer2);
        PlayerPrefs.SetInt(MaxCustomerVictory2Key, MaxCustomerVictory2);
        PlayerPrefs.SetInt(MaxG2Key, MaxG2);
        PlayerPrefs.SetInt(MaxGetG2Key, MaxGetG2);
        PlayerPrefs.SetInt(CountPlay2Key, CountPlay2);

        PlayerPrefs.SetInt(MaxLv3Key, MaxLv3);
        PlayerPrefs.SetInt(MaxDays3Key, MaxDays3);
        PlayerPrefs.SetInt(MaxKill3Key, MaxKill3);
        PlayerPrefs.SetInt(MaxCustomer3Key, MaxCustomer3);
        PlayerPrefs.SetInt(MaxCustomerVictory3Key, MaxCustomerVictory3);
        PlayerPrefs.SetInt(MaxG3Key, MaxG3);
        PlayerPrefs.SetInt(MaxGetG3Key, MaxGetG3);
        PlayerPrefs.SetInt(CountPlay3Key, CountPlay3);

        PlayerPrefs.SetInt(MaxLv4Key, MaxLv4);
        PlayerPrefs.SetInt(MaxDays4Key, MaxDays4);
        PlayerPrefs.SetInt(MaxKill4Key, MaxKill4);
        PlayerPrefs.SetInt(MaxCustomer4Key, MaxCustomer4);
        PlayerPrefs.SetInt(MaxCustomerVictory4Key, MaxCustomerVictory4);
        PlayerPrefs.SetInt(MaxG4Key, MaxG4);
        PlayerPrefs.SetInt(MaxGetG4Key, MaxGetG4);
        PlayerPrefs.SetInt(CountPlay4Key, CountPlay4);

        PlayerPrefs.SetInt(MaxLv5Key, MaxLv5);
        PlayerPrefs.SetInt(MaxDays5Key, MaxDays5);
        PlayerPrefs.SetInt(MaxKill5Key, MaxKill5);
        PlayerPrefs.SetInt(MaxCustomer5Key, MaxCustomer5);
        PlayerPrefs.SetInt(MaxCustomerVictory5Key, MaxCustomerVictory5);
        PlayerPrefs.SetInt(MaxG5Key, MaxG5);
        PlayerPrefs.SetInt(MaxGetG5Key, MaxGetG5);
        PlayerPrefs.SetInt(CountPlay5Key, CountPlay5);

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

        PlayerPrefs.SetInt(MaxLv2Key, 0);
        PlayerPrefs.SetInt(MaxDays2Key, 0);
        PlayerPrefs.SetInt(MaxKill2Key, 0);
        PlayerPrefs.SetInt(MaxCustomer2Key, 0);
        PlayerPrefs.SetInt(MaxCustomerVictory2Key, 0);
        PlayerPrefs.SetInt(MaxG2Key, 0);
        PlayerPrefs.SetInt(MaxGetG2Key, 0);
        PlayerPrefs.SetInt(CountPlay2Key, 0);

        PlayerPrefs.SetInt(MaxLv3Key, 0);
        PlayerPrefs.SetInt(MaxDays3Key, 0);
        PlayerPrefs.SetInt(MaxKill3Key, 0);
        PlayerPrefs.SetInt(MaxCustomer3Key, 0);
        PlayerPrefs.SetInt(MaxCustomerVictory3Key, 0);
        PlayerPrefs.SetInt(MaxG3Key, 0);
        PlayerPrefs.SetInt(MaxGetG3Key, 0);
        PlayerPrefs.SetInt(CountPlay3Key, 0);

        PlayerPrefs.SetInt(MaxLv4Key, 0);
        PlayerPrefs.SetInt(MaxDays4Key, 0);
        PlayerPrefs.SetInt(MaxKill4Key, 0);
        PlayerPrefs.SetInt(MaxCustomer4Key, 0);
        PlayerPrefs.SetInt(MaxCustomerVictory4Key, 0);
        PlayerPrefs.SetInt(MaxG4Key, 0);
        PlayerPrefs.SetInt(MaxGetG4Key, 0);
        PlayerPrefs.SetInt(CountPlay4Key, 0);

        PlayerPrefs.SetInt(MaxLv5Key, 0);
        PlayerPrefs.SetInt(MaxDays5Key,0);
        PlayerPrefs.SetInt(MaxKill5Key, 0);
        PlayerPrefs.SetInt(MaxCustomer5Key, 0);
        PlayerPrefs.SetInt(MaxCustomerVictory5Key, 0);
        PlayerPrefs.SetInt(MaxG5Key, 0);
        PlayerPrefs.SetInt(MaxGetG5Key, 0);
        PlayerPrefs.SetInt(CountPlay5Key, 0);

        MaxLv1 = 0;//到達レベル
        MaxDays1 = 0;//到達日付
        MaxKill1 = 0;//殺人数
        MaxCustomer1 = 0;//さばいた客の数
        MaxCustomerVictory1 = 0;//うち魅了した客の数
        MaxG1 = 0;//最終的な持ち金＝スコア
        MaxGetG1 = 0;//かせいだ売上の総和　持ち金を引けば利益率が出る
        CountPlay1 = 0;//遊んだ回数　初回はチュートリアル出す　初回は数周で切る？

        MaxLv2 = 0;//到達レベル
        MaxDays2 = 0;//到達日付
        MaxKill2 = 0;//殺人数
        MaxCustomer2 = 0;//さばいた客の数
        MaxCustomerVictory2 = 0;//うち魅了した客の数
        MaxG2 = 0;//最終的な持ち金＝スコア
        MaxGetG2 = 0;//かせいだ売上の総和　持ち金を引けば利益率が出る
        CountPlay2 = 0;//遊んだ回数　初回はチュートリアル出す　初回は数周で切る？

        MaxLv3 = 0;//到達レベル
        MaxDays3 = 0;//到達日付
        MaxKill3 = 0;//殺人数
        MaxCustomer3 = 0;//さばいた客の数
        MaxCustomerVictory3 = 0;//うち魅了した客の数
        MaxG3 = 0;//最終的な持ち金＝スコア
        MaxGetG3 = 0;//かせいだ売上の総和　持ち金を引けば利益率が出る
        CountPlay3 = 0;//遊んだ回数　初回はチュートリアル出す　初回は数周で切る？

        MaxLv4 = 0;//到達レベル
        MaxDays4 = 0;//到達日付
        MaxKill4 = 0;//殺人数
        MaxCustomer4 = 0;//さばいた客の数
        MaxCustomerVictory4 = 0;//うち魅了した客の数
        MaxG4 = 0;//最終的な持ち金＝スコア
        MaxGetG4 = 0;//かせいだ売上の総和　持ち金を引けば利益率が出る
        CountPlay4 = 0;//遊んだ回数　初回はチュートリアル出す　初回は数周で切る？

        MaxLv5 = 0;//到達レベル
        MaxDays5 = 0;//到達日付
        MaxKill5 = 0;//殺人数
        MaxCustomer5 = 0;//さばいた客の数
        MaxCustomerVictory5 = 0;//うち魅了した客の数
        MaxG5 = 0;//最終的な持ち金＝スコア
        MaxGetG5 = 0;//かせいだ売上の総和　持ち金を引けば利益率が出る
        CountPlay5 = 0;//遊んだ回数　初回はチュートリアル出す　初回は数周で切る？

        MaxLv = 0;//到達レベル
        MaxDays = 0;//到達日付
        MaxKill = 0;//殺人数
        MaxCustomer = 0;//さばいた客の数
        MaxCustomerVictory = 0;//うち魅了した客の数
        MaxG = 0;//最終的な持ち金＝スコア
        MaxGetG = 0;//かせいだ売上の総和　持ち金を引けば利益率が出る

        TotalCountPlay = 0;//遊んだ回数　初回はチュートリアル出す　初回は数周で切る？

    }

    // Use this for initialization
    void Start () {

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

        MaxLv2 = PlayerPrefs.GetInt(MaxLv2Key, 0);
        MaxDays2 = PlayerPrefs.GetInt(MaxDays2Key, 0);
        MaxKill2 = PlayerPrefs.GetInt(MaxKill2Key, 0);
        MaxCustomer2 = PlayerPrefs.GetInt(MaxCustomer2Key, 0);
        MaxCustomerVictory2 = PlayerPrefs.GetInt(MaxCustomerVictory2Key, 0);
        MaxG2 = PlayerPrefs.GetInt(MaxG2Key, 0);
        MaxGetG2 = PlayerPrefs.GetInt(MaxGetG2Key, 0);
        CountPlay2 = PlayerPrefs.GetInt(CountPlay2Key, 0);

        MaxLv3 = PlayerPrefs.GetInt(MaxLv3Key, 0);
        MaxDays3 = PlayerPrefs.GetInt(MaxDays3Key, 0);
        MaxKill3 = PlayerPrefs.GetInt(MaxKill3Key, 0);
        MaxCustomer3 = PlayerPrefs.GetInt(MaxCustomer3Key, 0);
        MaxCustomerVictory3 = PlayerPrefs.GetInt(MaxCustomerVictory3Key, 0);
        MaxG3 = PlayerPrefs.GetInt(MaxG3Key, 0);
        MaxGetG3 = PlayerPrefs.GetInt(MaxGetG3Key, 0);
        CountPlay3 = PlayerPrefs.GetInt(CountPlay3Key, 0);

        MaxLv4 = PlayerPrefs.GetInt(MaxLv4Key, 0);
        MaxDays4 = PlayerPrefs.GetInt(MaxDays4Key, 0);
        MaxKill4 = PlayerPrefs.GetInt(MaxKill4Key, 0);
        MaxCustomer4 = PlayerPrefs.GetInt(MaxCustomer4Key, 0);
        MaxCustomerVictory4 = PlayerPrefs.GetInt(MaxCustomerVictory4Key, 0);
        MaxG4 = PlayerPrefs.GetInt(MaxG4Key, 0);
        MaxGetG4 = PlayerPrefs.GetInt(MaxGetG4Key, 0);
        CountPlay4 = PlayerPrefs.GetInt(CountPlay4Key, 0);

        MaxLv5 = PlayerPrefs.GetInt(MaxLv5Key, 0);
        MaxDays5 = PlayerPrefs.GetInt(MaxDays5Key, 0);
        MaxKill5 = PlayerPrefs.GetInt(MaxKill5Key, 0);
        MaxCustomer5 = PlayerPrefs.GetInt(MaxCustomer5Key, 0);
        MaxCustomerVictory5 = PlayerPrefs.GetInt(MaxCustomerVictory5Key, 0);
        MaxG5 = PlayerPrefs.GetInt(MaxG5Key, 0);
        MaxGetG5 = PlayerPrefs.GetInt(MaxGetG5Key, 0);
        CountPlay5 = PlayerPrefs.GetInt(CountPlay5Key, 0);

    }

    // Update is called once per frame
    void Update () {
	
	}
}
