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

    //客生成
    public void MakeCustomer(string Name,string Image, int Hp, string CoreColor,string Color, int DropG,string[] DropItem,string[]DropMeat,int SaveSus)
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
        Color Col = new Color(CoreR+PlusR, CoreG + PlusG, CoreB + PlusB, 1f);

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

    }


}
