using UnityEngine;

[CreateAssetMenu(menuName = "Player Stats")]
public class PlayerStats : ScriptableObject
{
    public int maxHealth = 10;
    public int currentHealth = 10;
    public int maxScore = 15;
    public int currentScore = 0;

}


