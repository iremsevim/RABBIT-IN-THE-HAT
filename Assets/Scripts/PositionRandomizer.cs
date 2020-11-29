using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class PositionRandomizer : MonoBehaviour
{
    public List<Transform> allhats;
    public float hatspeed;
    public int mixercount = 5;
    [Space(15)]
    public UnityEvent OnHatMixedFinished;
    
    public UnityEvent OnHatMixedStarted;
    public UnityEvent OnAnyState;
    public GameObject newcursor;
    public AudioClip trueaudio;
   

  

    public void Start()
    {
        StartCoroutine(HatMixerTimer());
        Cursor.visible = false;
    }
    public void Update()
    {
        newcursor.transform.position=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 cursor = newcursor.transform.position;
        cursor.z = 0;
        newcursor.transform.position = cursor;
    }
    public IEnumerator ReStartIE()
    {
        yield return new WaitForSeconds(2f);
        Start();

    }
    public void ReStart()
    {
        StartCoroutine(ReStartIE());
    }

    public void StartShuffle()
    {
         List<Vector3> allhottpos=allhats.ConvertAll(x => x.transform.position);
        Utility.Shuffle(allhats);

        for (int i = 0; i < allhats.Count; i++)
        {
            allhats[i].transform.DOMove(allhottpos[i],Random.Range(hatspeed*.75f,hatspeed*1.2f));
        }
    }
    public IEnumerator HatMixerTimer()
    {
        OnHatMixedStarted?.Invoke();
        for (int i = 0; i < mixercount; i++)
        {
            yield return new WaitForSeconds(hatspeed + 0.5f);
            StartShuffle();
            OnAnyState?.Invoke();
        }
        OnHatMixedFinished?.Invoke();
    }
    public void PlayAudio()
    {
        GameObject newaudio = new GameObject();
        newaudio.AddComponent<AudioSource>().PlayOneShot(trueaudio);
    }
}
public static class Utility
{
    private static System.Random rng = new System.Random();
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}


