using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthGraphics : MonoBehaviour
{
    [SerializeField] private Health playerHealth;

    [SerializeField] private int healthPerHeart = 1;

    [SerializeField] private Sprite blankSpriteRef; // Color of the heart when taken damage
    [SerializeField] private Sprite redSpriteRef; // Color of the heart when full

    [SerializeField] private Image[] hearts;

    private void Start()
    {
        int max = Mathf.Clamp(playerHealth.GetMaxHealth() / healthPerHeart, 1, hearts.Length); //Clamp is to avoid errors as the array has a set length

        changeTextures(max, max);
    }

    public void healthGraphicUpdate()
    {
        int max = Mathf.Clamp(playerHealth.GetMaxHealth()/healthPerHeart, 1, hearts.Length); //Clamp is to avoid errors as the array has a set length
        int curr = playerHealth.GetCurrHealth()/healthPerHeart;

        changeTextures(curr, max);
    }

    private void changeTextures(int curr, int max)
    {
        //enable hearts to max and set color
        for (int i = 0; i < max; i++)
        {
            hearts[i].enabled = true;
            if (i < curr)
            {
                hearts[i].sprite = redSpriteRef;
            }
            else
            {
                hearts[i].sprite = blankSpriteRef;
            }
        }
        //disable after max
        for (int i = max; i < hearts.Length; i++)
        {
            hearts[i].enabled = false;
        }
    }

}