using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bird_scirpt : MonoBehaviour
{
    public Rigidbody2D rigidb;
    public float jump_vel;
    public GameObject you_win;
    public GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        rigidb.velocity = Vector2.up * 2.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) == true)
        {
            // print(Input.GetKeyDown(KeyCode.Space));
            rigidb.velocity = Vector2.up * jump_vel * Time.deltaTime;
            // print(rigidb.velocity);
            // rigidb.AddForce(Vector2.up * 10);
            // rigidb.AddForce(Vector2.up * jump_vel, ForceMode2D.Impulse);
            // rigidb.AddForceAtPosition(Vector2.up * jump_vel, Vector2.left * 0.3f, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "key") {
            Vector2 vel = rigidb.velocity;
            vel.x = 0.1f * Mathf.Sign(vel.x);
            rigidb.velocity = vel;
        } else if (other.gameObject.tag == "death wall") {
            string name = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(name, LoadSceneMode.Single);
        } else if (other.gameObject.tag == "win wall") {
            Destroy(parent);
            you_win.SetActive(true);
        }
    }
}
