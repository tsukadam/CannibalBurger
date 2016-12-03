using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CustomerStat : MonoBehaviour
{
    //客のステータスを保持する
    //cloneして使う
    //オートセーブではこの中のデータがPlayerStatに移されて保持される

    //ステータスの定義
    public string Name = "name";//名前

    public string Image = "image";//イメージ名
    public int Rare = 0;//レアリティ
    public int Hp = 0;//空腹値
    public int Color = 0;//色
    public int PositionRow = 0;//列
    public int PositionColumn = 0;//行
    public float GetPop = 0;//報酬POP
    public int GetG = 0;//報酬G
    public int Bomb = 0;
    public string BombType = "";
    public string BombTarget = "";
    public int BombAmount = 0;
    public int BombTurn = 0;
    public string ItemName = "";

    //ステータス表示オブジェクトの取得
    public GameObject Customer;//自分自身
    public GameObject BombCount;

    //個別FEED押したとき
//    public void FEED1()
//    {
//        GameObject.FindGameObjectWithTag("Script").GetComponent<CustomerController>().FEED1(Customer);
//           }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
