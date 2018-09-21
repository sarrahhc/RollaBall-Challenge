using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text scoreText;
    public Text winText;
    int x;


    private int score;
    private int count;
    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        SetCountText();

        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score + 1;
            SetCountText();
            if (count == 12)
            {
                transform.position = new Vector3(20.0f, rb.transform.position.y, 3.0f);
            }
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            score = score - 1;
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        scoreText.text = "Score: " + score.ToString();
        if (count >= 24)
        {
            winText.text = "You Finished with a score of: " + score.ToString();
        }
    }

}
