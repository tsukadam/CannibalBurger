using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStat : MonoBehaviour {
    //プレイ中のプレイヤーのステータスを保持する
    //ステータス周りの描写も行う
    //オートセーブではこの中のデータが保持される

    //ステータスの定義
    //プレイ外ステータス
    //プレイ内表示ステータス
    public int StatG = 0;//所持金
    public float StatSus = 0;//SUS値
    public float StatPop = 0;//POP値

    public int StatBundsLv = 0;//レベル
    public int StatPattyLv = 0;//レベル
    public int StatToppingLv = 0;//レベル
    public int StatSourceLv = 0;//レベル
    public int StatBurgerLv = 0;//レベル

    public int StatBundsPower = 0;//パワー
    public int StatPattyPower = 0;//パワー
    public int StatToppingPower = 0;//パワー
    public int StatSourcePower = 0;//パワー
    public int StatBurgerPower = 0;//パワー


    //イベントシステムの取得（処理中に切る場合がある）
    public GameObject EventSystem;

  
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
