using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public Transform prefab;
    public Transform startMarker;
    public Transform endMarker;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;

    public float camMoveSpeed = 5.0f;
    void Start()
    {
        //transform.position = new Vector3(0,2,0);
    }

    void Update()
    {
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * camMoveSpeed);

        if (Input.GetKeyDown("e"))
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            prefab.transform.position = Vector3.Slerp(startMarker.position, endMarker.position, fracJourney);
        }
    }
}