using System;
using System.Diagnostics;

namespace JogoDaVelha
{

    public class Program
    {
        private static void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("- MENU PRINCIPAL -\n");
            Console.ResetColor();
            Console.WriteLine("1. Como jogar");
            Console.WriteLine("2. Começar a jogar");
            Console.WriteLine("3. Histórico de partidas");
            Console.WriteLine("4. Sair do jogo\n");
            Console.Write("Escolha a opção desejada: ");        
        }

        private static void ShowMenu2()
        {
            Console.WriteLine();
            Console.WriteLine("1. Voltar ao Menu Principal");
            Console.WriteLine("2. Começar a Jogar\n");
            Console.Write("O que deseja fazer? ");           
        }

        private static void ShowMenu3()
        {
            Console.WriteLine();
            Console.WriteLine("1. Jogar mais uma partida");
            Console.WriteLine("2. Voltar ao Menu Principal\n");
            Console.Write("O que deseja fazer? ");
        }

        public static void Main(string[] args)
        {
            Console.ForegroundColor= ConsoleColor.DarkYellow;
            Console.WriteLine("________________________________________");
            Console.WriteLine("      BEM-VINDOS AO JOGO DA VELHA!      ");
            Console.WriteLine("________________________________________\n");
            Console.ResetColor();
            int opcaoMenu;

            do
            {
                ShowMenu();
                opcaoMenu = int.Parse(Console.ReadLine());
                Console.WriteLine("________________________________________\n");

                switch (opcaoMenu)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("---------------------");
                        Console.WriteLine("      COMO JOGAR     ");
                        Console.WriteLine("_____________________\n");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine("- Participam dois jogadores, que jogam alternadamente preenchendo cada um dos espaços vazios;");
                        Console.WriteLine("- Cada participante deve usar um símbolo (X ou O);");
                        Console.WriteLine("- Vence o jogador que conseguir formar primeiro uma linha com três símbolos iguais, seja ela na horizontal, vertical ou diagonal\n");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Escolha seu símbolo, coloque seu nome e comece a jogar!\n");
                        Console.ResetColor();
                        Console.WriteLine();
                        ShowMenu2();
                        int opcaoMenu2 = int.Parse(Console.ReadLine());
                        Console.WriteLine("________________________________________\n");
                            switch (opcaoMenu2)
                            {
                                case 1:
                                    ShowMenu();
                                    break;
                                case 2:
                                    ComeçarJogo();
                                    break;
                                default:
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Opção inválida. Por favor, tente outra vez.");
                                Console.ResetColor();
                                    break;
                            }
                         break;
                    case 2:
                        ComeçarJogo();
                        break;
                    case 3:
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Voltem sempre que quiserem espairecer um pouco... Até mais!");
                        Console.ResetColor();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Esta opção não é válida. Por favor, tente outra vez.");
                        Console.ResetColor();
                        Console.WriteLine("________________________________________\n");
                        break;
                }

            }
            while (opcaoMenu != 4);
                  

        }

        private static void ComeçarJogo()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("---------------------");
            Console.WriteLine("   COMEÇAR A JOGAR   ");
            Console.WriteLine("_____________________\n");
            Console.ResetColor();
            Console.WriteLine();

            Console.WriteLine("Okay, vamos lá!!\n");
            Console.WriteLine();
            Console.WriteLine("- Jogador 1, seu símbolo é o X.\n");
            Console.Write("- Como devo te chamar? ");
            string jogador1 = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("- Belo nome.\n");
            Console.WriteLine("- Jogador 2, já o seu símbolo é o O.\n");
            Console.Write("- Qual o seu nome? ");
            string jogador2 = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("- Perfeito! Tudo pronto, agora vamos começar!\n");
            Console.WriteLine("Digite qualquer tecla para continuar...");
            Console.ReadLine();
            Console.Clear();

            CabecalhoJogo();

            string[,] matriz = new string[3, 3];

            List<string> posicaoNumeros = new List<string> { };

            int posicao = 1;

            // criando a tabela/matriz do jogo da velha, que irá aparecer pela primeira vez, sem nenhum símbolo
            for (int i = 0; i < matriz.GetLength(0); i++) // linhas. Método GetLenght(0) = Define o primeiro elemento, ou seja, índice zero, para pegar o comprimento (o primeiro 3 do [3,3]). 
            {
                for (int j = 0; j < matriz.GetLength(1); j++) // colunas. Pegando o comprimento do segundo elemento do [3, 3] (índice 1). Podemos colocar somente < 3 ao invés de GetLenght se o tamanho da matriz não for mudar. 
                {
                    matriz[i, j] = posicao.ToString();
                    posicaoNumeros.Add(posicao.ToString()); //está adicionando na lista os numeros da matriz. 
                    posicao++;
                }
            }


            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    //Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("| ");
                   // Console.ResetColor();
                    Console.Write($"{matriz[i, j]}");
                    //Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(" |");
                    //Console.ResetColor();
                }

                Console.WriteLine();  // colocamos este cw vazio para cada linha lida pular uma em branco para formar o tabuleiro.
                //Console.ForegroundColor= ConsoleColor.Magenta;
                Console.WriteLine("|---||---||---|");
               // Console.ResetColor();
            }


            // Começa o jogo:
            string simbolo = "X";
            string jogador = jogador1;
            int rodadas = 1;

            Console.WriteLine();
            Console.WriteLine("{0}, qual a posição que gostaria de fazer sua primeira jogada?\n", jogador);
            Console.Write("Digite o número da posição: ");
            string jogada = Console.ReadLine();
            Console.WriteLine();


            Console.Clear();


            while (rodadas < 9)
            {
                CabecalhoJogo();

                // substituindo o valor da posição pelo símbolo             
                for (int i = 0; i < matriz.GetLength(0); i++)
                {
                    for (int j = 0; j < matriz.GetLength(1); j++)
                    {
                        if (matriz[i, j] == jogada && posicaoNumeros.Contains(jogada)) // se o valor que eu digitei (jogada) for o mesmo da matriz e este valor conter na lista, ele troca pelo simbolo.
                        {
                            matriz[i, j] = simbolo;
                            posicaoNumeros.Remove(jogada); //tiramos a posição digitada da lista para não poder ser usada novamente nas próximas jogadas.   
                        }
                    }
                }

                // imprimindo a matriz novamente
                for (int i = 0; i < matriz.GetLength(0); i++)
                {
                    for (int j = 0; j < matriz.GetLength(1); j++)
                    {
                       // Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("| ");
                     //   Console.ResetColor();
                        Console.Write($"{matriz[i, j]}");
                      //  Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(" |");
                       // Console.ResetColor();
                    }

                    Console.WriteLine();
                   // Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("|---||---||---|");
                   // Console.ResetColor();
                }

                // vitória diagonais
                if (matriz[0, 0] == matriz[1, 1] && matriz[1, 1] == matriz[2, 2] || matriz[0, 2] == matriz[1, 1] && matriz[1, 1] == matriz[2, 0])
                {
                    MensagemVitoria(jogador);
                    break;
                }

                //vitória linhas
                if (matriz[0, 0] == matriz[0, 1] && matriz[0, 1] == matriz[0, 2] || matriz[1, 0] == matriz[1, 1] && matriz[1, 1] == matriz[1, 2] || matriz[2, 0] == matriz[2, 1] && matriz[2, 1] == matriz[2, 2])
                {
                    MensagemVitoria(jogador);
                    break;
                }

                //vitória colunas
                if (matriz[0, 0] == matriz[1, 0] && matriz[1, 0] == matriz[2, 0] || matriz[0, 1] == matriz[1, 1] && matriz[1, 1] == matriz[2, 1] || matriz[0, 2] == matriz[1, 2] && matriz[1, 2] == matriz[2, 2])
                {
                    MensagemVitoria(jogador);
                    break;
                }


                if (simbolo == "X")
                {
                    simbolo = "O";
                    jogador = jogador2;
                }
                else
                {
                    simbolo = "X";
                    jogador = jogador1;
                }

                Console.WriteLine();
                Console.Write("{0}, você gostaria de jogar {1} em qual posição? ", jogador, simbolo);
                jogada = Console.ReadLine();
                Console.WriteLine();

                while (!posicaoNumeros.Contains(jogada))  // enquanto não conter um número da lista, vai aparecer a mensagem.
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Jogada inválida. Por favor, tente outra posição: ");
                    Console.ResetColor();
                    jogada = Console.ReadLine();
                }

                rodadas++;

                Console.Clear();

            }

            if (rodadas == 9)
            {
                CabecalhoJogo();

                for (int i = 0; i < matriz.GetLength(0); i++)
                {
                    for (int j = 0; j < matriz.GetLength(1); j++)
                    {
                        Console.Write($"| {matriz[i, j]} |");
                    }

                    Console.WriteLine();
                    Console.WriteLine("|---||---||---|");
                }

                Console.WriteLine();
                Console.ForegroundColor= ConsoleColor.DarkYellow;
                Console.WriteLine("Ops, houve um empate!");
                Console.WriteLine("Ninguém ganhou desta vez.\n");
                Console.ResetColor();
                
            }

            Console.ReadLine();

            Console.WriteLine();
            ShowMenu3();
            int opcaoMenu3 = int.Parse(Console.ReadLine());
            switch (opcaoMenu3)
            {
                case 1:
                    ComeçarJogo();
                    break;
                case 2:
                    ShowMenu();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Opção inválida. Por favor, tente outra vez.");
                    Console.ResetColor();
                    break;
            }


        }

        private static void MensagemVitoria(string jogador)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Fim de partida!");
            Console.WriteLine("Parabéns {0}, você venceu!", jogador);
            Console.ResetColor();
        }

        private static void CabecalhoJogo()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-------------------------------------\n");
            Console.WriteLine("            JOGO DA VELHA            \n");
            Console.WriteLine("-------------------------------------\n");
            Console.ResetColor();
            Console.WriteLine();

            //Console.ForegroundColor = ConsoleColor.DarkCyan;
            //Console.ResetColor();
        }

    }
}