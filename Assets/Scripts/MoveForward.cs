using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private int speed = 5;
    private float _offset;

    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, _offset, Time.deltaTime * speed));
    }
}
