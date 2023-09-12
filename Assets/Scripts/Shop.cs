using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public UiManager uiManager;

    public GameObject Particle1;
    public GameObject Particle2;
    public GameObject Particle3;
    public GameObject Particle4;

    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;
    public GameObject Item4;
    
    public GameObject Lock1;
    public GameObject Lock2;
    public GameObject Lock3;

    public Sprite YellowSprite;
    public Sprite GreenSprite;


    

    public void ItemOpen()
    {
        Particle1.SetActive(true);
        Particle2.SetActive(false);
        Particle3.SetActive(false);
        Particle4.SetActive(false);

        Item1.GetComponent<Image>().sprite = GreenSprite;
        Item2.GetComponent<Image>().sprite = YellowSprite;
        Item3.GetComponent<Image>().sprite = YellowSprite;
        Item4.GetComponent<Image>().sprite = YellowSprite;

        PlayerPrefs.SetInt("ItemSelect", 0);

    }

    public void ItemOpen2()
    {
        Particle1.SetActive(false);
        Particle2.SetActive(true);
        Particle3.SetActive(false);
        Particle4.SetActive(false);

        Item1.GetComponent<Image>().sprite = YellowSprite;
        Item2.GetComponent<Image>().sprite = GreenSprite;
        Item3.GetComponent<Image>().sprite = YellowSprite;
        Item4.GetComponent<Image>().sprite = YellowSprite;

        PlayerPrefs.SetInt("ItemSelect", 1);


    }

    public void ItemOpen3()
    {
        Particle1.SetActive(false);
        Particle2.SetActive(false);
        Particle3.SetActive(true);
        Particle4.SetActive(false);

        Item1.GetComponent<Image>().sprite = YellowSprite;
        Item2.GetComponent<Image>().sprite = YellowSprite;
        Item3.GetComponent<Image>().sprite = GreenSprite;
        Item4.GetComponent<Image>().sprite = YellowSprite;

        PlayerPrefs.SetInt("ItemSelect", 2);


    }

    public void ItemOpen4()
    {
        Particle1.SetActive(false);
        Particle2.SetActive(false);
        Particle3.SetActive(false);
        Particle4.SetActive(true);

        Item1.GetComponent<Image>().sprite = YellowSprite;
        Item2.GetComponent<Image>().sprite = YellowSprite;
        Item3.GetComponent<Image>().sprite = YellowSprite;
        Item4.GetComponent<Image>().sprite = GreenSprite;

        PlayerPrefs.SetInt("ItemSelect", 3);


    }


    public void Awake()
    {
        if (PlayerPrefs.HasKey("ItemSelect") == false)
            PlayerPrefs.SetInt("ItemSelect", 0);

        //---------------------------------ITEM SELECT-----------------------------------//
        if (PlayerPrefs.GetInt("ItemSelect") == 0)
            ItemOpen();

        else if (PlayerPrefs.GetInt("ItemSelect") == 1)
            ItemOpen2();

        else if (PlayerPrefs.GetInt("ItemSelect") == 2)
            ItemOpen3();

        else if (PlayerPrefs.GetInt("ItemSelect") == 3)
            ItemOpen4();


        //---------------------------------LOCKED-----------------------------------//
        if (PlayerPrefs.HasKey("LockControll") == false)
            PlayerPrefs.SetInt("LockControll", 0);

        if (PlayerPrefs.HasKey("Lock1Controll") == false)
            PlayerPrefs.SetInt("Lock1Controll", 0);

        if (PlayerPrefs.HasKey("Lock2Controll") == false)
            PlayerPrefs.SetInt("Lock2Controll", 0);


        if (PlayerPrefs.GetInt("LockControll") == 1)
            Lock1.SetActive(false);

        if (PlayerPrefs.GetInt("Lock1Controll") == 1)
            Lock2.SetActive(false);

        if (PlayerPrefs.GetInt("Lock2Controll") == 1)
            Lock3.SetActive(false);


    }

    public void LockOpen()
    {
        int money = PlayerPrefs.GetInt("Money");
        int lockcontroll = PlayerPrefs.GetInt("LockControll");
        if (money >=2000 && lockcontroll == 0)
        {
            Lock1.SetActive(false);
            PlayerPrefs.SetInt("Money", money -2000);
            PlayerPrefs.SetInt("LockControll", 1);
            ItemOpen2();
            uiManager.CoinTextUpdate();

        }
    }

    public void Lock2Open()
    {
        int money = PlayerPrefs.GetInt("Money");
        int lock1controll = PlayerPrefs.GetInt("Lock1Controll");
        if (money >= 5000 && lock1controll == 0)
        {
            Lock2.SetActive(false);
            PlayerPrefs.SetInt("Money", money - 5000);
            PlayerPrefs.SetInt("Lock1Controll", 1);
            ItemOpen3();
            uiManager.CoinTextUpdate();

        }
    }


    public void Lock3Open()
    {
        int money = PlayerPrefs.GetInt("Money");
        int lock2controll = PlayerPrefs.GetInt("Lock2Controll");
        if (money >= 10000 && lock2controll == 0)
        {
            Lock3.SetActive(false);
            PlayerPrefs.SetInt("Money", money - 10000);
            PlayerPrefs.SetInt("Lock2Controll", 1);
            ItemOpen4();
            uiManager.CoinTextUpdate();

        }
    }

}
