using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagement : MonoBehaviour
{
    [SerializeField] private string nextLevel;

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
