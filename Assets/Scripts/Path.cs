using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public int Health;
    public int I;
    public float Leeftijd;
    public float StartTime;
    public float Speed = 1;
    public List<GameObject> enemychecker;
    public List<GameObject> PathPoints;
    // Start is called before the first frame update
    void Start()
    {
        StartTime = Time.time;
        GameObject.Find("EnemyCount").GetComponent<MenuHandler>().EnemyCount += 1;
        // transform.LookAt(PathPoints[I + 1]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            /*
            for (int I = 0; I <= enemychecker.Count;)
            {
                if (enemychecker[I].GetComponent<EnemyKillerScript>().fastestEnemie == gameObject)
                {
                    enemychecker[I].GetComponent<EnemyKillerScript>().fastestEnemie = null;
                }
                if (enemychecker[I].GetComponent<EnemyChecker>().enemies[I] == gameObject)
                {
                    enemychecker[I].GetComponent<EnemyChecker>().enemies.Remove(enemychecker[I].GetComponent<EnemyKillerScript>().enemies[I]);
                }
                I++;
            }

            Debug.Log("Destroyed");
            Destroy(gameObject);
            */
        }
        Leeftijd = Time.time - StartTime;
        //Debug.Log(GameObject.Find("Sphere").transform.position.magnitude);
        //Vector3 Distance = (GameObject.Find("Sphere").transform.position - GameObject.Find("Cube").transform.position);
        Vector3 Distance = (PathPoints[I].transform.position - PathPoints[I + 1].transform.position);
        Distance = Vector3.Normalize(Distance);
        Debug.Log(Distance);
        transform.position += Distance * Time.deltaTime * -Speed;

        if (Vector3.Distance(transform.position, PathPoints[I + 1].transform.position) < 1.5f)
        {
            Debug.Log("dit werktmaarniiiet");
            I++;
            transform.rotation = PathPoints[I].transform.rotation;

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Finish")
        {
            Destroy(gameObject);
            GameObject.Find("Lives").GetComponent<MenuHandler>().Lives -= 10;
            
        }
    }
}
