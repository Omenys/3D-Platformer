using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    [SerializeField] PlayerStats stats;
    [SerializeField] Image bar;
    TMP_Text scoreText;


    // Start is called before the first frame update
    void Start()
    {
        scoreText = FindObjectOfType<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update UI based on stats
        bar.fillAmount = stats.currentHealth / stats.maxHealth;
        scoreText.text = stats.currentScore.ToString();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Title");
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
