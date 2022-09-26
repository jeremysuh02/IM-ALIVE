using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuTransition : MonoBehaviour
{
    public string firstLevel;

    public GameObject optionsScreen;

    public GameObject storyScreen1;

    public GameObject continueScreen;

    public GameObject finalScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(firstLevel);
    }

    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
        Debug.Log("Closed");
    }

    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
    }


    public void StartStory()
    {
        storyScreen1.SetActive(true);
    }

    public void ContinueStory()
    {
        continueScreen.SetActive(true);
    }

    public void FinalStory()
    {
        finalScreen.SetActive(true);
    }
    
    public void StopStory()
    {
        storyScreen1.SetActive(false);
        continueScreen.SetActive(false);
        finalScreen.SetActive(false);
    }
    
}

