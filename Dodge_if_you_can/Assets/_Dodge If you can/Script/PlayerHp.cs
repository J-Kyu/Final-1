using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour {
    public float playerLastingTime=0.0f;
    [SerializeField]//private can be seen in inspector
    private int hp = 10;
    public int score=0;
    public Text hpText;
    public Text scoreText;
    public Text timeText;
    public int copyHp;
    public Move move;
    public ButtonController BT;
    public GameObject endGame;
    public GameObject FinalScore;
   

    public int CopyHp()
    {
        copyHp = hp;
        return copyHp;
    }
  
    public void ScoreUp()
    {
        if (hp != 0)
        {
            score += 3;
            scoreText.text = score.ToString();
        }
        else score = 0;
    }
    public void HealHp(int amount)
    {
        ScoreUp();
        hp += amount;
        UpdateHp();
    }
    public void DamageHp(int amount)
    {   
        hp-= amount;
        UpdateHp();
    }
    private void UpdateHp()
    {
        hpText.text = hp.ToString();
       
    }

	// Use this for initialization
	void Start () {
        endGame.SetActive(false);
        FinalScore.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        timeText.text = playerLastingTime.ToString();
        playerLastingTime += Time.deltaTime;
		 hpText.text = hp.ToString();
        if (hp <= 0)
        {
            move.acel = 0.0f;
            hp = 0;

            EndGame();
            BT.AddNumber();
        }

       
        
            
   

        if (playerLastingTime> 5.0f)
        {
            ScoreUp();
            hp++;
            playerLastingTime=0;
        }

    

    }
    public void EndGame()
        {
           endGame.SetActive(true);
        FinalScore.SetActive(true);
    }




}
