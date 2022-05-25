using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager
{
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    public GameObject Instanticate(string path, Transform parent = null)
    {
        GameObject gameObject = Load<GameObject>($"{path}");

        if (gameObject == null)
        {
            Debug.Log($"Failed to load sprite : {path}");
            return null;
        }

        return gameObject;
    }
}