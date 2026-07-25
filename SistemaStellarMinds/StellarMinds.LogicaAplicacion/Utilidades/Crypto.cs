using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;

namespace StellarMinds.LogicaAplicacion.Utilidades
{
    public static class Crypto
    {
        public static string Hash(string textoPlano)
        {
            return BCrypt.Net.BCrypt.HashPassword(textoPlano);
        }

        public static bool Verify(string textoPlano, string hashGuardado)
        {
            if (string.IsNullOrWhiteSpace(textoPlano) || string.IsNullOrWhiteSpace(hashGuardado))
                return false;

            if (EsHashBcrypt(hashGuardado))
            {
                return BCrypt.Net.BCrypt.Verify(textoPlano, hashGuardado);
            }

            using SHA256 sha256 = SHA256.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(textoPlano);
            byte[] hash = sha256.ComputeHash(bytes);
            string hashTextoPlano = Convert.ToBase64String(hash);

            return string.Equals(hashTextoPlano, hashGuardado, StringComparison.Ordinal);
        }

        public static bool NeedsRehash(string hashGuardado)
        {
            return !string.IsNullOrWhiteSpace(hashGuardado) && !EsHashBcrypt(hashGuardado);
        }

        private static bool EsHashBcrypt(string hash)
        {
            return hash.StartsWith("$2a$")
                || hash.StartsWith("$2b$")
                || hash.StartsWith("$2y$");
        }
    }
}
