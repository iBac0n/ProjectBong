using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour {
    public int playerCount;
    public string[] playerNames;
    public Color[] playerColors;

    void Awake() {
        playerNames = new string[6];
        playerColors = new Color[6];
        Object.DontDestroyOnLoad(this);
    }

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
