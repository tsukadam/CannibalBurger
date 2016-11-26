using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CustomerContraller : MonoBehaviour
{
    //客の生成を制御する

    //客プレファブ
    public GameObject CustomerPrefab;

    //ステータスの定義

    //ステータス表示オブジェクトの取得
    public GameObject GameSpace;//表示スペース

    //イベントシステムの取得（処理中に切る場合がある）
    public GameObject EventSystem;

    //客生成
    public void MakeCustomer(int PositionRow, int PositionColumn)
    {
        GameObject Customer = (GameObject)Instantiate(
            CustomerPrefab,
            transform.position,
            Quaternion.identity);
        Customer.transform.parent = GameSpace.transform;
        int PositionY = PositionRow*200-200;
        int PositionX = PositionColumn*170-425;
        Customer.transform.position = new Vector3(PositionX,PositionY,0);
        Debug.Log("MakeCustomer done");
    }

    public void MakeCustomer12()
    {
        MakeCustomer(1, 1);
        MakeCustomer(2, 1);
        MakeCustomer(3, 1);
        MakeCustomer(1, 2);
        MakeCustomer(2, 2);
        MakeCustomer(3, 2);
        MakeCustomer(1, 3);
        MakeCustomer(2, 3);
        MakeCustomer(3, 3);
        MakeCustomer(1, 4);
        MakeCustomer(2, 4);
        MakeCustomer(3, 4);

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
