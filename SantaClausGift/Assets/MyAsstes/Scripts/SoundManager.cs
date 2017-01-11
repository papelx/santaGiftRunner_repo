using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{

    public  AudioSource managerSrc;
    public AudioSource musicManager;
    public  AudioClip collectClip;
    private AudioClip loseJingle;
    private AudioClip winJingle;
    private AudioClip gameplayJingle;

	// Use this for initialization
	void Start ()
	{
	    //managerSrc = gameObject.AddComponent<AudioSource>();
        loseJingle = Resources.Load("lose_jingle") as AudioClip;
        winJingle = Resources.Load("win_jingle") as AudioClip;
        loseJingle = Resources.Load("gameplay_jingle") as AudioClip;
	    musicManager.clip = gameplayJingle;
        musicManager.Play();
    }
	

	public void SetSound (string soundName)
    {
	    switch (soundName)
	    {
            case "Collect1":
                //managerSrc.clip = Resources.Load(soundName) as AudioClip;
                managerSrc.PlayOneShot(collectClip, 7F);
                break;
            case "Lose":
               
	            musicManager.clip = loseJingle;
                musicManager.PlayOneShot(loseJingle, 7F);
                break;
            case "Win":
                musicManager.clip = winJingle;
                musicManager.PlayOneShot(winJingle, 7F);
                break;
	    }
	}
}
