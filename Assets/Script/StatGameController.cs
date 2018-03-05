using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;
//プレイ中のプレイヤーのステータス周りの変化と描写を行う
public class StatGameController : MonoBehaviour
{
    //プレイヤーstat
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


    public RectTransform BarSus;

    public RectTransform BarExp;

    public GameObject ObjectSus;
    public Text TextG;
    public Text TextLv;
    public Text TextDays;

    public GameObject Item4_1Image;
    public Text Item4_1Text;
    public Text Item4_1Power;

    public GameObject Item4_2Image;
    public Text Item4_2Text;
    public Text Item4_2Power;

    public GameObject Item4_3Image;
    public Text Item4_3Text;
    public Text Item4_3Power;

    public GameObject Item4_4Image;
    public Text Item4_4Text;
    public Text Item4_4Power;


    public GameObject Item6_1Image;
    public Text Item6_1Text;
    public Text Item6_1Power;

    public GameObject Item6_2Image;
    public Text Item6_2Text;
    public Text Item6_2Power;

    public GameObject Item6_3Image;
    public Text Item6_3Text;
    public Text Item6_3Power;

    public GameObject Item6_4Image;
    public Text Item6_4Text;
    public Text Item6_4Power;

    public GameObject Item6_5Image;
    public Text Item6_5Text;
    public Text Item6_5Power;

    public GameObject Item6_6Image;
    public Text Item6_6Text;
    public Text Item6_6Power;

    public GameObject DisPoseImage;
    public Text DisPoseText;
    public Text DisPosePower;

    public GameObject GetImage;
    public Text GetText;
    public Text GetPower;

    //イベントシステムの取得（処理中に切る場合がある）
    public GameObject EventSystem;

    //ここから描写処理

    //アイテム描写
    //取得アイテムがない時のゲットアイテムの確認ポップアップ
    public void DrawGetItem(string[] GetItem)
    {

        string ImagePath;
        string ColorText;
        string PowerText;
        string NameText;
        Color ColorColor;
        Sprite SpriteImage;

        ImagePath = "Item/" + GetItem[1];
        SpriteImage = Resources.Load<Sprite>(ImagePath);
        ColorText = GetItem[3];
        if (ColorText == "") { ColorText = "#000000"; }
        ColorColor = GetComponent<ColorGetter>().ToColor(ColorText);
        GetImage.GetComponent<Image>().sprite = SpriteImage;
        PowerText = GetItem[2];
        if (PowerText == "None") { PowerText = " "; }
        GetPower.text = PowerText;
        NameText = GetItem[0];
        if (NameText == "None") { NameText = " "; }
        GetText.text = NameText;
        GetImage.GetComponent<Image>().color = ColorColor;



    }

