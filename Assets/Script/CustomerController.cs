using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//客の生成を制御する
public class CustomerController : MonoBehaviour
{

    //客プレファブ
    public GameObject CustomerPrefab;

    //gamestat
    public GameObject StatGame;

    public GameObject CustomerField;//表示スペース
    //イベントシステムの取得（処理中に切る場合がある）
    public GameObject EventSystem;


    public int LowDataGetCount=0;

    public int LowName;
    public int LowImage;
    public int LowPopLv;
    public int LowDisLv;
    public int LowRare;
    public int LowHp;
    public int LowCoreColor;
    public int LowSaveSus;
    public int LowDropG;
    public int LowDropName;
    public int LowDropImage;
    public int LowDropPower;
    public int LowDropSus;
    public int LowMeatName;
    public int LowMeatImage;
    public int LowMeatPower;
    public int LowMeatSus;

    public int LowNumber;

    //そのレベルの客をレアリティごとの配列にして保持する
    public void GetCustomerData(int NowLv)
    {        
        string[,] CustomerAllData = StatGame.GetComponent<StatGame>().CustomerAllData;
        int CustomerLength= CustomerAllData.GetLength(0);
        int Count = 1;
        int ThisPopLv;
        int ThisDisLv;
        int LowCount = 0;

        //初回のみ、どの行に何のデータがあるか取得する
        if (LowDataGetCount == 0)
        {
            int CustomerLowLength = CustomerAllData.GetLength(1);
            LowCount = 0;
            while (LowCount < CustomerLowLength)
            {
                if (CustomerAllData[0, LowCount] == "Name") { LowName = LowCount; }
                else if (CustomerAllData[0, LowCount] == "Image") { LowImage = LowCount; }
                else if (CustomerAllData[0, LowCount] == "PopLv") { LowPopLv = LowCount; }
                else if (CustomerAllData[0, LowCount] == "DisLv") { LowDisLv = LowCount; }
                else if (CustomerAllData[0, LowCount] == "Rare") { LowRare = LowCount; }
                else if (CustomerAllData[0, LowCount] == "Hp") { LowHp = LowCount; }
                else if (CustomerAllData[0, LowCount] == "CoreColor") { LowCoreColor = LowCount; }
                else if (CustomerAllData[0, LowCount] == "SaveSus") { LowSaveSus = LowCount; }
                else if (CustomerAllData[0, LowCount] == "DropG") { LowDropG = LowCount; }
                else if (CustomerAllData[0, LowCount] == "DropName") { LowDropName = LowCount; }
                else if (CustomerAllData[0, LowCount] == "DImage") { LowDropImage = LowCount; }
                else if (CustomerAllData[0, LowCount] == "DPower") { LowDropPower = LowCount; }
                else if (CustomerAllData[0, LowCount] == "DSus") { LowDropSus = LowCount; }
                else if (CustomerAllData[0, LowCount] == "MeatName") { LowMeatName = LowCount; }
                else if (CustomerAllData[0, LowCount] == "MImage") { LowMeatImage = LowCount; }
                else if (CustomerAllData[0, LowCount] == "MPower") { LowMeatPower = LowCount; }
                else if (CustomerAllData[0, LowCount] == "MSus") { LowMeatSus = LowCount; }
                else { Debug.Log("Customerデータの行の取得に失敗しました Low="+ LowCount); }
                LowCount++;
            }
            LowDataGetCount = 1;
            LowNumber = LowCount;
        }
        LowCount = LowNumber;

        GetComponent<LvDesignController>().LowName = LowName;
        GetComponent<LvDesignController>().LowImage = LowImage;
        GetComponent<LvDesignController>().LowPopLv = LowPopLv;
        GetComponent<LvDesignController>().LowDisLv = LowDisLv;
        GetComponent<LvDesignController>().LowRare = LowRare;
        GetComponent<LvDesignController>().LowHp = LowHp;
        GetComponent<LvDesignController>().LowCoreColor = LowCoreColor;
        GetComponent<LvDesignController>().LowSaveSus = LowSaveSus;
        GetComponent<LvDesignController>().LowDropG = LowDropG;
        GetComponent<LvDesignController>().LowDropName = LowDropName;
        GetComponent<LvDesignController>().LowDropImage = LowDropImage;
        GetComponent<LvDesignController>().LowDropPower = LowDropPower;
        GetComponent<LvDesignController>().LowDropSus = LowDropSus;
        GetComponent<LvDesignController>().LowMeatName = LowMeatName;
        GetComponent<LvDesignController>().LowMeatImage = LowMeatImage;
        GetComponent<LvDesignController>().LowMeatPower = LowMeatPower;
        GetComponent<LvDesignController>().LowMeatSus = LowMeatSus;

        Count = 1;
        int CountC = 0;
        int CountUC = 0;
        int CountR = 0;
        int CountSR = 0;
        int CountSSR = 0;
        while (Count< CustomerLength){
            ThisPopLv = int.Parse(CustomerAllData[Count, LowPopLv]);
            ThisDisLv = int.Parse(CustomerAllData[Count, LowDisLv]);
//登場レベルの間にあるキャラなら処理する
//まずレアリティごとの数を数える
            if (NowLv>=ThisPopLv &NowLv<ThisDisLv) {
                if (CustomerAllData[Count, LowRare] == "C") { CountC++; }
                else if (CustomerAllData[Count, LowRare] == "UC") { CountUC++; }
                else if (CustomerAllData[Count, LowRare] == "R") { CountR++; }
                else if (CustomerAllData[Count, LowRare] == "SR") { CountSR++; }
                else if (CustomerAllData[Count, LowRare] == "SSR") { CountSSR++; }
                else { Debug.Log("レアリティの仕分けに失敗しています。SSRとして数えます。Column="+Count);
                    CountUC++;
                }
            }
            Count++;
        }

        string[,] CustmerC;
        string[,] CustmerUC;
        string[,] CustmerR;
        string[,] CustmerSR;
        string[,] CustmerSSR;

        if (CountC == 0) { CustmerC = new string[1, 1];CustmerC[0,0]="None"; }
        else {
            CustmerC = new string[CountC, LowCount];
        }
        if (CountUC == 0) { CustmerUC = new string[1, 1]; CustmerUC[0, 0] = "None"; }
        else {
            CustmerUC = new string[CountUC, LowCount];
        }
        if (CountR == 0) { CustmerR = new string[1, 1]; CustmerR[0, 0] = "None"; }
        else {
            CustmerR = new string[CountR, LowCount];
        }
        if (CountSR == 0) { CustmerSR = new string[1, 1]; CustmerSR[0, 0] = "None"; }
        else {
            CustmerSR = new string[CountSR, LowCount];
        }
        if (CountSSR == 0) { CustmerSSR = new string[1, 1]; CustmerSSR[0, 0] = "None"; }
        else {
            CustmerSSR = new string[CountSSR, LowCount];
        }


        //もっかい回して配列を取得
        Count = 1;
        int CountSmall = 0;
        CountC = 0;
        CountUC = 0;
        CountR = 0;
        CountSR = 0;
        CountSSR = 0;
        while (Count < CustomerLength)
        {
            ThisPopLv = int.Parse(CustomerAllData[Count, LowPopLv]);
            ThisDisLv = int.Parse(CustomerAllData[Count, LowDisLv]);
            //登場レベルの間にあるキャラなら処理する
            //まずレアリティごとの数を数える
            if( NowLv >= ThisPopLv & NowLv < ThisDisLv)
            {
                if (CustomerAllData[Count, LowRare] == "C") {
                    CountSmall = 0;
                    while (CountSmall<LowCount)
                    {
                        CustmerC[CountC, CountSmall] = CustomerAllData[Count, CountSmall];
                            CountSmall++;
                    }
                    CountC++; }
                else if (CustomerAllData[Count, LowRare] == "UC") {
                    CountSmall = 0;
                    while (CountSmall < LowCount)
                    {
                        CustmerUC[CountUC, CountSmall] = CustomerAllData[Count, CountSmall];
                        CountSmall++;
                    }
                    CountUC++;}
                else if (CustomerAllData[Count, LowRare] == "R") {
                    CountSmall = 0;
                    while (CountSmall < LowCount)
                    {
                        CustmerR[CountR, CountSmall] = CustomerAllData[Count, CountSmall];
                        CountSmall++;
                    }
                    CountR++; }
                else if (CustomerAllData[Count, LowRare] == "SR") {
                    CountSmall = 0;
                    while (CountSmall < LowCount)
                    {
                        CustmerSR[CountSR, CountSmall] = CustomerAllData[Count, CountSmall];
                        CountSmall++;
                    }
                    CountSR++; }
                else if (CustomerAllData[Count, LowRare] == "SSR") {
                    CountSmall = 0;
                    while (CountSmall < LowCount)
                    {
                        CustmerSSR[CountSSR, CountSmall] = CustomerAllData[Count, CountSmall];
                        CountSmall++;
                    }
                    CountSSR++;
               }
                else {
                    CountSmall = 0;
                    while (CountSmall < LowCount)
                    {
                        CustmerSSR[CountC, CountSmall] = CustomerAllData[Count, CountSmall];
                    CountSmall++;
                }
                CountSSR++;
                Debug.Log("レアリティの仕分けに失敗しています。SSRとして数えます。Column=" + Count);
                    CountUC++;
                }
            }
            Count++;
        }

        StatGame.GetComponent<StatGame>().CustmerC = CustmerC;
        StatGame.GetComponent<StatGame>().CustmerUC = CustmerUC;
        StatGame.GetComponent<StatGame>().CustmerR = CustmerR;
        StatGame.GetComponent<StatGame>().CustmerSR = CustmerSR;
        StatGame.GetComponent<StatGame>().CustmerSSR = CustmerSSR;



    }



