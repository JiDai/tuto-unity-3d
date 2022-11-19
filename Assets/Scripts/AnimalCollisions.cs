using System;
using UnityEngine;

public class AnimalCollisions : MonoBehaviour
{
    public static event Action OnAnimalFed;
    public static event Action OnAnimalHurt;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        var gameObjectName = other.gameObject.name;
        if (gameObjectName == "Player")
        {
            OnAnimalHurt?.Invoke();
        }
        else
        {
            Destroy(other.gameObject);
            OnAnimalFed?.Invoke();
        }
    }
}