    //捨てるアイテムの確認ポップアップ
    public void DrawDisposeItem(string[] DisposeItem)
    {

        string ImagePath;
        string ColorText;
        string PowerText;
        string NameText;
        Color ColorColor;
        Sprite SpriteImage;

        ImagePath = "Item/" + DisposeItem[1];
        SpriteImage = Resources.Load<Sprite>(ImagePath);
        ColorText = DisposeItem[3];
        if (ColorText == "") { ColorText = "#000000"; }
        ColorColor = GetComponent<ColorGetter>().ToColor(ColorText);
        DisPoseImage.GetComponent<Image>().sprite = SpriteImage;
        PowerText = DisposeItem[2];
        if (PowerText == "None") { PowerText = " "; }
        DisPosePower.text = PowerText;
        NameText = DisposeItem[0];
        if (NameText == "None") { NameText = " "; }
        DisPoseText.text = NameText;
        DisPoseImage.GetComponent<Image>().color = ColorColor;



    }
    //アイテムセレクト時に所持アイテム1～4を表示
    public void DrawItemSelectItem4()
    {
        string ImagePath;
        string ColorText;
        string PowerText;
            Color ColorColor;
        Sprite SpriteImage;

        ImagePath = "Item/" + StatGame.GetComponent<StatGame>().Item1[1];
        SpriteImage = Resources.Load<Sprite>(ImagePath);
        ColorText = StatGame.GetComponent<StatGame>().Item1[3];
        if (ColorText == "None") { ColorText = "#000000"; }
        ColorColor = GetComponent<ColorGetter>().ToColor(ColorText);
        SelectItemItem1Image.GetComponent<Image>().sprite = SpriteImage;
        PowerText=StatGame.GetComponent<StatGame>().Item1[2];
        if (PowerText == "None") { PowerText = " "; }
        SelectItemItem1Power.text = PowerText;
        SelectItemItem1Image.GetComponent<Image>().color = ColorColor;

        ImagePath = "Item/" + StatGame.GetComponent<StatGame>().Item2[1];
        SpriteImage = Resources.Load<Sprite>(ImagePath);
        ColorText = StatGame.GetComponent<StatGame>().Item2[3];
        if (ColorText == "None") { ColorText = "#000000"; }
        ColorColor = GetComponent<ColorGetter>().ToColor(ColorText);
        SelectItemItem2Image.GetComponent<Image>().sprite = SpriteImage;
        PowerText = StatGame.GetComponent<StatGame>().Item2[2];
        if (PowerText == "None") { PowerText = " "; }
        SelectItemItem2Power.text = PowerText;
        SelectItemItem2Image.GetComponent<Image>().color = ColorColor;

        ImagePath = "Item/" + StatGame.GetComponent<StatGame>().Item3[1];
        SpriteImage = Resources.Load<Sprite>(ImagePath);
        ColorText = StatGame.GetComponent<StatGame>().Item3[3];
        if (ColorText == "None") { ColorText = "#000000"; }
        ColorColor = GetComponent<ColorGetter>().ToColor(ColorText);
        SelectItemItem3Image.GetComponent<Image>().sprite = SpriteImage;
        PowerText = StatGame.GetComponent<StatGame>().Item3[2];
        if (PowerText == "None") { PowerText = " "; }
        SelectItemItem3Power.text = PowerText;
        SelectItemItem3Image.GetComponent<Image>().color = ColorColor;

        ImagePath = "Item/" + StatGame.GetComponent<StatGame>().Item4[1];
        SpriteImage = Resources.Load<Sprite>(ImagePath);
        ColorText = StatGame.GetComponent<StatGame>().Item4[3];
        if (ColorText == "None") { ColorText = "#000000"; }
        ColorColor = GetComponent<ColorGetter>().ToColor(ColorText);
        SelectItemItem4Image.GetComponent<Image>().sprite = SpriteImage;
        PowerText = StatGame.GetComponent<StatGame>().Item4[2];
        if (PowerText == "None") { PowerText = " "; }
        SelectItemItem4Power.text = PowerText;
        SelectItemItem4Image.GetComponent<Image>().color = ColorColor;

    }
    //6Itemsに所持アイテム1～4を表示
    public void DrawItem6()
    {
        string ImagePath;
        string ColorText;
        string PowerText;
        string NameText;

        Color ColorColor;
        Sprite SpriteImage;

        ImagePath = "Item/" + StatGame.GetComponent<StatGame>().Item1[1];
        SpriteImage = Resources.Load<Sprite>(ImagePath);
        ColorText = StatGame.GetComponent<StatGame>().Item1[3];
        if (ColorText == "None") { ColorText = "#000000"; }
        ColorColor = GetComponent<ColorGetter>().ToColor(ColorText);
        Item6_1Image.GetComponent<Image>().sprite = SpriteImage;
        NameText = StatGame.GetComponent<StatGame>().Item1[0];
        if (NameText == "None") { NameText = " "; }
        Item6_1Text.text = NameText;
        PowerText = StatGame.GetComponent<StatGame>().Item1[2];
        if (PowerText == "None") { PowerText = " "; }
        Item6_1Power.text = PowerText;
        Item6_1Image.GetComponent<Image>().color = ColorColor;

        ImagePath = "Item/" + StatGame.GetComponent<StatGame>().Item2[1];
        SpriteImage = Resources.Load<Sprite>(ImagePath);
        ColorText = StatGame.GetComponent<StatGame>().Item2[3];
        if (ColorText == "None") { ColorText = "#000000"; }
        ColorColor = GetComponent<ColorGetter>().ToColor(ColorText);
        Item6_2Image.GetComponent<Image>().sprite = SpriteImage;
        NameText = StatGame.GetComponent<StatGame>().Item2[0];
        if (NameText == "None") { NameText = " "; }
        Item6_2Text.text = NameText;
        PowerText = StatGame.GetComponent<StatGame>().Item2[2];
        if (PowerText == "None") { PowerText = " "; }
        Item6_2Power.text = PowerText;
        Item6_2Image.GetComponent<Image>().color = ColorColor;

        ImagePath = "Item/" + StatGame.GetComponent<StatGame>().Item3[1];
        SpriteImage = Resources.Load<Sprite>(ImagePath);
        ColorText = StatGame.GetComponent<StatGame>().Item3[3];
        if (ColorText == "None") { ColorText = "#000000"; }
        ColorColor = GetComponent<ColorGetter>().ToColor(ColorText);
        Item6_3Image.GetComponent<Image>().sprite = SpriteImage;
        NameText = StatGame.GetComponent<StatGame>().Item3[0];
        if (NameText == "None") { NameText = " "; }
        Item6_3Text.text = NameText;
        PowerText = StatGame.GetComponent<StatGame>().Item3[2];
        if (PowerText == "None") { PowerText = " "; }
        Item6_3Power.text = PowerText;
        Item6_3Image.GetComponent<Image>().color = ColorColor;

        ImagePath = "Item/" + StatGame.GetComponent<StatGame>().Item4[1];
        SpriteImage = Resources.Load<Sprite>(ImagePath);
        ColorText = StatGame.GetComponent<StatGame>().Item4[3];
        if (ColorText == "None") { ColorText = "#000000"; }
        ColorColor = GetComponent<ColorGetter>().ToColor(ColorText);
        Item6_4Image.GetComponent<Image>().sprite = SpriteImage;
        NameText = StatGame.GetComponent<StatGame>().Item4[0];
        if (NameText == "None") { NameText = " "; }
        Item6_4Text.text = NameText;
        PowerText = StatGame.GetComponent<StatGame>().Item4[2];
        if (PowerText == "None") { PowerText = " "; }
        Item6_4Power.text = PowerText;
        Item6_4Image.GetComponent<Image>().color = ColorColor;

        ImagePath = "Item/" + StatGame.GetComponent<StatGame>().Item5[1];
        SpriteImage = Resources.Load<Sprite>(ImagePath);
        ColorText = StatGame.GetComponent<StatGame>().Item5[3];
        if (ColorText == "None") { ColorText = "#000000"; }
        ColorColor = GetComponent<ColorGetter>().ToColor(ColorText);
        Item6_5Image.GetComponent<Image>().sprite = SpriteImage;
        NameText = StatGame.GetComponent<StatGame>().Item5[0];
        if (NameText == "None") { NameText = " "; }
        Item6_5Text.text = NameText;
        PowerText = StatGame.GetComponent<StatGame>().Item5[2];
        if (PowerText == "None") { PowerText = " "; }
        Item6_5Power.text = PowerText;
        Item6_5Image.GetComponent<Image>().color = ColorColor;

        ImagePath = "Item/" + StatGame.GetComponent<StatGame>().Item6[1];
        SpriteImage = Resources.Load<Sprite>(ImagePath);
        ColorText = StatGame.GetComponent<StatGame>().Item6[3];
        if (ColorText == "None") { ColorText = "#000000"; }
        ColorColor = GetComponent<ColorGetter>().ToColor(ColorText);
        Item6_6Image.GetComponent<Image>().sprite = SpriteImage;
        NameText = StatGame.GetComponent<StatGame>().Item6[0];
        if (NameText == "None") { NameText = " "; }
        Item6_6Text.text = NameText;
        PowerText = StatGame.GetComponent<StatGame>().Item6[2];
        if (PowerText == "None") { PowerText = " "; }
        Item6_6Power.text = PowerText;
        Item6_6Image.GetComponent<Image>().color = ColorColor;

    }
    //4Itemsに所持アイテム1～4を表示
    public void DrawItem4()
    {
        string ImagePath;
        string ColorText;
        string PowerText;
        string NameText;

        Color ColorColor;
        Sprite SpriteImage;

        Item4_1Text.color=new Color(1.0f,1.0f,1.0f,1.0f);
        Item4_1Power.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        Item4_2Text.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        Item4_2Power.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        Item4_3Text.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        Item4_3Power.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        Item4_4Text.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        Item4_4Power.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);


