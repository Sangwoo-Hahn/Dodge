using System;
using System.Xml.Serialization;
using JetBrains.Annotations;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    public StartCursor startCursor;

    void Start() {
        startCursor.position = 0;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            animator.SetTrigger("FadeOut");
        }
    }

    public void OnFadeComplete() {
        if (SceneManager.GetActiveScene().name == "Lobby" && startCursor.position == 0) {
            SceneManager.LoadScene("Ingame");
        }
    }
}