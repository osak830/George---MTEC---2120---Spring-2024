using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDetector : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject LeftPaddle;
    public GameObject RightPaddle;
    public GameObject Ball;

    
    public float ForceAmt = 4f;
    public float BallShotForce = 100f;

    private bool BallIsReset;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(BallIsReset)
            {
                Ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1f, 1f) * BallShotForce, ForceMode2D.Force);  
            }
            else
            {
                SetBallGravity(1f);
            }
        }

        if(Input.GetKey(KeyCode.A))
        {
            LeftPaddle.GetComponent<Rigidbody2D>().AddForceAtPosition(new Vector2(0f, ForceAmt), new Vector2(1f, 0f), ForceMode2D.Impulse);
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            RightPaddle.GetComponent<Rigidbody2D>().AddForceAtPosition(new Vector2(0f, ForceAmt), new Vector2(1f, 0f), ForceMode2D.Impulse);
        }
    }

    public void DoBallReset()
    {
        BallIsReset = true;
        SetBallGravity(0f);
    }

    public void SetBallGravity(float newGravity)
    {
        Ball.GetComponent<Rigidbody2D>().gravityScale = newGravity;
    }
}