        ImagePath = "Item/" + StatGame.GetComponent<StatGame>().Item1[1];
        SpriteImage = Resources.Load<Sprite>(ImagePath);
        ColorText = StatGame.GetComponent<StatGame>().Item1[3];
        if (ColorText == "None") { ColorText = "#000000"; }
        ColorColor = GetComponent<ColorGetter>().ToColor(ColorText);
        Item4_1Image.GetComponent<Image>().sprite = SpriteImage;
        NameText = StatGame.GetComponent<StatGame>().Item1[0];
        if (NameText == "None") { NameText = " "; }
        Item4_1Text.text = NameText;
        PowerText = StatGame.GetComponent<StatGame>().Item1[2];
        if (PowerText == "None") { PowerText = " "; }
        Item4_1Power.text = PowerText;
        Item4_1Image.GetComponent<Image>().color = ColorColor;

        ImagePath = "Item/" + StatGame.GetComponent<StatGame>().Item2[1];
        SpriteImage = Resources.Load<Sprite>(ImagePath);
        ColorText = StatGame.GetComponent<StatGame>().Item2[3];
        if (ColorText == "None") { ColorText = "#000000"; }
        ColorColor = GetComponent<ColorGetter>().ToColor(ColorText);
        Item4_2Image.GetComponent<Image>().sprite = SpriteImage;
        NameText = StatGame.GetComponent<StatGame>().Item2[0];
        if (NameText == "None") { NameText = " "; }
        Item4_2Text.text = NameText;
        PowerText = StatGame.GetComponent<StatGame>().Item2[2];
        if (PowerText == "None") { PowerText = " "; }
        Item4_2Power.text = PowerText;
        Item4_2Image.GetComponent<Image>().color = ColorColor;

