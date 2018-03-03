using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

//音関係の演出

public class SoundController : MonoBehaviour {
    //必要なもの
    public GameObject StatGame;

    public AudioSource BgmSource;
    public AudioSource SESource;
    public AudioMixer Mixer;

    //bgmに使うクリップ
    public AudioClip StoreBgm1;

    //seに使うクリップ
    public AudioClip SEGGet;
    public AudioClip SEDoorOpen;
    public AudioClip SECustomerVoice;
    public AudioClip SEKill;
    public AudioClip SETapButton;
    public AudioClip SEVictory;
    public AudioClip SEGGetOne;
    public AudioClip SELvUp;

    //フェードインアウト設定
    public float SEVolume = 1;
    public float BgmVolume = 1;


    //ボタンを押した音
    public void ButtonMenuSE()    {        PlaySE("TapButton");    }
    public void Button4ItemSE()    {        PlaySE("TapButton");    }
    public void Button6ItemSE()    {        PlaySE("TapButton");    }
    public void ButtonSelectOKSE()    {        PlaySE("TapButton");    }
    public void ButtonSelectWakuSE()    {        PlaySE("TapButton");    }
    public void ButtonHiroiItemOKSE()    {        PlaySE("TapButton");    }
    public void ButtonDisposeOKSE()    {        PlaySE("TapButton");    }
    public void ButtonCancelSE()   {        PlaySE("TapButton");    }
    public void ButtonResultOKSE()    {        PlaySE("TapButton");    }
    public void ButtonNoSaveSE()    {        PlaySE("TapButton");    }
    public void ButtonSaveSE()    {        PlaySE("TapButton");    }
    public void ButtonLvUpOKSE()    {        PlaySE("TapButton");    }
    public void ButtonGameOverOKSE()    {        PlaySE("TapButton");    }
    public void ButtonGoResultSE()    {        PlaySE("TapButton");    }
    public void ButtonLoadSE()    {        PlaySE("TapButton");    }
    public void ButtonNoLoadSE()    {        PlaySE("TapButton");    }


    //キーを送るとクリップを返す
    public AudioClip GetNameSE(string SEName)
    {
        AudioClip UseSE = SEGGet;//宣言で入れるデフォ値、指定された番号のSEがないとこれが鳴ってしまう

        if (SEName == "GGet") { UseSE = SEGGet; }
        else if (SEName == "DoorOpen") { UseSE = SEDoorOpen; }
        else if (SEName == "CustomerVoice") { UseSE = SECustomerVoice; }
        else if (SEName == "Kill") { UseSE = SEKill; }
        else if (SEName == "TapButton") { UseSE = SETapButton; }
        else if (SEName == "Victory") { UseSE = SEVictory; }
        else if (SEName == "GGetOne") { UseSE = SEGGetOne; }
        else if (SEName == "LvUp") { UseSE = SELvUp; }
        else { Debug.Log("指定された番号のSEはありません"); }

        return UseSE;

    }
    public AudioClip GetNameBgm(string BgmName)
    {
        AudioClip UseBgm = StoreBgm1;//宣言で入れるデフォ値、指定された番号のSEがないとこれが鳴ってしまう

        if (BgmName == "StoreBgm1") { UseBgm = StoreBgm1; }
       
        else { Debug.Log("指定された番号のSEはありません"); }

        return UseBgm;
    }

    //通常音量でSE
    public void PlaySE(string SEName)
    {
        SESource.volume = SEVolume;
        AudioClip UseSE = GetNameSE(SEName);
        SESource.PlayOneShot(UseSE);
    }

    //フェードイン・アウトでSE
    public void FadeInOutSE(string SEName,float FadeInTime, float MaxTime, float FadeOutTime, float MaxVolume)
    {
        SESource.volume = 0;
        AudioClip UseSE = GetNameSE(SEName);
        SESource.DOFade(MaxVolume, FadeInTime).SetEase(Ease.InCubic);
        SESource.DOFade(0.0f, FadeOutTime).SetDelay(MaxTime + FadeInTime);
        SESource.PlayOneShot(UseSE);

    }

    //通常音量でBgm
    public void PlayStoreBgm(string BgmName)
    {
            BgmSource.clip = GetNameBgm(BgmName);
        BgmSource.Play();

    }

    //前の曲をフェードアウトしてフェードインするBgm
    public void FadeInOutBgm(string BgmName, float FadeOutTime, float WaitTime, float FadeInTime)
    {
        SESource.DOFade(0.0f, FadeOutTime).SetEase(Ease.InCubic);//まず前の曲をフェードアウト

        DOVirtual.DelayedCall(WaitTime + FadeOutTime, () => {//曲を切り替える
            BgmSource.clip = GetNameBgm(BgmName);
            BgmSource.Play();
        });

        SESource.DOFade(BgmVolume, FadeInTime).SetDelay(WaitTime+FadeOutTime) ;//Delayで無音の時間のあと、フェードイン
 
    }
    public void StopStoreBgm()
    {
        BgmSource.Stop();
    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
