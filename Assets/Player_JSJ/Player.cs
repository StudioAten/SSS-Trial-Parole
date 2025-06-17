using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float turnSpeed = 5f;

    Rigidbody m_Rigidbody;
    Vector3 m_Movement;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
        Interaction();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_Movement = new Vector3(horizontal, 0, vertical).normalized;

        transform.position += m_Movement * moveSpeed * Time.deltaTime;

        if (m_Movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(m_Movement, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, turnSpeed * Time.deltaTime);
        }
    }

    private void Interaction()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            print("��ȣ�ۿ�!");
        }
    }

    // �������̵��ؼ� �����ߴµ� ���� �� ���ͼ� �ϴ� ����
    //public virtual void InteractionDetail()
    //{
    //    print("��ȣ�ۿ�!");
    //}
}
