using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform Camera;

    private void Update() 
    {
        transform.position = Camera.position;
    }
}
