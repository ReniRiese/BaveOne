using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class BasicMovement : MonoBehaviour
{
    public int speed = 10;
    public float jumpSpeed = 9.81f;

    public Transform Camera = null;
    
    private CharacterController m_CharacterController;
    //private Camera m_Camera;
    private bool m_Jump;
    private bool m_Jumping;
    private Vector3 m_MoveDir = Vector3.zero;
    private float m_upDownVelocity = 0;
    private bool m_isGrounded;

    private Animator m_Animator;
    
    private Vector3 camRotation;
    [Range(-45, -15)]
    public int minAngle = -30;
    [Range(30, 80)]
    public int maxAngle = 45;
    [Range(50, 500)]
    public int sensitivity = 200;

    // Start is called before the first frame update
    void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
        m_Animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        //m_Camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIsGrounded();
        CheckJump();
        RotateCamera();
    }
    
    private void FixedUpdate()
    {
        DoMovement();
        
    }
    
    private void CheckJump()
    {
        if (!m_Jump && m_isGrounded && !m_Jumping)
        {
            m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
        }
    }
    private void CheckIsGrounded()
    {
        m_isGrounded = (Physics.Raycast((m_CharacterController.transform.position + m_CharacterController.transform.up * 1f), 
            transform.up * -1, 1f));
    }

    private void DoMovement()
    {
        Vector2 inputs = GetInput();
        
        m_Animator.SetBool("moving", inputs.x!= 0 || inputs.y != 0);
        
        Vector3 forwardMove = transform.forward * inputs.y * speed;
        Vector3 rightMove = transform.right * inputs.x * speed;
        
        if (m_isGrounded)
        {
            if (m_Jump)
            {
                m_Jumping = true;
                m_upDownVelocity = jumpSpeed;
            }
            else
            {
                m_Jumping = false;
                m_Jump = false;
                m_upDownVelocity = 0;
            }
        }
        else
        {
            m_Jump = false;
        }

        m_MoveDir = forwardMove + rightMove + (transform.up * m_upDownVelocity);
        
        m_CharacterController.Move(m_MoveDir * Time.fixedDeltaTime);
    }

    private Vector2 GetInput()
    {
        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float vertical = CrossPlatformInputManager.GetAxis("Vertical");
        Vector2 input = new Vector2(horizontal, vertical);
        input.Normalize();
        return input;
    }
    
    private Vector2 GetMouseInput()
    {
        float mouseX = CrossPlatformInputManager.GetAxis("Mouse X");
        float mouseY = CrossPlatformInputManager.GetAxis("Mouse Y");
        Vector2 input = new Vector2(mouseX, mouseY);
        input.Normalize();
        return input;
    }

    private void RotateCamera()
    {
        Vector2 mouseInputs = GetMouseInput();
        
        camRotation.x -= mouseInputs.y * sensitivity * Time.deltaTime;
        camRotation.x = Mathf.Clamp(camRotation.x, minAngle, maxAngle);
        
        camRotation.y -= mouseInputs.x * sensitivity * Time.deltaTime;
        //camRotation.y = Mathf.Clamp(camRotation.y, minAngle, maxAngle);

        transform.localEulerAngles = camRotation;
    }
}