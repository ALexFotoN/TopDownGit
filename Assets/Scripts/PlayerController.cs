using UnityEngine;

public class PlayerController
{
    private readonly PlayerModel _model;
    private readonly PlayerView _view;

    public PlayerController(PlayerModel model, PlayerView view)
    {
        _model = model;
        _view = view;

        _model.OnHealthChange += OnHealthChanged;
        _model.OnPlayerDeath += OnPlayerDeath;
    }

    private void OnHealthChanged(int currentHealth)
    {
        _view.UpdateHealthText(currentHealth, _model.MaxHealth);
        Debug.Log($"Health changed: {currentHealth}");
        var color = currentHealth > 0 ? Color.white : Color.red;
        _view.UpdatePlayerVisual(color);
    }

    private void OnPlayerDeath()
    {
        Debug.Log("Player is dead.");
    }
    
    public void Move(Vector2 direction)
    {
        if (_view is null) return;
        // Рассчитываем новую позицию
        var move = new Vector3(direction.x, direction.y, 0) * (_model.moveSpeed * Time.deltaTime);
        var newPosition = _view.transform.position + move;

        // Ограничиваем новую позицию в пределах границ экрана
        var bounds = ScreenBounds.GetScreenBounds();
        newPosition.x = Mathf.Clamp(newPosition.x, -bounds.x, bounds.x);
        newPosition.y = Mathf.Clamp(newPosition.y, -bounds.y, bounds.y);

        // Применяем новую позицию
        _view.transform.position = newPosition;
    }
    
    public void TakeDamage(int damage)
    {
        _model.ChangeHealth(-damage);
    }

}