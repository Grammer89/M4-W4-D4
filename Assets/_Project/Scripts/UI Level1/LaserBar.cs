using UnityEngine;
using UnityEngine.UI;

public class LaserBar : MonoBehaviour
{
    [SerializeField] Image _image;


    public void ModifyLifeBar(int actualLife )
    {
        float fillAmount = (float)actualLife / Utility._lifemax;
        Debug.Log("Fill Amount : " + fillAmount); 
        _image.fillAmount = fillAmount;
        
    }
}
