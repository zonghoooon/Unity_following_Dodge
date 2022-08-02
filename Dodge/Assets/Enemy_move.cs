using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Enemy_move : MonoBehaviour
{
    public GameObject player;
    public GameObject pannel;
    public float speed = 1.0f;

    // Update is called once per frame
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pannel = GameObject.Find("Canvas").transform.GetChild(1).gameObject;
    }
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed );

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            pannel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void Retry()
    {
        pannel.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");  
    }
}
