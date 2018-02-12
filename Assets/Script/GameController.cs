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

    public GameObject PopupResultG;
    public Text PopupResultGText;

    public GameObject PopupDisposeItem;
    public Text PopupDisposeText;

    public GameObject Message;
    public Text MessageText;


    //プレハブ
    public GameObject HeartPrefab;
    public GameObject SelectBoxPrefab;


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
        PopupDisposeItem.SetActive(false);
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
        StatGame.GetComponent<StatGame>().Item1 = new string[] { "初期肉１", "niku1", "10", "#ff0000", "0" };
        StatGame.GetComponent<StatGame>().Item2 = new string[] { "初期肉２", "niku1", "20", "#00ff00", "0" };
        StatGame.GetComponent<StatGame>().Item3 = new string[] { "初期肉３", "niku1", "30", "#0000ff", "0" };
        StatGame.GetComponent<StatGame>().Item4 = new string[] { "初期人肉４", "niku1", "40", "#666666", "5" };

        CustomerStart();

            //        GetComponent<CustomerController>().MakeCustomer12();

        //        TapBlock.SetActive(false);
        //        Popup.SetActive(false);
        EventSystem.SetActive(true);

    }


    //食材選択　→　効果判定　→　Gリザルト表示
    public void Feed(int ItemNum)
    {
        MessageDraw("");
        Button4Items.SetActive(false);

        //どの所持アイテムが押されたか判定、そのアイテムは所持アイテムから消す
        string[] UseItem= new string[4];
        string[] NoItem = { "", "", "", "", "" };
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
        int GetExp = 0;
        while (Count<CustomerLength)
        {
            int CustomerHp= Customers[Count].GetComponent<StatCustomer>().Hp;
            int CustomerDropG = Customers[Count].GetComponent<StatCustomer>().DropG;

            //Powerを比べる
            //こちらの勝利
            if (UseItemPower >= CustomerHp)
            {
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
                Customers[Count].GetComponent<StatCustomer>().PointColor = Random.Range(0, 100);

                //賞金取得
                GetG += CustomerDropG;
                //exp獲得
                GetExp += CustomerDropG;
            }
            //客の勝利
            else
            {
                //タグをつける
                Customers[Count].tag = "Winner";
            }

            Count++;
        }


        //賞金を所持金に加算
        GetComponent<StatGameController>().GUp(GetG);

        //ポップアップ表示
        PopupResultG.SetActive(true);
        string TextGetG = (GetG).ToString();
        string TextGetExp = (GetExp).ToString();
        PopupResultGText.text = TextGetG+"Gを獲得しました\n"+TextGetExp+"の経験値を得ました";

        //ここでレベルアップＳＵＳ減を判定した後、ＳＵＳゲームオーバーの判定が入る
    }

    //アイテムゲット選択画面へ
    public void Select()
    {
        //ポップアップ閉じる
        PopupResultG.SetActive(false);
        //選択アイテム欄出す
        ButtonSelectItem.SetActive(true);

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

        }
        else { 
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
            int ItemUpSus;

            Count = 0;
            string CountString;
            CustomerLength = LoserTop.GetLength(0);
            int PositionY=0;
            int PositionX=0;
            while (Count < CustomerLength)
            {
                PositionY = 200;
                PositionX = (150*Count)-200;
                LoserTop[Count].transform.position = new Vector3(PositionX, PositionY, 0);
                LoserTop[Count].GetComponent<Rigidbody2D>().constraints=RigidbodyConstraints2D.FreezePosition;
                LoserTop[Count].GetComponent<Button>().interactable = true;


                DropItem = LoserTop[Count].GetComponent<StatCustomer>().DropItem;
                ItemName = DropItem[0];
                ItemImage = DropItem[1];
                ItemPower = int.Parse(DropItem[2]);
                ItemUpSus = int.Parse(DropItem[4]);
                CountString = (Count).ToString();
                ItemTag = "Item"+CountString;
                ItemCol = LoserTop[Count].GetComponent<Image>().color;
                GetComponent<ItemController>().MakeItem(ItemName, ItemImage,ItemPower,ItemCol,ItemUpSus,PositionX,-50,ItemTag);

                Count++;
            }
        }
        MessageDraw("食材を２つ選んでＯＫ");
        SelectStart();//選択ワクの初期化
        SelectButtonOK.GetComponent<Button>().interactable = false;

    }

    //選択確定→捨てる画面に遷移
    public void SelectOK()
    {
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
        GetItem1[4] = PowerString;
        Col = SelectItemImage1.GetComponent<StatItem>().Col;
        ColorString = GetComponent<ColorGetter>().ToColorString(Col);
        GetItem1[3] = "#" + ColorString;

        GetItem2[0] = SelectItemImage2.GetComponent<StatItem>().Name;
        GetItem2[1] = SelectItemImage2.GetComponent<StatItem>().Image;
        PowerString = (SelectItemImage2.GetComponent<StatItem>().Power).ToString();
        GetItem2[2] = PowerString;
        UpSusString = (SelectItemImage2.GetComponent<StatItem>().UpSus).ToString();
        GetItem2[4] = PowerString;
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


        SelectButtonOK.GetComponent<Button>().interactable = false;
        ButtonSelectItem.SetActive(false);
        Button6Items.SetActive(true);

        if (StatGame.GetComponent<StatGame>().Item1[0] == "") { Button6Items1.GetComponent<Button>().interactable = false; }
        else { Button6Items1.GetComponent<Button>().interactable = true; }
        if (StatGame.GetComponent<StatGame>().Item2[0] == "") { Button6Items2.GetComponent<Button>().interactable = false; }
        else { Button6Items2.GetComponent<Button>().interactable = true; }
        if (StatGame.GetComponent<StatGame>().Item3[0] == "") { Button6Items3.GetComponent<Button>().interactable = false; }
        else { Button6Items3.GetComponent<Button>().interactable = true; }
        if (StatGame.GetComponent<StatGame>().Item4[0] == "") { Button6Items4.GetComponent<Button>().interactable = false; }
        else { Button6Items4.GetComponent<Button>().interactable = true; }
        if (StatGame.GetComponent<StatGame>().Item5[0] == "") { Button6Items5.GetComponent<Button>().interactable = false; }
        else { Button6Items5.GetComponent<Button>().interactable = true; }
        if (StatGame.GetComponent<StatGame>().Item6[0] == "") { Button6Items6.GetComponent<Button>().interactable = false; }
        else { Button6Items6.GetComponent<Button>().interactable = true; }


        MessageDraw("捨てる食材を選んでください");
        GetComponent<StatGameController>().DrawItem6();

    }

    public void Dispose(int ItemNum)
    {
        string[] CheckItem = new string[5];
        if (ItemNum == 1) { CheckItem = StatGame.GetComponent<StatGame>().Item1; }
        else if (ItemNum == 2) { CheckItem = StatGame.GetComponent<StatGame>().Item2; }
        else if (ItemNum == 3) { CheckItem = StatGame.GetComponent<StatGame>().Item3; }
        else if (ItemNum == 4) { CheckItem = StatGame.GetComponent<StatGame>().Item4; }
        else if (ItemNum == 5) { CheckItem = StatGame.GetComponent<StatGame>().Item5; }
        else { CheckItem = StatGame.GetComponent<StatGame>().Item6; }
        PopupDisposeItem.SetActive(true);
        PopupDisposeText.text = CheckItem[0]+"\nを捨てていいですか？";
        GetComponent<StatGameController>().DrawDisposeItem(CheckItem);
        StatGame.GetComponent<StatGame>().DisposeItemID = ItemNum;
    }

    public void DisposeCancel()
    {
        PopupDisposeItem.SetActive(false);
        StatGame.GetComponent<StatGame>().DisposeItemID = 0;
    }
    public void DisposeOK()
    {
        PopupDisposeItem.SetActive(false);

        int ItemNum = StatGame.GetComponent<StatGame>().DisposeItemID;
        if (ItemNum == 1) { StatGame.GetComponent<StatGame>().Item1 =new string[]{ "","","","","" }; }
        else if (ItemNum == 2) { StatGame.GetComponent<StatGame>().Item2 = new string[] { "", "", "", "", "" }; }
        else if (ItemNum == 3) { StatGame.GetComponent<StatGame>().Item3 = new string[] { "", "", "", "", "" }; }
        else if (ItemNum == 4) { StatGame.GetComponent<StatGame>().Item4 = new string[] { "", "", "", "", "" }; }
        else if (ItemNum == 5) { StatGame.GetComponent<StatGame>().Item5 = new string[] { "", "", "", "", "" }; }
        else if (ItemNum == 6) { StatGame.GetComponent<StatGame>().Item6 = new string[] { "", "", "", "", "" }; }
        else { Debug.Log("1~6以外のアイテムＩＤが入っています"); }

        string[] CheckItem = new string[5];
        int Count = 0;
        int ItemCount = 0;
        
        while (Count < 6)
        {
            if (Count == 0) { CheckItem = StatGame.GetComponent<StatGame>().Item1; }
            else if (Count == 1) { CheckItem = StatGame.GetComponent<StatGame>().Item2; }
            else if (Count == 2) { CheckItem = StatGame.GetComponent<StatGame>().Item3; }
            else if (Count == 3) { CheckItem = StatGame.GetComponent<StatGame>().Item4; }
            else if (Count == 4) { CheckItem = StatGame.GetComponent<StatGame>().Item5; }
            else { CheckItem = StatGame.GetComponent<StatGame>().Item6; }

            if (CheckItem[0] == "") { }
            else
            {
                if (ItemCount == 0) {StatGame.GetComponent<StatGame>().Item1=CheckItem; }
                else if (ItemCount == 1) { StatGame.GetComponent<StatGame>().Item2 = CheckItem; }
                else if (ItemCount == 2) { StatGame.GetComponent<StatGame>().Item3 = CheckItem; }
                else { StatGame.GetComponent<StatGame>().Item4 = CheckItem; }
                ItemCount++;
            }
            Count++;
        }
        Button6Items.SetActive(false);
        CustomerStart();
    }

    //来客開始
    public void CustomerStart()
    {
        //アイテムパネルの描画
        Button4Items.SetActive(true);
        GetComponent<StatGameController>().DrawItem4();

        //メッセージ表示
        MessageDraw("使う食材をタップして下さい");

        //客フィールドの初期化
        //初期客の生成

        int count = 0;
        while (count < 20)
        {
            int RandomHp = Random.Range(10, 40);
            //            int RandomImage = Random.Range(1, 4);
            GetComponent<CustomerController>().MakeCustomer("ドクター・ヤブ", "doc", RandomHp, 0, 0, 2, new string[] { "患者の肉", "niku1", "30", "Color", "0" }, new string[] { "医者の肉", "niku1", "100", "Color", "5" }, 0);
            count++;
        }


    }

    //選択ワクの初期化
    public void SelectStart()
    {
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


    }

    //既に選択されたワクがタップされたら選択を解除
    public void UnSelectItem(string TagName)
    {
        //OKボタンを切る
        SelectButtonOK.GetComponent<Button>().interactable=false;
        GameObject UseBox = SelectItemImage1;

        if (TagName == "Box1")
        {
            UseBox = SelectItemImage1;
            Destroy(GameObject.FindGameObjectWithTag("Box1"));
            SelectItemImage1.GetComponent<Image>().sprite = null;
            SelectItemImage1.GetComponent<Image>().color = new Color(0,0,0, 1f); ;
            SelectItemName1.text = "";
            SelectItemPower1.text = "";

        }
        else
        {
            UseBox = SelectItemImage2;
            Destroy(GameObject.FindGameObjectWithTag("Box2"));
            SelectItemImage2.GetComponent<Image>().sprite = null;
            SelectItemImage2.GetComponent<Image>().color = new Color(0, 0, 0, 1f);
            SelectItemName2.text = "";
            SelectItemPower2.text = "";
        }
        UseBox.GetComponent<StatItem>().Name = null;
        UseBox.GetComponent<StatItem>().Image = null;
        UseBox.GetComponent<StatItem>().Power = 0;
        UseBox.GetComponent<StatItem>().Col = new Color(0, 0, 0, 1f);
        UseBox.GetComponent<StatItem>().UpSus = 0;
//        UseBox.tag = "Untagged";

    }

    //アイテムないし人がタップされたら選択状態にする
    public void SelectItem(string TagName)
    {
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
            int UpSus;
            string UpSusString;

            GameObject UseBox = SelectItemImage1;
            //アイテムの場合

            //枠の生成
            GameObject SelectBox = (GameObject)Instantiate(
                       SelectBoxPrefab,
                       transform.position,
                       Quaternion.identity);
            SelectBox.transform.SetParent(SelectedItem.transform);

            //位置決定
            SelectBox.transform.localPosition = new Vector3(0, 0, 0);

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
//                UseBox.tag = TagName;
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
                UpSus = int.Parse(UpSusString);

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
 //               UseBox.tag = TagName;

            }
            else { Debug.Log("アイテムでも人でもないものが選択されている"); }
            //枠が両方埋まっていたらＯＫボタンを出す
            if (GameObject.FindGameObjectWithTag("Box1") != null & GameObject.FindGameObjectWithTag("Box2") != null)
            {
                SelectButtonOK.GetComponent<Button>().interactable = true;
            }

        }
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

