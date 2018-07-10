using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//ゲームの進行を制御する

public class GameController : MonoBehaviour
{
    public int FPS = 60;//FPS設定

    public int ITweenCount = 0;
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
    public GameObject Status;
    public GameObject StoryAll;
    public GameObject TutorialAll;

    //ボタン類
    public GameObject ButtonSave;
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

    public GameObject Buns1;
    public GameObject Buns2;
    public GameObject ParticleFeed;

    public GameObject PopupHand;

    public GameObject Hand;
    public GameObject HandButton;

    public GameObject ButtonSelectItem;
    public GameObject SelectItem1;
    public GameObject SelectItem2;

    public GameObject SelectItemImage1Base;
    public GameObject SelectItemImage1;
    public GameObject SelectItemName1;
    public GameObject SelectItemPower1;
    public GameObject SelectItemSus1;

    public GameObject SelectItemImage2Base;
    public GameObject SelectItemImage2;
    public GameObject SelectItemName2;
    public GameObject SelectItemPower2;
    public GameObject SelectItemSus2;
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
    public GameObject PopupSaveSus;
    public Text PopupSaveSusName1;
    public Text PopupSaveSusName2;
    public Text PopupSaveSusValue;
    public GameObject SaveSusOKButton;

    public GameObject PopupSelectAction;
    public GameObject PopupAction;
    public GameObject ActHito1;
    public GameObject ActHito2;
    public GameObject ActMessage;
    public GameObject ActPlacePict;
    public Text ActPlaceText;

    public Text ActMessageText;
    public GameObject ActButtonPolice;
    public GameObject ActButtonChurch;
    public GameObject ActButtonHome;
    public GameObject ActButtonMarket;

    public GameObject ButtonPolice;
    public GameObject ButtonChurch;
    public GameObject ButtonHome;
    public GameObject ButtonMarket;

    public Text PoliceCost1;
    public Text PoliceReturn1;
    public Text PoliceCost2;
    public Text PoliceReturn2;

    public Text ChurchReturn1;
    public Text ChurchReturn2;

    public Text HomeReturn1;
    public Text HomeReturn2;

    public GameObject ActionEndOK;
    public GameObject ActionDispose;

    public GameObject PopupDisposeItem;
    public Text PopupDisposeText;
    public GameObject PopupGetItem;
    public Text PopupGetText;
    public GameObject PopupLvUp;
    public GameObject LvUpOKButton;

    public Text PopupLvUpText;
    public Text PopupLvUpSusText;
    public GameObject PopupGameOver;
    public Text PopupGameOverText;
    public GameObject ButtonActionBack;

    //メッセージ欄
    public GameObject Message;
    public Text MessageText;

    //平日休日の切り替え基準
    //7で割った余り


    //プレハブ
    public GameObject HeartPrefab;
    public GameObject GPrefab;
    public GameObject ColorCheckPrefab;
    public GameObject SelectBoxPrefab;
    public GameObject HPbarPrefab;

    //イベントシステムの取得（処理中に切る場合がある）
    public GameObject EventSystem;
    //タップ切るための板
    public GameObject TapBlock;
    public GameObject FieldBlock;

    //キルアニメの間をボタンクリックまたいでも保持するためのメモ変数
    float MemoTime6;
    float MemoTime7;
    float MemoTill5Time;
    float MemoTillAllTime;

    //SUSの色
    public Color SusGreen;
    //Expの色
    public Color ExpBlue;
    //Gの色
    public Color GYellow;

    //ゲームスタート前オープニング
    public void GameOpening() {
        //ゲーム画面への遷移
        Menu.SetActive(false);
        HighScore.SetActive(false);
        AdsDelete.SetActive(false);
        Game.SetActive(true);
        Status.SetActive(false);
        StoryAll.SetActive(false);
        TutorialAll.SetActive(false);

        if (StatPlayer.GetComponent<StatPlayer>().FlagStoryOP == 0)//オープニング見ていなければ表示
        {
            StatPlayer.GetComponent<StatPlayer>().FlagStoryOP = 1;
            StatPlayer.GetComponent<StatPlayer>().SaveFlag();

            GetComponent<StoryController>().StartStory("Opening");
        }

        else
        {
            GameStart();
        }
    }

    //ゲームスタート
    public void GameStart()
    {
        //ゲーム画面への遷移
        Status.SetActive(true);
        StoryAll.SetActive(false);
        TutorialAll.SetActive(false);


        TapBlock.SetActive(true);
        EventSystem.SetActive(false);

        //BGM
        GetComponent<SoundController>().PlayStoreBgm("StoreBgm1");


        //ボタン初期化
        ButtonSave.SetActive(false);
        Button4Items.SetActive(false);
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
        PopupSaveSus.SetActive(false);
        PopupAction.SetActive(false);
        PopupSelectAction.SetActive(false);

        PopupHand.SetActive(true);
        Hand.SetActive(false);
        HandButton.SetActive(false);

        Buns1.SetActive(false);
        Buns2.SetActive(false);

        Button6Items5.SetActive(false);
        Button6Items6.SetActive(false);

        FieldBlock.SetActive(false);

        CustomerFieldBack.SetActive(true);
        CustomerFieldCollider.SetActive(true);

        Button4Items1.GetComponent<Button>().interactable = true;
        Button4Items2.GetComponent<Button>().interactable = true;
        Button4Items3.GetComponent<Button>().interactable = true;
        Button4Items4.GetComponent<Button>().interactable = true;


        //所持アイテムのリセット
        StatGame.GetComponent<StatGame>().Item1 = new string[] { "", "None", "None", "None", "None" };
        StatGame.GetComponent<StatGame>().Item2 = new string[] { "", "None", "None", "None", "None" };
        StatGame.GetComponent<StatGame>().Item3 = new string[] { "", "None", "None", "None", "None" };
        StatGame.GetComponent<StatGame>().Item4 = new string[] { "", "None", "None", "None", "None" };
        //所持扱いにならない、取得処理時に使う枠
        StatGame.GetComponent<StatGame>().Item5 = new string[] { "None", "None", "None", "None", "None" };
        StatGame.GetComponent<StatGame>().Item6 = new string[] { "None", "None", "None", "None", "None" };

        //休日行動のステ
        StatGame.GetComponent<StatGame>().MarketItem1 = new string[] { "None", "None", "None", "None", "None" };
        StatGame.GetComponent<StatGame>().MarketItem2 = new string[] { "None", "None", "None", "None", "None" };
        StatGame.GetComponent<StatGame>().MarketCost1 = 0;
        StatGame.GetComponent<StatGame>().MarketCost2 = 0;

        StatGame.GetComponent<StatGame>().PoliceCost1 = 0;
        StatGame.GetComponent<StatGame>().PoliceReturn1 = 0;
        StatGame.GetComponent<StatGame>().PoliceCost2 = 0;
        StatGame.GetComponent<StatGame>().PoliceReturn2 = 0;
        StatGame.GetComponent<StatGame>().ChurchReturn1 = 0;
        StatGame.GetComponent<StatGame>().ChurchReturn2 = 0;
        StatGame.GetComponent<StatGame>().HomeReturn1 = 0;
        StatGame.GetComponent<StatGame>().HomeReturn2 = 0;

        //Ｇ，カルマ取得修正率
        StatGame.GetComponent<StatGame>().ModifyG = 0;
        StatGame.GetComponent<StatGame>().ModifySus = 0;


        //Feed記憶領域の初期化
        StatGame.GetComponent<StatGame>().UseItemNum = 0;
        StatGame.GetComponent<StatGame>().UseItemData = new string[] { "None", "None", "None", "None", "None" };

        //ロード前の描画リセット
        GetComponent<StatGameController>().DrawSus();
        GetComponent<StatGameController>().DrawG();
        GetComponent<StatGameController>().DrawLv();
        GetComponent<StatGameController>().DrawDays();
        GetComponent<StatGameController>().DrawExp();
        GetComponent<StatGameController>().DrawItem4();
        GetComponent<StatGameController>().DrawModify();
        GetComponent<StatGameController>().DrawYoubi();

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


        //レベルデザイン情報の読み込み
        GetComponent<LvDesignController>().GetLvDesignData();

        //客データの読み込み
        GetComponent<CustomerController>().GetCustomerData(StatGame.GetComponent<StatGame>().StatLv);

        GetComponent<StatGameController>().DrawSus();
        GetComponent<StatGameController>().DrawG();
        GetComponent<StatGameController>().DrawLv();
        GetComponent<StatGameController>().DrawDays();
        GetComponent<StatGameController>().DrawExp();

        RoundStart(1);




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

        RoundStart(0);

        TapBlock.SetActive(false);
        EventSystem.SetActive(true);
    }

