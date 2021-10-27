using System;
using System.Security.Cryptography;
using rules;

namespace crypt
{
    public class RandomCrypt
    {
        public HMACSHA256 HMAC { get; private set; }
        //public byte[] Key { get; private set; }
        
        public RandomCrypt()
        {
            byte[] Key = new Byte[16];
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            rng.GetBytes(Key);
            HMAC = new HMACSHA256(Key);
        }

        public static int getComputerMove()
        {
            byte[] nums = new byte[4];
            RandomNumberGenerator move = RandomNumberGenerator.Create();
            move.GetBytes(nums);
            int choice = (int)(BitConverter.ToUInt32(nums) % Rules.Combs.Count);

            return choice;
        }
    }
}
