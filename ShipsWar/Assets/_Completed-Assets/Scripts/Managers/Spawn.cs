using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject[] teleport;
    public GameObject[] prefab;
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    private float spawnTime=5f;
    private float spawnTimer=5f;

    void Start()
    { //this will spawn only one prefeb, if you want call it many time, create  a new function and call it or create for loop
      //int tele_num = Random.Range(0, 2);
      //int prefeb_num = Random.Range(0, 2);
      //Instantiate(prefeb[prefeb_num], teleport[tele_num].position, teleport[tele_num].rotation);
        InvokeRepeating("Spawning", spawnTime, spawnTimer);
    }
    void Spawning()
    {
        Instantiate(prefab1, teleport[Random.Range(0, 2)].transform.position, Quaternion.identity);
        Instantiate(prefab2, teleport[Random.Range(0, 2)].transform.position, Quaternion.identity);
        Instantiate(prefab3, teleport[Random.Range(0, 2)].transform.position, Quaternion.identity);
        GameObject PowerUp = prefab[Random.Range(0, 2)];
        for (int i = 0; i < teleport.Length; i++)
        {
            //Instantiate(PowerUp, teleport[i].position, teleport[i].rotation);
            //Instantiate(prefab1, teleport[Random.Range(0, 2)].transform.position, Quaternion.identity);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(10);
        
    }
}
