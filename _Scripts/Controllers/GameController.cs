using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {
    public Image overlay;
    public Button reloadButton;
    public Button toMenuButton;

    private bool pauseState = false;


    void Start() {
        StartCoroutine(ILoadScene());
        reloadButton.gameObject.SetActive(false);
        toMenuButton.gameObject.SetActive(false);
    }

    void Update() {
        if ( Input.GetKeyDown(KeyCode.Escape) ) {
            if ( pauseState ) {
                Unpause();
            }
            else {
                Pause();
            }
        }
    }

    public void ReloadScene() {
        Unpause();
        reloadButton.gameObject.SetActive(false);
        toMenuButton.gameObject.SetActive(false);
        StartCoroutine(IUnoadScene(() => {
            SceneManager.LoadScene("MainScene");
        }));
    }

    public void ToMenu() {
        Unpause();
        reloadButton.gameObject.SetActive(false);
        toMenuButton.gameObject.SetActive(false);
        StartCoroutine(IUnoadScene(() => {
            SceneManager.LoadScene("MenuScene");
        }));
    }

    public void Pause() {
        StartCoroutine(ILoadPause());
        reloadButton.gameObject.SetActive(true);
        toMenuButton.gameObject.SetActive(true);
        AudioListener.pause = true;
        pauseState = true;
        Time.timeScale = 0;
    }

    public void Unpause() {
        StartCoroutine(IUnloadPause());
        reloadButton.gameObject.SetActive(false);
        toMenuButton.gameObject.SetActive(false);
        AudioListener.pause = false;
        pauseState = false;
        Time.timeScale = 1;
    }

    IEnumerator ILoadScene() {
        overlay.CrossFadeAlpha(0.0f, 1.0f, true);
        yield return new WaitForSeconds(1.0f);
    }

    IEnumerator IUnoadScene(Action callback) {
        overlay.CrossFadeAlpha(1.0f, 1.0f, true);
        yield return new WaitForSeconds(1.0f);
        callback();
    }

    IEnumerator ILoadPause() {
        overlay.CrossFadeAlpha(0.5f, 0.5f, true);
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator IUnloadPause() {
        overlay.CrossFadeAlpha(0.0f, 0.5f, true);
        yield return new WaitForSeconds(0.5f);
    }


}
