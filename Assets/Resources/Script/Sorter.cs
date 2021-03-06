﻿using UnityEngine;

public class Sorter : MonoBehaviour
{
    public void GlowSort(GameObject[] Customers)
    {

        int Count1 = 0;
        int Count1Plus = 0;
        int Count2 = 0;
        int Count2Max = 1;
        int CountNotTopNext = 0;

        int CustomersLength = Customers.GetLength(0);
        GameObject TopCustomer = Customers[0];
        int Hp1;
        int Hp2;

        GameObject[] CustomersNotTop = Customers;
        GameObject[] CustomersNotTopNext = Customers;

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
                CustomersNotTop = CustomersNotTopNext;//リスト更新（前回ＴＯＰ認定された１人が減る）
            }
            //次の周用の「少なくともトップではない」の箱を用意、中身は空
            CustomersNotTopNext = new GameObject[CustomersLength - Count2 - 1];
            CountNotTopNext = 0;

            //暫定トップ
            TopCustomer = CustomersNotTop[0];
            Count1 = 0;
            while (Count1 < CustomersLength - Count2 - 1)
            {
                Count1Plus = Count1 + 1;
                Hp1 = TopCustomer.GetComponent<StatCustomer>().Hp;
                Hp2 = CustomersNotTop[Count1Plus].GetComponent<StatCustomer>().Hp;

                //暫定トップとCount1Plus番目を比較し、低い方は「少なくともトップではない」の箱に入れる
                //「少なくともトップではない」の箱を使った回数はカウントされる（最大CustomersLength - Count2 - 1）
                if (Hp1 > Hp2)
                {
                    CustomersNotTopNext[CountNotTopNext] = CustomersNotTop[Count1Plus];
                    CountNotTopNext++;
                }
                else if (Hp1 == Hp2)//同率の場合、暫定トップの勝ち
                {
                    CustomersNotTopNext[CountNotTopNext] = CustomersNotTop[Count1Plus];
                    CountNotTopNext++;
                }
                else {
                    CustomersNotTopNext[CountNotTopNext] = TopCustomer;
                    CountNotTopNext++;
                    TopCustomer = CustomersNotTop[Count1Plus];
                }
                Count1++;
            }
            TopCustomers[Count2] = TopCustomer;
            Count2++;
        }

        int Count3 = 0;
        while (Count3< CustomersLength)
        {
            if(Customers[Count3].GetComponent<StatCustomer>().Hp== TopCustomers[0].GetComponent<StatCustomer>().Hp)
            {


                Customers[Count3].GetComponent<StatCustomer>().Glow();

            }
            Count3++;
        }
    }


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
                Rarerity1 = TopCustomer.GetComponent<StatCustomer>().Rarerity;
                Rarerity2 = CustomersNotTop[Count1Plus].GetComponent<StatCustomer>().Rarerity;
                Rarerity1Int = GetComponent<LvDesignController>().GetRarerityInt(Rarerity1);
                Rarerity2Int = GetComponent<LvDesignController>().GetRarerityInt(Rarerity2);
                //暫定トップとCount1Plus番目を比較し、低い方は「少なくともトップではない」の箱に入れる
                //「少なくともトップではない」の箱を使った回数はカウントされる（最大CustomersLength - Count2 - 1）
                //まずはレアリティを比較する

                if (Rarerity1Int > Rarerity2Int)
                {
                    CustomersNotTopNext[CountNotTopNext] = CustomersNotTop[Count1Plus];
                    CountNotTopNext++;
                }
                else if (Rarerity1Int < Rarerity2Int)
                {
                    CustomersNotTopNext[CountNotTopNext] = TopCustomer;
                    CountNotTopNext++;
                    TopCustomer = CustomersNotTop[Count1Plus];
                }
                //レアリティが同じ場合はPointColorを比較する
                else
                {

                    PointColor1 = TopCustomer.GetComponent<StatCustomer>().PointColor;
                    PointColor2 = CustomersNotTop[Count1Plus].GetComponent<StatCustomer>().PointColor;

                    if (PointColor1 > PointColor2)
                    {
                        CustomersNotTopNext[CountNotTopNext] = CustomersNotTop[Count1Plus];
                        CountNotTopNext++;
                    }
                    else
                    {
                        //PointColorも同じなら勝利度を比較する（同じ場合は暫定トップの負け）辛勝の方が残る
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