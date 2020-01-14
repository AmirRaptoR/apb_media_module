using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Volo.Abp.Modularity;

namespace Farazpardazan.Media
{
    [DependsOn(typeof(MediaDomainSharedModule))]
    public class MediaDomainModule : AbpModule
    {
    }

    public static class HashHelper
    {
        private static string CreateHash(byte[] input, HashAlgorithm algorithm)
        {
            var hashBytes = algorithm.ComputeHash(input);
            return hashBytes.ToHexString();
        }
        
        private static string CreateHash(Stream input, HashAlgorithm algorithm)
        {
            var hashBytes = algorithm.ComputeHash(input);
            return hashBytes.ToHexString();
        }


        public static string CreateMd5(string input)
        {
            using var md5 = MD5.Create();
            return CreateHash(Encoding.UTF8.GetBytes(input), md5);
        }

        public static string CreateMd5(byte[] input)
        {
            using var md5 = MD5.Create();
            return CreateHash(input, md5);
        }

        public static string CreateMd5(Stream input)
        {
            using var md5 = MD5.Create();
            return CreateHash(input, md5);
        }
        
        public static string CreateSha1(string input)
        {
            using var sha1 = System.Security.Cryptography.SHA1.Create();
            return CreateHash(Encoding.UTF8.GetBytes(input), sha1);
        }

        public static string CreateSha1(byte[] input)
        {
            using var sha1 = SHA1.Create();
            return CreateHash(input, sha1);
        }

        public static string CreateSha1(Stream input)
        {
            using var sha1 = SHA1.Create();
            return CreateHash(input, sha1);
        }
        
        public static string CreateSha256(string input)
        {
            using var hashAlgorithm = SHA256.Create();
            return CreateHash(Encoding.UTF8.GetBytes(input), hashAlgorithm);
        }

        public static string CreateSha256(byte[] input)
        {
            using var hashAlgorithm = SHA256.Create();
            return CreateHash(input, hashAlgorithm);
        }

        public static string CreateSha256(Stream input)
        {
            using var hashAlgorithm = SHA256.Create();
            return CreateHash(input, hashAlgorithm);
        }
        
        public static string CreateHmac(string input)
        {
            using var hashAlgorithm = HMAC.Create();
            return CreateHash(Encoding.UTF8.GetBytes(input), hashAlgorithm);
        }

        public static string CreateHmac(byte[] input)
        {
            using var hashAlgorithm = HMAC.Create();
            return CreateHash(input, hashAlgorithm);
        }

        public static string CreateHmac(Stream input)
        {
            using var hashAlgorithm = HMAC.Create();
            return CreateHash(input, hashAlgorithm);
        }
    }
        
        public static class StringHelper
        {
            private static readonly Random Random = new Random();

            public static string CreateRandom(int length = 16)
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789qwertyuiopasdfghjklzxcvbnm";
                return new string(Enumerable.Repeat(chars, length)
                    .Select(s => s[Random.Next(s.Length)]).ToArray());
            }

            public static string ToCamelCase(this string str)
            {
                return str.Substring(0, 1).ToLower() + str.Substring(1);
            }

            public static string ToHexString(this byte[] data)
            {
                var sb = new StringBuilder();
                foreach (var t in data)
                {
                    sb.Append(t.ToString("X2"));
                }

                return sb.ToString();
            }

            public static void ThrowIfIsNullOrWhiteSpace(this string str, string argumentName)
            {
                if (string.IsNullOrWhiteSpace(str))
                {
                    throw new ArgumentException($"{argumentName} can not be null or white space");
                }
            }
        
        
            public static void ThrowIfIsNullOrEmpty(this string str, string argumentName)
            {
                if (string.IsNullOrEmpty(str))
                {
                    throw new ArgumentException($"{argumentName} can not be null or empty");
                }
            }
        }


}