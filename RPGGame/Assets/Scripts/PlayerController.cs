using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //public int playerId;
    //Player player;

    [Header("Character attributes:")]
    public float MOVEMENT_BASE_SPEED = 3.0f;

    [Space]
    [Header("Character statistics:")]
    public Vector2 movementDirection;
    public float movementSpeed;

    [Space]
    [Header("References:")]
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        //player = ReInput.players.GetPlayer(playerId);
    }

    // Update is called once per frame
    void Update() {
        ProcessInputs();
        Move();
    }

    void ProcessInputs() {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();
    }

    void Move() {
        rb.velocity = movementDirection * movementSpeed * MOVEMENT_BASE_SPEED;
    }
}
