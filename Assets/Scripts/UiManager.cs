using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public Sound SesScript;

    public Image WhiteEfeckImage;
    private int EfectKontrol = 0;
    private bool RadianlShine1;
    public GameObject Player;
    public GameObject FinishLine;


    public Animator LayoutAnimator;
    public Text CoinText;

    public Image FillRateImage;


    //----------//BUTONLAR//-------------
    //Setting
    public GameObject SettingOpen;
    public GameObject SettingClose; 
    public GameObject LayoutBackGround; 
    
    //Sound
    public GameObject SoundOpen;
    public GameObject SoundClose;

    //Vibration
    public GameObject VibrationOpen;
    public GameObject VibrationClose;


    //Diger Ikisi
    public GameObject Iap;
    public GameObject Information;


    public GameObject IntroHand;
    public GameObject TopTooMove;
    public GameObject NoAds;
    public GameObject ShopButton;

    public GameObject RestartScreen;

    //Oyun sonu ekrani

    public GameObject FinishScreenCanvas;
    public GameObject BlackBackGround;
    public GameObject Complete;
    public GameObject RadialShine;
    public GameObject Coin;
    public GameObject Rewarded;
    public GameObject NoThanks;

    public GameObject NextButtton;
    public GameObject RewardCoin;
    public Text RewardText;

    public void Start()
    {
        if (PlayerPrefs.HasKey("Sound") == false)
        {
            PlayerPrefs.SetInt("Sound", 1);
        }
        
        
        if (PlayerPrefs.HasKey("Vibration") == false)
        {
            PlayerPrefs.SetInt("Vibration", 1);
        }

        if (PlayerPrefs.HasKey("NoAds") == false)
        {
            PlayerPrefs.SetInt("NoAds", 0);

        }

        if (PlayerPrefs.GetInt("NoAds") == 1)
        {
            NoAdsRemove();
        }

        CoinTextUpdate();

    }

    public void Update()
    {
        if (RadianlShine1 == true)
        {
            RadialShine.GetComponent<RectTransform>().Rotate(new Vector3(0,0, 30f * Time.deltaTime));
        }

        FillRateImage.fillAmount = ((Player.transform.position.z * 100) / (FinishLine.transform.position.z)) / 100;
             //z) / (FinishLine.transform.position.z);
    }


    public void RestartButtonActive()
    {
        RestartScreen.SetActive(true);
    }
    
    public void RestartScenne()
    {
        Veriables.FirstTouch = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LevelNext()
    {
        StartCoroutine(AfterNextLevel());

    }
    public void NextScene()
    {

        Veriables.FirstTouch = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }


    public void FirstTouchDissaper()
    {
        IntroHand.SetActive(false);
        TopTooMove.SetActive(false);
        NoAds.SetActive(false);
        ShopButton.SetActive(false);
        SettingOpen.SetActive(false);
        SettingClose.SetActive(false);
        LayoutBackGround.SetActive(false);
        SoundOpen.SetActive(false);
        SoundClose.SetActive(false);
        VibrationOpen.SetActive(false);
        VibrationClose.SetActive(false);
        Iap.SetActive(false);
        Information.SetActive(false);
    }

    public IEnumerator AfterRewardButton()
    {
        RewardCoin.SetActive(true);
        RewardText.gameObject.SetActive(true);

        Rewarded.SetActive(false);
        NoThanks.SetActive(false);

        for (int i = 0; i < 401; i += 4)
        {
            RewardText.text = "+" + i.ToString();
            yield return new WaitForSeconds(0.0001f);
        }

       
        yield return new WaitForSeconds(1f);
        NextButtton.SetActive(true);

       
    }


    public void NoAdsRemove()
    {
        NoAds.SetActive(false);
    }


    public IEnumerator AfterNextLevel()
    {

        Rewarded.SetActive(false);
        NoThanks.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        NextButtton.SetActive(true);


    }

    public void CoinTextUpdate()
    {
        CoinText.text = PlayerPrefs.GetInt("Money").ToString();
    }


    //--------Buton Fonksiyonlar----------
    public void Setting_Open()
    {
        SettingOpen.SetActive(false);
        SettingClose.SetActive(true);
        LayoutAnimator.SetTrigger("Slide_in");

        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            SoundOpen.SetActive(true);
            SoundClose.SetActive(false);
            AudioListener.volume = 1;
        }
        else if (PlayerPrefs.GetInt("Sound") == 2)
        {
            SoundOpen.SetActive(false);
            SoundClose.SetActive(true);
            AudioListener.volume = 0;
        }


        if (PlayerPrefs.GetInt("Vibration") == 1)
        {
            VibrationOpen.SetActive(true);
            VibrationClose.SetActive(false);
        }     
        else if (PlayerPrefs.GetInt("Vibration") == 2)
        {
            VibrationOpen.SetActive(false);
            VibrationClose.SetActive(true);
        }
    }

    public void Setting_Close()
    {
        SettingOpen.SetActive(true);
        SettingClose.SetActive(false);
        LayoutAnimator.SetTrigger("Slide_off");
    }


    public void Sound_Open()
    {
        SoundOpen.SetActive(false);
        SoundClose.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("Sound", 2);
    }
    
    public void Sound_Close()
    {
        SoundOpen.SetActive(true);
        SoundClose.SetActive(false);
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("Sound", 1);

    }


    public void Vibration_Open()
    {
        VibrationOpen.SetActive(false);
        VibrationClose.SetActive(true); 
        PlayerPrefs.SetInt("Vibration", 2);

    }

    public void Vibration_Close()
    {
        VibrationOpen.SetActive(true);
        VibrationClose.SetActive(false);
        PlayerPrefs.SetInt("Vibration", 1);
    }

    public IEnumerator FinishLaunch()
    {
        Time.timeScale = 0.5f;
        RadianlShine1 = true;
        FinishScreenCanvas.SetActive(true);
        BlackBackGround.SetActive(true);
        yield return  new WaitForSeconds(0.4f);

        SesScript.CompleteSound();
        Complete.SetActive(true);
        yield return new WaitForSeconds(0.4f);

        SesScript.CompleteSound();
        RadialShine.SetActive(true);
        Coin.SetActive(true);
        yield return new WaitForSeconds(0.3f);


        Rewarded.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        NoThanks.SetActive(true);


    }

    public void FinishScreeen()
    {
        StartCoroutine(FinishLaunch());
    }

    
    public void PrivacyPolicy()
    {
        Application.OpenURL("https://www.youtube.com/channel/UC8kggt_PLKvlrADUV5XKneQ");
    }
    
    public void TermOfUse()
    {
        Application.OpenURL("https://www.youtube.com/channel/UC8kggt_PLKvlrADUV5XKneQ");
    }
    




    public IEnumerator WhiteEfect()
    {
        WhiteEfeckImage.gameObject.SetActive(true);
        while (EfectKontrol == 0)
        {
            yield return new WaitForSeconds(0.001f);
            WhiteEfeckImage.color += new Color(0,0,0,0.1f);

            if (WhiteEfeckImage.color == new Color(WhiteEfeckImage.color.r, WhiteEfeckImage.color.g, WhiteEfeckImage.color.b,1))
            {
                EfectKontrol = 1;
            }

        }

        while (EfectKontrol == 1)
        {
            yield return new WaitForSeconds(0.001f);
            WhiteEfeckImage.color -= new Color(0, 0, 0, 0.1f);

            if (WhiteEfeckImage.color == new Color(WhiteEfeckImage.color.r, WhiteEfeckImage.color.g, WhiteEfeckImage.color.b, 0))
            {
                EfectKontrol = 2;
            }
        }

        if (EfectKontrol == 2)
        {
            Debug.Log("Efekt bitti");
        }
    }
}
