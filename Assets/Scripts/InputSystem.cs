using UnityEngine;

public class InputSystem : IInputHandler
{
    public Vector3 GetInputDirection()
    {
        //Handle input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        return new Vector3(horizontal, 0, vertical);
    }
}