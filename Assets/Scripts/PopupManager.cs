using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum PopupTypes {
    Gravity,
    Speed
}

public class PopupManager : MonoBehaviour {
    public GameObject popupPrefab;
    public GameObject currentBall;
    public float cooldown;
    public List<Popups> currentPopups = new List<Popups>();

    private PopupTypes currentTypeToSpawn;
    private float timeMark = 0f;
    void Start() {

    }


    void Update() {
        if(Time.time > timeMark) {
            Debug.LogError("Trying to spawn a popup!");
            SpawnPopup(Random.Range(3, 5), currentTypeToSpawn, new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), 0));
            timeMark = Time.time + cooldown;
        }
    }

    public void ActivateEffect(PopupTypes type) {
        Debug.LogError("Activating");
    }

    public bool SpawnPopup(float duration, PopupTypes type, Vector3 spawnPosition) {
        GameObject popupGO = (GameObject)GameObject.Instantiate(popupPrefab, spawnPosition, Quaternion.identity);
        if(popupGO == null) {
            Debug.LogError("Failed to spawn Popup");
            return false;
        }
        Popups popupScript = popupGO.GetComponent<Popups>();
        popupScript.pDuration = duration;
        popupScript.pManager = this;
        popupScript.pType = type;
        return true;
    }
}
