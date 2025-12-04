namespace ArvoreTarefa2
{
    public static class Processamento
    {
        public static void ProcessarCenario(int[] array)
        {
            Console.WriteLine("Array de entrada: [" + string.Join(", ", array) + "]");

            int raiz = array.Max();
            int indexRaiz = Array.IndexOf(array, raiz);

            Console.WriteLine($"Raiz: {raiz}");

            var nosEsquerda = array.Take(indexRaiz).OrderByDescending(x => x).ToList();
            Console.WriteLine("Galhos da esquerda: " + string.Join(", ", nosEsquerda));

            var nosDireita = array.Skip(indexRaiz + 1).OrderByDescending(x => x).ToList();
            Console.WriteLine("Galhos da direita: " + string.Join(", ", nosDireita));

            Console.WriteLine("\nÁrvore:");
            ImprimirArvore(raiz, nosDireita, nosEsquerda);
        }

        private static void ImprimirArvore(
            int raiz,
            List<int> nosDireita,
            List<int> nosEsquerda)
        {

            if (nosDireita.Count > nosEsquerda.Count)
            {
                MontarhArvoreDaDireita(raiz, nosDireita, nosEsquerda);
            }
            else
            {
                MontarhArvoreDaEsquerda(raiz, nosDireita, nosEsquerda);
            }
        }

        private static void MontarhArvoreDaEsquerda(
            int raiz,
            List<int> nosDireita,
            List<int> nosEsquerda)
        {
            var quantidadeAhEsquerda = (nosEsquerda.Count * 2);
            var espacosItemAhEsquerda = string.Empty;
            var espacosItemAhDireita = string.Empty;

            for (int i = 1; i < quantidadeAhEsquerda; i++)
            {
                espacosItemAhEsquerda += " ";
            }

            Console.WriteLine(espacosItemAhEsquerda + $"{raiz}");

            int contador = 0;
            var ultimoRegistroDireita = 0;
            var ultimoRegistroEsquerda = 0;
            var arvorehEsquerda = false;

            foreach (var itemEsquerda in nosEsquerda)
            {
                foreach (var itemDireita in nosDireita)
                {
                    if (ultimoRegistroDireita != itemDireita && ultimoRegistroEsquerda != itemEsquerda)
                    {
                        if (!arvorehEsquerda)
                        {
                            espacosItemAhDireita += " ";
                            espacosItemAhEsquerda = espacosItemAhEsquerda.Remove(espacosItemAhEsquerda.Length - 1);
                            Console.WriteLine(espacosItemAhEsquerda + "/" + espacosItemAhDireita + "\\");
                            espacosItemAhDireita += " ";
                            Console.WriteLine(espacosItemAhEsquerda + itemEsquerda + espacosItemAhDireita + itemDireita);
                            ultimoRegistroDireita = itemDireita;
                            ultimoRegistroEsquerda = itemEsquerda;
                        }
                        else
                        {
                            espacosItemAhEsquerda = espacosItemAhEsquerda.Remove(espacosItemAhEsquerda.Length - 1);
                            Console.WriteLine(espacosItemAhEsquerda + "/");
                            Console.WriteLine(espacosItemAhEsquerda + itemEsquerda);
                        }
                    }
                    else
                    {
                        continue;
                    }

                    contador++;

                    if (nosDireita.Count() <= contador)
                    {
                        arvorehEsquerda = true;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private static void MontarhArvoreDaDireita(
            int raiz,
            List<int> nosDireita,
            List<int> nosEsquerda)
        {
            var quantidadeAhDireita = (nosDireita.Count * 2);
            var espacosItemAhEsquerda = string.Empty;
            var espacosItemAhDireita = string.Empty;

            for (int i = 1; i < quantidadeAhDireita; i++)
            {
                espacosItemAhDireita += " ";
            }

            Console.WriteLine(espacosItemAhDireita + $"{raiz}");

            int contador = 0;
            var ultimoRegistroDireita = 0;
            var ultimoRegistroEsquerda = 0;
            var arvorehDireita = false;

            foreach (var itemDireita  in nosDireita)
            {
                foreach (var itemEsquerda in nosEsquerda)
                {
                    if (ultimoRegistroDireita != itemDireita && ultimoRegistroEsquerda != itemEsquerda)
                    {
                        if (!arvorehDireita)
                        {
                            espacosItemAhEsquerda += " ";
                            espacosItemAhDireita = espacosItemAhDireita.Remove(espacosItemAhDireita.Length - 1);
                            Console.WriteLine(espacosItemAhDireita + "/" + espacosItemAhEsquerda + "\\");
                            espacosItemAhEsquerda += " ";
                            Console.WriteLine(espacosItemAhDireita  + itemEsquerda + espacosItemAhEsquerda + itemDireita);
                            ultimoRegistroEsquerda = itemEsquerda;
                            ultimoRegistroDireita = itemDireita;
                        }
                        else
                        {
                            espacosItemAhDireita  += " ";
                            Console.WriteLine(espacosItemAhDireita + espacosItemAhEsquerda + "\\"); 
                            Console.WriteLine(espacosItemAhDireita + espacosItemAhEsquerda + itemDireita );
                        }
                    }
                    else
                    {
                        continue;
                    }

                    contador++;

                    if (nosEsquerda.Count() <= contador)
                    {
                        arvorehDireita = true;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}