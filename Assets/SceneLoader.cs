using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{

    [SerializeField] DayData data;
    public void GoToScene(int index)
    {
       // StartCoroutine(GoToScene(index));
       SceneManager.LoadScene(index);
    }

    public void GoToCorrespondingScene()
    {
       StartCoroutine(GoToCorrespondingSceneC());
    }
    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator GoToSceneC(int index)
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(index);
    }
    IEnumerator GoToCorrespondingSceneC()
    {
        yield return new WaitForSeconds(3);
        if (data.badDays >= 3)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            ReloadScene();
    }
}
