using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {
    public float ballSpeed;
    public float ballBounciness;
    public Color ballColor;

    private Rigidbody2D rigid2D;
    private CircleCollider2D circleColl2D;
    void Start() {
        rigid2D = this.GetComponent<Rigidbody2D>();
        circleColl2D = this.GetComponent<CircleCollider2D>();

        StartGame(GetRandomPlayer());
    }


    void Update() {

    }


    public GameObject GetRandomPlayer() {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject selectedPlayer = players[Random.Range(0, players.Length)];
        Debug.LogError(selectedPlayer);
        return selectedPlayer;
    }

    public bool StartGame(GameObject startPlayer) {
        if(startPlayer == null) {
            return false;
        } else {
            Vector2 velocity = new Vector2(startPlayer.transform.position.x, startPlayer.transform.position.y);
            velocity.Normalize();
            rigid2D.AddForce(velocity * ballSpeed);
            Debug.LogError("Starting!");
            return true;
        }
    }
    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketHeight) {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    void OnCollisionEnter2D(Collision2D col) {
        Debug.LogError("COL");
        if(col.transform.tag == "Player") {
            Debug.LogError("COLLIDING!");
            rigid2D.velocity += col.gameObject.GetComponent<Rigidbody2D>().velocity.normalized;
        }
    }
}
