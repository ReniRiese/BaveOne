using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAcceptor : MonoBehaviour
{
    public GravityGiver gravityGiver;
    private Vector3 m_VectorToGravityCenter = Vector3.down;
    public float gravityForce = 9.81f;
    public float gravityMultiplier = 2f;

    private CharacterController m_CharacterController;
    private bool m_isGrounded;
    private Vector3 m_lastMovement = Vector3.zero;

    // Start is called before the first frame update
    public void SetLastMovementToZero()
    {
        m_lastMovement = Vector3.zero;
    }
    void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
        CheckIsGrounded();
        CheckGravityEndpoint();
        DoOrientation();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIsGrounded();
        CheckGravityEndpoint();
    }

    private void CheckGravityEndpoint()
    {
        m_VectorToGravityCenter = gravityGiver.GetGravityVector(this.gameObject);
    }

    private void FixedUpdate()
    {
        ApplyGravityToGameObject();
        CheckGravityEndpoint();
        DoOrientation();
    }

    private void DoOrientation()
    {
        //Debug.DrawLine(transform.position, transform.position + m_VectorToGravityCenter * 100);

        //transform.up = (m_VectorToGravityCenter * -1).normalized;
    }

    private void CheckIsGrounded()
    {
        m_isGrounded = (Physics.Raycast(
            (m_CharacterController.transform.position + m_CharacterController.transform.up * 1f),
            transform.up * -1, 1f));
        
        Debug.Log("isGrounded (acceptor) " + m_isGrounded);
    }

    private void ApplyGravityToGameObject()
    {
        // Do Fancy Stuff
        Vector3 m_MoveDir = Vector3.zero;
        
        if (!m_isGrounded)
        {
            m_MoveDir = m_VectorToGravityCenter * gravityForce * Time.fixedDeltaTime;
        }
        else
        {
            m_lastMovement = Vector3.zero;
            m_MoveDir = Vector3.zero;
        }

        Vector3 thisMovement = m_lastMovement + m_MoveDir;
        m_CharacterController.Move(thisMovement * Time.fixedDeltaTime);

        m_lastMovement = thisMovement;
    }
}