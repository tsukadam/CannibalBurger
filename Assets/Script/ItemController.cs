using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//アイテムの生成を制御する
public class ItemController : MonoBehaviour
{

    //アイテムプレファブ
    public GameObject ItemDrawPrefab;

    public GameObject CustomerField;//表示スペース

    //イベントシステムの取得（処理中に切る場合がある）
    public GameObject EventSystem;

    //アイテム生成
    public void MakeItem(string Name, string Image, int Power, Color Col, int UpSus,int PositionX,int PositionY,string TagName)
    {
        GameObject Item = (GameObject)Instantiate(
            ItemDrawPrefab,
            transform.position,
            Quaternion.identity);
        //        Customer.transform.parent = CustomerField.transform;
        Item.transform.SetParent(CustomerField.transform);

        //位置決定
        Item.transform.position = new Vector3(PositionX, PositionY, 0);

        //画像決定
        string ImagePath = "Item/" + Image;
        Sprite SpriteImage = Resources.Load<Sprite>(ImagePath);
        Item.GetComponent<Image>().sprite = SpriteImage;

        //色決定
        Item.GetComponent<Image>().color = Col;

        //パワー表記
        string PowerString = (Power).ToString();
        Item.GetComponent<StatItem>().PowerText.text = PowerString;

        //アイテムの情報をＳＴＡＴに書き込み
        Item.GetComponent<StatItem>().Name = Name;
        Item.GetComponent<StatItem>().Image = Image;
        Item.GetComponent<StatItem>().Power = Power;
        Item.GetComponent<StatItem>().Col = Col;
        Item.GetComponent<StatItem>().UpSus = UpSus;
        Item.tag = TagName;
    }



}
