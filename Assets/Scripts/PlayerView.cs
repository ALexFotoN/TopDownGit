using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public UnityEngine.UI.Text healthText;

    [HideInInspector] public PlayerController PlayerController;

    public void UpdateHealthText(int currentHealth, int maxHealth)
    {
        if (healthText != null)
            healthText.text = $"{currentHealth} / {maxHealth}";
    }

    public void UpdatePlayerVisual(Color color)
    {
        if (spriteRenderer != null)
            spriteRenderer.color = color;
    }
}