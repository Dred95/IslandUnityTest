using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
	public SpriteRenderer caveSrpiteRenederer;
	public Sprite[] caveSprites;
	public Text[] smallCircleTexts;
	public Text[] bigCircleTexts;
	public Image awardSrpiteRenederer;
	public AnimatedSprite[] cavemans;
	public AnimatedSprite explosion;

	private int clicksToDestroy = 3;
	private int currentClicks = 0;

	private struct three
	{
		public int alive;
		public int achived;
		public int cost;
	}

	private three black;
	private three red;
	private three green;
	private three white;

	private int award;




	// Use this for initialization
	void Start () {

		black.alive = 100;
		red.alive = 100;
		green.alive = 100;
		white.alive = 100;

		SetNewCave ();
	}

	public void OnClick()
	{

		if (currentClicks >= clicksToDestroy - 1) 
		{
			if (!TryDestroyCave ()) 
			{
				return;
			}
		}

		currentClicks = currentClicks < clicksToDestroy - 1 ? currentClicks + 1 : 0;
		caveSrpiteRenederer.sprite = caveSprites [currentClicks];
		if (currentClicks == 0) 
		{
			switch (award) 
			{
			case 0:
				black.achived++;
				break;
			case 1:
				red.achived++;
				break;
			case 2:
				green.achived++;
				break;
			case 3:
				white.achived++;
				break;
			}
			SetNewCave ();
			explosion.StartAnimation ();
		}
	}

	bool TryDestroyCave()
	{
		black.alive -= Mathf.Clamp (black.cost - black.achived, 0, 4);
		red.alive -= Mathf.Clamp (red.cost - red.achived, 0, 4);
		green.alive -= Mathf.Clamp (green.cost - green.achived, 0, 4);
		white.alive -= Mathf.Clamp (white.cost - white.achived, 0, 4);

		return black.alive >= 0 && red.alive >= 0 && green.alive >= 0 && white.alive >= 0;
	}

	void SetNewCave()
	{

		if (black.cost > 0) 
		{
			cavemans [0].StartAnimation ();
		}
		if (red.cost > 0) 
		{
			cavemans [1].StartAnimation ();
		}
		if (green.cost > 0) 
		{
			cavemans [2].StartAnimation ();
		}
		if (white.cost > 0) 
		{
			cavemans [3].StartAnimation ();
		}

		black.cost = Random.Range (0, 5);
		red.cost = Random.Range (0, 5);
		green.cost = Random.Range (0, 5);
		white.cost = Random.Range (0, 5);

		award = Random.Range (0, 4);

		UpdateUI ();
	}

	void UpdateUI()
	{
		smallCircleTexts [0].text = "" + black.cost;
		smallCircleTexts [1].text = "" + red.cost;
		smallCircleTexts [2].text = "" + green.cost;
		smallCircleTexts [3].text = "" + white.cost;

		bigCircleTexts [0].text =  black.alive + "/" + black.achived;
		bigCircleTexts [1].text =  red.alive + "/" + red.achived;
		bigCircleTexts [2].text = green.alive + "/" + green.achived;
		bigCircleTexts [3].text = white.alive + "/" + white.achived;

		switch (award) 
		{
		case 0:
			awardSrpiteRenederer.color = Color.black;
			break;
		case 1:
			awardSrpiteRenederer.color = Color.red;
			break;
		case 2:
			awardSrpiteRenederer.color = new Color (62f / 255f, 219f / 255f, 52f / 255f);
			break;
		case 3:
			awardSrpiteRenederer.color = Color.white;
			break;
		}



	}
	// Update is called once per frame
	void Update () {
	
	}
}
