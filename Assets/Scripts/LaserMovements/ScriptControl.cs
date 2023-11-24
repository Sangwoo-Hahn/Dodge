using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptControl : MonoBehaviour
{
    private Vector3 m_Position_Default;
    public lasermove1 script1;
    public lasermove2 script2;

    void Start()
    {
        //Invoke("StartScript2", 0.0f);
        StartScript1();

        Invoke("StartScript2", 4.0f);

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
