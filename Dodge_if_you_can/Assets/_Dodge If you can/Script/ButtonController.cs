using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {
    public AudioSource audioSource;
    public GameObject hpPanel;
    public Text addNumberButtonText; //누르면 숫자가 증가하는 버튼 Text
    public PlayerHp playerHp;

    public void OpenMainScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void BackToSplashScene()
    {
        SceneManager.LoadScene("Splash");
    }

    public void PlaySound()
    {
        audioSource.Play();
       // Debug.LogFormat("wow");
    }

    public void ToggleHpPanel()         ///*in a simple way:*/ hpPanel.SetActive(hpPanel.activeSelf==false);
    {
        if (hpPanel.activeSelf)
        {
            hpPanel.SetActive(false);
        }
        else
        {
            hpPanel.SetActive(true);
        }
    }

    


   

    public void AddNumber()
    {
        var playerHighestHp = PlayerPrefs.GetInt("PLAYER_HIGHEST_HP", 0);
       
        
        addNumberButtonText.text = (playerHp.score).ToString();
        RecordSetSave(GetHighestHp());

    }

    public int GetHighestHp()
    {
        return PlayerPrefs.GetInt("PLAYER_HIGHEST_HP", 0);
    }
    public void RecordSetSave(int score)
    {
        PlayerPrefs.SetInt("PLAYER_HIGHEST_HP", score);
        PlayerPrefs.Save();
    }


   
}
