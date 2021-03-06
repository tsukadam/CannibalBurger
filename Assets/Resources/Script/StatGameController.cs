﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Coffee.UIExtensions;

//プレイ中のプレイヤーのステータス周りの変化と描写を行う
public class StatGameController : MonoBehaviour
{

    //プレイヤーstat
    public GameObject Script;
    public GameObject StatGame;
    //タップ切るための板
    public GameObject TapBlockSus;
    public GameObject TapBlockG;
    public GameObject TapBlockExp;

    //ステータス表示オブジェクトの取得

    public GameObject SelectItemItem1Image;
    public GameObject SelectItemItem2Image;
    public GameObject SelectItemItem3Image;
    public GameObject SelectItemItem4Image;
    public Text SelectItemItem1Power;
    public Text SelectItemItem2Power;
    public Text SelectItemItem3Power;
    public Text SelectItemItem4Power;
    public Text SelectItemItem1Sus;
    public Text SelectItemItem2Sus;
    public Text SelectItemItem3Sus;
    public Text SelectItemItem4Sus;


    public RectTransform BarSus;
    public GameObject BarSusOb;

    public RectTransform BarExp;
    public GameObject BarExpOb;

    public GameObject ObjectSus;
    public Text TextG;
    public Text TextLv;
    public Text TextDays;
    public Text TextSus;

    public GameObject Item4_1Image;
    public Text Item4_1Text;
    public Text Item4_1Power;
    public Text Item4_1Sus;

    public GameObject Item4_2Image;
    public Text Item4_2Text;
    public Text Item4_2Power;
    public Text Item4_2Sus;

    public GameObject Item4_3Image;
    public Text Item4_3Text;
    public Text Item4_3Power;
    public Text Item4_3Sus;

    public GameObject Item4_4Image;
    public Text Item4_4Text;
    public Text Item4_4Power;
    public Text Item4_4Sus;


    public GameObject Item6_1Image;
    public Text Item6_1Text;
    public Text Item6_1Power;
    public Text Item6_1Sus;

    public GameObject Item6_2Image;
    public Text Item6_2Text;
    public Text Item6_2Power;
    public Text Item6_2Sus;

    public GameObject Item6_3Image;
    public Text Item6_3Text;
    public Text Item6_3Power;
    public Text Item6_3Sus;

    public GameObject Item6_4Image;
    public Text Item6_4Text;
    public Text Item6_4Power;
    public Text Item6_4Sus;

    public GameObject Item6_5Image;
    public Text Item6_5Text;
    public Text Item6_5Power;
    public Text Item6_5Sus;

    public GameObject Item6_6Image;
    public Text Item6_6Text;
    public Text Item6_6Power;
    public Text Item6_6Sus;

    public GameObject DisPoseImage;
    public Text DisPoseText;
    public Text DisPosePower;
    public Text DisPoseSus;

    public GameObject GetImage;
    public Text GetText;
    public Text GetPower;
    public Text GetSus;

    public Color SusCol;
    public Color GCol;
    public Color ExpCol;
    public float ColorChangeSpan = 0.5f;

    public int SusGlowFlag = 0;

    public GameObject MarketPict1;
    public Text MarketName1;
    public Text MarketPower1;
    public Text MarketSus1;
    public Text MarketCost1;

    public GameObject MarketPict2;
    public Text MarketName2;
    public Text MarketPower2;
    public Text MarketSus2;
    public Text MarketCost2;

    public GameObject Modify;
    public GameObject ModifyYaSus;
    public GameObject ModifyYaG;
    public GameObject Youbi;

    private int SusGlowCount = 0;

    //イベントシステムの取得（処理中に切る場合がある）
    public GameObject EventSystem;

    //コルーチン
    public IEnumerator Routine;

    //ここから描写処理

    //アイテム描写

    //休日のアイテム描写
    //waku=0 左側 =1 右側　
    public void DrawMarketItem(string[] MarketItem, int cost, int waku)
    {

        string[] UseItem;
        Text UsePower;
        Text UseSus;
        Text UseName;
        GameObject UseImage;

        UseItem = MarketItem;

        if (waku == 0)
        {
            UsePower = MarketPower1;
            UseSus = MarketSus1;
            UseImage = MarketPict1;
            UseName = MarketName1;

            MarketCost1.text = cost.ToString();
        }
        else {
            UsePower = MarketPower2;
            UseSus = MarketSus2;
            UseImage = MarketPict2;
            UseName = MarketName2;

            MarketCost2.text = cost.ToString();
        }

        MarketCost1.color = GetComponent<GameController>().GYellow;
        MarketCost2.color = GetComponent<GameController>().GYellow;

        DrowItemAll(UseItem, UsePower, UseSus, UseName, UseImage);


    }

