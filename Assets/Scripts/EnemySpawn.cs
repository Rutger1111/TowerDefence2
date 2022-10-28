using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made By Tom & Sil
public class EnemySpawn : MonoBehaviour
{
    public Waves waves;[SerializeField] int wave = 0; public List<Waves> wavesList;

    void Update() { if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.N)) { waves = wavesList[wave]; StartCoroutine(wavestart()); wave++; } }
    IEnumerator wavestart()
    {
        for (int i = 0; i < waves.waveEnemies.Length; i++)
        {
            for (int j = 0; j < waves.waveAmounts[i]; j++) { Instantiate(waves.waveEnemies[i], this.transform.position, Quaternion.identity); yield return new WaitForSeconds(1f); }
            Debug.Log("part done");

        }
        Debug.Log("wave done");
    }
}

