using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace VRStandardAssets.Utils
{
    // This class simply allows the user to return to the main menu.
    public class GotoNavigationPortal : MonoBehaviour
    {
        [SerializeField] private VRInput m_VRInput;                     // Reference to the VRInput in order to know when Cancel is pressed.
        [SerializeField] private GameObject player;
		[SerializeField] private float loc_X = 0f;
		[SerializeField] private float loc_Y = 1.1f;
		[SerializeField] private float loc_Z = 0f;
		[SerializeField] private VRCameraFade m_CameraFade; 
		[SerializeField] private string m_MenuSceneName = "MainMenu"; 

		public bool inNavigation = true;

		//private PlayerState playerState = gameObject.GetComponent<PlayerState>();

        private void OnEnable ()
        {
            m_VRInput.OnCancel += HandleCancel;
        }


        private void OnDisable ()
        {
            m_VRInput.OnCancel -= HandleCancel;
        }


        private void HandleCancel ()
        {
            StartCoroutine (FadeToMenu ());
        }


        private IEnumerator FadeToMenu ()

        {

			PlayerState playerState = player.GetComponent<PlayerState>();
			playerState.oldLocation=player.transform.position;

				// Wait for the screen to fade out.
				//yield return StartCoroutine (m_CameraFade.BeginFadeOut (true));


				// Load the main menu by itself.
				//SceneManager.LoadScene(m_MenuSceneName, LoadSceneMode.Single);


            // Wait for the screen to fade out.
			yield return StartCoroutine (m_CameraFade.BeginFadeOut (true));

			//playerState.oldLocation = player.transform.position;

			player.transform.position = new Vector3(loc_X,loc_Y,loc_Z);
			m_CameraFade.transform.rotation = Quaternion.identity;

			yield return StartCoroutine(m_CameraFade.BeginFadeIn(true));
        }
    }
}