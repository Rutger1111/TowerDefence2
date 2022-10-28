using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public List<GameObject> Levels = new List<GameObject>();
    public int I = 0;
    public int Lives = 100;
    public int Money = 100;
    public int BuyPrice = 0;
    public int EnemyCount = 0;
    public int SceneNumber = 0;
    public bool LoadsFirstImage;
    public bool isLives = false;
    public bool isMoney = false;
    public bool isEnemyCount = false;
    public bool isTowerPLacer = false;
    public TMPro.TMP_Text text;
    public GameObject Deadmenu;
    public GameObject TowerToPlace;
    // Start is called before the first frame update
    void Start()
    {
        I = 0;
        if (PlayerPrefs.GetInt("i") >= 0)
        {
            I = PlayerPrefs.GetInt("i");
        }
        //        GameObject.Find("DeadMenu").SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (isLives == true)
        {
            if (Lives <= 0)
            {
                text.text = "Lives: " + Lives;
                Deadmenu.SetActive(true);
                Time.timeScale = 0;
            }
            text.text = "Lives: " + Lives;
        }
        if (isMoney == true)
        {
            text.text = "Money: " + Money;
        }
        if (isEnemyCount == true)
        {
            text.text = ": " + EnemyCount;
        }
        if (isTowerPLacer == true)
        {
            Debug.Log(Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0)));
            gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 10));
        }
    }
    public void toScene()
    {
        SceneManager.LoadScene(SceneNumber);
    }
    public void EnterLevel()
    {
        PlayerPrefs.SetInt("i", I);
        SceneManager.LoadScene(SceneNumber + I);
    }
    public void nextLevel()
    {
        Levels[I].SetActive(false);
        I++;
        if (I >= Levels.Count)
        {
            I = 0;
        }
        Levels[I].SetActive(true);
    }
    public void BackLevel()
    {
        Levels[I].SetActive(false);
        I--;
        if (I == -1)
        {
            I = Levels.Count - 1;
        }
        Levels[I].SetActive(true);
    }
    public void BuyTower()
    {
        int Money = GameObject.Find("Money").GetComponent<MenuHandler>().Money;
        if (Money >=  BuyPrice)
        {
            GameObject.Find("Money").GetComponent<MenuHandler>().Money -= BuyPrice;
            Instantiate(TowerToPlace);
        }
    }
}
