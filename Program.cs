// See https://aka.ms/new-console-template for more information
using System.Threading.Tasks.Dataflow;

Console.WriteLine("Hello, World!");

var n = 9;
var ar = new List<int> { 10, 20, 20, 10, 10, 30, 50, 10, 20 };

var response = SockMerchant(n, ar);
Console.WriteLine(response);

var response2 = SockMerchant2(n, ar);
Console.WriteLine(response2);

static int SockMerchant(int? n, List<int> ar)
{
    if (n == 0 || n == null || ar == null || ar.Count == 0 || n != ar.Count)
    {
        return 0;
    }
    ar.Sort();
    int pairCount = 0;
    int i = 0;

    while (i + 1 < ar.Count)
    {
        if (ar[i] == ar[i + 1])
        {
            pairCount = pairCount + 1;
            i = i + 2;
        }
        else
        {
            i = i + 1;
        }
    }
    return pairCount;
}

static int SockMerchant2(int? n, List<int> ar)
{
    if (n == 0 || n == null || ar == null || ar.Count == 0 || n != ar.Count)
    {
        return 0;
    }

    int pairCount = 0;
    int i = 0;
    var br = new List<int>();

    while (i + 1 < ar.Count)
    {
        var numberofPair = ar.Where(x => x == ar[i] && !br.Any(z => z == ar[i])).Count() / 2;
        if (numberofPair > 0)
        {
            pairCount = pairCount + numberofPair;
            br.Add(ar[i]);
        }
        i++;
    }
    return pairCount;
}

Console.ReadLine();