using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class StartButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        SoundManager._instance.ClickSoundPlay();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.transform.DOScale(0.9f, 0.3f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.transform.DOScale(0.8f, 0.3f);
    }

}
