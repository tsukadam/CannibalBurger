using UnityEngine;
using UnityEngine.UI;
public class ContrallerDisplay : MonoBehaviour {
    //画面の移動、ウインドウの表示、文字の表示等についてはこのスクリプトで記述される
    //他のスクリプトで生成された文字も、このスクリプトを経由して表示方法が決定される


    public GameObject Column1;
    public GameObject Column2;
    public GameObject Column3;
    public GameObject Column4;
    public GameObject Column5;
    public GameObject CanvasContent;
    public GameObject StatPannel;

    public GameObject BoxRoom;
    public GameObject BoxItem;
    public GameObject BoxStatus;
    public GameObject BoxSetting;
    public GameObject BoxMenu;
    public GameObject BoxShop;
    public GameObject BoxCook;
    public GameObject BoxResult;
    public GameObject BoxTown;
    public GameObject BoxMarket;
    public GameObject BoxPolice;
    public GameObject BoxLibrary;
    public GameObject BoxAssembly;
    public GameObject BoxWhoiswho;
    public GameObject BoxHistory;


    float FlagMove = 0;
    float SizeW = 720;
    float SizeH = 1280;

    void MoveDisplay(float x1,float y1, float x2, float y2) {
        iTween.MoveTo(CanvasContent, iTween.Hash(
        "position", new Vector3(x1-x2, y1-y2,0),
        "time", 0.5f,
        "easeType", "easeInOutQuad"
        ));
        Invoke("FlagMoveOff", 0.5f);
    }

    void FlagMoveOn() {
        FlagMove = 1;
    }
    void FlagMoveOff(){
        FlagMove = 0;
    }

    // Use this for initialization
    void Start () {
        MoveDisplay(SizeW, -SizeH * 3/2, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        float x2 = Input.GetAxis("Horizontal");
        float y2 = Input.GetAxis("Vertical");
        Vector3 CanvasContentPosition = CanvasContent.transform.position;
        float x1 = CanvasContentPosition.x;
        float y1 = CanvasContentPosition.y;
        //キー入力方向に画面を動かす。デバッグ用。
        if ((x2!=0||y2!=0)&&FlagMove == 0)
        {
            FlagMoveOn();
            if (x2 == 0) { x2 = 0; }
            else if (x2 < 0) { x2 = -1 * SizeW; }
            else { x2 = SizeW; }
            if (y2 == 0) { y2 = 0; }
            else if (y2 < 0) { y2 = -1 * SizeH; }
            else { y2 = SizeH; }
            MoveDisplay(x1, y1, x2, y2);
            Debug.Log("x1:"+x1+" y1:"+y1);

        }
        //表示領域から離れた画面は非アクティブにする
        //最終的には、画面移動時のみ発動すれば負荷を減らせるはず
        if (x1 <= -SizeW * 2)
        {
            Column1.SetActive(false);
            Column2.SetActive(false);
            Column3.SetActive(false);
            Column4.SetActive(true);
            Column5.SetActive(true);
        }
        else if (x1 <= -SizeW && x1 > -SizeW * 2)
        {
            Column1.SetActive(false);
            Column2.SetActive(false);
            Column3.SetActive(true);
            Column4.SetActive(true);
            Column5.SetActive(true);
        }
        else if (x1 <= 0 && x1 > -SizeW)
        {
            Column1.SetActive(false);
            Column2.SetActive(true);
            Column3.SetActive(true);
            Column4.SetActive(true);
            Column5.SetActive(false);
        }
        else if (x1 <= SizeW && x1 > 0)
        {
            Column1.SetActive(true);
            Column2.SetActive(true);
            Column3.SetActive(true);
            Column4.SetActive(false);
            Column5.SetActive(false);
        }
        else if (x1 > SizeW)
        {
            Column1.SetActive(true);
            Column2.SetActive(true);
            Column3.SetActive(false);
            Column4.SetActive(false);
            Column5.SetActive(false);
        }

        if (y1 <= -SizeH * 3 / 2)
        {
            BoxRoom.SetActive(true);
            BoxMenu.SetActive(true); 
            BoxTown.SetActive(true); 
            BoxMarket.SetActive(true); 

            BoxItem.SetActive(true); 
            BoxShop.SetActive(true); 
            BoxPolice.SetActive(true); 

            BoxCook.SetActive(false); 
            BoxLibrary.SetActive(false); 
            BoxWhoiswho.SetActive(false); 

            BoxStatus.SetActive(false); 
            BoxResult.SetActive(false); 
            BoxAssembly.SetActive(false); 
            BoxHistory.SetActive(false);

            BoxSetting.SetActive(false); 
        }
        else if (y1 <= -SizeH * 3 / 2 + SizeH && y1 > -SizeH * 3 / 2)
        {
            BoxRoom.SetActive(true);
            BoxMenu.SetActive(true);
            BoxTown.SetActive(true);
            BoxMarket.SetActive(true);

            BoxItem.SetActive(true);
            BoxShop.SetActive(true);
            BoxPolice.SetActive(true);

            BoxCook.SetActive(true);
            BoxLibrary.SetActive(true);
            BoxWhoiswho.SetActive(true);

            BoxStatus.SetActive(false);
            BoxResult.SetActive(false);
            BoxAssembly.SetActive(false);
            BoxHistory.SetActive(false);

            BoxSetting.SetActive(false);
        }
        else if (y1 <= -SizeH * 3 / 2 + SizeH*2  && y1 > -SizeH * 3 / 2+SizeH)
        {
            BoxRoom.SetActive(false);
            BoxMenu.SetActive(false);
            BoxTown.SetActive(false);
            BoxMarket.SetActive(false);

            BoxItem.SetActive(true);
            BoxShop.SetActive(true);
            BoxPolice.SetActive(true);

            BoxCook.SetActive(true);
            BoxLibrary.SetActive(true);
            BoxWhoiswho.SetActive(true);

            BoxStatus.SetActive(true);
            BoxResult.SetActive(true);
            BoxAssembly.SetActive(true);
            BoxHistory.SetActive(true);

            BoxSetting.SetActive(false);
        }
        else if (y1 <= -SizeH * 3 / 2 + SizeH * 3 && y1 > -SizeH * 3 / 2 + SizeH*2)
        {
            BoxRoom.SetActive(false);
            BoxMenu.SetActive(false);
            BoxTown.SetActive(false);
            BoxMarket.SetActive(false);

            BoxItem.SetActive(false);
            BoxShop.SetActive(false);
            BoxPolice.SetActive(false);

            BoxCook.SetActive(true);
            BoxLibrary.SetActive(true);
            BoxWhoiswho.SetActive(true);

            BoxStatus.SetActive(true);
            BoxResult.SetActive(true);
            BoxAssembly.SetActive(true);
            BoxHistory.SetActive(true);

            BoxSetting.SetActive(true);
        }
        else if (y1 > -SizeH * 3 / 2 + SizeH * 3)
        {
            BoxRoom.SetActive(false);
            BoxMenu.SetActive(false);
            BoxTown.SetActive(false);
            BoxMarket.SetActive(false);

            BoxItem.SetActive(false);
            BoxShop.SetActive(false);
            BoxPolice.SetActive(false);

            BoxCook.SetActive(false);
            BoxLibrary.SetActive(false);
            BoxWhoiswho.SetActive(false);

            BoxStatus.SetActive(true);
            BoxResult.SetActive(true);
            BoxAssembly.SetActive(true);
            BoxHistory.SetActive(true);

            BoxSetting.SetActive(true);
        }

    }



}
