using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitializeButton : MonoBehaviour
{
    private Button button;
    public uint index;

    private void Start()
    {
        try
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(delegate { SetCurrentObject((int)index); });
        }
        catch (Exception e)
        {
            Debug.Log($"{e.Message}");
            throw;
        }
    }

    private void SetCurrentObject(int index)
    {
        ShopMenager.Instance.SelectItem(index);
    }
}
