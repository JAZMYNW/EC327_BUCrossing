using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spawned in objects
public class MovingObject : MonoBehaviour
{
    [SerializeField] private float speed;
    void Update()
    {
        
        transform.Translate(Vector3.forward * speed * Time.deltaTime); // move enemy
        if(transform.position.x > 10 || transform.position.x < -10) { // object off screen
            Destroy(this.gameObject);
        }
    }
}
