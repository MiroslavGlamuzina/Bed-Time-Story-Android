using UnityEngine;

namespace CompleteProject
{
	public class PlayerShooting : MonoBehaviour
	{
		public int damagePerShot = 20;                  // The damage inflicted by each bullet.
		public float timeBetweenBullets = 0.15f;        // The time between each shot.
		public float range = 100f;                      // The distance the gun can fire.


		float timer;                                    // A timer to determine when to fire.
		Ray shootRay;                                   // A ray from the gun end forwards.
		RaycastHit shootHit;                            // A raycast hit to get information about what was hit.
		int shootableMask;                              // A layer mask so the raycast only hits things on the shootable layer.
		ParticleSystem gunParticles;                    // Reference to the particle system.
		LineRenderer gunLine;                           // Reference to the line renderer.
		AudioSource gunAudio;                           // Reference to the audio source.
		Light gunLight;                                 // Reference to the light component.
		float effectsDisplayTime = 0.2f;                // The proportion of the timeBetweenBullets that the effects will display for.
		private CardboardHead head;
		public InGameMenuVisibility InGameMenuVisibility;
		public PauseScript pausescript;
		public RestartScript restartscript;
		public MainMenuScript mainmenuscript;
		public InGameMenu ingamemenuscript;
		public FBShareScript fbsharescript;

		void Awake ()
		{
			QualitySettings.vSyncCount = 1;
			// Create a layer mask for the Shootable layer.
			shootableMask = LayerMask.GetMask ("Shootable");
			head = Camera.main.GetComponent<StereoController> ().Head;
			// Set up the references.
			gunParticles = GetComponent<ParticleSystem> ();
			gunLine = GetComponent <LineRenderer> ();
			gunAudio = GetComponent<AudioSource> ();
			gunLight = GetComponent<Light> ();
		}

		void Update ()
		{
			head = Camera.main.GetComponent<StereoController> ().Head;
		
			// Add the time since Update was last called to the timer.
			timer += Time.deltaTime;

			//  if ((CrossPlatformInputManager.GetAxisRaw("Mouse X") != 0 || CrossPlatformInputManager.GetAxisRaw("Mouse Y") != 0) && timer >= timeBetweenBullets)
			if ((Input.GetButton ("Fire1") && timer >= timeBetweenBullets) || Cardboard.SDK.CardboardTriggered) {
				// ... shoot the gun
				Shoot ();
			}
	
			// If the timer has exceeded the proportion of timeBetweenBullets that the effects should be displayed for...
			if (timer >= timeBetweenBullets * effectsDisplayTime) {
				// ... disable the effects.
				DisableEffects ();
			}
		}

		public void DisableEffects ()
		{
			// Disable the line renderer and the light.
			gunLine.enabled = false;
			gunLight.enabled = false;
		}

		void Shoot ()
		{
			// Reset the timer.
			timer = 0f;

			// Play the gun shot audioclip.
			gunAudio.Play ();

			// Enable the light.
			gunLight.enabled = true;

			// Stop the particles from playing if they were, then start the particles.
			gunParticles.Stop ();
			gunParticles.Play ();

			// Enable the line renderer and set it's first position to be the end of the gun.
			gunLine.enabled = true;
			gunLine.SetPosition (0, transform.position);

			// Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
			shootRay.origin = transform.position;
			shootRay.direction = transform.forward;

			// Perform the raycast against gameobjects on the shootable layer and if it hits something...
			if (Physics.Raycast (shootRay, out shootHit, range, shootableMask)) {
				StartNewGame ();

//				PauseGame();
				IngameMenuOptions ();
//				ReturnToMainMenu();
				FBShareOption ();
				
				// Try and find an EnemyHealth script on the gameobject hit.
				EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();

				// If the EnemyHealth component exist...
				if (enemyHealth != null) {
					// ... the enemy should take damage.
					enemyHealth.TakeDamage (damagePerShot, shootHit.point);
				}

				// Set the second position of the line renderer to the point the raycast hit.
				gunLine.SetPosition (1, shootHit.point);
			}
            // If the raycast didn't hit anything on the shootable layer...
            else {
				// ... set the second position of the line renderer to the fullest extent of the gun's range.
				gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
			}
		}

		void StartNewGame ()
		{
			//applciation code for objects inside of the main menu scene
			if (Application.loadedLevelName == "MainMenu") {
				RestartScript startgame = shootHit.collider.GetComponent<RestartScript> ();
				if (startgame) {
					restartscript.RestartLevel = true;
					Debug.Log ("MainMenu NEW GAME");
				}
			}
		}

		void FBShareOption ()
		{
			//applciation code for objects inside of the main menu scene
			if (Application.loadedLevelName == "MainMenu") {
				FBShareScript fbshare = shootHit.collider.GetComponent<FBShareScript> ();
				if (fbshare) {
					Debug.Log ("MainMenu FB SHARE");
					fbsharescript.fbshare = true;
				}
			}
		}
//		void PauseGame ()
//		{
//			//applciation code for objects inside of the main menu scene
//			if (Application.loadedLevelName == "Level 01") {
//				PauseScript pauseGame = shootHit.collider.GetComponent<PauseScript> ();
//				if (pauseGame) {
//					Debug.Log ("PAUSE GAME");
//				}
//			}
//		}
		void IngameMenuOptions ()
		{
			if (Application.loadedLevelName == "Level 01") {
				RaycastHit hit;
				Ray ray = Camera.main.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0f));
				if (Physics.Raycast (ray, out hit, 100f, LayerMask.GetMask ("InGameMenu"))) {
					InGameMenu ingamemenu_temp = hit.collider.GetComponent <InGameMenu> ();
					if (Application.loadedLevelName == "Level 01") {
						if (ingamemenu_temp) {
							if (hit.point.x < 1.5f) {
								if (pausescript.pausegame != true) {
									pausescript.Pause ();
								}	
							}
							if (hit.point.x > 1.51f && hit.point.x < 1.9f) {
								if (restartscript.RestartLevel != true) {
									restartscript.RestartLevel = true;
								}
							}
							if (hit.point.x > 1.91f) {
								mainmenuscript.MainMenuToggle = true;
							}
						} 
					}
				}






//				RestartScript restartLevel = shootHit.collider.GetComponent<RestartScript> ();		
//				InGameMenu restartLevel = shootHit.collider.GetComponent<InGameMenu> ();		
//				if (restartLevel) {
//					Debug.Log ("RESTART GAME METHOD");
//					restartscript.RestartLevel = true;
//				}
			}
		}

		void ReturnToMainMenu ()
		{
			//applciation code for objects inside of the main menu scene
			Debug.Log ("RETURN TO MAIN MENU METHOD");
			if (Application.loadedLevelName == "Level 01") {
				Debug.Log ("Applicaiton loaded level fromplayer shootig script");
				MainMenuScript goToMain = shootHit.collider.GetComponent<MainMenuScript> ();
				if (goToMain) {
					mainmenuscript.MainMenuToggle = true;
					Debug.Log ("GO TO MAIN MENU");
				}
			}
		}
	}
}