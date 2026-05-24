using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float minX = -1.2f;
    public float maxX = 41.6f;

    void LateUpdate()
    {
        float x = Mathf.Clamp(player.position.x, minX, maxX);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
