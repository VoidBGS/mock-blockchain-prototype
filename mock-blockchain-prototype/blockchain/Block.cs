using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace mock_blockchain_prototype.blockchain
{
    public class Block
    {
        public string Hash{ get; set; }

        public string PrevHash{ get; set; }

        public DateTime Timestamp{ get; set; }

        public string Data { get; set; }

        public Block(string prevHash, string data)
        {
            this.PrevHash = prevHash;
            this.Data = data;
            this.Timestamp = DateTime.UtcNow;
            this.CalculateHash();
        }

        private void CalculateHash()
        {
            var rawHash = Convert.ToString(this.PrevHash) + Convert.ToString(this.Timestamp) + Convert.ToString(this.Timestamp);
            this.Hash = ComputeSha256Hash(rawHash);
        }

        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
