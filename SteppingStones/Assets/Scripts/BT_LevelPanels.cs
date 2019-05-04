using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BT_LevelPanels : MonoBehaviour
{

    public Animator panelLoader;
    private AudioSource source;
    public AudioClip Click;

    public CanvasGroup raycastBlock;

    // Start is called before the first frame update
    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        print("click");
        source.PlayOneShot(Click);
    }

    public void RemoveBlock()
    {
        raycastBlock.blocksRaycasts = false;
    }

    public void LoadScene()
    {
        PlaySound();
        RemoveBlock();
        panelLoader.SetTrigger("FadeOutPanel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
