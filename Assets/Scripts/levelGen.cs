using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//generates terrain

public class levelGen : MonoBehaviour
{
  public GameObject Coin;
  public PlayerMovement player;
  [SerializeField] private List<GameObject> terrainTypes;
  public static List<GameObject> terrainList = new List<GameObject>();
  int rTerrain = 0;
  int rNum;
  int lev2player = 12;
  float max = 0;
  int terrainMade = 0;

    Vector3 pos = new Vector3(0,0,0);
    void Start(){
      for(int i = -12 ; i < 12; i++){
          pos = new Vector3(0,0,i);
          GameObject terrain = Instantiate(terrainTypes[3]) as GameObject;
          terrainList.Add(terrain);
          terrain.transform.position = pos;
        }
      for(int i = 0; i < 4;i++){
        rTerrain = Random.Range(0,terrainTypes.Count);
        rNum = Random.Range(1,8);
        for(int j = 0; j < rNum; j++ ){
          pos = new Vector3(0,0,lev2player);
          GameObject terrain = Instantiate(terrainTypes[rTerrain]) as GameObject;
          lev2player +=1;
          terrainList.Add(terrain);
          terrain.transform.position = pos;
          if(Random.Range(0,4)==0){
            GameObject coin = Instantiate(Coin) as GameObject;
            coin.transform.position = pos + new Vector3(Random.Range(-7,7), .53f, 0);
          }
        }
      }
      rNum = 0;
    }

    // Update is called once per frame
    //deletes terrain at the very beginning

void Update(){

    if(Input.GetButtonUp("up") && Mathf.Round(max) == Mathf.Round(player.transform.position.z) && player.transform.position==player.endPos){
      if(terrainMade == rNum){
        terrainMade = 0;
        rTerrain = Random.Range(0,terrainTypes.Count);
        rNum = Random.Range(1,8);
      }
      if(terrainMade < rNum){
        pos = new Vector3(0,0,lev2player);
        GameObject terrain = Instantiate(terrainTypes[rTerrain]) as GameObject;
        lev2player +=1;
        terrainList.Add(terrain);
        terrain.transform.position = pos;
        if(Random.Range(0,4)==0){
          GameObject coin = Instantiate(Coin) as GameObject;
          coin.transform.position = pos + new Vector3(Random.Range(-7,7), .53f, 0);
        }
        Destroy(terrainList[0]);
        terrainList.RemoveAt(0);
        terrainMade++;
      }
    }
    if(max < player.transform.position.z)
      max = player.transform.position.z;
  }
}
