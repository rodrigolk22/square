using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Gerencia as ações do jogador e faz a solicitação de nova fase e de fim de jogo
public class ActionManager : MonoBehaviour {

    public int currentPoints = 0;
    public int currentErrors = 0;
    public static int currentHits = 0;
    public int selectedSquares = 0;
    public Text pointsUI;
    public Text errorUI;
    public GameManager gameManager;
    public Level level;
    public Button nextLevel;
    public Button gameOver;

    //Checa o padrão do Square e encaminha para o procedimento correspondente
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
        currentHits ++;
        currentPoints++;
        //Atualiza a tela
        pointsUI.text = "Points: " + currentPoints;
        //Em caso de conclusão de fase
        if (level.numberOfPatterns <= currentHits)
        {
            //Atualiza os pontos
            gameManager.totalPoints += currentPoints;
            //Limpa a tela
            level.clean();
            //Atualiza a tela de erros
            errorUI.text = "Errors: 0";
            //Muda a mensagem de transição quando não há erros
            if (currentErrors == 0)
            {
                gameManager.resultGameUI.text = "Amazing! Total points: " + gameManager.totalPoints;
            }
            else
            {
                gameManager.resultGameUI.text = "Great! Total points: " + gameManager.totalPoints;
            }
            //Exibe um botão para que o jogador solicite uma nova fase
            nextLevel.gameObject.SetActive(true);
            //Reseta os valores da fase atual
            reset();
        }
    }
    //Realiza adiversas ações relacionadas a seleção errada
    public void countError()
    {
        //Atualiza os valores e a interface
        selectedSquares++;
        currentErrors++;
        errorUI.text = "Errors: " + currentErrors;
        //Checa se o jogador excedeu o limite de erros
        if ((gameManager.defaultErrors + gameManager.currentLimitErrors) == currentErrors)
        {
            //Limpa a tela
            level.clean();
            //Exibe o botão de fim do jogo
            gameOver.gameObject.SetActive(true);
            //Solicita o Game Manager realizar o final do jogo
            gameManager.gameOver();
        }
    }
    //Reseta os valores correntes da fase
    public void reset()
    {
        currentPoints = 0;
        currentErrors = 0;
        currentHits = 0;
        selectedSquares = 0;
        loadTexts();
    }
    //Exibe a interface inicial do jogo. Chamado pelo Play Button
    public void loadTexts()
    {
        pointsUI.text = "Points: 0";
        errorUI.text = "Errors: 0";
    }
}
