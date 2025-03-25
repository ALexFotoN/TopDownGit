using UnityEngine;

public class ScreenBounds
{
    private static Camera _mainCamera;

    public static Vector2 GetScreenBounds()
    {
        _mainCamera ??= Camera.main;

        var screenAspect = (float)Screen.width / Screen.height;
        var cameraHeight = _mainCamera.orthographicSize * 2;
        return new Vector2(cameraHeight * screenAspect / 2, _mainCamera.orthographicSize);
    }
}