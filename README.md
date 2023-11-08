<h1>Square Overflow</h1> 

<p align="center">
  <img src="https://img.shields.io/badge/Unity3D-2017.3.0f3-green?style=flat" alt="Unity3D" />
  <img src="https://img.shields.io/badge/.NET-v3.5-green?style=flat" alt=".NET" />
  <img src="https://img.shields.io/badge/Status-Complete-green?style=flat" alt="Status" />
  <img src="https://img.shields.io/badge/LICENSE-Read%20Only-red?style=flat" alt="LICENSE" />
</p>

## Descrição do projeto

<p align="justify">
  Square Overflow é um projeto de jogo Unity3D que faz parte de um trabalho de conclusão de curso
<a href="http://repositorio.utfpr.edu.br:8080/jspui/bitstream/1/23714/1/CT_COSIS_2019_2_06.pdf" target="_blank">Estudo da Aplicabilidade da OPM para Desenvolvimento de
Jogos Digitais</a>.
</p>

:warning: Como este projeto está atrelado a um projeto acadêmico, este código esta diponível apenas para leitura.

Permitido:
<ul>
  <li>Clonar ou baixar o projeto</li>
  <li>Ler o código</li>
  <li>Construir ou executar o projeto</li>
  <li>Experimentar ou testar o projeto</li>
  <li>Compreender ou aprender as implementações do projeto</li>
  <li>Armazenar ou excluir todo o projeto em seu próprio disco físico</li>
</ul>
Não permitido:
<ul>
  <li>Fazer alterações ou modificar o projeto</li>
  <li>Reenviar o projeto na internet</li>
  <li>Reenviar o projeto para qualquer mercado</li>
</ul>

## Detalhes sobre o projeto

[![Assita o video](https://img.youtube.com/vi/us_G29ts710/maxresdefault.jpg)](https://youtu.be/us_G29ts710?si=xGu1-cvngZi-8aJs)

> Clique na imagem para assitir o vídeo

<p align="justify">
Trata-se de um jogo que desafia o jogador identificar um padrão de luzes por meio da sua capacidade de reconhecimento visual. Foi optado por fazer esse jogo porque seu mecanismo é simples e tem pequeno porte, facilitando a correlação entre os diagramas da UML e da OPM.
</p>
<p align="justify">
Assim que o jogador aciona o botão Jogar, uma nova partida é iniciada. O jogador pode também a qualquer momento acionar o botão Sair para fechar o jogo.
</p>
<p align="justify">
Ao inicializar uma partida, o jogador será desafiado a indicar o padrão de luzes que é formado por um conjunto de quadrados acesos. Esta tela contém os textos: Pontos, exibindo a pontuação atual, e Erros, exibindo os erros cometidos, e um conjunto de quadrados com os tipos: cinza (apagado) e branco (aceso). O padrão dos quadrados acesos é exibido na tela por um período de dois segundos. Este período é reservado para que o jogador tente memorizar o padrão. Após este período de tempo todos os quadrados são apagados (em cor cinza).
</p> 
<p align="justify">
Quando o jogador seleciona um quadrado pertencente ao padrão, este quadrado permanece aceso e é computado um ponto. Quando o jogador seleciona um quadrado que não pertence ao padrão, o quadrado é removido e é adicionado um erro.
</p>
<p align="justify">
Após cada ação do jogador, ocorre a verificação de condição de vitória, que é a formação do padrão exibido, ou condição de derrota, que é errar além do limite permitido. A cada vez que a vitória é alcançada, um novo nível é criado, com um número maior de quadrados que a fase anterior e em um novo padrão. Quando ocorre uma derrota, a partida acaba, exibindo a tela de fim de jogo. É exibido o total de pontos e o botão Jogar, que ao acioná-lo, começa uma nova partida.
</p> 

## Requerimentos

:warning: [Unity3D v2017.3.0f3](https://unity.com/releases/editor/whats-new/2017.3.0-1)

## Como executar :arrow_forward:

Basta executar o projeto usando o Unity3D.
:warning: O build dele foi feito originalmente para executar em Android.


## Desenvolvedor :octocat:

| [<img src="https://avatars.githubusercontent.com/u/26410295?v=4" width=115><br><sub>Rodrigo Luiz Kovalski</sub>](https://github.com/rodrigolk22) |
| :---: |


## Licença 

Read Only - Somente leitura

Copyright :copyright: 2019 - Square Overflow
