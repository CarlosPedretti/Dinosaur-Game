using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //[SerializeField] private GameObject[] obstacles;


    void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    private IEnumerator SpawnObstacle()
    {

        while (true)
        {
           // int randomIndex = Random.Range(0, obstacles.Length);
            float minTime = 1.0f;
            float maxTime = 1.8f;
            float randomTime = Random.Range(minTime, maxTime);

            //Instantiate(obstacles[randomIndex], transform.position, Quaternion.identity);
            GameObject obj = ObjectPool.Instance.RequestObject(); 
            obj.transform.position = gameObject.transform.position;
            yield return new WaitForSeconds(randomTime);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.SetActive(false);
    }


}