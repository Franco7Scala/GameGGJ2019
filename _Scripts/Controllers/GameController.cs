using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {
    public Image overlay;


    void Start() {
        StartCoroutine(ILoadScene());
    }

    public void ReloadScene() {
        StartCoroutine(IUnoadScene(() => {
            SceneManager.LoadScene("MainScene");
        }));
    }

    public void ToMenu() {
        StartCoroutine(IUnoadScene(() => {
            SceneManager.LoadScene("MenuScene");
        }));
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


}
