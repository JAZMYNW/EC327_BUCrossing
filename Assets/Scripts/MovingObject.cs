using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    
    [SerializeField] private float speed;
    void Update()
    {
        // object off screen
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if(transform.position.x > 10 || transform.position.x < -10) {
            Destroy(this.gameObject);
        }
    }
    
}
