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
        float speed = 0;
        float backspeed = 0;
        if (Input.GetKey(KeyCode.W))
        {
            float tempspeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
            speed = Mathf.Lerp(0, tempspeed, 0.9f);

            characterAnimator.SetFloat("Speed", speed);
            characterRigidbody.MovePosition(characterTransform.position + characterTransform.forward * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            float temp = -(Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed);
            backspeed = Mathf.Lerp(0, temp, 0.9f);
            characterAnimator.SetFloat("Speed", backspeed);

            characterRigidbody.MovePosition(characterTransform.position + characterTransform.forward * backspeed * Time.deltaTime);
        }
        else
        {
            characterAnimator.SetFloat("Speed", 0);

        }
    }
    private void FixedUpdate()
    {
        
    }
}
