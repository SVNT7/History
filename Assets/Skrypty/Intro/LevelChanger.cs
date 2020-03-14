using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Animator _animator; // animator - Obrazek, skrypt na MainCamera
   //[SerializeField] private GameObject _obrazek;



    // Update is called once per frame
    void Update()
    {
        
    }
    void setTrigger()
    {
        _animator.SetTrigger("FadeOut");
    }
    public void ChangeLevel()
    {
        SceneManager.LoadScene(3);
    }
    public void Blink()
    {
        _animator.SetTrigger("FadeInOut");
    }
    public void BlinkReset()
    {
        _animator.ResetTrigger("FadeInOut");
    }
}
