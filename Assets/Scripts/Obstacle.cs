using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(100f, 100f, 0);
    }

    public float time = 0f;
    [SerializeField] private float startTime = 3f;
    [SerializeField] private float endTime = 6f;
    [SerializeField] private float[] startPos = {-20f, 0f};
    [SerializeField] private float[] endPos = {20f, 0f};
    private float t;

    // Update is called once per frame
    void Update()
    {
        time = Time.time;
        if (time > startTime && time < endTime) {
            t = (time-startTime)/(endTime-startTime);
            transform.position = new Vector3(startPos[0]*(1-t)+endPos[0]*t, startPos[1]*(1-t)+endPos[1]*t, 0);
        }
    }
}
