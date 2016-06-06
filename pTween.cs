using UnityEngine;
using System;
using System.Collections;

// Peter's Tweening Library.

public static class pTween 
{
	public static IEnumerator To(float duration, float startValue, float endValue, Action<float> callback)
	{
		float start = Time.time;
		float end = start + duration;
		float durationInv = 1f / duration;
		float startMulDurationInv = start / duration;
		
		for(float t = Time.time; t < end; t = Time.time)
		{
			callback(Mathf.Lerp(startValue, endValue, t * durationInv - startMulDurationInv));
			yield return null;
		}
		callback(endValue);
	}

	public static IEnumerator To(float duration, Action<float> callback)
	{
		return To(duration, 0f, 1f, callback);
	}

	public static IEnumerator Then(this IEnumerator coroutine, IEnumerator after)
	{
		while (coroutine.MoveNext())
		{
			yield return coroutine.Current;
		}

		while (after.MoveNext())
		{
			yield return after.Current;
		}
	}

	public static IEnumerator Then(this IEnumerator coroutine, Action after)
	{
		while (coroutine.MoveNext())
		{
			yield return coroutine.Current;
		}

		after();
	}

	public static IEnumerator Then(this IEnumerator coroutine, float delay, Action after)
	{
		while (coroutine.MoveNext())
		{
			yield return coroutine.Current;
		}

		yield return new WaitForSeconds(delay);

		after();
	}
}