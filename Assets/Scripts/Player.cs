using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject sceneManager;
    public float playerSpeed = 1000;
    public float directionalSpeed = 20;
    public AudioClip scoreUp;
    public AudioClip coin;
    public AudioClip damage;

    void Start()
    {

    }
    void Update()
    {
        // change the player speed if the player speed is lower then 1700
        if (playerSpeed < 1700)
        {
            playerSpeed = playerSpeed + 0.1f;
        }

#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER
        float moveHorizontal = Input.GetAxis("Horizontal");
        transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(Mathf.Clamp(gameObject.transform.position.x + moveHorizontal, -2.5f, 2.5f), gameObject.transform.position.y, gameObject.transform.position.z), directionalSpeed * Time.deltaTime);
#endif
        GetComponent<Rigidbody>().velocity = Vector3.forward * playerSpeed * Time.deltaTime;
        transform.Rotate(Vector3.right * GetComponent<Rigidbody>().velocity.z / 3);
        // Mobile controls
        Vector2 touch = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10f));
        if (Input.touchCount > 0)
        {
            transform.position = new Vector3(touch.x, transform.position.y, transform.position.z);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "scoreup")
        {
            // make sound whene hit the tag
            GetComponent<AudioSource>().PlayOneShot(scoreUp, 1.0f);
        }
        if (other.gameObject.tag == "coin")
        {
            // make sound whene hit the tag
            GetComponent<AudioSource>().PlayOneShot(coin, 1.0f);
        }
        if (other.gameObject.tag == "triangel")
        {
            // make sound whene hit the tag
            GetComponent<AudioSource>().PlayOneShot(damage, 1.0f);
            sceneManager.GetComponent<App_initialize>().GameOver();
        }
    }
}
