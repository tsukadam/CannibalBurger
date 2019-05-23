using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

public class CSVDataReader : MonoBehaviour
{
    public GameObject StatGame;

    public Text DebugLog;


    //敵データ格納用の配列データ(とりあえず初期値はnull値)
    private string[,] stageMapDatas = null;

    //読み込めたか確認の表示用の変数
    private int height = 0;    //行数
    private int width = 0;    //列数

    //CSVデータ読み込み関数
    //引数：データパス
    private string[,] readCSVData(string path)
    {
        //返り値の２次元配列
        string[,] readToIntData;

        TextAsset csvFile;
        csvFile = Resources.Load(path,typeof(TextAsset)) as TextAsset;

        //StringSplitOptionを設定(要はカンマとカンマに何もなかったら格納しないことにする)
        System.StringSplitOptions option = StringSplitOptions.RemoveEmptyEntries;

        //行に分ける
        string[] lines = csvFile.text.Split(new char[] { '\r', '\n' }, option);

        //カンマ分けの準備(区分けする文字を設定する)
        char[] spliter = new char[1] { ',' };

        //行数設定
        int heightLength = lines.Length;
        //列数設定
        int widthLength = lines[0].Split(spliter, option).Length;

        //返り値の2次元配列の要素数を設定
        readToIntData = new string[heightLength, widthLength];

        //カンマ分けをしてデータを完全分割
        for (int i = 0; i < heightLength; i++)
        {
            for (int j = 0; j < widthLength; j++)
            {
                //カンマ分け
                string[] readStrData = lines[i].Split(spliter, option);
                //型変換
                //                readToIntData[i, j] = int.Parse(readStrData[j]);
                //Debug.Log(i + "-" + j+":" + readStrData[j]);
                readToIntData[i, j] = readStrData[j];
            }
        }

        //確認表示用の変数(行数、列数)を格納する
        this.height = heightLength;    //行数   
        this.width = widthLength;     //列数

        //返り値
        return readToIntData;
 
    }

    //確認表示用の関数
    //引数：2次元配列データ,行数,列数
    private void WriteMapDatas(string[,] arrays, int hgt, int wid)
    {
        for (int i = 0; i < hgt; i++)
        {

            for (int j = 0; j < wid; j++)
            {
                //行番号-列番号:データ値 と表示される
                Debug.Log(i + "-" + j + ":" + arrays[i, j]);
            }
        }
    }

    public void CustomerCSVRead()
    {
        //客データ
        //データパスを設定
        string path = "CustomerCSV";
        //データを読み込む(引数：データパス)
        string[,] CustomerAllData = readCSVData(path);

        StatGame.GetComponent<StatGame>().CustomerAllData = CustomerAllData;

//レベルデザインデータ
//データパスを設定
        path = "LvDesignCSV";
        //データを読み込む(引数：データパス)
        string[,] LvDesignData = readCSVData(path);

        StatGame.GetComponent<StatGame>().LvDesignData = LvDesignData;

        //ストーリーデータ
        //データパスを設定
        path = "StoryCSV";
        //データを読み込む(引数：データパス)
        string[,] StoryData = readCSVData(path);

        StatGame.GetComponent<StatGame>().StoryData = StoryData;

        //エンドヒントデータ
        //データパスを設定
        path = "EndHintCSV";
        //データを読み込む(引数：データパス)
        string[,] EndHintData = readCSVData(path);

        StatGame.GetComponent<StatGame>().EndHintData = EndHintData;



        //        DebugLog.text = CustomerAllData[0, 0];

        //        WriteMapDatas(this.stageMapDatas, this.height, this.width);


    }

    void Start()
    {
        CustomerCSVRead();
    }

    void UpDate()
    {

    }
}
