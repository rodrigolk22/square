using UnityEngine;
using UnityEngine.UI;

//Game Manager faz o gerenciamento das telas e níveis do jogo
public class GameManager : MonoBehaviour {

    public int initialLines = 3;
    public int initialColumns = 2;
    public int limitErrors = 3;
    public int currentLines;
    public int currentColumns;
    public int totalPoints = 0;
    private bool toggleAxis = true;
    public int currentErrors = 0;
    public static int currentHits = 0;
    public int sizeLines;
    public int sizeColumns;
    public int totalSquares;
    public int numberOfPatterns;
    private bool[,] patternMap;
    public int offSetX = 10;
    public int offSetY = 10;
    public int offSetAdjustamentXDefault = 266;
    public int offSetAdjustamentYDefault = 150;
    public int offSetAdjustamentX = 272;
    public int offSetAdjustamentY = 150;
    public int offSetTile = 30;
    //Variáveis para referência pois as funções alteram diretamente nas variáveis
    public Canvas gameCanvas;
    public GameObject errorSquare;
    public GameObject patternSquare;
    public GameObject[] squareObjects;
    public Text infoGameUI;
    public GameObject titleUI;
    public Text pointsUI;
    public Text errorUI;
    public Button nextLevelButton;
    public Button playButton;

    //Função modifica os parametros para construir novo nível
    public void nextLevel()
    { 
        //Adiciona alternadamente as linhas e colunas e faz ajuste de posição na tela
        if (toggleAxis == true)
        {
            currentColumns++;
            offSetAdjustamentY -= 10;
            toggleAxis = false;
        }
        else
        {
            currentLines++;
            offSetAdjustamentX -= 16;
            toggleAxis = true;
        }
        sizeColumns = initialColumns + currentColumns;
        sizeLines = initialLines + currentLines;
        //Definindo uma matriz de padrões
        patternMap = new bool[sizeLines, sizeColumns];
        //Definindo o número de padrões que serão inseridos
        totalSquares = (sizeLines * sizeColumns);
        numberOfPatterns = totalSquares / 3;
        //Variáveis auxiliares para sorteio do padrão
        int remaningPatterns = numberOfPatterns;
        int randomX;
        int randomY;
        while (remaningPatterns > 0)
        {
            //Função que faz o sorteio baseado nos limites dados
            randomX = Random.Range(0, sizeLines);
            randomY = Random.Range(0, sizeColumns);
            //Impede padrão seja marcado mais de uma vez na mesma posição
            if (patternMap[randomX, randomY] == false)
            {
                patternMap[randomX, randomY] = true;
                remaningPatterns--;
            }
        }
        //Criando os quadrados
        //Variaveis para auxiliar a identificação dos quadrados
        int positionY = 0;
        int positionX = 0;
        //Instancia os quadrados conforme a matriz de padrões
        for (int y = 0; y < sizeColumns; y++)
        {
            for (int x = 0; x < sizeLines; x++)
            {
                //Atualiza a posição do novo quadrado através de um objeto Vector que tem as coordenadas x, y e z
                Vector3 actualPosition = patternSquare.transform.position;
                actualPosition.x = (x * offSetTile) + offSetX + offSetAdjustamentX;
                actualPosition.y = (y * offSetTile) + offSetY + offSetAdjustamentY;
                actualPosition.z = 10;
                GameObject newSquareInstance;
                //Checa se é padrão
                if (patternMap[x, y] == true)
                {
                    newSquareInstance = Instantiate(patternSquare) as GameObject;
                }
                else
                {
                    newSquareInstance = Instantiate(errorSquare) as GameObject;
                }
                //Define o nome do novo quadrados
                newSquareInstance.name = "Square Y" + positionY + " X " + positionX;
                //Adiciona uma etiqueta para auxiliar a busca dos objetos que serão destruídos no final da fase
                newSquareInstance.tag = "ObjectToDestroy";
                //Posiciona dentro do Canvas para que o unity renderize o botão corretamente
                newSquareInstance.transform.SetParent(gameCanvas.transform, false);
                newSquareInstance.transform.position = actualPosition;
                positionX++;
            }
            positionY++;
        }
    }

    //Checa o padrão do quadrado e encaminha para o procedimento correspondente
    public void selectedSquare(bool pattern)
    {
        if (pattern)
        {
            countPoint();
        }
        else
        {
            countError();
        }
    }
    //Realiza adiversas ações relacionadas a um padrão selecionado corretamente
    public void countPoint()
    {
        //Atualiza os pontos
        currentHits++;
        totalPoints++;
        //Atualiza a tela
        pointsUI.text = "Pontos: " + totalPoints;
        //Em caso de conclusão de fase
        if (numberOfPatterns <= currentHits)
        {
            //Limpa a tela
            GameObject[] squareObjects = GameObject.FindGameObjectsWithTag("ObjectToDestroy");
            int lenght = squareObjects.Length;
            for (int i = 0; i < lenght; i++)
            {
                Destroy(squareObjects[i]);
            }
            //Atualiza a tela de erros
            errorUI.text = "Erros: 0";
            infoGameUI.text = "Muito bom! Total de pontos: " + totalPoints;
            //Exibe um botão para que o jogador solicite uma nova fase
            nextLevelButton.gameObject.SetActive(true);
            //Reseta as ações da fase da fase
            currentErrors = 0;
            currentHits = 0;
        }
    }
    //Realiza diversas ações relacionadas a seleção errada
    public void countError()
    {
        //Atualiza os valores e a interface
        currentErrors++;
        errorUI.text = "Erros: " + currentErrors;
        //Checa se o jogador excedeu o limite de erros
        if (limitErrors <= currentErrors)
        {
            //Limpa a tela
            GameObject[] squareObjects = GameObject.FindGameObjectsWithTag("ObjectToDestroy");
            int lenght = squareObjects.Length;
            for (int i = 0; i < lenght; i++)
            {
                Destroy(squareObjects[i]);
            }
            //Exibe o botão de jogar novamente
            playButton.gameObject.SetActive(true);
            //Reseta as ações para um novo jogo
            currentErrors = 0;
            currentHits = 0;
            offSetAdjustamentY = offSetAdjustamentYDefault;
            offSetAdjustamentX = offSetAdjustamentXDefault;
            currentColumns = 0;
            currentLines = 0;
            toggleAxis = true;
            infoGameUI.text = "Fim de jogo! Total de pontos:  " + totalPoints;
            titleUI.SetActive(true);
        }
    }
  
}
