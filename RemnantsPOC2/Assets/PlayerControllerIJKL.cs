using UnityEngine;

public class PlayerControllerIJKL : MonoBehaviour
{
    //Simple movement script taken and adapted from https://docs.unity3d.com/ScriptReference/CharacterController.Move.html 
    //Variables
    [SerializeField]
    private float speed = 6.0F;
    //public float jumpSpeed = 8.0F;
    //public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        // is the controller on the ground?
        if (controller.isGrounded)
        {
            //Feed moveDirection with input.
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            // Mathf.Sqrt(2) is needed to calculate the diagonal distance properly.

            // TODO: write code to deal with diagonal movement. (or dont, like its fine like this for testing purposes.) 
            //if(Input.GetKeyDown(KeyCode.I) && Input.GetKeyDown(KeyCode.J))
            //{ }
            if (Input.GetKeyDown(KeyCode.I))
            {
                moveDirection.x *= speed;
                moveDirection.z = 0;
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                moveDirection.x *= -speed;
                moveDirection.z = 0;
            }
            else if (Input.GetKeyDown(KeyCode.J))
            {
                moveDirection.x = 0;
                moveDirection.z *= -speed;
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                moveDirection.x = 0;
                moveDirection.z *= speed;
            } else
            {
                moveDirection.x = 0;
                moveDirection.z = 0;
            }


            //moveDirection = transform.TransformDirection(moveDirection);
            //Multiply it by speed.
            //moveDirection *= speed;
            //Jumping
            //if (Input.GetButton("Jump"))
            //    moveDirection.y = jumpSpeed;

        }
        //Applying gravity to the controller
        //moveDirection.y -= gravity * Time.deltaTime;
        //Making the character move
        controller.Move(moveDirection * Time.deltaTime); // time is multiplied here so it doesnt need to happen earlier. 1 call of Time.deltaTime
    }
}