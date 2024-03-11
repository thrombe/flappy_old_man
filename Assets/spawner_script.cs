using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner_script : MonoBehaviour
{
    public GameObject pipe;
    public float spawn_rate = 2;
    float timer = 0;
    public float y_up = 0.8f;
    public float y_down = -0.5f;

    // Start is called before the first frame update
    void Start()
    {
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawn_rate) {
            timer = 0;
            spawn();
        }
    }

    void spawn() {
        Vector3 pos = transform.position + Vector3.up * Random.Range(y_down, y_up);
        Instantiate(pipe, pos, transform.rotation);
    }
}
