using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public GameObject playerPrefab;
    public GameObject ballPrefab;
    public Vector3[] startPositions;
    public Color[] playerColors;
    public string[] playerNames;
    public int playerCount;

    private GameObject pointTop;
    private GameObject pointBottom;

    private int[] scoredPoints;
    // Use this for initialization
    void Start() {
        scoredPoints = new int[playerCount];
        pointTop = this.transform.GetChild(1).gameObject;
        pointBottom = this.transform.GetChild(0).gameObject;
        StartGame(playerCount);
    }

    // Update is called once per frame
    void Update() {
        if(pointTop.GetComponent<PointTrigger>().isTriggered == true) {
            Debug.LogError("WTF");
            PointScored(1);
            pointTop.GetComponent<PointTrigger>().isTriggered = false;
            pointBottom.GetComponent<PointTrigger>().isTriggered = false;
        }
        if(pointBottom.GetComponent<PointTrigger>().isTriggered == true) {
            Debug.LogError("WTF");
            PointScored(0);
            pointTop.GetComponent<PointTrigger>().isTriggered = false;
            pointBottom.GetComponent<PointTrigger>().isTriggered = false;
        }
    }

    public void PointScored(int playerID) {
        Debug.LogError("Funzt");
        scoredPoints[playerID] += 1;
        ResetGame();
    }

    public void ResetGame() {
        Debug.LogError("Resseting Game");
        Destroy(GameObject.FindGameObjectWithTag("Ball"));
        StartCoroutine(WaitForReset(2));
    }

    IEnumerator WaitForReset(int secs) {
        int count = 0;
        foreach(GameObject player in GameObject.FindGameObjectsWithTag("Player")) {
            player.GetComponent<PlayerController>().enabled = false;
            player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
        yield return new WaitForSeconds(secs);
        Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
        foreach(GameObject player in GameObject.FindGameObjectsWithTag("Player")) {
            player.transform.position = startPositions[count];
            player.GetComponent<PlayerController>().enabled = true;
            count++;
        }
    }

    public void StartGame(int playerNum) {
        for(int i = 0; i < playerNum; i++) {
            if(i == 0) {
                GameObject playerGO = (GameObject)Instantiate(playerPrefab, startPositions[i], Quaternion.identity);
                PlayerController playerScript = playerGO.GetComponent<PlayerController>();
                playerScript.playerAxis = "Horizontal";
                playerScript.playerID = 0;
                playerScript.playerColor = playerColors[i];
                playerScript.playerName = playerNames[i];
            } else if(i == 1) {
                GameObject playerGO = (GameObject)Instantiate(playerPrefab, startPositions[i], Quaternion.identity);
                PlayerController playerScript = playerGO.GetComponent<PlayerController>();
                playerScript.playerAxis = "Horizontal2";
                playerScript.playerID = 2;
                playerScript.playerColor = playerColors[i];
                playerScript.playerName = playerNames[i];
            } else if(i == 2) {
                GameObject playerGO = (GameObject)Instantiate(playerPrefab, startPositions[i], Quaternion.identity);
                PlayerController playerScript = playerGO.GetComponent<PlayerController>();
                playerScript.playerAxis = "Vertical";
                playerScript.playerID = 1;
                playerScript.playerColor = playerColors[i];
                playerScript.playerName = playerNames[i];
            } else if(i == 3) {
                GameObject playerGO = (GameObject)Instantiate(playerPrefab, startPositions[i], Quaternion.identity);
                PlayerController playerScript = playerGO.GetComponent<PlayerController>();
                playerScript.playerAxis = "Vertical2";
                playerScript.playerID = 3;
                playerScript.playerColor = playerColors[i];
                playerScript.playerName = playerNames[i];
            }

        }
    }
}
