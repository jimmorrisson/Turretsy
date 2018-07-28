using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenager : MonoBehaviour
{
    #region Singleton
    public static ShopMenager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
            Destroy(this.gameObject);
        Instance = this;
    }
    #endregion
    public GameObject buttonPrefab;

    private void Start()
    {
        uint i = 0;
        foreach (var item in SpawningManager.Instance.ObjectsToSpawn)
        {
            var go = Instantiate(buttonPrefab, transform) as GameObject;
            go.GetComponent<InitializeButton>().index = i;
            i++;   
        }
    }

    public void SelectItem(int index)
    {
        SpawningManager.Instance.SetCurrentItem(SpawningManager.Instance.ObjectsToSpawn[index]);
    }
}
