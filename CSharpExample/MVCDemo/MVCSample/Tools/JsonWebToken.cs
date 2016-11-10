using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;

namespace MVCSample.Tools
{
    public static class JsonWebToken
    {
        private static Dictionary<JwtHashAlgorithm, Func<byte[], byte[], byte[]>> HashAlgorithms;

        private static JavaScriptSerializer jsonSerializer;

        static JsonWebToken()
        {
            JsonWebToken.jsonSerializer = new JavaScriptSerializer();
            Dictionary<JwtHashAlgorithm, Func<byte[], byte[], byte[]>> dictionary = new Dictionary<JwtHashAlgorithm, Func<byte[], byte[], byte[]>>();
            dictionary.Add(JwtHashAlgorithm.HS256, delegate(byte[] key, byte[] value)
            {
                byte[] result;
                using (HMACSHA256 hMACSHA = new HMACSHA256(key))
                {
                    result = hMACSHA.ComputeHash(value);
                }
                return result;
            });
            dictionary.Add(JwtHashAlgorithm.HS384, delegate(byte[] key, byte[] value)
            {
                byte[] result;
                using (HMACSHA384 hMACSHA = new HMACSHA384(key))
                {
                    result = hMACSHA.ComputeHash(value);
                }
                return result;
            });
            dictionary.Add(JwtHashAlgorithm.HS512, delegate(byte[] key, byte[] value)
            {
                byte[] result;
                using (HMACSHA512 hMACSHA = new HMACSHA512(key))
                {
                    result = hMACSHA.ComputeHash(value);
                }
                return result;
            });
            JsonWebToken.HashAlgorithms = dictionary;
        }

        public static string Encode(object payload, byte[] key, JwtHashAlgorithm algorithm)
        {
            List<string> list = new List<string>();
            var obj = new
            {
                typ = "JWT",
                alg = algorithm.ToString()
            };
            byte[] bytes = Encoding.UTF8.GetBytes(JsonWebToken.jsonSerializer.Serialize(obj));
            byte[] bytes2 = Encoding.UTF8.GetBytes(JsonWebToken.jsonSerializer.Serialize(payload));
            list.Add(JsonWebToken.Base64UrlEncode(bytes));
            list.Add(Base64UrlEncode(bytes2));
            string s = string.Join(".", list.ToArray());
            byte[] bytes3 = Encoding.UTF8.GetBytes(s);
            byte[] input = HashAlgorithms[algorithm](key, bytes3);
            list.Add(JsonWebToken.Base64UrlEncode(input));
            return string.Join(".", list.ToArray());
        }

        public static string Encode(object payload, string key, JwtHashAlgorithm algorithm)
        {
            return JsonWebToken.Encode(payload, Encoding.UTF8.GetBytes(key), algorithm);
        }

        public static string Decode(string token, byte[] key, bool verify = true)
        {
            string[] array = token.Split(new char[]
			{
				'.'
			});
            string text = array[0];
            string text2 = array[1];
            byte[] inArray = JsonWebToken.Base64UrlDecode(array[2]);
            string @string = Encoding.UTF8.GetString(JsonWebToken.Base64UrlDecode(text));
            Dictionary<string, object> dictionary = jsonSerializer.Deserialize<Dictionary<string, object>>(@string);
            string string2 = Encoding.UTF8.GetString(Base64UrlDecode(text2));
            if (verify)
            {
                byte[] bytes = Encoding.UTF8.GetBytes(text + "." + text2);
                string algorithm = (string)dictionary["alg"];
                byte[] inArray2 = JsonWebToken.HashAlgorithms[JsonWebToken.GetHashAlgorithm(algorithm)](key, bytes);
                string text3 = Convert.ToBase64String(inArray);
                string text4 = Convert.ToBase64String(inArray2);
                if (text3 != text4)
                {
                    throw new SignatureVerificationException(string.Format("Invalid signature. Expected {0} got {1}", text3, text4));
                }
            }
            return string2;
        }

        public static string Decode(string token, string key, bool verify = true)
        {
            return JsonWebToken.Decode(token, Encoding.UTF8.GetBytes(key), verify);
        }

        public static object DecodeToObject(string token, string key, bool verify = true)
        {
            string input = JsonWebToken.Decode(token, key, verify);
            return JsonWebToken.jsonSerializer.Deserialize<Dictionary<string, object>>(input);
        }

        private static JwtHashAlgorithm GetHashAlgorithm(string algorithm)
        {
            if (algorithm != null)
            {
                if (algorithm == "HS256")
                {
                    return JwtHashAlgorithm.HS256;
                }
                if (algorithm == "HS384")
                {
                    return JwtHashAlgorithm.HS384;
                }
                if (algorithm == "HS512")
                {
                    return JwtHashAlgorithm.HS512;
                }
            }
            throw new SignatureVerificationException("Algorithm not supported.");
        }

        public static string Base64UrlEncode(byte[] input)
        {
            string text = Convert.ToBase64String(input);
            text = text.Split(new char[]
			{
				'='
			})[0];
            text = text.Replace('+', '-');
            return text.Replace('/', '_');
        }

        public static byte[] Base64UrlDecode(string input)
        {
            string text = input.Replace('-', '+');
            text = text.Replace('_', '/');
            switch (text.Length % 4)
            {
                case 0:
                    goto IL_60;
                case 2:
                    text += "==";
                    goto IL_60;
                case 3:
                    text += "=";
                    goto IL_60;
            }
            throw new Exception("Illegal base64url string!");
        IL_60:
            return Convert.FromBase64String(text);
        }
    }
}