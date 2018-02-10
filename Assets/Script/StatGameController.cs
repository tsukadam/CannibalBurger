using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//プレイ中のプレイヤーのステータス周りの描写を行う
public class StatGameController : MonoBehaviour
{
    //プレイヤーstat
    public GameObject StatGame;
    //タップ切るための板
//    public GameObject TapBlock;

    //ステータス表示オブジェクトの取得

    public RectTransform BarSus;
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


    //イベントシステムの取得（処理中に切る場合がある）
    public GameObject EventSystem;

    //ここから描写処理

    //アイテム描写
    //4Itemsに所持アイテム1～4を表示
    public void DrawItem4()
    {
        string ImagePath;
        string ColorText;
        Color ColorColor;
        Sprite SpriteImage;

        ImagePath = "Item/" + StatGame.GetComponent<StatGame>().Item1[1];
        SpriteImage = Resources.Load<Sprite>(ImagePath);
        ColorText = StatGame.GetComponent<StatGame>().Item1[3];
        ColorColor = GetComponent<ColorGetter>().ToColor(ColorText);
        Item4_1Image.GetComponent<Image>().sprite = SpriteImage;
        Item4_1Text.text = StatGame.GetComponent<StatGame>().Item1[0];
        Item4_1Power.text = StatGame.GetComponent<StatGame>().Item1[2];
        Item4_1Image.GetComponent<Image>().color = ColorColor;

        ImagePath = "Item/" + StatGame.GetComponent<StatGame>().Item2[1];
        SpriteImage = Resources.Load<Sprite>(ImagePath);
        ColorText = StatGame.GetComponent<StatGame>().Item2[3];
        ColorColor = GetComponent<ColorGetter>().ToColor(ColorText);
        Item4_2Image.GetComponent<Image>().sprite = SpriteImage;
        Item4_2Text.text = StatGame.GetComponent<StatGame>().Item2[0];
        Item4_2Power.text = StatGame.GetComponent<StatGame>().Item2[2];
        Item4_2Image.GetComponent<Image>().color = ColorColor;

        ImagePath = "Item/" + StatGame.GetComponent<StatGame>().Item3[1];
        SpriteImage = Resources.Load<Sprite>(ImagePath);
        ColorText = StatGame.GetComponent<StatGame>().Item3[3];
        ColorColor = GetComponent<ColorGetter>().ToColor(ColorText);
        Item4_3Image.GetComponent<Image>().sprite = SpriteImage;
        Item4_3Text.text = StatGame.GetComponent<StatGame>().Item3[0];
        Item4_3Power.text = StatGame.GetComponent<StatGame>().Item3[2];
        Item4_3Image.GetComponent<Image>().color = ColorColor;

        ImagePath = "Item/" + StatGame.GetComponent<StatGame>().Item4[1];
        SpriteImage = Resources.Load<Sprite>(ImagePath);
        ColorText = StatGame.GetComponent<StatGame>().Item4[3];
        ColorColor = GetComponent<ColorGetter>().ToColor(ColorText);
        Item4_4Image.GetComponent<Image>().sprite = SpriteImage;
        Item4_4Text.text = StatGame.GetComponent<StatGame>().Item4[0];
        Item4_4Power.text = StatGame.GetComponent<StatGame>().Item4[2];
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
        StatG = Goal;
//        Debug.Log("StatG: " + Moto + " → " + Goal);
        EventSystem.SetActive(true);
    }


    //Sus増減
    public void SusUp(int Count)
    {
        StartCoroutine("SusUpCoroutine", Count);
    }
    IEnumerator SusUpCoroutine(int Count)
    {
        EventSystem.SetActive(false);
        float StatSus = StatGame.GetComponent<StatGame>().StatSus;
        int BarSize = 304;//バー全体の長さ
        int MemoriSize = 4;//１目盛りの長さ
        float Moto = StatSus;//元のステータス値
        float Goal = Moto + Count;//変化後のステータス値
        if (Goal < 0) { Goal = 0; }//結果が０以下なら０
        else if (Goal > 100) { Goal = 100; }//結果が１００以上なら１００
        float iCount = Count / (100f / (BarSize / MemoriSize));
        if (Count >= 0)//減少方向のとき描画回数も負になってしまうので正にする（絶対値を取る）
        {
            iCount = iCount * 1;
        }
        else {
            iCount = iCount * -1;
        }
        float Start = Moto - Moto % (100f / (BarSize / MemoriSize));//開始地点を丸める
        float Memori = (100f / (BarSize / MemoriSize));//描画一回の変化量がコレ（4px動く分）
        StatSus = Start;
        int i;
        for (i = 1; i <= iCount; i++)
        {
            if (Count >= 0)
            {
                StatSus = StatSus + Memori;
            }
            else {
                StatSus = StatSus - Memori;
            }
            if (StatSus < 0) { StatSus = 0; break; }
            if (StatSus > 100) { StatSus = 100; break; }
            StatGame.GetComponent<StatGame>().StatSus = StatSus;
            DrawSus();
            yield return new WaitForSeconds(0.1f);//描画一回にかける遅延時間
        }
        StatSus = Goal;
 //       Debug.Log("StatSus: " + Moto + " → " + Goal);
        EventSystem.SetActive(true);
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
        BarSus.sizeDelta = new Vector2(304 * StatSus / 100, 15);
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

    }
}
