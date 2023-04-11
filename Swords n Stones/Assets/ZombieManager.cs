using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    public GameObject ZombiePrefab;
    public GameObject target;
    public int MaxZombies = 30;
    public int MaxX = 30;
    public int MaxZ = 30;
    // Start is called before the first frame update
    void Start()
    {
        for(int i =0; i < MaxZombies; i++)
        {
            int x = Random.Range(-MaxX, MaxX);
            int z = Random.Range(-MaxZ, MaxZ);
            SpawnZombie(new Vector3(target.transform.position.x + x, 3.0f, target.transform.position.z + z));
        }
    }

    void SpawnZombie(Vector3 position)
    {
        GameObject zombie = Instantiate(ZombiePrefab, position, Quaternion.identity);
        zombie.GetComponent<Steering>().Target = target;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
