using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//ゲームの進行を制御する

public class GameController : MonoBehaviour
{
    //プレイヤーstat
    public GameObject StatPlayer;
    //ゲームstat
    public GameObject StatGame;

    //ハイスコア関連
    public int MaxKill;//殺人数
    public int MaxCustomer;//さばいた客の数
    public int MaxCustomerVictory;//うち魅了した客の数
    public int MaxGetG;//かせいだ売上の総和

    //各画面
    public GameObject Menu;
    public GameObject Game;
    public GameObject HighScore;
    public GameObject AdsDelete;

    //各パーツ
    public GameObject CustomerField;
    public GameObject CustomerFieldBack;
    public GameObject CustomerFieldCollider;



    //ボタン類
    public GameObject Button4Items;
    public GameObject Button4Items1;
    public GameObject Button4Items2;
    public GameObject Button4Items3;
    public GameObject Button4Items4;

    public GameObject Button6Items;
    public GameObject Button6Items1;
    public GameObject Button6Items2;
    public GameObject Button6Items3;
    public GameObject Button6Items4;
    public GameObject Button6Items5;
    public GameObject Button6Items6;

    public GameObject ButtonSelectItem;
    public GameObject SelectItemImage1;
    public Text SelectItemName1;
    public Text SelectItemPower1;
    public GameObject SelectItemImage2;
    public Text SelectItemName2;
    public Text SelectItemPower2;
    public GameObject SelectButtonOK;
    public GameObject ButtonGoResult;

    public GameObject TapButton;

    //ポップアップ類
    public GameObject PopupResultG;
    public Text PopupResultGTextG;
    public Text PopupResultGTextExp;
    public Text PopupResultGTextSus;
    public GameObject SusLine;

    public GameObject PopupSave;
    public GameObject PopupLoad;


    public GameObject PopupDisposeItem;
    public Text PopupDisposeText;
    public GameObject PopupGetItem;
    public Text PopupGetText;
    public GameObject PopupLvUp;
    public Text PopupLvUpText;
    public GameObject PopupGameOver;

    //メッセージ欄
    public GameObject Message;
    public Text MessageText;

    //プレハブ
    public GameObject HeartPrefab;
    public GameObject ColorCheckPrefab;
    public GameObject SelectBoxPrefab;

    //イベントシステムの取得（処理中に切る場合がある）
    public GameObject EventSystem;
    //タップ切るための板
   public GameObject TapBlock;
    public GameObject FieldBlock;


    //ゲームスタート
    public void GameStart()
    {
        TapBlock.SetActive(true);
        EventSystem.SetActive(false);

        //ゲーム画面への遷移
        Menu.SetActive(false);
        HighScore.SetActive(false);
        AdsDelete.SetActive(false);
        Game.SetActive(true);

        //ボタン初期化
        Button4Items.SetActive(true);
        Button6Items.SetActive(false);
        ButtonSelectItem.SetActive(false);
        PopupResultG.SetActive(false);
        PopupDisposeItem.SetActive(false);
        Message.SetActive(true);
        CustomerField.SetActive(true);
        PopupGetItem.SetActive(false);
        PopupLvUp.SetActive(false);
        PopupGameOver.SetActive(false);
        ButtonGoResult.SetActive(false);
        TapButton.SetActive(false);
        PopupSave.SetActive(false);
        PopupLoad.SetActive(false);

        FieldBlock.SetActive(false);

        CustomerFieldBack.SetActive(true);
        CustomerFieldCollider.SetActive(true);

        Button4Items1.GetComponent<Button>().interactable = true;
        Button4Items2.GetComponent<Button>().interactable = true;
        Button4Items3.GetComponent<Button>().interactable = true;
        Button4Items4.GetComponent<Button>().interactable = true;


        //所持アイテムのリセット
        StatGame.GetComponent<StatGame>().Item1 = new string[] { "None", "None", "None", "None", "None" };
        StatGame.GetComponent<StatGame>().Item2 = new string[] { "None", "None", "None", "None", "None" };
        StatGame.GetComponent<StatGame>().Item3 = new string[] { "None", "None", "None", "None", "None" };
        StatGame.GetComponent<StatGame>().Item4 = new string[] { "None", "None", "None", "None", "None" };
        //所持扱いにならない、取得処理時に使う枠
        StatGame.GetComponent<StatGame>().Item5 = new string[] { "None", "None", "None", "None", "None" };
        StatGame.GetComponent<StatGame>().Item6 = new string[] { "None", "None", "None", "None", "None" };

        //ロード前の描画リセット
        GetComponent<StatGameController>().DrawSus();
        GetComponent<StatGameController>().DrawG();
        GetComponent<StatGameController>().DrawLv();
        GetComponent<StatGameController>().DrawDays();
        GetComponent<StatGameController>().DrawExp();
        GetComponent<StatGameController>().DrawItem4();

        if (StatPlayer.GetComponent<StatPlayer>().ExistSave == 1)
        {
            //ある時はロードの選択肢を出す  
            PopupLoad.SetActive(true);

        }
        else
        {
            //無ければ初期処理に直行
            NoLoadStart();
        }

    
        TapBlock.SetActive(false);
        EventSystem.SetActive(true);
    }

    //セーブがある時の初期処理
    public void LoadStart()
    {
        TapBlock.SetActive(true);
        EventSystem.SetActive(false);
        PopupLoad.SetActive(false);

        StatPlayer.GetComponent<StatPlayer>().Load();
        //ロードでステータスは読み込まれる

        MaxKill = StatPlayer.GetComponent<StatPlayer>().MaxKill; //殺人数
        MaxCustomer = StatPlayer.GetComponent<StatPlayer>().MaxCustomer;//さばいた客の数
        MaxCustomerVictory = StatPlayer.GetComponent<StatPlayer>().MaxCustomerVictory;//うち魅了した客の数
        MaxGetG = StatPlayer.GetComponent<StatPlayer>().MaxGetG; ;//かせいだ売上の総和

        //初期アイテムの生成
        GetComponent<LvDesignController>().MakeItemFirst();
        //レベルデザイン情報の読み込み
        GetComponent<LvDesignController>().GetLvDesignData();

        //客データの読み込み
        GetComponent<CustomerController>().GetCustomerData(StatGame.GetComponent<StatGame>().StatLv);

        GetComponent<StatGameController>().DrawSus();
        GetComponent<StatGameController>().DrawG();
        GetComponent<StatGameController>().DrawLv();
        GetComponent<StatGameController>().DrawDays();
        GetComponent<StatGameController>().DrawExp();

        CustomerStart1();

        CustomerStart2();

        //初期客の生成
        GetComponent<LvDesignController>().MakeSavedCustomer();


        TapBlock.SetActive(false);
        EventSystem.SetActive(true);

    }

