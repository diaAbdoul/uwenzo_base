using System.Collections.Generic;
using System;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace  core.Models {
    public class Block {
        public int Index { get; set; }
        public DateTime TimeStamp { get; set; }
        public string PreviousHash { get; set; }
        public string Hash { get; set; }
        public IList<core.Models.Transaction> Transactions { get; set; } 
        public int Nonce { get; set; }

        public Block (DateTime timeStamp, string previousHash, List<core.Models.Transaction> transactions) {
            Index = 0;
            TimeStamp = timeStamp;
            PreviousHash = previousHash;
            Transactions = transactions;
            Hash = CalculateHash (2);
        }

        public string CalculateHash (int difficulty) {
            SHA256 sha256 = SHA256.Create();  
  
            byte[] inputBytes = Encoding.ASCII.GetBytes($"{TimeStamp}-{PreviousHash ?? ""}-{JsonConvert.SerializeObject(Transactions)}-{Nonce}-{difficulty}");  
            byte[] outputBytes = sha256.ComputeHash(inputBytes);  
        
            return Convert.ToBase64String(outputBytes); 
        }

        public void Mine (int difficulty) {
            var leadingZeros = new string ('0', difficulty);
            Console.WriteLine (leadingZeros);

            while (this.Hash.Substring(0, difficulty) != leadingZeros) {
                Console.WriteLine (this.Nonce);

                this.Nonce++;
                this.Hash = this.CalculateHash (difficulty);

                Console.WriteLine (this.Hash);
            }
        }
    }
}