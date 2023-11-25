using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptControl : MonoBehaviour
{
    private Vector3 m_Position_Default;
    public lasermove1 script1;
    public lasermove2 script2;
    [SerializeField] private float time1 = 0.0f;
    [SerializeField] private float time2 = 3.0f;

    void Start()
    {
        Invoke("StartScript1", time1);

        Invoke("StartScript2", time2);

    }

    void StartScript1()
    {
        script1.Move();
    }
    void StartScript2()
    {
        script2.Move();
    }

    void Update()
    {

    }
}
