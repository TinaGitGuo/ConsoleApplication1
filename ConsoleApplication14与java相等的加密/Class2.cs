using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
//import java.security.PrivateKey;
//   import java.security.Provider;
//   import java.security.PublicKey;
//   import java.security.Security;
//   import java.security.Signature;
//   import java.security.spec.KeySpec;
//   import javax.crypto.Cipher;
//   import javax.crypto.SecretKey;
//   import javax.crypto.SecretKeyFactory;
//   import javax.crypto.spec.IvParameterSpec;
//   import javax.crypto.spec.PBEKeySpec;
//   import javax.crypto.spec.SecretKeySpec;
//   import org.bouncycastle.jce.provider.BouncyCastleProvider;
namespace ConsoleApplication14与java相等的加密
{
    public class SGSecuror
    {
        public SGSecuror()
        {
            //Provider p = Security.getProvider("BC");
            //if (p == null)
            //{
            //    Security.addProvider(new BouncyCastleProvider());
            //}
        }
        public static readonly byte[] iv_as_AllZEROS = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public static bool verifyDataRSA(byte[] data, byte[] singature, string publicKey)
        {
            RSACryptoServiceProvider RSAalg = new RSACryptoServiceProvider();
            if (data == null) {
                throw new Exception("Data is empty");
            }
            if (data.Length == 0) {
                throw new Exception("Data length is zero");
            }

            if (singature == null) {
                throw new Exception("Signature is empty");
            }
            if (singature.Length == 0) {
                throw new Exception("Signature length is zero");
            }
            if (publicKey == null) {
                throw new Exception("Certificate Public Key is empty");
            }
            //if (RSAalg.SignatureAlgorithm.Equals("http://www.w3.org/2000/09/xmldsig#rsa-sha1")) {
            //    throw new Exception("Certificate Algorithm is not RSA");
            //}
            try
            {
                RSAalg.FromXmlString(publicKey);

                return RSAalg.VerifyData(data, "SHA1", singature);

                //Signature sig = Signature.getInstance("SHA1WithRSA", "BC");
                //sig.initVerify(publicKey);
                //sig.update(data);
                //return sig.verify(singature);
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public static byte[] decryptRSA(byte[] encrypted, string privateKey)  
        {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            if (encrypted == null) {
                throw new Exception("Data is empty");
            }
     if (encrypted.Length == 0) {
                throw new Exception("Data length is zero");
            }
     if (privateKey == null) {
                throw new Exception("Certificate Private Key is empty");
            }
            //if (RSA.SignatureAlgorithm.Equals("http://www.w3.org/2000/09/xmldsig#rsa-sha1") ) {
            //           throw new Exception("Certificate Algorithm is not RSA");
            //       }      RSA.SignatureAlgorithm always is "http://www.w3.org/2000/09/xmldsig#rsa-sha1"
            try
            {
              
              RSA.FromXmlString(privateKey);
              return  RSA.Decrypt(encrypted,RSAEncryptionPadding.OaepSHA1);

                //byte[] encryptionByte = null;
                //Cipher cipher = Cipher.getInstance("RSA/ECB/PKCS1Padding");
                //cipher.init(2, privateKey);
                //byte[] someDecrypted = cipher.update(encrypted);
                //byte[] moreDecrypted = cipher.doFinal();
                //byte[] decrypted = new byte[someDecrypted.length + moreDecrypted.length];
                //System.arraycopy(someDecrypted, 0, decrypted, 0, someDecrypted.length);
                //System.arraycopy(moreDecrypted, 0, decrypted, someDecrypted.length, moreDecrypted.length);
                //return decrypted;
            }
     catch (Exception ex) {
                throw ex;
            }
        }

        public static byte[] signDataRSA(byte[] data, string privateKey)  
        {
            RSACryptoServiceProvider RSAalg = new RSACryptoServiceProvider();
        if (data == null) {
                throw new Exception("Data is empty");
            }
        if (data.Length == 0) {
                throw new Exception("Data length is zero");
            }
        if (privateKey == null) {
                throw new Exception("Certificate Private Key is empty");
            }
        //if (!RSAalg.SignatureAlgorithm.Equals("RSA")) {
        //        throw new Exception("Certificate Algorithm is not RSA");
        //    }
        try
        {
                RSAalg.FromXmlString(privateKey);
                return RSAalg.SignData(data, "SHA1");
                //Signature signature = Signature.getInstance("SHA1WithRSA", "BC");
                //signature.initSign(privateKey);
                //signature.update(data);
                //return signature.sign();
            }
        catch (Exception ex) {
                throw ex;
            }
        }

        public static byte[] encryptRSA(byte[] plainData, string pubKey)  
        {
          
        if (plainData == null) {
                throw new Exception("Data is empty");
            }
        if (plainData.Length == 0) {
                throw new Exception("Data length is zero");
            }
        if (pubKey == null) {
                throw new Exception("Certificate Public Key is empty");
            }
            try
            {
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    if (!RSA.SignatureAlgorithm.Equals("RSA"))
                    {
                        throw new Exception("Certificate Algorithm is not RSA");
                    }

                    RSA.FromXmlString(pubKey);
                    return    RSA.Encrypt(plainData, RSAEncryptionPadding.OaepSHA1);
                }
                   

                //byte[] encryptionByte = null;
                //Cipher cipher = Cipher.getInstance("RSA/ECB/PKCS1Padding");
                //cipher.init(1, pubKey);
                //byte[] someData = cipher.update(plainData);
                //byte[] moreData = cipher.doFinal();
                //byte[] encrypted = new byte[someData.length + moreData.length];
                //System.arraycopy(someData, 0, encrypted, 0, someData.length);
                //System.arraycopy(moreData, 0, encrypted, someData.length, moreData.length);
                //return encrypted;
            }
        catch (Exception ex) {
                throw ex;
            }
        }

        public static byte[] decryptAES(byte[] key, byte[] encrypted, byte[] iv)
        
        {
        if (key == null) {
                throw new Exception("Key is empty");
            }

        if ((key.Length != 16) && (key.Length != 24) && (key.Length != 32)) {
                throw new Exception("Key Length is invalid. It can be only 16,24 or 32.");
            }

        if (iv == null) {
                throw new Exception("IV is empty");
            }
           
                if (encrypted == null) {
                throw new Exception("Data is empty");
               }
            try
            {
                Aes aes = new AesCryptoServiceProvider();
                aes.Key = key;
                aes.IV = iv;

                byte[] decryptBytes;
                using (MemoryStream ms = new MemoryStream(encrypted))
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cs))
                        {
                            string result = reader.ReadToEnd() ;
                            decryptBytes = GetBytes(result);
                            return decryptBytes;
                        }
                    }
                }

