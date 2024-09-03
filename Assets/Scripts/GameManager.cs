using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject cubePrefab;
    public IMovable movementSystem;

    private void Start()
    {
        //Create and configure systems
        IInputHandler ınputHandler = new InputSystem();
        movementSystem = new MovementSystem(ınputHandler, 5f);

        //Instantiate and configure the cube
        GameObject cube = Instantiate(cubePrefab, new Vector3(0f, -1.48f, 0f), Quaternion.identity);
        CubeController cubeController = cube.GetComponent<CubeController>();
        cubeController.Initialize(movementSystem);

    }
}