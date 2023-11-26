using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    Queue<string> moveState = new Queue<string>();
    // [SerializeField]
    private float moveTime = 0.02f;
    public int position = 0;
    private float step = 0.9f;
    private bool moving = false;
    private bool fading = false;

    private float y = 0f;

    private float time_start;
    private float time_current;
    private float delta = 0f;
    private int deltaCount = 0;
    private string direction;
    private float t;
    private float deltaPos;

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            moveState.Enqueue("UP");
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            moveState.Enqueue("DOWN");
        } else if (Input.GetKeyDown(KeyCode.Space)) {
            moveState.Enqueue("SPACE");
        }
        // float verticalInput = Input.GetKeyDown("Vertical");
        // Vector3 moveTo = new Vector3(horizontalInput, verticalInput, 0f);
        // transform.position += moveTo * moveSpeed * Time.deltaTime;
        if (!fading) {
            if (moving) {
                y = y + (position*step-y)*Time.deltaTime/moveTime;
                if (position*step-y > -0.01f && position*step-y < 0.01f) {
                    moving = false;
                    delta = time_current - moveTime/(deltaCount+1);
                    deltaCount = moveState.Count;
                }
                if (direction == "UP") {
                    transform.position = new Vector3(-3f, y-1.4f, 0f);
                } else if (direction == "DOWN") {
                    transform.position = new Vector3(-3f, y-1.4f, 0f);
                }
            } else {
                transform.position = new Vector3(-3f, (float)position*step-1.4f, 0f);
                if (moveState.Count > 0) {
                    moving = true;
                    direction = moveState.Dequeue();
                    if (direction == "UP") {
                        position += 1;
                    } else if (direction == "DOWN") {
                        position -= 1;
                    } else if (direction == "SPACE") {
                        if (position == 0){
                            fading = true;
                            LevelChanger.instance.NextLevel("Stages");
                        }
                    }
                    position = (position+5)%3-2;
                    //AudioManager.instance.PlaySfx(AudioManager.Sfx.Move);
                }
            }
        }
    }
}
