using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MovingObjectScript : MonoBehaviour
{

    public float speed = 2f;
    private Rigidbody rb;
    public Text countText;
    public Text scoreText;
    private int score;
    private int count;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    public Rigidbody projectile;

    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, speed * Time.deltaTime);
    }

}