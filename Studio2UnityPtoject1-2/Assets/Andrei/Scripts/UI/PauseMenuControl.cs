using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseMenuControl : MonoBehaviour
{
    [SerializeField] string menuScene;
    [SerializeField] Button continueButton;
    [SerializeField] Button goToMenuButton;

    [SerializeField] Image sceneTransit;
    Animator sceneTransitAnimator;
    void Start()
    {
        sceneTransitAnimator = sceneTransit.GetComponent<Animator>();
        sceneTransitAnimator.SetBool("leavingScene", false);

        DisableButtons();
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return))
        {
            PauseGame();
        }
    }

    public void DisableButtons()
    {
        continueButton?.gameObject.SetActive(false);
        goToMenuButton?.gameObject.SetActive(false);
    }

    public void EnableButtons()
    {
        continueButton?.gameObject.SetActive(true);
        goToMenuButton?.gameObject.SetActive(true);
    }


    public void PauseGame()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        EnableButtons();
    }

    public void UnPauseGame()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        DisableButtons();
    }

    public void BackToMenu()
    {   
        UnPauseGame();
        Cursor.visible = true;
        SceneManager.LoadScene(menuScene);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public IEnumerator FadeIn(string sceneName)
    {
        sceneTransitAnimator.SetBool("leavingScene", true);
        Debug.Log("Fading in...");
        yield return new WaitForSeconds(1.0f);
        LoadScene(sceneName);
    }
}
