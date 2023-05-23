using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EncryptionController : ControllerBase
    {
        private readonly SymmetricAlgorithm _algorithm;

        public EncryptionController()
        {
            _algorithm = Aes.Create();
            _algorithm.Key = Encoding.UTF8.GetBytes("YourEncryptionKey123");
        }

        [HttpGet("encrypt/{text}")]
        public ActionResult<string> Encrypt(string text)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(text);
            byte[] encryptedBytes;

            using (ICryptoTransform encryptor = _algorithm.CreateEncryptor())
            {
                encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
            }

            string encryptedText = Encoding.UTF8.GetString(encryptedBytes);
            return encryptedText;
        }

        [HttpGet("decrypt/{encryptedText}")]
        public ActionResult<string> Decrypt(string encryptedText)
        {
            byte[] encryptedBytes = Encoding.UTF8.GetBytes(encryptedText);
            byte[] decryptedBytes;

            using (ICryptoTransform decryptor = _algorithm.CreateDecryptor())
            {
                decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
            }

            string decryptedText = Encoding.UTF8.GetString(decryptedBytes);
            return decryptedText;
        }
    }
}
