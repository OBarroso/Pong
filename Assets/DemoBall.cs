using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoBall : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public int player1Score = 0;
    public int player2Score = 0;

    // Start is called before the first frame update
    void Start()
    {
        Launch();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        GetComponent<Rigidbody>().velocity = new Vector3(speed * x, speed * y, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GoalPlayer1"))
        {
            player2Score++;
            Debug.Log("Goal for Player 2! " + player2Score);
            
            CheckWinCondition();
            
        }
        else if (collision.gameObject.CompareTag("GoalPlayer2"))
        {
            player1Score++;
            Debug.Log("Goal for Player 1! " + player1Score);
            
            CheckWinCondition();
            
        }
    }

    private void CheckWinCondition()
    {
        if (player1Score >= 3 || player2Score >= 3)
        {
            Debug.Log("Game Over! Resetting scores...");
            ResetScores();
        }
    }

    private void ResetScores()
    {
        player1Score = 0;
        player2Score = 0;
        Debug.Log("Player 1 Score: " + player1Score);
        Debug.Log("Player 2 Score: " + player2Score);
    }
}
