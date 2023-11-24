using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineWidthControl : MonoBehaviour
{
    // Start is called before the first frame update
    public LineWidthChange1 script1;
    public LineWidthChange2 script2;

    void Start()
    {
        Invoke("StartScript1", 1.0f);

        Invoke("StartScript2", 2.0f);

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