        ImagePath = "Item/" + StatGame.GetComponent<StatGame>().Item3[1];
        SpriteImage = Resources.Load<Sprite>(ImagePath);
        ColorText = StatGame.GetComponent<StatGame>().Item3[3];
        if (ColorText == "None") { ColorText = "#000000"; }
        ColorColor = GetComponent<ColorGetter>().ToColor(ColorText);
        Item4_3Image.GetComponent<Image>().sprite = SpriteImage;
        NameText = StatGame.GetComponent<StatGame>().Item3[0];
        if (NameText == "None") { NameText = " "; }
        Item4_3Text.text = NameText;
        PowerText = StatGame.GetComponent<StatGame>().Item3[2];
        if (PowerText == "None") { PowerText = " "; }
        Item4_3Power.text = PowerText;
        Item4_3Image.GetComponent<Image>().color = ColorColor;

        ImagePath = "Item/" + StatGame.GetComponent<StatGame>().Item4[1];
        SpriteImage = Resources.Load<Sprite>(ImagePath);
        ColorText = StatGame.GetComponent<StatGame>().Item4[3];
        if (ColorText == "None") { ColorText = "#000000"; }
        ColorColor = GetComponent<ColorGetter>().ToColor(ColorText);
        Item4_4Image.GetComponent<Image>().sprite = SpriteImage;
        NameText = StatGame.GetComponent<StatGame>().Item4[0];
        if (NameText == "None") { NameText = " "; }
        Item4_4Text.text = NameText;
        PowerText = StatGame.GetComponent<StatGame>().Item4[2];
        if (PowerText == "None") { PowerText = " "; }
        Item4_4Power.text = PowerText;
        Item4_4Image.GetComponent<Image>().color = ColorColor;

