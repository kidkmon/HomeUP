using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour {

	[Header("Panel")]
	[SerializeField] private GameObject pausePanel;
	[SerializeField] private GameObject bgBlackPanel;

	[Header("HUD Animator Controllers")]
	[SerializeField] private Animator continueBtnAnim;
	[SerializeField] private Animator gameOverPanelAnim;
	[SerializeField] private Animator medalIconAnim;
	[SerializeField] private Animator menuBtnAnim;
	[SerializeField] private Animator pauseBtnAnim;
	[SerializeField] private Animator playAgainBtnAnim;
	[SerializeField] private Animator rankingBtnAnim;
	[SerializeField] private Animator restartBtnAnim;
	[SerializeField] private Animator transitionAnim;

	private GameObject player;
	private GameObject follow;

	void Start(){
		player = GameObject.FindGameObjectWithTag("Player");
		follow = GameObject.FindGameObjectWithTag("Follow");
		pausePanel.SetActive(false);
		bgBlackPanel.SetActive(false);
	}

	public void ContinueButton(){
		StartCoroutine(StartPauseExitAnimation());
	}

	public void MenuButton(){
		StartCoroutine(StartMenuAnimation());
	}

	public void PauseButton(){
		bool pauseIsActive = pausePanel.activeInHierarchy;

		if(pauseIsActive){
			StartCoroutine(StartPauseExitAnimation());
		}
		else{
			player.SetActive(pauseIsActive);
			follow.SetActive(pauseIsActive);
			bgBlackPanel.SetActive(!pauseIsActive);
			pausePanel.SetActive(!pauseIsActive);
		}
	}

	public void RankingButton(){
		StartCoroutine(StartRankingAnimation());
	}

	public void RestartButton(){
		StartCoroutine(StartRestartAnimation());
	}
	
	IEnumerator StartMenuAnimation(){
		menuBtnAnim.SetTrigger("Exit");
		pauseBtnAnim.SetTrigger("Exit");
		yield return new WaitForSeconds(.6f);
		transitionAnim.SetTrigger("Exit");
		yield return new WaitForSeconds(.6f);
		SceneManager.LoadScene("Start");
	}

	IEnumerator StartPauseExitAnimation(){
		continueBtnAnim.SetTrigger("Exit");
		pauseBtnAnim.SetTrigger("Exit");
		yield return new WaitForSeconds(.6f);
		pausePanel.SetActive(false);
		bgBlackPanel.SetActive(false);
		player.SetActive(true);
		BoyMovement.gameStarted = true;
		follow.SetActive(true);
	}

	IEnumerator StartRankingAnimation(){
		medalIconAnim.SetTrigger("Exit");
		rankingBtnAnim.SetTrigger("Exit");
		pauseBtnAnim.SetTrigger("Exit");
		yield return new WaitForSeconds(.6f);
		//Faltando implementar
		pausePanel.SetActive(false);
		bgBlackPanel.SetActive(false);
		player.SetActive(true);
		follow.SetActive(true);
	}

	IEnumerator StartRestartAnimation(){
		if(gameOverPanelAnim.gameObject.activeInHierarchy){
			playAgainBtnAnim.SetTrigger("Exit");
			gameOverPanelAnim.SetTrigger("Exit");
			yield return new WaitForSeconds(.4f);
		}
		else{
			restartBtnAnim.SetTrigger("Exit");
			pauseBtnAnim.SetTrigger("Exit");
			yield return new WaitForSeconds(.6f);
		}
		
		transitionAnim.SetTrigger("Exit");
		yield return new WaitForSeconds(.6f);
		SceneManager.LoadScene("Game");
	}
}
