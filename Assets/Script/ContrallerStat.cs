using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ContrallerStat : MonoBehaviour {
    //ステータスの変化はこのオブジェクト内の変数の変更で表現される
    //このオブジェクト内の変数の状態を参照することでステータスの描写を行う
    //描写そのものもこのオブジェクト内にスクリプトを記述する
    //このオブジェクト内の変数の状態を保存することでセーブを行う
    //ステータスに対して加えられる変化は、このオブジェクト内の関数として定義される

//ステータスの定義
    //プレイ外ステータス
    public int LogAdv = 0;//広告消し有無
    public int LogRoomExpand = 0;//地下室の拡張個数
    public int LogItemExpand = 0;//アイテム上限数の拡張個数
    public int LogTotalArrest = 0;//総逮捕回数
    public int LogTotalMoney = 0;//総獲得金額
    public int LogTotalKill = 0;//総殺人数
    public int LogTotalDays = 0;//総経過日数
    public int LogMaxMoney = 0;//総獲得金額
    public int LogMaxDays = 0;//総経過日数
    public int LogLawOpen = 0;//解放済み法案のIDの配列（仮にint）
    public int LogSettingHoge = 0;//設定項目の状態
    //プレイ内表示ステータス
    public int StatG = 500;//所持金
    public float StatSus = 0;//SUS値
    public float StatPop = 0;//POP値
    public float StatXp = 0;//経験値
    public int StatLv = 1;//レベル
    public int StatSkillCool = 0;//スキル-料理力
    public int StatSkillAttract = 0;//スキル-集客力
    public int StatSkillIncome = 0;//スキル-収入力
    public int StatFoodOpen = 0;//解放済み具材のIDの配列（仮にint）
    public int StatDowChange = 0;//直前の景気変化
    public int StatDays = 0;//経過日数
    public int StatLawOpen = 0;//ゲーム開始時にLogLawOpenをコピーする
    public int StatSettingHoge = 0;//ゲーム開始時にLogSettingHogeをコピーする
    public int StatRoomNumber = 0;//地下室の拘留人数
    public int StatRoomData = 0;//地下室の拘留者データの多次元配列（仮にint）
    public int StatScene = 0;//今がどのゲーム画面か。0=来客画面　1=メニュー画面
    public int StatCustomerNumber = 0;//来客人数
    public int StatCustomerData = 0;//来客者データの多次元配列（仮にint）
    //プレイ内非表示ステータス
    public int StatDowValue = 0;//景気値
    public int StatWanted = 0;//賞金首進行状況（制御方法未定。仮。レベルから直接算出でいいかも）


    //ステータス表示オブジェクトの取得
    public Text PannelLv;
    public Text PannelDays;
    public RectTransform PannelXp;
    public RectTransform PannelSus;
    public RectTransform PannelPop;
    public Text PannelG;
    public RectTransform PannelDow;

    //イベントシステムの取得（処理中に切る場合がある）
    public GameObject EventSystem;
    
    // Use this for initialization
    void Start () {
//ステータスの初期化
//最終的には、初回起動時に初期値をセット
//それ以外の時は保存されている値をセット
//プレイ外ステータス
    LogAdv = 0;//広告消し有無
    LogRoomExpand = 0;//地下室の拡張個数
    LogItemExpand = 0;//アイテム上限数の拡張個数
    LogTotalArrest = 0;//総逮捕回数
    LogTotalMoney = 0;//総獲得金額
    LogTotalKill = 0;//総殺人数
    LogTotalDays = 0;//総経過日数
    LogMaxMoney = 0;//総獲得金額
    LogMaxDays = 0;//総経過日数
    LogLawOpen = 0;//解放済み法案のIDの配列（仮にint）
    LogSettingHoge = 0;//設定項目の状態
    //プレイ内表示ステータス
    StatG = 500;//所持金
    StatSus = 0;//SUS値
    StatPop = 0;//POP値
    StatXp = 0;//経験値
    StatLv = 1;//レベル
    StatSkillCool = 0;//スキル-料理力
    StatSkillAttract = 0;//スキル-集客力
    StatSkillIncome = 0;//スキル-収入力
    StatFoodOpen = 0;//解放済み具材のIDの配列（仮にint）
    StatDowChange = 0;//直前の景気変化
    StatDays = 1;//経過日数
    StatLawOpen = 0;//ゲーム開始時にLogLawOpenをコピーする
    StatSettingHoge = 0;//ゲーム開始時にLogSettingHogeをコピーする
    StatRoomNumber = 0;//地下室の拘留人数
    StatRoomData = 0;//地下室の拘留者データの多次元配列（仮にint）
    StatScene = 0;//今がどのゲーム画面か。0=来客画面　1=メニュー画面
    StatCustomerNumber = 0;//来客人数
    StatCustomerData = 0;//来客者データの多次元配列（仮にint）
    //プレイ内非表示ステータス
    StatDowValue = 0;//景気値
    StatWanted = 0;//賞金首進行状況（制御方法未定。仮。レベルから直接算出でいいかも）

        //ステータスの初期描画
        LvDraw();
        DaysDraw();
        GDraw();
        SusDraw();
        PopDraw();
        XpDraw();

    }

    //景気上下時
    //上下は-2～+2
    public void DowUp(int Count)
    {
        StatDowValue = StatDowValue + Count;
        StatDowChange = Count;
        DowDraw();
    }


    //レベルアップ
    public void LvUp(int Count)
    {
        StatLv= StatLv+ Count;
        LvDraw();
    }
    //日付アップ
    public void DaysUp(int Count)
    {
        StatDays = StatDays + Count;
        DaysDraw();
    }
    //G増減
    public void GUp(int Count)
    {
        StartCoroutine("GUpCoroutine", Count);
    }
    IEnumerator GUpCoroutine(int Count)
    {
        EventSystem.SetActive(false);
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
            else if (iCount - i >= 10) { Memori = 10;Plus = 10; }
            else { Memori = 1;Plus = 1; }

            if (Count >= 0)
            {
                StatG = StatG + Memori;
            }
            else {
                StatG = StatG - Memori;
            }
            if (StatG < 0) { StatG = 0; GDraw(); break; }
            if (StatG > 99999999) { StatG = 99999999; GDraw(); break; }
            GDraw();
            yield return new WaitForSeconds(0.05f);//描画一回にかける遅延時間
            i = i + Plus;
        }
        StatG = Goal;
        Debug.Log("StatG: " + Moto + " → " + Goal);
        EventSystem.SetActive(true);
    }


    //Sus増減
    public void SusUp(int Count)
    {
                StartCoroutine("SusUpCoroutine",Count);
    }
    IEnumerator SusUpCoroutine(int Count)
    {
        EventSystem.SetActive(false);
        int BarSize = 304;//バー全体の長さ
        int MemoriSize = 4;//１目盛りの長さ
        float Moto = StatSus;//元のステータス値
        float Goal = Moto +Count;//変化後のステータス値
        if (Goal < 0) { Goal = 0;}//結果が０以下なら０
        else if (Goal > 100) { Goal = 100; }//結果が１００以上なら１００
        float iCount = Count / (100f / (BarSize / MemoriSize));
        if (Count >= 0)//減少方向のとき描画回数も負になってしまうので正にする（絶対値を取る）
        {
            iCount = iCount * 1;
        }
        else {
            iCount = iCount * -1;
        }
        float Start = Moto-Moto%(100f / (BarSize / MemoriSize));//開始地点を丸める
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
            SusDraw();
            yield return new WaitForSeconds(0.1f);//描画一回にかける遅延時間
        }
        StatSus = Goal;
        Debug.Log("StatSus: "+Moto +" → "+ Goal);
        EventSystem.SetActive(true);
    }

    //Pop増減
    public void PopUp(int Count)
    {
        StartCoroutine("PopUpCoroutine", Count);
    }
    IEnumerator PopUpCoroutine(int Count)
    {
        EventSystem.SetActive(false);
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
            PopDraw();
            yield return new WaitForSeconds(0.1f);//描画一回にかける遅延時間
        }
        StatPop = Goal;
        Debug.Log("StatPop: " + Moto + " → " + Goal);
        EventSystem.SetActive(true);
    }

    //Xp増減
    public void XpUp(int Count)
    {
        StartCoroutine("XpUpCoroutine", Count);
    }
    IEnumerator XpUpCoroutine(int Count)
    {
        EventSystem.SetActive(false);
        int BarSize = 136;//バー全体の長さ
        int MemoriSize = 4;//１目盛りの長さ
        float Moto = StatXp;//元のステータス値
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
        StatXp = Start;
        int i;
        for (i = 1; i <= iCount; i++)
        {
            if (Count >= 0)
            {
                StatXp = StatXp + Memori;
            }
            else {
                StatXp = StatXp - Memori;
            }
            if (StatXp < 0) { StatXp = 0; break; }
            if (StatXp > 100) { StatXp = 100; break; }
            XpDraw();
            yield return new WaitForSeconds(0.1f);//描画一回にかける遅延時間
        }
        StatXp = Goal;
        Debug.Log("StatXp: " + Moto + " → " + Goal);
        EventSystem.SetActive(true);
    }


    //レベルパネル描画
    public void LvDraw()
    {
        string StatLvText = StatLv.ToString();
        PannelLv.text = StatLvText;
    }
    //日付パネル描画
    public void DaysDraw()
    {
        string StatDaysText = StatDays.ToString();
        PannelDays.text = StatDaysText;
    }
    //Ｇパネル描画
    public void GDraw()
    {
        string StatGText = StatG.ToString();
        PannelG.text = StatGText;
    }
    //Sus描画
    public void SusDraw()
    {
        PannelSus.sizeDelta = new Vector2(304 * StatSus / 100, 15);
    }
    //Pop描画
    public void PopDraw()
    {
        PannelPop.sizeDelta = new Vector2(304 * StatPop / 100, 15);
    }
    //Xp描画
    public void XpDraw()
    {
        PannelXp.sizeDelta = new Vector2(136 * StatXp / 100, 15);
    }
    //Dow描画
    public void DowDraw()
    {
        int Kakudo = -90;
        if (StatDowChange == 2) { Kakudo = -30; }
        else if (StatDowChange == 1) { Kakudo = -60; }
        else if (StatDowChange == 0) { Kakudo = -90; }
        else if (StatDowChange == -1) { Kakudo = -120; }
        else if (StatDowChange == -2) { Kakudo = -150; }
        else { Debug.Log("景気の変化が-2～2を超えている");
            Kakudo = -90;
        }
        PannelDow.localRotation = Quaternion.Euler(0,0, Kakudo);

    }


    // Update is called once per frame
    void Update () {
	
	}

}
