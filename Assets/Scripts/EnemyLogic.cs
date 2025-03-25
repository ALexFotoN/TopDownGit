using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public int damage = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверяем, есть ли у объекта PlayerView
        if (!collision.gameObject.TryGetComponent(out PlayerView playerView)) return;
        // Наносим урон через PlayerController
        if (playerView.PlayerController == null) return;
        playerView.PlayerController.TakeDamage(damage);
        Debug.Log($"Player took {damage} damage!");
    }
}