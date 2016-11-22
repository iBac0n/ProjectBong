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
            currentTypeToSpawn = GetRandomType();
            SpawnPopup(Random.Range(4, 6), currentTypeToSpawn, new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), 0));
            timeMark = Time.time + cooldown;
        }
    }

    public PopupTypes GetRandomType() {
        float randomNumber = Random.Range(0, 2);//TODO This has to be hardcoded !
        if(randomNumber == 0) {
            return PopupTypes.Gravity;
        } else if(randomNumber == 1) {
            return PopupTypes.Speed;
        }

        return PopupTypes.Speed;
    }

    public void ActivateEffect(PopupTypes type) {
        Debug.LogError("Activating");
        if(type == PopupTypes.Gravity) {
            //currentBall.GetComponent<BallScript>().circleColl2D.sharedMaterial.bounciness += 0.5f;
            StartCoroutine(DeactivateEffect(PopupTypes.Gravity, 6f));
        } else if(type == PopupTypes.Speed) {
            currentBall.GetComponent<BallScript>().ballSpeed += 5;
            StartCoroutine(DeactivateEffect(PopupTypes.Speed, 6f));
        }
    }

    public IEnumerator DeactivateEffect(PopupTypes type, float duration) {
        Debug.LogError("Waitin for Deactivating the effect");
        yield return new WaitForSeconds(duration);
        Debug.LogError("DeactivateEffect");
        if(type == PopupTypes.Gravity) {
            currentBall.GetComponent<BallScript>().circleColl2D.sharedMaterial.bounciness -= 0.5f;
        } else if(type == PopupTypes.Speed) {
            currentBall.GetComponent<BallScript>().ballSpeed -= 5;
        }
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
