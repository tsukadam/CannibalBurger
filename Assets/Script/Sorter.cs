using UnityEngine;

public class Sorter : MonoBehaviour
{
    public GameObject[] LoserSort(GameObject[] Customers)
    {

        int Count1 = 0;
        int Count1Plus = 0;
        int Count2 = 0;
        int Count2Max = 4;
        int CountNotTopNext = 0;

        int CustomersLength = Customers.GetLength(0);
        GameObject TopCustomer = Customers[0];
        int PointPower1;
        int PointPower2;
        float PointColor1;
        float PointColor2;
        string Rarerity1;
        string Rarerity2;
        int Rarerity1Int;
        int Rarerity2Int;
        string TagNo = "";
        GameObject[] CustomersNotTop = Customers;
        GameObject[] CustomersNotTopNext = Customers;

//Loserが４以下の時は取得数もその数にする
        if (CustomersLength < Count2Max) { Count2Max = CustomersLength;}
        GameObject[] TopCustomers = new GameObject[Count2Max];

        while (Count2 < Count2Max)
        {
            //一周目は元のリストを使う
            if (Count2 == 0)
            {
                CustomersNotTop = Customers;
            }
            //二周目以降は前周で作られた「少なくともトップではない」のリストを使う
            else
            {
                CustomersNotTop= CustomersNotTopNext;//リスト更新（前回ＴＯＰ認定された１人が減る）
            }
            //次の周用の「少なくともトップではない」の箱を用意、中身は空
            CustomersNotTopNext = new GameObject[CustomersLength - Count2 - 1];
            CountNotTopNext=0;

            //暫定トップ
            TopCustomer = CustomersNotTop[0];
            Count1 = 0;
            while (Count1 < CustomersLength -Count2- 1)
            {
                Count1Plus = Count1 + 1;
                PointColor1 = TopCustomer.GetComponent<StatCustomer>().PointColor;
                PointColor2 = CustomersNotTop[Count1Plus].GetComponent<StatCustomer>().PointColor;
                //暫定トップとCount1Plus番目を比較し、低い方は「少なくともトップではない」の箱に入れる
                //「少なくともトップではない」の箱を使った回数はカウントされる（最大CustomersLength - Count2 - 1）
                if (PointColor1 > PointColor2)
                {
                    CustomersNotTopNext[CountNotTopNext] = CustomersNotTop[Count1Plus];
                    CountNotTopNext++;
                }
                else if (PointColor1 < PointColor2)
                {
                    CustomersNotTopNext[CountNotTopNext] = TopCustomer;
                    CountNotTopNext++;
                    TopCustomer = CustomersNotTop[Count1Plus];
                }
                //PointColorが同じ場合はレアリティを比較する
                else
                {
                    Rarerity1 = TopCustomer.GetComponent<StatCustomer>().Rarerity;
                    Rarerity2 = CustomersNotTop[Count1Plus].GetComponent<StatCustomer>().Rarerity;
                    Rarerity1Int = GetComponent<LvDesignController>().GetRarerityInt(Rarerity1);
                    Rarerity2Int = GetComponent<LvDesignController>().GetRarerityInt(Rarerity2);


                    if (Rarerity1Int > Rarerity2Int)
                    {
                        CustomersNotTopNext[CountNotTopNext] = CustomersNotTop[Count1Plus];
                        CountNotTopNext++;
                    }
                    else
                    {
                        //レアリティも同じなら勝利度を比較する（同じ場合は暫定トップの負け）辛勝の方が残る
                        PointPower1 = TopCustomer.GetComponent<StatCustomer>().PointPower;
                        PointPower2 = CustomersNotTop[Count1Plus].GetComponent<StatCustomer>().PointPower;
                        if (PointColor1 < PointColor2)
                        {
                            CustomersNotTopNext[CountNotTopNext] = CustomersNotTop[Count1Plus];
                            CountNotTopNext++;
                        }
                        else
                        {
                            CustomersNotTopNext[CountNotTopNext] = TopCustomer;
                            CountNotTopNext++;
                            TopCustomer = CustomersNotTop[Count1Plus];
                        }
                    }


                }
                Count1++;
            }
            TopCustomers[Count2] = TopCustomer;
            TagNo = (Count2).ToString();
            TopCustomers[Count2].tag = "Top"+TagNo;
            Count2++;
        }


        return TopCustomers;
    }
}