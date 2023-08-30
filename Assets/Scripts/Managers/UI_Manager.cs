using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    public GameObject buttonsPanel;

    private void Update()
    {
        DetectObject();
    }

    public void ShowButtonsPanel(bool isActive)
    {
        buttonsPanel.SetActive(isActive);
    }

    public void ChangeSceneTo(int numScene)
    {
        SceneManager.LoadScene(numScene);
    }
    
    private void DetectObject()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePos);
            if (targetObject != null)
            {
                if (targetObject.CompareTag("Player"))
                {
                    targetObject.GetComponent<Animator>().SetTrigger("isRun");
                }
                else if (targetObject.CompareTag("Gem"))
                {
                    ShowButtonsPanel(true);
                }
            }
        }
    }
}
