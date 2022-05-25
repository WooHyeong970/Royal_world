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
    public GameObject rangeOjbect;

    ResourceManager _resource = new ResourceManager();
    SpawnManager _spawn = new SpawnManager();

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

    public void Fight()
    {
        StartCoroutine("spawnMonster");
    }

    IEnumerator spawnMonster()
    {
        int cnt = 10;
        while(true)
        {
            if (cnt == 0) break;
            Instantiate(_resource.Instanticate("Prefab/Enemy"), _spawn.RandomPosition(rangeOjbect), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            cnt--;
        }
    }
}
