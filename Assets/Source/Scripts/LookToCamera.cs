using UnityEngine;

public class LookToCamera : MonoBehaviour
{
    private Transform _camera;

    private void Start()
    {
        _camera = Camera.main.transform;
    }

    private void Update()
    {
        transform.rotation = _camera.rotation;
    }
}
