using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;

public class IconMenuUI : MonoBehaviour
{

	public GameObject togglePrefab;
	public RectTransform parentRect;
    public bool oneByOne = false;

	[System.Serializable]
	public class IconMenu
	{
		public Canvas canvas;
		public Toggle toggle;
	} 

	public IconMenu[] iconMenus;


	// Use this for initialization
	void Start ()
	{
        
        foreach (IconMenu im in iconMenus) {
			if (im.toggle == null)
				continue;
			
            im.toggle.isOn = false;
			im.toggle.onValueChanged.AddListener(
				(b)=>{ToggleCanvas(im.toggle);}
			);

            im.canvas.gameObject.SetActive(false);
            im.canvas.enabled = false;
        }

	}

    private IconMenu current;

	public void ToggleCanvas (Toggle t)
	{ 
        if (current != null && !oneByOne)
        {
            current.toggle.isOn = false;
            current.canvas.gameObject.SetActive(false);
            current.canvas.enabled = false;
            current = null;
        }

		foreach (IconMenu im in iconMenus) {
			if(im == null)
				continue;
			if(im.canvas == null)
				continue;

			if (im.toggle.isOn) {
                current = im;
				im.canvas.gameObject.SetActive(true);
				im.canvas.enabled = true;
			}

            if (oneByOne)
            {
                im.canvas.gameObject.SetActive(im.toggle.isOn);
                im.canvas.enabled = im.toggle.isOn;
            }
		}



	}
}
