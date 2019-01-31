using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeScene : MonoBehaviour {

	[Header("Animator Controllers")]
	[SerializeField] private Animator btnPlayAnim;
	[SerializeField] private Animator creditsAnim;
	[SerializeField] private Animator logoAnim;
	[SerializeField] private Animator transitionAnim;
	
	[Header("Name of the Scene")]
	[SerializeField] private string sceneName;

	[Header("Time of Exit Animations")]
	[SerializeField] private float frontExit;
	[SerializeField] private float fadeExit;

	public void StartGame(){
		StartCoroutine(StartTransition());
	}

	IEnumerator StartTransition(){
		btnPlayAnim.SetTrigger("Exit");
		creditsAnim.SetTrigger("Exit");
		logoAnim.SetTrigger("Exit");
		yield return new WaitForSeconds(frontExit);
		transitionAnim.SetTrigger("Start");
		yield return new WaitForSeconds(fadeExit);
		SceneManager.LoadScene(sceneName);
	}

}
