using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography.X509Certificates;
//import java.security.PrivateKey;
//import java.security.Provider;
//import java.security.PublicKey;
//import java.security.Security;
//import java.security.Signature;
//import java.security.spec.KeySpec;
//import javax.crypto.Cipher;
//import javax.crypto.SecretKey;
//import javax.crypto.SecretKeyFactory;
//import javax.crypto.spec.IvParameterSpec;
//import javax.crypto.spec.PBEKeySpec;
//import javax.crypto.spec.SecretKeySpec;
//import org.bouncycastle.jce.provider.BouncyCastleProvider;
namespace ConsoleApplication14与java相等的加密
{
      public class SGSecuror
     {
        public static readonly byte[] iv_as_AllZEROS = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
       
    public SGSecuror() {
            X509Certificate2 x509 = new X509Certificate2(Path, "12345678");
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] hashbytes = sha1.ComputeHash(messagebytes); //对要签名的数据进行哈希 
            RSAPKCS1SignatureFormatter signe = new RSAPKCS1SignatureFormatter();
            signe.SetKey(x509.PrivateKey); //设置签名用到的私钥 
            signe.SetHashAlgorithm("SHA1"); //设置签名算法 
            byte[] reslut = signe.CreateSignature(hashbytes);

            Provider p = System.Security.getProvider("BC");
     if (p == null) {
       Security.addProvider(new BouncyCastleProvider());
     }
    }

    public static bool verifyDataRSA(byte[] data, byte[] singature, PublicKey publicKey)  
    {
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
     if (publicKey.GetHashCode().CompareTo("RSA") != 0) {
            throw new Exception("Certificate Algorithm is not RSA");
        }
     try
     {
                Signature sig = new Signature("SHA1WithRSA", "BC");
                sig..getInstance("SHA1WithRSA", "BC");
            sig.initVerify(publicKey);
            sig.update(data);
            return sig.verify(singature);
        }
     catch (Exception ex) {
            throw ex;
        }
    }

    public static byte[] decryptRSA(byte[] encrypted, PublicKey privateKey)  
    {
     if (encrypted == null) {
            throw new Exception("Data is empty");
        }
     if (encrypted.length == 0) {
            throw new Exception("Data length is zero");
        }
     if (privateKey == null) {
            throw new Exception("Certificate Private Key is empty");
        }
     if (privateKey.getAlgorithm().compareTo("RSA") != 0) {
            throw new Exception("Certificate Algorithm is not RSA");
        }
     try {
            byte[] encryptionByte = null;
                CipherData cipher = Cipher.getInstance("RSA/ECB/PKCS1Padding");
            cipher.init(2, privateKey);
            byte[] someDecrypted = cipher.update(encrypted);
            byte[] moreDecrypted = cipher.doFinal();
            byte[] decrypted = new byte[someDecrypted.length + moreDecrypted.length];
            System.arraycopy(someDecrypted, 0, decrypted, 0, someDecrypted.length);
            System.arraycopy(moreDecrypted, 0, decrypted, someDecrypted.length, moreDecrypted.length);
            return decrypted;
        }
     catch (Exception ex) {
            throw ex;
        }
    }

    public static byte[] signDataRSA(byte[] data, PrivateKey privateKey) throws Exception
    {
     if (data == null) {
            throw new Exception("Data is empty");
        }
     if (data.length == 0) {
            throw new Exception("Data length is zero");
        }
     if (privateKey == null) {
            throw new Exception("Certificate Private Key is empty");
        }
     if (privateKey.getAlgorithm().compareTo("RSA") != 0) {
            throw new Exception("Certificate Algorithm is not RSA");
        }
     try
     {
            Signature signature = Signature.getInstance("SHA1WithRSA", "BC");
            signature.initSign(privateKey);
            signature.update(data);
            return signature.sign();
        }
     catch (Exception ex) {
            throw ex;
        }
    }

