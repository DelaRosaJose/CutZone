using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace CutZone.Helper
{
    internal class Hasher
    {
        public static string ComputeHash(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            var bytes = Encoding.UTF8.GetBytes(text);
#pragma warning disable SYSLIB0021 // Type or member is obsolete
#pragma warning disable SYSLIB00 // Type or member is obsolete
            using SHA1Managed sha1 = new();
#pragma warning restore SYSLIB00 // Type or member is obsolete
#pragma warning restore SYSLIB0021 // Type or member is obsolete
            var sha1Bytes = sha1.ComputeHash(bytes);
            var b64 = Convert.ToBase64String(sha1Bytes);
            b64 = b64.Replace('+', '-').Replace(' ', '-').Replace('/', '_');
            return b64;
        }
    }
}
