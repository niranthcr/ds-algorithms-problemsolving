    public static void KMPSearch(string text, string word)
    {
        var aux = Aux(word).ToArray();
        int i = 0;
        int j = 0;

        while(i < text.Length)
        {
            if(text[j] != word[i])
            {
                if(i == 0)
                    j++;
                else
                    i = aux[i - 1];
            }
            else
            {
                i++;
                j++;

                if(i == word.Length)
                {
                    Console.WriteLine($"match found at index {j}");
                    //if we want to find more patterns, we can 
                    //continue as if no match was found at this point.
                    i = aux[i - 1];
                }
            }
        }
    }

    public static IEnumerable<int> Aux(string word)
    {
        int[] aux = new int[word.Length];

        int i = 1;
        int m = 0;

        while(i < word.Length)
        {
            if(word[i] == word[m])
            {
                m++;
                aux[i] = m;
                i++;
            }
            else if (word[i] != word[m] && m != 0)
            {
                //this one is a little tricky,
                //when there is a mismatch,
                //we will check the index of previous
                //possible prefix.
                m = aux[m-1];
            }
            else
            {
                aux[i] = 0;
                i++;
            }
        }
        return aux;
    }
