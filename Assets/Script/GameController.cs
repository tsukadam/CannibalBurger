using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
    //ゲームの進行を制御する

    //プレイヤーstat
    public GameObject playerstat;
    //ステータスの定義

    //ステータス表示オブジェクトの取得

    //イベントシステムの取得（処理中に切る場合がある）
    public GameObject EventSystem;

    //ゲームスタート
    public void GameStart()
    {
        //パラメータ初期化
        playerstat.GetComponent<PlayerStat>().StatSus = 0;
        playerstat.GetComponent<PlayerStat>().StatPop = 0;
        playerstat.GetComponent<PlayerStat>().StatG = 50;
        GetComponent<PlayerController>().DrawSus();
        GetComponent<PlayerController>().DrawPop();
        GetComponent<PlayerController>().DrawG();

        playerstat.GetComponent<PlayerStat>().ClearCustomer = 0;
        playerstat.GetComponent<PlayerStat>().NowBombCount = 0;

        playerstat.GetComponent<PlayerStat>().StatBunsLv = 1;
        playerstat.GetComponent<PlayerStat>().StatPattyLv = 1;
        playerstat.GetComponent<PlayerStat>().StatToppingLv = 1;
        playerstat.GetComponent<PlayerStat>().StatSourceLv = 1;
        playerstat.GetComponent<PlayerStat>().StatBunsPower = 10;
        playerstat.GetComponent<PlayerStat>().StatPattyPower = 10;
        playerstat.GetComponent<PlayerStat>().StatToppingPower = 10;
        playerstat.GetComponent<PlayerStat>().StatSourcePower = 10;
        GetComponent<PlayerController>().DrawLvPower("Buns","Lv",0);
        GetComponent<PlayerController>().DrawLvPower("Buns", "Power", 0);
        GetComponent<PlayerController>().DrawLvPower("Patty", "Lv", 0);
        GetComponent<PlayerController>().DrawLvPower("Patty", "Power", 0);
        GetComponent<PlayerController>().DrawLvPower("Topping", "Lv", 0);
        GetComponent<PlayerController>().DrawLvPower("Topping", "Power", 0);
        GetComponent<PlayerController>().DrawLvPower("Source", "Lv", 0);
        GetComponent<PlayerController>().DrawLvPower("Source", "Power", 0);

        GetComponent<CustomerController>().MakeCustomer12();
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
