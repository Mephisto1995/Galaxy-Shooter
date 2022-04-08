using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

public class MainMenuManager : MonoBehaviour
{
    public void LoadGame()
    {
        HelperFunctions.LoadScene(Constants.SCENE_GAME);
    }
}
