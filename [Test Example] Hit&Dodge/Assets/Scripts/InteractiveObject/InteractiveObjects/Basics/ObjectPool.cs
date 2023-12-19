using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace InteractiveObjects.Basics
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private int startingPoolSize = 5;
        [SerializeField] private int poolSizeIncrement = 2;
        [SerializeField] private Transform leftSpawnPoint;
        [SerializeField] private Transform rightSpawnPoint;
        [SerializeField] private List<Transform> leftSideObjects;
        [SerializeField] private List<Transform> rightSideObjects;
        [SerializeField] private int maxSpawnCount;
        [SerializeField] private TextMeshProUGUI disabledObjectCountText;

        private List<List<GameObject>> objectPools = new List<List<GameObject>>();
        private int currentWave = 0;
        private int spawnCount = 0;
        private int decreaseCount = 0;

        private void Start()
        {
            InitializeObjectPools();
            StartCoroutine(SpawnWaves());
        }

        private void Update()
        {
            disabledObjectCountText.text = $"{decreaseCount}";
        }

        private void FixedUpdate()
        {
            Debug.Log($"Decreased active objects in pool. Decrease count: {decreaseCount}");
        }

        private void InitializeObjectPools()
        {
            InitializeObjectPool(leftSideObjects, startingPoolSize, ref objectPools);

            InitializeObjectPool(rightSideObjects, startingPoolSize, ref objectPools);
        }

        private void InitializeObjectPool(List<Transform> sideObjects, int poolSize, ref List<List<GameObject>> pools)
        {
            List<GameObject> objectPool = new List<GameObject>();

            for (int i = 0; i < poolSize; i++)
            {
                int randomIndex = Random.Range(0, sideObjects.Count);
                GameObject obj = Instantiate(sideObjects[randomIndex].gameObject, Vector2.zero, Quaternion.identity);
                obj.SetActive(false);
                objectPool.Add(obj);
            }

            pools.Add(objectPool);
        }

        private IEnumerator SpawnWaves()
        {
            while (true)
            {
                yield return new WaitUntil(AllObjectsInactive);

                IncreasePoolSize();

                for (int i = 0; i < startingPoolSize + (currentWave * poolSizeIncrement); i++)
                {
                    Transform spawnPoint = Random.Range(0, 2) == 0 ? leftSpawnPoint : rightSpawnPoint;

                    List<GameObject> selectedPool = GetSelectedPool(spawnPoint);

                    if (selectedPool.Count > 0)
                    {
                        GameObject obj = GetPooledObject(selectedPool);

                        Vector2 spawnPosition = spawnPoint.position;
                        Quaternion spawnRotation = spawnPoint.rotation;

                        obj = SpawnFromPool(selectedPool, obj, spawnPosition, spawnRotation);

                        IncrementSpawnCount();
                    }
                }

                currentWave++;
            }
        }

        private void IncreasePoolSize()
        {
            startingPoolSize += poolSizeIncrement;
        }

        private bool AllObjectsInactive()
        {
            foreach (List<GameObject> pool in objectPools)
            {
                foreach (GameObject obj in pool)
                {
                    if (obj.activeInHierarchy)
                        return false;
                }
            }

            return true;
        }


        private List<GameObject> GetSelectedPool(Transform spawnPoint)
        {
            int poolIndex = spawnPoint == leftSpawnPoint ? 0 : 1;
            return objectPools[poolIndex];
        }

        private GameObject GetPooledObject(List<GameObject> objectPool)
        {
            foreach (GameObject obj in objectPool)
            {
                if (!obj.activeInHierarchy)
                {
                    return obj;
                }
            }

            int randomIndex = Random.Range(0, objectPool.Count);
            GameObject newObj = Instantiate(objectPool[randomIndex]);
            objectPool.Add(newObj);
            return newObj;
        }

        private GameObject SpawnFromPool(List<GameObject> objectPool, GameObject obj, Vector2 spawnPosition,
            Quaternion spawnRotation)
        {
            if (!obj.activeInHierarchy)
            {
                obj.transform.position = spawnPosition;
                obj.transform.rotation = spawnRotation;
                obj.SetActive(true);
                return obj;
            }

            GameObject newObj = Instantiate(objectPool[0], spawnPosition, spawnRotation);
            objectPool.Add(newObj);
            return newObj;
        }

        private void IncrementSpawnCount()
        {
            spawnCount++;

            if (spawnCount >= maxSpawnCount)
            {
                CheckActiveObjectCount();
                StopCoroutine(SpawnWaves());
            }
        }

        private int CountActiveObjects(List<GameObject> objectPool)
        {
            int activeObjectCount = 0;

            foreach (GameObject obj in objectPool)
            {
                if (obj.activeInHierarchy)
                {
                    activeObjectCount++;
                }
            }

            return activeObjectCount;
        }

        private void CheckActiveObjectCount()
        {
            for (int i = 0; i < objectPools.Count; i++)
            {
                List<GameObject> pool = objectPools[i];
                int activeCount = CountActiveObjects(pool);

                Debug.Log($"Active objects in pool {i}: {activeCount}");

                if (activeCount < pool.Count) decreaseCount++;

            }

        }
    }
}
