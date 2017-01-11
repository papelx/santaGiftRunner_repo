using UnityEngine;
using System.Collections;

public class ParticlesManager : MonoBehaviour
{

    private ParticleSystem pstCollectables;

    private bool isDead;

	// Use this for initialization
	void Start ()
	{
	    pstCollectables = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
    private void Update()
    {
        if (!pstCollectables.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}

