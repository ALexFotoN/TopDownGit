using UnityEngine;

public class MovementManager : MonoBehaviour
{
    private PlayerController _controller;
    private InputListener _inputListener;

    public void Initialize(PlayerController controller, InputListener inputListener)
    {
        _controller = controller;
        _inputListener = inputListener;
    }

    private void Update()
    {
        var input = InputListener.GetMovementInput();
        _controller.Move(input);
    }
}