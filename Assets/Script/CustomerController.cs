using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CustomerController : MonoBehaviour
{
    //客の生成を制御する

    //客プレファブ
    public GameObject CustomerPrefab;

    //プレイヤーstat
    public GameObject playerstat;

    //ステータスの定義

    //ステータス表示オブジェクトの取得
    public GameObject GameSpace;//表示スペース
    public GameObject Customer11Name;
    public GameObject Customer11Hp;
    public GameObject Customer12Name;
    public GameObject Customer12Hp;
    public GameObject Customer13Name;
    public GameObject Customer13Hp;
    public GameObject Customer14Name;
    public GameObject Customer14Hp;

    public int FlagColumn1 = 0;
    public int FlagColumn2 = 0;
    public int FlagColumn3 = 0;
    public int FlagColumn4 = 0;
    public int FlagDestroy = 0;

    //イベントシステムの取得（処理中に切る場合がある）
    public GameObject EventSystem;
    //タップ切るための板
    public GameObject TapBlock;
    //ポップアップ
    public GameObject Popup;
    public GameObject PopupText1;

    //客生成
    public void MakeCustomer(int PositionRow, int PositionColumn,
        int Color, int Hp, string Name, float GetPop, int GetG,
        string BombType, string BombTarget, int BombAmount, int BombTurn, string ItemName)
    {
        GameObject Customer = (GameObject)Instantiate(
            CustomerPrefab,
            transform.position,
            Quaternion.identity);
        Customer.transform.parent = GameSpace.transform;
        int PositionY = PositionRow * 200 - 200;
        int PositionX = PositionColumn * 170 - 425;
        Customer.transform.position = new Vector3(PositionX, PositionY, 0);
        Color Col = new Color(0, 0, 0, 0);
        if (Color == 1) { Col = new Color(1, 0, 0, 1); }
        else if (Color == 2) { Col = new Color(0, 1, 0, 1); }
        else if (Color == 3) { Col = new Color(1, 1, 0, 1); }
        else if (Color == 4) { Col = new Color(1, 1, 1, 1); }
        else { Col = new Color(0, 1, 1, 0);
            Debug.Log("Color is not 1~4");
        }
        Customer.GetComponent<Image>().color = Col;

        //爆弾かどうかの決定
        //とりあえず、爆弾が画面に１個あったら出さない
        GameObject Customer11 = GameObject.FindGameObjectWithTag("1-1");
        GameObject Customer12 = GameObject.FindGameObjectWithTag("1-2");
        GameObject Customer13 = GameObject.FindGameObjectWithTag("1-3");
        GameObject Customer14 = GameObject.FindGameObjectWithTag("1-4");
        GameObject Customer21 = GameObject.FindGameObjectWithTag("2-1");
        GameObject Customer22 = GameObject.FindGameObjectWithTag("2-2");
        GameObject Customer23 = GameObject.FindGameObjectWithTag("2-3");
        GameObject Customer24 = GameObject.FindGameObjectWithTag("2-4");
        GameObject Customer31 = GameObject.FindGameObjectWithTag("3-1");
        GameObject Customer32 = GameObject.FindGameObjectWithTag("3-2");
        GameObject Customer33 = GameObject.FindGameObjectWithTag("3-3");
        GameObject Customer34 = GameObject.FindGameObjectWithTag("3-4");
        //倒したことがなければ何もしない（ゲーム開始時）
        if (playerstat.GetComponent<PlayerStat>().ClearCustomer > 0)
        {
            Debug.Log("no null");
            //ボムが一定数以上あれば何もしない
            int Count= playerstat.GetComponent<PlayerStat>().ClearCustomer/10;
            int BombLevel = Random.Range(1,Count/4);
            if (playerstat.GetComponent<PlayerStat>().NowBombCount < BombLevel)
            {
                Debug.Log("less Bomb");
                if (Random.Range(0, 10) > 7)//この確率で爆弾になる
                {
                    Debug.Log("make Bomb");
                    Customer.GetComponent<CustomerStat>().Bomb = 1;
                    Customer.GetComponent<CustomerStat>().BombTarget = BombTarget;
                    Customer.GetComponent<CustomerStat>().BombAmount = BombAmount;
                    Customer.GetComponent<CustomerStat>().BombTurn = BombTurn;
                    Customer.GetComponent<CustomerStat>().BombCount.SetActive(true);
                    Customer.GetComponent<CustomerStat>().BombCount.GetComponent<Text>().text = BombTurn.ToString();
                    playerstat.GetComponent<PlayerStat>().NowBombCount++;
                    //爆弾の時だけアイテムをセット
                    if (ItemName == "パワーアップ")
                    {
                        Customer.GetComponent<CustomerStat>().ItemName = "パワーアップ";
                    }
                }
                else
                {
                    Customer.GetComponent<CustomerStat>().Bomb = 0;
                    Customer.GetComponent<CustomerStat>().BombTarget = "";
                    Customer.GetComponent<CustomerStat>().BombAmount = 0;
                    Customer.GetComponent<CustomerStat>().BombTurn = 0;
                    Customer.GetComponent<CustomerStat>().ItemName = "";
                    Customer.GetComponent<CustomerStat>().BombCount.SetActive(false);
                }
            }
        }

        //客の情報をカスタマーＳＴＡＴに書き込み
        Customer.GetComponent<CustomerStat>().PositionRow = PositionRow;
        Customer.GetComponent<CustomerStat>().PositionColumn = PositionColumn;
        Customer.GetComponent<CustomerStat>().Color = Color;
        Customer.GetComponent<CustomerStat>().Hp = Hp;
        Customer.GetComponent<CustomerStat>().Name = Name;
        Customer.GetComponent<CustomerStat>().GetPop = GetPop;
        Customer.GetComponent<CustomerStat>().GetG = GetG;
        string TagRow = PositionRow.ToString();
        string TagColumn = PositionColumn.ToString();
        string TagName = TagRow + "-" + TagColumn;
        Customer.tag = TagName;


    }

    //座標を渡すとその座標のCustomerのGameObjectを返す
    public GameObject GetObjectFromPosition(int Row,int Column)
    {
        string TagName = Row.ToString()+"-"+Column.ToString();
        GameObject ReturnObject = GameObject.FindGameObjectWithTag(TagName);
        return ReturnObject;
    }
    //Columnを渡すとその行の最前列の名前表記部分Objectを返す
    public GameObject GetNameObjectFromColumn(int Column)
    {
        GameObject ReturnObject = Customer11Name;
        if (Column == 1) { ReturnObject = Customer11Name; }
        else if (Column == 2) { ReturnObject = Customer12Name; }
        else if (Column == 3) { ReturnObject = Customer13Name; }
        else if (Column == 4) { ReturnObject = Customer14Name; }
        else { Debug.Log("Column is not 1~4, but Use 1 NameObject"); }
        return ReturnObject;
    }

    //Columnを渡すとその行の最前列のHP表記部分Objectを返す
    public GameObject GetHpObjectFromColumn(int Column)
    {
        GameObject ReturnObject = Customer11Name;
        if (Column == 1) { ReturnObject = Customer11Hp; }
        else if (Column == 2) { ReturnObject = Customer12Hp; }
        else if (Column == 3) { ReturnObject = Customer13Hp; }
        else if (Column == 4) { ReturnObject = Customer14Hp; }
        else { Debug.Log("Column is not 1~4, but Use 1 HpObject"); }
        return ReturnObject;
    }


    //最前列の客の情報を描画
    public void DrawCustomerName(int Column)
    {
        GameObject Customer = GetObjectFromPosition(1, Column);
        GameObject Name = GetNameObjectFromColumn(Column);
        GameObject Hp = GetHpObjectFromColumn(Column);

        Name.GetComponent<Text>().text = Customer.GetComponent<CustomerStat>().Name.ToString();
            Hp.GetComponent<Text>().text = Customer.GetComponent<CustomerStat>().Hp.ToString();
    }

    //ゲーム開始時の生成
    public void MakeCustomer12()
    {
        StartCoroutine(GameStartCoroutine());
    }

        IEnumerator GameStartCoroutine()
    {
        yield return StartCoroutine(Make12Coroutine());
//        yield return new WaitForSeconds(1f);//遅延時間
        DrawCustomerName(1);
        DrawCustomerName(2);
        DrawCustomerName(3);
        DrawCustomerName(4);

    }

    IEnumerator Make12Coroutine()
    {
        int CountColumn = 1;
        int CountRow = 1;

        while (CountColumn <= 4)
        {
            CountRow = 1;
            while (CountRow <= 3)
            {

                //public void MakeCustomer(int PositionRow, int PositionColumn,
                //    int Color, int Hp, string Name, int GetPop, int GetG,
                //    string BombType, string BombTarget, int BombAmount, int BombTurn, string ItemName)                string Name = "わらにんぎょう";
                int ClearCount = playerstat.GetComponent<PlayerStat>().ClearCustomer;
                int Power = Random.Range(ClearCount / 4, ClearCount + 8);
                string Name = "初期にんぎょう";
                if (Power > ClearCount * 2 / 3) { Name = "アーリーアダプター"; }
                else if (Power > ClearCount / 2) { Name = "ネオにんぎょう"; }
                else if (Power > ClearCount / 3) { Name = "わらにんぎょう"; }
                else if (Power > ClearCount / 4) { Name = "プアーキッド"; }
                else { Name = "弱き者"; }
                float GetPop = Random.value;
                int GetG = Random.Range(Power, Power * Power / (ClearCount + 1));

                MakeCustomer(CountRow, CountColumn, Random.Range(1, 5), Power, Name, GetPop, GetG, "Bomb", "Sus", Random.Range(10, 50), Random.Range(5, 10), "パワーアップ");
                CountRow++;
            }
            CountColumn++;
        }
        yield return null;
    }

        //爆弾カウント減らして、０になれば消して効果発動
        IEnumerator ExplodeCheckCoroutine()
    {
            Debug.Log("Check");
        if (playerstat.GetComponent<PlayerStat>().NowBombCount > 0)
        {
            yield return StartCoroutine(ExplodeCountCoroutine(GameObject.FindGameObjectWithTag("1-1")));
            yield return StartCoroutine(ExplodeCountCoroutine(GameObject.FindGameObjectWithTag("1-2")));
            yield return StartCoroutine(ExplodeCountCoroutine(GameObject.FindGameObjectWithTag("1-3")));
            yield return StartCoroutine(ExplodeCountCoroutine(GameObject.FindGameObjectWithTag("1-4")));
            yield return StartCoroutine(ExplodeCountCoroutine(GameObject.FindGameObjectWithTag("2-1")));
            yield return StartCoroutine(ExplodeCountCoroutine(GameObject.FindGameObjectWithTag("2-2")));
            yield return StartCoroutine(ExplodeCountCoroutine(GameObject.FindGameObjectWithTag("2-3")));
            yield return StartCoroutine(ExplodeCountCoroutine(GameObject.FindGameObjectWithTag("2-4")));
            yield return StartCoroutine(ExplodeCountCoroutine(GameObject.FindGameObjectWithTag("3-1")));
            yield return StartCoroutine(ExplodeCountCoroutine(GameObject.FindGameObjectWithTag("3-2")));
            yield return StartCoroutine(ExplodeCountCoroutine(GameObject.FindGameObjectWithTag("3-3")));
            yield return StartCoroutine(ExplodeCountCoroutine(GameObject.FindGameObjectWithTag("3-4")));
        }
        yield return null;
    }
    IEnumerator ExplodeCountCoroutine(GameObject Customer)
    {
        if (Customer.GetComponent<CustomerStat>().Bomb == 1) {
            Customer.GetComponent<CustomerStat>().BombTurn--;
            Customer.GetComponent<CustomerStat>().BombCount.GetComponent<Text>().text = Customer.GetComponent<CustomerStat>().BombTurn.ToString();
            if (Customer.GetComponent<CustomerStat>().BombTurn <= 0) {
                yield return StartCoroutine("ExplodeCoroutine", Customer);
            }
        }
        yield return null;
    }
    IEnumerator ExplodeCoroutine(GameObject Customer)
    {
        playerstat.GetComponent<PlayerStat>().NowBombCount--;
        yield return new WaitForSeconds(0.2f);//遅延時間
        Customer.GetComponent<CustomerStat>().BombCount.GetComponent<Text>().text = "Kabooom!";
        if (Customer.GetComponent<CustomerStat>().BombTarget == "Sus")
        {
            GetComponent<PlayerController>().SusUp(Customer.GetComponent<CustomerStat>().BombAmount);
        }
        int MoveColumn = Customer.GetComponent<CustomerStat>().PositionColumn;
        int MoveRow = Customer.GetComponent<CustomerStat>().PositionRow;
        yield return new WaitForSeconds(0.2f);//遅延時間
        Destroy(Customer);
        yield return StartCoroutine(CustomerPlusCoroutine(MoveColumn, MoveRow));
        yield return null;
    }

    //個別FEED押したとき
    public void FEED1(int Column)
    {
        StartCoroutine(FEED1Coroutine(Column));
    }

    IEnumerator FEED1Coroutine(int Column)
    {
        TapBlock.SetActive(true);    
        EventSystem.SetActive(false);

        yield return StartCoroutine(CustomerCheckCoroutine(Column,"FEED1"));
        yield return StartCoroutine(ExplodeCheckCoroutine());
        
        EventSystem.SetActive(true);
        TapBlock.SetActive(false);
        yield return null;

    }
    //FEED押したとき
    public void FEED4()
    {
        TapBlock.SetActive(true);
        EventSystem.SetActive(false);
        StartCoroutine("FEED4Coroutine");
    }

    IEnumerator FEED4Coroutine()
    {

        //フラグの初期化
        FlagColumn1 = 0;
        FlagColumn2 = 0;
        FlagColumn3 = 0;
        FlagColumn4 = 0;

         StartCoroutine(CustomerCheckCoroutine(1,"FEED4"));
         StartCoroutine(CustomerCheckCoroutine(2, "FEED4"));
         StartCoroutine(CustomerCheckCoroutine(3, "FEED4"));
         StartCoroutine(CustomerCheckCoroutine(4, "FEED4"));

        yield return new WaitWhile(() => FlagColumn1==0| FlagColumn2 == 0| FlagColumn3 == 0| FlagColumn4 == 0);

        yield return StartCoroutine(ExplodeCheckCoroutine());
        EventSystem.SetActive(true);
        TapBlock.SetActive(false);
        yield return null;

    }

    //客をチェックする処理
    IEnumerator CustomerCheckCoroutine(int Column,string Mode)
    {
        GameObject Customer = GetObjectFromPosition(1, Column);
        int Damage= playerstat.GetComponent<PlayerStat>().StatBurgerPower;
        //FEED1のときは単独ボーナス
        if (Mode == "FEED1") { Damage =Damage* 3; }
        Customer.GetComponent<CustomerStat>().Hp -= Damage;

        DrawCustomerName(Column);
        if (Customer.GetComponent<CustomerStat>().Hp <= 0) { yield return StartCoroutine(CustomerDestroyCoroutine(Customer)); }

        if (Column == 1) { FlagColumn1 = 1; }
        else if (Column == 2) { FlagColumn2 = 1; }
        else if (Column == 3) { FlagColumn3 = 1; }
        else if (Column == 4) { FlagColumn4 = 1; }
        else { Debug.Log("Column is not 1~4"); }

        yield return null;
    }

    //レベルアップ
    IEnumerator LvUpCoroutine()
    {
        int Part=Random.Range(1, 5);
        string PartName = "";
        if (Part == 1) {PartName = "Buns"; }
        else if (Part == 2) { PartName = "Patty"; }
        else if (Part == 3) { PartName = "Topping"; }
        else{ PartName = "Source"; }
        GetComponent<PlayerController>().DrawLvPower(PartName, "Lv", 1);
        GetComponent<PlayerController>().DrawLvPower(PartName, "Power", playerstat.GetComponent<PlayerStat>().ClearCustomer/10);
//        Popup.SetActive(true);
//        string Text = PartName+"がレベルアップしました。";
//        PopupText1.GetComponent<Text>().text=Text;


        yield return null;
    }
    //客を消す処理
    IEnumerator CustomerDestroyCoroutine(GameObject Customer)
    {
        //爆弾の場合
        if (Customer.GetComponent<CustomerStat>().Bomb == 1)
        {
            playerstat.GetComponent<PlayerStat>().NowBombCount--;
            GetComponent<PlayerController>().PopUp(Customer.GetComponent<CustomerStat>().GetPop*10);//ボーナス値入れる
            GetComponent<PlayerController>().GUp(Customer.GetComponent<CustomerStat>().GetG*10);//ボーナス値入れる
        }
        else
        {
            GetComponent<PlayerController>().PopUp(Customer.GetComponent<CustomerStat>().GetPop);
            GetComponent<PlayerController>().GUp(Customer.GetComponent<CustomerStat>().GetG);
        }
        //レベルアップ時
        //とりあえず、１０の倍数人目のときにレベルアップさせてみる
        playerstat.GetComponent<PlayerStat>().ClearCustomer++;
        int Clear = playerstat.GetComponent<PlayerStat>().ClearCustomer;
        if (Clear %10 == 0)
        {
            yield return StartCoroutine(LvUpCoroutine());        
        }

        //消す客の名前をいったん空白にする
        int MoveColumn = Customer.GetComponent<CustomerStat>().PositionColumn;
        int MoveRow = Customer.GetComponent<CustomerStat>().PositionRow;

        GameObject Name = GetNameObjectFromColumn(MoveColumn);
        GameObject Hp = GetHpObjectFromColumn(MoveColumn);
            Name.GetComponent<Text>().text = "";
            Hp.GetComponent<Text>().text = "";

        //デストロイ
        Destroy(Customer);
        yield return StartCoroutine(CustomerPlusCoroutine(MoveColumn, MoveRow));
        yield return null;
    }
    //客を追加する処理
    IEnumerator CustomerPlusCoroutine(int MoveColumn,int MoveRow)
    {
        EventSystem.SetActive(false);
        yield return new WaitForSeconds(0.2f);//遅延時間
        //客をずらす、タグも付け替える
        string TagRow1 = "1-" + MoveColumn.ToString();
        string TagRow2 = "2-" + MoveColumn.ToString();
        string TagRow3 = "3-" + MoveColumn.ToString();
        //１列目が消えた時
        if (MoveRow == 1) {        
        GameObject Customer2n = GetObjectFromPosition(2, MoveColumn);
        GameObject Customer3n = GetObjectFromPosition(3, MoveColumn);
        Customer2n.transform.position = new Vector3(MoveColumn * 170 - 425, 1 * 200 - 200, 0);
        yield return new WaitForSeconds(0.2f);//遅延時間
        Customer3n.transform.position = new Vector3(MoveColumn * 170 - 425, 2 * 200 - 200, 0);
        Customer2n.GetComponent<CustomerStat>().PositionRow = 1;
        Customer3n.GetComponent<CustomerStat>().PositionRow = 2;
        Customer2n.tag = TagRow1;
        Customer3n.tag = TagRow2;
        }
        //２列目が消えた時
        else if (MoveRow == 2)
        {
            GameObject Customer3n = GetObjectFromPosition(3, MoveColumn);
            yield return new WaitForSeconds(0.2f);//遅延時間
            Customer3n.transform.position = new Vector3(MoveColumn * 170 - 425, 2 * 200 - 200, 0);
            Customer3n.GetComponent<CustomerStat>().PositionRow = 2;
            Customer3n.tag = TagRow2;
        }
        //３列目が消えた時
        else if (MoveRow == 3)
        {        }

        yield return new WaitForSeconds(0.2f);//遅延時間

        //新たな客を追加
        //public void MakeCustomer(int PositionRow, int PositionColumn,
        //    int Color, int Hp, string Name, int GetPop, int GetG,
        //    string BombType, string BombTarget, int BombAmount, int BombTurn, string ItemName)
        string Name = "追加戦士";
        int ClearCount = playerstat.GetComponent<PlayerStat>().ClearCustomer;
        int Power = Random.Range(ClearCount / 4, ClearCount*125/100);
        if(Power> ClearCount) {Name = "腐れ儒者"; }
        else if (Power > ClearCount/2) { Name = "バイトリーダー"; }
        else if (Power > ClearCount / 3) { Name = "アルバイトロス"; }
        else if (Power > ClearCount / 4) { Name = "ノーマルバイト"; }
        else { Name = "弱き者"; }
        float GetPop = Random.value;
        int GetG = Random.Range(Power,Power*Power/(ClearCount+1));

        MakeCustomer(3, MoveColumn, Random.Range(1, 5),Power, Name, GetPop,GetG ,"Bomb", "Sus", Random.Range(10, 50), Random.Range(5, 10), "パワーアップ");
        DrawCustomerName(MoveColumn);

        yield return new WaitForSeconds(0.2f);//遅延時間
        EventSystem.SetActive(true);
        yield return null;
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