    //セーブがない時の初期処理
    public void NoLoadStart()
    {
        TapBlock.SetActive(true);
        EventSystem.SetActive(false);
        PopupLoad.SetActive(false);

        StatPlayer.GetComponent<StatPlayer>().SaveDelete();//セーブは消す

        //セーブがない場合の初期値
        //パラメータ初期化
        StatGame.GetComponent<StatGame>().StatSus = 0;
        StatGame.GetComponent<StatGame>().StatG = 0;
        StatGame.GetComponent<StatGame>().StatLv = 1;
        StatGame.GetComponent<StatGame>().StatExp = 0;
        StatGame.GetComponent<StatGame>().StatDays = 0;

        MaxKill = 0;//殺人数
        MaxCustomer = 0;//さばいた客の数
        MaxCustomerVictory = 0;//うち魅了した客の数
        MaxGetG = 0;//かせいだ売上の総和

        //初期アイテムの生成
        GetComponent<LvDesignController>().MakeItemFirst();
        //レベルデザイン情報の読み込み
        GetComponent<LvDesignController>().GetLvDesignData();

        //客データの読み込み
        GetComponent<CustomerController>().GetCustomerData(StatGame.GetComponent<StatGame>().StatLv);

        GetComponent<StatGameController>().DrawSus();
        GetComponent<StatGameController>().DrawG();
        GetComponent<StatGameController>().DrawLv();
        GetComponent<StatGameController>().DrawDays();
        GetComponent<StatGameController>().DrawExp();

        CustomerStart1();

        CustomerStart2();

            //初期客の生成
            GetComponent<LvDesignController>().MakeCustomerFirst();

        TapBlock.SetActive(false);
        EventSystem.SetActive(true);
    }

    //今いる客をすべて破壊
    public void CustomerDestroy()
    {
        TapBlock.SetActive(true);
        EventSystem.SetActive(false);

        //前周の客を破壊
        if (GameObject.FindGameObjectWithTag("Top0") != null) { Destroy(GameObject.FindGameObjectWithTag("Top0")); }
        if (GameObject.FindGameObjectWithTag("Top1") != null) { Destroy(GameObject.FindGameObjectWithTag("Top1")); }
        if (GameObject.FindGameObjectWithTag("Top2") != null) { Destroy(GameObject.FindGameObjectWithTag("Top2")); }
        if (GameObject.FindGameObjectWithTag("Top3") != null) { Destroy(GameObject.FindGameObjectWithTag("Top3")); }

        if (GameObject.FindGameObjectWithTag("Item0") != null) { Destroy(GameObject.FindGameObjectWithTag("Item0")); }
        if (GameObject.FindGameObjectWithTag("Item1") != null) { Destroy(GameObject.FindGameObjectWithTag("Item1")); }
        if (GameObject.FindGameObjectWithTag("Item2") != null) { Destroy(GameObject.FindGameObjectWithTag("Item2")); }
        if (GameObject.FindGameObjectWithTag("Item3") != null) { Destroy(GameObject.FindGameObjectWithTag("Item3")); }

        int Count;
        int CustomerLength;
        if (GameObject.FindGameObjectsWithTag("Customer") != null)
        {
            GameObject[] NormalCustomer = GameObject.FindGameObjectsWithTag("Customer");
            Count = 0;
            CustomerLength = NormalCustomer.GetLength(0);
            while (Count < CustomerLength)
            {
                Destroy(NormalCustomer[Count]);
                Count++;
                Debug.Log("Destroy");
            }
        }

            if (GameObject.FindGameObjectsWithTag("Loser") != null)
        {
            GameObject[] LoserNotTop = GameObject.FindGameObjectsWithTag("Loser");
            Count = 0;
            CustomerLength = LoserNotTop.GetLength(0);
            while (Count < CustomerLength)
            {
                Destroy(LoserNotTop[Count]);
                Count++;
            }
        }
        if (GameObject.FindGameObjectsWithTag("Winner") != null)
        {
            GameObject[] Winner = GameObject.FindGameObjectsWithTag("Winner");
            Count = 0;
            CustomerLength = Winner.GetLength(0);
            while (Count < CustomerLength)
            {
                Destroy(Winner[Count]);
                Count++;
            }
        }


        TapBlock.SetActive(false);
        EventSystem.SetActive(true);
    }

    //来客開始前
    //この状態にしつつSaveポップアップなどが出ている
    public void CustomerStart1()
    {
        TapBlock.SetActive(true);
        EventSystem.SetActive(false);

        FieldBlock.SetActive(true);

        //表示パネルの初期化
        //客表示せず、操作できない状態
        Button4Items.SetActive(false);
        Button6Items.SetActive(false);
        ButtonSelectItem.SetActive(false);
        PopupResultG.SetActive(false);
        PopupDisposeItem.SetActive(false);
        Message.SetActive(false);
        CustomerField.SetActive(true);

        PopupGetItem.SetActive(false);
        PopupLvUp.SetActive(false);
        PopupGameOver.SetActive(false);
        ButtonGoResult.SetActive(false);
        TapButton.SetActive(false);
        PopupSave.SetActive(false);
        PopupLoad.SetActive(false);

        CustomerFieldBack.SetActive(false);
        CustomerFieldCollider.SetActive(false);


        TapBlock.SetActive(false);
        EventSystem.SetActive(true);
    }

    //保存→中断画面
    //広告出すとしたらここが候補
    //ノルマなどを表示するのに使うのもあり
    public void SelectSave()
    {
        PopupSave.SetActive(true);
        //セーブ選択画面を表示

    }

