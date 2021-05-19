using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                //METHOT SONUNDA, İÇİ BOŞ OLARAK VERİLEN PASSWORDHASH VE PASSWORDSALT, BURADA ATANAN DEĞERLERE SAHİP OLACAK.
                //(REFERANS TİP MANTIĞINDA ÇALIŞACAK)
            }
        }




        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            //HASHLANMİŞ VERİ GERİ ÇÖZÜLEMEZ. GELEN ŞİFREYİ HASHLE, HASHLER AYNI MI KONTROL ET.

            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for(int i = 0; i < computeHash.Length; i++)
                {
                    //OLUŞAN HASH İLE PASSWORD HASH'I KARŞILAŞTIR.
                    if(computeHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
