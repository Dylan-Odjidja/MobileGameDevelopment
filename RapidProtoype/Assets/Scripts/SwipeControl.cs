using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeControl : MonoBehaviour, IEndDragHandler
{
    [SerializeField] int maxPage;
    int currentPage;
    Vector3 targetPos;
    [SerializeField] Vector3 pageStep;
    [SerializeField] RectTransform levelPagesRect;

    [SerializeField] float tweenTime;
    [SerializeField] LeanTweenType tweenType;
    float dragThreshold;

    [SerializeField] Image[] barImage;
    [SerializeField] Sprite barClosed, barOpen;

    [SerializeField] Button previousButton, nextButton;

    public void Awake()
    {
        currentPage = 1;
        targetPos = levelPagesRect.localPosition;
        dragThreshold = Screen.width / 15;
        UpdateBar();
        UpdateArrowButton();
    }

    public void Next()
    {
        if (currentPage < maxPage)
        {
            currentPage++;
            targetPos += pageStep;
            MovePage();
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (Math.Abs(eventData.position.x - eventData.pressPosition.x) > dragThreshold)
        {
            if (eventData.position.x > eventData.pressPosition.x)
            {
                Previous();
            }
            else
            {
                Next();
            }
        }
        else
        {
            MovePage();
        }
    }

    public void Previous()
    {
        if (currentPage > 1)
        {
            currentPage--;
            targetPos -= pageStep;
            MovePage();
        }
    }

    void MovePage()
    {
        levelPagesRect.LeanMoveLocal(targetPos, tweenTime).setEase(tweenType);
        UpdateBar();
        UpdateArrowButton();
    }

    void UpdateBar()
    {
        foreach (var item in barImage)
        {
            item.sprite = barClosed;
        }
        barImage[currentPage - 1].sprite = barOpen;
    }

    void UpdateArrowButton()
    {
        nextButton.interactable = true;
        previousButton.interactable = true;
        if (currentPage == 1)
        {
            previousButton.interactable = false;
        }
        else if (currentPage == maxPage)
        {
            nextButton.interactable = false;
        }
    }
}
