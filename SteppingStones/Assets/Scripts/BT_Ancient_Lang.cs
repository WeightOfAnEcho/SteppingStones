using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Ancient_Lang : MonoBehaviour
{
    private Renderer rend;
    public Material mouseOverColor;
    public Material originalColor;
    public ParticleSystem glow;

    public BT_Tutorial_Player tutorialPlayer;

    // Start is called before the first frame update
    void Start()
    {
        // Fetch the Renderer from the GameObject
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                // whatever tag you are looking for on your game object
                if (hit.collider.tag == "Lang")
                {
                    tutorialPlayer.hadTutorialLang = true;
                    StartCoroutine(tutorialPlayer.FadeTextToZeroAlpha(1f, tutorialPlayer.tutorialLang));
                    tutorialPlayer.tutorialLangParticle.Stop();
                    StartCoroutine(WaitFor (1));
                    
                }
            }
        }
    }

    void OnMouseOver()
    {
        glow.Play();
        rend.material = mouseOverColor;
    }

    void OnMouseExit()
    {
        glow.Stop();
        rend.material = originalColor;
    }

    IEnumerator WaitFor(int seconds) // delay coroutine for number of seconds delay
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }
}
