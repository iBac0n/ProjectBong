using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public string playerName = "Default";
    public string playerAxis = "Horizontal";
    public bool isVerticalPlayer = false;
    public Color playerColor;
    public float playerSpeed;
    public string playerPosition = "";
    public int playerID = 0;

    private Animator anim;
    private SpriteRenderer sRenderer;
    void Start() {
        //anim = this.transform.GetChild(0).GetComponent<Animator>();
        sRenderer = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
        sRenderer.color = playerColor;
        this.transform.name = playerName;

        if(this.transform.position.y > 0 && isVerticalPlayer == false) {
            playerPosition = "Top";
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            Debug.LogError(this.GetComponent<Rigidbody2D>().constraints);
        } else if(this.transform.position.y < 0 && isVerticalPlayer == false) {
            playerPosition = "Bottom";
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        } else if(this.transform.position.x > 0) {
            playerPosition = "Right";
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        } else if(this.transform.position.x < 0) {
            playerPosition = "Left";
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
        //anim.SetInteger("PlayerID", playerID);
    }


    void Update() {
        GetMovement();
    }

    void GetMovement() {
        float _x = 0;
        float _y = 0;
        if(!isVerticalPlayer) {
            _x = Input.GetAxisRaw(playerAxis);
        }
        if(isVerticalPlayer) {
            _y = Input.GetAxisRaw(playerAxis);
        }

        Vector2 velocity = new Vector3(_x, _y).normalized;

        this.GetComponent<Rigidbody2D>().velocity = velocity * playerSpeed;
    }

    void OnCollisionEnter2D(Collision2D col) {
        if(col.transform.name == "Ball") {
            //anim.SetTrigger("isHit");
        }
    }

}
