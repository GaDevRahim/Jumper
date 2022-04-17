using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    float speed = 20.0f;
    float posiXDestroy = -5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerController.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (transform.position.x < posiXDestroy && gameObject.CompareTag("Obstacle"))
        {
            PlayerController.score++;
            Destroy(gameObject);
        }
    }
}