    public void SaveEnd()
    {

        GetHighScore();
        StatPlayer.GetComponent<StatPlayer>().Save();
        CustomerDestroy();
        GoMenu();
        //客破壊
    }


    //生成した客を可視化し、アイテム等押せるようにする
    public void CustomerStart2()
    {
        TapBlock.SetActive(true);
        EventSystem.SetActive(false);

        //日付を経過させる
        GetComponent<StatGameController>().DaysUp(1);

        //ステ描画
        GetComponent<StatGameController>().DrawSus();
        GetComponent<StatGameController>().DrawG();
        GetComponent<StatGameController>().DrawLv();
        GetComponent<StatGameController>().DrawDays();
        GetComponent<StatGameController>().DrawExp();

        //表示パネルの初期化
        //ボタン初期化
        FieldBlock.SetActive(false);

        Button4Items.SetActive(true);
        Button6Items.SetActive(false);
        ButtonSelectItem.SetActive(false);
        PopupResultG.SetActive(false);
        PopupDisposeItem.SetActive(false);
        Message.SetActive(true);
        CustomerField.SetActive(true);
        PopupGetItem.SetActive(false);
        PopupLvUp.SetActive(false);
        PopupGameOver.SetActive(false);
        ButtonGoResult.SetActive(false);
        TapButton.SetActive(false);
        PopupSave.SetActive(false);


        CustomerFieldBack.SetActive(true);
        CustomerFieldCollider.SetActive(true);


        Button4Items1.GetComponent<Button>().interactable = true;
        Button4Items2.GetComponent<Button>().interactable = true;
        Button4Items3.GetComponent<Button>().interactable = true;
        Button4Items4.GetComponent<Button>().interactable = true;

        //アイテムパネルの描画
        Button4Items.SetActive(true);
        GetComponent<StatGameController>().DrawItem4();

        //メッセージ表示
        MessageDraw("つかう しょくざい を タップしてください");

        TapBlock.SetActive(false);
        EventSystem.SetActive(true);
    }

    //食材選択　→　効果判定　→　Gリザルト表示
    public void Feed(int ItemNum)
    {
        TapBlock.SetActive(true);
        EventSystem.SetActive(false);

        MessageDraw("");
        Button4Items.SetActive(false);

        //どの所持アイテムが押されたか判定、そのアイテムは所持アイテムから消す
        string[] UseItem= new string[4];
        string[] NoItem = { "None", "None", "None", "None", "None" };
        if (ItemNum == 1) { UseItem = StatGame.GetComponent<StatGame>().Item1;
            StatGame.GetComponent<StatGame>().Item1 = NoItem;
        }
        else if (ItemNum == 2) { UseItem = StatGame.GetComponent<StatGame>().Item2;
            StatGame.GetComponent<StatGame>().Item2 = NoItem;
        }
        else if (ItemNum == 3) { UseItem = StatGame.GetComponent<StatGame>().Item3;
            StatGame.GetComponent<StatGame>().Item3 = NoItem;
        }
        else if (ItemNum == 4) { UseItem = StatGame.GetComponent<StatGame>().Item4;
            StatGame.GetComponent<StatGame>().Item4 = NoItem;
        }
        else { Debug.Log("１～４以外のアイテム番号が送られています"); }
//客をすべて取得し、一体ずつ処理
        GameObject[] Customers=GameObject.FindGameObjectsWithTag("Customer");
        int Count = 0;
        int CustomerLength = Customers.GetLength(0);
        int UseItemPower = int.Parse(UseItem[2]);
        string UseItemColor = UseItem[3];
        float UseItemUpSus = float.Parse(UseItem[4]);

        int GetG =0;
        int GetExp = 0;
        float GetSus = 0;
        float VictoryPoint=0;
        int RateColor = 0;

        //Susは人数に関わらず上がる
        GetSus = UseItemUpSus;

        while (Count<CustomerLength)
        {
            MaxCustomer++;//さばいた客の数

            int CustomerHp = Customers[Count].GetComponent<StatCustomer>().Hp;
            int CustomerDropG = Customers[Count].GetComponent<StatCustomer>().DropG;
            string CustomerColor = Customers[Count].GetComponent<StatCustomer>().Color;


            //色距離の取得
            Color UseColor = GetComponent<ColorGetter>().ToColor(UseItemColor);
            Color CustomColor = GetComponent<ColorGetter>().ToColor(CustomerColor);
            RateColor = GetComponent<LvDesignController>().ColorCondition(UseItemColor, CustomerColor);

                        GameObject ColorCheck = (GameObject)Instantiate(
                                   ColorCheckPrefab,
                                   transform.position,
                                   Quaternion.identity);
                        ColorCheck.transform.SetParent(Customers[Count].transform);
                        //位置決定
                        ColorCheck.transform.localPosition = new Vector3(0, 90, 0);
                        string DistancePerString = (RateColor).ToString();
            ColorCheck.GetComponent<Text>().text = DistancePerString+"";


            //Powerを比べる
            //こちらの勝利
            VictoryPoint = GetComponent<LvDesignController>().VictoryCondition(UseItemPower, CustomerHp, RateColor);
            if (VictoryPoint >= 0)
            {
                MaxCustomerVictory ++;//うち魅了した客の数


                //ハートの生成
                GameObject Heart = (GameObject)Instantiate(
                           HeartPrefab,
                           transform.position,
                           Quaternion.identity);
                Heart.transform.SetParent(Customers[Count].transform);
                //位置決定
                Heart.transform.localPosition = new Vector3(0, 70, 0);

                //タグをつける
                Customers[Count].tag = "Loser";
                //勝利度合の記録
                Customers[Count].GetComponent<StatCustomer>().PointPower =UseItemPower-CustomerHp;
                Customers[Count].GetComponent<StatCustomer>().PointColor = RateColor;

                //賞金取得
                GetG+=GetComponent<LvDesignController>().VictoryDropG(CustomerDropG,VictoryPoint);
                //exp獲得
                GetExp += GetComponent<LvDesignController>().VictoryDropExp(CustomerDropG, VictoryPoint);//Exp基数=Gと同じ

            }
            //客の勝利
            else
            {
                //タグをつける
                Customers[Count].tag = "Winner";
            }

            Count++;
        }

        float ResultGetSus = GetComponent<LvDesignController>().FeedGetSus(GetSus);

        //変動値を一時的にSTATに記録
        StatGame.GetComponent<StatGame>().ResultGetG =GetG;
        StatGame.GetComponent<StatGame>().ResultGetExp = GetExp;
        StatGame.GetComponent<StatGame>().ResultGetSus = ResultGetSus;

        //OKボタン表示
        ButtonGoResult.SetActive(true);

        TapBlock.SetActive(false);
        EventSystem.SetActive(true);

    }

