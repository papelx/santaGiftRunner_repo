using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    public void GoToLevel (string level)
    {
	    switch (level)
	    {
            case"Gameplay":
                Application.LoadLevel(level);
                break;
        }
	
	}
}
