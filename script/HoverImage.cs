using UnityEngine;

public class HoverImage : MonoBehaviour
{
    [SerializeField] private GameObject Content;
    private RectTransform posImage;
    private float TimeHover = 3;
    // Start is called before the first frame update
    void Start()
    {
        posImage = GetComponent<RectTransform>();    
    }

    // Update is called once per frame
    void Update()
    {
        ActivePane();
    }
    private bool Hover()
    {
        if ((Input.mousePosition.x > (posImage.position.x - posImage.rect.width / 2) && Input.mousePosition.x < (posImage.position.x + posImage.rect.width / 2)) && (Input.mousePosition.y > (posImage.position.y - posImage.rect.height / 2) && Input.mousePosition.y < (posImage.position.y + posImage.rect.height / 2)))
        {
            return true;
        }
        else return false;
    }
    private void ActivePane()
    {
        if(Hover())
        {
            TimeHover -= Time.deltaTime;
            if (TimeHover > 0) return;
            Content.SetActive(true);
        }
        else
        {
            TimeHover = 3;
            Content.SetActive(false);
        }
    }
}
