using UnityEngine;

public class Sample : MonoBehaviour
{
    private SampleSpawner spawner;

    public void Init(SampleSpawner spawner)
    {
        this.spawner = spawner;
    }

    public void Update()
    {
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            spawner.count(true);
            Destroy(gameObject);
        }
        if (other.tag == "Floor")
        {
            spawner.count(false);
            Destroy(gameObject);
        }
    }
}