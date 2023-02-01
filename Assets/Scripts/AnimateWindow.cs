using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimateWindow : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    [SerializeField] private Animator canvasAnimator;
    [Header("Sounds")]
    [SerializeField] private AudioSource windowMoving;
    private bool isCanTouch = true;

    public void SetAnswer(int button)
    {
        if(isCanTouch == true)
        {
            isCanTouch = false;
            buttons[button].GetComponent<Animator>().SetTrigger("Select");
            StartCoroutine(AnimateButton());
        }
    }
    private IEnumerator AnimateButton()
    {
        windowMoving.Play();
        yield return new WaitForSeconds(0.5f);
        canvasAnimator.SetTrigger("Next");
    }
    public void GoPreviousWindow()
    {
        windowMoving.Play();
        canvasAnimator.SetTrigger("Previous");
        isCanTouch = true;
    }
}
