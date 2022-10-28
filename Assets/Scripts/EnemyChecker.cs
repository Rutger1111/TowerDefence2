using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChecker : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public int i = 0;
    public GameObject FastestEnemie;
    public GameObject LastEnemy;
    // Start is called before the first frame update
    void Start()
    {

    }
    //enemies[i].GetComponent<Path>().Leeftijd > FastestEnemie.GetComponent<Path>().Leeftijd
    // Update is called once per frame
    void Update()
    {
        //Check();
        if (FastestEnemie)
        {
            Debug.Log(FastestEnemie.name);
        }
        else
        {
            FastestEnemie = enemies[0];
            if (FastestEnemie)
            {
                FastestEnemie = null;
                if (!enemies[0])
                {
                    enemies.Remove(enemies[0]);
                }
                FastestEnemie = enemies[0];
                Debug.Log(FastestEnemie.name);
            }
            else
            {
                Debug.Log("No game object called wibble found");
            }
        }
        /*
        if (LastEnemy != null)
        {
            FastestEnemie = LastEnemy;
        }
        if (LastEnemy == null)
        {
            LastEnemy = enemies[0];
            FastestEnemie = LastEnemy;
        }
        */
        Debug.Log("nieuweEnemy" + FastestEnemie);
        Debug.Log("enemycheckt");
        if (FastestEnemie == null)
        {
            i = 0;
            FastestEnemie = enemies[0];
        }
        if (i < 0)
        {
            i = 0;
        }
        if (i >= enemies.Count)
        {
            i = 0;
        }
        if (enemies.Count == 1)
        {
            FastestEnemie = enemies[i];
        }
        if (enemies.Count > 1)
        {
            if (enemies[i].GetComponent<Path>().Leeftijd > FastestEnemie.GetComponent<Path>().Leeftijd)
            {
                Debug.Log("werkt");
                FastestEnemie = enemies[i];
            }
        }

        i++;
        if (i >= enemies.Count)
        {
            i = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("CheckWerkt");
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("hoi");
            enemies.Add(collision.gameObject);
            collision.gameObject.GetComponent<Path>().enemychecker.Add(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("hoi");
            enemies.Remove(collision.gameObject);
            collision.gameObject.GetComponent<Path>().enemychecker.Remove(gameObject);
            if (FastestEnemie == collision.gameObject)
            {
                if (i >= enemies.Count)
                {

                    i--;
                }
                FastestEnemie = enemies[i];
            }
        }
    }
}