using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class BombGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject bomb;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("BombGenerate", 3f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BombGenerate() {
        Instantiate(bomb, new Vector3(Random.Range(-1, 2) * 2.0f, Random.Range(-1, 2) * 2.0f, 0), Quaternion.identity);
    }
}