    //今いる客をすべて破壊
    public void CustomerDestroy()
    {
        TapBlock.SetActive(true);
        EventSystem.SetActive(false);
        iTween.tweens.Clear();

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
    public void CustomerStart1()
    {
        TapBlock.SetActive(true);
        EventSystem.SetActive(false);

        FieldBlock.SetActive(true);



        //表示パネルの初期化
        //客表示せず、操作できない状態
        ButtonSave.SetActive(false);

        Button4Items.SetActive(false);
        Button6Items.SetActive(false);
        ButtonSelectItem.SetActive(false);
        PopupResultG.SetActive(false);
        PopupDisposeItem.SetActive(false);
        Message.SetActive(false);
        CustomerField.SetActive(true);

        Buns1.SetActive(false);
        Buns2.SetActive(false);

        PopupGetItem.SetActive(false);
        PopupLvUp.SetActive(false);
        PopupGameOver.SetActive(false);
        ButtonGoResult.SetActive(false);
        TapButton.SetActive(false);
        PopupSave.SetActive(false);
        PopupLoad.SetActive(false);
        PopupSaveSus.SetActive(false);
        PopupAction.SetActive(false);
        PopupSelectAction.SetActive(false);

        Button6Items5.SetActive(false);
        Button6Items6.SetActive(false);

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

        //        PopupSave.SetActive(true);
        //セーブ選択画面を表示

        //セーブ画面は経由せず、自動セーブしてＴＯＰに戻る
        SaveEnd();
    }

    //セーブせず続ける
    //ウインドウ閉じるだけ
    public void NotSaveContinue()
    {
        PopupSave.SetActive(false);
    }

    public void SaveEnd()
    {
        //BGM止める
        GetComponent<SoundController>().StopStoreBgm();

        //セーブ
        GetHighScore();
        StatPlayer.GetComponent<StatPlayer>().Save();
        //客破壊はGoMenu内にあり
        GoMenu();
    }


    //生成した客を可視化し、アイテム等押せるようにする
    public void CustomerStart2()
    {
        TapBlock.SetActive(true);
        EventSystem.SetActive(false);
        //PopupSave.SetActive(false);
        ButtonSave.SetActive(true);


        //ゲーム開始演出
        iTween.MoveTo(CustomerFieldBack, iTween.Hash("position", new Vector3(0f, 300f, 0f), "time", 1.0f, "easeType", iTween.EaseType.linear));

        //SE
        GetComponent<SoundController>().PlaySE("DoorOpen");

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
        Message.SetActive(true);
        CustomerField.SetActive(true);

        CustomerFieldBack.SetActive(true);
        CustomerFieldCollider.SetActive(true);


        Button4Items1.GetComponent<Button>().interactable = true;
        Button4Items2.GetComponent<Button>().interactable = true;
        Button4Items3.GetComponent<Button>().interactable = true;
        Button4Items4.GetComponent<Button>().interactable = true;

        //アイテムパネルの描画
        GetComponent<StatGameController>().DrawItem4();

        //メッセージ表示
        MessageDraw("どれを つかいますか？");

        //チュートリアル　初回Feed
        if (StatPlayer.GetComponent<StatPlayer>().FlagTutorialFirstFeed == 0)//以前に見ていなければ表示
        {
            //ボタン押せなくする
            ButtonSave.GetComponent<Button>().interactable = false;
            Button4Items1.GetComponent<Button>().interactable = false;
            Button4Items2.GetComponent<Button>().interactable = false;
            Button4Items3.GetComponent<Button>().interactable = false;
            Button4Items4.GetComponent<Button>().interactable = false;
            GetComponent<TutorialController>().StartTutorial("FirstFeed");
        }

        //チュートリアル　二回目Feed
        else if (StatPlayer.GetComponent<StatPlayer>().FlagTutorialFirstFeed == 1&
            StatPlayer.GetComponent<StatPlayer>().FlagTutorialSecondFeed == 0)//１を見て２がまだなら表示
        {
            ButtonSave.GetComponent<Button>().interactable = false;
            Button4Items1.GetComponent<Button>().interactable = false;
            Button4Items2.GetComponent<Button>().interactable = false;
            Button4Items3.GetComponent<Button>().interactable = false;
            Button4Items4.GetComponent<Button>().interactable = false;
            GetComponent<TutorialController>().StartTutorial("SecondFeed");
        }

        else if (StatPlayer.GetComponent<StatPlayer>().FlagTutorialFirstFeed == 1 &
            StatPlayer.GetComponent<StatPlayer>().FlagTutorialSecondFeed == 1 & 
            StatPlayer.GetComponent<StatPlayer>().FlagTutorialFirstRare == 0&
            StatGame.GetComponent<StatGame>().FlagGlowCustomer==1)
        {
            ButtonSave.GetComponent<Button>().interactable = false;
            Button4Items1.GetComponent<Button>().interactable = false;
            Button4Items2.GetComponent<Button>().interactable = false;
            Button4Items3.GetComponent<Button>().interactable = false;
            Button4Items4.GetComponent<Button>().interactable = false;
            GetComponent<TutorialController>().StartTutorial("FirstRare");

        }

        TapBlock.SetActive(false);
        EventSystem.SetActive(true);
    }



    //食材選択　→　効果判定　→　Gリザルト表示
    public void Feed(int ItemNum)
    {
        TapBlock.SetActive(true);
        EventSystem.SetActive(false);

//        GetComponent<SoundController>().BgmFlag2 = 1;//bgmの切り替え例文

        ButtonSave.SetActive(false);
        MessageDraw("");
        //Item4ボタン押せなくする
        Button4Items1.GetComponent<Button>().interactable = false;
        Button4Items2.GetComponent<Button>().interactable = false;
        Button4Items3.GetComponent<Button>().interactable = false;
        Button4Items4.GetComponent<Button>().interactable = false;


        //どの所持アイテムが押されたか判定、そのアイテムは所持アイテムから消す
        //押されたアイテム以外の欄を消す
        string[] UseItem = new string[4];
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

        //記憶領域に記録
        StatGame.GetComponent<StatGame>().UseItemNum = ItemNum;
        StatGame.GetComponent<StatGame>().UseItemData = UseItem;

        GoAttack();

        TapBlock.SetActive(false);
        EventSystem.SetActive(true);
    }

    //フェードアウトアニメーションテキスト
    private IEnumerator TextFadeOutCoroutine(GameObject ChangeObject, float Time)
    {
        int Count = 0;
        Color NowColor;
        while (Count <= FPS * Time)
        {
            NowColor = ChangeObject.GetComponent<Text>().color;
            NowColor.a -= 1.0f / (FPS * Time);
            ChangeObject.GetComponent<Text>().color = NowColor;
            yield return new WaitForSeconds(Time / FPS);//遅延

            Count++;
        }
        ChangeObject.GetComponent<Text>().color = new Color(0, 0, 0, 0);

        yield return null;
    }


    //フェードアウトアニメーション画像
    private IEnumerator FadeOutCoroutine(GameObject ChangeObject, float Time)
    {
        int Count = 0;
        Color NowColor;
        while (Count <= FPS * Time)
        {
            NowColor = ChangeObject.GetComponent<Image>().color;
            NowColor.a -= 1.0f / (FPS * Time);
            ChangeObject.GetComponent<Image>().color = NowColor;

            yield return new WaitForSeconds(Time / FPS);//遅延
            Count++;
        }
        ChangeObject.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        yield return null;
    }
    //色を変えるアニメーションテキスト
    private IEnumerator TextColorChangeCoroutine(GameObject ChangeObject, Color GoColor, float Time)
    {
        int Count = 0;
        Color MotoColor = ChangeObject.GetComponent<Text>().color;
        Color NowColor;
        while (Count <= FPS * Time)
        {
            NowColor = ChangeObject.GetComponent<Text>().color;
            NowColor.r += (GoColor.r - MotoColor.r) / (FPS * Time);
            NowColor.g += (GoColor.g - MotoColor.g) / (FPS * Time);
            NowColor.b += (GoColor.b - MotoColor.b) / (FPS * Time);
            NowColor.a += (GoColor.a - MotoColor.a) / (FPS * Time);
            ChangeObject.GetComponent<Text>().color = NowColor;


            yield return new WaitForSeconds(Time / FPS);//遅延
            Count++;
        }
        ChangeObject.GetComponent<Text>().color = GoColor;
        yield return null;
    }
    //色を変えるアニメーション
    private IEnumerator ColorChangeCoroutine(GameObject ChangeObject, Color GoColor, float Time)
    {
        int Count = 0;
        Color MotoColor = ChangeObject.GetComponent<Image>().color;
        Color NowColor;
        while (Count <= FPS * Time)
        {
            NowColor = ChangeObject.GetComponent<Image>().color;
            NowColor.r += (GoColor.r - MotoColor.r) / (FPS * Time);
            NowColor.g += (GoColor.g - MotoColor.g) / (FPS * Time);
            NowColor.b += (GoColor.b - MotoColor.b) / (FPS * Time);
            NowColor.a += (GoColor.a - MotoColor.a) / (FPS * Time);
            ChangeObject.GetComponent<Image>().color = NowColor;

            yield return new WaitForSeconds(Time / FPS);//遅延
            Count++;
        }
        ChangeObject.GetComponent<Image>().color = GoColor;
        yield return null;
    }

    //XYで大きさを変えるアニメーション
    private IEnumerator XYChangeCoroutine(GameObject ChangeObject, float GoX, float GoY, float Time)
    {
        int Count = 0;
        Vector2 NowSize;
        float MotoSizeX = ChangeObject.GetComponent<RectTransform>().sizeDelta.x;
        float MotoSizeY = ChangeObject.GetComponent<RectTransform>().sizeDelta.y;
        while (Count <= FPS * Time)
        {

            NowSize = ChangeObject.GetComponent<RectTransform>().sizeDelta;
            NowSize.x += (GoX - MotoSizeX) / (FPS * Time);
            NowSize.y += (GoY - MotoSizeY) / (FPS * Time);
            ChangeObject.GetComponent<RectTransform>().sizeDelta = NowSize;

            yield return new WaitForSeconds(Time / FPS);//遅延
            Count++;
        }
        ChangeObject.GetComponent<RectTransform>().sizeDelta = new Vector2(GoX, GoY);

        yield return null;
    }
    //Feed演出
    public void GoAttack()
    {


        StartCoroutine("GoAttackCoroutine");

    }

    private IEnumerator GoAttackCoroutine()
    {
        TapBlock.SetActive(true);
        EventSystem.SetActive(false);

        int ItemNum = StatGame.GetComponent<StatGame>().UseItemNum;
        string[] UseItem = StatGame.GetComponent<StatGame>().UseItemData;


        float Time1 = 0.6f;//ワクが動く時間
        float Time2 = 0.3f;//具の色が変わる時間
        float Time4 = 0;//間の時間
        float Time5 = 0.8f;//バンズが挟む時間
        float Time6 = 0.8f;//間の時間
        float Time7 = 0.4f;//効果が広がっていく時間

        string UseItemColor = UseItem[3];
        Color UseColor = GetComponent<ColorGetter>().ToColor(UseItemColor);
        Buns1.SetActive(true);
        Buns2.SetActive(true);

        //押された枠以外をよせる
        GameObject UseWaku = Button4Items1;

        if (ItemNum == 1)
        {
            UseWaku = Button4Items1;
            iTween.MoveTo(Button4Items2, iTween.Hash("position", new Vector3(177f, -750f, 0f), "time", Time1, "easeType", iTween.EaseType.linear));
            iTween.MoveTo(Button4Items3, iTween.Hash("position", new Vector3(-177f, -750f, 0f), "time", Time1, "easeType", iTween.EaseType.linear));
            iTween.MoveTo(Button4Items4, iTween.Hash("position", new Vector3(177f, -750f, 0f), "time", Time1, "easeType", iTween.EaseType.linear));

        }
        else if (ItemNum == 2)
        {
            UseWaku = Button4Items2;
            iTween.MoveTo(Button4Items1, iTween.Hash("position", new Vector3(-177f, -750f, 0f), "time", Time1, "easeType", iTween.EaseType.linear));
            iTween.MoveTo(Button4Items3, iTween.Hash("position", new Vector3(-177f, -750f, 0f), "time", Time1, "easeType", iTween.EaseType.linear));
            iTween.MoveTo(Button4Items4, iTween.Hash("position", new Vector3(177f, -750f, 0f), "time", Time1, "easeType", iTween.EaseType.linear));

        }
        else if (ItemNum == 3)
        {
            UseWaku = Button4Items3;
            iTween.MoveTo(Button4Items1, iTween.Hash("position", new Vector3(-177f, -750f, 0f), "time", Time1, "easeType", iTween.EaseType.linear));
            iTween.MoveTo(Button4Items2, iTween.Hash("position", new Vector3(177f, -750f, 0f), "time", Time1, "easeType", iTween.EaseType.linear));
            iTween.MoveTo(Button4Items4, iTween.Hash("position", new Vector3(177f, -750f, 0f), "time", Time1, "easeType", iTween.EaseType.linear));

        }
        else if (ItemNum == 4)
        {
            UseWaku = Button4Items4;
            iTween.MoveTo(Button4Items1, iTween.Hash("position", new Vector3(-177f, -750f, 0f), "time", Time1, "easeType", iTween.EaseType.linear));
            iTween.MoveTo(Button4Items2, iTween.Hash("position", new Vector3(177f, -750f, 0f), "time", Time1, "easeType", iTween.EaseType.linear));
            iTween.MoveTo(Button4Items3, iTween.Hash("position", new Vector3(-177f, -750f, 0f), "time", Time1, "easeType", iTween.EaseType.linear));

        }
        else {
            Debug.Log("１～４以外のアイテム番号が送られています");
        }

        //ワクが挟まれる位置へ
        iTween.MoveTo(UseWaku, iTween.Hash("position", new Vector3(0, -405f, 0f), "time", Time1, "easeType", iTween.EaseType.linear));

        //バンズ現れる
        iTween.MoveTo(Buns1, iTween.Hash("position", new Vector3(0, -304f, 0f), "time", Time1, "easeType", iTween.EaseType.linear));
        iTween.MoveTo(Buns2, iTween.Hash("position", new Vector3(0, -509f, 0f), "time", Time1, "easeType", iTween.EaseType.linear));

        string ImagePath = "Item/None";
        Sprite SpriteImage = Resources.Load<Sprite>(ImagePath);

        //ワク縮む

        float GoX = 35 * 5;
        float GoY = 35;
        Color GoColor = UseColor;
        GameObject Mask = UseWaku.transform.Find("Mask").gameObject;
        GameObject AllColor = UseWaku.transform.Find("Mask/AllColor").gameObject;

        UseWaku.transform.Find("Mask/Power").GetComponent<Text>().text = "";
        UseWaku.transform.Find("Mask/Text").GetComponent<Text>().text = "";
        UseWaku.transform.Find("Mask/Sus").GetComponent<Text>().text = "";
        UseWaku.transform.Find("Mask/ItemImage").GetComponent<Image>().sprite = SpriteImage;
        UseWaku.transform.Find("Mask/AllColor").GetComponent<Image>().color = UseColor;

        StartCoroutine(XYChangeCoroutine(UseWaku, GoX, GoY, Time2));
        StartCoroutine(XYChangeCoroutine(Mask, GoX, GoY, Time2));
        StartCoroutine(XYChangeCoroutine(AllColor, GoX, GoY, Time2));
        StartCoroutine(ColorChangeCoroutine(UseWaku, UseColor, Time2));
        GetComponent<SoundController>().PlaySE("Bans");

        yield return new WaitForSeconds(Time4);//遅延

        //バンズはさむ
        iTween.MoveTo(Buns1, iTween.Hash("position", new Vector3(0, -360f, 0f), "time", Time5, "easeType", iTween.EaseType.linear));
        iTween.MoveTo(Buns2, iTween.Hash("position", new Vector3(0, -450f, 0f), "time", Time5, "easeType", iTween.EaseType.linear));
        //  GetComponent<SoundController>().PlaySE("BansDon");

        yield return new WaitForSeconds(Time5);//遅延

        //パーティクル発動
        ParticleSystem.MinMaxGradient color = new ParticleSystem.MinMaxGradient();
        color.mode = ParticleSystemGradientMode.Color;
        color.color = UseColor;
        ParticleSystem.MainModule main = ParticleFeed.GetComponent<ParticleSystem>().main;
        main.startColor = color;

        ParticleFeed.GetComponent<ParticleSystem>().Play();
        //SE
        GetComponent<SoundController>().PlaySE("Burger");

        yield return new WaitForSeconds(Time6 / 4);//遅延

        ParticleFeed.GetComponent<ParticleSystem>().Play();

        yield return new WaitForSeconds(Time6 + Time7);//遅延

        Attack();

        TapBlock.SetActive(false);
        EventSystem.SetActive(true);

        yield return null;

    }

    public void Attack()
    {
        TapBlock.SetActive(true);
        EventSystem.SetActive(false);

        StartCoroutine("AttackCoroutine");

        TapBlock.SetActive(false);
        EventSystem.SetActive(true);
    }

    //点滅
    private IEnumerator Blink(GameObject Customer, GameObject Base, Color GOColor, float DelayTime, int mode)
    {
        yield return new WaitForSeconds(DelayTime);//遅延
        Customer.GetComponent<Image>().color = GOColor;
        if (mode == 0)
        {
            Base.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }
        else
        {
            Base.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }
        yield return null;
    }
    //Gの移動
    private IEnumerator GMove(GameObject G, Vector3 GoPosition, float GoTime, float DelayTime)
    {
        yield return new WaitForSeconds(DelayTime);//遅延
        if (G != null) {
            G.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 0);
            iTween.MoveTo(G, iTween.Hash(
    "position", GoPosition,
    "time", GoTime
    , "easeType", iTween.EaseType.linear
));
        }
        yield return null;
    }
    //勝敗処理
    private IEnumerator AttackCoroutine()
    {
        int ItemNum = StatGame.GetComponent<StatGame>().UseItemNum;
        string[] UseItem = StatGame.GetComponent<StatGame>().UseItemData;

        TapBlock.SetActive(true);
        EventSystem.SetActive(false);
        //客をすべて取得し、一体ずつ処理
        GameObject[] Customers = GameObject.FindGameObjectsWithTag("Customer");
        int Count = 0;
        int CustomerLength = Customers.GetLength(0);
        int UseItemPower = int.Parse(UseItem[2]);
        string UseItemColor = UseItem[3];
        float UseItemUpSus = float.Parse(UseItem[4]);

        int VictoryNum = 0;
        int GetG = 0;
        int NowGetG = 0;
        int MaxG = 0;
        float FloatMaxG = 0;
        float GCount = 0;
        float FloatNowGetG = 0;
        int GetExp = 0;
        float GetSus = 0;
        float VictoryPoint = 0;
        int RateColor = 0;
        float FloatCount = 0;
        //Susは人数に関わらず上がる
        GetSus = UseItemUpSus;

        float BlinkTime = 0.8f;
        float HeartTime = 0.3f;
        float HPTime = 0.4f;
        float MaTime = 0.2f;//ハートからＧゲットまでの間
        float GTime = 1.0f;
        float MaTime2 = 0.3f;//Ｇゲットからタップできるようになるまでの間

        float HpPoint;

        GameObject Base;
        GameObject HPbar;

        while (Count < CustomerLength)
        {
            MaxCustomer++;//さばいた客の数

            int CustomerHp = Customers[Count].GetComponent<StatCustomer>().Hp;
            int CustomerDropG = Customers[Count].GetComponent<StatCustomer>().DropG;
            string CustomerColor = Customers[Count].GetComponent<StatCustomer>().Color;


            //色距離の取得
            Color UseColor = GetComponent<ColorGetter>().ToColor(UseItemColor);
            Color CustomColor = GetComponent<ColorGetter>().ToColor(CustomerColor);
            RateColor = GetComponent<LvDesignController>().ColorCondition(UseItemColor, CustomerColor);

            /*デバッグ用、色類似度の表示
                        GameObject ColorCheck = (GameObject)Instantiate(
                                   ColorCheckPrefab,
                                   transform.position,
                                   Quaternion.identity);
                        ColorCheck.transform.SetParent(Customers[Count].transform);
                        //位置決定
                        ColorCheck.transform.localPosition = new Vector3(0, 90, 0);
                        string DistancePerString = (RateColor).ToString();
            ColorCheck.GetComponent<Text>().text = DistancePerString+"";
            */

            //Powerを比べる
            //勝利点算出
            VictoryPoint = GetComponent<LvDesignController>().VictoryCondition(UseItemPower, CustomerHp, RateColor);
            HpPoint = VictoryPoint * -1f;
            if (HpPoint < 0) { HpPoint = 0; }


            //点滅演出
            FloatCount = (float)Count * 1.0f;
            //Baseを取得
            Base = Customers[Count].transform.Find("CustomerBase").gameObject;


            if (VictoryPoint >= 0 & VictoryPoint < 1.5f)
            {

                StartCoroutine(Blink(Customers[Count], Base, new Color(0, 0, 0, 0), FloatCount / 16, 0));
                StartCoroutine(Blink(Customers[Count], Base, CustomColor, BlinkTime * 1 / 6 + FloatCount / 16, 1));
                // Debug.Log("Blink1");

            }
            else if (VictoryPoint >= 1.5f & VictoryPoint < 2.0f) {
                StartCoroutine(Blink(Customers[Count], Base, new Color(0, 0, 0, 0), FloatCount / 16, 0));
                StartCoroutine(Blink(Customers[Count], Base, CustomColor, BlinkTime * 1 / 6 + FloatCount / 16, 1));
                StartCoroutine(Blink(Customers[Count], Base, new Color(0, 0, 0, 0), BlinkTime * 2 / 8 + FloatCount / 16, 0));
                StartCoroutine(Blink(Customers[Count], Base, CustomColor, BlinkTime * 3 / 6 + FloatCount / 16, 1));
                // Debug.Log("Blink2");
            }
            else if (VictoryPoint > 2.0f)
            {
                StartCoroutine(Blink(Customers[Count], Base, new Color(0, 0, 0, 0), FloatCount / 16, 0));
                StartCoroutine(Blink(Customers[Count], Base, CustomColor, BlinkTime * 1 / 6 + FloatCount / 16, 1));
                StartCoroutine(Blink(Customers[Count], Base, new Color(0, 0, 0, 0), BlinkTime * 2 / 8 + FloatCount / 16, 0));
                StartCoroutine(Blink(Customers[Count], Base, CustomColor, BlinkTime * 3 / 6 + FloatCount / 16, 1));
                StartCoroutine(Blink(Customers[Count], Base, new Color(0, 0, 0, 0), BlinkTime * 4 / 8 + FloatCount / 16, 0));
                StartCoroutine(Blink(Customers[Count], Base, CustomColor, BlinkTime * 5 / 6 + FloatCount / 16, 1));
                // Debug.Log("Blink3");


            }

            //HP演出
            //生成
            GameObject HPwaku = (GameObject)Instantiate(
                   HPbarPrefab,
                   transform.position,
                   Quaternion.identity);
            HPwaku.transform.SetParent(Customers[Count].transform);
            //bar取得
            HPbar = HPwaku.transform.Find("HPbar").gameObject;
            HPbar.GetComponent<Image>().color = ExpBlue;

            //位置決定
            HPwaku.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 1);
            HPwaku.GetComponent<RectTransform>().localPosition = new Vector3(0, 87f, 0);
            //大きさ変更

            iTween.ScaleTo(HPwaku, iTween.Hash(
                "x", 1,
                "y", 1,
                "time", 0,
                "delay", BlinkTime / 2, "easeType", iTween.EaseType.linear
                ));
            /*
            iTween.MoveTo(HPwaku, iTween.Hash(
                "position", new Vector3(0, 87f, 0f),
                "time", HeartTime,
                "isLocal", true, "easeType", iTween.EaseType.linear
                ));
                */
            //Hpbarを減らす
            iTween.ScaleTo(HPbar, iTween.Hash(
               "x", HpPoint,
                "time", HPTime,
                "delay", BlinkTime / 2,
                "isLocal", true, "easeType", iTween.EaseType.linear
                ));

            if (VictoryPoint >= 0)
            {
                VictoryNum++;

                //ハートの生成
                GameObject Heart = (GameObject)Instantiate(
                       HeartPrefab,
                       transform.position,
                       Quaternion.identity);
                Heart.transform.SetParent(Customers[Count].transform);
                //位置決定
                Heart.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
                Heart.GetComponent<RectTransform>().localPosition = new Vector3(0, 77f, 0);
                //大きさ変更
                iTween.ScaleTo(Heart, iTween.Hash(
                    "x", 5,
                    "y", 5,
                    "time", 0,
                    "delay", BlinkTime, "easeType", iTween.EaseType.linear
                    ));

                iTween.MoveTo(Heart, iTween.Hash(
                    "position", new Vector3(0, 87f, 0f),
                    "time", HeartTime,
                    "delay", BlinkTime,
                    "isLocal", true, "easeType", iTween.EaseType.easeOutElastic
                    ));


                //タグをつける
                Customers[Count].tag = "Loser";
                //勝利度合の記録
                Customers[Count].GetComponent<StatCustomer>().PointPower = UseItemPower - CustomerHp;
                Customers[Count].GetComponent<StatCustomer>().PointColor = RateColor;

                //賞金取得
                NowGetG = GetComponent<LvDesignController>().VictoryDropG(CustomerDropG, VictoryPoint);

                //修正値による修正
                FloatNowGetG = (float)NowGetG;
                FloatNowGetG = FloatNowGetG * (StatGame.GetComponent<StatGame>().ModifyG + 100) / 100;
                NowGetG = Mathf.RoundToInt(FloatNowGetG);

                GetG += NowGetG;
                if (MaxG < NowGetG) { MaxG = NowGetG; }
                FloatMaxG = (float)MaxG;
                FloatNowGetG = (float)NowGetG;

                //exp獲得
                GetExp += GetComponent<LvDesignController>().VictoryDropExp(CustomerDropG, VictoryPoint);//Exp基数=Gと同じ

                GCount = 0;

                while (GCount < FloatNowGetG / 10 & GCount < 10) {
                    //G生成
                    //  Debug.Log("G!");
                    GameObject G = (GameObject)Instantiate(
                           GPrefab,
                           transform.position,
                           Quaternion.identity);
                    G.GetComponent<Image>().color = GYellow;
                    G.transform.SetParent(Customers[Count].transform);
                    //位置決定
                    G.transform.localPosition = new Vector3(0, 30, 1);
                    G.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);

                    //移動
                    StartCoroutine(GMove(G,
                        new Vector3(-200f, 500f, 0),
                        GTime / (FloatMaxG / 10),
                        (GTime / (FloatMaxG / 10)) * GCount + BlinkTime + HeartTime + MaTime)
                        );


                    GCount++;
                }

            }
            //客の勝利
            else
            {
                //タグをつける
                Customers[Count].tag = "Winner";
            }

