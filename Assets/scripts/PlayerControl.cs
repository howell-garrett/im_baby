using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float moveSpeed;
    public float moveHandicap;
    public float jumpForce;
    public CharacterController controller;

    private Vector3 moveDirection;
    public float gravityScale;

    public int totalJumps;
    private int remainingJumps;






    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
        remainingJumps = totalJumps;

}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        { moveSpeed = moveSpeed + 20; }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        { moveSpeed = moveSpeed - 20; }

            float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + transform.right * Input.GetAxisRaw("Horizontal");
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;
        if (controller.isGrounded)
        {
            remainingJumps = totalJumps;
            moveDirection.y = 0f;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (!controller.isGrounded)
                
            { remainingJumps--; }
                if (remainingJumps > 0)
            {
                jump();
                 
            }
        }
        //Debug.Log(controller.isGrounded);




 







        moveDirection.y = moveDirection.y +  Physics.gravity.y * gravityScale/100;
        controller.Move(moveDirection  * Time.deltaTime);
    }

    void jump()
    {
        moveDirection.y = jumpForce;
    }

    
}
