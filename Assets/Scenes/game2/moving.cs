using UnityEngine;
using UnityEngine.InputSystem; 

public class SimpleMover : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        
        float move = 0f;

        if (Keyboard.current.aKey.isPressed)
            move = 1f;
        else if (Keyboard.current.dKey.isPressed)
            move = -1f;

        transform.Translate(Vector3.forward * move * speed * Time.deltaTime);
    }
}
