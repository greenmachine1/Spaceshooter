using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

    private List<GameObject> instantiatedBackgroundObjects = new List<GameObject>();

	public GameObject player;

	public int layer;
    public float zPosition;
    public float velocity;
	public bool sideParallaxEnabled = true;
    public float sideParallaxSpeed; 
	private float cameraViewHeight;
	private float cameraCenter;
	private float bottomEdgeOfCamera;
	private float heightOfBackground;
	private Object[] textures;

	public int scrollCount = 0;
	
	new Camera camera;
	
	void Start () {
		camera = Camera.main;
		camera.enabled = true;
		
		if(layer == 0){
			textures = Resources.LoadAll("Materials/Backgrounds", typeof(Texture2D));
		}if(layer == 1){
			textures = Resources.LoadAll("Materials/StarsLayer", typeof(Texture2D));
		}if(layer == 2){
            textures = Resources.LoadAll("Materials/Nebula",typeof(Texture2D));
        }

		// getting the camera position and its height //
		cameraViewHeight = 2f * camera.orthographicSize;
		cameraCenter = camera.transform.position.y;
		bottomEdgeOfCamera = cameraCenter - (cameraViewHeight / 2);
		heightOfBackground = 0.0f;

		// setting this to one for the initial background placement //
		scrollCount = 1;

		for(var i = 0; i < 2; i++){
			
			// instantiating new background elements //
			GameObject backgroundElement = (GameObject)Instantiate(Resources.Load("backgroundElement"));
			
			backgroundElement.transform.position = new Vector3(0.0f, i * heightOfBackground, zPosition);

			// gaining access to the backgroundElements script //
			BackgroundElement backgroundElementScript = backgroundElement.GetComponent<BackgroundElement>();
			backgroundElementScript.scrollRate = velocity;
			
			// after a background object has been instantiated, we can grab its height and use it //
			heightOfBackground = backgroundElement.GetComponent<Renderer>().bounds.size.y;

			// getting a random texture and applying it to the background object //
			Texture2D backgroundTextures = (Texture2D)textures[Random.Range(0, textures.Length)];
			backgroundElement.GetComponent<Renderer>().material.mainTexture = backgroundTextures;
			instantiatedBackgroundObjects.Add(backgroundElement);
		}
	}
	
	void FixedUpdate () {
		foreach(var backgrounds in instantiatedBackgroundObjects){

			float positionOfCenterBackground = backgrounds.transform.position.y;
			float topEdgeOfBackground = positionOfCenterBackground + (heightOfBackground / 2.0f);

			// detecting when the bottom of the camera has reached the top edge of //
			// the background //
			if((int)(topEdgeOfBackground) <= (int)(bottomEdgeOfCamera)){
				float yPositionOfRemainingBackground = backgrounds.transform.position.y;

				// getting a random texture and applying it to the background object //
                Texture2D backgroundTextures = (Texture2D)textures[Random.Range(0, textures.Length)];
				backgrounds.GetComponent<Renderer>().material.mainTexture = backgroundTextures;
                backgrounds.transform.position = new Vector3(0.0f, 
					yPositionOfRemainingBackground + (heightOfBackground * instantiatedBackgroundObjects.Count - 1) + 1.0f, 
					zPosition);

			    // we dont really need to mind the star layer for the background count //
				// this will just keep track of how many true backgrounds have gone by .. //
				if(player == null){
					scrollCount++;
               
				}
            }

			if(player != null){
				if(sideParallaxEnabled == true){
					backgrounds.transform.position = new Vector3(player.transform.position.x * sideParallaxSpeed, 
					backgrounds.transform.position.y, 
					backgrounds.transform.position.z);
				}
			}
        }
	}
}
