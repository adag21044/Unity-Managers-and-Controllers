using UnityEngine;

public class MovementSystem : IMovable
{
    private readonly IInputHandler inputHandler;
    private readonly float speed;

    public MovementSystem(IInputHandler inputHandler, float speed)
    {
        this.inputHandler = inputHandler;
        this.speed = speed;
    }

    public void Move()
    {
        Vector3 direction = inputHandler.GetInputDirection();

        //Apply movement logic based on the input direction,
        Transform cubeTransform = GameObject.FindObjectOfType<CubeController>().transform;

        cubeTransform.Translate(direction * speed * Time.deltaTime);
    }
}