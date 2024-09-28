using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private Transform targetDestination;
    [SerializeField] private float speed;
    [SerializeField] private float startTime;
    

    private float travelLength;
    private Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
        travelLength = Vector3.Distance(startPosition, targetDestination.position);
        startTime = Time.time;
    }

    void Update()
    {
        float timeElapsed = (Time.time - startTime) * speed;
        float fractionOfJourney = timeElapsed / travelLength;

        float x = Mathf.Lerp(startPosition.x, targetDestination.position.x, fractionOfJourney);
        float y = Mathf.Lerp(startPosition.y, targetDestination.position.y, fractionOfJourney);
        float z = Mathf.Lerp(startPosition.z, targetDestination.position.z, fractionOfJourney);

        float currentDistance = Vector3.Distance(transform.position, targetDestination.position);

        Debug.Log(speed + "");
        Debug.Log("Distance to target via lerping:" + currentDistance);
        transform.position = new Vector3(x, y, z);
    }
}
