pTween 
======
The worlds smallest tweening library for Unity. 28 useful lines of code written by [Peter Bruun](http://www.twitter.com/ptrbrn)

### How to use

```cs
// 2 second fade audio in.
StartCoroutine(pTween.To(2f, t => { 
	audio.volume = t; 
}));

// Move game object and change color in 5 seconds.
StartCoroutine(pTween.To(5f, t => { 
	transform.position = Vector3.Lerp(new Vector3(0f, 0f, 0f), new Vector3(10f, 10f, 0f), t);
	renderer.material.color = Color.Lerp(Color.white, Color.red, t);
}));


IEnumerator SequenceCoroutine()
{
	// first rotate object...
	yield return StartCoroutine(pTween.To(2f, 0f, 360f, angle => {
    	transform.localRotation.eulerAngles = new Vector3(0f, angle, 0f);
    }));
    
    // ... then shrink
    yield return StartCoroutine(pTween.To(2f, 1f, 0f, s => {
    	transform.localScale = s * Vector3.one;
    }));
}

```