using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//spawns all objects (obstacles, player)

public class ObjectSpawner : MonoBehaviour
{

    [SerializeField] private Transform spawnPos;
    [SerializeField] private float minTime;
    [SerializeField] private float maxTime;
    [SerializeField] private List<GameObject> movingObjects;
    private int direction;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObject());
        direction = Random.Range(0,2);


    }

// Update is called once per frame

//adds delay to object spawning when the player spawns

    private IEnumerator SpawnObject(){
        yield return new WaitForSeconds(Random.Range(0.5f,1));
        while(true){
            GameObject go = Instantiate(movingObjects[Random.Range(0,movingObjects.Count)], transform.position+new Vector3(-9,0,0), Quaternion.identity);
            go.transform.Rotate(new Vector3(0, 90, 0));
            if(direction == 0){
                go.transform.Translate(new Vector3(0, 0 , 18));
                go.transform.Rotate(new Vector3(0, 180, 0));

            }
            yield return new WaitForSeconds(Random.Range(minTime,maxTime));
        }
    }
}
