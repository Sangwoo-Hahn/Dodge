using System;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using JetBrains.Annotations;
using UnityEditor.SceneManagement;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    public StartCursor startCursor;
    public StageCursor stageCursor;

    private string InputKey;
    [SerializeField]
    private bool InputDetect = false;
    private string scenename;

    void Start() {
        startCursor.position = 0;
    }

    void Update() {
        if (InputDetect == false && Input.GetKeyDown(KeyCode.Space)) {
            InputDetect = true;
            InputKey = "Space";
            animator.SetTrigger("FadeOut");
        }
        else if (InputDetect == false && Input.GetKeyDown(KeyCode.Backspace)) {
            InputDetect = true;
            InputKey = "Backspace";
            animator.SetTrigger("FadeOut");
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
    }
}