            Count++;
        }

        MaxCustomerVictory += VictoryNum;//うち魅了した客の数
                                         //SE
        GetComponent<SoundController>().PlaySE("Heart");

        //一人もつれなかったら演出のディレイ時間減らす
        if (VictoryNum == 0)
        {
            BlinkTime = 0;
            HeartTime = 0;
            MaTime = 1.0f;
            GTime = 0f;
            FloatMaxG = 0.1f;
        }
        float ResultGetSus = GetComponent<LvDesignController>().FeedGetSus(GetSus);
        //修正値による修正
        ResultGetSus = ResultGetSus * (StatGame.GetComponent<StatGame>().ModifySus + 100) / 100;
        ResultGetSus = Mathf.Round(ResultGetSus);
        //SE
        yield return new WaitForSeconds(BlinkTime + HeartTime + MaTime + GTime * 3 / 10);//遅延
        GetComponent<SoundController>().PlaySE("GGetOne");

        //合計賞金を加算
        GetComponent<StatGameController>().GUp(GetG);

        //EXPを加算
        GetComponent<StatGameController>().ExpUp(GetExp);

        //Susを加算
        GetComponent<StatGameController>().SusUp(ResultGetSus);

        MaxGetG += GetG;//かせいだ売上の総和

        //記録

        StatGame.GetComponent<StatGame>().ResultGetG = GetG;
        StatGame.GetComponent<StatGame>().ResultGetExp = GetExp;
        StatGame.GetComponent<StatGame>().ResultGetSus = ResultGetSus;

        yield return new WaitForSeconds(GTime * 7 / 10 + MaTime2);//遅延

        TapBlock.SetActive(false);
        EventSystem.SetActive(true);

        PopupResultGPopPop();
        yield return null;

    }

    public void PopupResultGPopPop()
    {

        TapButton.SetActive(false);

        //SE
        GetComponent<SoundController>().PlaySE("GGet");


        int GetG = StatGame.GetComponent<StatGame>().ResultGetG;
        int GetExp = StatGame.GetComponent<StatGame>().ResultGetExp;
        float GetSus = StatGame.GetComponent<StatGame>().ResultGetSus;

        //ポップアップ表示

        PopupResultG.SetActive(true);

        //アイテム４は消す
        Button4Items.SetActive(false);
        //消した個々のボタンは戻しておく
        Button4Items1.SetActive(true);
        Button4Items2.SetActive(true);
        Button4Items3.SetActive(true);
        Button4Items4.SetActive(true);

        PopupResultGTextSus.color = SusGreen;

        GetG = Mathf.Abs(GetG);
        string TextGetG = (GetG).ToString();
        string TextGetExp = GetComponent<LvDesignController>().StringGetExp(GetExp);
        string TextGetSus = (GetSus).ToString();
        if (GetG <= 0) { PopupResultGTextG.color = SusGreen; }
        else { PopupResultGTextG.color = GYellow; }

        if (GetSus > 0) { SusLine.SetActive(true); }
        else { SusLine.SetActive(false); }

        PopupResultGTextG.text = TextGetG;
        PopupResultGTextExp.text = TextGetExp;
        PopupResultGTextSus.text = TextGetSus;


        //この直後、ゲームオーバー判定
    }

    public void LevelUp()
    {

        PopupResultG.SetActive(false);
        if (GetComponent<LvDesignController>().LvUpCondition())
        {
            StatGame.GetComponent<StatGame>().StatExp = 0;

            //SE
            GetComponent<SoundController>().PlaySE("LvUp");

            PopupLvUp.SetActive(true);
            PopupLvUpText.text = "レベルアップ！";

            int SaveSus = GetComponent<LvDesignController>().LvUpSus;
            PopupLvUpSusText.color = ExpBlue;
            PopupLvUpSusText.text = SaveSus.ToString();
            //レベルアップ時のボーナス処理
            GetComponent<StatGameController>().LvUp(1);


            //レベルを渡すとSus減少を発動する
            GetComponent<LvDesignController>().LvUpSaveSus();

            int NowLv = StatGame.GetComponent<StatGame>().StatLv;
            GetComponent<CustomerController>().GetCustomerData(NowLv);

            //チュートリアル 初レベルアップ
        if (StatPlayer.GetComponent<StatPlayer>().FlagTutorialFirstLvup == 0)
            {
                //ボタン押せなくする
                LvUpOKButton.GetComponent<Button>().interactable = false;

                GetComponent<TutorialController>().StartTutorial("FirstLvup");
            }

        }
        else {

            CheckGameOver();
        }

    }
    //ゲームオーバー判定（カルマ）
    public void CheckGameOver()
    {


        GetComponent<StatGameController>().DrawExp();//レベルアップしていたら、Expを０に戻した状態で再描画

        if (StatGame.GetComponent<StatGame>().StatSus > 100) {

            GameOver();
        }
        else
        {

            Select(); }
    }

    //ゲームオーバーストーリー表示後のエンドカード
    public void EndCard(string EndMassage)
    {
        CustomerField.SetActive(false);
        Button4Items.SetActive(false);
        Hand.SetActive(false);
        Message.SetActive(false);

        PopupGameOverText.text = EndMassage;
        PopupGameOver.SetActive(true);

        //スコア記録
        GetHighScore();
        StatPlayer.GetComponent<StatPlayer>().CheckHighScore();
        StatPlayer.GetComponent<StatPlayer>().WriteHighScore();

    }
    //ゲームオーバー時（カルマ）
    public void GameOver()
    {
        //客破壊
        CustomerDestroy();
        DestroyG();
        DestroyHeart();

        Hand.SetActive(false);
        CustomerField.SetActive(false);

        GetComponent<SoundController>().StopStoreBgm();

        if (StatGame.GetComponent<StatGame>().StatG >= 5000000) {
            GetComponent<StoryController>().StartStory("EndingKarma2");
        }
        else {
            GetComponent<StoryController>().StartStory("EndingKarma1");
        }
    }

    //ゲームオーバー時罰金
    public int GetEndFine(string NowStoryKey)
    {
        int Fine=0;
        if (NowStoryKey == "EndingKarma1" | NowStoryKey == "SkipEndingKarma1") { Fine = StatGame.GetComponent<StatGame>().StatG; }
        else if (NowStoryKey == "EndingKarma2" | NowStoryKey == "SkipEndingKarma2") { Fine = 5000000; }
        else if (NowStoryKey == "Ending1" | NowStoryKey == "SkipEnding1") { Fine = StatGame.GetComponent<StatGame>().StatG; }
        else if (NowStoryKey == "Ending2" | NowStoryKey == "SkipEnding2") { Fine = StatGame.GetComponent<StatGame>().StatG; }
        else if (NowStoryKey == "Ending3" | NowStoryKey == "SkipEnding3") { Fine = 10000000-StatGame.GetComponent<StatGame>().StatG;}
        else if (NowStoryKey == "Ending4" | NowStoryKey == "SkipEnding4") { Fine = 0; }
        return Fine;
    }

    //ゲームオーバー時（日数）
    public void DaysEnd()
    {
        Hand.SetActive(false);
        CustomerField.SetActive(false);

        GetComponent<SoundController>().StopStoreBgm();
        GetHighScore();
        StatPlayer.GetComponent<StatPlayer>().CheckHighScore();
        StatPlayer.GetComponent<StatPlayer>().WriteHighScore();

        if (StatGame.GetComponent<StatGame>().StatG < 3000000)
        {
            GetComponent<StoryController>().StartStory("Ending1");
        }
        else if (StatGame.GetComponent<StatGame>().StatG >= 3000000& StatGame.GetComponent<StatGame>().StatG < 5000000)
        {
            GetComponent<StoryController>().StartStory("Ending2");
        }
        else if (StatGame.GetComponent<StatGame>().StatG >= 5000000 & StatGame.GetComponent<StatGame>().StatG < 10000000)
        {
            GetComponent<StoryController>().StartStory("Ending3");
        }
        else
        {
            GetComponent<StoryController>().StartStory("Ending4");
        }

    }
    //ハイスコアの記録
    public void GetHighScore()
    {
        StatPlayer.GetComponent<StatPlayer>().TotalCountPlay++;

        StatPlayer.GetComponent<StatPlayer>().MaxKill = MaxKill;//殺人数
        StatPlayer.GetComponent<StatPlayer>().MaxCustomer = MaxCustomer;//さばいた客の数
        StatPlayer.GetComponent<StatPlayer>().MaxCustomerVictory = MaxCustomerVictory;//うち魅了した客の数
        StatPlayer.GetComponent<StatPlayer>().MaxGetG = StatGame.GetComponent<StatGame>().StatG;//かせいだ売上（=所持金）の総和

        StatPlayer.GetComponent<StatPlayer>().MaxG = StatGame.GetComponent<StatGame>().StatG;
        StatPlayer.GetComponent<StatPlayer>().MaxLv = StatGame.GetComponent<StatGame>().StatLv;
        StatPlayer.GetComponent<StatPlayer>().MaxDays = StatGame.GetComponent<StatGame>().StatDays;


    }

    //取得アイテムがないときにアイテムを自動的に１つ得る
    public void GetPickUp()
    {


        string[] PickUpItem = GetComponent<LvDesignController>().GetPickUpItem();

        if (StatGame.GetComponent<StatGame>().Item1[0] == "None") { StatGame.GetComponent<StatGame>().Item1 = PickUpItem; }
        else if (StatGame.GetComponent<StatGame>().Item2[0] == "None") { StatGame.GetComponent<StatGame>().Item2 = PickUpItem; }
        else if (StatGame.GetComponent<StatGame>().Item3[0] == "None") { StatGame.GetComponent<StatGame>().Item3 = PickUpItem; }
        else { StatGame.GetComponent<StatGame>().Item4 = PickUpItem; }

        PopupGetItem.SetActive(true);
        PopupGetText.text = "だれも こなかったので、\nそのへんで" + PickUpItem[0] + "\n を ひろいました";
        GetComponent<StatGameController>().DrawGetItem(PickUpItem);


    }

    //アイテムゲット選択画面へ
    public void Select()
    {

        //レベルアップから来た場合のレベルアップポップアップを消す
        PopupLvUp.SetActive(false);

        //手持ちボタン表示
        Hand.SetActive(false);
        HandButton.SetActive(true);


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

            Button4Items1.GetComponent<Button>().interactable = false;
            Button4Items2.GetComponent<Button>().interactable = false;
            Button4Items3.GetComponent<Button>().interactable = false;
            Button4Items4.GetComponent<Button>().interactable = false;

            CustomerFieldCollider.SetActive(false);
            CustomerFieldBack.SetActive(false);

            GetComponent<StatGameController>().DrawItem4();

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
            int PositionY = 0;
            int PositionX = 0;
            while (Count < CustomerLength)
            {
                PositionY = 125;
                PositionX = (150 * Count) - 220;
                LoserTop[Count].transform.position = new Vector3(PositionX, PositionY, 0);
                LoserTop[Count].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
                LoserTop[Count].GetComponent<Button>().interactable = true;


                DropItem = LoserTop[Count].GetComponent<StatCustomer>().DropItem;
                ItemName = DropItem[0];
                ItemImage = DropItem[1];
                ItemPower = int.Parse(DropItem[2]);
                ItemUpSus = float.Parse(DropItem[4]);
                CountString = (Count).ToString();
                ItemTag = "Item" + CountString;
                ItemCol = LoserTop[Count].GetComponent<Image>().color;

                float CoreR = ItemCol.r;
                float CoreG = ItemCol.g;
                float CoreB = ItemCol.b;
                //アイテムの色揺れ幅

                float PlusR = Random.Range(50f / 255, -50f / 255);
                float PlusG = Random.Range(50f / 255, -50f / 255);
                float PlusB = Random.Range(50f / 255, -50f / 255);
                Color UseItemCol = new Color(CoreR + PlusR, CoreG + PlusG, CoreB + PlusB, 1f);


                GetComponent<ItemController>().MakeItem(ItemName, ItemImage, ItemPower, UseItemCol, ItemUpSus, PositionX, -90, ItemTag, 0);

                Count++;
            }
            MessageDraw(" ２つえらんでＯＫ  （ わくタップでキャンセル ）");
            SelectStart();//選択ワクの初期化
            SelectButtonOK.GetComponent<Button>().interactable = false;
        }

        //チュートリアル 初選択
        if (StatPlayer.GetComponent<StatPlayer>().FlagTutorialFirstSelect == 0)
        {
            HandButton.GetComponent<Button>().interactable = false;

            GetComponent<TutorialController>().StartTutorial("FirstSelect");
        }


    }
    //手持ち開く
    public void HandOpen()
    {
        GetComponent<StatGameController>().DrawItemSelectItem4();
        Hand.SetActive(true);
        HandButton.SetActive(false);
    }
    //手持ち閉じる
    public void HandClose()
    {
        Hand.SetActive(false);
        HandButton.SetActive(true);
    }

    public void DestroyG()
    {
        //Gを破壊
        GameObject[] Gs = GameObject.FindGameObjectsWithTag("G");
        int Count = 0;
        int GLength = Gs.GetLength(0);
        while (Count < GLength)
        {
            Destroy(Gs[Count]);
            Count++;
        }
    }
    public void DestroyHeart()
    {
        //Heartを破壊
        GameObject[] Hearts = GameObject.FindGameObjectsWithTag("Heart");
        int Count = 0;
        int HeartLength = Hearts.GetLength(0);
        while (Count < HeartLength)
        {
            Destroy(Hearts[Count]);
            Count++;
        }

    }

    //選択ワクの初期化
    public void SelectStart()
    {

        DestroyG();
        DestroyHeart();

        if (GameObject.FindGameObjectWithTag("Box1") != null) { Destroy(GameObject.FindGameObjectWithTag("Box1")); }
        if (GameObject.FindGameObjectWithTag("Box2") != null) { Destroy(GameObject.FindGameObjectWithTag("Box2")); }

        SelectItemImage1.GetComponent<Image>().sprite = null;
        SelectItemImage1Base.GetComponent<Image>().sprite = null;
        SelectItemImage1Base.GetComponent<Image>().color = new Color(1f,1f,1f,1f) ;
        SelectItemImage1Base.SetActive(false);
        SelectItemImage1.GetComponent<Image>().color = new Color(0, 0, 0, 1f); ;
        SelectItemName1.GetComponent<Text>().text = "";
        SelectItemPower1.GetComponent<Text>().text = "";
        SelectItemSus1.GetComponent<Text>().text = "";
        SelectItemSus1.GetComponent<Text>().color = SusGreen;

        SelectItemImage2.GetComponent<Image>().sprite = null;
        SelectItemImage2Base.GetComponent<Image>().sprite = null;
        SelectItemImage2Base.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        SelectItemImage2Base.SetActive(false);
        SelectItemImage2.GetComponent<Image>().color = new Color(0, 0, 0, 1f);
        SelectItemName2.GetComponent<Text>().text = "";
        SelectItemPower2.GetComponent<Text>().text = "";
        SelectItemSus2.GetComponent<Text>().text = "";
        SelectItemSus2.GetComponent<Text>().color = SusGreen;

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

            //SE
            GetComponent<SoundController>().PlaySE("Victory");
            GameObject SelectedItem = GameObject.FindGameObjectWithTag(TagName);

            string Name;
            string Image;
            int Power;
            string PowerString;
            Color Col;
            float UpSus;
            string UpSusString;
            int SaveSus = 0;

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
                UpSusString = (SelectedItem.GetComponent<StatItem>().UpSus).ToString();

                string ImagePath = "Item/" + Image;
                Sprite SpriteImage = Resources.Load<Sprite>(ImagePath);
                if ((GameObject.FindGameObjectWithTag("Box1") == null & GameObject.FindGameObjectWithTag("Box2") != null) |
                    (GameObject.FindGameObjectWithTag("Box1") == null & GameObject.FindGameObjectWithTag("Box2") == null))
                {
                    UseBox = SelectItemImage1;
                    SelectItemImage1.GetComponent<Image>().sprite = SpriteImage;
                    SelectItemImage1Base.GetComponent<Image>().sprite = null;
                    SelectItemImage1Base.SetActive(false);

                    SelectItemImage1.GetComponent<Image>().color = Col;
                    SelectItemName1.GetComponent<Text>().text = Name;
                    SelectItemPower1.GetComponent<Text>().text = PowerString;
                    SelectItemSus1.GetComponent<Text>().text = UpSusString;
                    SelectBox.tag = "Box1";
                    SelectItemImage1.tag = TagName; }
                else
                {
                    UseBox = SelectItemImage2;
                    SelectItemImage2.GetComponent<Image>().sprite = SpriteImage;
                    SelectItemImage2Base.GetComponent<Image>().sprite = null;
                    SelectItemImage2Base.SetActive(false);

                    SelectItemImage2.GetComponent<Image>().color = Col;
                    SelectItemName2.GetComponent<Text>().text = Name;
                    SelectItemPower2.GetComponent<Text>().text = PowerString;
                    SelectItemSus2.GetComponent<Text>().text =UpSusString;
                    SelectBox.tag = "Box2";
                    SelectItemImage2.tag = TagName;
                }
                //アイテムの情報をＳＴＡＴに書き込み
                UseBox.GetComponent<StatItem>().Name = Name;
                UseBox.GetComponent<StatItem>().Image = Image;
                UseBox.GetComponent<StatItem>().Power = Power;
                UseBox.GetComponent<StatItem>().Col = Col;
                UseBox.GetComponent<StatItem>().UpSus = UpSus;
                UseBox.GetComponent<StatItem>().SaveSus = 0;
                UseBox.GetComponent<StatItem>().HumanName = "";

                //ワクの位置と大きさ
                SelectBox.transform.localPosition = new Vector3(0, 15, 0);
                SelectBox.GetComponent<RectTransform>().sizeDelta = new Vector2(140, 160);
                SelectBox.GetComponent<BoxCollider2D>().size = new Vector2(140, 160);

                UseBox.GetComponent<RectTransform>().sizeDelta = new Vector2(130, 65);
                UseBox.GetComponent<RectTransform>().localPosition = new Vector3(0, 25, 0);

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
                SaveSus = SelectedItem.GetComponent<StatCustomer>().SaveSus;

                string ImagePath = "CustomerColor/" + SelectedItem.GetComponent<StatCustomer>().Image;
                Sprite SpriteImage = Resources.Load<Sprite>(ImagePath);

                string ImagePathBase = "CustomerBase/" + SelectedItem.GetComponent<StatCustomer>().Image;
                Sprite SpriteImageBase = Resources.Load<Sprite>(ImagePathBase);

                if ((GameObject.FindGameObjectWithTag("Box1") == null & GameObject.FindGameObjectWithTag("Box2") != null) |
                    (GameObject.FindGameObjectWithTag("Box1") == null & GameObject.FindGameObjectWithTag("Box2") == null))
                {
                    UseBox = SelectItemImage1;
                    SelectItemImage1.GetComponent<Image>().sprite = SpriteImage;
                    SelectItemImage1Base.GetComponent<Image>().sprite = SpriteImageBase;
                    SelectItemImage1Base.SetActive(true);

                    SelectItemImage1.GetComponent<Image>().color = Col;
                    SelectItemName1.GetComponent<Text>().text = SelectedItem.GetComponent<StatCustomer>().Name;
                    SelectItemPower1.GetComponent<Text>().text = "？";
                    SelectItemSus1.GetComponent<Text>().text = "？";
                    SelectBox.tag = "Box1";
                    SelectItemImage1.tag = TagName;
                }
                else
                {
                    UseBox = SelectItemImage2;
                    SelectItemImage2.GetComponent<Image>().sprite = SpriteImage;
                    SelectItemImage2Base.GetComponent<Image>().sprite = SpriteImageBase;
                    SelectItemImage2Base.SetActive(true);

                    SelectItemImage2.GetComponent<Image>().color = Col;
                    SelectItemName2.GetComponent<Text>().text = SelectedItem.GetComponent<StatCustomer>().Name;
                    SelectItemPower2.GetComponent<Text>().text = "？";
                    SelectItemSus2.GetComponent<Text>().text = "？";
                    SelectBox.tag = "Box2";
                    SelectItemImage2.tag = TagName;
                }

                //アイテムの情報をＳＴＡＴに書き込み
                UseBox.GetComponent<StatItem>().Name = Name;
                UseBox.GetComponent<StatItem>().Image = Image;
                UseBox.GetComponent<StatItem>().Power = Power;
                UseBox.GetComponent<StatItem>().Col = Col;
                UseBox.GetComponent<StatItem>().UpSus = UpSus;
                UseBox.GetComponent<StatItem>().SaveSus = SaveSus;
                UseBox.GetComponent<StatItem>().HumanName = SelectedItem.GetComponent<StatCustomer>().Name;


                //ワクの位置と大きさ
                SelectBox.transform.localPosition = new Vector3(0, 0, 0);
                SelectBox.GetComponent<RectTransform>().sizeDelta = new Vector2(140, 200);
                SelectBox.GetComponent<BoxCollider2D>().size = new Vector2(140, 200);
                UseBox.GetComponent<RectTransform>().sizeDelta = new Vector2(125, 175);
                UseBox.GetComponent<RectTransform>().localPosition = new Vector3(0, 25, 0);

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

        //SE
        GetComponent<SoundController>().PlaySE("TapButton");

        //OKボタンを切る
        SelectButtonOK.GetComponent<Button>().interactable = false;
        GameObject UseBox = SelectItemImage1;

        if (TagName == "Box1")
        {
            UseBox = SelectItemImage1;
            Destroy(GameObject.FindGameObjectWithTag("Box1"));

            SelectItemImage1Base.GetComponent<Image>().sprite = null;
            SelectItemImage1Base.SetActive(false);

            SelectItemImage1.GetComponent<Image>().sprite = null;
            SelectItemImage1.GetComponent<Image>().color = new Color(0, 0, 0, 1f); ;
            SelectItemName1.GetComponent<Text>().text = " ";
            SelectItemPower1.GetComponent<Text>().text = " ";
            SelectItemSus1.GetComponent<Text>().text = " ";
            SelectItemImage1.tag = "Untagged";

        }
        else
        {
            UseBox = SelectItemImage2;
            Destroy(GameObject.FindGameObjectWithTag("Box2"));

            SelectItemImage2Base.GetComponent<Image>().sprite = null;
            SelectItemImage2Base.SetActive(false);

            SelectItemImage2.GetComponent<Image>().sprite = null;
            SelectItemImage2.GetComponent<Image>().color = new Color(0, 0, 0, 1f);
            SelectItemName2.GetComponent<Text>().text = " ";
            SelectItemPower2.GetComponent<Text>().text = " ";
            SelectItemSus2.GetComponent<Text>().text = " ";
            SelectItemImage2.tag = "Untagged";
        }
        UseBox.GetComponent<StatItem>().Name = null;
        UseBox.GetComponent<StatItem>().Image = null;
        UseBox.GetComponent<StatItem>().Power = 0;
        UseBox.GetComponent<StatItem>().Col = new Color(0, 0, 0, 1f);
        UseBox.GetComponent<StatItem>().UpSus = 0;
        UseBox.GetComponent<StatItem>().SaveSus = 0;
        UseBox.GetComponent<StatItem>().HumanName = "";
        //        UseBox.tag = "Untagged";

        TapBlock.SetActive(false);
        EventSystem.SetActive(true);

    }

    //選択確定→捨てる画面に遷移
    //演出
    public void GoSelectOK()
    {
        StartCoroutine ("GoSelectOKCoroutine");
    }
    private IEnumerator GoSelectOKCoroutine()
    {
        TapBlock.SetActive(true);
        EventSystem.SetActive(false);
        float Time1 = 0.5f;//客を上に寄せる時間
        float Time2 = 0;//客が赤くなる時間
        float Time3 = 0.4f;//客が消えていく時間
        float Time4 = 0.5f;//アイテムが現われる時間
        float Time5 = 0.3f;//間の時間
        float Time6 = 0.6f;//ワクが動く時間
        float Time7 = 0.1f;//間の時間

        MessageDraw("");
        SelectButtonOK.SetActive(false);

        //Dispose画面を準備しておく
        BeforeDispose();
        
        //客は上に寄せる
        if (GameObject.FindGameObjectWithTag("Top0") != null) { iTween.MoveTo(GameObject.FindGameObjectWithTag("Top0"), iTween.Hash("y",1000, "time", Time1, "islocal",true, "easeType", iTween.EaseType.linear)); }
        if (GameObject.FindGameObjectWithTag("Top1") != null) { iTween.MoveTo(GameObject.FindGameObjectWithTag("Top1"), iTween.Hash("y", 1000, "time", Time1, "islocal", true, "easeType", iTween.EaseType.linear)); }
        if (GameObject.FindGameObjectWithTag("Top2") != null) { iTween.MoveTo(GameObject.FindGameObjectWithTag("Top2"), iTween.Hash("y", 1000, "time", Time1, "islocal", true, "easeType", iTween.EaseType.linear)); }
        if (GameObject.FindGameObjectWithTag("Top3") != null) { iTween.MoveTo(GameObject.FindGameObjectWithTag("Top3"), iTween.Hash("y", 1000, "time", Time1, "islocal", true, "easeType", iTween.EaseType.linear)); }
        if (GameObject.FindGameObjectWithTag("Item0") != null) { iTween.MoveTo(GameObject.FindGameObjectWithTag("Item0"), iTween.Hash("y", 1000, "time", Time1, "islocal", true, "easeType", iTween.EaseType.linear)); }
        if (GameObject.FindGameObjectWithTag("Item1") != null) { iTween.MoveTo(GameObject.FindGameObjectWithTag("Item1"), iTween.Hash("y", 1000, "time", Time1, "islocal", true, "easeType", iTween.EaseType.linear)); }
        if (GameObject.FindGameObjectWithTag("Item2") != null) { iTween.MoveTo(GameObject.FindGameObjectWithTag("Item2"), iTween.Hash("y", 1000, "time", Time1, "islocal", true, "easeType", iTween.EaseType.linear)); }
        if (GameObject.FindGameObjectWithTag("Item3") != null) { iTween.MoveTo(GameObject.FindGameObjectWithTag("Item3"), iTween.Hash("y", 1000, "time", Time1, "islocal", true, "easeType", iTween.EaseType.linear)); }



        if (SelectItemImage1.tag == "Top1" | SelectItemImage1.tag == "Top2" | SelectItemImage1.tag == "Top3" | SelectItemImage1.tag == "Top0" |
            SelectItemImage2.tag == "Top1" | SelectItemImage2.tag == "Top2" | SelectItemImage2.tag == "Top3" | SelectItemImage2.tag == "Top0")
        {
            //ボックスを上に上げる
            iTween.MoveTo(SelectItem1, iTween.Hash("y", 30, "time", Time1, "islocal", true, "easeType", iTween.EaseType.linear));
            iTween.MoveTo(SelectItem2, iTween.Hash("y", 30, "time", Time1, "islocal", true, "easeType", iTween.EaseType.linear));
            Hand.SetActive(false);
            HandButton.SetActive(false);

            // iTween.MoveTo(Hand, iTween.Hash("y", 800, "time", Time1, "islocal", true, "easeType", iTween.EaseType.linear));

            //遅延処理

            yield return new WaitForSeconds(Time1);

            //SE　とりあえず、一人でも人間がいたら鳴らす　あとで演出付けるべき
            GetComponent<SoundController>().PlaySE("Kill");
               // Debug.Log("Kill");

                //血しぶき
                //赤色変化してフェードアウトし、アイテム画像に変わる
                if (SelectItemImage1.tag == "Top1" | SelectItemImage1.tag == "Top2" | SelectItemImage1.tag == "Top3" | SelectItemImage1.tag == "Top0")
                {
                StartCoroutine(CustomerKill(SelectItemImage1, SelectItemName1, SelectItemPower1, SelectItemSus1, Time2, Time3, Time4));
                }

                if (SelectItemImage2.tag == "Top1" | SelectItemImage2.tag == "Top2" | SelectItemImage2.tag == "Top3" | SelectItemImage2.tag == "Top0")
                {
                StartCoroutine(CustomerKill(SelectItemImage2, SelectItemName2, SelectItemPower2, SelectItemSus2, Time2, Time3, Time4));
            }
        }
        else {
            Time1 = 0;
            Time2 = 0;
            Time3 = 0;
            Time4 = 0;
            //キルがない時は血しぶき処理をスキップ
        }

        float Till5Time = Time1 + Time2 + Time3 + Time4 + Time5;
        float TillAllTime = Time1 + Time2 + Time3 + Time4 + Time5 + Time6 + Time7;
        MemoTime6=Time6;
        MemoTime7 = Time7;
        MemoTill5Time = Till5Time;
        MemoTillAllTime=TillAllTime;

        StartCoroutine("KillSaveSusOrNot");


        yield return null;
    }


    //キルによってSaveSusがある時とない時の判定のタイミング
    private IEnumerator KillSaveSusOrNot()
    {
        TapBlock.SetActive(true);
        EventSystem.SetActive(false);
        float Till5Time = MemoTill5Time;

        //キルによってSaveSusがある時
        if (SelectItemImage1.GetComponent<StatItem>().SaveSus > 0 | SelectItemImage2.GetComponent<StatItem>().SaveSus > 0)
        {
            yield return new WaitForSeconds(Till5Time);
            KillSaveSus(SelectItemImage1.GetComponent<StatItem>().HumanName, SelectItemImage2.GetComponent<StatItem>().HumanName,
                SelectItemImage1.GetComponent<StatItem>().SaveSus, SelectItemImage2.GetComponent<StatItem>().SaveSus);
            }

        //ない時はアイテム捨てに直行
        else {
            AfterCustomerKill(0);
        }
        TapBlock.SetActive(false);
        EventSystem.SetActive(true);
        yield return null;


    }
    //キルによってSaveSusがある時
    public void KillSaveSus(string HumanName1, string HumanName2, float SaveSus1, float SaveSus2)
    {
      

        if (SaveSus1 > 0 & SaveSus2 >0)
        {
            PopupSaveSusName1.text = HumanName1 + " と";
            PopupSaveSusName2.text = HumanName2 + " を もてなして";
            PopupSaveSusValue.text = (SaveSus1 + SaveSus2).ToString();
        }
        else if (SaveSus1 > 0 & SaveSus2 <= 0)
        {
            PopupSaveSusName1.text = "";
            PopupSaveSusName2.text = HumanName1 + " を もてなして";
            PopupSaveSusValue.text = SaveSus1.ToString();
        }
        else if (SaveSus1 <= 0 & SaveSus2 > 0)
        {
            PopupSaveSusName1.text = "";
            PopupSaveSusName2.text = HumanName2 + " を もてなして";
            PopupSaveSusValue.text = SaveSus2.ToString();
        }
        else {
            Debug.Log("SaveSusの人名が両方空なのにSaveSusが呼ばれている");
            PopupSaveSusName1.text = "";
            PopupSaveSusName2.text = "なにものか を もてなして";
            PopupSaveSusValue.text = (SaveSus1 + SaveSus2).ToString();
        }

        //SUS減発動
        GetComponent<StatGameController>().SusUp((SaveSus1+SaveSus2)*-1.0f);

        PopupSaveSus.SetActive(true);

        //チュートリアル 初Savesus
        if (StatPlayer.GetComponent<StatPlayer>().FlagTutorialFirstSaveSus == 0)
        {
            //ボタン押せなくする
            SaveSusOKButton.GetComponent<Button>().interactable = false;
            GetComponent<TutorialController>().StartTutorial("FirstSaveSus");
        }

    }


    //キル演出の後半
    public void AfterCustomerKill(int mode)
    {
        StartCoroutine(AfterCustomerKillCoroutine(mode));
    }
    private IEnumerator AfterCustomerKillCoroutine(int mode)
    {
        //mode=0 通常 =1 SaveSusでＯＫをタップしての遷移
        //        メモ変数から動作Time読み取る、ただしSaveSusがあった時は別の値を入れる
        float Time6;
        float Time7;
        float Till5Time;
        float TillAllTime;
        if (mode == 0)
        {
            Time6 = MemoTime6;
            Time7 = MemoTime7;
            Till5Time = MemoTill5Time;
            TillAllTime = Time6 + Time7;
        }
        else
        {
            Time6 = MemoTime6;
            Time7 = MemoTime7;
            Till5Time = 0;
            TillAllTime = Time6+Time7;

        }

        PopupSaveSus.SetActive(false);
        yield return new WaitForSeconds(Till5Time);

                 //ボックスを下に下げる
        StartCoroutine(XYChangeCoroutine(SelectItem1, 335f, 150f, Time6/2));
        StartCoroutine(XYChangeCoroutine(SelectItem2, 335f, 150f, Time6/2));
     
        iTween.MoveTo(SelectItemImage1, iTween.Hash("y", 19, "time", Time6, "islocal", true, "easeType", iTween.EaseType.linear));
        iTween.MoveTo(SelectItemImage2, iTween.Hash("y", 19, "time", Time6, "islocal", true, "easeType", iTween.EaseType.linear));
        iTween.MoveTo(SelectItem1, iTween.Hash("y", -200, "time", Time6, "islocal", true, "easeType", iTween.EaseType.linear));
        iTween.MoveTo(SelectItem2, iTween.Hash("y", -200, "time", Time6, "islocal", true, "easeType", iTween.EaseType.linear));


        Button6Items.SetActive(true);
        iTween.MoveTo(Button6Items, iTween.Hash("y", 0, "time", Time6, "islocal", true, "easeType", iTween.EaseType.linear));

        yield return new WaitForSeconds(TillAllTime);

        Button6Items6.SetActive(true);
            Button6Items5.SetActive(true);
            ButtonSelectItem.SetActive(false);


            TapBlock.SetActive(false);
            EventSystem.SetActive(true);

            SelectOK();
        yield return null;
    }


    //キル演出の共有部分
    private IEnumerator CustomerKill(GameObject Image, GameObject Name, GameObject Power, GameObject Sus,float Time2, float Time3, float Time4)
    {

        string ImagePath;
        Sprite SpriteImage;
        Color ItemCol = Image.GetComponent<StatItem>().Col;
        Color CustomCol = Image.GetComponent<Image>().color;
        string PowerString;
        string SusString;
        GameObject Base = Image.transform.Find("Base").gameObject;

        iTween.ShakePosition(Image,iTween.Hash("x",5, "y", 5, "time",Time2 + Time3));

        //パーティクル発動
        GameObject Blood1 = Image.transform.Find("ParticleBlood").gameObject;
        GameObject Blood2 = Image.transform.Find("ParticleBloodBack").gameObject;

      

        ParticleSystem.MinMaxGradient color = new ParticleSystem.MinMaxGradient();
        color.mode = ParticleSystemGradientMode.Color;
        color.color = CustomCol;

        ParticleSystem.MainModule main1 = Blood1.GetComponent<ParticleSystem>().main;
        main1.startColor = color;
        ParticleSystem.MainModule main2 = Blood2.GetComponent<ParticleSystem>().main;
        main2.startColor = color;

        Blood1.GetComponent<ParticleSystem>().Play();
        Blood2.GetComponent<ParticleSystem>().Play();


        StartCoroutine(FadeOutCoroutine(Image, Time3));
        StartCoroutine(FadeOutCoroutine(Base, Time3));
        StartCoroutine(TextFadeOutCoroutine(Name, Time3));
        StartCoroutine(TextFadeOutCoroutine(Power, Time3));
        StartCoroutine(TextFadeOutCoroutine(Sus,  Time3));

        float MaTime = 0.2f;//消えている一瞬の間

        yield return new WaitForSeconds(Time2 + Time3 + MaTime);//遅延

                                //客のスプライトをアイテムに差し替える
                                ImagePath = "Item/" + Image.GetComponent<StatItem>().Image;
                                 SpriteImage = Resources.Load<Sprite>(ImagePath);
                                 Image.GetComponent<Image>().sprite = SpriteImage;
       
                                 Image.GetComponent<Image>().color = new Color(0, 0, 0, 1.0f);
                                 Image.GetComponent<RectTransform>().sizeDelta = new Vector2(130, 65);

                                Name.GetComponent<Text>().text = Image.GetComponent<StatItem>().Name;
                                 PowerString = (Image.GetComponent<StatItem>().Power).ToString();
                                 Power.GetComponent<Text>().text = PowerString;
                                 SusString = (Image.GetComponent<StatItem>().UpSus).ToString();
                                 if (SusString == "0"| SusString == "None")
                                 {
                                     Sus.GetComponent<Text>().text = " ";
                                 }
                                 else {
                                     Sus.GetComponent<Text>().text = SusString;
                                 }
        //情報も差し替える

        //アイテム画像を黒から本来の色に変える
        StartCoroutine(ColorChangeCoroutine(Image,ItemCol, Time4-MaTime));
        StartCoroutine(TextColorChangeCoroutine(Name, new Color(1.0f, 1.0f, 1.0f, 1.0f), Time4 - MaTime));
        StartCoroutine(TextColorChangeCoroutine(Power, new Color(1.0f, 1.0f, 1.0f, 1.0f), Time4 - MaTime));
        StartCoroutine(TextColorChangeCoroutine(Sus, SusGreen, Time4 - MaTime));

        yield return new WaitForSeconds(Time4);//遅延

        yield return null;
    }
    //捨てる画面の準備
    public void BeforeDispose()
    {
        if (SelectItemImage1.tag == "Top1" | SelectItemImage1.tag == "Top2" | SelectItemImage1.tag == "Top3" | SelectItemImage1.tag == "Top0")
        {
            MaxKill++;//殺人数    
        }
        if (SelectItemImage2.tag == "Top1" | SelectItemImage2.tag == "Top2" | SelectItemImage2.tag == "Top3" | SelectItemImage2.tag == "Top0")
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

        GetItem1[0] = SelectItemImage1.GetComponent<StatItem>().Name;
        GetItem1[1] = SelectItemImage1.GetComponent<StatItem>().Image;
        PowerString = (SelectItemImage1.GetComponent<StatItem>().Power).ToString();
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
        GetItem2[3] = "#" + ColorString;

        StatGame.GetComponent<StatGame>().Item5 = GetItem1;
        StatGame.GetComponent<StatGame>().Item6 = GetItem2;

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

        GetComponent<StatGameController>().DrawItem6();
    }


   
