using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoPaddle : MonoBehaviour
{
    public float unitsPerSecond = 6f;
    public bool RightPlayer;
    public Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    
    {
    
        float horizontalValue = Input.GetAxis(RightPlayer ? "Top" : "Bot");
        Vector3 force = Vector3.right * horizontalValue * unitsPerSecond;//* unitsPerSecond * Time.deltaTime;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(force, ForceMode.Force);
        
        
    }

    void Update()
    {

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Vector3 bounceDirection = (collision.contacts[0].point - transform.position).normalized;

            Rigidbody ballRb = collision.rigidbody;
            ballRb.velocity += bounceDirection * unitsPerSecond;
        }
    }
}
