using System.Linq;
using System;
using blockchaincore.Models;
using Newtonsoft;

namespace clientTest {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
            // Blockchain phillyCoin = new Blockchain ();
            // phillyCoin.AddBlock (new Block (DateTime.Now, null, "{sender:Henry,receiver:MaHesh,amount:10}"));
            // phillyCoin.AddBlock (new Block (DateTime.Now, null, "{sender:MaHesh,receiver:Henry,amount:5}"));
            // phillyCoin.AddBlock (new Block (DateTime.Now, null, "{sender:Mahesh,receiver:Henry,amount:5}"));
            
            // Console.WriteLine (phillyCoin.Chain[1].Data);

            // Console.WriteLine($"Is Chain Valid: {phillyCoin.IsValid()}");  
  
            // Console.WriteLine($"Update amount to 1000");  
            // phillyCoin.Chain[1].Data = "{sender:Henry,receiver:MaHesh,amount:1000}";  
            
            // Console.WriteLine($"Is Chain Valid: {phillyCoin.IsValid()}"); 

            // Console.WriteLine($"Update the entire chain");  

            // phillyCoin.Chain[2].PreviousHash = phillyCoin.Chain[1].Hash;  
            // phillyCoin.Chain[2].Hash = phillyCoin.Chain[2].CalculateHash();  
            // phillyCoin.Chain[3].PreviousHash = phillyCoin.Chain[2].Hash;  
            // phillyCoin.Chain[3].Hash = phillyCoin.Chain[3].CalculateHash();     


            var startTime = DateTime.Now;  
            
            Blockchain phillyCoin = new Blockchain();  
            phillyCoin.AddBlock(new Block(DateTime.Now, null, "{sender:Henry,receiver:MaHesh,amount:10}"));  
            phillyCoin.AddBlock(new Block(DateTime.Now, null, "{sender:MaHesh,receiver:Henry,amount:5}"));  
            phillyCoin.AddBlock(new Block(DateTime.Now, null, "{sender:Mahesh,receiver:Henry,amount:5}"));  
            
            var endTime = DateTime.Now;  
            
            Console.WriteLine($"Duration: {endTime - startTime}");  
            
            phillyCoin.Chain[2].PreviousHash = phillyCoin.Chain[1].Hash;  
            phillyCoin.Chain[2].Hash = phillyCoin.Chain[2].CalculateHash();  
            phillyCoin.Chain[3].PreviousHash = phillyCoin.Chain[2].Hash;  
            phillyCoin.Chain[3].Hash = phillyCoin.Chain[3].CalculateHash();     

        }
    }
}