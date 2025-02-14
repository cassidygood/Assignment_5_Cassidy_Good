using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    public float rotationSpeed = 100f; // Adjust to make it spin faster or slower

    void Update()
    {
        // Rotate the coin
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        // Floating effect
        float floatHeight = 0.2f; // How high it moves
        float floatSpeed = 2f;    // Speed of the movement
        transform.position += new Vector3(0, Mathf.Sin(Time.time * floatSpeed) * floatHeight * Time.deltaTime, 0);
    }
}