    public void PopupResultGPop()
    {
        TapBlock.SetActive(true);
        EventSystem.SetActive(false);

        ButtonGoResult.SetActive(false);

        int GetG = StatGame.GetComponent<StatGame>().ResultGetG;
        int GetExp = StatGame.GetComponent<StatGame>().ResultGetExp;
        float GetSus = StatGame.GetComponent<StatGame>().ResultGetSus;

        //合計賞金を加算
        GetComponent<StatGameController>().GUp(GetG);

        //EXPを加算
        GetComponent<StatGameController>().ExpUp(GetExp);

        //Susを加算
        GetComponent<StatGameController>().SusUp(GetSus);

        MaxGetG += GetG;//かせいだ売上の総和


        TapButton.SetActive(true);
        TapBlock.SetActive(false);
        EventSystem.SetActive(true);

    }
    public void PopupResultGPopPop()
    {
        TapBlock.SetActive(true);
        EventSystem.SetActive(false);
        TapButton.SetActive(false);

        int GetG = StatGame.GetComponent<StatGame>().ResultGetG;
        int GetExp = StatGame.GetComponent<StatGame>().ResultGetExp;
        float GetSus = StatGame.GetComponent<StatGame>().ResultGetSus;

        //ポップアップ表示
        PopupResultG.SetActive(true);

        GetG = Mathf.Abs(GetG);
        string TextGetG = (GetG).ToString();
        string TextGetExp = GetComponent<LvDesignController>().StringGetExp(GetExp);
        string TextGetSus = (GetSus).ToString();
        if (GetG <= 0) { TextGetG = "<color='red'>" + TextGetG + "</color>"; }
        if (GetSus > 0) { SusLine.SetActive(true); }
        else { SusLine.SetActive(false); }

        PopupResultGTextG.text = TextGetG;
        PopupResultGTextExp.text = TextGetExp;
        PopupResultGTextSus.text = TextGetSus;

        TapBlock.SetActive(false);
        EventSystem.SetActive(true);
        //この直後、ゲームオーバー判定
    }

    public void LevelUp()
    {
        TapBlock.SetActive(true);
        EventSystem.SetActive(false);

        PopupResultG.SetActive(false);
        if (GetComponent<LvDesignController>().LvUpCondition())
        {
            StatGame.GetComponent<StatGame>().StatExp = 0;

            PopupLvUp.SetActive(true);
            PopupLvUpText.text = "レベルアップ！";
            //レベルアップ時のボーナス処理
            GetComponent<StatGameController>().LvUp(1);


            //レベルを渡すとSus減少を発動する
            GetComponent<LvDesignController>().LvUpSaveSus();

            int NowLv = StatGame.GetComponent<StatGame>().StatLv;
            GetComponent<CustomerController>().GetCustomerData(NowLv);

            TapBlock.SetActive(false);
            EventSystem.SetActive(true);

        }
        else {
            TapBlock.SetActive(false);
            EventSystem.SetActive(true);
            CheckGameOver();
        }

    }
    //ゲームオーバー判定
    public void CheckGameOver()
    {
        TapBlock.SetActive(true);
        EventSystem.SetActive(false);
        GetComponent<StatGameController>().DrawExp();//レベルアップしていたら、Expを０に戻した状態で再描画

        if (StatGame.GetComponent<StatGame>().StatSus > 100) {
            TapBlock.SetActive(false);
            EventSystem.SetActive(true);
            GameOver(); }
        else
        {
            TapBlock.SetActive(false);
            EventSystem.SetActive(true);
            Select(); }
    }

    //ゲームオーバー時
    public void GameOver()
    {
        PopupGameOver.SetActive(true);

        GetHighScore();
        StatPlayer.GetComponent<StatPlayer>().CheckHighScore();
        StatPlayer.GetComponent<StatPlayer>().WriteHighScore();

    }

    //ハイスコアの記録
    public void GetHighScore()
    {
        StatPlayer.GetComponent<StatPlayer>().TotalCountPlay++;

        StatPlayer.GetComponent<StatPlayer>().MaxKill=MaxKill;//殺人数
        StatPlayer.GetComponent<StatPlayer>().MaxCustomer=MaxCustomer;//さばいた客の数
        StatPlayer.GetComponent<StatPlayer>().MaxCustomerVictory=MaxCustomerVictory;//うち魅了した客の数
        StatPlayer.GetComponent<StatPlayer>().MaxGetG= StatGame.GetComponent<StatGame>().StatG;//かせいだ売上（=所持金）の総和

        StatPlayer.GetComponent<StatPlayer>().MaxG =StatGame.GetComponent<StatGame>().StatG;
        StatPlayer.GetComponent<StatPlayer>().MaxLv = StatGame.GetComponent<StatGame>().StatLv;
        StatPlayer.GetComponent<StatPlayer>().MaxDays = StatGame.GetComponent<StatGame>().StatDays;


    }

    //取得アイテムがないときにアイテムを自動的に１つ得る
    public void GetPickUp()
    {
        TapBlock.SetActive(true);
        EventSystem.SetActive(false);

        string[] PickUpItem = GetComponent<LvDesignController>().GetPickUpItem();

        if (StatGame.GetComponent<StatGame>().Item1[0] == "None") { StatGame.GetComponent<StatGame>().Item1 = PickUpItem; }
        else if (StatGame.GetComponent<StatGame>().Item2[0] == "None") { StatGame.GetComponent<StatGame>().Item2 = PickUpItem; }
        else if (StatGame.GetComponent<StatGame>().Item3[0] == "None") { StatGame.GetComponent<StatGame>().Item3 = PickUpItem; }
        else { StatGame.GetComponent<StatGame>().Item4 = PickUpItem; }

        PopupGetItem.SetActive(true);
        PopupGetText.text = "だれも こなかったので、\nそのへんで" + PickUpItem[0] + "\n を ひろいました";
        GetComponent<StatGameController>().DrawGetItem(PickUpItem);

        TapBlock.SetActive(false);
        EventSystem.SetActive(true);

    }

