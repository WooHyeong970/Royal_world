using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public void WindowOnOff(Image image)
    {
        if (image.gameObject.activeSelf)
            image.gameObject.SetActive(false);
        else
            image.gameObject.SetActive(true);
    }
}
