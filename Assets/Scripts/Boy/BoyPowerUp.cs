using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyPowerUp : MonoBehaviour {

	[Header("Power Ups Controller")]
	[SerializeField] private float powerUpCake;
	[SerializeField] private float powerUpCandy;
	[SerializeField] private float powerUpFruit;
	[SerializeField] private float powerUpPizza;
	public float powerUpTenis;

	private StaminaController stamina;

	void Start(){
		stamina = GetComponent<StaminaController>();
	}

	//Power Ups logic
	void CakePowerUp(){
		stamina.StaminaBonus(powerUpCake);
	}

	void CandyPowerUp(){
		stamina.StaminaBonus(powerUpCandy);
	}

	void FruitPowerUp(){
		stamina.StaminaBonus(powerUpFruit);
	}

	void PizzaPowerUp(){
		stamina.StaminaBonus(powerUpPizza);
	}

	IEnumerator TenisPowerUp(){
		GetComponent<BoyMovement>().tenisPowerUp = true;
		yield return new WaitForSeconds(1f);
		GetComponent<BoyMovement>().tenisPowerUp = false;
	}

	void PowerUps(int powerUpNumber){
		if(powerUpNumber.Equals(1)){
			CandyPowerUp();
		}
		else if(powerUpNumber.Equals(2)){
			CakePowerUp();
		}
		else if(powerUpNumber.Equals(3)){
			FruitPowerUp();
		}
		else if(powerUpNumber.Equals(4)){
			PizzaPowerUp();
		}
		else if(powerUpNumber.Equals(5)){
			StartCoroutine(TenisPowerUp());
		}
	}

	//Collider logic
    void OnControllerColliderHit(ControllerColliderHit hit){
        if(hit.gameObject.CompareTag("PowerUp")){
			StartCoroutine(DestroyPowerUp(hit.gameObject.GetComponent<Animator>(), hit.gameObject));
        }
    }

	IEnumerator DestroyPowerUp(Animator animator, GameObject powerUp){
		animator.SetTrigger("Destroy");
		powerUp.GetComponent<BoxCollider>().isTrigger = true;
		GetComponents<AudioSource>()[1].Play();
		PowerUps(animator.GetInteger("PowerUp"));
		yield return new WaitForSeconds(0.3f);
		powerUp.SetActive(false);
		powerUp.GetComponent<BoxCollider>().isTrigger = false;
    }
}
