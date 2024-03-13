using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart_game_script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) {
            string name = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(name, LoadSceneMode.Single);
        }
    }
}
