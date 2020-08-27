using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerMovement_Iso : MonoBehaviour
{
    MouseInput mouseInput;

    [Header("Movement Variables")]
    public float walkSpeed = 5;

    [HideInInspector]
    //public bool frozen = false;
    //private float inputHorizontal;
    //private float inputVertical;
    private Vector3 destination;
    public Animator animator;

    private Rigidbody2D rigidBody;
    //private SpriteRenderer spriteRenderer;
    //private Collider2D collider;

    private void Awake() {
        mouseInput = new MouseInput();
    }

    private void OnEnable() {
        mouseInput.Enable();
    }

    private void OnDisable() {
        mouseInput.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        destination = transform.position;
        mouseInput.Mouse.Click.performed += _ => FindPosition();
        //rigidBody = GetComponent<Rigidbody2D>();
        //spriteRenderer = GetComponent<SpriteRenderer>();
        //collider = GetComponent<Collider2D>();
    }

    private void FindPosition() {
        UnityEngine.Debug.Log("We Clicked!");
        Vector2 mousePosition = mouseInput.Mouse.Position.ReadValue<Vector2>();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        destination = mousePosition;
    }

    void FixedUpdate() {
        //inputHorizontal = Input.GetAxis("Horizontal");
        //inputVertical = Input.GetAxis("Vertical");
        //rigidBody.velocity = new Vector2(inputHorizontal * walkSpeed, inputVertical * walkSpeed);
        //animator.SetFloat("horSpeed", rigidBody.velocity.x);
        //animator.SetFloat("vertSpeed", rigidBody.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, destination) > 0.1f) {
            transform.position = Vector3.MoveTowards(transform.position, destination, walkSpeed * Time.deltaTime);
        }
    }
}
