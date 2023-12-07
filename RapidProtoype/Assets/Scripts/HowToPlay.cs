using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    public GameObject menu;

    public void Help()
    {
        menu.SetActive(true);
    }

    public void Close()
    {
        menu.SetActive(false);
    }
}
