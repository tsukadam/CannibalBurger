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

    //イベントシステムの取得（処理中に切る場合がある）
    public GameObject EventSystem;

    //客生成
    public void MakeCustomer(int PositionRow, int PositionColumn,
        int Color,int Hp,string Name,int GetPop,int GetG,
        string BombType,string BombTarget,int BombAmount,int BombTurn,string ItemName)
    {
        GameObject Customer = (GameObject)Instantiate(
            CustomerPrefab,
            transform.position,
            Quaternion.identity);
        Customer.transform.parent = GameSpace.transform;
        int PositionY = PositionRow*200-200;
        int PositionX = PositionColumn*170-425;
        Customer.transform.position = new Vector3(PositionX,PositionY,0);
        Color Col = new Color(0,0,0,0);
        if (Color == 1) { Col = new Color(1,0,0,1); }
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
        if (playerstat.GetComponent<PlayerStat>().ClearCustomer >0)
        {
            Debug.Log("no null");
            //ボムが一つでもあれば何もしない
            if (playerstat.GetComponent<PlayerStat>().NowBombCount <= 0)
            {
                Debug.Log("no Bomb");
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
        string TagName=TagRow+"-"+TagColumn;
        Customer.tag = TagName;


    }

    //最前列の客の情報を描画
    public void DrawCustomerName()
    {
        GameObject Customer11 = GameObject.FindGameObjectWithTag("1-1");
        Customer11Name.GetComponent<Text>().text = Customer11.GetComponent<CustomerStat>().Name.ToString();
        Customer11Hp.GetComponent<Text>().text = Customer11.GetComponent<CustomerStat>().Hp.ToString();

        GameObject Customer12 = GameObject.FindGameObjectWithTag("1-2");
        Customer12Name.GetComponent<Text>().text = Customer12.GetComponent<CustomerStat>().Name.ToString();
        Customer12Hp.GetComponent<Text>().text = Customer12.GetComponent<CustomerStat>().Hp.ToString();

        GameObject Customer13 = GameObject.FindGameObjectWithTag("1-3");
        Customer13Name.GetComponent<Text>().text = Customer13.GetComponent<CustomerStat>().Name.ToString();
        Customer13Hp.GetComponent<Text>().text = Customer13.GetComponent<CustomerStat>().Hp.ToString();

        GameObject Customer14 = GameObject.FindGameObjectWithTag("1-4");
        Customer14Name.GetComponent<Text>().text = Customer14.GetComponent<CustomerStat>().Name.ToString();
        Customer14Hp.GetComponent<Text>().text = Customer14.GetComponent<CustomerStat>().Hp.ToString();

    }

    //ゲーム開始時の生成
    public void MakeCustomer12()
    {
        string Name = "わらにんぎょう";
        MakeCustomer(1, 1,Random.Range(1,5), Random.Range(20, 120),"切込隊長", Random.Range(0, 10)/10, Random.Range(10, 200), "Bomb", "Sus", 10, 3, "パワーアップ");
        MakeCustomer(2, 1, Random.Range(1, 5), Random.Range(20, 120), Name, Random.Range(0, 10) / 10, Random.Range(10, 200), "Bomb", "Sus", 10, 3, "パワーアップ");
        MakeCustomer(3, 1, Random.Range(1, 5), Random.Range(20, 120), Name, Random.Range(0, 10) / 10, Random.Range(10, 200), "Bomb", "Sus", 10, 3, "パワーアップ");
        MakeCustomer(1, 2, Random.Range(1, 5), Random.Range(20, 120), "セカンドライフ", Random.Range(0, 10) / 10, Random.Range(10, 200), "Bomb", "Sus", 10, 3, "パワーアップ");
        MakeCustomer(2, 2, Random.Range(1, 5), Random.Range(20, 120), Name, Random.Range(0, 10) / 10, Random.Range(10, 200), "Bomb", "Sus", 10, 3, "パワーアップ");
        MakeCustomer(3, 2, Random.Range(1, 5), Random.Range(20, 120), Name, Random.Range(0, 10) / 10, Random.Range(10, 200), "Bomb", "Sus", 10, 3, "パワーアップ");
        MakeCustomer(1, 3, Random.Range(1, 5), Random.Range(20, 120), "第三の男", Random.Range(0, 10) / 10, Random.Range(10, 200), "Bomb", "Sus", 10, 3, "パワーアップ");
        MakeCustomer(2, 3, Random.Range(1, 5), Random.Range(20, 120), Name, Random.Range(0, 10) / 10, Random.Range(10, 200), "Bomb", "Sus", 10, 3, "パワーアップ");
        MakeCustomer(3, 3, Random.Range(1, 5), Random.Range(20, 120), Name, Random.Range(0, 10) / 10, Random.Range(10, 200), "Bomb", "Sus", 10, 3, "パワーアップ");
        MakeCustomer(1, 4, Random.Range(1, 5), Random.Range(20, 120), "４６４９", Random.Range(0, 10) / 10, Random.Range(10, 200), "Bomb", "Sus", 10, 3, "パワーアップ");
        MakeCustomer(2, 4, Random.Range(1, 5), Random.Range(20, 120), Name, Random.Range(0, 10) / 10, Random.Range(10, 200), "Bomb", "Sus", 10, 3, "パワーアップ");
        MakeCustomer(3, 4, Random.Range(1, 5), Random.Range(20, 120), Name, Random.Range(0, 10) / 10, Random.Range(10, 200), "Bomb", "Sus", 10, 3, "パワーアップ");
        DrawCustomerName();
    }

    //爆弾カウント減らして、０になれば消して効果発動
    public void ExplodeCheck()
    {
        if (playerstat.GetComponent<PlayerStat>().NowBombCount > 0)
        {
            ExplodeCount(GameObject.FindGameObjectWithTag("1-1"));
            ExplodeCount(GameObject.FindGameObjectWithTag("1-2"));
            ExplodeCount(GameObject.FindGameObjectWithTag("1-3"));
            ExplodeCount(GameObject.FindGameObjectWithTag("1-4"));
            ExplodeCount(GameObject.FindGameObjectWithTag("2-1"));
            ExplodeCount(GameObject.FindGameObjectWithTag("2-2"));
            ExplodeCount(GameObject.FindGameObjectWithTag("2-3"));
            ExplodeCount(GameObject.FindGameObjectWithTag("2-4"));
            ExplodeCount(GameObject.FindGameObjectWithTag("3-1"));
            ExplodeCount(GameObject.FindGameObjectWithTag("3-2"));
            ExplodeCount(GameObject.FindGameObjectWithTag("3-3"));
            ExplodeCount(GameObject.FindGameObjectWithTag("3-4"));
        }

    }
    public void ExplodeCount(GameObject Customer)
    {
            if (Customer.GetComponent<CustomerStat>().Bomb == 1) {
                Customer.GetComponent<CustomerStat>().BombTurn--;
                Customer.GetComponent<CustomerStat>().BombCount.GetComponent<Text>().text = Customer.GetComponent<CustomerStat>().BombTurn.ToString();
                if (Customer.GetComponent<CustomerStat>().BombTurn <= 0) {
                    StartCoroutine("ExplodeCoroutine", Customer);
                }
            }
    }
    IEnumerator ExplodeCoroutine(GameObject Customer)
    {
        playerstat.GetComponent<PlayerStat>().NowBombCount--;
        yield return new WaitForSeconds(0.5f);//遅延時間
        Customer.GetComponent<CustomerStat>().BombCount.GetComponent<Text>().text = "Kabooom!";
        if (Customer.GetComponent<CustomerStat>().BombTarget == "Sus")
        {
            GetComponent<PlayerController>().SusUp(Customer.GetComponent<CustomerStat>().BombAmount);
        }
        int MoveColumn = Customer.GetComponent<CustomerStat>().PositionColumn;
        int MoveRow = Customer.GetComponent<CustomerStat>().PositionRow;
        yield return new WaitForSeconds(0.5f);//遅延時間
        Destroy(Customer);
        CustomerPlus(MoveColumn,MoveRow);
    }

    //個別FEED押したとき
    public void FEED1(GameObject Customer)
    {
        StartCoroutine("FEED1Coroutine",Customer);
    }

    IEnumerator FEED1Coroutine(GameObject Customer)
    {
        EventSystem.SetActive(false);
        //ＨＰからパワーぶん引く
        //単独の時のパワーボーナスかける
        Customer.GetComponent<CustomerStat>().Hp -= playerstat.GetComponent<PlayerStat>().StatBurgerPower*3;
        DrawCustomerName();

        if (Customer.GetComponent<CustomerStat>().Hp <= 0) { CustomerDestroy(Customer); }
        yield return new WaitForSeconds(2.75f);//遅延時間        
        ExplodeCheck();
        EventSystem.SetActive(true);

    }
    //FEED押したとき
    public void FEED4()
    {
        StartCoroutine("FEED4Coroutine");
    }


    IEnumerator FEED4Coroutine()
    {
        EventSystem.SetActive(false);

        //ＨＰからパワーぶん引く
        GameObject Customer11 = GameObject.FindGameObjectWithTag("1-1");
        GameObject Customer12 = GameObject.FindGameObjectWithTag("1-2");
        GameObject Customer13 = GameObject.FindGameObjectWithTag("1-3");
        GameObject Customer14 = GameObject.FindGameObjectWithTag("1-4");
        Customer11.GetComponent<CustomerStat>().Hp -= playerstat.GetComponent<PlayerStat>().StatBurgerPower;
        Customer12.GetComponent<CustomerStat>().Hp -= playerstat.GetComponent<PlayerStat>().StatBurgerPower;
        Customer13.GetComponent<CustomerStat>().Hp -= playerstat.GetComponent<PlayerStat>().StatBurgerPower;
        Customer14.GetComponent<CustomerStat>().Hp -= playerstat.GetComponent<PlayerStat>().StatBurgerPower;
        DrawCustomerName();

        if (Customer11.GetComponent<CustomerStat>().Hp <= 0) { CustomerDestroy(Customer11); }
        if (Customer12.GetComponent<CustomerStat>().Hp <= 0) { CustomerDestroy(Customer12); }
        if (Customer13.GetComponent<CustomerStat>().Hp <= 0) { CustomerDestroy(Customer13); }
        if (Customer14.GetComponent<CustomerStat>().Hp <= 0) { CustomerDestroy(Customer14); }
        yield return new WaitForSeconds(2.75f);//遅延時間        
        ExplodeCheck();
        EventSystem.SetActive(true);

    }
    //客を消す処理（追加する処理を中で呼ぶ）
    public void CustomerDestroy(GameObject Customer)
    {
        //爆弾の場合
        if (Customer.GetComponent<CustomerStat>().Bomb == 1)
        {
            playerstat.GetComponent<PlayerStat>().NowBombCount--;
            GetComponent<PlayerController>().PopUp(Customer.GetComponent<CustomerStat>().GetPop*3);//ボーナス値入れる
            GetComponent<PlayerController>().GUp(Customer.GetComponent<CustomerStat>().GetG*3);//ボーナス値入れる
        }
        else
        {
            GetComponent<PlayerController>().PopUp(Customer.GetComponent<CustomerStat>().GetPop);
            GetComponent<PlayerController>().GUp(Customer.GetComponent<CustomerStat>().GetG);
        }
        int MoveColumn = Customer.GetComponent<CustomerStat>().PositionColumn;
        int MoveRow = Customer.GetComponent<CustomerStat>().PositionRow;
        if (Customer.GetComponent<CustomerStat>().PositionColumn == 1)
        {
            Customer11Name.GetComponent<Text>().text = "";
            Customer11Hp.GetComponent<Text>().text = "";
        }
        else if (Customer.GetComponent<CustomerStat>().PositionColumn == 2)
        {
            Customer12Name.GetComponent<Text>().text = "";
            Customer12Hp.GetComponent<Text>().text = "";
        }
        else if (Customer.GetComponent<CustomerStat>().PositionColumn == 3)
        {
            Customer13Name.GetComponent<Text>().text = "";
            Customer13Hp.GetComponent<Text>().text = "";
        }
        else if (Customer.GetComponent<CustomerStat>().PositionColumn == 4)
        {
            Customer14Name.GetComponent<Text>().text = "";
            Customer14Hp.GetComponent<Text>().text = "";
        }
        else { Debug.Log("Destroy Column is not 1~4"); }
        playerstat.GetComponent<PlayerStat>().ClearCustomer++;
        Destroy(Customer);
        CustomerPlus(MoveColumn,MoveRow);

    }

    //客を追加する処理
    public void CustomerPlus(int MoveColumn,int MoveRow)
    {
        StartCoroutine(CustomerPlusCoroutine(MoveColumn,MoveRow));
    }
    IEnumerator CustomerPlusCoroutine(int MoveColumn,int MoveRow)
    {
        EventSystem.SetActive(false);
        yield return new WaitForSeconds(0.5f);//遅延時間
        //上の客をずらす、タグも付け替える
        string TagRow1 = "1-" + MoveColumn.ToString();
        string TagRow2 = "2-" + MoveColumn.ToString();
        string TagRow3 = "3-" + MoveColumn.ToString();
        if (MoveRow == 1) {        
        GameObject Customer2n = GameObject.FindGameObjectWithTag(TagRow2);
        GameObject Customer3n = GameObject.FindGameObjectWithTag(TagRow3);
        Customer2n.transform.position = new Vector3(MoveColumn * 170 - 425, 1 * 200 - 200, 0);
        yield return new WaitForSeconds(0.5f);//遅延時間
        Customer3n.transform.position = new Vector3(MoveColumn * 170 - 425, 2 * 200 - 200, 0);
        Customer2n.GetComponent<CustomerStat>().PositionRow = 1;
        Customer3n.GetComponent<CustomerStat>().PositionRow = 2;
        Customer2n.tag = TagRow1;
        Customer3n.tag = TagRow2;
        }
        else if (MoveRow == 2)
        {
            GameObject Customer3n = GameObject.FindGameObjectWithTag(TagRow3);
            yield return new WaitForSeconds(0.5f);//遅延時間
            Customer3n.transform.position = new Vector3(MoveColumn * 170 - 425, 2 * 200 - 200, 0);
            Customer3n.GetComponent<CustomerStat>().PositionRow = 2;
            Customer3n.tag = TagRow2;
        }
        else if (MoveRow == 3)
        {        }

        yield return new WaitForSeconds(0.5f);//遅延時間

        string Name = "追加戦士";
        MakeCustomer(3, MoveColumn, Random.Range(1, 5), Random.Range(60, 200), Name, Random.Range(0, 10) / 10, Random.Range(10, 200) ,"Bomb", "Sus", Random.Range(10, 50), Random.Range(5, 10), "パワーアップ");
        DrawCustomerName();


        EventSystem.SetActive(true);
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
