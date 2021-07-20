using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Got_it_button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // current position
    private Vector3 currentPos;

    private void Start()
    {
        currentPos= this.transform.position;
    }
    /// <summary>
    /// when pointer enters, what is going to happen
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOMove(currentPos + Vector3.right * 1, 0.2f, false);
    }

    /// <summary>
    /// when pointer leaves, what is going to happen
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOMove(currentPos, 0.2f, false);
    }
}
