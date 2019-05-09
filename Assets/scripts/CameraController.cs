using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;

    public Vector3 offset;

    public bool useOffset;
    public float rotateSpeed;

    public Transform pivot;

	// Use this for initialization
	void Start () {
        if (!useOffset)
        {
            offset = target.position - transform.position;
        }

        pivot.transform.position = target.transform.position;
        pivot.transform.parent = target.transform;

        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void LateUpdate () {

        //get the x position of the mouse &  rotate target
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.Rotate(0, horizontal, 0);

        //get Y position of the mouse and rotate pivot
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        pivot.Rotate(-vertical, 0, 0);

        if (pivot.rotation.eulerAngles.x > 60f && pivot.rotation.eulerAngles.x < 180f )
        {
            pivot.rotation = Quaternion.Euler(60f, 0, 0);
        }

        if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360f)
        {
            pivot.rotation = Quaternion.Euler(360f, 0, 0);
        }

        float desiredYAngle = target.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = target.position - (rotation * offset);


       // transform.position = target.position - offset;
        transform.LookAt(target);

        //if (transform.position.y < target.position.y)
        //{
         //   transform.position = new Vector3(transform.position.x, target.position.y - .5f, transform.position.z);
      //  }

	}
}
