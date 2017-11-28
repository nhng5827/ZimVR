using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoSelection : MonoBehaviour
{
	[SerializeField]
	private VideoClip videoClip;

	private VideoPlayer videoPlayer;

	private void Start()
	{
		videoPlayer = FindObjectOfType<VideoPlayer>();
	}

	private void OnTriggerEnter(Collider collider)
	{
		StartClipIfNotAlreadyPlaying();
	}

	public void StartClipIfNotAlreadyPlaying()
	{
		if (videoPlayer.clip != videoClip)
		{
			videoPlayer.clip = videoClip;
			videoPlayer.Play();
		}
	}
}