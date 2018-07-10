using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour {

    //プレイヤーstat
    public GameObject StatPlayer;
    //ゲームstat
    public GameObject StatGame;

    public GameObject TutorialAll;
    public GameObject Sankaku;
    public GameObject NextButton;
    public GameObject SkipButton;
    public GameObject EndButton;
    public string NowSerif="";

    public int ReadCount;
    public int ReadCountMax;
    public float WaitTime=0;

    public GameObject Window;
    public Text Massage;

   // public GameObject ButtonBlock1;

    public GameObject Red1;
    public GameObject Red2;
    public GameObject Red3;
    public GameObject Red4;

    public string NowKey = "";



    public string[] TutorialFirstFeed;
    public string[] TutorialSecondFeed;
    public string[] TutorialFirstSaveSus;
    public string[] TutorialFirstLvup;
    public string[] TutorialFirstRare;
    public string[] TutorialFirstHolyday;
    public string[] TutorialFirstSelect;
    public string[] TutorialFirstDispose;
    public string[] TutorialReigai;




    public string[] UseStory;

    public void StartTutorial(string TutorialKey)
    {
        NowKey = TutorialKey;
        TutorialAll.SetActive(true);
        Window.SetActive(false);
       Red1.SetActive(false);
        Red2.SetActive(false);
        Red3.SetActive(false);
        Red4.SetActive(false);

        //    Sankaku.SetActive(false);
        NextButton.SetActive(false);
        EndButton.SetActive(false);
        SkipButton.SetActive(false);

     //   ButtonBlock1.SetActive(false);

        Massage.text = "";
        if (TutorialKey == "FirstFeed") { UseStory = TutorialFirstFeed;
      //      ButtonBlock1.SetActive(true);
            StatPlayer.GetComponent<StatPlayer>().FlagTutorialFirstFeed = 1;
            WaitTime = 2.0f;
        }
        else if (TutorialKey == "SecondFeed") { UseStory = TutorialSecondFeed;
            //ButtonBlock1.SetActive(true);
            StatPlayer.GetComponent<StatPlayer>().FlagTutorialSecondFeed = 1;
            WaitTime = 2.0f;
        }
        else if (TutorialKey == "FirstSaveSus") { UseStory = TutorialFirstSaveSus;
            StatPlayer.GetComponent<StatPlayer>().FlagTutorialFirstSaveSus = 1;
            WaitTime = 2.0f;
        }
        else if (TutorialKey == "FirstLvup") { UseStory = TutorialFirstLvup;
            StatPlayer.GetComponent<StatPlayer>().FlagTutorialFirstLvup = 1;
            WaitTime = 1.0f;
        }
        else if (TutorialKey == "FirstRare") { UseStory = TutorialFirstRare;
            StatPlayer.GetComponent<StatPlayer>().FlagTutorialFirstRare = 1;
            WaitTime = 2.0f;
        }
        else if (TutorialKey == "FirstHolyday") { UseStory = TutorialFirstHolyday;
            StatPlayer.GetComponent<StatPlayer>().FlagTutorialFirstHolyday = 1;
            WaitTime = 1.0f;
        }
        else if (TutorialKey == "FirstSelect") { UseStory = TutorialFirstSelect;
            StatPlayer.GetComponent<StatPlayer>().FlagTutorialFirstSelect = 1;
            WaitTime = 2.0f;
        }
        else if (TutorialKey == "FirstDispose") { UseStory = TutorialFirstDispose;
            StatPlayer.GetComponent<StatPlayer>().FlagTutorialFirstDispose = 1;
            WaitTime = 1.0f;
        }
        else { Debug.Log("指定されたチュートリアルKeyはありません");
            TutorialAll.SetActive(false); }

        ReadCount = 0;
        ReadCountMax = UseStory.Length;

        StartCoroutine("BeforeStartCoroutine");

    }

    IEnumerator BeforeStartCoroutine()
    {
        yield return new WaitForSeconds(WaitTime);
        Window.SetActive(true);
        SkipButton.SetActive(true);
      //  Sankaku.SetActive(true);



        ReadLine();

        yield return null;
    }

    public void ReadLine()
    {
        string Serif = UseStory[ReadCount];
        NowSerif = Serif;

        Red1.SetActive(false);
        Red2.SetActive(false);
        Red3.SetActive(false);
        Red4.SetActive(false);

        //文字着色
        if (NowKey == "FirstFeed"&ReadCount==1)
        {
            Red1.SetActive(true);
            Red2.SetActive(true);
        }
        else if (NowKey == "FirstFeed" & ReadCount == 2)
        {
            Red3.SetActive(true);
        }
        else if (NowKey == "FirstSaveSus" & ReadCount == 0)
        {
            Red4.SetActive(true);
        }
        else if (NowKey == "FirstLvup" & ReadCount == 0)
        {
            Red4.SetActive(true);
        }


        NextButton.SetActive(false);
        SkipButton.SetActive(true);

        StartCoroutine("MassageCoroutine", Serif);

        ReadCount++;

    }

    IEnumerator MassageCoroutine(string Serif)
    {
        int Count = 0;
        string ReadingSerif = "";
        string NowGriff;
        int SerifLength = Serif.Length;
        while (Count < SerifLength)
        {
            NowGriff = Serif.Substring(Count, 1);
            ReadingSerif += NowGriff;
            Massage.text = ReadingSerif;
            yield return new WaitForSeconds(0.02f);
            Count++;
        }
        NextButton.SetActive(true);
        SkipButton.SetActive(false);

        if (ReadCount >= ReadCountMax)
        {
            TutorialBeforeEnd();
        }
        yield return null;
    }


    public void SkipReadLine()
    {
        StopCoroutine("MassageCoroutine");
        Massage.text = NowSerif;
        if (ReadCount >= ReadCountMax)
        {
            TutorialBeforeEnd();
        }
        else {
            NextButton.SetActive(true);
            SkipButton.SetActive(false);
        }
    }
    public void TutorialBeforeEnd()
    {
        NextButton.SetActive(false);
        SkipButton.SetActive(false);
            EndButton.SetActive(true);

    }


    public void TutorialEnd()
    {
        StatPlayer.GetComponent<StatPlayer>().SaveFlag();
        TutorialAll.SetActive(false);

        //ボタン押せるようにする
        GameObject ButtonSave = GetComponent<GameController>().ButtonSave;
        GameObject Button4Items1 = GetComponent<GameController>().Button4Items1;
        GameObject Button4Items2 = GetComponent<GameController>().Button4Items2;
        GameObject Button4Items3 = GetComponent<GameController>().Button4Items3;
        GameObject Button4Items4 = GetComponent<GameController>().Button4Items4;
        GameObject Button6Items1 = GetComponent<GameController>().Button6Items1;
        GameObject Button6Items2 = GetComponent<GameController>().Button6Items2;
        GameObject Button6Items3 = GetComponent<GameController>().Button6Items3;
        GameObject Button6Items4 = GetComponent<GameController>().Button6Items4;
        GameObject Button6Items5 = GetComponent<GameController>().Button6Items5;
        GameObject Button6Items6 = GetComponent<GameController>().Button6Items6;

        GameObject LvUpOKButton = GetComponent<GameController>().LvUpOKButton;
        GameObject SaveSusOKButton = GetComponent<GameController>().SaveSusOKButton;
        GameObject ButtonPolice = GetComponent<GameController>().ButtonPolice;
        GameObject ButtonChurch = GetComponent<GameController>().ButtonChurch;
        GameObject ButtonHome = GetComponent<GameController>().ButtonHome;
        GameObject ButtonMarket = GetComponent<GameController>().ButtonMarket;
        GameObject HandButton = GetComponent<GameController>().HandButton;
        ButtonSave.GetComponent<Button>().interactable = true;
        Button4Items1.GetComponent<Button>().interactable = true;
        Button4Items2.GetComponent<Button>().interactable = true;
        Button4Items3.GetComponent<Button>().interactable = true;
        Button4Items4.GetComponent<Button>().interactable = true;
        Button6Items1.GetComponent<Button>().interactable = true;
        Button6Items2.GetComponent<Button>().interactable = true;
        Button6Items3.GetComponent<Button>().interactable = true;
        Button6Items4.GetComponent<Button>().interactable = true;
        Button6Items5.GetComponent<Button>().interactable = true;
        Button6Items6.GetComponent<Button>().interactable = true;
        LvUpOKButton.GetComponent<Button>().interactable = true;
        SaveSusOKButton.GetComponent<Button>().interactable = true;
        ButtonPolice.GetComponent<Button>().interactable = true;
        ButtonChurch.GetComponent<Button>().interactable = true;
        ButtonHome.GetComponent<Button>().interactable = true;
        ButtonMarket.GetComponent<Button>().interactable = true;
        HandButton.GetComponent<Button>().interactable = true;

    }



    // Use this for initialization
    void Start () {


    TutorialFirstFeed =
        new string[]{
        "４つの しょくざいから" +"\n"+"１つ えらんで " +"\n"+"バーガーを つくるよ",
        "しろい すうじが パワー" +"\n"+"あかい すうじが カルマ",
        "カルマ が たまると" +"\n"+"ゲームオーバーだよ"
    };
    TutorialSecondFeed =
        new string[]{
        "１にち けいかしたよ。"+"\n"+"きょうも しょくざいを えらぼう",
        "おきゃくさまの いろ と" +"\n"+"しょくざいの いろ が ちかいと" +"\n"+"こうか ばつぐん だよ"
    };
    TutorialFirstSaveSus =
        new string[]{
        "たんてい や けいかん を もてなすと" +"\n"+"カルマ を へらせるよ"
    };
    TutorialFirstLvup =
        new string[]{
        "レベルアップ すると " +"\n"+"カルマ を へらせるよ",
        "おきゃくさま の しゅるい も" +"\n"+"へんか するよ"
    };
    TutorialFirstRare =
        new string[]{
        "ひかる おきゃくさま は てごわい" +"\n"+"そのぶん みいり も おおきい"
    };
    TutorialFirstHolyday =
   new string[] {
        "にちようび は おやすみ" +"\n"+"すきなところ に でかけよう"
    };
    TutorialFirstSelect =
   new string[] {
        "まんぞくした おきゃくさま だけが" +"\n"+"しょくざい を くれるよ",
        "ほしい しょくざい を" +"\n"+"２つ タップして えらぼう",
        "もういちど タップ で キャンセル",
        "おきゃくさま も えらべるよ"
    };
    TutorialFirstDispose =
    new string[]{
        "もてる しょくざい は ４つまで。" +"\n"+"１つ すてるよ",
        "すてる しょくざい を" +"\n"+"タップしてね"
    };
    TutorialReigai =
    new string[]{
        "",
    };
}
	
	// Update is called once per frame
	void Update () {
		
	}
}
