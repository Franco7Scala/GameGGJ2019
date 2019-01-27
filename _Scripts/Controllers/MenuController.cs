using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour {
    public Image overlay;


    void Start() {
        StartCoroutine(ILoadMenu());
    }

    public void PlayAsMale() {
        StartCoroutine(IUnloadMenu( () => {
            PlayerPrefs.SetInt("skin", 1);
            SceneManager.LoadScene("MainScene");
        }));
    }

    public void PlayAsFemale() {
        StartCoroutine(IUnloadMenu( () => {
            PlayerPrefs.SetInt("skin", 0);
            SceneManager.LoadScene("MainScene");
        }));
    }

    public void Reset() {
        PlayerPrefs.DeleteAll();
    }

    IEnumerator ILoadMenu() {
        overlay.CrossFadeAlpha(0.0f, 1.0f, true);
        yield return new WaitForSeconds(1.0f);
    }

    IEnumerator IUnloadMenu(Action callback) {
        overlay.CrossFadeAlpha(1.0f, 1.0f, true);
        yield return new WaitForSeconds(1.0f);
        callback();
    }


}
