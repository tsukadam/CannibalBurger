using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    //プレイ中のプレイヤーのステータス周りの描写を行う

    //プレイヤーstat
    public GameObject playerstat;
    //タップ切るための板
    public GameObject TapBlock;

    //ステータスの定義
    //プレイ外ステータス
    //プレイ内表示ステータス


    //ステータス表示オブジェクトの取得
    public GameObject TextBunsLv;//レベル
    public GameObject TextPattyLv;//レベル
    public GameObject TextToppingLv;//レベル
    public GameObject TextSourceLv;//レベル
    public GameObject TextBurgerLv;//レベル

    public GameObject TextBunsPower;//パワー
    public GameObject TextPattyPower;//パワー
    public GameObject TextToppingPower;//パワー
    public GameObject TextSourcePower;//パワー
    public GameObject TextBurgerPower;//パワー

    public RectTransform BarSus;
    public RectTransform BarPop;
    public Text TextG;

    //イベントシステムの取得（処理中に切る場合がある）
    public GameObject EventSystem;

    //ここから描写処理
    //G増減
    public void GUp(int Count)
    {
        StartCoroutine("GUpCoroutine", Count);
    }
    IEnumerator GUpCoroutine(int Count)
    {
        EventSystem.SetActive(false);
        int StatG = playerstat.GetComponent<PlayerStat>().StatG;//所持金
        int Moto = StatG;//元のステータス値
        int Goal = Moto + Count;//変化後のステータス値
        if (Goal < 0) { Goal = 0; }//結果が０以下なら０
        else if (Goal > 99999999) { Goal = 99999999; }//結果が９９９９９９９９以上なら９９９９９９９９
        float iCount = Count;
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
            playerstat.GetComponent<PlayerStat>().StatG = StatG;
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
        float StatSus = playerstat.GetComponent<PlayerStat>().StatSus;
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
            playerstat.GetComponent<PlayerStat>().StatSus = StatSus;
            DrawSus();
            yield return new WaitForSeconds(0.1f);//描画一回にかける遅延時間
        }
        StatSus = Goal;
 //       Debug.Log("StatSus: " + Moto + " → " + Goal);
        EventSystem.SetActive(true);
    }

    //Pop増減
    public void PopUp(float Count)
    {
        StartCoroutine("PopUpCoroutine", Count);
    }
    IEnumerator PopUpCoroutine(float Count)
    {
        EventSystem.SetActive(false);
        float StatPop = playerstat.GetComponent<PlayerStat>().StatPop;
        int BarSize = 304;//バー全体の長さ
        int MemoriSize = 4;//１目盛りの長さ
        float Moto = StatPop;//元のステータス値
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
        StatPop = Start;
        int i;
        for (i = 1; i <= iCount; i++)
        {
            if (Count >= 0)
            {
                StatPop = StatPop + Memori;
            }
            else {
                StatPop = StatPop - Memori;
            }
            if (StatPop < 0) { StatPop = 0; break; }
            if (StatPop > 100) { StatPop = 100; break; }
            playerstat.GetComponent<PlayerStat>().StatPop = StatPop;
            DrawPop();
            yield return new WaitForSeconds(0.1f);//描画一回にかける遅延時間
        }
        StatPop = Goal;
 //       Debug.Log("StatPop: " + Moto + " → " + Goal);
        EventSystem.SetActive(true);
    }
    //Ｇパネル描画
    public void DrawG()
    {
        int StatG = playerstat.GetComponent<PlayerStat>().StatG;//所持金
        string StatGText = StatG.ToString();
        TextG.text = StatGText;
    }
    //Sus描画
    public void DrawSus()
    {
        float StatSus = playerstat.GetComponent<PlayerStat>().StatSus;
        BarSus.sizeDelta = new Vector2(304 * StatSus / 100, 15);
    }
    //Pop描画
    public void DrawPop()
    {
        float StatPop = playerstat.GetComponent<PlayerStat>().StatPop;
        BarPop.sizeDelta = new Vector2(304 * StatPop / 100, 15);
    }
    //LvPower増減＋描画
    public void DrawLvPower(string Part, string LvPower, int Value)
    {
        int Moto = Value;
        if (Part == "Buns")
        {
            if (LvPower == "Lv") { Moto += playerstat.GetComponent<PlayerStat>().StatBunsLv;
                playerstat.GetComponent<PlayerStat>().StatBunsLv=Moto;
                TextBunsLv.GetComponent<Text>().text =Moto.ToString();
            }
            else if (LvPower == "Power") { Moto += playerstat.GetComponent<PlayerStat>().StatBunsPower;
                playerstat.GetComponent<PlayerStat>().StatBunsPower = Moto;
                TextBunsPower.GetComponent<Text>().text = Moto.ToString();
            }
            else { Debug.Log("Bunds LvPower setting error"); }
        }
        else if (Part == "Patty")
        {
            if (LvPower == "Lv") { Moto += playerstat.GetComponent<PlayerStat>().StatPattyLv;
                playerstat.GetComponent<PlayerStat>().StatPattyLv = Moto;
                TextPattyLv.GetComponent<Text>().text = Moto.ToString();
            }
            else if (LvPower == "Power") { Moto += playerstat.GetComponent<PlayerStat>().StatPattyPower;
                playerstat.GetComponent<PlayerStat>().StatPattyPower = Moto;
                TextPattyPower.GetComponent<Text>().text = Moto.ToString();
            }
            else { Debug.Log("Patty LvPower setting error"); }
        }
        else if (Part == "Topping")
        {
            if (LvPower == "Lv") { Moto += playerstat.GetComponent<PlayerStat>().StatToppingLv;
                playerstat.GetComponent<PlayerStat>().StatToppingLv = Moto;
                TextToppingLv.GetComponent<Text>().text = Moto.ToString();
            }
            else if (LvPower == "Power") { Moto += playerstat.GetComponent<PlayerStat>().StatToppingPower;
                playerstat.GetComponent<PlayerStat>().StatToppingPower = Moto;
                TextToppingPower.GetComponent<Text>().text = Moto.ToString();
            }
            else { Debug.Log("Topping LvPower setting error"); }
        }
        else if (Part == "Source")
        {
            if (LvPower == "Lv") { Moto += playerstat.GetComponent<PlayerStat>().StatSourceLv;
                playerstat.GetComponent<PlayerStat>().StatSourceLv = Moto;
                TextSourceLv.GetComponent<Text>().text = Moto.ToString();
            }
            else if (LvPower == "Power") { Moto += playerstat.GetComponent<PlayerStat>().StatSourcePower;
                playerstat.GetComponent<PlayerStat>().StatSourcePower = Moto;
                TextSourcePower.GetComponent<Text>().text = Moto.ToString();
            }
            else { Debug.Log("Source LvPower setting error"); }
        }
        else { Debug.Log("Part setting error"); }

        playerstat.GetComponent<PlayerStat>().StatBurgerLv = playerstat.GetComponent<PlayerStat>().StatBunsLv
            + playerstat.GetComponent<PlayerStat>().StatPattyLv
            + playerstat.GetComponent<PlayerStat>().StatToppingLv 
            + playerstat.GetComponent<PlayerStat>().StatSourceLv;
        TextBurgerLv.GetComponent<Text>().text = playerstat.GetComponent<PlayerStat>().StatBurgerLv.ToString();

        playerstat.GetComponent<PlayerStat>().StatBurgerPower = playerstat.GetComponent<PlayerStat>().StatBunsPower
    + playerstat.GetComponent<PlayerStat>().StatPattyPower
    + playerstat.GetComponent<PlayerStat>().StatToppingPower
    + playerstat.GetComponent<PlayerStat>().StatSourcePower;
        TextBurgerPower.GetComponent<Text>().text = playerstat.GetComponent<PlayerStat>().StatBurgerPower.ToString();


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
