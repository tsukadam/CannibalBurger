using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ContrallerCustomer : MonoBehaviour {

    //客オブジェクトの取得
    public GameObject Ct1;
    public GameObject Ct2;
    public GameObject Ct3;
    public GameObject Ct4;
    public GameObject Ct5;
    public GameObject Ct6;
    public GameObject Ct7;
    public GameObject Ct8;
    public GameObject Ct9;
    public GameObject Ct10;


    public Color Red1;
    public Color Red2;
    public Color Green1;
    public Color Green2;
    public Color Yellow1;
    public Color Yellow2;
    public Color White1;
    public Color White2;

    int Ct1AnimeFlag = 0;
    int Ct2AnimeFlag = 0;
    int Ct3AnimeFlag = 0;
    int Ct4AnimeFlag = 0;
    int Ct5AnimeFlag = 0;
    int Ct6AnimeFlag = 0;
    int Ct7AnimeFlag = 0;
    int Ct8AnimeFlag = 0;
    int Ct9AnimeFlag = 0;
    int Ct10AnimeFlag = 0;

    // Use this for initialization
    void Start () {
	}

    public Color ColorReturn(int ColorMain, int ColorSub, int ColorType, int Cl) {
        Color ReturnColor = new Color(1f, 1f, 1f, 1f);
        //4色は白固定
        Color Cl4Color = new Color(1f, 1f, 1f, 1f);
        //3色は黒固定
        Color Cl3Color = new Color(0f, 0f, 0f, 1f);

        //単色キャラは1・2色がメイン色
        if (ColorType == 1) {
            if (Cl == 1)
            {
                if (ColorMain == 0) { ReturnColor = Red1; }
                else if (ColorMain == 1) { ReturnColor = Green1; }
                else if (ColorMain == 2) { ReturnColor = Yellow1; }
                else if (ColorMain == 3) { ReturnColor = White1; }
                else {
                    Debug.Log("色指定が0～3以外になっている");
                }
            }
            else if (Cl == 2)
            {
                if (ColorMain == 0) { ReturnColor = Red2; }
                else if (ColorMain == 1) { ReturnColor = Green2; }
                else if (ColorMain == 2) { ReturnColor = Yellow2; }
                else if (ColorMain == 3) { ReturnColor = White2; }
                else {
                    Debug.Log("色指定が0～3以外になっている");
                }
            }
            else if (Cl == 3)
            {
                ReturnColor = Cl3Color;
            }
            else if (Cl == 4)
            {
                ReturnColor = Cl4Color;
            }
            else { Debug.Log("色パーツ指定が1～2以外になっている"); }
        }

        //複数色キャラは1色がメイン色、2色がサブ色
        else{
            if (Cl == 1)
            {
                if (ColorMain == 0) { ReturnColor = Red1; }
                else if (ColorMain == 1) { ReturnColor = Green1; }
                else if (ColorMain == 2) { ReturnColor = Yellow1; }
                else if (ColorMain == 3) { ReturnColor = White1; }
                else {
                    Debug.Log("色指定が0～3以外になっている");
                }
            }
            else if (Cl == 2)
            {
                if (ColorSub == 0) { ReturnColor = Red2; }
                else if (ColorSub == 1) { ReturnColor = Green2; }
                else if (ColorSub == 2) { ReturnColor = Yellow2; }
                else if (ColorSub == 3) { ReturnColor = White2; }
                else {
                    Debug.Log("色指定が0～3以外になっている");
                }
            }
            else if (Cl == 3)
            {
                ReturnColor = Cl3Color;
            }
            else if (Cl == 4)
            {
                ReturnColor = Cl4Color;
            }
            else { Debug.Log("色パーツ指定が1～4以外になっている"); }

        }

        return ReturnColor;
    }
    public void CustomerMake2(int Count){ 
        for (int i = 1; i <= Count; i++)
        {
            CustomerMake(i,Count);
        }
    }

    public void CustomerMake(int Number,int Count) {
        //種族指定
        string Tribe = "BlondGirl";
        int TribePick = Random.Range(0,8);
        if (TribePick == 0){Tribe = "BlondGirl";}
        else if (TribePick == 1) { Tribe = "Butcher"; }
        else if (TribePick == 2) { Tribe = "EnlightGirl"; }
        else if (TribePick == 3) { Tribe = "Jungian"; }
        else if (TribePick == 4) { Tribe = "KodawariSenior"; }
        else if (TribePick == 5) { Tribe = "MethylMaker"; }
        else if (TribePick == 6) { Tribe = "Moretsu"; }
        else{ Tribe = "StarBoy"; }

        //各色パーツごとの画像指定
        GameObject NewCustomer =null;
        string Name = "Customer" + Number;

        //どのCtを使うか指定
        if (Number == 1) { NewCustomer = Ct1;}
        else if (Number == 2) { NewCustomer = Ct2;}
        else  if (Number == 3) { NewCustomer = Ct3;}
        else if (Number == 4) { NewCustomer = Ct4;}
        else if (Number == 5) { NewCustomer = Ct5;}
        else if (Number == 6) { NewCustomer = Ct6; }
        else if (Number == 7) { NewCustomer = Ct7; }
        else if (Number == 8) { NewCustomer = Ct8; }
        else if (Number == 9) { NewCustomer = Ct9; }
        else if (Number == 10) { NewCustomer = Ct10; }
        else { Debug.Log("人数があらかじめ用意したCtの数を超えている"); }

        //色範囲のオブジェクトを取得し、画像を入れる
        GameObject Cl1Ob = GameObject.Find(Name+"/Color1");
        GameObject Cl2Ob = GameObject.Find(Name + "/Color2");
        GameObject Cl3Ob = GameObject.Find(Name + "/Color3");
        GameObject Cl4Ob = GameObject.Find(Name + "/Color4");
        Image Cl1 = Cl1Ob.GetComponent<Image>();
        Image Cl2 = Cl2Ob.GetComponent<Image>();
        Image Cl3 = Cl3Ob.GetComponent<Image>();
        Image Cl4 = Cl4Ob.GetComponent<Image>();    
        Cl1.sprite= Resources.Load<Sprite>("People/"+Tribe+"1");
        Cl2.sprite = Resources.Load<Sprite>("People/" + Tribe + "2");
        Cl3.sprite = Resources.Load<Sprite>("People/" + Tribe + "3");
        Cl4.sprite = Resources.Load<Sprite>("People/" + Tribe + "4");

        //メイン色の指定
        //Rate1~4はそれぞれの色の出る割合
        //Rate5は多色になる確率
        float Rate1 =2;
        float Rate2 = 2;
        float Rate3 = 2;
        float Rate4 = 1;
        float Rate5 = 70;
        //0があれば、それは1/10000000として扱う
        float ZeroRate = 1 / 10000000;
        if (Rate1 == 0) { Rate1 = ZeroRate; }
        if (Rate2 == 0) { Rate2 = ZeroRate; }
        if (Rate3 == 0) { Rate3 = ZeroRate; }
        if (Rate4 == 0) { Rate4 = ZeroRate; }
        //百分率に直す
        float AllRate = Rate1 + Rate2 + Rate3 + Rate4;
        Rate1 = Rate1 * 100/AllRate;
        Rate2 = Rate2 * 100 / AllRate;
        Rate3 = Rate3 * 100 / AllRate;
        Rate4 = Rate4 * 100 / AllRate;
        //境目を求める
        float Rate1Min = 0;
        float Rate1Max = Rate1;
        float Rate2Min = Rate1Max;
        float Rate2Max = Rate1+Rate2;
        float Rate3Min = Rate2Max;
        float Rate3Max = Rate1 + Rate2+Rate3;
        float Rate4Min = Rate3Max;
        float Rate4Max = 100;
        //乱数で決定
        int ColorPick1 = Random.Range(0, 100);
        //Debug.Log(ColorPick1);
        int ColorMain = 3;
        if (Rate1Min <= ColorPick1 && ColorPick1 < Rate1Max) { ColorMain = 0; }
        else if (Rate2Min <= ColorPick1 && ColorPick1 < Rate2Max) { ColorMain = 1; }
        else if (Rate3Min <= ColorPick1 && ColorPick1 < Rate3Max) { ColorMain = 2; }
        else if (Rate4Min <= ColorPick1 && ColorPick1 < Rate4Max) { ColorMain = 3; }
        else { Debug.Log("メイン色が適切に決定されていない。とりあえず白にした"); }

        //色数の決定
        int ColorType = 1;
        int ColorPick2 = Random.Range(0, 100);
        if (ColorPick2 <= Rate5) { ColorType = 2; }
        //メイン白の場合は色数１
        if (ColorMain == 3) { ColorType = 1; }

        //サブ色の指定
        int ColorSub = 3;
        //色数１の場合はサブ色とメイン色を合わせる
        if (ColorType == 1) { ColorSub = ColorMain; }
        else { 
        //色確立はメイン色と同じ
        //ただし白は二色目にならない
        int Rate3Maxint = (int)Rate3Max;
        int ColorPick3 = Random.Range(0, Rate3Maxint);
        if (Rate1Min <= ColorPick3 && ColorPick3 < Rate1Max) { ColorSub = 0; }
        else if (Rate2Min <= ColorPick3 && ColorPick3 < Rate2Max) { ColorSub = 1; }
        else if (Rate3Min <= ColorPick3 && ColorPick3 < Rate3Maxint) { ColorSub = 2; }
        else { Debug.Log("メイン色が適切に決定されていない。とりあえず白にした"); }

        }

        Debug.Log("Ct["+Number+"] Main:"+ColorMain+" Sub:"+ColorSub+" Type:"+ ColorType);

        //メイン色、サブ色、塗り範囲から色を取得し、入れる
        Cl1.color = ColorReturn(ColorMain, ColorSub, ColorType, 1);
        Cl2.color = ColorReturn(ColorMain, ColorSub, ColorType, 2);
        Cl3.color = ColorReturn(ColorMain, ColorSub, ColorType, 3);
        Cl4.color = ColorReturn(ColorMain, ColorSub, ColorType, 4);

        Cl1.SetNativeSize();
        Cl2.SetNativeSize();
        Cl3.SetNativeSize();
        Cl4.SetNativeSize();

        //縦位置の指定
        //全体の2/3までは３列、そのあとは２列
        int FloorHeight = 0;
        int FloorAll = 380;
        float m = 2/3f;
        if (Number <= Count*m) {
            if (Number % 3 == 0)
            {
                FloorHeight = FloorAll / Count * (Number - 2) ;
            }
            else if (Number % 3 == 1)
            {
                FloorHeight = FloorAll / Count * Number;
            }
            else
            {
                FloorHeight = FloorAll / Count * (Number - 1);
            }
        }
        else {
            if (Number % 2 == 0)
            {
                FloorHeight = FloorAll / Count * Number;
            }
            else
            {
                FloorHeight = FloorAll / Count * (Number - 1);
            }
        }
        int PosY = FloorHeight - 180;

        //横位置の指定
        int PosX = Random.Range(40, 200);
        if (Number <= Count * m)
        {
            PosX = Random.Range(100, 200);
            if (Number % 3 == 0) { PosX = PosX * -1; }
           else if (Number % 3 == 1) { PosX = Random.Range(-40, 40); }
            else { PosX = PosX * 1; }
        }
        else
        {
            PosX = Random.Range(40, 200);
            if (Number % 2 == 0) { PosX = PosX * -1; }
            else { PosX = PosX * 1; }
        }

        //配置とスケールを決める
        NewCustomer.GetComponent<RectTransform>().localPosition = new Vector2(PosX,PosY);
        NewCustomer.GetComponent<RectTransform>().localScale = new Vector3(0.7f,0.7f,1.0f);
        //アニメーションを始める
        MoveCustomer(NewCustomer);
    }

    void MoveCustomer(GameObject Customer)
    {
        float WaitTime = Random.Range(3f, 5f);
        StartCoroutine(MoveCustomerCoroutine(Customer, WaitTime));
}


    //客につけるアニメーション
    IEnumerator MoveCustomerCoroutine(GameObject Customer,float WaitTime)
    {
        Vector2 pos = Customer.GetComponent<RectTransform>().localPosition;
        int Count = 0;
        int PositionX = (int)pos.x;
        //移動幅、移動速度は客ごとに固定
        int MoveWidthSize = Random.Range(-50,50);
        float MoveTime = Random.Range(4f, 6f);
        int MoveWidth = MoveWidthSize;

        while (Count < 100)
        {
        //奇数回目の動きは逆にする
            if (Count % 2 == 1) {
                MoveWidth = PositionX -MoveWidthSize;
                Customer.GetComponent<RectTransform>().localScale = new Vector3(-0.7f, 0.7f, 1.0f);

            }
            else {
                MoveWidth = PositionX;
                Customer.GetComponent<RectTransform>().localScale = new Vector3(0.7f, 0.7f, 1.0f);
            }

            iTween.MoveTo(Customer, iTween.Hash(
        "x", MoveWidth,
        "time", MoveTime,
        "easeType", "easeInOutSine"
        ));
            //      Debug.Log("MoveWidth:"+MoveWidth+" Count:"+Count);

            yield return new WaitForSeconds(WaitTime);
            Count++;
        }

    }

    // Update is called once per frame
    void Update () {
	
	}
}
