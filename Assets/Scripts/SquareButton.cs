using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Este script gerencia requisitos visuais
public class SquareButton : MonoBehaviour
{
    public bool pattern;
    public bool selected;
    public Sprite standardFrame;
    public Sprite selectedFrame;

    public GameObject itself;

    //Realiza a transição inicial da aparencia do quadrado
    void Start()
    { 
        // Impede que o quadrados originais interajam com o jogo pois serão clonados várias vezes
        if (!System.String.Equals(itself.name, "SquarePatternObject") && !System.String.Equals(itself.name, "ErrorSquareObject"))
        {
            //Impede ações no botão
            GetComponent<Button>().interactable = false;
            //Realiza a espera e conclui o padrão
            StartCoroutine(showingFrame());
        }
    }

    IEnumerator showingFrame()
    {
        //Aguarda por segundos
        yield return new WaitForSeconds(2);
        //Torna o botão clicável
        GetComponent<Button>().interactable = true;
        //Esconde o padrão
        if (pattern == true)
        {
            GetComponent<Image>().sprite = standardFrame;
        }
    }

}
