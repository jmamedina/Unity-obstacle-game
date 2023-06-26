using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb; //get the rigid body of the player
    private Animator playerAnim; //get the animator of the player

    public float jumpForce; //force of the jump
    public float gravityModifier; //gravitiy
    public bool isOnGround = true; //if rigid body is on ground or not flag
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        //get the component rigid body
        playerRb = GetComponent<Rigidbody>();

        //get the component animator
        playerAnim = GetComponent<Animator>();

        //modify players gravity
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        //if space pressed it will jump
       if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
        }

    }

    //if rigid body is in collision or not
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }else if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("game over");
        }
    }

}
