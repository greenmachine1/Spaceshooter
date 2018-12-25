using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrapController : MonoBehaviour {

    public int scrapAmount;
    public float scrapSpeed = 0.0f;
    MeshRenderer _meshRenderer;

    public float timeToStartFlashing = 0.0f;
    public float timeToExpire = 0.0f;
    public float flashTime = 0.0f;
    float originalFlashTime = 0.0f;
    float originalOnTime = 0.0f;

    //bool isVisible = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameController.GC.shipScrap += scrapAmount;
            Destroy(this.transform.parent.gameObject);
        }
    }

    private void Start()
    {
        _meshRenderer = this.gameObject.GetComponent<MeshRenderer>();
        originalOnTime = timeToExpire;
        originalFlashTime = flashTime;

    }

    private void FixedUpdate()
    {
        timeToStartFlashing -= Time.deltaTime;
        if (timeToStartFlashing < 0){
            
            flashTime -= Time.deltaTime;
            if (flashTime < 0)
            {
                if (_meshRenderer.enabled == true)
                {
                    _meshRenderer.enabled = false;
                    flashTime = originalFlashTime;
                }
                else
                {
                    _meshRenderer.enabled = true;
                    flashTime = originalFlashTime;
                }


            }
            timeToExpire -= Time.deltaTime;
            if (timeToExpire < 0)
            {
                Destroy(this.gameObject.transform.parent.gameObject);
            }

        }
    }

}
