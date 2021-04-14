using System.Security.Cryptography;
using System.Text;

namespace AspNetCoreDDD.Infrastructure.Security
{
    public class DealingHash
    {
        private HashAlgorithm _hashAlgorithm;

        public DealingHash(HashAlgorithm hashAlgorithm) => _hashAlgorithm = hashAlgorithm;

        public string GenerateHash(string password)
        {
            var valueEncoded = Encoding.UTF8.GetBytes(password);
            var passwordEncrypted = _hashAlgorithm.ComputeHash(valueEncoded);
            return EncryptedValue(passwordEncrypted).ToString();
        }

        public bool CheckHash(string passwordInput, string passwordRegistered)
        {
            var passwordEncrypted = _hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(passwordInput));
            return EncryptedValue(passwordEncrypted).ToString() == passwordRegistered;
        }

        private static StringBuilder EncryptedValue(byte[] passwordEncrypted)
        {
            var sb = new StringBuilder();

            foreach (var character in passwordEncrypted)
            {
                sb.Append(character.ToString("X2"));
            }

            return sb;
        }
    }
}
