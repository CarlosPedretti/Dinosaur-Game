using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    private IEnumerator SpawnObstacle()
    {

        while (true)
        {
            float minTime = 1.0f;
            float maxTime = 1.8f;
            float randomTime = Random.Range(minTime, maxTime);

            GameObject obj = ObjectPool.Instance.RequestObject(); 
            obj.transform.position = transform.position;
            yield return new WaitForSeconds(randomTime);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.SetActive(false);
    }


}