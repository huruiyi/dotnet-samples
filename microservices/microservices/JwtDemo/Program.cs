using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;

namespace JwtDemo
{
    /*

    标准中注册的声明 :
        iss ： jwt签发者
        sub：jwt所面向的用户
        aud：接收jwt的一方
        exp：jwt的过期时间，这个过期时间必须要大于签发时间
        nbf：定义在什么时间之前，该jwt都是不可用的.
        iat ：jwt的签发时间
        jti  ：jwt的唯一身份标识，主要用来作为一次性token,从而回避重放攻击。
    */

    internal class Program
    {
        private static string GetToken()
        {
            var payload = new Dictionary<string, object>
            {
                { "UserId", 123 },
                { "UserName", "admin" },
                {"exp",DateTimeOffset.Now.AddMinutes(1).ToUnixTimeSeconds()}
            };
            string secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";//不要泄露

            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            string token = encoder.Encode(payload, secret);
            Console.WriteLine(token);
            return token;
        }

        private static void Main(string[] args)
        {
            Console.WriteLine(DateTimeOffset.Now.ToUnixTimeSeconds());
            Console.WriteLine(DateTimeOffset.Now.AddMinutes(1).ToUnixTimeSeconds());

            string token = GetToken();

            var secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                var json = decoder.Decode(token, secret, true);
                Console.WriteLine(json);
            }
            catch (FormatException)
            {
                Console.WriteLine("Token format invalid");
            }
            catch (TokenExpiredException)
            {
                Console.WriteLine("Token has expired");
            }
            catch (SignatureVerificationException)
            {
                Console.WriteLine("Token has invalid signature");
            }

            Console.ReadKey();
        }
    }
}