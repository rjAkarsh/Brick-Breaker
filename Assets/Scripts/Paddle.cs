using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minPaddlePos;
    [SerializeField] float maxPaddlePos;
    GameStatus gameStatus;
    Ball ball;
    bool hasStarted = false;
    // Start is called before the first frame update
    void Start()
    {
         gameStatus = FindObjectOfType<GameStatus>();
         ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            hasStarted = true;
         Vector2 paddlePos;
        if (!gameStatus.IsAutoplayEnabled())
        {
            float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
            paddlePos  = new Vector2( Mathf.Clamp(mousePosInUnits, minPaddlePos, maxPaddlePos), transform.position.y );
        } else {

            paddlePos  = new Vector2( Mathf.Clamp(ball.transform.position.x, minPaddlePos, maxPaddlePos), transform.position.y );
        }
        
        transform.position = paddlePos;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(hasStarted)
          GetComponent<AudioSource>().Play();
    }
}
