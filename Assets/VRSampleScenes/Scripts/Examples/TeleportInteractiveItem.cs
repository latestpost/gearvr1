using UnityEngine;
using VRStandardAssets.Utils;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;

namespace VRStandardAssets.Examples
{
    // This script is a simple example of how an interactive item can
    // be used to change things on gameobjects by handling events.
    public class TeleportInteractiveItem : MonoBehaviour
    {
        [SerializeField] private Material m_NormalMaterial;                
        [SerializeField] private Material m_OverMaterial;                  
        [SerializeField] private Material m_ClickedMaterial;               
        [SerializeField] private Material m_DoubleClickedMaterial;         
        [SerializeField] private VRInteractiveItem m_InteractiveItem;
        [SerializeField] private Renderer m_Renderer;
		[SerializeField] private VRCameraFade m_CameraFade; 
		[SerializeField] private float loc_X = 0f;
		[SerializeField] private float loc_Y = 1.1f;
		[SerializeField] private float loc_Z = 0f;
		[SerializeField] private GameObject player;

		private Vector3 oldLocation;

        private void Awake ()
        {
            m_Renderer.material = m_NormalMaterial;
        }


        private void OnEnable()
        {
            m_InteractiveItem.OnOver += HandleOver;
            m_InteractiveItem.OnOut += HandleOut;
            m_InteractiveItem.OnClick += HandleClick;
            m_InteractiveItem.OnDoubleClick += HandleDoubleClick;
        }


        private void OnDisable()
        {
            m_InteractiveItem.OnOver -= HandleOver;
            m_InteractiveItem.OnOut -= HandleOut;
            m_InteractiveItem.OnClick -= HandleClick;
            m_InteractiveItem.OnDoubleClick -= HandleDoubleClick;
        }


        //Handle the Over event
        private void HandleOver()
        {
            Debug.Log("Show over state");
            m_Renderer.material = m_OverMaterial;
        }


        //Handle the Out event
        private void HandleOut()
        {
            Debug.Log("Show out state");
            m_Renderer.material = m_NormalMaterial;
        }


        //Handle the Click event
        private void HandleClick()
        {
            Debug.Log("Show click state");
            m_Renderer.material = m_ClickedMaterial;
			StartCoroutine (ActivateButton());
        }

		private IEnumerator ActivateButton()
		{
			// If the camera is already fading, ignore.
			if (m_CameraFade.IsFading)
				yield break;

			// Wait for the camera to fade out.
			yield return StartCoroutine(m_CameraFade.BeginFadeOut(true));

			Debug.Log(m_InteractiveItem.gameObject.name);
			Debug.Log(oldLocation);

			if (m_InteractiveItem.gameObject.name == "Exit") {
				PlayerState playerState = player.GetComponent<PlayerState>();
				player.transform.position = playerState.oldLocation;
				GameObject navPanel = GameObject.Find("NavPanel");
				GotoNavigationPortal gotoNavigationPortal = navPanel.GetComponent<GotoNavigationPortal>();
				gotoNavigationPortal.inNavigation = false;
			}
			else {
				player.transform.position = new Vector3(loc_X,loc_Y,loc_Z);
			}

			yield return StartCoroutine(m_CameraFade.BeginFadeIn(true));

		}

		public void UpdateLocation(Vector3 location) {
			loc_X = location.x;
			loc_Y = location.y;
			loc_Z = location.z;
			Debug.Log("updated item!");
		}


        //Handle the DoubleClick event
        private void HandleDoubleClick()
        {
            Debug.Log("Show double click");
            m_Renderer.material = m_DoubleClickedMaterial;
        }
    }

}