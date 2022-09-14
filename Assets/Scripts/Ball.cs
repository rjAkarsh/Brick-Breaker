using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // reference parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float startVx=3, startVy=5;
    [SerializeField] Rigidbody2D myRigidbody2D;
    bool hasStarted = false;
    
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
       
    }

    private void LockBallToPaddle() {
         float paddlePosx = paddle1.transform.position.x;
        transform.position = new Vector2( paddlePosx, transform.position.y );
    }

    private void LaunchOnMouseClick() {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidbody2D.velocity = new Vector2(startVx, startVy);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (myRigidbody2D.velocity.x == 0  )
        {
            myRigidbody2D.velocity = new Vector2(-myRigidbody2D.velocity.y/10, myRigidbody2D.velocity.y  );
        }
        else if (myRigidbody2D.velocity.y ==0 )
        {
            myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, -myRigidbody2D.velocity.x/5);
        }
    }

    
}
