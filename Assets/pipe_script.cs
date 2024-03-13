using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe_script : MonoBehaviour
{
    float move_speed = 0.4f;
    float death_x = -2.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * move_speed * Time.deltaTime;


        if (transform.position.x < death_x) {
            Destroy(gameObject);
        }
    }
}
