# Unity Managers and Controllers

## Overview

This project demonstrates the Manager and Controller pattern in Unity with a focus on adhering to SOLID principles. The example involves a simple setup where a cube is managed by a `GameManager`, and its movement is controlled by a `CubeController`. The movement logic is handled by a `MovementSystem` which uses an `InputSystem` to receive input directions.

### SOLID Principles Applied
- **Single Responsibility Principle (SRP)**: Each class has a single responsibility, such as managing game state or handling movement.
- **Open/Closed Principle (OCP)**: Classes are open for extension (e.g., adding new movement types) but closed for modification.
- **Liskov Substitution Principle (LSP)**: Implementations of interfaces can be replaced without affecting the system.
- **Interface Segregation Principle (ISP)**: Interfaces are specific to the needs of the classes that use them.
- **Dependency Inversion Principle (DIP)**: High-level modules depend on abstractions, not on concrete implementations.

## Components

### `GameManager`
Handles the overall game setup, including instantiating the cube and configuring the movement system.

```csharp
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject cubePrefab;
    public IMovable movementSystem;

    private void Start()
    {
        // Create and configure systems
        IInputHandler inputHandler = new InputSystem();
        movementSystem = new MovementSystem(inputHandler, 5f);

        // Instantiate and configure the cube
        GameObject cube = Instantiate(cubePrefab, new Vector3(0f, -1.48f, 0f), Quaternion.identity);
        CubeController cubeController = cube.GetComponent<CubeController>();
        cubeController.Initialize(movementSystem);
    }
}
```

### `IMovable`
Defines a contract for movement functionality.

```csharp
public interface IMovable 
{
    void Move();
}
```

### `IInputHandlar`
Defines a contract for input handling.

```csharp
public interface IInputHandler 
{
    Vector3 GetInputDirection();
}
```

### `MovementSystem`
Implements `IMovable` and handles the logic for moving the cube based on input directions.

```csharp
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
        Transform cubeTransform = GameObject.FindObjectOfType<CubeController>().transform;
        cubeTransform.Translate(direction * speed * Time.deltaTime);
    }
}
```

### `InputSystem`
Implements `IInputHandler` to provide input directions using Unity's `Input` system.

```csharp
using UnityEngine;

public class InputSystem : IInputHandler
{
    public Vector3 GetInputDirection()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        return new Vector3(horizontal, 0, vertical);
    }
}
```

### ``CubeController`
Manages the behavior of the cube, using the `IMovable` system to handle movement.

```csharp
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
        movementSystem.Move();
    }
}
```


