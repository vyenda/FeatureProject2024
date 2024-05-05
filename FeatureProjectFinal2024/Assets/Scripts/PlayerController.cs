using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
/* Author: Angeleen Arellano
 * Last Edited: 5/1/2024
 */
/// <summary>
/// Controls the player, specifically movement and attack.
/// 
/// 1. Movement (speed included)
/// 2. AOE attack including a jump (cooldown included)
/// 3. Bigger AOE attack (cooldown included)
/// 4. Auto attack
/// </summary>

public class PlayerController : MonoBehaviour
{
    // movement speed of player
    public float speed = 10f;

    // damage that the player will do
    public int damage = 10;

    // inputaction to tell which keys to press
    public FeatureProjectFinal2024 controls;

    // the move direction for player across vector2
    Vector2 moveDir = Vector2.zero;

    // creating the rb for player
    public Rigidbody rb;

    // for movement
    private InputAction movement;
    // for firing/auto attacking
    private InputAction fire;
    
    // requirement for inputsystem
    private void OnEnable()
    {
        movement = controls.Player.Move;
        movement.Enable();

        fire = controls.Player.Fire;
        fire.Enable();
        // register fire method to the event
        fire.performed += Fire;
    }
    // requirement for inputsystem
    private void OnDisable()
    {
        movement.Disable();
        fire.Disable();
    }

    private void Awake()
    {
        // initializes the script
        controls = new FeatureProjectFinal2024();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // pulls the WASD value
        moveDir = movement.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        // adds movement and speed to the rigidbody
        rb.velocity = new Vector2(moveDir.x * speed, moveDir.y * speed);
    }

    private void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("Fired");
    }
}