    //取得アイテムがない時のゲットアイテムの確認ポップアップ
    public void DrawGetItem(string[] GetItem)
    {

        string[] UseItem;
        Text UsePower;
        Text UseSus;
        Text UseName;
        GameObject UseImage;
        UseItem = GetItem;
        UsePower = GetPower;
        UseSus = GetSus;
        UseImage = GetImage;
        UseName = GetText;

        DrowItemAll(UseItem, UsePower, UseSus, UseName, UseImage);



    }

    //捨てるアイテムの確認ポップアップ
    public void DrawDisposeItem(string[] DisposeItem)
    {
        string[] UseItem;
        Text UsePower;
        Text UseSus;
        Text UseName;
        GameObject UseImage;
        UseItem = DisposeItem;
        UsePower = DisPosePower;
        UseSus = DisPoseSus;
        UseImage = DisPoseImage;
        UseName = DisPoseText;

        DrowItemAll(UseItem, UsePower, UseSus, UseName, UseImage);

    }
    //アイテムセレクト時に所持アイテム1～4を表示
    public void DrawItemSelectItem4()
    {
        string[] UseItem;
        Text UsePower;
        Text UseSus;

        GameObject UseImage;
        int Count = 0;
        while (Count < 6)
        {
            if (Count == 0)
            {
                UseItem = StatGame.GetComponent<StatGame>().Item1;
                UsePower = SelectItemItem1Power;
                UseSus = SelectItemItem1Sus;
                UseImage = SelectItemItem1Image; ;
            }
            else if (Count == 1)
            {
                UseItem = StatGame.GetComponent<StatGame>().Item2;
                UsePower = SelectItemItem2Power;
                UseSus = SelectItemItem2Sus;
                UseImage = SelectItemItem2Image;
            }
            else if (Count == 2)
            {
                UseItem = StatGame.GetComponent<StatGame>().Item3;
                UsePower = SelectItemItem3Power;
                UseSus = SelectItemItem3Sus;
                UseImage = SelectItemItem3Image;
            }

            else {
                UseItem = StatGame.GetComponent<StatGame>().Item4;
                UsePower = SelectItemItem4Power;
                UseSus = SelectItemItem4Sus;
                UseImage = SelectItemItem4Image;
            }

            DrowItemAll(UseItem, UsePower, UseSus, null, UseImage);
            Count++;
        }

    }

