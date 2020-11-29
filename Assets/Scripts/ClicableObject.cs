using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class ClicableObject : MonoBehaviour
{
    public UnityEvent OnClicked;
    public Vector3 finishedscale;
    


  

    public void OnMouseUpAsButton()
    {
        OnClicked?.Invoke();
        ClickEffect();
    }

    public void ClickEffect()
    {
        Vector3 firstscale = transform.localScale;
        transform.DOScale(transform.localScale + finishedscale, 0.15f).OnComplete(()=> 
        {
            transform.DOScale(firstscale, 0.15f);
        });  
    }
    
   

}
