using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;//for the Info switchin;
using UnityEngine.EventSystems;

public class MainMenuScript : MonoBehaviour {

    public EventSystem eventSystem;
    public GameObject selectedObject;
    private bool buttonSelected;

    private void Update()
    {
        if (Input.GetAxisRaw("Vertical") != 0 & buttonSelected == false)
        {
            eventSystem.SetSelectedGameObject(selectedObject);
            buttonSelected = true;
        }
    }
    private void OnDisable()
    {
        buttonSelected = false;
    }

    //play the first level, after menu. Scene wise
    public void PlayGame() {SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);}
    //load from a set number, build index wise
    public void LoadByIndex(int sceneIndex) {SceneManager.LoadScene(sceneIndex);}
    public void LoadGame() { }//to load 'saved' save state, scene/save database management wise
    
    public void QuitGame() {
        Debug.Log("Game has closed");

        //cue conditional #define statement
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
		        Application.Quit();
        #endif
    }
}