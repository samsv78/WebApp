using System.Security.Cryptography;

namespace WebApplication1.Helpers
{
    public class CAes {
        
        static readonly string Password = string.Empty;
        private const int Bits = 128;
        private static byte[] Encrypt(byte[] clearData, byte[] key, byte[] iv) {
            var ms = new MemoryStream();

            var alg = Aes.Create();
            alg.Key = key;

            alg.IV = iv;
            var cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(clearData, 0, clearData.Length);
            cs.Close();
            var encryptedData = ms.ToArray();
            return encryptedData;
        }
        private static string Encrypt(string data, string password, int bits) {
            var clearBytes = System.Text.Encoding.Unicode.GetBytes(data);
            var pdb = new PasswordDeriveBytes(password,
                new byte[] {0x00, 0x01, 0x02, 0x1C, 0x1D, 0x1E, 0x03, 0x04, 0x05, 0x0F, 0x20, 0x21, 0xAD, 0xAF, 0xA4});

            if (bits == 128) {
                var encryptedData = Encrypt(clearBytes, pdb.GetBytes(16), pdb.GetBytes(16));
                return Convert.ToBase64String(encryptedData);
            }

            if (bits == 192) {
                var encryptedData = Encrypt(clearBytes, pdb.GetBytes(24), pdb.GetBytes(16));
                return Convert.ToBase64String(encryptedData);
            }

            if (bits == 256) {
                var encryptedData = Encrypt(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));
                return Convert.ToBase64String(encryptedData);
            }

            return string.Concat(bits);
        }
        private static byte[] Decrypt(byte[] cipherData, byte[] key, byte[] iv) {
            var ms = new MemoryStream();
            var alg = Aes.Create();
            alg.Key = key;
            alg.IV = iv;
            var cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(cipherData, 0, cipherData.Length);
            cs.Close();
            var decryptedData = ms.ToArray();
            return decryptedData;
        }
        private static string Decrypt(string data, string password, int bits) {
            var cipherBytes = Convert.FromBase64String(data);
            var pdb = new PasswordDeriveBytes(password,
                new byte[] {0x00, 0x01, 0x02, 0x1C, 0x1D, 0x1E, 0x03, 0x04, 0x05, 0x0F, 0x20, 0x21, 0xAD, 0xAF, 0xA4});

            if (bits == 128) {
                var decryptedData = Decrypt(cipherBytes, pdb.GetBytes(16), pdb.GetBytes(16));
                return System.Text.Encoding.Unicode.GetString(decryptedData);
            }

            if (bits == 192) {
                var decryptedData = Decrypt(cipherBytes, pdb.GetBytes(24), pdb.GetBytes(16));
                return System.Text.Encoding.Unicode.GetString(decryptedData);
            }

            if (bits == 256) {
                var decryptedData = Decrypt(cipherBytes, pdb.GetBytes(32), pdb.GetBytes(16));
                return System.Text.Encoding.Unicode.GetString(decryptedData);
            }

            return string.Concat(Bits);
        }
        public static string Encrypt(string data) {
            return Encrypt(data, Password, Bits);
        }
        public static string Decrypt(string data, string password) {
            return Decrypt(data, password, Bits);
        }

        public static string Decrypt(string data) {
            return Decrypt(data, Password, Bits);
        }
    }
}