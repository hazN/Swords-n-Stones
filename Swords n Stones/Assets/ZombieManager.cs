using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

public class ZombieManager : MonoBehaviour
{
    public GameObject ZombiePrefab;
    public GameObject target;
    public int MaxZombies = 30;
    public int MaxX = 60;
    public int MaxZ = 60;
    List<GameObject> zombiesList;
    // Start is called before the first frame update
    void Start()
    {
        zombiesList = new List<GameObject>();
        for (int i = 0; i < MaxZombies; i++)
        {
            int x = Random.Range(-MaxX, MaxX);
            int z = Random.Range(-MaxZ, MaxZ);
            zombiesList.Add(SpawnZombie(new Vector3(target.transform.position.x + x, 3.0f, target.transform.position.z + z)));
        }
        Debug.Log("Zombies size: " + zombiesList.Count);
    }

    GameObject SpawnZombie(Vector3 position)
    {
        GameObject zombie = Instantiate(ZombiePrefab, position, Quaternion.identity);
        zombie.GetComponent<Steering>().Target = target;
        return zombie;
    }

    // Update is called once per frame
    void Update()
    {
        int count = 0;
        foreach (GameObject zombie in zombiesList)
        {
            if (zombie.GetComponent<Health>().isDead && !zombie.GetComponent<Health>().isIgnored)
            {
                count++;
                zombie.GetComponent<Health>().isIgnored = true;
            }
        }
        if (zombiesList.Count > 50)
            return;
        for (int i = 0; i < count; i++)
        {

            int x = Random.Range(-MaxX, MaxX);
            int z = Random.Range(-MaxZ, MaxZ);
            zombiesList.Add(SpawnZombie(new Vector3(target.transform.position.x + x, 3.0f, target.transform.position.z + z)));
            Debug.Log("New zombie added");
        }

        for (int i = zombiesList.Count() - 1; i >= 0; i--)
        {
            GameObject zombie = zombiesList[i];
            if (zombie.GetComponent<Health>().isDead)
            {
                zombiesList.Remove(zombie);
            }
        }

        /*foreach(GameObject zombie in tobeRemoved)
        {
            Debug.Log("Removing dead zombie!");
            zombiesList.Remove(zombie);
        }*/
    }
}
