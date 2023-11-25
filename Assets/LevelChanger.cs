using System;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using JetBrains.Annotations;
using UnityEditor.SceneManagement;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    public StartCursor startCursor;
    public StageCursor stageCursor;
    private string InputKey;
    private bool InputDetect = false;
    private string scenename;

    void Start() {
        startCursor.position = 0;
    }

    void Update() {
        if (InputDetect == false && Input.GetKeyDown(KeyCode.Space)) {
            animator.SetTrigger("FadeOut");
            InputKey = "Space";
            InputDetect = true;
        }
        else if (InputDetect == false && Input.GetKeyDown(KeyCode.Backspace)) {
            animator.SetTrigger("FadeOut");
            InputKey = "Backspace";
            InputDetect = true;
        }
    }

    public void OnFadeComplete() {
        scenename = SceneManager.GetActiveScene().name;
        if (InputKey == "Space") {
            if (scenename == "Lobby" && startCursor.position == 0) {
                SceneManager.LoadScene("Stages");
            }
            else if (scenename == "Stages") {
                if (stageCursor.position == 0) {
                    SceneManager.LoadScene("Stage_1");
                }
                else if (stageCursor.position == -1) {
                    SceneManager.LoadScene("Stage_2");
                }
                else if (stageCursor.position == -2) {
                    SceneManager.LoadScene("Stage_3");
                }
            }
        }
        else if (InputKey == "Backspace") {
            if (scenename == "Stages") {
                SceneManager.LoadScene("Lobby");
            }
            else if (scenename == "Stage_1" || scenename == "Stage_2" || scenename == "Stage_3") {
                SceneManager.LoadScene("Stages");
            }
        }
        InputDetect = false;
    }
}