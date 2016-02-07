using UnityEngine;
using System.Collections;

public class AnimatedSprite : MonoBehaviour {
	public Sprite[] Sprites;
	public float step = 0.05f;
	public bool repeat;
	public bool start;
	private SpriteRenderer spriteRenderer;
	Coroutine currentCoroutine;
	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		if (start) 
		{
			currentCoroutine = StartCoroutine (ChangeSprite ());
		}
	}

	public void StartAnimation() 
	{
		if (currentCoroutine != null) 
		{
			StopCoroutine (currentCoroutine);
		}

		currentCoroutine = StartCoroutine (ChangeSprite ());
	}

	IEnumerator ChangeSprite()
	{
		int i = -1;
		int max = Sprites.Length - 1;
		while (true) 
		{
			if (i >= max) 
			{
				if (!repeat) 
				{
					yield break;
				} else 
				{
					i = 0;
				}
			} else 
			{
				i++;
			}
			spriteRenderer.sprite = Sprites[i];
			yield return new WaitForSeconds (step);
		}
	}
}
