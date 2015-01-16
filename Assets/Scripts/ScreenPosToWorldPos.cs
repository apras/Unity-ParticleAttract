using UnityEngine;
using System.Collections;

public class ScreenPosToWorldPos : MonoBehaviour
{
	private Camera m_camera;

	void Start()
	{
		GameObject _cameraObj = GameObject.FindWithTag("MainCamera");
		if (_cameraObj == null )
			Debug.LogError("GameObject missing: MainCamera");

		this.m_camera = _cameraObj.GetComponent<Camera>();
	}
	
	void Update()
	{
		if(this.m_camera != null)
		{
			if(Input.GetMouseButton(0))
			{
				Vector2 _mousePosition = Input.mousePosition;
				Vector3 _worldPosition = this.m_camera.ScreenToWorldPoint(new Vector3(_mousePosition.x, _mousePosition.y, 1000));
				this.transform.position = _worldPosition;
			}
		}
	}
}
