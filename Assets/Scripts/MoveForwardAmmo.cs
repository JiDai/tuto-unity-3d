using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardAmmo : MonoBehaviour
{
    private int speed = 20;
    private float _offset = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, _offset, transform.position.z + Time.deltaTime * speed);
    }
}
