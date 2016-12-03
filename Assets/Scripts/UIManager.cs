using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour {
    public GameObject playerOptionPanelPrefab;
    public Vector3 playerOptionStartPosition;
    public Vector3 offset;

    public Animator animMainPanel;
    public Animator animSingleplayerPanel;

    public Vector3[] startPositions2P;
    public Vector3[] startPositions4P;

    private GameObject pCount;
    private List<GameObject> playerOptionPanels = new List<GameObject>();

    public int currentPlayerAmount = 0;
	// Use this for initialization
	void Start () {
        pCount = GameObject.Find("PlayerCount");
        if(pCount.GetComponent<Dropdown>().value == 0) {
            InstantiatePlayerOptionPanel(2);
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    private void InstantiatePlayerOptionPanel(int amount) {
        currentPlayerAmount = 0;
        for(int i = 0; i < amount; i++) {
            GameObject temp = (GameObject)Instantiate(playerOptionPanelPrefab, playerOptionPanelPrefab.transform.position, Quaternion.identity);
            playerOptionPanels.Add(temp);
            temp.transform.parent = GameObject.Find("PlayerOptions").transform;
            currentPlayerAmount += 1;
        }
    }

    public void CheckPlayerCount() {
        foreach(GameObject temp in playerOptionPanels) {
            Destroy(temp);
        }
        if(pCount.GetComponent<Dropdown>().value == 0) {
            InstantiatePlayerOptionPanel(2);
        } else if(pCount.GetComponent<Dropdown>().value == 1) {
            InstantiatePlayerOptionPanel(4);
        } else if(pCount.GetComponent<Dropdown>().value == 2) {
            InstantiatePlayerOptionPanel(6);
        }

    }

    private Color CheckWhatColor(string ColorString) {
        switch(ColorString) {
            case "Blue":
                return Color.blue;
            case "Red":
                return Color.red;
            case "Yellow":
                return Color.yellow;
            case "Green":
                return Color.green;
            case "Orange":
                return Color.magenta;
            case "Brown":
                return Color.cyan;
        }
        return Color.black;
    }

    public void MainMenuSingleplayerButton() {
        animMainPanel.SetBool("SwipeLeft", true);
        animSingleplayerPanel.SetBool("SwipeLeft", true);
    }

    public void SingleplayerPanelBackButton() {
        animMainPanel.SetBool("SwipeLeft", false);
        animSingleplayerPanel.SetBool("SwipeLeft", false);
    }

    public void SingleplayerButton() {
        GameData gD = GameObject.Find("GameData").GetComponent<GameData>();
        gD.playerCount = currentPlayerAmount;
        GameObject playerOptionsPanel = GameObject.Find("PlayerOptions");
        for(int i = 0; i < playerOptionsPanel.transform.childCount; i++) {
            GameObject parent = playerOptionsPanel.transform.GetChild(i).gameObject;
            GameObject nameObject = parent.transform.GetChild(3).gameObject;
            Debug.LogError(nameObject.transform.name);
            gD.playerNames[i] = nameObject.GetComponent<InputField>().text;
            GameObject colorObject = parent.transform.GetChild(2).gameObject;
            gD.playerColors[i] = CheckWhatColor(colorObject.GetComponent<Dropdown>().captionText.text);
            
        }
        if(currentPlayerAmount == 2) {
            gD.startPositions = startPositions2P;
        } else if(currentPlayerAmount == 4) {
            gD.startPositions = startPositions4P;
        }
        Debug.LogError("LoadingNewScene");
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
