﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt)
        {// Ona verdiğimiz passwordün Hashini oluşturacak ve aynı zamnanda saltını vericek bize 
            using (var hmac=new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        public static bool VerifyPasswordHash(string password,byte []passwordHash,byte[]passwordSalt)
        {//Password Hashi doğrulama veri tabanındaki hash değeriyle elimdeki hash değeri aynıysa true dönüyoruz değilse false

            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i]!=passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public static bool VerifyPasswordHash(string password, object passwordHash, object passwordSalt)
        {
            throw new NotImplementedException();
        }
    }
    
}
