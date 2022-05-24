using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    public Image ready_pn;
    public Text ready_txt;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }

    public void Ready()
    {
        Debug.Log("is Ready");
        ready_pn.gameObject.SetActive(true);
        StartCoroutine("ready_time");
    }

    IEnumerator ready_time()
    {
        int t = 3;
        while(true)
        {
            if (t == 0) break;
            ready_txt.GetComponent<Text>().text = t.ToString();
            yield return new WaitForSecondsRealtime(1);
            t--;
        }
        ready_pn.gameObject.SetActive(false);
        SceneManager.LoadScene(3);
    }
}
