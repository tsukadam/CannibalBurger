using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//プレイ中のステータスを保持する
public class StatGame : MonoBehaviour
{
        //表示ステータス
    public int StatG = 0;//所持金
    public float StatSus = 0;//SUS値
    public int StatDays = 0;//日数
    public int StatLv = 0;//レベル
    public int StatExp = 0;//Exp

    //所持アイテム
    //所持アイテムの内容を数列で書き込む
    public string[] Item1 = { "Name","PictuePath","Power","Color","Sus"};//
    public string[] Item2 = { "Name", "PictuePath", "Power", "Color", "Sus" };//
    public string[] Item3 = { "Name", "PictuePath", "Power", "Color", "Sus" };//
    public string[] Item4 = { "Name", "PictuePath", "Power", "Color", "Sus" };//

    //所持扱いにならない、取得処理時に使う枠
    public string[] Item5 = { "Name", "PictuePath", "Power", "Color", "Sus" };//
    public string[] Item6 = { "Name", "PictuePath", "Power", "Color", "Sus" };//

    public string[,] LvDesignData;

    //客のCSVデータ
    public string[,] CustomerAllData;
//レベルごとに更新されるデータ
    public string[,] CustmerC;
    public string[,] CustmerUC;
    public string[,] CustmerR;
    public string[,] CustmerSus;


    public int DisposeItemID = 0;//廃棄時に使う記憶領域
    public int UseItemNum;//Feed時に使う記憶領域
    public string[] UseItemData;

    public int ResultGetG = 0;//リザルト時に使う記憶領域
    public int ResultGetExp = 0;//リザルト時に使う記憶領域
    public float ResultGetSus = 0;//リザルト時に使う記憶領域


    //Ｇ，カルマ取得修正率
    public int ModifyG=0;
    public int ModifySus =0;

    //休日行動のステ
    //レベルデザインが計算し、スタットゲームが持つ
    public int PoliceCost1;
    public int PoliceReturn1;
    public int PoliceCost2;
    public int PoliceReturn2;

    public int ChurchReturn1;
    public int ChurchReturn2;

    public int HomeReturn1;
    public int HomeReturn2;

    public string[] MarketItem1 = { "Name", "PictuePath", "Power", "Color", "Sus" };
    public string[] MarketItem2 = { "Name", "PictuePath", "Power", "Color", "Sus" };
    public int MarketCost1;
    public int MarketCost2;


    //ハイスコア記録用、殺人数など

    //イベントシステムの取得（処理中に切る場合がある）
    public GameObject EventSystem;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
