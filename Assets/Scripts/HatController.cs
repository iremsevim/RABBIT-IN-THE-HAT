using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HatController : MonoBehaviour
{
    public Transform rabbitobject;
    public Transform rabbitmovementstartpoint;
    public Transform rabbitmovementfinishedpoint;


    public void RabbitIn()
    {
        rabbitobject.DOMove(rabbitmovementfinishedpoint.position,1.25f);
    }
    public void RabbitOut()
    {
        rabbitobject.DOMove(rabbitmovementstartpoint.position,1f);
    }

}
