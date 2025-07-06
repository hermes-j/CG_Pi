using UnityEngine;

public class SampleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject samplePrefab;
    [SerializeField] private float r = 10; // radius
    [SerializeField] private int spawnRate = 100; // number of samples spawned per second
    private float timeAfterSpawn = 0f;

    private float pi;
    private int numSphere = 0; // samples that hit sphere
    private int numPlane = 0; // samples that didn't hit sphere

    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        if (timeAfterSpawn > 1)
        {
            timeAfterSpawn = 0;
            for(int i=0; i<spawnRate; i++)
            {
                float randomX = Random.Range(-r, r);
                float randomZ = Random.Range(-r, r);
                Vector3 spawnPosition = new Vector3(randomX, 4, randomZ);
                GameObject sampleObj = Instantiate(samplePrefab, spawnPosition, new Quaternion(0,0,0,0));

                Sample sample = sampleObj.GetComponent<Sample>();
                sample.Init(this);
            }
            if (numSphere * numPlane != 0) // start calculating after first spawn
            {
                pi = 4 * (float)numSphere / (numSphere+numPlane);
                Debug.Log($"파이 추정값: {pi}, 생성 샘플 수: {numSphere + numPlane}");
            }
        }
    }
    public void count(bool isInsideCircle)
    {
        if (isInsideCircle) numSphere++;
        else numPlane++;
    }
}