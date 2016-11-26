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
    public int HP = 0;//空腹値
    public int color = 0;//色
    public int PositionRow = 0;//列
    public int PositionColumn = 0;//行

    //ステータス表示オブジェクトの取得
    public Object Customer;//自分自身

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
