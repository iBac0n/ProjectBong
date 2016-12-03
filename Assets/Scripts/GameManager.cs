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
    private GameObject pointLeft;
    private GameObject pointRight;

    private int[] scoredPoints;

    private GameData gD;
    // Use this for initialization
    void Start() {
        gD = GameObject.Find("GameData").GetComponent<GameData>();
        playerColors = gD.playerColors;
        playerNames = gD.playerNames;
        startPositions = gD.startPositions;
        playerCount = gD.playerCount;
        //playerCount = gD.playerCount;
        scoredPoints = new int[playerCount];
        GetPointTrigger();
        Debug.LogError("Start");
        StartGame(playerCount);
        ResetGame();
    }

    // Update is called once per frame
    void Update() {
        if(playerCount == 2) {
            if(pointTop.GetComponent<PointTrigger>().isTriggered == true) {
                PointScored(1);
                pointTop.GetComponent<PointTrigger>().isTriggered = false;
                pointBottom.GetComponent<PointTrigger>().isTriggered = false;
            }
            if(pointBottom.GetComponent<PointTrigger>().isTriggered == true) {
                PointScored(0);
                pointTop.GetComponent<PointTrigger>().isTriggered = false;
                pointBottom.GetComponent<PointTrigger>().isTriggered = false;
            }
        }

        if(playerCount == 4) {
            if(pointTop.GetComponent<PointTrigger>().isTriggered == true) {
                PointScored(1);
                pointTop.GetComponent<PointTrigger>().isTriggered = false;
                pointBottom.GetComponent<PointTrigger>().isTriggered = false;
                pointLeft.GetComponent<PointTrigger>().isTriggered = false;
                pointRight.GetComponent<PointTrigger>().isTriggered = false;
            }
            if(pointBottom.GetComponent<PointTrigger>().isTriggered == true) {
                PointScored(0);
                pointTop.GetComponent<PointTrigger>().isTriggered = false;
                pointBottom.GetComponent<PointTrigger>().isTriggered = false;
                pointLeft.GetComponent<PointTrigger>().isTriggered = false;
                pointRight.GetComponent<PointTrigger>().isTriggered = false;
            }
            if(pointLeft.GetComponent<PointTrigger>().isTriggered == true) {
                PointScored(3);
                pointTop.GetComponent<PointTrigger>().isTriggered = false;
                pointBottom.GetComponent<PointTrigger>().isTriggered = false;
                pointLeft.GetComponent<PointTrigger>().isTriggered = false;
                pointRight.GetComponent<PointTrigger>().isTriggered = false;
            }
            if(pointRight.GetComponent<PointTrigger>().isTriggered == true) {
                PointScored(2);
                pointTop.GetComponent<PointTrigger>().isTriggered = false;
                pointBottom.GetComponent<PointTrigger>().isTriggered = false;
                pointLeft.GetComponent<PointTrigger>().isTriggered = false;
                pointRight.GetComponent<PointTrigger>().isTriggered = false;
            }
        }
    }

    public void GetPointTrigger() {
        if(playerCount == 2) {
            pointTop = GameObject.Find("Map").transform.GetChild(5).gameObject;
            pointBottom = GameObject.Find("Map").transform.GetChild(6).gameObject;
        } else if(playerCount == 4) {
            pointTop = GameObject.Find("Map4P").transform.GetChild(8).gameObject;
            pointBottom = GameObject.Find("Map4P").transform.GetChild(9).gameObject;
            pointLeft = GameObject.Find("Map4P").transform.GetChild(10).gameObject;
            pointRight = GameObject.Find("Map4P").transform.GetChild(11).gameObject;
        }
    }

    public void PointScored(int playerID) {
        Debug.LogError("Funzt");
        if(playerCount == 2) {
            scoredPoints[playerID] += 1;
        } else if(playerCount == 4) {
            scoredPoints[playerID] -= 1;
        }
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
        //if(playerNum == 2) {
        //    Camera.main.orthographicSize = 7;
        //} else if(playerNum == 4) {
        //    Camera.main.orthographicSize = 10;
        //}
        if(playerNum == 2) {
            GameObject.Find("Map4P").SetActive(false);
        } else if(playerNum == 4) {
            GameObject.Find("Map").SetActive(false);
        }

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
                GameObject playerGO = (GameObject)Instantiate(playerPrefab, startPositions[i], Quaternion.Euler(0, 0, 90));
                PlayerController playerScript = playerGO.GetComponent<PlayerController>();
                playerScript.playerAxis = "Vertical";
                playerScript.isVerticalPlayer = true;
                playerScript.playerID = 1;
                playerScript.playerColor = playerColors[i];
                playerScript.playerName = playerNames[i];
            } else if(i == 3) {
                GameObject playerGO = (GameObject)Instantiate(playerPrefab, startPositions[i], Quaternion.Euler(0,0,90));
                PlayerController playerScript = playerGO.GetComponent<PlayerController>();
                playerScript.playerAxis = "Vertical2";
                playerScript.isVerticalPlayer = true;
                playerScript.playerID = 3;
                playerScript.playerColor = playerColors[i];
                playerScript.playerName = playerNames[i];
            }

        }
    }
}
