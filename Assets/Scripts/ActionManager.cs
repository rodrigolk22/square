using UnityEngine;
using UnityEngine.UI;

//Gerencia as ações do jogador fazendo a solicitação de uma nova fase ou do fim de jogo
public class ActionManager : MonoBehaviour {

    public int currentErrors = 0;
    public static int currentHits = 0;
    public int selectedSquares = 0;
    //Variáveis para referência
    public Text pointsUI;
    public Text errorUI;
    public GameManager gameManager;
    public LevelManager level;
    public Button nextLevel;
    public Button gameOver;

    //Checa o padrão do quadrado e encaminha para o procedimento correspondente
    public void selectedSquare(bool pattern)
    {
        if (pattern)
        {
            countPoints();
        }
        else
        {
            countError();
        }
    }
    //Realiza adiversas ações relacionadas a um padrão selecionado corretamente
    public void countPoints()
    {
        //Atualiza os pontos
        selectedSquares++;
        currentHits++;
        gameManager.totalPoints++;
        //Atualiza a tela
        pointsUI.text = "Pontos: " + gameManager.totalPoints;
        //Em caso de conclusão de fase
        if (level.numberOfPatterns <= currentHits)
        {
            //Limpa a tela
            GameObject[] squareObjects = GameObject.FindGameObjectsWithTag("ObjectToDestroy");
            int lenght = squareObjects.Length;
            for (int i = 0; i < lenght; i++)
            {
                Destroy(squareObjects[i]);
            }
            //Atualiza a tela de erros
            pointsUI.text = "Pontos: " + gameManager.totalPoints;
            errorUI.text = "Erros: 0";
            gameManager.resultGameUI.text = "Muito bom! Total de pontos: " + gameManager.totalPoints;
            //Exibe um botão para que o jogador solicite uma nova fase
            nextLevel.gameObject.SetActive(true);
            //Reseta as ações da fase da fase
            resetActions();
            errorUI.text = "Erros: 0";
        }
    }
    //Realiza diversas ações relacionadas a seleção errada
    public void countError()
    {
        //Atualiza os valores e a interface
        selectedSquares++;
        currentErrors++;
        errorUI.text = "Erros: " + currentErrors;
        //Checa se o jogador excedeu o limite de erros
        if ((gameManager.limitErrors) <= currentErrors)
        {
            //Limpa a tela
            GameObject[] squareObjects = GameObject.FindGameObjectsWithTag("ObjectToDestroy");
            int lenght = squareObjects.Length;
            for (int i = 0; i < lenght; i++)
            {
                Destroy(squareObjects[i]);
            }
            //Exibe o botão de fim do jogo
            gameOver.gameObject.SetActive(true);
            //Reseta as ações para um novo jogo
            resetActions();
            //Solicita o Game Manager realizar o final do jogo
            gameManager.gameOver();
        }
    }
    public void resetActions()
    {
        currentErrors = 0;
        currentHits = 0;
        selectedSquares = 0;
    }

}
