using UnityEngine;

//Realiza a contrução da matriz de quadrados de acordo com os parametros dados pelo Game Manager
public class LevelManager : MonoBehaviour {

    public int sizeLines;
    public int sizeColumns;
    public int totalSquares;
    public int numberOfPatterns;
    private bool[,] patternMap;
    public int offSetX = 10;
    public int offSetY = 10;
    public int offSetAdjustamentXDefault = 266;
    public int offSetAdjustamentYDefault = 150;
    public int offSetAdjustamentX = 266;
    public int offSetAdjustamentY = 150;
    public int offSetTile = 30;
    //Variaveis para referência
    public Canvas gameCanvas;
    public GameObject errorSquare;
    public GameObject patternSquare;
    public GameObject[] squareObjects;

    public void createMatrix(){
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
}
