using UnityEngine;
using System.Collections;

public class BallVisual : MonoBehaviour {

    private Rigidbody2D rigid;

	void Start () {
        rigid = this.GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        Vector3 velNorm = rigid.velocity.normalized;
        this.transform.localScale = velNorm;
	}
}
