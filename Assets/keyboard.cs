using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class keyboard : MonoBehaviour
{
    string word;
    int index;
    public GameObject key;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        word = "wokak";
        TMP_Text text = key.GetComponent<TMP_Text>();
        text.text = word;
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (index >= word.Length) {
            word = "wokak";
            TMP_Text text = key.GetComponent<TMP_Text>();
            text.text = word;
            index = 0;
        }

        Vector3 pos = transform.position;
        pos.x = player.transform.position.x;
        transform.position = pos;
    
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            index = 0;
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            string name = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(name, LoadSceneMode.Single);
        }

        foreach (char k in Input.inputString) {
            if (march(k)) {
                GameObject t = Instantiate(key, transform.position + Vector3.up * 0.03f, transform.rotation);
                t.transform.SetParent(transform);

                TMP_Text txt = t.GetComponent<TMP_Text>();
                txt.text = k.ToString();
                txt.transform.SetParent(t.transform);

                Rigidbody2D rgd = t.GetComponent<Rigidbody2D>();
                rgd.bodyType = RigidbodyType2D.Dynamic;
                rgd.velocity = (player.transform.position - t.transform.position).normalized * 20.5f;
                rgd.mass = 0.1f;
                rgd.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
            }
        }
    }

    bool march(char k) {
        // return k == 'w';
        if (word.Length > index && word[index] == k) {
            index += 1;
            TMP_Text text = key.GetComponent<TMP_Text>();
            text.text = "<color=\"red\">" + word[..index] + "</color>" + word[index..];
            return true;
        }

        return false;
    }
}
