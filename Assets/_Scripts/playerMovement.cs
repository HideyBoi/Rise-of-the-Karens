using UnityEngine;

public class playerMovement : MonoBehaviour
{
    
    public Rigidbody2D rb;
    public Animator animator;
    public float moveSpeed;

    public float holding;
    public FloatingJoystick joystick;
    public bool usingTouch;
    public GameObject TouchGui;

    public float MoveX;
    public float MoveY;


    void Awake()
    {
        int loadVarible = PlayerPrefs.GetInt("usingTouchControls");

        if (loadVarible == 1)
        {
            usingTouch = true;
            TouchGui.SetActive(true);
        }
        else
        {
            usingTouch = false;
            TouchGui.SetActive(false);
        }
    }


    void FixedUpdate()
    {
        if(!usingTouch)
        {
            MoveX = Input.GetAxis("Horizontal") * moveSpeed;
            MoveY = Input.GetAxis("Vertical") * moveSpeed;
        }
        else
        {
            MoveX = joystick.Horizontal * moveSpeed;
            MoveY = joystick.Vertical * moveSpeed;
        }
       
        Vector2 move = new Vector2(MoveX, MoveY);
        animator.SetFloat("Horizontal", MoveX);
        animator.SetFloat("Vertical", MoveY);
        animator.SetFloat("Speed", move.sqrMagnitude);
        rb.AddForce(move);
    }

}
