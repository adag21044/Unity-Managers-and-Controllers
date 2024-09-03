using UnityEngine;

public class CubeController : MonoBehaviour
{
    private IMovable movementSystem;

    public void Initialize(IMovable movementSystem)
    {
        this.movementSystem = movementSystem;
    }
    
    public void Update()
    {
        //Use movement system to move the cube
        movementSystem.Move();
    }
}