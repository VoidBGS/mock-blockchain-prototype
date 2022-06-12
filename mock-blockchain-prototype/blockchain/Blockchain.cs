using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mock_blockchain_prototype.blockchain
{
    public class Blockchain
    {
        private List<Block> blocks;

        public Blockchain()
        {
            this.blocks = new List<Block>();
            Block genesis = this.GenesisBlock();
            this.blocks.Add(genesis);
        }

        public void AddBlock(Block block)
        {
            this.blocks.Add(block);
        }

        public List<Block> GetBlockChain()
        {
            return this.blocks;
        }

        public Block GetLastBlock()
        {
            return this.GetBlockChain().Last();
        }

        public Block GenesisBlock()
        {
            return new Block("", "Genesis Block");
        }
    }
}
