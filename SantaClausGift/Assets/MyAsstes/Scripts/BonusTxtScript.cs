using UnityEngine;
using System.Collections;

public class BonusTxtScript : MonoBehaviour
{
    public GameObject psBonus;

	// Use this for initialization
	void OnEnable ()
	{
        psBonus.SetActive(true);

	}
	
	// Update is called once per frame
	public void DisabledText ()
    {
	
        gameObject.SetActive(false);
        psBonus.SetActive(false);
	}
}
