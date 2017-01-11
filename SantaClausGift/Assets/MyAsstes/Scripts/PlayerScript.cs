using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerScript : MonoBehaviour{

    public static float _speed;
    public float speed;

    private Vector3 dir;

    public GameObject collectPs;

    private bool isDead;

    public GameObject resetBtn;

    public int score = 0;

    public Text ScoreText;
    public Text currentScoreText;
    public Text bestScoreText;

    public GameObject bonusTxt;
    public SoundManager managerSound;
    public GameManager gameManager;
    public Transform _playerGO;
    private Animator anim;

    public float lookSpeed = 10;
    private Vector3 curLoc;
    private Vector3 prevLoc;
    
    // Use this for initialization
    private void Start()
    {
        isDead = false;
        dir = Vector3.zero;
        anim = GetComponent<Animator>();
        anim.SetBool("run", false);
        anim.SetBool("falldown", false);
        gameObject.GetComponent<GameManager>();

    }
	
	// Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            score ++;
            ScoreText.text = score.ToString();
            anim.SetBool("falldown", false);
            anim.SetBool("run", true);
            if (dir == Vector3.forward)
            {
                dir = Vector3.left;


                //gameObject.transform.rotation = Quaternion.Lerp(transform.rotation,
                //    Quaternion.LookRotation(transform.position - dir), -10);

                     print(dir);

            }
            else
            {
                dir = Vector3.forward;

                //gameObject.transform.rotation = Quaternion.Lerp(transform.rotation,
                //  Quaternion.LookRotation(dir + transform.position), 10 );
                  print(dir);
            }
        }

        float amoutToMove = speed *Time.deltaTime;

        transform.Translate(dir*amoutToMove);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CollectBox" || other.tag == "CollectStar")
        {
            other.gameObject.SetActive(false);
            Instantiate(collectPs, transform.position, Quaternion.identity);

            managerSound.SetSound("Collect1");
            bonusTxt.SetActive(true);
            score += 3;
            ScoreText.text = score.ToString();

            if (other.tag == "CollectBox")
            {
                gameManager.boxCntTxt.text = GameManager.boxCnt++.ToString();
            }

            if (other.tag == "CollectStar")
            {
                gameManager.starCntTxt.text = GameManager.starCnt++.ToString();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Tile")
        {
            RaycastHit hit;

            Ray downRay = new Ray(transform.position, Vector3.down);

            if (Physics.Raycast(downRay, out hit))
            {
                //Kill Player!
                //isDead = true;
                //anim.SetBool("falldown", true);
                //anim.SetBool("run", false);
                if (transform.childCount > 0)
                {
                    //transform.GetChild(0).transform.parent = null;
                }
               // gameManager.SceneManager("GameOver");
                // resetBtn.SetActive(true);
            }
        }
    }
}
