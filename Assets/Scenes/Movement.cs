using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform characterTransform;
    public Animator characterAnimator;
    public Rigidbody characterRigidbody;
    public float walkSpeed = 3.0f;
    public float runSpeed = 6.0f;
    // Start is called before the first frame update
    void Start()
    {
       if (characterTransform == null || characterAnimator == null || characterRigidbody == null)
       {
            Debug.LogError("Please attach the required components.");
       }
    }

    // Update is called once per frame
    void Update()
    {
        float speed=0;

        if (Input.GetKey(KeyCode.W))
        {
            speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
            characterAnimator.SetFloat("Speed", speed);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                characterAnimator.SetTrigger("Run");
            }
            else
            {
                characterAnimator.SetTrigger("Walk");
            }
            characterRigidbody.MovePosition(characterTransform.position + characterTransform.forward * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                characterAnimator.SetTrigger("BackRun");
            }
            else
            {
                characterAnimator.SetTrigger("BackWalk");
            }
            characterRigidbody.MovePosition(characterTransform.position - characterTransform.forward * speed * Time.deltaTime);
        }
        else 
        {
            if(speed ==0)
            characterAnimator.SetTrigger("Idle");
        }
    }
}
