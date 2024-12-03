using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public Transform[] points;
    public GameObject factory;
    private void Start()
    {
        StartCoroutine(SpawnFactory());
    }
    IEnumerator SpawnFactory()
    {
        for(int i =1; i<points.Length; i++)
        {
            yield return new WaitForSeconds(10f);
            GameObject spawn = Instantiate(factory);
            Destroy(spawn.GetComponent<PlaceObjects>());
            spawn.transform.position = points[i].position;
            spawn.transform.rotation = Quaternion.Euler(new Vector3(0, UnityEngine.Random.Range(0, 360), 0 ));
            spawn.GetComponent<AutoCarCreate>().enabled = true;
            spawn.GetComponent<AutoCarCreate>().isEnemy = true;
        }
    }
}