    //客生成
    public void MakeCustomer(string Name,string Image, int Hp, string CoreColor,string Color, int DropG,string[] DropItem,string[]DropMeat,int SaveSus,string Rarerity,int LvAppear,int LvDisAppear)
    {
        GameObject Customer = (GameObject)Instantiate(
            CustomerPrefab,
            transform.position,
            Quaternion.identity);
//        Customer.transform.parent = CustomerField.transform;
        Customer.transform.SetParent(CustomerField.transform);

        //位置決定
        int PositionY = Random.Range(-200, 200);
        int PositionX = Random.Range(-200, 200);
        Customer.transform.position = new Vector3(PositionX, PositionY, 0);
        int ForceY = Random.Range(-1, 1);
        int ForceX = Random.Range(-1, 1);
        int ForcePower = Random.Range(5000, 50000);

        Customer.GetComponent<Rigidbody2D>().AddForce(new Vector2(ForceX, ForceY) * ForcePower);

        //画像決定

        string ImagePath = "Customer/" + Image;
        Sprite SpriteImage = Resources.Load<Sprite>(ImagePath);
        Customer.GetComponent<Image>().sprite = SpriteImage;

        //色決定
        Color CoreCol = GetComponent<ColorGetter>().ToColor(CoreColor);
        float CoreR = CoreCol.r;
        float CoreG = CoreCol.g;
        float CoreB = CoreCol.b;
  
        float PlusR = Random.Range(150f/255,-150f / 255);
        float PlusG = Random.Range(150f / 255, -150f / 255);
        float PlusB = Random.Range(150f / 255, -150f / 255);
        //        Color Col = new Color(CoreR+PlusR, CoreG + PlusG, CoreB + PlusB, 1f);
        Color Col = CoreCol;
        Customer.GetComponent<Image>().color = Col;
        string ColorString="#"+GetComponent<ColorGetter>().ToColorString(Col);
        //タグをつける
        Customer.tag = "Customer";
//アイテム選択時用のボタンを不活性にする
        Customer.GetComponent<Button>().interactable = false;

        //客の情報をカスタマーＳＴＡＴに書き込み
        Customer.GetComponent<StatCustomer>().Name = Name;
        Customer.GetComponent<StatCustomer>().Image = Image;
        Customer.GetComponent<StatCustomer>().Hp = Hp;
        Customer.GetComponent<StatCustomer>().CoreColor = CoreColor;
        Customer.GetComponent<StatCustomer>().Color = ColorString;
        Customer.GetComponent<StatCustomer>().DropG = DropG;
        Customer.GetComponent<StatCustomer>().DropItem = DropItem;
        Customer.GetComponent<StatCustomer>().DropMeat = DropMeat;
        Customer.GetComponent<StatCustomer>().SaveSus = SaveSus;
        Customer.GetComponent<StatCustomer>().Rarerity = Rarerity;
        Customer.GetComponent<StatCustomer>().LvAppear = LvAppear;
        Customer.GetComponent<StatCustomer>().LvDisAppear = LvDisAppear;

    }


}
