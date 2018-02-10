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

    //各画面
    public GameObject Menu;
    public GameObject Game;
    public GameObject HighScore;
    public GameObject AdsDelete;

    public GameObject CustomerField;

    public GameObject Button4Items;
    public GameObject Button6Items;
    public GameObject ButtonSelectItem;
    public GameObject PopupResultG;
    public GameObject PopupResultItem;
    public GameObject Message;
    public Text MessageText;

    //ハートプレハブ
    public GameObject HeartPrefab;


    //イベントシステムの取得（処理中に切る場合がある）
    public GameObject EventSystem;
    //タップ切るための板
//    public GameObject TapBlock;
    //ポップアップ
//    public GameObject Popup;


//ゲームスタート
    public void GameStart()
    {
//        TapBlock.SetActive(true);
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
        PopupResultItem.SetActive(false);
        Message.SetActive(true);
        CustomerField.SetActive(true);

        //パラメータ初期化
        StatGame.GetComponent<StatGame>().StatSus = 0;
        StatGame.GetComponent<StatGame>().StatG = 50;
        StatGame.GetComponent<StatGame>().StatLv = 1;
        StatGame.GetComponent<StatGame>().StatDays = 1;
        GetComponent<StatGameController>().DrawSus();
        GetComponent<StatGameController>().DrawG();
        GetComponent<StatGameController>().DrawLv();
        GetComponent<StatGameController>().DrawDays();

        //所持アイテム
        StatGame.GetComponent<StatGame>().Item1 = new string[]{ "Name", "niku1", "Power", "Color", "Sus" };
        StatGame.GetComponent<StatGame>().Item2 = new string[] { "Name", "niku1", "Power", "Color", "Sus" };
        StatGame.GetComponent<StatGame>().Item3 = new string[] { "Name", "niku1", "Power", "Color", "Sus" };
        StatGame.GetComponent<StatGame>().Item4 = new string[] { "Name", "niku1", "Power", "Color", "Sus" };
        //所持扱いにならない、取得処理時に使う枠
        StatGame.GetComponent<StatGame>().Item5 = new string[] { "Name", "niku1", "Power", "Color", "Sus" };
        StatGame.GetComponent<StatGame>().Item6 = new string[] { "Name", "niku1", "Power", "Color", "Sus" };

        //初期アイテムの生成
        StatGame.GetComponent<StatGame>().Item1 = new string[] { "初期肉１", "niku1", "1", "#ff0000", "0" };
        StatGame.GetComponent<StatGame>().Item2 = new string[] { "初期肉２", "niku1", "2", "#00ff00", "0" };
        StatGame.GetComponent<StatGame>().Item3 = new string[] { "初期肉３", "niku1", "3", "#0000ff", "0" };
        StatGame.GetComponent<StatGame>().Item4 = new string[] { "初期人肉４", "niku1", "4", "#666666", "5" };

        //アイテムパネルの描画
        GetComponent<StatGameController>().DrawItem4();

        //メッセージ表示
        MessageDraw("使う食材をタップして下さい");

        //客フィールドの初期化
        //初期客の生成

        int count = 0;
        while (count < 8)
        {
            int RandomHp=Random.Range(1, 4);
//            int RandomImage = Random.Range(1, 4);
            GetComponent<CustomerController>().MakeCustomer("test", "doc", RandomHp, 0, 0, 2, new string[3], new string[3], 0);
            count++;
        }

        //        GetComponent<CustomerController>().MakeCustomer12();

        //        TapBlock.SetActive(false);
        //        Popup.SetActive(false);
        EventSystem.SetActive(true);

    }


    //食材選択　→　効果判定　→　リザルト表示前まで
    public void Feed(int ItemNum)
    {
//どの所持アイテムが押されたか判定、そのアイテムは所持アイテムから消す
        string[] UseItem= new string[4];
        string[] NoItem = { "None", "", "", "", "" };
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
        int GetG=0;
        while (Count<CustomerLength)
        {
            int CustomerHp= Customers[Count].GetComponent<StatCustomer>().Hp;
            int CustomerDropG = Customers[Count].GetComponent<StatCustomer>().DropG;

            //Powerを比べる
            //こちらの勝利
            if (UseItemPower >= CustomerHp)
            {
                //                Customers[Count].GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);//デバッグ用　敗北した客をグレーにする
                //ハートの生成
                GameObject Heart = (GameObject)Instantiate(
                           HeartPrefab,
                           transform.position,
                           Quaternion.identity);
                Heart.transform.SetParent(Customers[Count].transform);
                //位置決定
                Heart.transform.localPosition = new Vector3(0, 70, 0);

                //賞金取得
                GetG = GetG + CustomerDropG;
            }
            //客の勝利
            else
            {
            }


            Count++;
        }
        GetComponent<StatGameController>().GUp(GetG);



    }

    //メッセージ表示
    public void MessageDraw(string Text)
    {
        MessageText.text = Text;
    }

    // Use this for initialization
    void Start()
    {
        //メニュー画面への遷移
        Menu.SetActive(true);
        HighScore.SetActive(false);
        AdsDelete.SetActive(false);
        Game.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {

    }
}
