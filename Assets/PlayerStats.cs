using UnityEngine;

[CreateAssetMenu(menuName = "Player Stats")]
public class PlayerStats : ScriptableObject
{
    public int maxHealth = 0;
    public int currentHealth = 0;
    public int maxScore = 0;
    public int currentScore = 0;
    public void defaultStats()
    {
        maxHealth = 5;
        currentHealth = 5;
        maxScore = 10;
        currentScore = 0;
    }
}



