using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManeger : MonoBehaviour
{

    public void TwoPlayers()
    {
        SceneManager.LoadScene("2 Players");
    }
    public void OnePlayer()
    {
        SceneManager.LoadScene("1 Player");
    }
}
