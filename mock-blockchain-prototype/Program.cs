using mock_blockchain_prototype.blockchain;

Console.WriteLine("Initializing Blockchain...");
Blockchain blockchain = new Blockchain();
Console.WriteLine("Blocks in the blockchain:" + blockchain.GetBlockChain().Count);
Console.WriteLine($"Add the number of transactions that you want to see");
int numberOfIterations = Convert.ToInt32(Console.ReadLine());
Random rnd = new Random();
List<string>names = new List<string>();
names.Add("Nick");
names.Add("Kris");
names.Add("Zach");
names.Add("Zoe");
names.Add("Dan");
names.Add("Joe");

//Mock transactions, have fun
for (int i = 0; i < numberOfIterations; i++)
{
    Thread.Sleep(rnd.Next(500, 2000));
    int sellingPerson = rnd.Next(0, 5);
    int buyingPerson = rnd.Next(0, 5);
    int nrOfKrisCoinsSold = rnd.Next(1, 8);
    if(sellingPerson == buyingPerson && sellingPerson == 0)
    {
        buyingPerson++;
    }
    else if (sellingPerson == buyingPerson && sellingPerson == 5)
    {
        buyingPerson--;
    }
    else if(sellingPerson == buyingPerson)
    {
        buyingPerson++;
    }

    Block prevTransaction = blockchain.GetLastBlock();
    Block transaction = new Block(prevTransaction.Hash, $"{names[sellingPerson]} sold {nrOfKrisCoinsSold} krisCoin to {names[buyingPerson]}");
    blockchain.AddBlock(transaction);
    Console.WriteLine($"Transaction added: {transaction.Hash} prevous hash: {transaction.PrevHash} created at: {transaction.Timestamp} Data contains: {transaction.Data}");
}
Console.WriteLine($"End of mock blockchain demo. In real life a blockchain is far more complex as it requires transaction information, proof of workload (computational power) and a consensus mechanism");