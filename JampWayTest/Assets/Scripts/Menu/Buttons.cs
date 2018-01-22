using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Buttons : MonoBehaviour {

    public float bigger = 1.15f;
    public float lower = 1f;
    public Sprite mus_on, mus_off;
    public Sprite[] themeColor;
    public GameObject ShopBG;

    private void Start()
    {
        if(gameObject.name == "color")
        {
            GetComponent<Image>().sprite = themeColor[PlayerPrefs.GetInt("CountColor")];
        }

        if(PlayerPrefs.GetString("music") == "off")
        {
            Camera.main.GetComponent<AudioListener>().enabled = false;
            if (gameObject.name == "music")
            {
                GetComponent<Image>().sprite = mus_off;
            }
        }
    }

    private void OnMouseDown()    {
        
        transform.localScale = new Vector3(bigger, bigger, bigger);
    }
    private void OnMouseUp()
    {
        transform.localScale = new Vector3(lower, lower, lower);
    }

    private void OnMouseUpAsButton()
    {
        GetComponent<AudioSource>().Play();
        switch (gameObject.name)
        {
            case "Return":                
                SceneManager.LoadScene("main");
                cubeJamp.gameOver = false;
                cubeJamp.countBlock = 0;
                break;
            case "Facebook":
                Application.OpenURL("https://ru-ru.facebook.com/");
                break;
            case "Settings":
                for(int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(!transform.GetChild(i).gameObject.activeSelf);
                }
                break;
            case "twitter":
                Application.OpenURL("https://twitter.com/");
                break;
            case "google":
                Application.OpenURL("https://google.com/");
                break;
            case "music":
                if (PlayerPrefs.GetString("music") == "off")
                {
                    GetComponent<Image>().sprite = mus_on;
                    Camera.main.GetComponent<AudioListener>().enabled = true;
                    PlayerPrefs.SetString("music", "on");
                }
                else
                {
                    GetComponent<Image>().sprite = mus_off;
                    Camera.main.GetComponent<AudioListener>().enabled = false;
                    PlayerPrefs.SetString("music", "off");
                }
                break;
            case "color":
                if (PlayerPrefs.GetInt("CountColor") + 1 == RandBG.materialCount)
                    PlayerPrefs.SetInt("CountColor", 0);
                else
                    PlayerPrefs.SetInt("CountColor", PlayerPrefs.GetInt("CountColor") + 1);
                GetComponent<Image>().sprite = themeColor[PlayerPrefs.GetInt("CountColor")];
                break;
            case "shop":                
                    ShopBG.SetActive(!ShopBG.activeSelf);
                break;
            case "close":
                ShopBG.SetActive(false);
                break;
        }
    }
}