    //アイテムゲット選択画面へ
    public void Select()
    {
        TapBlock.SetActive(true);
        EventSystem.SetActive(false);

        //レベルアップから来た場合のレベルアップポップアップを消す
        PopupLvUp.SetActive(false);

        int Count = 0;
        int CustomerLength;
        //Winnerタグの客を破壊
        GameObject[] Winner = GameObject.FindGameObjectsWithTag("Winner");
        Count = 0;
        CustomerLength = Winner.GetLength(0);
        while (Count < CustomerLength)
        {
            Destroy(Winner[Count]);
            Count++;
        }
        //Loserタグの客をソート
        GameObject[] Loser = GameObject.FindGameObjectsWithTag("Loser");
        CustomerLength = Loser.GetLength(0);

        //Loserが独りもいなければアイテムゲットが発生しないようにする
        if (CustomerLength == 0) {
            GetPickUp();
        }
        else {
            //選択アイテム欄出す
            ButtonSelectItem.SetActive(true);
            Button4Items.SetActive(false);
            Button4Items1.GetComponent<Button>().interactable = false;
            Button4Items2.GetComponent<Button>().interactable = false;
            Button4Items3.GetComponent<Button>().interactable = false;
            Button4Items4.GetComponent<Button>().interactable = false;

            CustomerFieldBack.SetActive(false);
            CustomerFieldCollider.SetActive(false);

            GetComponent<StatGameController>().DrawItem4();
            GetComponent<StatGameController>().DrawItemSelectItem4();
            //TOPを取得
            GameObject[] LoserTop = GetComponent<Sorter>().LoserSort(Loser);
            //Top以外は破壊
            GameObject[] LoserNotTop = GameObject.FindGameObjectsWithTag("Loser");
            Count = 0;
            CustomerLength = LoserNotTop.GetLength(0);
            while (Count < CustomerLength)
            {
                Destroy(LoserNotTop[Count]);
                Count++;
            }

            //TOPを物理演算切って整列、それらの所持アイテムも整列
            string[] DropItem;
            string ItemName;
            string ItemImage;
            string ItemTag;
            int ItemPower;
            Color ItemCol;
            float ItemUpSus;

            Count = 0;
            string CountString;
            CustomerLength = LoserTop.GetLength(0);
            int PositionY=0;
            int PositionX=0;
            while (Count < CustomerLength)
            {
                PositionY = 125;
                PositionX = (150*Count)-220;
                LoserTop[Count].transform.position = new Vector3(PositionX, PositionY, 0);
                LoserTop[Count].GetComponent<Rigidbody2D>().constraints=RigidbodyConstraints2D.FreezePosition;
                LoserTop[Count].GetComponent<Button>().interactable = true;


                DropItem = LoserTop[Count].GetComponent<StatCustomer>().DropItem;
                ItemName = DropItem[0];
                ItemImage = DropItem[1];
                ItemPower = int.Parse(DropItem[2]);
                ItemUpSus = float.Parse(DropItem[4]);
                CountString = (Count).ToString();
                ItemTag = "Item"+CountString;
                ItemCol = LoserTop[Count].GetComponent<Image>().color;

                float CoreR = ItemCol.r;
                float CoreG = ItemCol.g;
                float CoreB = ItemCol.b;
                //アイテムの色揺れ幅

                float PlusR = Random.Range(50f / 255, -50f / 255);
                float PlusG = Random.Range(50f / 255, -50f / 255);
                float PlusB = Random.Range(50f / 255, -50f / 255);
                Color UseItemCol = new Color(CoreR + PlusR, CoreG + PlusG, CoreB + PlusB, 1f);


                GetComponent<ItemController>().MakeItem(ItemName, ItemImage,ItemPower,UseItemCol,ItemUpSus,PositionX,-90,ItemTag);

                Count++;
            }
            MessageDraw(" ２つえらんでＯＫ  （ わくタップでキャンセル ）");
            SelectStart();//選択ワクの初期化
            SelectButtonOK.GetComponent<Button>().interactable = false;
        }
        TapBlock.SetActive(false);
        EventSystem.SetActive(true);

    }

    //選択ワクの初期化
    public void SelectStart()
    {
        TapBlock.SetActive(true);
        EventSystem.SetActive(false);
        if (GameObject.FindGameObjectWithTag("Box1") != null) { Destroy(GameObject.FindGameObjectWithTag("Box1")); }
        if (GameObject.FindGameObjectWithTag("Box2") != null) { Destroy(GameObject.FindGameObjectWithTag("Box2")); }

        SelectItemImage1.GetComponent<Image>().sprite = null;
        SelectItemImage1.GetComponent<Image>().color = new Color(0, 0, 0, 1f); ;
        SelectItemName1.text = "";
        SelectItemPower1.text = "";

        SelectItemImage2.GetComponent<Image>().sprite = null;
        SelectItemImage2.GetComponent<Image>().color = new Color(0, 0, 0, 1f);
        SelectItemName2.text = "";
        SelectItemPower2.text = "";

        SelectItemImage1.GetComponent<StatItem>().Name = null;
        SelectItemImage1.GetComponent<StatItem>().Image = null;
        SelectItemImage1.GetComponent<StatItem>().Power = 0;
        SelectItemImage1.GetComponent<StatItem>().Col = new Color(0, 0, 0, 1f);
        SelectItemImage1.GetComponent<StatItem>().UpSus = 0;

        SelectItemImage2.GetComponent<StatItem>().Name = null;
        SelectItemImage2.GetComponent<StatItem>().Image = null;
        SelectItemImage2.GetComponent<StatItem>().Power = 0;
        SelectItemImage2.GetComponent<StatItem>().Col = new Color(0, 0, 0, 1f);
        SelectItemImage2.GetComponent<StatItem>().UpSus = 0;

        TapBlock.SetActive(false);
        EventSystem.SetActive(true);

    }



