using UnityEngine;

public class Wine : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private GameObject wineGatherParticleSystem;
    [SerializeField] private int spendAmount = 10;

    private void FixedUpdate()
    {
        transform.Rotate(0, rotationSpeed * Time.fixedDeltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        ProgressManager.Default.CollectBadItem(spendAmount);
        // spawn fx above
        Instantiate(wineGatherParticleSystem, transform.position + Vector3.up, Quaternion.identity);
        Destroy(gameObject);
    }
}