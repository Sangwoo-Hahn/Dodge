using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        
    }

    Queue<string> moveState = new Queue<string>();
    // [SerializeField]
    private float moveTime = 0.15f;
    private int[] position = {0, 0};
    private float step = 2f;
    private bool moving = false;

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
            // Debug.Log("UP");
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            moveState.Enqueue("DOWN");
        } else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            moveState.Enqueue("LEFT");
        } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            moveState.Enqueue("RIGHT");
            // Debug.Log("RIGHT");
        }
        // float verticalInput = Input.GetKeyDown("Vertical");
        // Vector3 moveTo = new Vector3(horizontalInput, verticalInput, 0f);
        // transform.position += moveTo * moveSpeed * Time.deltaTime;
        if (moving) {
            time_current = Time.time - time_start;
            t = time_current / (moveTime/(deltaCount+1));
            deltaPos = - (t-1)*(t-1)*(t-1)*(t-1)*Mathf.Cos(t*t*t*30);
            // Debug.Log(Time.time);
            // Debug.Log(position[0]);
            // Debug.Log(position[1]);
            // Debug.Log(moveState);
            if (time_current > moveTime/(deltaCount+1)) {
                moving = false;
                delta = time_current - moveTime/(deltaCount+1);
                deltaCount = moveState.Count;
            }
            if (direction == "UP") {
                transform.position = new Vector3((float)position[0]*step, (((float)position[1] + deltaPos - 4.5f) % 3 + 1.5f)*step, 0f);
            } else if (direction == "DOWN") {
                transform.position = new Vector3((float)position[0]*step, (((float)position[1] - deltaPos + 4.5f) % 3 - 1.5f)*step, 0f);
            } else if (direction == "LEFT") {
                transform.position = new Vector3((((float)position[0] - deltaPos + 4.5f) % 3 - 1.5f)*step, (float)position[1]*step, 0f);
            } else if (direction == "RIGHT") {
                transform.position = new Vector3((((float)position[0] + deltaPos - 4.5f) % 3 + 1.5f)*step, (float)position[1]*step, 0f);
            }
        } else {
            transform.position = new Vector3((float)position[0]*step, (float)position[1]*step, 0f);
            if (moveState.Count > 0) {
                moving = true;
                time_start = Time.time - Time.deltaTime - delta;
                direction = moveState.Dequeue();
                if (direction == "UP") {
                    position[1] += 1;
                } else if (direction == "DOWN") {
                    position[1] -= 1;
                } else if (direction == "LEFT") {
                    position[0] -= 1;
                } else if (direction == "RIGHT") {
                    position[0] += 1;
                }
                position[0] = (position[0]+4)%3-1;
                position[1] = (position[1]+4)%3-1;
            }
        }
    }
}