    //アイテムないし人がタップされたら選択状態にする
    public void SelectItem(string TagName)
    {
        TapBlock.SetActive(true);
        EventSystem.SetActive(false);
        if (GameObject.FindGameObjectWithTag("Box1") != null & GameObject.FindGameObjectWithTag("Box2") != null)
        {
            //枠が両方とも使われている場合は何も起こらない
        }
        else {
            GameObject SelectedItem = GameObject.FindGameObjectWithTag(TagName);

            string Name;
            string Image;
            int Power;
            string PowerString;
            Color Col;
            float UpSus;
            string UpSusString;

            GameObject UseBox = SelectItemImage1;
            //アイテムの場合

            //枠の生成
            GameObject SelectBox = (GameObject)Instantiate(
                       SelectBoxPrefab,
                       transform.position,
                       Quaternion.identity);
            SelectBox.transform.SetParent(SelectedItem.transform);


            if (TagName == "Item0" | TagName == "Item1" | TagName == "Item2" | TagName == "Item3")
            {
                Name = SelectedItem.GetComponent<StatItem>().Name;
                Image = SelectedItem.GetComponent<StatItem>().Image;
                Power = SelectedItem.GetComponent<StatItem>().Power;
                PowerString = (Power).ToString();
                Col = SelectedItem.GetComponent<StatItem>().Col;
                UpSus = SelectedItem.GetComponent<StatItem>().UpSus;

                string ImagePath = "Item/" + Image;
                Sprite SpriteImage = Resources.Load<Sprite>(ImagePath);
                if ((GameObject.FindGameObjectWithTag("Box1") == null & GameObject.FindGameObjectWithTag("Box2") != null) |
                    (GameObject.FindGameObjectWithTag("Box1") == null & GameObject.FindGameObjectWithTag("Box2") == null))
                {
                    UseBox = SelectItemImage1;
                    SelectItemImage1.GetComponent<Image>().sprite = SpriteImage;
                    SelectItemImage1.GetComponent<Image>().color = Col;
                    SelectItemName1.text = Name;
                    SelectItemPower1.text = PowerString;
                    SelectBox.tag = "Box1";
                }
                else
                {
                    UseBox = SelectItemImage2;
                    SelectItemImage2.GetComponent<Image>().sprite = SpriteImage;
                    SelectItemImage2.GetComponent<Image>().color = Col;
                    SelectItemName2.text = Name;
                    SelectItemPower2.text = PowerString;
                    SelectBox.tag = "Box2";
                }
                //アイテムの情報をＳＴＡＴに書き込み
                UseBox.GetComponent<StatItem>().Name = Name;
                UseBox.GetComponent<StatItem>().Image = Image;
                UseBox.GetComponent<StatItem>().Power = Power;
                UseBox.GetComponent<StatItem>().Col = Col;
                UseBox.GetComponent<StatItem>().UpSus = UpSus;

                //ワクの位置と大きさ
                SelectBox.transform.localPosition = new Vector3(0, 15, 0);
                SelectBox.GetComponent<RectTransform>().sizeDelta = new Vector2(140, 160);
                SelectBox.GetComponent<BoxCollider2D>().size = new Vector2(140, 160);

                UseBox.GetComponent<RectTransform>().sizeDelta = new Vector2(130, 65);

            }
            //人の場合
            else if (TagName == "Top0" | TagName == "Top1" | TagName == "Top2" | TagName == "Top3")
            {
                Name = SelectedItem.GetComponent<StatCustomer>().DropMeat[0];
                Image = SelectedItem.GetComponent<StatCustomer>().DropMeat[1];
                PowerString = SelectedItem.GetComponent<StatCustomer>().DropMeat[2];
                Power = int.Parse(PowerString);
                Col = SelectedItem.GetComponent<Image>().color;
                UpSusString = SelectedItem.GetComponent<StatCustomer>().DropMeat[4];
                UpSus = float.Parse(UpSusString);

                string ImagePath = "Customer/" + SelectedItem.GetComponent<StatCustomer>().Image;
                Sprite SpriteImage = Resources.Load<Sprite>(ImagePath);


                if ((GameObject.FindGameObjectWithTag("Box1") == null & GameObject.FindGameObjectWithTag("Box2") != null) |
                    (GameObject.FindGameObjectWithTag("Box1") == null & GameObject.FindGameObjectWithTag("Box2") == null))
                {
                    UseBox = SelectItemImage1;
                    SelectItemImage1.GetComponent<Image>().sprite = SpriteImage;
                    SelectItemImage1.GetComponent<Image>().color = Col;
                    SelectItemName1.text = SelectedItem.GetComponent<StatCustomer>().Name;
                    SelectItemPower1.text = "？";
                    SelectBox.tag = "Box1";
                }
                else
                {
                    UseBox = SelectItemImage2;
                    SelectItemImage2.GetComponent<Image>().sprite = SpriteImage;
                    SelectItemImage2.GetComponent<Image>().color = Col;
                    SelectItemName2.text = SelectedItem.GetComponent<StatCustomer>().Name;
                    SelectItemPower2.text = "？";
                    SelectBox.tag = "Box2";
                }

                //アイテムの情報をＳＴＡＴに書き込み
                UseBox.GetComponent<StatItem>().Name = Name;
                UseBox.GetComponent<StatItem>().Image = Image;
                UseBox.GetComponent<StatItem>().Power = Power;
                UseBox.GetComponent<StatItem>().Col = Col;
                UseBox.GetComponent<StatItem>().UpSus = UpSus;

                //ワクの位置と大きさ
                SelectBox.transform.localPosition = new Vector3(0, 0, 0);
                SelectBox.GetComponent<RectTransform>().sizeDelta = new Vector2(140, 200);
                SelectBox.GetComponent<BoxCollider2D>().size = new Vector2(140, 200);
                UseBox.GetComponent<RectTransform>().sizeDelta = new Vector2(125, 175);

            }
            else { Debug.Log("アイテムでも人でもないものが選択されている"); }
            //枠が両方埋まっていたらＯＫボタンを出す
            if (GameObject.FindGameObjectWithTag("Box1") != null & GameObject.FindGameObjectWithTag("Box2") != null)
            {
                SelectButtonOK.GetComponent<Button>().interactable = true;
            }

        }
        TapBlock.SetActive(false);
        EventSystem.SetActive(true);
    }

