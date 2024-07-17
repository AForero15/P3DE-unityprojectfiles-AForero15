using UnityEngine;

public class SpawnOnProximity : MonoBehaviour
{
    public GameObject objectToSpawn;  
    public Transform spawnLocation;  
    public float spawnDistance = 3.0f;  

    private Transform player; 

    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        
        float distance = Vector3.Distance(player.position, transform.position);

        
        if (distance <= spawnDistance && Input.GetKeyDown(KeyCode.F))
        {
            
            Instantiate(objectToSpawn, spawnLocation.position, spawnLocation.rotation);
        }
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnDistance);
    }
}
