using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject CameraHolder;
    public Vector2 Moving;//needed to see/move
    public Vector2 Looking;//needed to see/move
    public float LookRotation;//needed to see/move

    public bool grounded; //is the player touching a floor surface
    public bool dead = false; //will the player show himself dying
    public bool SprintingNow; //is the player sprinting


    [SerializeField] public float Speed = 5f;
    [SerializeField] public float SprintMult = 2f;
    [SerializeField] public float Sensitive = 0.2f;
    [SerializeField] public float Maxforce = 1f;
    [SerializeField] public float JumpForce = 3f;
    

    public void OnMove(InputAction.CallbackContext context){
        Moving = context.ReadValue<Vector2>();
    }
    public void OnLook(InputAction.CallbackContext context){
        Looking = context.ReadValue<Vector2>();
    }
    public void OnJump(InputAction.CallbackContext context){
        Jump();
    }
    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.started){
            SprintingNow = true;
        }
        if (context.canceled){
            SprintingNow = false;
        }
    }

    private void FixedUpdate(){
        Move();
    }

    void Jump(){
        Vector3 JumpForces = Vector3.zero;

        //dead players cannot move or lookaround. - Dennis
        if (GameManager.gameManager.playerHealth.Health <= 0)
        {
            rb.velocity = Vector3.zero;
            return;
        }

        if(grounded){
            JumpForces = Vector3.up * JumpForce;
        }
        rb.AddForce(JumpForces, ForceMode.VelocityChange);
    }

    void Move(){

        //dead players cannot move or lookaround. - Dennis
        if (GameManager.gameManager.playerHealth.Health <= 0)
        {
            rb.velocity = Vector3.zero;
            return;
        }

        //multiply the speed if sprinting
        float currSpeed;
        if (SprintingNow){
            currSpeed = Speed * SprintMult;
        }
        else{
            currSpeed = Speed;
        }

        
        //set the players velocity
        Vector3 CurrVelocity = rb.velocity;
        Vector3 TargetVelocity = new Vector3(Moving.x,0,Moving.y) * currSpeed;
        //fixes the camera
        TargetVelocity = transform.TransformDirection(TargetVelocity);

        //sets the force and hiw strong it is
        Vector3 VelocityChange = (TargetVelocity - CurrVelocity);
        VelocityChange = new Vector3(VelocityChange.x,0,VelocityChange.z);
        Vector3.ClampMagnitude(VelocityChange, Maxforce);
        rb.AddForce(VelocityChange, ForceMode.VelocityChange);

    }

    void Look(){

        //dead players cannot move or lookaround. - Dennis
        if (GameManager.gameManager.playerHealth.Health <= 0)
        {
            rb.velocity = Vector3.zero;
            return;
        }

        //turns the camera properly with mouse sensitivity
        transform.Rotate(Vector3.up * Looking.x * Sensitive);
        //use mouse to look arounf and limit how much
        LookRotation = LookRotation + (-Looking.y * Sensitive);
        LookRotation = Mathf.Clamp(LookRotation, -90, 90);
        CameraHolder.transform.eulerAngles = new Vector3(LookRotation, CameraHolder.transform.eulerAngles.y, CameraHolder.transform.eulerAngles.z);
    }

    // Start is called before the first frame update
    void Start()
    {
        //hides the mouse and also keeps the cursor from leaving the window
        Cursor.lockState = CursorLockMode.Locked;
    }
 
    // Update is called once per frame
    void LateUpdate()
    {
        Look();
    }

    public void SetGrounded(bool state){
        grounded = state;
    }

    //NEW: is dead state checker, similar to is grounded state check
        public void SetDead(bool state)
    {
        dead = state;
    }


}//END