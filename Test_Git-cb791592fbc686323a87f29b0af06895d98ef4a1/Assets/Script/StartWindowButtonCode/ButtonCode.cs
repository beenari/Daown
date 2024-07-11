using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonCode : MonoBehaviour
{
    public static ButtonCode BTC;

    public GameObject Panel;
    public GameObject Seting_Panel;
    private void Start()
    {
        BTC = this;

        Panel.SetActive(false);
        Seting_Panel.SetActive(false);
    }
    public void Start_Button()
    {
        SceneManager.LoadScene("Æ©Åä¸®¾ó ¾À");
    }
    public void Cerator_word_Button()
    {
        Panel.SetActive(true);
    }
    public void OffCerator_word_Button()
    {
        Panel.SetActive(false);
    }
    public void Seting_Button()
    {
        Seting_Panel.SetActive(true);
    }
    public void Quit_Button()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
