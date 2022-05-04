using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Code to move player
public class PlayerMovement : MonoBehaviour {


  float curmoveTime;
  float percent = 1 ; // used to determine how far until target position
  float currentScaleTime;
  float scalePercent;

  bool inp1;

  public float lerpSpeed = 5;
  public float scaleSpeed = 3;
  public Transform child;
  public float axisSChange = 0.1f;
  public AnimationCurve ac;
  public Animation a;

  Vector3 startPos = new Vector3(0,1,0);
  public  Vector3 endPos = new Vector3(0,1,0);

  Vector3 startSc;
  Vector3 endSc;

  List<GameObject> terrains = levelGen.terrainList;

  public GameObject Cam;

  public string[] models = new string[] { "turkey","bu_rhett", "bc_eagle","neu_husky", "tufts_jumbo","prof"};
  public GameObject[] model = new GameObject[6];

// Setup at game start
  void Start(){

    for(int i = 0; i < 6;i++){
      model[i].SetActive(false);
    }

    model[CharacterSelection.charnum - 1].SetActive(true);

    child = gameObject.transform.Find(models[CharacterSelection.charnum - 1]);
    a = gameObject.transform.Find(models[CharacterSelection.charnum - 1]).GetComponent<Animation>();
  }



    // Update is called once per frame
  public void Update(){


    if(Input.GetButtonDown("up") || Input.GetButtonDown("down") || Input.GetButtonDown("left") || Input.GetButtonDown("right")){
        currentScaleTime = 0;
    }

    if(Input.GetButton("up") || Input.GetButton("down") || Input.GetButton("left") || Input.GetButton("right")){
        startSc = gameObject.transform.localScale ;
        endSc = new Vector3(transform.localScale.x + axisSChange, transform.localScale.y - axisSChange, transform.localScale.z);
        inp1 = true;
    }

    if(Input.GetButtonUp("up") || Input.GetButtonUp("down") || Input.GetButtonUp("left") || Input.GetButtonUp("right")){
      if(percent>=1){
        a.Play("Jump");
        curmoveTime = 0 ;
        currentScaleTime = 0;
        percent = 0;
        startPos = gameObject.transform.position;
        startSc = gameObject.transform.localScale;
        endSc = new Vector3(1,1,1);
      }
    }

    if(Input.GetButtonUp("right") && gameObject.transform.position==endPos){

      endPos = new Vector3(transform.position.x+1 , transform.position.y , transform.position.z);

    }
    if(Input.GetButtonUp("left") && gameObject.transform.position==endPos){

      endPos = new Vector3(transform.position.x-1 , transform.position.y , transform.position.z);

    }
    if(Input.GetButtonUp("up") && gameObject.transform.position==endPos){

      endPos = new Vector3(transform.position.x , transform.position.y , transform.position.z+1);
      ScoreManagment.instance.AddPoint();

    }
    if(Input.GetButtonUp("down") && gameObject.transform.position==endPos){

      endPos = new Vector3(transform.position.x , transform.position.y , transform.position.z-1);
      ScoreManagment.instance.RemovePoint();

    }

    if(inp1){

      curmoveTime+=Time.deltaTime * lerpSpeed;  //using deltatime allows the game to run similar despite differing frames per seconds
      percent = curmoveTime;
      gameObject.transform.position = Vector3.Lerp(startPos,endPos,ac.Evaluate(percent));

      currentScaleTime+= Time.deltaTime * scaleSpeed;
      scalePercent = currentScaleTime;
      child.transform.localScale = Vector3.Lerp(startSc,endSc,ac.Evaluate(scalePercent));

    }
    //off screen
    if(Cam.transform.position.z - 9 > gameObject.transform.position.z || gameObject.transform.position.x > 8 || gameObject.transform.position.x < -8){ 
      gameOver();
    }
  }



  // Game Over function
  public void gameOver(){
    //deletes terrain
    while(terrains.Count > 0){
      Destroy(terrains[0]);
      terrains.RemoveAt(0);
    }
    Invoke("Restart",0);

  }

  //Collision Handling
  void OnCollisionEnter(Collision collision){ 
    if(collision.collider.tag == "Enemy"){
        gameOver();
    }
    if(collision.collider.tag == "Safe"){
      transform.parent =  collision.gameObject.transform;
    }
  }

  // log collision
  void OnTriggerExit(Collider col){
    gameObject.transform.parent = null;
  }
  // Restart game
  void Restart() {
    SceneManager.LoadScene("GameOver");

  }
}
