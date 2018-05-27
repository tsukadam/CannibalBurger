using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryController : MonoBehaviour {
    //プレイヤーstat
    public GameObject StatPlayer;
    //ゲームstat
    public GameObject StatGame;

    public GameObject Person1;
    public GameObject Person2;
    public GameObject Place;
    public Text Massage;
    public GameObject FukidashiL;
    public GameObject FukidashiR;

    public int ReadCount;
    public int ReadCountMax;

    public GameObject StartButton;
    public GameObject NextButton;
    public GameObject SkipButton;
    public string NowSerif;

    public string ActionNowSerif;
    public Text ActionMassage;


    //テスト用ストーリー
    public string[,] StoryData= new string[,] {
       {"SceneName","Person1","Person2","Fukidashi","Place", "Serif" },
       {"scene1","Police","Miyako","L","Church", "１つめのセリフ" },
       {"scene1","Miyako","Morrel","R","Market", "２つめのセリフ" },
       {"scene1","Miyako","Morrel","L","Market", "３つめのセリフ" },
       {"scene1","Miyako","Morrel","R","Market", "４つめのセリフ" },
       {"scene2","Miyako","Morrel","L","Market", "５つめのセリフ" }
    };

    public string[,] UseStory;
    public int LowSceneName;
    public int LowPerson1;
    public int LowPerson2;
    public int LowFukidashi;
    public int LowPlace;
    public int LowSerif;
    public int NowMode;

    //Mode=0 オープニング　終了後はゲームスタートに遷移
    //Mode=1 エンディング　終了後はゲームオーバー画面に遷移
    public void ModeSetting(int Mode)
    {
        NowMode = Mode;

    }
    public void StartStory(string StoryKey)
    {
        //今回使うストーリーのまとまりをkeyで抜き出す
        int StoryDataLength = StoryData.GetLength(0);
        int LowLength = StoryData.GetLength(1);
        int Count = 0;
        int SmallCount = 0;
        int LineCount = 0;

        //Low項目を取得
        while (Count < LowLength)
        {
            if (StoryData[0,Count] == "SceneName") { LowSceneName = Count; }
            else if (StoryData[0, Count] == "Person1") { LowPerson1 = Count; }
            else if (StoryData[0, Count] == "Person2") { LowPerson2 = Count; }
            else if (StoryData[0, Count] == "Fukidashi") { LowFukidashi = Count; }
            else if (StoryData[0, Count] == "Place") { LowPlace = Count; }
            else if (StoryData[0, Count] == "Serif") { LowSerif = Count; }
            else { Debug.Log("ストーリーに分類不能な列がある"); }
            Count++;
        }

        Count = 0;
        //まずまとまりの数を数える
        while (Count < StoryDataLength)
        {
            if (StoryData[Count, 0] == StoryKey)
            {
                LineCount++;
            }
            Count++;
        }

        string[,] ThisStory = new string[LineCount, LowLength];
        if (Count == 0) { Debug.Log("Keyに該当するストーリーがありません"); }
        //該当ストーリーがある時のみ以下の処理
        else {
            ReadCount = 0;
            ReadCountMax = LineCount;


            Count = 0;
            LineCount = 0;
            //もっかい回して取得
            while (Count < StoryDataLength)
            {
                if (StoryData[Count, 0] == StoryKey)
                {
                    SmallCount = 0;
                    while (SmallCount < LowLength)
                    {
                        ThisStory[LineCount, SmallCount] = StoryData[Count, SmallCount];
                       // Debug.Log(LineCount+"-"+SmallCount+":"+ ThisStory[LineCount, SmallCount]);
                        SmallCount++;
                    }
                    LineCount++;
                }
                Count++;
            }


        }
        UseStory = ThisStory;


        
        FukidashiL.SetActive(false);
        FukidashiL.SetActive(false);
        NextButton.SetActive(true);
        StartButton.SetActive(false);
        SkipButton.SetActive(false);

    }
    public void ReadLine()
    {
        string PlacePath = UseStory[ReadCount, LowPlace];
        string Person1Path = UseStory[ReadCount, LowPerson1];
        string Person2Path = UseStory[ReadCount, LowPerson2];
        string Fukidashi = UseStory[ReadCount, LowFukidashi];
        string Serif = UseStory[ReadCount, LowSerif];

        string ImagePath1 = "Face/" + Person1Path;
        Sprite SpriteImage1 = Resources.Load<Sprite>(ImagePath1);
        Person1.GetComponent<Image>().sprite = SpriteImage1;

        string ImagePath2 = "Face/" + Person2Path;
        Sprite SpriteImage2 = Resources.Load<Sprite>(ImagePath2);
        Person2.GetComponent<Image>().sprite = SpriteImage2;

        string ImagePath3 = "Place/" + PlacePath;
        Sprite SpriteImage3 = Resources.Load<Sprite>(ImagePath3);
        Place.GetComponent<Image>().sprite = SpriteImage3;

        if (Fukidashi == "L") {
            FukidashiL.SetActive(true);
            FukidashiR.SetActive(false);
        }
        else {
            FukidashiL.SetActive(false);
            FukidashiR.SetActive(true);
        }


        //        Massage.text = Serif;
        NowSerif = Serif;

        NextButton.SetActive(false);
        SkipButton.SetActive(true);

        StartCoroutine("MassageCoroutine", Serif);

        ReadCount++;



    }

    IEnumerator MassageCoroutine(string Serif)
{
        int Count = 0;
        string ReadingSerif="";
        string NowGriff;
        int SerifLength = Serif.Length;
        while(Count< SerifLength)
        {
            NowGriff = Serif.Substring(Count, 1);
            ReadingSerif += NowGriff;
            Massage.text = ReadingSerif;
            yield return new WaitForSeconds(0.05f);
            Count++;
        }
        NextButton.SetActive(true);

        if(ReadCount>=ReadCountMax)
        {
            StoryEnd();
        }
        yield return null;
}

    public void SkipReadLine()
    {
        StopCoroutine("MassageCoroutine");
        Massage.text = NowSerif;
        if (ReadCount >= ReadCountMax)
        {
            StoryEnd();
        }
        else {
            NextButton.SetActive(true);
            SkipButton.SetActive(false);
        }
    }


    public void StoryEnd()
    {
        if (NowMode == 0)
        {
            Debug.Log("ストーリー終了 Mode0");
        }
        else if (NowMode == 1)
        {
            Debug.Log("ストーリー終了 Mode0");
        }

        NextButton.SetActive(false);
        SkipButton.SetActive(false);

    }

    //休日アクションの中の、演出だけの文字送り
    public void ActionReadLine(string Serif)
    {
        StartCoroutine("ActionMassageCoroutine", Serif);
    }

    IEnumerator ActionMassageCoroutine(string Serif)
    {
        int Count = 0;
        string ReadingSerif = "";
        string NowGriff;
        int SerifLength = Serif.Length;
        while (Count < SerifLength)
        {
            NowGriff = Serif.Substring(Count, 1);
            ReadingSerif += NowGriff;
            ActionMassage.text = ReadingSerif;
            yield return new WaitForSeconds(0.05f);
            Count++;
        }

        yield return null;
    }
    public void SkipActionReadLine()
    {
        StopCoroutine("ActionMassageCoroutine");
        Massage.text = "";
    }
    // Use this for initialization
    void Start()
    {
        FukidashiL.SetActive(false);
        FukidashiL.SetActive(false);
        NextButton.SetActive(false);
        SkipButton.SetActive(false);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
