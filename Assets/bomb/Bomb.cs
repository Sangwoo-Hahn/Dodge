using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField]
    private GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Explosion", 2f);
        Destroy(gameObject, 2.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Explosion()
    {
        int x = (int) transform.position.x / 2;
        int y = (int) transform.position.y / 2;
        Instantiate(explosion, transform.position, Quaternion.identity);
        Instantiate(explosion, new Vector3(2f * ((x+2) % 3 - 1), 2f * y, 0f), Quaternion.identity);
        Instantiate(explosion, new Vector3(2f * ((x+3) % 3 - 1), 2f * y, 0f), Quaternion.identity);
        Instantiate(explosion, new Vector3(2f * x, 2f * ((y+2) % 3 - 1), 0f), Quaternion.identity);
        Instantiate(explosion, new Vector3(2f * x, 2f * ((y+3) % 3 - 1), 0f), Quaternion.identity);
    }
}
