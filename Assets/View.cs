using TMPro;
using UnityEngine;
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
        bar.fillAmount = stats.currentHealth / stats.maxHealth;
        scoreText.text = stats.currentScore.ToString();
    }

}
