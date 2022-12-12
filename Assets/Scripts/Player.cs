using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float frequencyResistance;
    [SerializeField] float fallSpeed;

    Transform tr;

    float lastFrequencyReceived;

    // Start is called before the first frame update
    void Start()
    {
        tr = transform;
    }

    // Update is called once per frame
    void Update()
    {
        float yVelocity = lastFrequencyReceived - fallSpeed;

        tr.position = new Vector2(tr.position.x, tr.position.y + yVelocity * Time.deltaTime);

        // Clamp Height
        if (tr.position.y > 9.25f) tr.position = new Vector2(tr.position.x, 9.25f);
        if (tr.position.y < -9.25f) tr.position = new Vector2(tr.position.x, -9.25f);
    }

    public void ReceiveFrequency(float frequency)
    {
        if (frequency > 1000) frequency = 1000; // Clamp frequency
        lastFrequencyReceived = frequency / frequencyResistance;
    }

    void Respawn()
    {
        tr.position = new Vector2(-9, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pillar")
        {
            Respawn();
        }
    }
}
