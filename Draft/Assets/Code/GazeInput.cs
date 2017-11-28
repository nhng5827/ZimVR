using UnityEngine;

public class GazeInput : MonoBehaviour
{
	private Ray ray;
	private RaycastHit hitInfo;

	[SerializeField]
	[Tooltip("The root object of all menu items")]
	private GameObject menuRoot;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (menuRoot.activeInHierarchy == false)
			{
				ShowMenu();
			}
			else
			{
				TrySelectMenuItem();
			}
		}
	}

	private void TrySelectMenuItem()
	{
		ray = new Ray(transform.position, transform.forward);
		if (Physics.Raycast(ray, out hitInfo))
		{
			var videoSelection = hitInfo.collider.GetComponent<VideoSelection>();
			if (videoSelection != null)
			{
				videoSelection.StartClipIfNotAlreadyPlaying();
				HideMenu();
			}
		}
		else
		{
			HideMenu();
		}
	}

	private void ShowMenu()
	{
		menuRoot.SetActive(true);
	}

	private void HideMenu()
	{
		menuRoot.SetActive(false);
	}
}