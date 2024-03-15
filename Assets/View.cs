using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    [SerializeField] PlayerStats stats;
    [SerializeField] Image bar;
    [SerializeField] Text score;

    // Update points

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = stats.currentHealth / stats.maxHealth;

    }
}
