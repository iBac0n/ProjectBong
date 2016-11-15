using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public string playerName = "Default";
    public string playerAxis = "Horizontal";
    public bool isVerticalPlayer = false;
    public Color playerColor;
    public float playerSpeed;

    public int playerID = 0;


    private SpriteRenderer sRenderer;
    void Start() {
        sRenderer = this.GetComponent<SpriteRenderer>();
        sRenderer.color = playerColor;
        this.transform.name = playerName;
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
}