    //6Itemsに所持アイテム1～4を表示
    public void DrawItem6()
    {
        string[] UseItem;
        Text UsePower;
        Text UseSus;
        Text UseName;
        GameObject UseImage;
        int Count = 0;
        while (Count < 6)
        {
            if (Count == 0)
            {
                UseItem = StatGame.GetComponent<StatGame>().Item1;
                UsePower = Item6_1Power;
                UseSus = Item6_1Sus;
                UseImage = Item6_1Image;
                UseName = Item6_1Text;
            }
            else if (Count == 1)
            {
                UseItem = StatGame.GetComponent<StatGame>().Item2;
                UsePower = Item6_2Power;
                UseSus = Item6_2Sus;
                UseImage = Item6_2Image;
                UseName = Item6_2Text;
            }
            else if (Count == 2)
            {
                UseItem = StatGame.GetComponent<StatGame>().Item3;
                UsePower = Item6_3Power;
                UseSus = Item6_3Sus;
                UseImage = Item6_3Image;
                UseName = Item6_3Text;
            }
            else if (Count == 3)
            {
                UseItem = StatGame.GetComponent<StatGame>().Item4;
                UsePower = Item6_4Power;
                UseSus = Item6_4Sus;
                UseImage = Item6_4Image;
                UseName = Item6_4Text;
            }
            else if (Count == 4)
            {
                UseItem = StatGame.GetComponent<StatGame>().Item5;
                UsePower = Item6_5Power;
                UseSus = Item6_5Sus;
                UseImage = Item6_5Image;
                UseName = Item6_5Text;
            }
            else {
                UseItem = StatGame.GetComponent<StatGame>().Item6;
                UsePower = Item6_6Power;
                UseSus = Item6_6Sus;
                UseImage = Item6_6Image;
                UseName = Item6_6Text;
            }

            DrowItemAll(UseItem, UsePower, UseSus, UseName, UseImage);
            Count++;
        }

    }
    //4Itemsに所持アイテム1～4を表示
    public void DrawItem4()
    {
        string[] UseItem;
        Text UsePower;
        Text UseSus;
        Text UseName;
        GameObject UseImage;
        int Count = 0;
        while (Count < 4)
        {
            if (Count == 0)
            {
                UseItem = StatGame.GetComponent<StatGame>().Item1;
                UsePower = Item4_1Power;
                UseSus = Item4_1Sus;
                UseImage = Item4_1Image;
                UseName = Item4_1Text;
            }
            else if (Count == 1)
            {
                UseItem = StatGame.GetComponent<StatGame>().Item2;
                UsePower = Item4_2Power;
                UseSus = Item4_2Sus;
                UseImage = Item4_2Image;
                UseName = Item4_2Text;
            }
            else if (Count == 2)
            {
                UseItem = StatGame.GetComponent<StatGame>().Item3;
                UsePower = Item4_3Power;
                UseSus = Item4_3Sus;
                UseImage = Item4_3Image;
                UseName = Item4_3Text;
            }
            else {
                UseItem = StatGame.GetComponent<StatGame>().Item4;
                UsePower = Item4_4Power;
                UseSus = Item4_4Sus;
                UseImage = Item4_4Image;
                UseName = Item4_4Text;
            }

            DrowItemAll(UseItem, UsePower, UseSus, UseName, UseImage);
            Count++;
        }

    }

    //アイテム描画共用部分
    public void DrowItemAll(string[] UseItem,
    Text UsePower,
    Text UseSus,
    Text UseName,
    GameObject UseImage)
    {
        string NameText;
        string ImagePath;
        string ColorText;
        string PowerText;
        string SusText;
        Color ColorColor;
        Sprite SpriteImage;

        UsePower.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        UseSus.color = GetComponent<GameController>().SusGreen;

        if (UseName != null) { UseName.color = new Color(1.0f, 1.0f, 1.0f, 1.0f); }


        ImagePath = "Item/" + UseItem[1];
        SpriteImage = Resources.Load<Sprite>(ImagePath);
        ColorText = UseItem[3];
        SusText = UseItem[4];
        NameText = UseItem[0];

        if (UseName != null)
        {
            if (NameText == "None")
            {
                NameText = " ";
            }
            UseName.text = NameText;
        }
        if (ColorText == "None") { ColorText = "#000000"; }
        ColorColor = GetComponent<ColorGetter>().ToColor(ColorText);
        PowerText = UseItem[2];
        if (PowerText == "None") { PowerText = " "; }
        UsePower.text = PowerText;
        UseImage.GetComponent<Image>().sprite = SpriteImage;
        UseImage.GetComponent<Image>().color = ColorColor;
        // Debug.Log(SusText);
        if (SusText == "None" | SusText == "0") { SusText = " "; }
        UseSus.text = SusText;


    }





