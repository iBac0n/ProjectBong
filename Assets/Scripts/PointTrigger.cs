using UnityEngine;
using System.Collections;

public class PointTrigger : MonoBehaviour {

    public bool isTriggered = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col) {
        Debug.LogError("TriggerEnter");
        isTriggered = true;
    }
}
