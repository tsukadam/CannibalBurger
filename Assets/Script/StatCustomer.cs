using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;
//客のステータスを保持する
//cloneして使う
public class StatCustomer : MonoBehaviour
{

    //ステータスの定義
    public int Id = 0;//名前
    public string Name = "name";//名前
    public string Image = "image";//イメージのファイル名（.png抜き）
    public int Hp = 0;//舌の肥え具合
    public string CoreColor = "corecolor";//中心色　あれば色の算出に使う
    public string Color = "color";//色
    public int DropG = 0;//報酬G
    public string[] DropItem = { "Name", "PictuePath", "Power", "Color", "Sus" };//報酬アイテム（固定）
    public string[] DropMeat = { "Name", "PictuePath", "Power", "Color", "Sus" };//肉にした場合の能力
    public int SaveSus =0;//殺した場合のSus減少値
    public string Rarerity = "";//レアリティ
    public int LvAppear = 0;//出現レベル
    public int LvDisAppear = 999;//いなくなるレベル


    //計算用の記録領域
    public int PointPower = 0;//点数での勝利度合
    public float PointColor = 0;//色での勝利度合

    //ステータス表示オブジェクトの取得
    public GameObject Customer;//自分自身


    public void Glow()
    {

        DOTween.To(
                    () => Customer.GetComponent<GlowImage>().glowSize,
        (x) => Customer.GetComponent<GlowImage>().glowSize = (-4 * x * (x - 1) )+ 0.5f,
                    1,
                    3.0f
                    ).SetLoops(-1);

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
