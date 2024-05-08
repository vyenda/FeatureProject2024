using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
/* Author: Angeleen Arellano
 * Last Edited: 5/7/2024
 */
/// <summary>
/// Controls the player, specifically movement and attack.
/// </summary>

public class PlayerController : MonoBehaviour
{
    // movement speed of player
    public float speed = 10f;

    // cooldown until you can use the ability again
    public float cooldown;

    // inputaction to tell which keys to press
    public FeatureProjectFinal2024 controls;

    // enemy rb and transform
    Rigidbody enemyBody;
    public Transform enemy;

    // distances/location for the pull mechanic
    public float pullRange;
    public float pullInt;
    public float distToEn;
    Vector3 pullForce;

    // the move direction for player across vector2
    Vector2 moveDir = Vector2.zero;

    // creating the rb for player
    public Rigidbody rb;

    // for movement
    private InputAction movement;

    // points and prefabs for attack 1 and 2
    public GameObject teleportPoint;
    public GameObject teleportPoint2;
    public GameObject attack1P;
    public GameObject attack2P;

    // bool for the beginning of attack 1
    public bool pullTrigger = false;

    // requirement for inputsystem
    private void OnEnable()
    {
        movement = controls.Player.Move;
        movement.Enable();
    }
    // requirement for inputsystem
    private void OnDisable()
    {
        movement.Disable();
    }

    private void Awake()
    {
        // initializes the script
        controls = new FeatureProjectFinal2024();
    }

    void Start()
    {
        // gets the rigidboy for the enemy
        enemyBody = enemy.GetComponent<Rigidbody>();
    }

    void Update()
    {
        // pulls the WASD value
        moveDir = movement.ReadValue<Vector2>();

        // starts attack 1 when E is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            // starts the coroutine, explanation further below
            StartCoroutine(pullAttack());
            // turns the pull mechanic on
            pullTrigger = true;
        }

        // the pull mechanic, which pulls enemy to the player if they are in range
        if (pullTrigger)
        {
            // makes distToEn equal the position of the enemy
            distToEn = Vector3.Distance(enemy.position, transform.position);
            // if distToEn is less than the set pullRange then it starts the pull mechanic
            if (distToEn < pullRange)
            {
                pullForce = (transform.position - enemy.position).normalized / distToEn * pullInt;
                enemyBody.AddForce(pullForce, ForceMode.Force);
            }
        }

        // starts attack 2 when Q is pressed
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // starts the coroutine, explanation further below
            StartCoroutine(consistentDmg());
            aoeAttack2();
        }

    }

    // adds a "timer" to the pull for how long it lasts, and then starts aoeAttack1() when finished
    IEnumerator pullAttack()
    {
        // timer for pull attack
        yield return new WaitForSeconds(1f);
        // turns pull off
        pullTrigger = false;
        // pushes the player up
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), 2f);
        yield return new WaitForSeconds(0.2f);
        Debug.Log("Up");
        // pushes the player down to original spot
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y - 2, transform.position.z), 2f);
        Debug.Log("Down");
        // starts attack 1
        aoeAttack1();
    }

    IEnumerator consistentDmg()
    {
        // does "continuous" damage to the enemy
        yield return new WaitForSeconds(2f);
        aoeAttack2();
        yield return new WaitForSeconds(2f);
        aoeAttack2();
        yield return new WaitForSeconds(2f);
        aoeAttack2();
    }

    // instantiates the prefab for the first attack
    private void aoeAttack1()
    {
        Instantiate(attack1P, teleportPoint2.transform.position, Quaternion.identity);
        Debug.Log("Attack1");

    }

    // instanties the prefab for the second attack
    private void aoeAttack2()
    {
        Instantiate(attack2P, teleportPoint.transform.position, Quaternion.identity);
        Debug.Log("Attack2");
    }

    private void FixedUpdate()
    {
        // adds movement and speed to the rigidbody
        rb.velocity = new Vector2(moveDir.x * speed, moveDir.y * speed);
    }
}
