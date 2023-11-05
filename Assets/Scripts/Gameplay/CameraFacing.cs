using NaughtyAttributes;
using UnityEngine;

public class CameraFacing : MonoBehaviour
{
    [SerializeField] private Camera _selectedCamera;

    private void LateUpdate()
    {
        Rotate();
    }
    [Button]
    private void Rotate()
    {
        transform.LookAt(transform.position + _selectedCamera.transform.forward);
    }

}