    public static byte[] encryptRSA(byte[] plainData, PublicKey pubKey) throws Exception
    {
     if (plainData == null) {
            throw new Exception("Data is empty");
        }
     if (plainData.length == 0) {
            throw new Exception("Data length is zero");
        }
     if (pubKey == null) {
            throw new Exception("Certificate Public Key is empty");
        }
     if (pubKey.getAlgorithm().compareTo("RSA") != 0) {
            throw new Exception("Certificate Algorithm is not RSA");
        }
     try
     {
            byte[] encryptionByte = null;
            Cipher cipher = Cipher.getInstance("RSA/ECB/PKCS1Padding");
            cipher.init(1, pubKey);
            byte[] someData = cipher.update(plainData);
            byte[] moreData = cipher.doFinal();
            byte[] encrypted = new byte[someData.length + moreData.length];
            System.arraycopy(someData, 0, encrypted, 0, someData.length);
            System.arraycopy(moreData, 0, encrypted, someData.length, moreData.length);
            return encrypted;
        }
     catch (Exception ex) {
            throw ex;
        }
    }

    public static byte[] decryptAES(byte[] key, byte[] encrypted, byte[] iv)
     throws Exception
    {
     if (key == null) {
            throw new Exception("Key is empty");
        }
     
     if ((key.length != 16) && (key.length != 24) && (key.length != 32)) {
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
            SecretKeySpec skeySpec = new SecretKeySpec(key, "AES");
            Cipher cipher = Cipher.getInstance("AES/CBC/PKCS5Padding");
            IvParameterSpec ivspec = new IvParameterSpec(iv);
            cipher.init(2, skeySpec, ivspec);
            return cipher.doFinal(encrypted);
        }
     catch (Exception e) {
            throw e;
        }
    }

    public static byte[] generateKeyAESKey(char[] password, byte[] iv, int iterationCount, int keyLength) throws Exception
    {
     if (password == null) {
            throw new Exception("Password is empty");
        }
     
     if (password.length == 0) {
            throw new Exception("Password has zero length");
        }
     
     if (iv == null) {
            throw new Exception("IV is empty");
        }
     
     if (iv.length == 0) {
            throw new Exception("IV has zero length");
        }
     
     if (iterationCount < 1000) {
            throw new Exception("Iteration Count should be minimum than 1000");
        }
     
     if ((keyLength != 128) && (keyLength != 192) && (keyLength != 256)) {
            throw new Exception("Key Length is invalid. It can be only 128 or 192 or 256.");
        }
     


     try
     {
            KeySpec keySpec = new PBEKeySpec(password, iv, iterationCount, keyLength);
            SecretKeyFactory keyFactory = SecretKeyFactory.getInstance("PBKDF2WithHmacSHA1");
            byte[] keyBytes = keyFactory.generateSecret(keySpec).getEncoded();
            SecretKey skey = new SecretKeySpec(keyBytes, "AES");
            return skey.getEncoded();
        }
     catch (Exception e)
     {
            throw e;
        }
    }

    public static byte[] encryptAES(byte[] key, byte[] clear, byte[] iv) throws Exception
    {
     if (key == null) {
            throw new Exception("Key is empty");
        }
     
     if ((key.length != 16) && (key.length != 24) && (key.length != 32)) {
            throw new Exception("Key Length is invalid. It can be only 16,24 or 32.");
        }
     
     if (iv == null) {
            throw new Exception("IV is empty");
        }
     
     if (clear == null) {
            throw new Exception("Data is empty");
        }
     try
     {
            SecretKeySpec skeySpec = new SecretKeySpec(key, "AES");
            Cipher cipher = Cipher.getInstance("AES/CBC/PKCS5Padding", "BC");
            IvParameterSpec ivspec = new IvParameterSpec(iv);
            cipher.init(1, skeySpec, ivspec);
            return cipher.doFinal(clear);
        }
     catch (Exception e) {
            throw e;
        }
    }

    public SGSecuror() { }
}
     
}
