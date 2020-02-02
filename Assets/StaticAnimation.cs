using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StaticAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadScene());
    }

    // Update is called once per frame
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }
}
