using UnityEngine;

[CreateAssetMenu(menuName = "Player Stats")]
public class PlayerStats : ScriptableObject
{
    public float maxHealth = 5.0f;
    public float currentHealth = 5.0f;
    public float maxScore = 10.0f;
    public float currentScore = 0f;
    public void defaultStats()
    {
        maxHealth = 5.0f;
        currentHealth = 5.0f;
        maxScore = 10.0f;
        currentScore = 0.0f;
    }
}



