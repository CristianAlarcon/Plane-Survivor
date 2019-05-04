using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range(0.1f, 5f)] [SerializeField] float currentSpeed = 10f;
    //[SerializeField] float damage = 50f;
    Player player;
    bool rightDirection;
    BoxCollider2D myCollider;

    void Start ()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        if (player.isFacingRight())
        {
            rightDirection = true;
        }
        else
        {
            rightDirection = false;
        }
    }

    void Update()
    {
        if (rightDirection)
        {
            transform.Translate(Vector2.right * currentSpeed * Time.deltaTime, Space.World);
        }
        else
        {
            transform.Translate(Vector2.left * currentSpeed * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var enemyMovement = otherCollider.GetComponent<EnemyMovement>();
        if (enemyMovement)
        {
            Destroy(gameObject);
            enemyMovement.die();
        }
        //else Debug.Log(otherCollider.gameObject);

    }

}