using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator animator;
    public GameObject Obrazek;


    void Start()
    {
        animator = Obrazek.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void setTrigger()
    {
        animator.SetTrigger("FadeOut");
    }
    public void ChangeLevel()
    {
        SceneManager.LoadScene(3);
    }
    public void Blink()
    {
        animator.SetTrigger("FadeInOut");
    }
    public void BlinkReset()
    {
        animator.ResetTrigger("FadeInOut");
    }
}
