using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private GameObject coinGatherParticleSystem;

    private void FixedUpdate()
    {
        transform.Rotate(0, rotationSpeed * Time.fixedDeltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        ProgressManager.Default.CollectMoney();
        // spawn fx above
        Instantiate(coinGatherParticleSystem, transform.position + Vector3.up, Quaternion.identity);
        Destroy(gameObject);
    }
}