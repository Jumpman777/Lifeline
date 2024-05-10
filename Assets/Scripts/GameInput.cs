using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class GameInput : MonoBehaviour
{
      private PlayerInput playerInput;

    //Create Singleton to access code from script
    public static GameInput instance;


    private void Awake()
    {
        // make object of auto generated script/ construct object of type PlayerInput
       PlayerInput playerInput= new PlayerInput();
        //enable input system/ activate chosen action map 
        playerInput.Player.Enable();


        if(instance== null)
        {
            instance= this;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public Vector2 GetMovementVectorNormalised()
    {
        // listens out for input 
        Vector2 inputVector= playerInput.Player.Move.ReadValue<Vector2>(); 
        
        //Normalise inputVector
        inputVector= inputVector.normalized;
        return inputVector;

        Debug.Log("Input");
    }
}
