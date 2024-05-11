using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed= 5;
    [SerializeField] private float rotateSpeed = 5f;

    public bool isRunning;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector= new Vector2(0,0);

        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y = +1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = +1;
        }

        inputVector= inputVector.normalized;

        //Create a vector 3 & assign y input to z azis
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        // increment gameobject/player transform position by the vector3 
        transform.position += moveDir* Time.deltaTime* moveSpeed;

        // bool returns true when inputis not zero
        isRunning = moveDir != Vector3.zero;
        
        // set forward pos to players move direction
        transform.forward = Vector3.Lerp(transform.position, moveDir, Time.deltaTime* rotateSpeed);
    }


    private void HandleMovement()
    {
        Vector2 inputVector = GameInput.instance.GetMovementVectorNormalised();

        float moveDistance= moveSpeed * Time.deltaTime;
        Vector3 moveDirection = new Vector3(inputVector.x, 0, inputVector.y);

        float playerRadius= .5f;
        float playerHeight= 2f;


      //  Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirection);


        
    }


   
    public bool IsRunning()
    {
        return isRunning;
    }
}
