using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//客のステータスを保持する
//cloneして使う
public class StatCustomer : MonoBehaviour
{

    //ステータスの定義
    public string Name = "name";//名前
    public string Image = "image";//イメージのファイル名（.png抜き）
    public int Hp = 0;//舌の肥え具合
    public int CoreColor = 0;//中心色　あれば色の算出に使う
    public int Color = 0;//色
    public int DropG = 0;//報酬G
    public string[] DropItem = { "Name", "PictuePath", "Power", "Color", "Sus" };//報酬アイテム（固定）
    public string[] DropMeat = { "Name", "PictuePath", "Power", "Color", "Sus" };//肉にした場合の能力
    public int SaveSus =0;//殺した場合のSus減少値

    //ステータス表示オブジェクトの取得
    public GameObject Customer;//自分自身


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
