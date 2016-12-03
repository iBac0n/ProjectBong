using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {
    public float ballSpeed;
    public float ballBounciness;
    public Color ballColor;

    private Rigidbody2D rigid2D;
    public CircleCollider2D circleColl2D;

    private TrailRenderer tr;
    void Start() {
        rigid2D = this.GetComponent<Rigidbody2D>();
        circleColl2D = this.GetComponent<CircleCollider2D>();

        StartGame(GetRandomPlayer());
    }


    void Update() {
        Debug.DrawRay(this.transform.position, rigid2D.velocity, Color.red);
        //rigid2D.velocity = ballSpeed * (rigid2D.velocity.normalized);
    }

    void FixedUpdate() {

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
            rigid2D.velocity = velocity.normalized * ballSpeed;
            Debug.LogError("Starting: " + velocity.normalized * ballSpeed);
            return true;
        }
    }


    //Careful we have to different between vertical players and horizontal players !
    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketHeight, bool vertical) {
        if(vertical) {
            return (ballPos.x - racketPos.x) / racketHeight;
        } else {
            return (ballPos.y - racketPos.y) / racketHeight;
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        if(col.transform.tag == "Player") {
            PlayerController controller = col.gameObject.GetComponent<PlayerController>();
            if(controller == null) {
                Debug.LogError("Not a player!");
            }
            if(controller.playerPosition == "Bottom") {
                float x = hitFactor(transform.position,
                                    col.transform.position,
                                    col.collider.bounds.size.x,
                                    true);

                Vector2 dir = new Vector2(x, 1).normalized;

                GetComponent<Rigidbody2D>().velocity = dir * ballSpeed;
            } else if(controller.playerPosition == "Top") {
                float x = hitFactor(transform.position,
                                    col.transform.position,
                                    col.collider.bounds.size.x,
                                    true);

                Vector2 dir = new Vector2(x, -1).normalized;

                GetComponent<Rigidbody2D>().velocity = dir * ballSpeed;
            } else if(controller.playerPosition == "Right") {
                float x = hitFactor(transform.position,
                    col.transform.position,
                    col.collider.bounds.size.y,
                    false);

                Vector2 dir = new Vector2(-1, x).normalized;

                GetComponent<Rigidbody2D>().velocity = dir * ballSpeed;
            } else if(controller.playerPosition == "Left") {
                float x = hitFactor(transform.position,
                    col.transform.position,
                    col.collider.bounds.size.y,
                    false);

                Vector2 dir = new Vector2(1, x).normalized;

                GetComponent<Rigidbody2D>().velocity = dir * ballSpeed;
            }
            //rigid2D.velocity += col.gameObject.GetComponent<Rigidbody2D>().velocity.normalized;
        }
    }
}
