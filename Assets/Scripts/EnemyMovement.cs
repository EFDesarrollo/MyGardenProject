using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int type;
    public float speed;
    public Vector3 startPosition;
    public Vector3 endPosition;

    private bool movingToEnd; 

    private SpriteRenderer sprite;
    private SpriteRenderer sprite2;

    private void Start()
    {
        startPosition = transform.position;
        movingToEnd = true;

        sprite = gameObject.transform.Find("").GetComponent<SpriteRenderer>();
        sprite.flipY = true;



    }

    private void Update()
    {

        EnemyMove();
    }

    void EnemyMove()
    {
        //calculate the destination in order to movingToEnd
        Vector3 targetPosition = (movingToEnd) ? endPosition : startPosition;

        //Enemy movement
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            movingToEnd = !movingToEnd;
//            if (!upDown) sprite.flipX = !sprite.flipX;
        }
    }

}
