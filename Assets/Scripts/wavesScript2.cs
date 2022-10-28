using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wavesScript2 : MonoBehaviour
{
    public EnemyChecker enemycheck;
    public bool wave1;
    public int i = 0;
    public int wavetussenTijd = 10;
    public int WaveNeeded = 1;
    public GameObject NextWave;
    public List<GameObject> WaveInhoud = new List<GameObject>();
    // public List<GameObject> ingespawned = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        if (wave1 == true)
        {
            StartCoroutine(spawn(1));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator spawn(float TimeInteraction)
    {
        int tijd = 1;
        if (WaveNeeded == 1)
        {
            if (i == WaveInhoud.Count - 1)
            {
                i = 0;
                WaveNeeded++;
                tijd = wavetussenTijd;
            }
        }

        yield return new WaitForSeconds(TimeInteraction);
        if (WaveNeeded == 1)
        {
            GameObject Enemy = Instantiate(WaveInhoud[i], transform.position, transform.rotation);
            Enemy.GetComponent<Path>().Speed = 1;
            Enemy.GetComponent<Path>().PathPoints = GameObject.Find("Enemy").GetComponent<Path>().PathPoints;
            i += 1;
        }

        if (WaveNeeded == 2)
        {
            StartCoroutine(NextWave.GetComponent<wavesScript2>().spawn(wavetussenTijd));
        }

        if (WaveNeeded == 1)
        {
            StartCoroutine(spawn(tijd));
        }
    }
}