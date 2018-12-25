using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour {

    public Vector3 mouseLocation;
    public Camera camera;
    Vector3 newLocation;

    public float moveSpeed = 0.0f;

    enum Strafe
    {
        LEFT,
        RIGHT
    };

    private void Start()
    {
        newLocation = this.transform.position;

    }



    private void FixedUpdate()
    {
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
            {
                //Vector2 touchPosition = Input.touches[0].position;
                Vector2 touchPosition = touch.position;

                Vector3 touchWorldPosition = camera.ScreenToWorldPoint(new Vector3(touchPosition.x,
                touchPosition.y + 60.0f,
                0.0f + 10.0f));

                float distance = Vector3.Distance(newLocation, touchWorldPosition);
                if(distance > 3){

                    Strafe direction;
                    if(newLocation.x > touchWorldPosition.x){
                        direction = Strafe.LEFT;
                    }else{
                        direction = Strafe.RIGHT;
                    }

                    newLocation = this.transform.position;
                    strafe(newLocation, touchWorldPosition, direction);


                    Debug.Log("Strafe");
                    //this.transform.position = touchWorldPosition;
                }else{
                    this.transform.position = touchWorldPosition;
                }
            }

            if(touch.phase == TouchPhase.Ended){
                newLocation = this.transform.position;
            }
                
        }

    }

    void strafe(Vector3 from, Vector3 to, Strafe direction){
        //this.transform.position = to;
        float step = moveSpeed * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(from, to, step);
    }

}
