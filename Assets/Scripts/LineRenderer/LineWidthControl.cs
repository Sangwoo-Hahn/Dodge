using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineWidthControl : MonoBehaviour
{
    // Start is called before the first frame update
    public LineWidthChange1 script1;
    public LineWidthChange2 script2;
    [SerializeField] private float time1 = 1.5f;
    [SerializeField] private float time2 = 2.0f;
    void Start()
    {
        Invoke("StartScript1", time1);

        Invoke("StartScript2", time2);

    }

    void StartScript1()
    {
        script1.Change();
    }
    void StartScript2()
    {
        script2.Change();
    }

    void Update()
    {

    }
}
