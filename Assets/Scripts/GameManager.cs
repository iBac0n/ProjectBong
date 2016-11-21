using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public GameObject playerPrefab;
    public Vector3[] startPositions;
    public Color[] playerColors;
    public string[] playerNames;
    public int playerCount;
    // Use this for initialization
    void Start() {
        StartGame(playerCount);
    }

    // Update is called once per frame
    void Update() {

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
