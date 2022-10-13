using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public List<GameObject> Levels = new List<GameObject>();
    public static int I = 0;
    public int SceneNumber = 0;
    public bool LoadsFirstImage;
    // Start is called before the first frame update
    void Start()
    {
        MenuHandler.I = 0;
        if (PlayerPrefs.GetInt("i") >= 0)
        {
            MenuHandler.I = PlayerPrefs.GetInt("i");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toScene()
    {
        SceneManager.LoadScene(SceneNumber);
    }
    public void EnterLevel()
    {
        PlayerPrefs.SetInt("i", MenuHandler.I);
        SceneManager.LoadScene(SceneNumber + MenuHandler.I);
    }
    public void nextLevel()
    {
        Levels[MenuHandler.I].SetActive(false);
        MenuHandler.I++;
        if (MenuHandler.I <= Levels.Count)
        {
            MenuHandler.I = 0;
        }
        Levels[MenuHandler.I].SetActive(true);
    }
    public void BackLevel()
    {
        Levels[MenuHandler.I].SetActive(false);
        MenuHandler.I--;
        if (MenuHandler.I > 0)
        {
            MenuHandler.I = 5;
        }
        Levels[MenuHandler.I].SetActive(true);
    }
}
