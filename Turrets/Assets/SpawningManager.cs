using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningManager : MonoBehaviour
{
#region Singleton
    public static SpawningManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
            Destroy(this.gameObject);
        Instance = this;
        ObjectsToSpawn = new List<GameObject>()
        {
            turret
        };
    }
    #endregion
    public List<GameObject> ObjectsToSpawn{ get; private set; }
    public GameObject turret;
    [SerializeField]
    private float maxDistance;
    private GameObject currentItem;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SpawnCurrentItem();
        }
    }

    private void SpawnCurrentItem()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (currentItem == null)
            return;
        if(Physics.Raycast(ray, out hit, maxDistance, LayerMask.GetMask("Test")))
        {
            Debug.Log($"Hit point {(int)hit.point.x} {(int)hit.point.z}");
            Instantiate(currentItem, new Vector3((int)hit.point.x, hit.point.y, (int)hit.point.z), Quaternion.identity);
            currentItem = null;
        }
    }
    public void SetCurrentItem(GameObject item)
    {
        try
        {
            currentItem = item;
            Debug.Log($"Current item: {item.name}");
        }
        catch(Exception e)
        {
            Debug.Log(e.Message);
            throw e;
        }
    }
    public GameObject GetCurrentItem()
    {
        return currentItem;
    }
}
