using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTitle : MonoBehaviour
{
    public void ClickTitleButton()
    {
        SceneManager.LoadScene("titlescene");
    }
}
