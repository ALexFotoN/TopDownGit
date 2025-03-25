using UnityEngine;

public class InputListener : MonoBehaviour
{
    public static Vector2 GetMovementInput()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        return new Vector2(horizontal, vertical);
    }
}