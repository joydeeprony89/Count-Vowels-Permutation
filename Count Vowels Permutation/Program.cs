// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Solution s = new Solution();
var answer = s.CountVowelPermutation(3);
Console.WriteLine(answer);

public class Solution
{

  // https://www.youtube.com/watch?v=VUVpTZVa7Ls
  public int CountVowelPermutation(int n)
  {
    //based on which letters a vowel will follow we update its current count based on the letters occurance it follow
    //as per problem
    //a will follow e i and u,  so record[2][a] = record[1][e] + record[1][i] + record[1][u]
    //n = 1  2 ...
    //a   1  3
    //e   1  2
    //i   1  2
    //o   1  1
    //u   1  2
    // total  =  10

    //Indexes 
    // a - 0
    // e = 1
    // i = 2
    // o = 3
    // u = 4

    long[][] records = new long[n + 1][];
    for(int i = 0; i < n + 1; i++)
    {
      records[i] = new long[5];
      for (int j = 0; j < 5; j++)
      {
        if(i == 1)
          records[1][j] = 1;
      }
    }

    int mod = 1000000007;
    for (int i = 2; i <= n; i++)
    {
      records[i][0] = (records[i - 1][1] + records[i - 1][2] + records[i - 1][4]) % mod;
      records[i][1] = (records[i - 1][0] + records[i - 1][2]) % mod;
      records[i][2] = (records[i - 1][1] + records[i - 1][3]) % mod;
      records[i][3] = (records[i - 1][2]) % mod;
      records[i][4] = (records[i - 1][2] + records[i - 1][3]) % mod;
    }
    long sum = 0;
    for (int i = 0; i < 5; i++)
    {
      sum += records[n][i];
      sum %= mod;
    }
    return (int)sum;
  }

}
