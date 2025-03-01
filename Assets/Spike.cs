using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    private float speed;
    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        transform.localScale = Vector3.one * Random.Range(0.2f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        timer += Time.deltaTime;
        if (timer > 10f)
        {
            Destroy(gameObject);
        }
    }
}
