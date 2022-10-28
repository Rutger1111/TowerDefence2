using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKillerScript : MonoBehaviour
{
    // primary Towers:
    public bool Archer = false;
    public bool HandSoldier = false;
    public bool ConnonMan = false;
    public bool GunMan = false;

    //upgraded Towers:

    public GameObject enemychecker;
    public GameObject fastestEnemie;
    public int waveI = 0;
    public int i = 0;
    public float tijdInterVal = 0.3f;
    public int HandPower = 1;
    //public GameObject fastestEnemie;
    public List<GameObject> enemies = new List<GameObject>();
    public List<GameObject> waveMachines = new List<GameObject>();
//    public TowerPlacement towerplacement;
    public bool Placing;
    public bool col;
    public bool isAanVallen = false;
    // Start is called before the first frame update
    void Start()
    {
//        towerplacement = GetComponent<TowerPlacement>();
    }

    // Update is called once per frame
    void Update()
    {
        /*int i = 0; i <= (waveMachines[waveI].GetComponent<wavesScript2>().ingespawned.Count - 1);*/
//        Placing = towerplacement.Placing;
        if (Placing == false)
        {
            if (HandSoldier == true)
            {
                enemies = transform.GetChild(0).GetComponent<EnemyChecker>().enemies;
                fastestEnemie = transform.GetChild(0).GetComponent<EnemyChecker>().FastestEnemie;
                Debug.Log("snelste " + fastestEnemie);
                if (fastestEnemie == null)
                {
                    Debug.Log("new");
                    fastestEnemie = transform.GetChild(0).GetComponent<EnemyChecker>().FastestEnemie;
                    Debug.Log("oud");
                }

                if (transform.position.x - fastestEnemie.transform.position.x >= -8 && transform.position.x - fastestEnemie.transform.position.x <= 0 || transform.position.z - fastestEnemie.transform.position.z <= 8 && transform.position.z - fastestEnemie.transform.position.z >= 0)
                {
                    if (isAanVallen == false && fastestEnemie != null)
                    {
                        isAanVallen = true;
                        StartCoroutine(Attack(tijdInterVal));
                    }
                }


                /*
                //if (i == waveMachines[waveI].GetComponent<wavesScript2>().ingespawned.Count - 1)
                //{
                waveI ++;
                if (waveI == waveMachines.Count)
                {
                    i = 0;
                }
                        
                //}
                if (waveI == waveMachines.Count)
                {
                    waveI = 0;
                }
                i++;


                for (int i = -0;  i <= enemies.Count - 1; i++)
                {
                    if (enemies[i].GetComponent<Path>().Leeftijd > fastestEnemie.GetComponent<Path>().Leeftijd)
                    {
                        fastestEnemie = enemies[i];
                    }
                }
                */
            }
        }
        if (Placing == true)
        {
            transform.position = new Vector3(GameObject.Find("Placer").transform.position.x, GameObject.Find("Placer").transform.position.y, 0);
            if (Input.GetMouseButtonUp(0))
            {
                Placing = false;
            }
        }
    }
    IEnumerator Attack(float TimeInterval)
    {
        yield return new WaitForSeconds(TimeInterval);
        isAanVallen = false;
        GameObject fastestEnemie = transform.GetChild(0).GetComponent<EnemyChecker>().FastestEnemie;
        fastestEnemie.GetComponent<Path>().Health -= HandPower;
        if (fastestEnemie.GetComponent<Path>().Health <= 0)
        {
            Destroy(fastestEnemie);
            transform.GetChild(0).GetComponent<EnemyChecker>().enemies.Remove(fastestEnemie);
            fastestEnemie = null;
        }
        //StartCoroutine(Attack(tijdInterVal));
    }
}