using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryController : MonoBehaviour {
    //プレイヤーstat
    public GameObject StatPlayer;
    //ゲームstat
    public GameObject StatGame;

    public GameObject StoryAll;

    public GameObject ButtonTrueSkip;

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
    public string NowSerif="";

    public string ActionSerif;
    public string ActionVoice;
    public string ActionNowSerif="";
    public Text ActionMassage;

    public GameObject EndButton0;
    public GameObject EndButton1;
    public GameObject EndButton2;

    public GameObject Suuzi;

    //テスト用ストーリー
    public string[,] StoryData;

    public string[,] UseStory;
    public int LowSceneName;
    public int LowPerson1;
    public int LowPerson2;
    public int LowFukidashi;
    public int LowPlace;
    public int LowSerif;
    public int NowMode;

    public int EndFine=0;
    public string NowStoryKey="";

    //コルーチン
    public IEnumerator Routine;


    //ランダムでエンドヒントを１つ再生
    public void RandomEndHint()
    {
        string StoryKey;
        int n = Random.Range(0, 19);
        if (n == 0) { StoryKey = "Hint1"; }
        else if (n == 1) { StoryKey = "Hint2"; }
        else if (n == 2) { StoryKey = "Hint3"; }
        else if (n == 3) { StoryKey = "Hint4"; }
        else if (n == 4) { StoryKey = "Hint5"; }
        else if (n == 5) { StoryKey = "Hint6"; }
        else if (n == 6) { StoryKey = "Hint7"; }
        else if (n == 7) { StoryKey = "Hint8"; }
        else if (n == 8) { StoryKey = "Hint9"; }
        else if (n == 9) { StoryKey = "Hint10"; }
        else if (n == 10) { StoryKey = "Hint11"; }
        else if (n == 11) { StoryKey = "Hint12"; }
        else if (n == 12) { StoryKey = "Hint13"; }
        else if (n == 13) { StoryKey = "Hint14"; }
        else if (n == 14) { StoryKey = "Hint15"; }
        else if (n == 15) { StoryKey = "Hint16"; }
        else if (n == 16) { StoryKey = "Hint17"; }
        else if (n == 17) { StoryKey = "Hint18"; }
        else if (n == 18) { StoryKey = "Hint19"; }
        else { StoryKey = "Hint20"; }
        StartStory(StoryKey);
    }


    //Mode=0 オープニング　終了後はゲームスタートに遷移
    //Mode=1 エンディング　終了後はゲームオーバー画面に遷移
    //Mode=2 エンドヒント　終了後はメニュー画面に遷移
    public void ModeSetting(int Mode)
    {
        NowMode = Mode;

    }


        public void StartStory(string StoryKey)
    {

        NowStoryKey = StoryKey;
        EndFine = GetComponent<GameController>().GetEndFine(NowStoryKey);

        Massage.text = "";


        if (StoryKey == "Opening"| StoryKey == "SkipOpening") { ModeSetting(0); }
        else if (StoryKey == "EndingKarma1"|
            StoryKey == "EndingKarma2"|
            StoryKey == "Ending1"|
            StoryKey == "Ending2" |
            StoryKey == "Ending3" |
            StoryKey == "Ending4" |
            StoryKey == "SkipEnding1" |
            StoryKey == "SkipEnding2" |
            StoryKey == "SkipEnding3" |
            StoryKey == "SkipEnding4" |
            StoryKey == "SkipEndingKarma1" |
            StoryKey == "SkipEndingKarma2" 
            )
        { ModeSetting(1); }
        else if (StoryKey == "Hint1" |
            StoryKey == "Hint2" |
            StoryKey == "Hint3" |
            StoryKey == "Hint4" |
            StoryKey == "Hint5" |
            StoryKey == "Hint6" |
            StoryKey == "Hint7" |
            StoryKey == "Hint8" |
            StoryKey == "Hint9" |
            StoryKey == "Hint10" |
            StoryKey == "Hint11" |
            StoryKey == "Hint12" |
            StoryKey == "Hint13" |
            StoryKey == "Hint14" |
            StoryKey == "Hint15" |
            StoryKey == "Hint16" |
            StoryKey == "Hint17" |
            StoryKey == "Hint18" |
            StoryKey == "Hint19" |
            StoryKey == "Hint20" )
        { ModeSetting(2); }
        else
        { Debug.Log("指定されたストーリーKeyはありません。モード１にします");
            ModeSetting(1); }

        if (NowMode == 1|NowMode==0) { 
        StoryData = StatGame.GetComponent<StatGame>().StoryData;
        }
        else if (NowMode == 2)
        {
            StoryData = StatGame.GetComponent<StatGame>().EndHintData;
        }
        else
        {
            StoryData = StatGame.GetComponent<StatGame>().StoryData;
        }

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


        ButtonTrueSkip.SetActive(false);
        StoryAll.SetActive(true);

        if (StoryKey.Contains("Skip"))
        {
            ButtonTrueSkip.SetActive(false);
            // Debug.Log("SKIP!!");
        }
        else if (NowMode == 2)
        {
            ButtonTrueSkip.SetActive(false);
        }
        else
        {
            ButtonTrueSkip.SetActive(true);

        }
        Suuzi.SetActive(false);

        EndButton0.SetActive(false);
        EndButton1.SetActive(false);
        EndButton2.SetActive(false);
        FukidashiL.SetActive(false);
        FukidashiL.SetActive(false);
        NextButton.SetActive(true);
        StartButton.SetActive(false);
        SkipButton.SetActive(false);

        ReadLine();
    }
    public void TrueSkip()
    {
        ButtonTrueSkip.SetActive(false);
        string SkipKey = "Skip"+NowStoryKey;
        StartStory(SkipKey);
    }

    public void ReadLine()
    {

        string PlacePath = UseStory[ReadCount, LowPlace];
        string Person1Path = UseStory[ReadCount, LowPerson1];
        string Person2Path = UseStory[ReadCount, LowPerson2];
        string Fukidashi = UseStory[ReadCount, LowFukidashi];
        string Serif = UseStory[ReadCount, LowSerif];
        Suuzi.SetActive(false);



        //特殊文字をステ内数字に変換
        //ステ内数字に該当数字を入れる
        //ステ内数字の表示位置を指定
        Suuzi.GetComponent<Text>().text = "";

        string NowStatG = StatGame.GetComponent<StatGame>().StatG.ToString();
        string EndUseG = EndFine.ToString();
        string MaxDays = StatGame.GetComponent<StatGame>().MaxDays.ToString();
        string Wairo = StatGame.GetComponent<StatGame>().Wairo.ToString();

        if (Serif.Contains("NowStatG"))
        {
            Serif = Serif.Replace("NowStatG", "＠");
            Suuzi.GetComponent<Text>().text = NowStatG;
            Suuzi.GetComponent<RectTransform>().localPosition = new Vector3(12, 6, 0); ;
        }
        else if(Serif.Contains("EndUseG"))
        {
            Serif = Serif.Replace("EndUseG", "＠");
            Suuzi.GetComponent<Text>().text = EndUseG;
            Suuzi.GetComponent<RectTransform>().localPosition = new Vector3(12, 6, 0); ;
        }
        else if (Serif.Contains("MaxDays1"))
        {
            Serif = Serif.Replace("MaxDays1", "＠　　 ");
            Suuzi.GetComponent<Text>().text = MaxDays;
            Suuzi.GetComponent<RectTransform>().localPosition = new Vector3(140, 72, 0); ;
        }
        else if (Serif.Contains("MaxDays2"))
        {
            Serif = Serif.Replace("MaxDays2", "＠　　 ");
            Suuzi.GetComponent<Text>().text = MaxDays;
            Suuzi.GetComponent<RectTransform>().localPosition = new Vector3(12, 72, 0); ;
        }
        else if (Serif.Contains("MaxDays3"))
        {
            Serif = Serif.Replace("MaxDays3", "＠　　　");
            Suuzi.GetComponent<Text>().text = MaxDays;
            Suuzi.GetComponent<RectTransform>().localPosition = new Vector3(194, 72, 0); ;
        }
        else if (Serif.Contains("MaxDays4"))
        {
            Serif = Serif.Replace("MaxDays4", "＠　　　");
            Suuzi.GetComponent<Text>().text = MaxDays;
            Suuzi.GetComponent<RectTransform>().localPosition = new Vector3(12, 6, 0); ;
        }
        else if (Serif.Contains("Wairo"))
        {
            Serif = Serif.Replace("Wairo", "＠      　　　　　");
            Suuzi.GetComponent<Text>().text = Wairo;
            Suuzi.GetComponent<RectTransform>().localPosition = new Vector3(12, 6, 0); 
        }
        else
        {
        }


        //改行文字を改行に変換
        string[] SplitSerif = Serif.Split("／"[0]);
        //Debug.Log(SplitSerif.Length);
        if (SplitSerif.Length == 1) {}
        else
        {
            int Count = 0;
            Serif = "";
            while (Count< SplitSerif.Length)
            {
                if (Count == 0) {
                    Serif = SplitSerif[Count];
                }
                else {
                    Serif = Serif + "\n" + SplitSerif[Count];
                }
                Count++;
            }

        }



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
        else if (Fukidashi == "R")
        {
            FukidashiL.SetActive(false);
            FukidashiR.SetActive(true);
        }
        else {
            FukidashiL.SetActive(false);
            FukidashiR.SetActive(false);
        }


        //        Massage.text = Serif;
        NowSerif = Serif;

        NextButton.SetActive(false);
        SkipButton.SetActive(true);
        string Voice="";

        if (Fukidashi == "L") {
            if (Person1Path == "Morrel")
            {
                Voice = "SEVoiceMan";
            }
            else if (Person1Path == "Morrel2")
            {
                Voice = "SEVoiceMan";
            }
            else if(Person1Path == "Miyako") {
                Voice = "SEVoiceWoman";
            }
            else if (Person1Path == "Death") {
                Voice = "SEVoiceOld";
            }
            else if (Person1Path == "Police") {
                Voice = "SEVoiceMan";
            }
            else if (Person1Path == "HintMan")
            {
                Voice = "SEVoiceOld";
            }
            else if (Person1Path == "HintGirl")
            {
                Voice = "SEVoiceWoman";
            }
            else
            {
                Voice = "SEVoiceNone";
            }
        }
        else if (Fukidashi == "R") {
            if (Person2Path == "Morrel")
            {
                Voice = "SEVoiceMan";
            }
            else if (Person2Path == "Morrel2")
            {
                Voice = "SEVoiceMan";
            }
            else if (Person2Path == "Miyako")
            {
                Voice = "SEVoiceWoman";
            }
            else if (Person2Path == "Death")
            {
                Voice = "SEVoiceOld";
            }
            else if (Person2Path == "Police")
            {
                Voice = "SEVoiceMan";
            }
            else if (Person2Path == "HintMan")
            {
                Voice = "SEVoiceOld";
            }
            else if (Person2Path == "HintGirl")
            {
                Voice = "SEVoiceWoman";
            }
            else
            {
                Voice = "SEVoiceNone";
            }
        }
        else
        {
            Voice = "SEVoiceNone";
        }

        Routine = null;
        Routine= MassageCoroutine(Serif, Voice);
        StartCoroutine(Routine);

        ReadCount++;



    }

    IEnumerator MassageCoroutine(string Serif, string Voice)
{
        int Count = 0;
        string ReadingSerif="";
        string NowGriff;
        int SerifLength = Serif.Length;
        while(Count< SerifLength)
        {
            NowGriff = Serif.Substring(Count, 1);
            if(NowGriff == "＠")
            {
                NowGriff = "";
                Suuzi.SetActive(true);
            }
            if (Count==0|NowGriff == "　" | NowGriff == "\n" | NowGriff == " " | NowGriff == "。" | NowGriff == "！" | NowGriff == "？")
            {
                GetComponent<SoundController>().PlaySE(Voice);
            }
            ReadingSerif += NowGriff;
            Massage.text = ReadingSerif;

            yield return new WaitForSeconds(0.01f);
            Count++;
        }
        NextButton.SetActive(true);
        SkipButton.SetActive(false);

        if (ReadCount>=ReadCountMax)
        {
            StoryEnd();
        }
        yield return null;
}

    public void SkipReadLine()
    {

        if (Routine != null) { StopCoroutine(Routine); }

        NowSerif = NowSerif.Replace("＠","");
        Suuzi.SetActive(true);
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


    //Mode=0 オープニング　終了後はゲームスタートに遷移
    //Mode=1 エンディング　終了後はゲームオーバー画面に遷移

    public void StoryEnd()
    {
        NextButton.SetActive(false);
        SkipButton.SetActive(false);
        ButtonTrueSkip.SetActive(false);

        if (NowMode == 0)
        {
            Debug.Log("ストーリー終了 Mode0");
            EndButton0.SetActive(true);

        }
        else if (NowMode == 1)
        {
            Debug.Log("ストーリー終了 Mode1");
            EndButton1.SetActive(true);
        }
        else if (NowMode == 2)
        {
            Debug.Log("ストーリー終了 Mode2");
            EndButton2.SetActive(true);
        }

    }

    public void End0()
    {
        StoryAll.SetActive(false);
        GetComponent<GameController>().GameStart();

    }

    public void End1()
    {
        StoryAll.SetActive(false);
        string EndMassage="";
        int BadEndFlag = 0;
        if (NowStoryKey == "EndingKarma1"| NowStoryKey == "SkipEndingKarma1") { EndMassage = "ゲームオーバー！";
            GetComponent<SoundController>().PlaySE("SEBadEnd");
            BadEndFlag = 1;
        }
        else if (NowStoryKey == "EndingKarma2"| NowStoryKey == "SkipEndingKarma2") { EndMassage = "ゲームクリア…？";
            GetComponent<SoundController>().PlaySE("SEBadEnd");
        }
        else if (NowStoryKey == "Ending1" | NowStoryKey == "SkipEnding1") { EndMassage = "ゲームオーバー！";
            GetComponent<SoundController>().PlaySE("SEBadEnd");
            BadEndFlag = 1;
        }
        else if (NowStoryKey == "Ending2" | NowStoryKey == "SkipEnding2") { EndMassage = "スコア０クリア！";
            GetComponent<SoundController>().PlaySE("SEGoodEnd");
        }
        else if (NowStoryKey == "Ending3"| NowStoryKey == "SkipEnding3") { EndMassage = "ゲームクリア！";
            GetComponent<SoundController>().PlaySE("SEGoodEnd");
        }
        else if (NowStoryKey == "Ending4"| NowStoryKey == "SkipEnding4") { EndMassage = "パーフェクトクリア！";
            GetComponent<SoundController>().PlaySE("SEGoodEnd");
        }

        EndFine = GetComponent<GameController>().GetEndFine(NowStoryKey);
        GetComponent<StatGameController>().GUp(EndFine * -1);
      //  Debug.Log("G:"+StatGame.GetComponent<StatGame>().StatG);
        GetComponent<GameController>().EndCard(EndMassage, BadEndFlag);

    }
    public void End2()
    {
        StoryAll.SetActive(false);
        GetComponent<GameController>().GoMenu();

    }

    //休日アクションの中の、演出だけの文字送り
    public void ActionReadLine(string Serif, string Voice)
    {
        Routine = null;
        ActionSerif = Serif;
        ActionVoice = Voice;
        Routine = ActionMassageCoroutine();
        StartCoroutine(Routine);
    }

    IEnumerator ActionMassageCoroutine()
    {
        GetComponent<GameController>().PopupActionSkipTapBlock.SetActive(true);

        string Serif = ActionSerif;
        string Voice = ActionVoice;
        int Count = 0;
        string ReadingSerif = "";
        string NowGriff;
        int SerifLength = Serif.Length;
        while (Count < SerifLength)
        {
            NowGriff = Serif.Substring(Count, 1);
            ReadingSerif += NowGriff;
            ActionMassage.text = ReadingSerif;
            if (Count == 0 | NowGriff == "　" | NowGriff == "\n" | NowGriff == " " | NowGriff == "。" | NowGriff == "！" | NowGriff == "？")
                {
            GetComponent<SoundController>().PlaySE(Voice);
        }
//            yield return new WaitForSeconds(1f);
            yield return new WaitForSeconds(0.01f);
            Count++;
        }
        GetComponent<GameController>().PopupActionSkipTapBlock.SetActive(false);
        yield return null;
    }
    public void ActionReadLineSkip()
    {
        StopCoroutine();
        ActionMassage.text = ActionSerif;
        GetComponent<GameController>().PopupActionSkipTapBlock.SetActive(false);

    }

    public void StopCoroutine()
    {
        if (Routine != null) { StopCoroutine(Routine); }

    }
    public void SkipActionReadLine()
    {
        StopCoroutine();
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