//捨てる画面
public void SelectOK()
    {
        PopupSaveSus.SetActive(false);

        SelectStart();//選択ワクの初期化
        Destroy(GameObject.FindGameObjectWithTag("Top0"));
        Destroy(GameObject.FindGameObjectWithTag("Top1"));
        Destroy(GameObject.FindGameObjectWithTag("Top2"));
        Destroy(GameObject.FindGameObjectWithTag("Top3"));
        Destroy(GameObject.FindGameObjectWithTag("Item0"));
        Destroy(GameObject.FindGameObjectWithTag("Item1"));
        Destroy(GameObject.FindGameObjectWithTag("Item2"));
        Destroy(GameObject.FindGameObjectWithTag("Item3"));
        SelectItemImage1.tag = "Untagged";
        SelectItemImage2.tag = "Untagged";

        MessageDraw("どれ を すてますか？");

        //チュートリアル 初捨てる
        if (StatPlayer.GetComponent<StatPlayer>().FlagTutorialFirstDispose == 0)
        {
            //ボタン押せなくする
            Button6Items1.GetComponent<Button>().interactable = false;
            Button6Items2.GetComponent<Button>().interactable = false;
            Button6Items3.GetComponent<Button>().interactable = false;
            Button6Items4.GetComponent<Button>().interactable = false;
            Button6Items5.GetComponent<Button>().interactable = false;
            Button6Items6.GetComponent<Button>().interactable = false;

            GetComponent<TutorialController>().StartTutorial("FirstDispose");
        }
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

        StatGame.GetComponent<StatGame>().Item5 = new string[] { "None", "None", "None", "None", "None" };
        StatGame.GetComponent<StatGame>().Item6 = new string[] { "None", "None", "None", "None", "None" };

        Button6Items.SetActive(false);

        TapBlock.SetActive(false);
        EventSystem.SetActive(true);

        RoundEnd();

    }


    //その周の終わりの処理
    public void RoundEnd()
    {
        PopupAction.SetActive(false);

        //アニメで動いたものを元に戻す
        BeforeStartAnim();

        //客破壊
        CustomerDestroy();
        RoundStart(2);
    }

    //その周の始まりの処理
    //mode=0　セーブなし開始
    //mode=1 セーブあり開始
    //mode=2　道中
    public void RoundStart(int Mode)
    {
        if (Mode != 1) { 
            //日付を経過させる
            GetComponent<StatGameController>().DaysUp(1);
        }
        GetComponent<StatGameController>().DrawYoubi();


        //70日になっていたら終了
        if (StatGame.GetComponent<StatGame>().StatDays >= 70) { DaysEnd(); }
        else { 
        //曜日振り分け
        int Youbi = StatGame.GetComponent<StatGame>().StatDays;
        if (Youbi % 7 != 0)
        {
         //   Debug.Log("平日");
            WorkingDay(Mode);
        }
        else
        {
          //  Debug.Log("休日");
            HolyDay(Mode);
        }

        }
    }
    //休日の開始
    //mode=0　セーブなし開始
    //mode=1 セーブあり開始
    //mode=2　道中
    public void HolyDay(int Mode)
    {
        //SE
        //GetComponent<SoundController>().PlaySE("DoorOpen");



        //ステ描画
        GetComponent<StatGameController>().DrawSus();
        GetComponent<StatGameController>().DrawG();
        GetComponent<StatGameController>().DrawLv();
        GetComponent<StatGameController>().DrawDays();
        GetComponent<StatGameController>().DrawExp();


        //行動ステの算出
        if (Mode != 1) { 
        StatGame.GetComponent<StatGame>().PoliceCost1 = GetComponent<LvDesignController>().ActPolice(0,0);
        StatGame.GetComponent<StatGame>().PoliceReturn1 = GetComponent<LvDesignController>().ActPolice(1, 0);
        StatGame.GetComponent<StatGame>().PoliceCost2 = GetComponent<LvDesignController>().ActPolice(0, 1);
        StatGame.GetComponent<StatGame>().PoliceReturn2 = GetComponent<LvDesignController>().ActPolice(1, 1);

        StatGame.GetComponent<StatGame>().ChurchReturn1 = GetComponent<LvDesignController>().ActChurch(0);
        StatGame.GetComponent<StatGame>().ChurchReturn2 = GetComponent<LvDesignController>().ActChurch(1);
    
        StatGame.GetComponent<StatGame>().HomeReturn1 = GetComponent<LvDesignController>().ActHome(0);
        StatGame.GetComponent<StatGame>().HomeReturn2 = GetComponent<LvDesignController>().ActHome(1);

        string[] MarketItem1Moto = GetComponent<LvDesignController>().ActMarket();
        string[] MarketItem2Moto = GetComponent<LvDesignController>().ActMarket();
        string[] MarketItem1 = { MarketItem1Moto[0], MarketItem1Moto[1], MarketItem1Moto[2], MarketItem1Moto[3], MarketItem1Moto[4] };
        string[] MarketItem2 = { MarketItem2Moto[0], MarketItem2Moto[1], MarketItem2Moto[2], MarketItem2Moto[3], MarketItem2Moto[4] };

        StatGame.GetComponent<StatGame>().MarketItem1 = MarketItem1;
        StatGame.GetComponent<StatGame>().MarketCost1 = int.Parse(MarketItem1Moto[5]);
        StatGame.GetComponent<StatGame>().MarketItem2 = MarketItem2;
        StatGame.GetComponent<StatGame>().MarketCost2 = int.Parse(MarketItem2Moto[5]);

            //前の週の修正値を無効にする
            StatGame.GetComponent<StatGame>().ModifyG = 0;
            StatGame.GetComponent<StatGame>().ModifySus = 0;
        }

        GetComponent<StatGameController>().DrawModify();

        PoliceCost1.text = StatGame.GetComponent<StatGame>().PoliceCost1.ToString();
        PoliceCost1.color = GYellow;
        PoliceReturn1.text = StatGame.GetComponent<StatGame>().PoliceReturn1.ToString();
        PoliceReturn1.color = ExpBlue;
        PoliceCost2.text = StatGame.GetComponent<StatGame>().PoliceCost2.ToString();
        PoliceCost2.color = GYellow;
        PoliceReturn2.text = StatGame.GetComponent<StatGame>().PoliceReturn2.ToString();
        PoliceReturn2.color = ExpBlue;

        ChurchReturn1.text = StatGame.GetComponent<StatGame>().ChurchReturn1.ToString();
        ChurchReturn1.color = ExpBlue;
        ChurchReturn2.text = StatGame.GetComponent<StatGame>().ChurchReturn2.ToString();
        ChurchReturn2.color = GYellow;
        HomeReturn1.text = StatGame.GetComponent<StatGame>().HomeReturn1.ToString();
        HomeReturn1.color = ExpBlue;
        HomeReturn2.text = StatGame.GetComponent<StatGame>().HomeReturn2.ToString();



        //マーケットのアイテム描画
        GetComponent<StatGameController>().DrawMarketItem(StatGame.GetComponent<StatGame>().MarketItem1, StatGame.GetComponent<StatGame>().MarketCost1, 0);
        GetComponent<StatGameController>().DrawMarketItem(StatGame.GetComponent<StatGame>().MarketItem2, StatGame.GetComponent<StatGame>().MarketCost2, 1);


        //手持ちボタン表示
        Hand.SetActive(false);
        HandButton.SetActive(true);


        //初期化
        ActionDispose.SetActive(false);
        ActionEndOK.SetActive(false);

        HolyDaySelect();
    }

    public void HolyDaySelect()
    {
        GetComponent<StoryController>().SkipActionReadLine();

        MessageDraw("どこ に でかけますか？");
        //行先選択を表示
        PopupSelectAction.SetActive(true);
        ActButtonPolice.SetActive(false);
        ActButtonChurch.SetActive(false);
        ActButtonHome.SetActive(false);
        ActButtonMarket.SetActive(false);
        PopupAction.SetActive(false);
        ActMessageText.text = "";

        //チュートリアル 初休日
        if (StatPlayer.GetComponent<StatPlayer>().FlagTutorialFirstHolyday == 0)
        {
            //ボタン押せなくする
            ButtonPolice.GetComponent<Button>().interactable = false;
            ButtonChurch.GetComponent<Button>().interactable = false;
            ButtonHome.GetComponent<Button>().interactable = false;
            ButtonMarket.GetComponent<Button>().interactable = false;
            HandButton.GetComponent<Button>().interactable = false;

            GetComponent<TutorialController>().StartTutorial("FirstHolyday");
        }

    }

    public void ActionPolice()
    {
        ButtonActionBack.SetActive(true);
        PopupSelectAction.SetActive(false);
        PopupAction.SetActive(true);
        ActButtonPolice.SetActive(true);
        string ImagePath1 = "Face/" + "Miyako";
        Sprite SpriteImage1 = Resources.Load<Sprite>(ImagePath1);
        ActHito1.GetComponent<Image>().sprite = SpriteImage1;

        string ImagePath2 = "Face/" + "Police";
        Sprite SpriteImage2 = Resources.Load<Sprite>(ImagePath2);
        ActHito2.GetComponent<Image>().sprite = SpriteImage2;

        string ImagePath3 = "Place/" + "Police";
        Sprite SpriteImage3 = Resources.Load<Sprite>(ImagePath3);
        ActPlacePict.GetComponent<Image>().sprite = SpriteImage3;
        ActPlaceText.text = "こうばん";

        ActMessage.SetActive(true);
        GetComponent<StoryController>().ActionReadLine("なんの よう かね。\nいそがしいんだが…");
        MessageDraw("わいろコース を えらんでね");

    }
    public void ActionChurch()
    {
        ButtonActionBack.SetActive(true);
        PopupSelectAction.SetActive(false);
        PopupAction.SetActive(true);
        ActButtonChurch.SetActive(true);

        string ImagePath1 = "Face/" + "Miyako";
        Sprite SpriteImage1 = Resources.Load<Sprite>(ImagePath1);
        ActHito1.GetComponent<Image>().sprite = SpriteImage1;

        string ImagePath2 = "Face/" + "Church";
        Sprite SpriteImage2 = Resources.Load<Sprite>(ImagePath2);
        ActHito2.GetComponent<Image>().sprite = SpriteImage2;

        string ImagePath3 = "Place/" + "Church";
        Sprite SpriteImage3 = Resources.Load<Sprite>(ImagePath3);
        ActPlacePict.GetComponent<Image>().sprite = SpriteImage3;
        ActPlaceText.text = "きょうかい";

        ActMessage.SetActive(true);
        GetComponent<StoryController>().ActionReadLine("ようこそ。\nともに いのりましょう");

        MessageDraw("いのりコース を えらんでね");

    }
    public void ActionHome()
    {
        ButtonActionBack.SetActive(true);
        PopupSelectAction.SetActive(false);
        PopupAction.SetActive(true);
        ActButtonHome.SetActive(true);

        string ImagePath1 = "Face/" + "Miyako";
        Sprite SpriteImage1 = Resources.Load<Sprite>(ImagePath1);
        ActHito1.GetComponent<Image>().sprite = SpriteImage1;

        string ImagePath2 = "Face/" + "Morrel";
        Sprite SpriteImage2 = Resources.Load<Sprite>(ImagePath2);
        ActHito2.GetComponent<Image>().sprite = SpriteImage2;

        string ImagePath3 = "Place/" + "Home";
        Sprite SpriteImage3 = Resources.Load<Sprite>(ImagePath3);
        ActPlacePict.GetComponent<Image>().sprite = SpriteImage3;
        ActPlaceText.text = "ホーム";

        ActMessage.SetActive(true);
        GetComponent<StoryController>().ActionReadLine("しこみでも しようか。");

        MessageDraw("しこみコース を えらんでね");

    }
    public void ActionMarket()
    {
        ButtonActionBack.SetActive(true);
        PopupSelectAction.SetActive(false);
        PopupAction.SetActive(true);
        ActButtonMarket.SetActive(true);

        string ImagePath1 = "Face/" + "Miyako";
        Sprite SpriteImage1 = Resources.Load<Sprite>(ImagePath1);
        ActHito1.GetComponent<Image>().sprite = SpriteImage1;

        string ImagePath2 = "Face/" + "Market";
        Sprite SpriteImage2 = Resources.Load<Sprite>(ImagePath2);
        ActHito2.GetComponent<Image>().sprite = SpriteImage2;

        string ImagePath3 = "Place/" + "Market";
        Sprite SpriteImage3 = Resources.Load<Sprite>(ImagePath3);
        ActPlacePict.GetComponent<Image>().sprite = SpriteImage3;
        ActPlaceText.text = "やみいち";


        ActMessage.SetActive(true);
        GetComponent<StoryController>().ActionReadLine("らっしゃい…。\nいま あるのは これだけだ。");
        MessageDraw("しょうひん を えらんでね");

    }

    //行動の結果を反映
    public void ActionPoliceResult(int type)
    {
        ButtonActionBack.SetActive(false);
        GetComponent<StoryController>().SkipActionReadLine();

        int Cost;
        int Return;
        if (type == 0)
        {
            Cost = StatGame.GetComponent<StatGame>().PoliceCost1;
            Return = StatGame.GetComponent<StatGame>().PoliceReturn1;
        }
        else
        {
            Cost = StatGame.GetComponent<StatGame>().PoliceCost2;
            Return = StatGame.GetComponent<StatGame>().PoliceReturn2;
        }

        GetComponent<StatGameController>().GUp(Cost*-1);
        GetComponent<StatGameController>().SusUp(Return*-1);
        ActButtonPolice.SetActive(false);

        GetComponent<StoryController>().ActionReadLine("オヤ おとしもの だね？\nあずかって おこう");
        ActionEndOK.SetActive(true);
        //手持ちボタン非表示
        Hand.SetActive(false);
        HandButton.SetActive(false);
    }

    public void ActionChurchResult(int type)
    {
        ButtonActionBack.SetActive(false);
        GetComponent<StoryController>().SkipActionReadLine();
        int Return;
        if (type == 0)
        {
            Return = StatGame.GetComponent<StatGame>().ChurchReturn1;
            StatGame.GetComponent<StatGame>().ModifySus = Return * -1;
        

        }
        else
        {
            Return = StatGame.GetComponent<StatGame>().ChurchReturn2;
            StatGame.GetComponent<StatGame>().ModifyG = Return;
        }

        ActButtonChurch.SetActive(false);
        if (type == 0)
        {
            GetComponent<StoryController>().ActionReadLine("あなたの つみ が\nやわらぎます ように…");
        }
        else {
            GetComponent<StoryController>().ActionReadLine("あなたの うりあげ が\nふえます ように…");
        }
        GetComponent<StatGameController>().DrawModify();

        ActionEndOK.SetActive(true);
        //手持ちボタン非表示
        Hand.SetActive(false);
        HandButton.SetActive(false);

    }

    public void ActionHomeResult(int type)
    {
        ButtonActionBack.SetActive(false);
        GetComponent<StoryController>().SkipActionReadLine();
        int Return;
        if (type == 0)
        {
            Return = StatGame.GetComponent<StatGame>().HomeReturn1;
            float ThisSus = 0;
            int IntThisSus = 0;

            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    ThisSus = float.Parse(StatGame.GetComponent<StatGame>().Item1[4]);
                }
                else if (i == 1)
                {
                    ThisSus = float.Parse(StatGame.GetComponent<StatGame>().Item2[4]);
                }
                else if (i == 2)
                {
                    ThisSus = float.Parse(StatGame.GetComponent<StatGame>().Item3[4]);
                }
                else
                {
                    ThisSus = float.Parse(StatGame.GetComponent<StatGame>().Item4[4]);
                }

                ThisSus = ThisSus * (Return*-1 + 100) / 100;
                IntThisSus = Mathf.RoundToInt(ThisSus);

                if (i == 0)
                {
                    StatGame.GetComponent<StatGame>().Item1[4] = IntThisSus.ToString();
                }
                else if (i == 1)
                {
                    StatGame.GetComponent<StatGame>().Item2[4] = IntThisSus.ToString();
                }
                else if (i == 2)
                {
                    StatGame.GetComponent<StatGame>().Item3[4] = IntThisSus.ToString();
                }
                else
                {
                    StatGame.GetComponent<StatGame>().Item4[4] = IntThisSus.ToString();
                }

            }
        }
        else
        {
            Return = StatGame.GetComponent<StatGame>().HomeReturn2;
            float ThisPower = 0;
            int IntThisPower = 0;
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    ThisPower = float.Parse(StatGame.GetComponent<StatGame>().Item1[2]);
                }
                else if (i == 1)
                {
                    ThisPower = float.Parse(StatGame.GetComponent<StatGame>().Item2[2]);
                }
                else if (i == 2)
                {
                    ThisPower = float.Parse(StatGame.GetComponent<StatGame>().Item3[2]);
                }
                else
                {
                    ThisPower = float.Parse(StatGame.GetComponent<StatGame>().Item4[2]);
                }

                ThisPower = ThisPower * (Return  + 100) / 100;
                IntThisPower = Mathf.RoundToInt(ThisPower);

                if (i == 0)
                {
                    StatGame.GetComponent<StatGame>().Item1[2] = IntThisPower.ToString();
                }
                else if (i == 1)
                {
                    StatGame.GetComponent<StatGame>().Item2[2] = IntThisPower.ToString();
                }
                else if (i == 2)
                {
                    StatGame.GetComponent<StatGame>().Item3[2] = IntThisPower.ToString();
                }
                else
                {
                    StatGame.GetComponent<StatGame>().Item4[2] = IntThisPower.ToString();
                }
            }
        }
        ActButtonHome.SetActive(false);
        ButtonActionBack.SetActive(false);
        GetComponent<StoryController>().SkipActionReadLine();
        if (type == 0)
        {
            GetComponent<StoryController>().ActionReadLine("きよく なれ。\nきよく なれ。");
        }
        else {
            GetComponent<StoryController>().ActionReadLine("おいしく なれ。\nおいしく なれ。");
        }
        ActionEndOK.SetActive(true);
        //手持ちボタン非表示
        Hand.SetActive(false);
        HandButton.SetActive(false);

    }

    public void ActionMarketResult(int type)
    {
        int Cost = 0;
        if (type == 0)
        {
            StatGame.GetComponent<StatGame>().Item5 = StatGame.GetComponent<StatGame>().MarketItem1;
            Cost = StatGame.GetComponent<StatGame>().MarketCost1;
        }
        else {
            StatGame.GetComponent<StatGame>().Item5 = StatGame.GetComponent<StatGame>().MarketItem2;
            Cost = StatGame.GetComponent<StatGame>().MarketCost2;
        }
        GetComponent<StatGameController>().GUp(Cost * -1);

        ActButtonMarket.SetActive(false);
        ActMessageText.text = "まいど……。";

        ActionDispose.SetActive(true);
        //手持ちボタン非表示
        Hand.SetActive(false);
        HandButton.SetActive(false);

    }
    public void ActionMarketDispose()
    {
        PopupAction.SetActive(false);

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

        GetComponent<StatGameController>().DrawItem6();
        Button6Items.SetActive(true);
        Button6Items6.SetActive(true);
        Button6Items5.SetActive(true);
        iTween.MoveTo(Button6Items, iTween.Hash("y", 0, "time", 0.5f, "islocal", true, "easeType", iTween.EaseType.linear));

        SelectOK();
}
    //mode=0　セーブなし開始
    //mode=1 セーブあり開始
    //mode=2　道中
