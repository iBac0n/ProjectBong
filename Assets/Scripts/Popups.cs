using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CircleCollider2D))]
public class Popups : MonoBehaviour {

    public PopupTypes pType;
    public PopupManager pManager;

    public float pDuration;
    private bool pSpawned = false;
    private float timeMark = 0f; 
    void Start() {
        pSpawned = true;
        timeMark = Time.time + pDuration;
    }

    void Update() {
        if(pSpawned) {
            if(Time.time > timeMark) {
                GameObject.Destroy(this.gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.transform.tag == "Ball") {
            pManager.ActivateEffect(pType);
            GameObject.Destroy(this.gameObject);
        }
    }
}
