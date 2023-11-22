using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToIngame : MonoBehaviour
{
    public void toingame() {
        SceneManager.LoadScene("Ingame");
    }
}