public void WorkingDay(int Mode)
    {

        //客の生成
        if (Mode==0)
        {
            //初期客の生成
            StatGame.GetComponent<StatGame>().FlagGlowCustomer = 0;
            GetComponent<LvDesignController>().MakeCustomerFirst();
        }
        else if(Mode==1)
        {
            //セーブ客の生成
            StatGame.GetComponent<StatGame>().FlagGlowCustomer = 0;
            GetComponent<LvDesignController>().MakeSavedCustomer();
        }
        else
        {
            //通常客の生成
            StatGame.GetComponent<StatGame>().FlagGlowCustomer = 0;
            GetComponent<LvDesignController>().MakeCustomerNormal();
        }

        CustomerStart1();
        CustomerStart2();
    }



    //メニュー画面への遷移
    public void GoMenu()
    {
        //客破壊
        CustomerDestroy();

        Menu.SetActive(true);
        HighScore.SetActive(false);
        AdsDelete.SetActive(false);
        Game.SetActive(false);
        BeforeStartAnim();
    }

    //メッセージ表示
    public void MessageDraw(string Text)
    {
        MessageText.text = Text;
    }

    
    public void BeforeStartAnim()
    {
        //スタート演出で動くものを上によせておく
        //開始時とメニューに戻った時に呼ぶ

        CustomerFieldBack.GetComponent<RectTransform>().localPosition = new Vector3(0f, 1000f, 0f);
        Button4Items1.GetComponent<RectTransform>().localPosition = new Vector3(-175f, -325f, 0f);
        Button4Items2.GetComponent<RectTransform>().localPosition = new Vector3(175f, -325f, 0f);
        Button4Items3.GetComponent<RectTransform>().localPosition = new Vector3(-175f, -495f, 0f);
        Button4Items4.GetComponent<RectTransform>().localPosition = new Vector3(175f, -495f, 0f);

        Button4Items1.GetComponent<RectTransform>().sizeDelta = new Vector2(335f,150f);
        Button4Items2.GetComponent<RectTransform>().sizeDelta = new Vector2(335f, 150f);
        Button4Items3.GetComponent<RectTransform>().sizeDelta = new Vector2(335f, 150f);
        Button4Items4.GetComponent<RectTransform>().sizeDelta = new Vector2(335f, 150f);
        Button4Items1.transform.Find("Mask").GetComponent<RectTransform>().sizeDelta = new Vector2(335f, 150f);
        Button4Items2.transform.Find("Mask").GetComponent<RectTransform>().sizeDelta = new Vector2(335f, 150f);
        Button4Items3.transform.Find("Mask").GetComponent<RectTransform>().sizeDelta = new Vector2(335f, 150f);
        Button4Items4.transform.Find("Mask").GetComponent<RectTransform>().sizeDelta = new Vector2(335f, 150f);
        Button4Items1.transform.Find("Mask/AllColor").GetComponent<RectTransform>().sizeDelta = new Vector2(0, 150f);
        Button4Items2.transform.Find("Mask/AllColor").GetComponent<RectTransform>().sizeDelta = new Vector2(0, 150f);
        Button4Items3.transform.Find("Mask/AllColor").GetComponent<RectTransform>().sizeDelta = new Vector2(0, 150f);
        Button4Items4.transform.Find("Mask/AllColor").GetComponent<RectTransform>().sizeDelta = new Vector2(0, 150f);
        Button4Items1.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        Button4Items2.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        Button4Items3.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        Button4Items4.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        Buns1.GetComponent<RectTransform>().localPosition = new Vector3(-600f, -305f, 0f);
        Buns2.GetComponent<RectTransform>().localPosition = new Vector3(600f, -510f, 0f);

        StatGame.GetComponent<StatGame>().UseItemNum = 0;
        StatGame.GetComponent<StatGame>().UseItemData = new string[] { "None", "None", "None", "None", "None" };

        SelectButtonOK.SetActive(true);
        SelectButtonOK.GetComponent<Button>().interactable = false;

        Button6Items.GetComponent<RectTransform>().localPosition = new Vector3(0f,800f,0f);
      //  Hand.GetComponent<RectTransform>().localPosition = new Vector3(0f, 345f, 0f);

        SelectItem1.GetComponent<RectTransform>().sizeDelta=new Vector2(335f, 255f);
        SelectItem2.GetComponent<RectTransform>().sizeDelta = new Vector2(335f, 255f);
        SelectItem1.GetComponent<RectTransform>().localPosition = new Vector3(-175f, -305, 0f);
        SelectItem2.GetComponent<RectTransform>().localPosition = new Vector3(175f, -305, 0f);
        SelectItemImage1.GetComponent<RectTransform>().localPosition = new Vector3(0, 5f, 0f);
        SelectItemImage2.GetComponent<RectTransform>().localPosition = new Vector3(0, 5f, 0f);


        //アイテム選択のＯＫボタンを切る

    }
    // Use this for initialization
    void Start()
    {
        BeforeStartAnim();
        SusGreen = new Color(255f / 255, 45f / 255, 58f / 255, 1.0f);
        GYellow = new Color(255f / 255, 226f / 255, 129f / 255, 1.0f);
        ExpBlue = new Color(24f / 255, 255f / 255, 150f / 255, 1.0f);


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
    void Awake()
    {
        //FPS固定
        Application.targetFrameRate = FPS;
    }
    // Update is called once per frame
    void Update()
    {


        ITweenCount = iTween.Count();
    }
}

