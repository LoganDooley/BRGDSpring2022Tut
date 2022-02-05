using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed =  5f;
    private int score = 0;
    public Text scoreText;
    public Text winText;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);

        rb.AddForce(movement.normalized*speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("pick up"))
        {
            other.gameObject.SetActive(false);
            score += 1;
            scoreText.text = "Score: " + score;
            if(score >= 8)
            {
                scoreText.gameObject.SetActive(false);
                winText.gameObject.SetActive(true);
            }
        }
    }
}