    //G増減
    public void GUp(int Count)
    {
        StartCoroutine("GUpCoroutine", Count);
    }
    IEnumerator GUpCoroutine(int Count)
    {
        TapBlockG.SetActive(true);
        EventSystem.SetActive(false);


        EventSystem.SetActive(false);
        int StatG = StatGame.GetComponent<StatGame>().StatG;//所持金
        int Moto = StatG;//元のステータス値
        int Goal = Moto + Count;//変化後のステータス値
        if (Goal < 0) { Goal = 0; }//結果が０以下なら０
        else if (Goal > 99999999) { Goal = 99999999; }//結果が９９９９９９９９以上なら９９９９９９９９
        int iCount = Count;
        if (Count >= 0)//減少方向のとき描画回数も負になってしまうので正にする（絶対値を取る）
        {
            iCount = iCount * 1;
        }
        else {
            iCount = iCount * -1;
        }
        int Memori = 1;//描画一回の変化量がコレ
        int i = 0;
        int Plus = 1;
        while (i < iCount)
        {
            if (iCount - i >= 10000000) { Memori = 10000000; Plus = 10000000; }
            else if (iCount - i >= 1000000) { Memori = 1000000; Plus = 1000000; }
            else if (iCount - i >= 100000) { Memori = 100000; Plus = 100000; }
            else if (iCount - i >= 10000) { Memori = 10000; Plus = 10000; }
            else if (iCount - i >= 1000) { Memori = 1000; Plus = 1000; }
            else if (iCount - i >= 100) { Memori = 100; Plus = 100; }
            else if (iCount - i >= 10) { Memori = 10; Plus = 10; }
            else { Memori = 1; Plus = 1; }

            if (Count >= 0)
            {
                StatG = StatG + Memori;
            }
            else {
                StatG = StatG - Memori;
            }
            if (StatG < 0) { StatG = 0; DrawG(); break; }
            if (StatG > 99999999) { StatG = 99999999; DrawG(); break; }
            StatGame.GetComponent<StatGame>().StatG = StatG;
            DrawG();
            yield return new WaitForSeconds(0.05f);//描画一回にかける遅延時間
            i = i + Plus;
        }
        yield return new WaitUntil(() => i >= iCount - 1);

        StatG = Goal;
        //        Debug.Log("StatG: " + Moto + " → " + Goal);

        TapBlockG.SetActive(false);
        EventSystem.SetActive(true);

    }


    //Sus増減
    public void SusUp(float Count)
    {

        StartCoroutine("SusUpCoroutine", Count);
    }
    IEnumerator SusUpCoroutine(float Count)
    {
        TapBlockSus.SetActive(true);
        EventSystem.SetActive(false);
        float StatSus = StatGame.GetComponent<StatGame>().StatSus;
        float AnimeSus = StatGame.GetComponent<StatGame>().StatSus;

        float BarSize = 320;//バー全体の長さ
        float MemoriSize = 10;//１目盛りの長さ
        float Moto = StatSus;//元のステータス値
        float Goal = Moto + Count;//変化後のステータス値
        if (Goal < 0) { Goal = 0; }//結果が０以下なら０
        else if (Goal > 100) { Goal = 100.0f; Count = 100 - Moto; }//結果が１００以上なら１００
        float Memori = 100 / BarSize * MemoriSize;//描画一回の変化量がコレ（10px動く分）
        float iCount = Mathf.Abs(Count / Memori);
                float Start = Moto - Moto % Memori;//開始地点を丸める


        AnimeSus = Start;
        int i;
        for (i = 1; i <= iCount; i++)
        {

            if (Count >= 0)
            {
                AnimeSus += Memori;
            }
            else {
                AnimeSus -= Memori;
            }
            DrawSus2(AnimeSus);
            DrawSusNum();
            if (AnimeSus < 0) { AnimeSus = 0; break; }
            if (AnimeSus > 100) { AnimeSus = 100; break; }
            yield return new WaitForSeconds(0.05f);//描画一回にかける遅延時間
        }
        StatGame.GetComponent<StatGame>().StatSus = Goal;
        DrawSus();
        DrawSusNum();
        //       Debug.Log("StatSus: " + Moto + " → " + Goal);
        TapBlockSus.SetActive(false);
        EventSystem.SetActive(true);
    }