    //既に選択されたワクがタップされたら選択を解除
    public void UnSelectItem(string TagName)
    {
        TapBlock.SetActive(true);
        EventSystem.SetActive(false);

        //OKボタンを切る
        SelectButtonOK.GetComponent<Button>().interactable = false;
        GameObject UseBox = SelectItemImage1;

        if (TagName == "Box1")
        {
            UseBox = SelectItemImage1;
            Destroy(GameObject.FindGameObjectWithTag("Box1"));
            SelectItemImage1.GetComponent<Image>().sprite = null;
            SelectItemImage1.GetComponent<Image>().color = new Color(0, 0, 0, 1f); ;
            SelectItemName1.text = " ";
            SelectItemPower1.text = " ";

        }
        else
        {
            UseBox = SelectItemImage2;
            Destroy(GameObject.FindGameObjectWithTag("Box2"));
            SelectItemImage2.GetComponent<Image>().sprite = null;
            SelectItemImage2.GetComponent<Image>().color = new Color(0, 0, 0, 1f);
            SelectItemName2.text = " ";
            SelectItemPower2.text = " ";
        }
        UseBox.GetComponent<StatItem>().Name = null;
        UseBox.GetComponent<StatItem>().Image = null;
        UseBox.GetComponent<StatItem>().Power = 0;
        UseBox.GetComponent<StatItem>().Col = new Color(0, 0, 0, 1f);
        UseBox.GetComponent<StatItem>().UpSus = 0;
        //        UseBox.tag = "Untagged";

        TapBlock.SetActive(false);
        EventSystem.SetActive(true);

    }
    //選択確定→捨てる画面に遷移
    public void SelectOK()
    {
        TapBlock.SetActive(true);
        EventSystem.SetActive(false);


        if(SelectItemImage1.tag=="Top0"| SelectItemImage1.tag == "Top1"|SelectItemImage1.tag=="Top2"|SelectItemImage1.tag=="Top3"){
        MaxKill++;//殺人数    
    }
        if (SelectItemImage2.tag == "Top0" | SelectItemImage1.tag == "Top1" | SelectItemImage1.tag == "Top2" | SelectItemImage1.tag == "Top3")
        {
            MaxKill++;//殺人数    
        }


        //選択されていたアイテムを取得
        string PowerString;
        string UpSusString;
        string ColorString;
        string[] GetItem1 = new string[5];
        string[] GetItem2 = new string[5];
        Color Col;

        GetItem1[0]=SelectItemImage1.GetComponent<StatItem>().Name;
        GetItem1[1] = SelectItemImage1.GetComponent<StatItem>().Image;
        PowerString=(SelectItemImage1.GetComponent<StatItem>().Power).ToString();
        GetItem1[2] = PowerString;
        UpSusString = (SelectItemImage1.GetComponent<StatItem>().UpSus).ToString();
        GetItem1[4] = UpSusString;
        Col = SelectItemImage1.GetComponent<StatItem>().Col;
        ColorString = GetComponent<ColorGetter>().ToColorString(Col);
        GetItem1[3] = "#" + ColorString;

        GetItem2[0] = SelectItemImage2.GetComponent<StatItem>().Name;
        GetItem2[1] = SelectItemImage2.GetComponent<StatItem>().Image;
        PowerString = (SelectItemImage2.GetComponent<StatItem>().Power).ToString();
        GetItem2[2] = PowerString;
        UpSusString = (SelectItemImage2.GetComponent<StatItem>().UpSus).ToString();
        GetItem2[4] = UpSusString;
        Col = SelectItemImage2.GetComponent<StatItem>().Col;
        ColorString = GetComponent<ColorGetter>().ToColorString(Col);
        GetItem2[3] = "#"+ColorString;

        StatGame.GetComponent<StatGame>().Item5 = GetItem1;
        StatGame.GetComponent<StatGame>().Item6 = GetItem2;
        SelectStart();//選択ワクの初期化
        Destroy(GameObject.FindGameObjectWithTag("Top0"));
        Destroy(GameObject.FindGameObjectWithTag("Top1"));
        Destroy(GameObject.FindGameObjectWithTag("Top2"));
        Destroy(GameObject.FindGameObjectWithTag("Top3"));
        Destroy(GameObject.FindGameObjectWithTag("Item0"));
        Destroy(GameObject.FindGameObjectWithTag("Item1"));
        Destroy(GameObject.FindGameObjectWithTag("Item2"));
        Destroy(GameObject.FindGameObjectWithTag("Item3"));


        //表示パーツ整理
        SelectButtonOK.GetComponent<Button>().interactable = false;
        ButtonSelectItem.SetActive(false);
        Button6Items.SetActive(true);
        Button4Items.SetActive(false);


        if (StatGame.GetComponent<StatGame>().Item1[0] == "None") { Button6Items1.GetComponent<Button>().interactable = false; }
        else { Button6Items1.GetComponent<Button>().interactable = true; }
        if (StatGame.GetComponent<StatGame>().Item2[0] == "None") { Button6Items2.GetComponent<Button>().interactable = false; }
        else { Button6Items2.GetComponent<Button>().interactable = true; }
        if (StatGame.GetComponent<StatGame>().Item3[0] == "None") { Button6Items3.GetComponent<Button>().interactable = false; }
        else { Button6Items3.GetComponent<Button>().interactable = true; }
        if (StatGame.GetComponent<StatGame>().Item4[0] == "None") { Button6Items4.GetComponent<Button>().interactable = false; }
        else { Button6Items4.GetComponent<Button>().interactable = true; }
        if (StatGame.GetComponent<StatGame>().Item5[0] == "None") { Button6Items5.GetComponent<Button>().interactable = false; }
        else { Button6Items5.GetComponent<Button>().interactable = true; }
        if (StatGame.GetComponent<StatGame>().Item6[0] == "None") { Button6Items6.GetComponent<Button>().interactable = false; }
        else { Button6Items6.GetComponent<Button>().interactable = true; }


        MessageDraw("どれ を すてますか？");
        GetComponent<StatGameController>().DrawItem6();

        TapBlock.SetActive(false);
        EventSystem.SetActive(true);

    }
    //捨てる確認画面
    public void Dispose(int ItemNum)
    {
        TapBlock.SetActive(true);
        EventSystem.SetActive(false);

        string[] CheckItem = new string[5];
        if (ItemNum == 1) { CheckItem = StatGame.GetComponent<StatGame>().Item1; }
        else if (ItemNum == 2) { CheckItem = StatGame.GetComponent<StatGame>().Item2; }
        else if (ItemNum == 3) { CheckItem = StatGame.GetComponent<StatGame>().Item3; }
        else if (ItemNum == 4) { CheckItem = StatGame.GetComponent<StatGame>().Item4; }
        else if (ItemNum == 5) { CheckItem = StatGame.GetComponent<StatGame>().Item5; }
        else { CheckItem = StatGame.GetComponent<StatGame>().Item6; }

        if (CheckItem[0] == "None") { }
        else {
            PopupDisposeItem.SetActive(true);
            PopupDisposeText.text = CheckItem[0] + "\n を すてます。";
            GetComponent<StatGameController>().DrawDisposeItem(CheckItem);
            StatGame.GetComponent<StatGame>().DisposeItemID = ItemNum;
        }
        TapBlock.SetActive(false);
        EventSystem.SetActive(true);
    }
    //捨てる確認画面キャンセル
    public void DisposeCancel()
    {
        PopupDisposeItem.SetActive(false);
        StatGame.GetComponent<StatGame>().DisposeItemID = 0;
    }
    //捨てる確認でＯＫ
    public void DisposeOK()
    {
        TapBlock.SetActive(true);
        EventSystem.SetActive(false);
        PopupDisposeItem.SetActive(false);

        int ItemNum = StatGame.GetComponent<StatGame>().DisposeItemID;
        if (ItemNum == 1) { StatGame.GetComponent<StatGame>().Item1 =new string[]{ "None", "None", "None", "None", "None" }; }
        else if (ItemNum == 2) { StatGame.GetComponent<StatGame>().Item2 = new string[] { "None", "None", "None", "None", "None" }; }
        else if (ItemNum == 3) { StatGame.GetComponent<StatGame>().Item3 = new string[] { "None", "None", "None", "None", "None" }; }
        else if (ItemNum == 4) { StatGame.GetComponent<StatGame>().Item4 = new string[] { "None", "None", "None", "None", "None" }; }
        else if (ItemNum == 5) { StatGame.GetComponent<StatGame>().Item5 = new string[] { "None", "None", "None", "None", "None" }; }
        else if (ItemNum == 6) { StatGame.GetComponent<StatGame>().Item6 = new string[] { "None", "None", "None", "None", "None" }; }
        else { Debug.Log("1~6以外のアイテムＩＤが入っています"); }


        if (StatGame.GetComponent<StatGame>().Item5[0] != "None") {
                if (StatGame.GetComponent<StatGame>().Item1[0]=="None")
            {
                StatGame.GetComponent<StatGame>().Item1= StatGame.GetComponent<StatGame>().Item5;
            }
            else if (StatGame.GetComponent<StatGame>().Item2[0] == "None")
            {
                StatGame.GetComponent<StatGame>().Item2 = StatGame.GetComponent<StatGame>().Item5;
            }
            else if (StatGame.GetComponent<StatGame>().Item3[0] == "None")
            {
                StatGame.GetComponent<StatGame>().Item3 = StatGame.GetComponent<StatGame>().Item5;
            }
            else
            {
                StatGame.GetComponent<StatGame>().Item4 = StatGame.GetComponent<StatGame>().Item5;
            }

        }

        if (StatGame.GetComponent<StatGame>().Item6[0] != "None")
        {
            if (StatGame.GetComponent<StatGame>().Item1[0] == "None")
            {
                StatGame.GetComponent<StatGame>().Item1 = StatGame.GetComponent<StatGame>().Item6;
            }
            else if (StatGame.GetComponent<StatGame>().Item2[0] == "None")
            {
                StatGame.GetComponent<StatGame>().Item2 = StatGame.GetComponent<StatGame>().Item6;
            }
            else if (StatGame.GetComponent<StatGame>().Item3[0] == "None")
            {
                StatGame.GetComponent<StatGame>().Item3 = StatGame.GetComponent<StatGame>().Item6;
            }
            else
            {
                StatGame.GetComponent<StatGame>().Item4 = StatGame.GetComponent<StatGame>().Item6;
            }
        }


        Button6Items.SetActive(false);

        TapBlock.SetActive(false);
        EventSystem.SetActive(true);

        CustomerEnd();

    }


