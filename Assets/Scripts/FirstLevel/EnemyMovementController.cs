using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour {
    [SerializeField] 
    private Rigidbody2D rb;
    private float speed = 2f;
    private float direction = 1f;
    private Vector2 movement; // Store the player's movement direction.

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        movement = direction == 1 ? Vector2.up : Vector2.down;
    }

    void FixedUpdate() { // Called at specific rate per frame, depending on physics frames per second (better than Update for physics).
        rb.velocity = movement * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "Bomb" || collision.collider.tag == "Wall") {
            movement = new Vector2(movement.x, movement.y == 1 ? -1 : 1);
        }
    }
}
