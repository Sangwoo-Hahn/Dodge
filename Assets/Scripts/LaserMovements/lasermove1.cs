using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lasermove1 : MonoBehaviour
{
    private Vector3 m_Position_Default;
    [SerializeField] protected Vector3 m_Position_End = new Vector3(6.0f, 0.0f, 0.0f);
    [SerializeField] protected float m_RunTime = 1.0f;

    private void Awake()
    {
        m_Position_Default = transform.position;
    }

    /*
    private void OnEnable()
    {
        StartCoroutine(Run(m_RunTime));
    }
    */

    IEnumerator Run(float duration)
    {
        var runTime = 0.0f;

        while (runTime < duration)
        {
            runTime += Time.deltaTime;

            transform.position = Vector3.Lerp(m_Position_Default, m_Position_End, runTime / duration);
            
            yield return null;
        }
    }

    public void Move()
    {
        m_Position_Default = transform.position;
        StartCoroutine(Run(1));
    }
}