    //その周の終わりの処理→一時保存画面
    public void CustomerEnd()
    {
        TapBlock.SetActive(true);
        EventSystem.SetActive(false);

        //客破壊
        CustomerDestroy();
        //客の生成
        GetComponent<LvDesignController>().MakeCustomerNormal();

        CustomerStart1();
        SelectSave();

        TapBlock.SetActive(false);
        EventSystem.SetActive(true);
    }



    //メニュー画面への遷移
    public void GoMenu()
    {
        Menu.SetActive(true);
        HighScore.SetActive(false);
        AdsDelete.SetActive(false);
        Game.SetActive(false);
    }

    //メッセージ表示
    public void MessageDraw(string Text)
    {
        MessageText.text = Text;
    }

    // Use this for initialization
    void Start()
    {
        //ナビゲーションバーを透明に
        /*
        ApplicationChrome.navigationBarState = ApplicationChrome.States.TranslucentOverContent;
        ApplicationChrome.statusBarState = ApplicationChrome.States.Hidden;
        */
        //解像度設定
        float screenRate = (float)1280 / Screen.height;
        if (screenRate > 1) screenRate = 1;
        int width = (int)(Screen.width * screenRate);
        int height = (int)(Screen.height * screenRate);
        Screen.SetResolution(width, height, true, 60);

        //回転固定
        // 縦
        Screen.autorotateToPortrait = false;
        // 左
        Screen.autorotateToLandscapeLeft = false;
        // 右
        Screen.autorotateToLandscapeRight = false;
        // 上下反転
        Screen.autorotateToPortraitUpsideDown = false;
        GoMenu();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