    //Exp描画飛ばし
    public void ExpSkip(int PlusExp, int BeforeExp)
    {
        //LvMAXでない時のみ作動
        if (StatGame.GetComponent<StatGame>().StatLv < 15)
        {
            if (Routine != null) { StopCoroutine(Routine); }//Expの動きを止める
            StatGame.GetComponent<StatGame>().StatExp = PlusExp+BeforeExp;

            DrawExp();
            TapBlockExp.SetActive(false);
            EventSystem.SetActive(true);
            //レベルアップ判定に飛ばす
          // GetComponent<GameController>().LevelUp();
        }
    }
        //Exp増減
        public void ExpUp(int Count)
    {
        Routine = null;
        Routine = ExpUpCoroutine(Count);
        StartCoroutine(Routine);
    }
    IEnumerator ExpUpCoroutine(int Count)
    {
        TapBlockExp.SetActive(true);
        EventSystem.SetActive(false);
        int StatSus = StatGame.GetComponent<StatGame>().StatExp;
        float AnimeSus = StatGame.GetComponent<StatGame>().StatExp;

        float BarSize = 720;//バー全体の長さ
        float MemoriSize = 10;//１目盛りの長さ
        int Moto = StatSus;//元のステータス値
        int Goal = Moto + Count;//変化後のステータス値
        if (Goal < 0) { Goal = 0; }//結果が０以下なら０
        else if (Goal > 100) { Goal = 100; Count = 100 - Moto; }//結果が１００以上なら１００
        float Memori = 100 / BarSize * MemoriSize;//描画一回の変化量がコレ（10px動く分）
        float iCount = Mathf.Abs(Count / Memori);
        float Start = Moto - Moto % Memori;//開始地点を丸める

        AnimeSus = Start;
        int i;
        for (i = 1; i <= iCount; i++)
        {

            if (Count >= 0)
            {
                AnimeSus += Memori;
            }
            else {
                AnimeSus -= Memori;
            }
            DrawExp2(AnimeSus);
            if (AnimeSus < 0) { AnimeSus = 0; break; }
            if (AnimeSus > 100) { AnimeSus = 100; break; }
                        //yield return new WaitForSeconds(0.5f);//描画一回にかける遅延時間（デバッグ用）

                        yield return new WaitForSeconds(0.5f / iCount);//描画一回にかける遅延時間
        }
        StatGame.GetComponent<StatGame>().StatExp = Goal;
        DrawExp();
        //       Debug.Log("StatSus: " + Moto + " → " + Goal);
        TapBlockExp.SetActive(false);
        EventSystem.SetActive(true);
        /*        TapBlockExp.SetActive(true);
                EventSystem.SetActive(false);


                int StatExp = StatGame.GetComponent<StatGame>().StatExp;
                int AnimeExp = StatGame.GetComponent<StatGame>().StatExp;

                int Moto = StatExp;//元のステータス値
                int Goal = Moto + Count;//変化後のステータス値
                if (Goal < 0) { Goal = 0; }//結果が０以下なら０
                else if (Goal > 100) { Goal = 100; Count = 100 - Moto; }//結果が１００以上なら１００
                int iCount = Count;
                int Start = Moto;//開始地点を丸める
                float AnimeExpFloat = (float)Start;

                int i;
                for (i = 1; i <= iCount; i++)
                {
                    AnimeExpFloat += 1;
                    if (AnimeExp < 0) { AnimeExp = 0; break; }
                    if (AnimeExp > 100) { AnimeExp = 100; break; }
                    DrawExp2(AnimeExpFloat);
                    yield return new WaitForSeconds(0.005f);//描画一回にかける遅延時間
                }
                StatGame.GetComponent<StatGame>().StatExp = Goal;


                DrawExp();
                TapBlockExp.SetActive(false);
                EventSystem.SetActive(true);
                */
    }

    //Lv増減
    public void LvUp(int Count)
    {
        StatGame.GetComponent<StatGame>().StatLv += Count;

        //レベルデザイン情報の読み込み
        GetComponent<LvDesignController>().GetLvDesignData();

        DrawLv();
    }

    //Days増減
    public void DaysUp(int Count)
    {
        StatGame.GetComponent<StatGame>().StatDays += Count;
        DrawDays();
    }


    //Ｇ描画
    public void DrawG()
    {
        GCol = GetComponent<GameController>().GYellow;
        int StatG = StatGame.GetComponent<StatGame>().StatG;//所持金
        string StatGText = StatG.ToString();
        TextG.color = GCol;
        TextG.text = StatGText;
    }
    //Sus数字描画
    public void DrawSusNum()
    {
        float StatSus = StatGame.GetComponent<StatGame>().StatSus;
        StatSus=Mathf.FloorToInt(StatSus);
        string StatSusText = StatSus.ToString();
        TextSus.text = StatSusText;

    }
    //Sus描画
    public void DrawSus()
    {

 float StatSus = StatGame.GetComponent<StatGame>().StatSus;
        float BarSize = 320;
        float MemoriSize = 10;//１目盛りの長さ
        float Memori = 100 / BarSize * MemoriSize;//描画一回の変化量がコレ（10px動く分）
        float End = StatSus-StatSus % Memori;//終了地点を丸める

        float iCount = Mathf.Ceil(End / Memori);

 
        if (End > 100)
        {
            BarSus.sizeDelta = new Vector2(320, 70);

        }
        else if (End <= 0)
        {
            BarSus.sizeDelta = new Vector2(0, 70);

        }
        else {
            BarSus.sizeDelta = new Vector2(10 * iCount, 70);
        }



    }
    //Sus描画（アニメーション用）
    public void DrawSus2(float AnimeSus)
    {
        BarSus.sizeDelta = new Vector2(320 * AnimeSus / 100, 70);
    }

