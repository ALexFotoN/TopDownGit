using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    public GameObject playerPrefab;
    public InputListener inputListener;
    public MovementManager movementManager;

    private void Start()
    {
        // Создание модели
        var playerModel = new PlayerModel(100);

        // Инстанцирование игрока
        var playerObject = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        var playerView = playerObject.GetComponent<PlayerView>();

        // Инициализация контроллера
        var playerController = new PlayerController(playerModel, playerView);

        // Устанавливаем ссылку на PlayerController в PlayerView
        playerView.PlayerController = playerController;

        // Связывание MovementManager
        movementManager.Initialize(playerController, inputListener);
    }
}