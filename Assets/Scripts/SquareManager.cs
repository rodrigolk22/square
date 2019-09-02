using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Este script gerencia alguns requisitos visuais e cosmeticos
public class SquareManager : MonoBehaviour
{
    public bool pattern;
    public bool selected;
    public Sprite standardFrame;
    public Sprite selectedFrame;
    public Sprite crackedFrame;
    //Variáveis para referência
    public LevelManager levelObject;

    //Realiza a transição inicial da aparencia do quadrado
    void Start()
    {
        if (pattern == true)
        {
            //Exibe o padrão
            GetComponent<Image>().sprite = selectedFrame;
        }
        else
        {
            //Exibe o botão vazio para destacar do padrão
            GetComponent<Image>().sprite = standardFrame;
        }
        //Impede ações no botão
        GetComponent<Button>().interactable = false;
        //Realiza a espera e conclui o padrão
        StartCoroutine(showingFrame());
    }

    IEnumerator showingFrame()
    {
        //Aguarda por segundos
        yield return new WaitForSeconds(levelObject.timeToHidePattern);
        if (pattern == true)
        {
            //Esconde o padrão
            GetComponent<Image>().sprite = standardFrame;
        }
        //Torna o botão clicável
        GetComponent<Button>().interactable = true;
    }

}
