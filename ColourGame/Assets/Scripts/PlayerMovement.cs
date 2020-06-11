using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator anim;
    float Velocity = 5f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // FixedUpdate makes things a lil smoother
    void FixedUpdate()
    {

        if(Input.GetAxisRaw("Vertical") > 0) //Moving up.
        {
            transform.Translate(Vector2.up * Velocity * Time.deltaTime); //Translate the objects position upwards
            //Reset idle animation triggers so walking animation can play
            anim.ResetTrigger("StopDownRight");
            anim.ResetTrigger("StopUpLeft");

            anim.SetTrigger("WalkUp"); //Set the appropriate Movement trigger 

            anim.ResetTrigger("WalkLeft"); //Reset the other movement triggers
            anim.ResetTrigger("WalkDown");
            anim.ResetTrigger("WalkRight");
        }
        else if(Input.GetAxisRaw("Horizontal") < 0) //Moving Left
        {
            transform.Translate(Vector2.left * Velocity * Time.deltaTime); //Translate the objects position left
            anim.ResetTrigger("StopDownRight");
            anim.ResetTrigger("StopUpLeft");

            anim.SetTrigger("WalkLeft");

            anim.ResetTrigger("WalkRight");
            anim.ResetTrigger("WalkUp");
            anim.ResetTrigger("WalkDown");
        }
        else if(Input.GetAxisRaw("Vertical") < 0) //Moving Down
        {
            transform.Translate(Vector2.down * Velocity * Time.deltaTime); //Translate the objects position down
            anim.ResetTrigger("StopDownRight");
            anim.ResetTrigger("StopUpLeft");

            anim.SetTrigger("WalkDown");

            anim.ResetTrigger("WalkLeft");
            anim.ResetTrigger("WalkRight");
            anim.ResetTrigger("WalkUp");
        }
        else if(Input.GetAxisRaw("Horizontal") > 0) //Moving Right
        {
            transform.Translate(Vector2.right * Velocity * Time.deltaTime); //Translate the objects position right
            anim.ResetTrigger("StopDownRight");
            anim.ResetTrigger("StopUpLeft");

            anim.SetTrigger("WalkRight");

            anim.ResetTrigger("WalkLeft");
            anim.ResetTrigger("WalkDown");
            anim.ResetTrigger("WalkUp");
        }
        else if((Input.GetAxisRaw("Horizontal") != 0) && (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A))) 
        {
            anim.ResetTrigger("WalkLeft");
            anim.ResetTrigger("WalkRight");
            anim.ResetTrigger("WalkUp");
            anim.ResetTrigger("WalkDown");

            anim.SetTrigger("StopUpLeft");
            
        }
        //If movement has stopped and the S or D keys are not pressed, revert to idle animation
        else if(Input.GetAxisRaw("Vertical") != 0 && (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D)))
        {
            anim.ResetTrigger("WalkLeft");
            anim.ResetTrigger("WalkRight");
            anim.ResetTrigger("WalkUp");
            anim.ResetTrigger("WalkDown");

            anim.SetTrigger("StopDownRight");
        }
    }
}
