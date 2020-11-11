using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    private Animator myAnim;

    private void Start()
    {
        myAnim = GetComponent<Animator>();
        StartCoroutine(WaitToFadeOut());
    }

    IEnumerator WaitToFadeOut()
    {
        yield return new WaitForSeconds(2);
        FadeOut();
    }

    public void FadeOut()
    {
        myAnim.SetTrigger("FadeOut");
        StartCoroutine(DestoryOnComplete());
    }

    IEnumerator DestoryOnComplete()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

}
