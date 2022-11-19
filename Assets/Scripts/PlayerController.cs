using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 25.0f;
    private int _xBound = 10;
    private int _zBound = 4;
    public GameObject projectilePrefab;
    Animator m_Animator;
    private static readonly int Run = Animator.StringToHash("Run");

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var tf = transform;
        if (tf.position.x < -_xBound)
        {
            var position = tf.position;
            position = new Vector3(-_xBound, position.y, position.z);
            tf.position = position;
        }
        else if (tf.position.x > _xBound)
        {
            var position = tf.position;
            position = new Vector3(_xBound, position.y, position.z);
            tf.position = position;
        }
        if (tf.position.z < -_zBound)
        {
            var position = tf.position;
            position = new Vector3(position.x, position.y,  -_zBound);
            tf.position = position;
        }
        else if (tf.position.z > _zBound)
        {
            var position = tf.position;
            position = new Vector3(position.x, position.y,  _zBound);
            tf.position = position;
        }

        horizontalInput = Input.GetAxis("Horizontal");
        tf.Translate(Vector3.right * (Time.deltaTime * (horizontalInput * speed)));
        verticalInput = Input.GetAxis("Vertical");
        tf.Translate(Vector3.forward * (Time.deltaTime * (verticalInput * speed)));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, tf.position, projectilePrefab.transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collider");
        Debug.Log(other.name);
        m_Animator.SetTrigger(Run);
    }
}