using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolScript : MonoBehaviour
{
    const string LEFT = "left";
    const string RIGHT = "right";

    [SerializeField]
    Transform castPosition;

    [SerializeField]
    float baseCastDistance;

    string facingDirection;
    Vector3 baseScale;
    Rigidbody2D rigidBody;
    float moveSpeed = 1;

    void Start()
    {
        baseScale = transform.localScale;
        facingDirection = RIGHT;
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float vX = moveSpeed;

        if (facingDirection == LEFT)
        {
            vX = -moveSpeed;
        }

        rigidBody.velocity = new Vector2(vX, rigidBody.velocity.y);
        
        if (IsHittingWall() || IsNearEdge())
        {
            if (facingDirection == LEFT)
            {
                Flip(RIGHT);
            }
            else if (facingDirection == RIGHT)
            {
                Flip(LEFT);
            }
        }
    }

    void Flip(string newDirection)
    {
        Vector3 newScale = baseScale;

        if (newDirection == LEFT)
        {
            newScale.x = -baseScale.x;
        }
        else if (newDirection == RIGHT)
        {
            newScale.x = baseScale.x;
        }

        transform.localScale = newScale;
        facingDirection = newDirection;
    }

    bool IsHittingWall()
    {
        bool val = false;
        float castDistance = baseCastDistance;

        if (facingDirection == LEFT)
        {
            castDistance = -baseCastDistance;
        }
        else
        {
            castDistance = baseCastDistance;
        }

        Vector3 targetPosition = castPosition.position;
        targetPosition.x += castDistance;

        Debug.DrawLine(castPosition.position, targetPosition, Color.blue);

        if (Physics2D.Linecast(castPosition.position, targetPosition, 1 << LayerMask.NameToLayer("Ground")))
        {
            val = true;
        }
        else
        {
            val = false;
        }

        return val;
    }

    bool IsNearEdge()
    {
        bool val = false;
        float castDistance = baseCastDistance;

        Vector3 targetPosition = castPosition.position;
        targetPosition.y -= castDistance;

        Debug.DrawLine(castPosition.position, targetPosition, Color.blue);

        if (Physics2D.Linecast(castPosition.position, targetPosition, 1 << LayerMask.NameToLayer("Ground")))
        {
            val = false;
        }
        else
        {
            val = true;
        }

        return val;
    }
}