        //        Customer.GetComponent<Image>().color = Col;

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
        yield return new WaitUntil(() => i >= iCount-1);

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

        float BarSize = 325;//バー全体の長さ
        float MemoriSize = 10;//１目盛りの長さ
        float Moto = StatSus;//元のステータス値
        float Goal = Moto + Count;//変化後のステータス値
        if (Goal < 0) { Goal = 0; }//結果が０以下なら０
        else if (Goal > 100) { Goal = 101.0f;Count = 100 - Moto; }//結果が１００以上なら１００
        float Memori = 100 / BarSize * MemoriSize;//描画一回の変化量がコレ（10px動く分）
        float iCount = Mathf.Abs(Count / Memori);
        float Start = Moto - Moto % Memori;//開始地点を丸める

        AnimeSus = Start;
        int i;
        for (i = 1; i <= iCount; i++)
        {

            if (Count >= 0)
            {
                AnimeSus +=Memori;
            }
            else {
                AnimeSus -=Memori;
            }
            if (AnimeSus < 0) { AnimeSus = 0; break; }
            if (AnimeSus > 100) { AnimeSus = 100; break; }
            DrawSus2(AnimeSus);
            yield return new WaitForSeconds(0.05f);//描画一回にかける遅延時間
        }
        StatGame.GetComponent<StatGame>().StatSus = Goal;
        DrawSus();
        //       Debug.Log("StatSus: " + Moto + " → " + Goal);
        TapBlockSus.SetActive(false);
        EventSystem.SetActive(true);
    }

    //Exp増減
    public void ExpUp(int Count)
    {
       StartCoroutine("ExpUpCoroutine", Count);
    }
    IEnumerator ExpUpCoroutine(int Count)
    {
        TapBlockExp.SetActive(true);
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
        int StatG = StatGame.GetComponent<StatGame>().StatG;//所持金
        string StatGText = StatG.ToString();
        TextG.text = StatGText;
    }
    //Sus描画
    public void DrawSus()
    {
        float StatSus = StatGame.GetComponent<StatGame>().StatSus;
        BarSus.sizeDelta = new Vector2(325 * StatSus / 100, 52);
    }
    //Sus描画（アニメーション用）
    public void DrawSus2(float AnimeSus)
    {
        BarSus.sizeDelta = new Vector2(325 * AnimeSus / 100, 52);
    }

    //Exp描画（アニメーション用）
    public void DrawExp2(float AnimeExp)
    {
        BarExp.sizeDelta = new Vector2(720 * AnimeExp / 100, 99);
    }


    //Exp描画
    public void DrawExp()
    {
        int StatExp = StatGame.GetComponent<StatGame>().StatExp;
        BarExp.sizeDelta = new Vector2(720 * StatExp / 100, 99);
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

    }

    // Update is called once per frame
    void Update()
    {

        if (StatGame.GetComponent<StatGame>().StatSus > 90)
        {
            ObjectSus.GetComponent<Image>().color = new Color(1f,0,0,1f);
        }
        else {
            ObjectSus.GetComponent<Image>().color = new Color(24f/255, 1f, 150f/255, 1f);
        }
    }
}