    //Exp描画（アニメーション用）
    public void DrawExp2(float AnimeExp)
    {
        //ExpCol = GetComponent<GameController>().ExpBlue;
        BarExpOb.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        BarExp.sizeDelta = new Vector2(720 * AnimeExp / 100, 25);
    }

    //曜日描画
    public void DrawYoubi() {
        int Day = StatGame.GetComponent<StatGame>().StatDays;
        string ImagePath="";
        Sprite SpriteImage;

        if (Day % 7 == 1){ImagePath = "Stat/" + "you_mon";}
        else if (Day % 7 == 2) { ImagePath = "Stat/" + "you_tue"; }
        else if (Day % 7 == 3) { ImagePath = "Stat/" + "you_wed"; }
        else if (Day % 7 == 4) { ImagePath = "Stat/" + "you_thu"; }
        else if (Day % 7 == 5) { ImagePath = "Stat/" + "you_fri"; }
        else if (Day % 7 == 6) { ImagePath = "Stat/" + "you_sat"; }
        else{ ImagePath = "Stat/" + "you_sun"; }

        SpriteImage = Resources.Load<Sprite>(ImagePath);
        Youbi.GetComponent<Image>().sprite = SpriteImage;

    }

    //Modify描画
    public void DrawModify()
    {
        int ModifyGValue = StatGame.GetComponent<StatGame>().ModifyG;
        int ModifySusValue = StatGame.GetComponent<StatGame>().ModifySus;
        ModifyYaG.GetComponent<Image>().color = GetComponent<GameController>().GYellow;
        ModifyYaSus.GetComponent<Image>().color = GetComponent<GameController>().ExpBlue;

        if (ModifyGValue != 0& ModifySusValue != 0) { Debug.Log("SusとG両方修正は出来ません　両方表示しません"); }
        else if (ModifyGValue != 0 & ModifySusValue == 0)
        {
            ModifyYaG.SetActive(true);
            ModifyYaSus.SetActive(false);
        }
        else if (ModifySusValue != 0 & ModifyGValue == 0)
        {
            ModifyYaSus.SetActive(true);
            ModifyYaG.SetActive(false);
        
        }
        else
        {
            ModifyYaSus.SetActive(false);
            ModifyYaG.SetActive(false);

        }
    }
    //Exp描画
    public void DrawExp()
    {
        int StatExp = StatGame.GetComponent<StatGame>().StatExp;
        BarExpOb.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);


        float BarSize = 720;
        float MemoriSize = 10;//１目盛りの長さ
        float Memori = 100 / BarSize * MemoriSize;//描画一回の変化量がコレ（10px動く分）
        float End = StatExp - StatExp % Memori;//終了地点を丸める

        float iCount = Mathf.Ceil(End / Memori);

