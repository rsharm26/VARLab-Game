using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

// https://www.youtube.com/watch?v=K1xZ-rycYY8 // Rollaball.

public class PlayerController : MonoBehaviour {
    private Vector2 playerStartPosition;
    private Vector2 movement; // Store the player's movement direction.
    private float speed = 3.5f;

    [SerializeField] private Rigidbody2D rb;
    public Animator animator;

    [SerializeField] // https://dennisse-pd.medium.com/flickering-color-effect-in-unity-9e198cc034af
    private SpriteRenderer sr;
    private bool shouldFlicker = false;

    [SerializeField]
    private DeathTracker dt;
    private int deaths = 0;

    [SerializeField]
    private ScoreTracker st;
    private int score = 0;

    void Start() {
        playerStartPosition = transform.position;
    }

    void Update() { // Called each frame.
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude); // Magnitude = length of movement vector (speed), squaring is optimized.
    }

    void FixedUpdate() { // Called at specific rate per frame, depending on physics frames per second (better than Update for physics).
        rb.velocity = movement * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log(collision.collider.tag);

        if (collision.collider.tag == "Bomb") { // Move back to beginning.
            dt.IncrementDeaths();
            movement = playerStartPosition;
            transform.position = movement;
            shouldFlicker = true;
            StartCoroutine(flickerRoutine());
        }

        if (collision.collider.tag == "Chest") {
            st.SetScore(9999);
            Time.timeScale = 0; // Not great.
        }
    }

    IEnumerator flickerRoutine() {
        while (shouldFlicker == true) {
            sr.color = Color.red;
            yield return new WaitForSeconds(0.3f);
            sr.color = Color.white;
            yield return new WaitForSeconds(0.3f);
            sr.color = Color.red;
            yield return new WaitForSeconds(0.3f);
            sr.color = Color.white;
            yield return new WaitForSeconds(0.3f);
            shouldFlicker = false;
        }
    }
}
