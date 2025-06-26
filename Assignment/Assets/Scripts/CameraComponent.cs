using UnityEngine;

public class CameraComponent : MonoBehaviour
{
    [SerializeField] private Transform player;
    private float currentPoseX;
    private Vector3 velocity = Vector3.zero;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