        if (End > 100)
        {
            BarExp.sizeDelta = new Vector2(720, 25);

        }
        else if (End <= 0)
        {
            BarExp.sizeDelta = new Vector2(0, 25);

        }
        else
        {

            BarExp.sizeDelta = new Vector2(10 * iCount, 25);
        }


    }

    //レベル描画
    public void DrawLv()
    {
        int StatLv = StatGame.GetComponent<StatGame>().StatLv;
        string StatLvText = StatLv.ToString();
        TextLv.text = StatLvText;
    }
    //日付描画
    public void DrawDays()
    {
        int StatDays = StatGame.GetComponent<StatGame>().StatDays;
        string StatDaysText = StatDays.ToString();
        TextDays.text = StatDaysText;
    }


    // Use this for initialization
    void Start()
    {
        Point(TextG);
        Point(SelectItemItem1Power);
        Point(SelectItemItem2Power);
        Point(SelectItemItem3Power);
        Point(SelectItemItem4Power);
        Point(SelectItemItem1Sus);
        Point(SelectItemItem2Sus);
        Point(SelectItemItem3Sus);
        Point(SelectItemItem4Sus);
        Point(TextLv);
        Point(TextDays);
        Point(TextSus);
        Point(Item4_1Text);
        Point(Item4_1Power);
        Point(Item4_1Sus);
        Point(Item4_2Text);
        Point(Item4_2Power);
        Point(Item4_2Sus);
        Point(Item4_3Text);
        Point(Item4_3Power);
        Point(Item4_3Sus);
        Point(Item4_4Text);
        Point(Item4_4Power);
        Point(Item4_4Sus);
        Point(Item6_1Text);
        Point(Item6_1Power);
        Point(Item6_1Sus);
        Point(Item6_2Text);
        Point(Item6_2Power);
        Point(Item6_2Sus);
        Point(Item6_3Text);
        Point(Item6_3Power);
        Point(Item6_3Sus);
        Point(Item6_4Text);
        Point(Item6_4Power);
        Point(Item6_4Sus);
        Point(Item6_5Text);
        Point(Item6_5Power);
        Point(Item6_5Sus);
        Point(Item6_6Text);
        Point(Item6_6Power);
        Point(Item6_6Sus);
        Point(DisPoseText);
        Point(DisPosePower);
        Point(DisPoseSus);
        Point(GetText);
        Point(GetPower);
        Point(GetSus);
        Point(MarketName1);
        Point(MarketPower1);
        Point(MarketSus1);
        Point(MarketCost1);
        Point(MarketName2);
        Point(MarketPower2);
        Point(MarketSus2);
        Point(MarketCost2);

}

    //テキストのぼやけを切る
    public void Point(Text TargetText)
    {
        TargetText.font.material.mainTexture.filterMode = FilterMode.Point;

    }



    public void SusGlow()
    {
        SusGlowFlag = 1;
        BarSusOb.GetComponent<UIEffect>().enabled = true;
        BarSus.GetComponent<UIEffect>().shadowColor=SusCol;

        Hashtable hashGlow = new Hashtable(){
            {"from", 0},
            {"to", ColorChangeSpan},
            {"time", 1.0f},
            {"delay", 0f},
            {"easeType",iTween.EaseType.linear},
            {"loopType",iTween.LoopType.pingPong},
            {"onupdate", "OnUpdateSusGlow"},
            {"onupdatetarget", gameObject},
        };
        iTween.ValueTo(gameObject, hashGlow);

    }


    IEnumerator SusGlowStop()
            {

        BarSusOb.GetComponent<UIEffect>().enabled = false;
        iTween.Stop(Script, "value");
        yield return new WaitForSeconds(0.01f);
        SusGlowFlag = 0;
        yield return null;
    }


    public void OnUpdateSusGlow(float NextPoint)
    {
        Color NextGlow = BarSus.GetComponent<UIEffect>().shadowColor;
        float NextA;
        NextA = NextPoint;
        NextGlow.a = NextA;

        BarSusOb.GetComponent<UIEffect>().shadowColor = NextGlow;

        Color NextCol = BarSusOb.GetComponent<Image>().color;
        float NextR = NextCol.r;
        float NextG = NextCol.g;
        float NextB = NextCol.b;

            NextR += NextPoint*3;
            NextG += NextPoint*3;
            NextB += NextPoint*3/2;

        NextCol = new UnityEngine.Color(NextR, NextG, NextB, 1.0f);

        BarSusOb.GetComponent<Image>().color = NextCol;
    }


    // Update is called once per frame
    void Update()
    {
        SusGlowCount++;
        if (SusGlowCount >0)
        {
            if (StatGame.GetComponent<StatGame>().StatSus > 90)
            {
                ObjectSus.GetComponent<Image>().color = new Color(1f, 0, 0, 1f);
                SusCol = new Color(1f, 0, 0, 1f);
                if (SusGlowFlag == 0)
                {
                    SusGlow();
                }
            }
            else
            {
                if (SusGlowFlag == 1)
                {
                    StartCoroutine("SusGlowStop");
                }
                ObjectSus.GetComponent<Image>().color = GetComponent<GameController>().SusGreen;
                SusCol = GetComponent<GameController>().SusGreen;
            }
        }
    }
}
