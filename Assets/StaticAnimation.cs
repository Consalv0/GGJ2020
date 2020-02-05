using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StaticAnimation : MonoBehaviour
{
    [SerializeField]GameObject family;
    [SerializeField]GameObject bad;
    [SerializeField]GameObject credits;
    [SerializeField]DayData data;

    private GameObject selected=null;
    // Start is called before the first frame update
    void Start()
    {
        if(data.ending==0)
        selected=bad;
        else
        selected=family;
        selected.SetActive(true);
        StartCoroutine(LoadScene());
    }

    // Update is called once per frame
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(5);
        selected.SetActive(false);
        credits.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }
}