                //SecretKeySpec skeySpec = new SecretKeySpec(key, "AES");
                //Cipher cipher = Cipher.getInstance("AES/CBC/PKCS5Padding");
                //IvParameterSpec ivspec = new IvParameterSpec(iv);
                //cipher.init(2, skeySpec, ivspec);
                //return cipher.doFinal(encrypted);
            }
        catch (Exception e) {
                throw e;
            }
        }
        #region other
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static byte[] GetBytes(string input)
        {
            string[] sInput = input.Split("-".ToCharArray());
            byte[] inputBytes = new byte[sInput.Length];
            for (int i = 0; i < sInput.Length; i++)
            {
                inputBytes[i] = byte.Parse(sInput[i], NumberStyles.HexNumber);
            }
            return inputBytes;
        }
        #endregion
        public static byte[] generateKeyAESKey(byte[] password, byte[] iv, int iterationCount, int keyLength)
        {
            if (password == null)
            {
                throw new Exception("Password is empty");
            }

            if (password.Length == 0)
            {
                throw new Exception("Password has zero length");
            }

            if (iv == null)
            {
                throw new Exception("IV is empty");
            }

            if (iv.Length == 0)
            {
                throw new Exception("IV has zero length");
            }

            if (iterationCount < 1000)
            {
                throw new Exception("Iteration Count should be minimum than 1000");
            }

            if ((keyLength != 128) && (keyLength != 192) && (keyLength != 256))
            {
                throw new Exception("Key Length is invalid. It can be only 128 or 192 or 256.");
            }
            try
            {
                
                PasswordDeriveBytes a =new  PasswordDeriveBytes(password, iv);
               return a.CryptDeriveKey("SHA1","AES",keyLength,iv);
                //KeySpec keySpec = new PBEKeySpec(password, iv, iterationCount, keyLength);
                //SecretKeyFactory keyFactory = SecretKeyFactory.getInstance("PBKDF2WithHmacSHA1");
                //byte[] keyBytes = keyFactory.generateSecret(keySpec).getEncoded();
                //SecretKey skey = new SecretKeySpec(keyBytes, "AES");
                //return skey.getEncoded();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static byte[] encryptAES(byte[] key, byte[] clear, byte[] iv)
        {
            if (key == null)
            {
                throw new Exception("Key is empty");
            }

            if ((key.Length != 16) && (key.Length != 24) && (key.Length != 32))
            {
                throw new Exception("Key Length is invalid. It can be only 16,24 or 32.");
            }

            if (iv == null)
            {
                throw new Exception("IV is empty");
            }

            if (clear == null)
            {
                throw new Exception("Data is empty");
            }
            try
            {
                using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
                {
                    aesAlg.Key = key;
                    aesAlg.IV = iv;

                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                swEncrypt.Write(clear);
                            }
                            byte[] encrypted = msEncrypt.ToArray();
                            return encrypted;
                        }
                    }
                }
                //SecretKeySpec skeySpec = new SecretKeySpec(key, "AES");
                //Cipher cipher = Cipher.getInstance("AES/CBC/PKCS5Padding", "BC");
                //IvParameterSpec ivspec = new IvParameterSpec(iv);
                //cipher.init(1, skeySpec, ivspec);
                //return cipher.doFinal(clear);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    } }
